using System.IO.Ports;
using System.Threading.Channels;

namespace BillAcceptorSdk;

public class SerialPortTransport : IDisposable
{
    private readonly SerialPort _port;
    private readonly Channel<byte> _channel;

    public event Action<Exception>? ErrorOccurred;

    public SerialPortTransport(string portName, int baudRate, Parity parity)
    {
        _port = new SerialPort
        {
            PortName = portName,
            BaudRate = baudRate,
            DataBits = 8,
            StopBits = StopBits.One,
            Handshake = Handshake.None,
            Parity = parity,
        };

        _channel = Channel.CreateBounded<byte>(new BoundedChannelOptions(4096)
        {
            SingleWriter = true,
            SingleReader = false,
            FullMode = BoundedChannelFullMode.DropOldest
        });

        _port.DataReceived += OnDataReceived;
    }

    public bool IsOpen => _port.IsOpen;
    public string PortName => _port.PortName;

    public void Open()
    {
        if (_port.IsOpen) return;
        _port.Open();
    }

    public void Close()
    {
        if (_port.IsOpen)
            _port.Close();
    }

    public async Task<byte> ReadAsync(CancellationToken ct = default)
    {
        return await _channel.Reader.ReadAsync(ct);
    }

    public async IAsyncEnumerable<byte> ReadStream([System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        while (await _channel.Reader.WaitToReadAsync(ct))
        {
            while (_channel.Reader.TryRead(out var item))
            {
                yield return item;
            }
        }
    }

    public async Task WriteAsync(params byte[] data)
    {
        await _port.BaseStream.WriteAsync(data, 0, data.Length);
        await _port.BaseStream.FlushAsync();
    }

    private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            while (_port.BytesToRead > 0)
            {
                var b = (byte)_port.ReadByte();
                _channel.Writer.TryWrite(b);
            }
        }
        catch (Exception ex)
        {
            ErrorOccurred?.Invoke(ex);
        }
    }

    public void Dispose()
    {
        _port.DataReceived -= OnDataReceived;
        _channel.Writer.TryComplete();
        Close();
        _port.Dispose();
    }
}

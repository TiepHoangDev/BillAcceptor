using System.IO.Ports;

namespace BillAcceptorSdk;

public class SerialPortTransport : IDisposable
{
    private readonly SerialPort _port;
    private event Action<byte>? ByteReceived;
    
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
        {
            _port.Close();
        }
    }

    public async Task<byte> ReadAsync(CancellationToken ct = default)
    {
        var tcs = new TaskCompletionSource<byte>();
        
        Action<byte> handler = data =>
        {
            tcs.TrySetResult(data);
        };

        ByteReceived += handler;

        try
        {
            using (ct.Register(() => tcs.TrySetCanceled()))
            {
                return await tcs.Task;
            }
        }
        finally
        {
            ByteReceived -= handler;
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
                var data = (byte)_port.ReadByte();
                ByteReceived?.Invoke(data);
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
        Close();
        _port.Dispose();
    }
}

using System.IO.Ports;
using System.Text;
using BillAcceptorSdk.Exceptions;
using BillAcceptorSdk.Models;

namespace BillAcceptorSdk
{
    public class TB74BillAcceptor : IBillAcceptorController
    {
        private const byte STX = 0x02;
        private const byte ETX = 0x03;
        private const int BAUD_RATE = 9600;
        private const int DATA_BITS = 8;
        private const Parity PARITY = Parity.None;
        private const StopBits STOP_BITS = StopBits.One;
        private const int MAX_BUFFER_SIZE = 2048;
        private const int DEBOUNCE_MS = 200;

        private SerialPort? _serialPort;
        private readonly List<byte> _buffer = new List<byte>();
        private readonly object _lock = new object();
        private int _totalAmount;
        private DateTime _lastBillTime = DateTime.MinValue;

        private readonly Dictionary<string, BillDenomination> _denominationMap = new Dictionary<string, BillDenomination>
        {
            { "05", BillDenomination.VND_5000 },
            { "10", BillDenomination.VND_10000 },
            { "20", BillDenomination.VND_20000 },
            { "50", BillDenomination.VND_50000 },
            { "100", BillDenomination.VND_100000 },
            { "200", BillDenomination.VND_200000 },
            { "500", BillDenomination.VND_500000 }
        };

        public event EventHandler<BillReceivedEventArgs> BillReceived;
        public event EventHandler<string> ErrorOccurred;

        public bool IsConnected => _serialPort?.IsOpen ?? false;
        public int TotalAmount
        {
            get
            {
                lock (_lock)
                {
                    return _totalAmount;
                }
            }
        }

        public async Task ConnectAsync(string portName)
        {
            if (IsConnected)
            {
                throw new ConnectionException("Already connected to a port");
            }

            try
            {
                _serialPort = new SerialPort(portName)
                {
                    BaudRate = BAUD_RATE,
                    DataBits = DATA_BITS,
                    Parity = PARITY,
                    StopBits = STOP_BITS,
                    Handshake = Handshake.None,
                    ReadTimeout = 500,
                    WriteTimeout = 500
                };

                _serialPort.DataReceived += OnDataReceived;

                await Task.Run(() => _serialPort.Open());
            }
            catch (Exception ex)
            {
                throw new ConnectionException($"Failed to connect to port {portName}", ex);
            }
        }

        public Task DisconnectAsync()
        {
            if (!IsConnected)
            {
                return Task.CompletedTask;
            }

            try
            {
                if (_serialPort != null)
                {
                    _serialPort.DataReceived -= OnDataReceived;
                    _serialPort.Close();
                    _serialPort.Dispose();
                    _serialPort = null;
                }

                lock (_lock)
                {
                    _buffer.Clear();
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new ConnectionException("Failed to disconnect", ex);
            }
        }

        public void ResetTotal()
        {
            lock (_lock)
            {
                _totalAmount = 0;
            }
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    return;
                }

                int bytesToRead = _serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                int bytesRead = _serialPort.Read(buffer, 0, bytesToRead);

                lock (_lock)
                {
                    _buffer.AddRange(buffer);
                    
                    if (_buffer.Count > MAX_BUFFER_SIZE)
                    {
                        _buffer.Clear();
                        OnErrorOccurred("Buffer overflow, cleared");
                        return;
                    }
                }

                ProcessBuffer();
            }
            catch (Exception ex)
            {
                OnErrorOccurred($"Error reading data: {ex.Message}");
            }
        }

        private void ProcessBuffer()
        {
            while (true)
            {
                int stxIndex;
                int etxIndex;
                byte[] frameData;

                lock (_lock)
                {
                    stxIndex = _buffer.IndexOf(STX);
                    if (stxIndex == -1)
                    {
                        if (_buffer.Count > 1024)
                        {
                            _buffer.Clear();
                        }
                        return;
                    }

                    if (stxIndex > 0)
                    {
                        _buffer.RemoveRange(0, stxIndex);
                    }

                    etxIndex = _buffer.IndexOf(ETX);
                    if (etxIndex == -1)
                    {
                        return;
                    }

                    if (etxIndex < 1)
                    {
                        _buffer.RemoveRange(0, etxIndex + 1);
                        continue;
                    }

                    frameData = _buffer.GetRange(1, etxIndex - 1).ToArray();
                    _buffer.RemoveRange(0, etxIndex + 1);
                }

                try
                {
                    ProcessFrame(frameData);
                }
                catch (Exception ex)
                {
                    OnErrorOccurred($"Error processing frame: {ex.Message}");
                }
            }
        }

        private void ProcessFrame(byte[] frameData)
        {
            if (frameData.Length == 0)
            {
                return;
            }

            string dataString = Encoding.ASCII.GetString(frameData)
                .Trim('\0', '\r', '\n', ' ');

            if (!_denominationMap.TryGetValue(dataString, out BillDenomination denomination))
            {
                return;
            }

            DateTime now = DateTime.Now;
            lock (_lock)
            {
                if ((now - _lastBillTime).TotalMilliseconds < DEBOUNCE_MS)
                {
                    return;
                }
                _lastBillTime = now;
            }

            int amount = (int)denomination;
            int newTotal;

            lock (_lock)
            {
                _totalAmount += amount;
                newTotal = _totalAmount;
            }

            var eventArgs = new BillReceivedEventArgs
            {
                Denomination = denomination,
                Amount = amount,
                Timestamp = now,
                TotalAmount = newTotal
            };

            OnBillReceived(eventArgs);
        }

        protected virtual void OnBillReceived(BillReceivedEventArgs e)
        {
            BillReceived?.Invoke(this, e);
        }

        protected virtual void OnErrorOccurred(string message)
        {
            ErrorOccurred?.Invoke(this, message);
        }

        public void Dispose()
        {
            try
            {
                DisconnectAsync().GetAwaiter().GetResult();
            }
            catch
            {
            }
        }
    }
}

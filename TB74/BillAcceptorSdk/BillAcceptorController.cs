using BillAcceptorSdk.Handlers;
using System.IO.Ports;
using System.Net.Http.Headers;

namespace BillAcceptorSdk;

public class BillAcceptorController(BillAcceptorConfig config)
{
    public event EventHandler<string>? OnLog;
    public event EventHandler<long>? OnAmountChange;

    void _log(string msg, params object[] args)
    {
        OnLog?.Invoke(this, string.Format(msg, args));
    }

    public async Task<long> WaitAmountAsync(CancellationToken cancellationToken)
    {
        using var powerTransport = new SerialPortTransport(config.PowerTranportCom, 9600, Parity.None);
        using var billTransport = new SerialPortTransport(config.BillTranportCom, 9600, Parity.Even);

        powerTransport.Open();
        _log("Power transport opened on {0}", config.PowerTranportCom);

        await powerTransport.WriteAsync([85, 86, 0, 0, 0, 1, 1, 173]);
        _log("Power ON command sent");

        await Task.Delay(500, cancellationToken);

        billTransport.Open();
        _log("Bill transport opened on {0}", config.BillTranportCom);

        var handleInput = new BillAcceptorHandlerInput
        {
            BATranport = billTransport,
            Config = config,
        };
        var handlers = new List<IBillAcceptorHandler>
        {
            new PowerUpBillAcceptorHandler(handleInput)
            {
                OnSuccess = async ()=> await SetEnableBA(billTransport, true),
            },
            new EscrowBillAcceptorHandler(handleInput),
            new ResetBillAcceptorHandler(handleInput),
            new GetStatusBillAcceptorHandler(handleInput),
        };

        try
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var currentAmount = config.AmountAccepted.Sum();
                var data = await billTransport.ReadAsync(cancellationToken);
                _log("[{1}] Received data: 0x{0:X2}", data, currentAmount);

                var handler = handlers.FirstOrDefault(h => h.CanHandle(data));
                if (handler != null) await handler.HandleResponse(data);
                else _log("No handler for data: 0x{0:X2}", data);

                var amountNow = config.AmountAccepted.Sum();
                if (amountNow != currentAmount)
                {
                    OnAmountChange?.Invoke(this, amountNow);
                }

                if (amountNow >= config.TotalAmount)
                {
                    return amountNow;
                }
            }
        }
        catch (Exception ex)
        {
            _log(ex.Message);
            throw;
        }
        finally
        {
            await SetEnableBA(billTransport, false);
            _log("Bill transport Disable");

            await powerTransport.WriteAsync([85, 86, 0, 0, 0, 1, 2, 174]);
            _log("Power transport OFF on {0}", config.PowerTranportCom);

            foreach (var item in handlers)
            {
                item.Dispose();
            }
        }
    }

    public async Task SetEnableBA(SerialPortTransport billTransport, bool isEnable)
    {
        var code = isEnable ? config.ProtocolConfig.EnableByte : config.ProtocolConfig.DisableByte;
        await billTransport.WriteAsync((byte)code);
    }

}

public class BillAcceptorConfig
{
    public required string BillTranportCom { get; set; }
    public required string PowerTranportCom { get; set; }
    public required long TotalAmount { get; set; }
    public List<long> AmountAccepted { get; set; } = [];
    public Action<string>? Log { get; set; }
    public BillAcceptorProtocolConfig ProtocolConfig { get; set; } = BillAcceptorProtocolConfig.Default;
}


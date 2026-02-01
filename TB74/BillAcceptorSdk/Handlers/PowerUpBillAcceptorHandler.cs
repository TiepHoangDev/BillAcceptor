namespace BillAcceptorSdk.Handlers;

public class PowerUpBillAcceptorHandler : BaseBillAcceptorHandler
{
    public PowerUpBillAcceptorHandler(BillAcceptorHandlerInput acceptorHandlerInput) : base(acceptorHandlerInput)
    {
    }

    public override bool CanHandle(byte data)
    {
        return data == Config.ProtocolConfig.PowerUpByte;
    }

    public override async Task HandleResponse(byte data)
    {
        Log("Enter mode: PowerUp");

        var res = await BATranport.ReadAsync();
        Log("PowerUp response: {0:X2}", res);

        if (res == Config.ProtocolConfig.PowerUpResponseByte)
        {
            await BATranport.WriteAsync(new byte[] { Config.ProtocolConfig.AckByte });
            Log("Reply OK");

            RaiseSuccess();
            return;
        }
        Log($"PowerUp failed. Response wrong byte code ({res:X2})");
    }
}


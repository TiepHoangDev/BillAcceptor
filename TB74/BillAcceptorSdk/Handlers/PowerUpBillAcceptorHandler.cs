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

    public async override Task<bool> HandleResponse(byte data)
    {
        Log("Enter mode: PowerUp");

        var res = await BATranport.ReadAsync();
        Log("PowerUp response: {0}", res.ToString("X2"));

        if (res == Config.ProtocolConfig.PowerUpResponseByte)
        {
            await BATranport.WriteAsync([Config.ProtocolConfig.AckByte]);
            Log("Reply OK");

            RaiseSuccess();
            return true;
        }
        Log($"PowerUp failed. Response wrong byte code ({res:X2})");

        return false;
    }
}



namespace BillAcceptorSdk.Handlers;
public class EscrowBillAcceptorHandler : BaseBillAcceptorHandler
{
    public EscrowBillAcceptorHandler(BillAcceptorHandlerInput billAcceptorHandlerInput) : base(billAcceptorHandlerInput)
    {
    }

    public override bool CanHandle(byte data)
    {
        return data == Config.ProtocolConfig.EscrowStartByte;
    }

    public async override Task HandleResponse(byte data)
    {
        Log("Enter mode: ESCROW");

        var maxAmount = Config.TotalAmount - Config.AmountAccepted.Sum();

        using var timeoutCts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
        var billData = await BATranport.ReadAsync(timeoutCts.Token);
        Log("Receiver Escrow: {0}", billData);


        var replyAccept = false;
        if (!Config.ProtocolConfig.BillTypeMapping.ContainsKey(billData))
        {
            Log("-> Config not accept Amount with value 0x{0:X2}", billData);
            replyAccept = false;
        }
        else
        {
            var amount = Config.ProtocolConfig.BillTypeMapping[billData];
            Log("-> Escrow Amount: {0}", amount);

            if (amount > maxAmount)
            {
                Log("-> Config not accept Amount with value 0x{0:X2}", billData);
                replyAccept = false;
            }
            else
            {
                replyAccept = true;
                Log("Send accept Escrow");
            }
        }

        var replyCode = replyAccept ? Config.ProtocolConfig.AckByte : Config.ProtocolConfig.RejectByte;
        var expectedRep = replyAccept ? Config.ProtocolConfig.StackedByte : Config.ProtocolConfig.RejectedByte;
        await BATranport.WriteAsync((byte)replyCode);

        var rep = await BATranport.ReadAsync(timeoutCts.Token);
        Log("Bill Response Escrow: {0}", rep);

        if (replyAccept && rep == expectedRep)
        {
            // OK stacked
            var acceptAmount = Config.ProtocolConfig.BillTypeMapping[billData];
            Log("Accept amount: {0}", acceptAmount);

            Config.AmountAccepted.Add(acceptAmount);

            RaiseSuccess();
        }
    }
}


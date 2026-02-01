
namespace BillAcceptorSdk.Handlers;

public class ResetBillAcceptorHandler : BaseBillAcceptorHandler
{
    private readonly PowerUpBillAcceptorHandler _powerUpBillAcceptor;

    public ResetBillAcceptorHandler(BillAcceptorHandlerInput billAcceptorHandlerInput) : base(billAcceptorHandlerInput)
    {
        _powerUpBillAcceptor = new PowerUpBillAcceptorHandler(billAcceptorHandlerInput);
        _powerUpBillAcceptor.OnSuccess = RaiseSuccess;
    }

    public override async Task SendAsync()
    {
        await BATranport.WriteAsync(0x30);
    }

    public override bool CanHandle(byte data)
    {
        return _powerUpBillAcceptor.CanHandle(data);
    }

    public override async Task HandleResponse(byte data)
    {
        await _powerUpBillAcceptor.HandleResponse(data);
    }
}


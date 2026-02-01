namespace BillAcceptorSdk.Handlers;

public abstract class BaseBillAcceptorHandler : IBillAcceptorHandler
{
    protected readonly BillAcceptorConfig Config;
    protected readonly BillAcceptorHandlerInput Input;
    protected readonly SerialPortTransport BATranport;

    protected BaseBillAcceptorHandler(BillAcceptorHandlerInput billAcceptorHandlerInput)
    {
        Input = billAcceptorHandlerInput;
        Config = billAcceptorHandlerInput.Config;
        BATranport = billAcceptorHandlerInput.BATranport;
    }

    public Action? OnSuccess { get; set; }

    public abstract Task HandleResponse(byte data);
    public abstract bool CanHandle(byte data);

    public virtual Task SendAsync() => Task.CompletedTask;

    public virtual void Log(string format, params object[] args)
    {
        Config.Log?.Invoke(string.Format(format, args));
    }

    public virtual void RaiseSuccess()
    {
        OnSuccess?.Invoke();
    }

    public virtual void Dispose()
    {
    }
}


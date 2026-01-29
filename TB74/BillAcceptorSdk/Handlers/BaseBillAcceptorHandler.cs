namespace BillAcceptorSdk.Handlers;

public abstract class BaseBillAcceptorHandler(BillAcceptorHandlerInput billAcceptorHandlerInput) : IBillAcceptorHandler
{
    protected readonly BillAcceptorConfig Config = billAcceptorHandlerInput.Config;
    protected readonly BillAcceptorHandlerInput Input = billAcceptorHandlerInput;
    protected readonly SerialPortTransport BATranport = billAcceptorHandlerInput.BATranport;

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


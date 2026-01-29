namespace BillAcceptorSdk.Handlers;

public interface IBillAcceptorHandler : IDisposable
{
    Task SendAsync();
    Task HandleResponse(byte data);
    bool CanHandle(byte data);
}

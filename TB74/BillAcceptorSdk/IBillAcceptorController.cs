using System;
using System.Threading.Tasks;
using BillAcceptorSdk.Models;

namespace BillAcceptorSdk
{
    public interface IBillAcceptorController : IDisposable
    {
        event EventHandler<BillReceivedEventArgs> BillReceived;
        event EventHandler<string> ErrorOccurred;
        
        bool IsConnected { get; }
        int TotalAmount { get; }
        
        Task ConnectAsync(string portName);
        Task DisconnectAsync();
        void ResetTotal();
    }
}

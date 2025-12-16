using System;

namespace BillAcceptorSdk.Models
{
    public class BillReceivedEventArgs : EventArgs
    {
        public BillDenomination Denomination { get; set; }
        public int Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public int TotalAmount { get; set; }
    }
}

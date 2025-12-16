using System;

namespace BillAcceptorSdk.Exceptions
{
    public class BillAcceptorException : Exception
    {
        public BillAcceptorException(string message) : base(message)
        {
        }

        public BillAcceptorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

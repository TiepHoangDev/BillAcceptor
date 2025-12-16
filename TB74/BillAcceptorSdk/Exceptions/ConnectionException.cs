using System;

namespace BillAcceptorSdk.Exceptions
{
    public class ConnectionException : BillAcceptorException
    {
        public ConnectionException(string message) : base(message)
        {
        }

        public ConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

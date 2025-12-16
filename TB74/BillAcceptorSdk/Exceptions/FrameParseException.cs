using System;

namespace BillAcceptorSdk.Exceptions
{
    public class FrameParseException : BillAcceptorException
    {
        public FrameParseException(string message) : base(message)
        {
        }

        public FrameParseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

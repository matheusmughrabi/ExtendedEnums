using System.Runtime.Serialization;

namespace ExtendedEnums.Exceptions
{
    public class ExtendedEnumsException : Exception
    {
        public ExtendedEnumsException()
        {
        }

        public ExtendedEnumsException(string? message) : base(message)
        {
        }

        public ExtendedEnumsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExtendedEnumsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

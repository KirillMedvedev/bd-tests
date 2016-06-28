using System;
using System.Runtime.Serialization;

namespace bd.common
{
    public class ResourceResolveException : Exception
    {
        public ResourceResolveException()
        {
        }

        public ResourceResolveException(string message) : base(message)
        {
        }

        public ResourceResolveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResourceResolveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;

namespace SOHome.Common.Exceptions
{

    [Serializable]
    public class RegisterException : Exception
    {
        public RegisterException() { }
        public RegisterException(string message) : base(message) { }
        public RegisterException(string message, Exception inner) : base(message, inner) { }
        protected RegisterException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

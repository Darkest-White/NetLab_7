using System;
using System.Runtime.Serialization;

namespace ClassLibraryFacultatives.Exception
{

    [Serializable]
    public class InvalidSubjectException : System.Exception
    {
        public InvalidSubjectException()
        {
        }

        public InvalidSubjectException(string message) : base(message)
        {
        }

        public InvalidSubjectException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected InvalidSubjectException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}

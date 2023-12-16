using System;
using System.Runtime.Serialization;

namespace ClassLibraryFacultatives.Exception
{

    [Serializable]
    public class InvalidStudentException : System.Exception
    {
        public InvalidStudentException()
        {
        }

        public InvalidStudentException(string message) : base(message)
        {
        }

        public InvalidStudentException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected InvalidStudentException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}

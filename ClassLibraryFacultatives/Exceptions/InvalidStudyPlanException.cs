using System;
using System.Runtime.Serialization;

namespace ClassLibraryFacultatives.Exception
{

    [Serializable]
    public class InvalidStudyPlanException : System.Exception
    {
        public InvalidStudyPlanException()
        {
        }

        public InvalidStudyPlanException(string message) : base(message)
        {
        }

        public InvalidStudyPlanException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected InvalidStudyPlanException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}

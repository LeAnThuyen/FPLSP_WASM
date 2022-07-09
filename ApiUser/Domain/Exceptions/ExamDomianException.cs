using System;

namespace ApiUser.Domain.Exceptions
{
    public class ExamDomianException : Exception
    {
        public ExamDomianException()
        { }

        public ExamDomianException(string message)
            : base(message)
        { }

        public ExamDomianException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

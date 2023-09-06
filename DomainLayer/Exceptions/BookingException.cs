namespace DomainLayer.Exceptions
{
    public class InstructorNotAvailableException : Exception
    {
        public InstructorNotAvailableException(string message) : base(message)
        {
        }

        public InstructorNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InstructorAlreadyBookedException : Exception
    {
        public InstructorAlreadyBookedException(string message) : base(message)
        {
        }

        public InstructorAlreadyBookedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

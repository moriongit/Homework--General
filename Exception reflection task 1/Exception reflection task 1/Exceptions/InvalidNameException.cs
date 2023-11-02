using System;

namespace MyProject.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message) : base(message) { }
    }
}



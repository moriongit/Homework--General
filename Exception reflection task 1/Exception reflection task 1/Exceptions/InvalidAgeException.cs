using System;

namespace MyProject.Exceptions
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message) { }
    }
}


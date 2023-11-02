using System;

namespace MyProject.Exceptions
{
    public class InvalidPhoneFormatException : Exception
    {
        public InvalidPhoneFormatException(string message) : base(message) { }
    }
}
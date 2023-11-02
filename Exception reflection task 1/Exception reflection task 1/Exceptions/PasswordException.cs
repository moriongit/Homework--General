using System;

namespace MyProject.Exceptions
{
    public class PasswordException : Exception
    {
        public PasswordException(string message) : base(message) { }
    }
}
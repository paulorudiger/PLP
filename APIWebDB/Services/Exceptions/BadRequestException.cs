using System;

namespace APIWebDB.Services.Exceptions
{
    public class BadRequestException : Exception
    {

        public BadRequestException(String message) : base(message) { }

    }
}

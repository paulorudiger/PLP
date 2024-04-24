using System;

namespace APIWebDB.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(String message) : base(message) { }
    }
}

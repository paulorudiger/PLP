using System;

namespace TrabalhoFinalRESTFull.Services.Exceptions
{
    public class BadRequestException : Exception
    {

        public BadRequestException(String message) : base(message) { }

    }
}

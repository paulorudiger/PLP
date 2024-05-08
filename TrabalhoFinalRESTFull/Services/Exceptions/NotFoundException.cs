using System;

namespace TrabalhoFinalRESTFull.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(String message) : base(message) { }
    }
}

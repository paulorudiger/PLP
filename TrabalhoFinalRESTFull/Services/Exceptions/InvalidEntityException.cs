using System;

namespace TrabalhoFinalRESTFull.Services.Exceptions
{
    public class InvalidEntityException : Exception
    {

        public InvalidEntityException(string message) : base(message) { 
            
        
        }

    }
}

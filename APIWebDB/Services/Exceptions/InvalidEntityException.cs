using System;

namespace APIWebDB.Services.Exceptions
{
    public class InvalidEntityException : Exception
    {

        public InvalidEntityException(string message) : base(message) { 
            
        
        }

    }
}

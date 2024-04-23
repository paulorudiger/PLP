using APIWebDB.Services.DTOs;
using APIWebDB.Services.Exceptions;

namespace APIWebDB.Services.Validate
{
    public class ClienteValidate
    {
        public static void Execute(ClienteDTO dto)
        {

            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new InvalidEntity("Campo Nome é obrigatório");

            }
            if (string.IsNullOrEmpty(dto.Documento))
            {
                throw new InvalidEntity("Campo Documento é obrigatório");
            }

            try
            {


            }

        }


    }
}

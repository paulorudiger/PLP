using APIWebDB.BaseDados.Models;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Exceptions;

namespace APIWebDB.Services.Validate
{
    public class ClienteValidate
    {

        private static void ValidateDocument(TipoDocumento tipo, string documento)
        {

            switch (tipo)
            {
                case TipoDocumento.CPF:
                    {
                        if (documento.Length != 11)
                        {
                            throw new BadRequestException("O CPF precisa ter 11 digitos");
                        }
                        break;
                    }
                case TipoDocumento.CNPJ:
                    {
                        if (documento.Length != 14)
                        {
                            throw new BadRequestException("O CNPJ precisa ter 14 digitos");
                        }
                        break;
                    }
                case TipoDocumento.Passaporte:
                    {
                        if (documento.Length != 8)
                        {
                            throw new BadRequestException("O CPF precisa ter 8 digitos");
                        }
                        break;
                    }
                case TipoDocumento.CNH:
                    {
                        if (documento.Length != 11)
                        {
                            throw new BadRequestException("A CNH precisa ter 11 digitos");
                        }
                        break;
                    }
                case TipoDocumento.Outros:
                    break;
            }
        }

        public static void Execute(ClienteDTO dto)
        {

            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new InvalidEntityException("Campo Nome é obrigatório");

            }
            if (string.IsNullOrEmpty(dto.Documento))
            {
                throw new InvalidEntityException("Campo Documento é obrigatório");
            }

            TipoDocumento tipo = TipoDocumento.Outros;
            try
            {
                tipo = (TipoDocumento)dto.Tipodoc;

            }
            catch
            {
                throw new InvalidEntityException($"O TipoDOc {dto.Tipodoc} é inválido.");

            }

            ValidateDocument(tipo, dto.Documento);

        }


    }
}

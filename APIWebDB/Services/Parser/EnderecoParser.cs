using APIWebDB.BaseDados.Models;
using APIWebDB.Services.DTOs;
using System;

namespace ApiWebDB.Services.Parser
{
    public static class EnderecoParser
    {
        public static TbEndereco ToEntity(EnderecoDTO dto)
        {
            return new TbEndereco
            {
                Cep = dto.Cep,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                Clienteid = dto.Clienteid,
                Status = dto.Status
            };
        }

        internal static void UpdateEntityFromDTO(EnderecoDTO endereco, TbEndereco existingEntity)
        {

            existingEntity.Cep = endereco.Cep;
            existingEntity.Logradouro = endereco.Logradouro;
            existingEntity.Numero = endereco.Numero;
            existingEntity.Complemento = endereco.Complemento;
            existingEntity.Bairro = endereco.Bairro;
            existingEntity.Cidade = endereco.Cidade;
            existingEntity.Uf = endereco.Uf;
            existingEntity.Clienteid = endereco.Clienteid;
            existingEntity.Status = endereco.Status;


        }
    }
}
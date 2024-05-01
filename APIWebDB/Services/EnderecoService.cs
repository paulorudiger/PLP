using ApiWebDB.Services.Parser;
using APIWebDB.BaseDados.Models;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Exceptions;
using APIWebDB.Services.Validate;
using System.Collections.Generic;
using System.Linq;

namespace APIWebDB.Services
{
    public class EnderecoService
    {

        private readonly ApidbContext _dbcontext;

        public EnderecoService(ApidbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public TbEndereco Insert(EnderecoDTO dto)
        {

            if (!EnderecoValidate.Execute(dto))
            {
                return null;
            }

            var entity = EnderecoParser.ToEntity(dto);

            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            return entity;
        }

        public TbEndereco Put(EnderecoDTO dto, int id)
        {
            if (!EnderecoValidate.Execute(dto))
            {
                return null;
            }


            var entity = EnderecoParser.ToEntity(dto);

            var EnderecoById = GetById(id);
            EnderecoById.Cep = entity.Cep;
            EnderecoById.Logradouro = entity.Logradouro;
            EnderecoById.Numero = entity.Numero;
            EnderecoById.Complemento = entity.Complemento;
            EnderecoById.Bairro = entity.Bairro;
            EnderecoById.Cidade = entity.Cidade;
            EnderecoById.Uf = entity.Uf;
            EnderecoById.Clienteid = entity.Clienteid;
            EnderecoById.Status = entity.Status;

            _dbcontext.Update(EnderecoById);
            _dbcontext.SaveChanges();

            return EnderecoById;

        }

        public void Delete(int id)
        {
            var Endereco = GetById(id);

            if (Endereco == null)
            {
                throw new NotFoundException($"Entidade não encontrada com o id: {id}");
            }
            _dbcontext.Remove(Endereco);
            _dbcontext.SaveChanges();

        }

        public TbEndereco Update(int id, EnderecoDTO dto)
        {
            var existingEntity = GetById(id);
            if (existingEntity == null)
            {
               throw new NotFoundException($"Endereco com o id {id} não foi encontrado");
            }

           var endereco = EnderecoParser.ToEntity(dto);

            existingEntity.Cep = endereco.Cep;
            existingEntity.Logradouro = endereco.Logradouro;
            existingEntity.Numero = endereco.Numero;
            existingEntity.Complemento = endereco.Complemento;
            existingEntity.Bairro = endereco.Bairro;
            existingEntity.Cidade = endereco.Cidade;
            existingEntity.Uf = endereco.Uf;
            existingEntity.Status = endereco.Status;

            _dbcontext.Update(existingEntity);
            _dbcontext.SaveChanges();

            return existingEntity;
        }

        public TbEndereco GetById(int id)
        {
            return _dbcontext.TbEnderecos.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TbEndereco> GetAll(int idCliente)
        {
            var existingEntities = _dbcontext.TbEnderecos.Where(e => e.Clienteid == idCliente).ToList();
            if (existingEntities == null || existingEntities.Count == 0)
            {
                throw new NotFoundException("Nenhum endereço encontrado para o cliente especificado");
            }
            return existingEntities;
        }
    }
}

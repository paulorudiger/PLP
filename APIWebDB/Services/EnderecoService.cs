using ApiWebDB.Services.Parser;
using APIWebDB.BaseDados.Models;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Parser;
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

            /* <summary> asdasd
             * if (Endereco == null)
              {
                  throw new NotFoundException($"Entidade não encontrada com o id: {id}");
              }*/
            _dbcontext.Remove(Endereco);
            _dbcontext.SaveChanges();

        }

        public TbEndereco Update(TbEndereco entity)
        {
            _dbcontext.Update(entity);
            _dbcontext.SaveChanges();

            return entity;
        }

        public TbEndereco GetById(int id)
        {
            return _dbcontext.TbEnderecos.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TbEndereco> GetAll()
        {
            /*    var existingEntity = _dbcontext.TbEndereco.ToList();
                if (existingEntity == null || existingEntity.Count == 0)
                {
                    throw new NotFoundException("Nenhum registro encontrado");
                } 
                return existingEntity;*/
            return null;
        }




    }
}

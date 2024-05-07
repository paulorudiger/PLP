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
            var EnderecoById = GetById(id);
            if (EnderecoById == null)
            {
                throw new NotFoundException($"O endereço com o id {id} não foi encontrado.");
            }

            if (!EnderecoValidate.Execute(dto))
            {
                return null;
            }

            var enderecoDTO = EnderecoParser.ToEntity(dto);
            
            EnderecoById.Cep = enderecoDTO.Cep;
            EnderecoById.Logradouro = enderecoDTO.Logradouro;
            EnderecoById.Numero = enderecoDTO.Numero;
            EnderecoById.Complemento = enderecoDTO.Complemento;
            EnderecoById.Bairro = enderecoDTO.Bairro;
            EnderecoById.Cidade = enderecoDTO.Cidade;
            EnderecoById.Uf = enderecoDTO.Uf;
            EnderecoById.Clienteid = enderecoDTO.Clienteid;
            EnderecoById.Status = enderecoDTO.Status;

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

        public TbEndereco GetById(int id)
        {
            return _dbcontext.TbEnderecos.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TbEndereco> GetAll(int idCliente)
        {
            var listEnderecos = _dbcontext.TbEnderecos.Where(e => e.Clienteid == idCliente).ToList();
            if (listEnderecos == null || listEnderecos.Count == 0)
            {
                throw new NotFoundException("Nenhum endereço encontrado para o cliente especificado");
            }
            return listEnderecos;
        }
    }
}

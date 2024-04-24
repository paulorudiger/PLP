using APIWebDB.BaseDados.Models;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Parser;
using APIWebDB.Services.Validate;
using System;
using System.Data.Common;
using System.Linq;

namespace APIWebDB.Services
{
    public class ClienteService
    {

        private readonly ApidbContext _dbcontext;

        public ClienteService(ApidbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public TbCliente Insert(ClienteDTO dto) {

            if(!ClienteValidate.Execute(dto))
            {
                return null;
            }

            var entity = ClienteParser.ToEntity(dto);

            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            return entity;
        
        }

        public TbCliente Put(ClienteDTO dto, int id) {
            if (!ClienteValidate.Execute(dto))
            {
                return null;
            }

            var entity = ClienteParser.ToEntity(dto);

            var ClienteById = GetById(id);
            ClienteById.Nome = entity.Nome;
            ClienteById.Nascimento = entity.Nascimento;
            ClienteById.Telefone = entity.Telefone;
            ClienteById.Documento = entity.Documento;   
            ClienteById.Tipodoc = entity.Tipodoc;
            ClienteById.Alteradoem = DateTime.Now;
                
            _dbcontext.Update(ClienteById);
            _dbcontext.SaveChanges();

            return ClienteById;
            
        }

        public TbCliente Update(TbCliente entity)
        {
            _dbcontext.Update(entity);
            _dbcontext.SaveChanges();

            return entity;
        }

        public TbCliente GetById(int id)
        {
            return _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
        }

    }
}

using APIWebDB.BaseDados.Models;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Exceptions;
using APIWebDB.Services.Parser;
using APIWebDB.Services.Validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var ClienteById = GetById(id);
            if (ClienteById == null)
            {
                throw new NotFoundException($"O cliente com o id {id} não foi encontrado.");
            }

            if (!ClienteValidate.Execute(dto))
            {
                return null;
            }

            var entity = ClienteParser.ToEntity(dto);
           
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
        
        public void Delete(int id) {
            var Cliente = GetById(id);

            if (Cliente == null )
            {
                throw new NotFoundException($"Entidade não encontrada com o id: {id}");
            }
            _dbcontext.Remove(Cliente);
            _dbcontext.SaveChanges();

        }

        public TbCliente GetById(int id)
        {
            return _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TbCliente> GetAll()
        {
            var existingEntity = _dbcontext.TbClientes.ToList();
            if (existingEntity == null || existingEntity.Count == 0)
            {
                throw new NotFoundException("Nenhum registro encontrado");
            }
            return existingEntity;
        }

    }
}

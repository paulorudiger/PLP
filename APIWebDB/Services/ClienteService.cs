using APIWebDB.BaseDados.Models;
using APIWebDB.Services.DTOs;
using APIWebDB.Services.Parser;
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

            var entity = ClienteParser.ToEntity(dto);

            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            return entity;
        
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

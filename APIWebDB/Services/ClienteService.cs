using APIWebDB.BaseDados.Models;

namespace APIWebDB.Services
{
    public class ClienteService
    {

        private readonly ApidbContext _dbcontext;

        public ClienteService(ApidbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public TbCliente Insert(TbCliente entity) {
       
            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            return entity;
        
        }

    }
}

using TrabalhoFinalRESTFull.BaseDados.Models;
using TrabalhoFinalRESTFull.Services.DTOs;

namespace TrabalhoFinalRESTFull.Services
{
    public class ProductService
    {

        private readonly TfDbContext _dbcontext;
        public ProductService(TfDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public TbProduct Insert(ProductDTO dto)
        {

          /* if (!ClienteValidate.Execute(dto))
            {
                return null;
            }*/

          //  var entity = ClienteParser.ToEntity(dto);

          //  _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            //   return entity;
            return null;

        }



    }
}

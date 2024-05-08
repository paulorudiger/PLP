using TrabalhoFinalRESTFull.BaseDados.Models;
using TrabalhoFinalRESTFull.Services.DTOs;

namespace TrabalhoFinalRESTFull.Services.Parser
{
    public class ProductParser
    {

        public static TbProduct ToEntity(ProductDTO dto)
        {
            return new TbProduct
            {
                Description = dto.Description,
                Barcode = dto.Barcode,
                Barcodetype = dto.Barcodetype,
                Stock = dto.Stock,
                Price = dto.Price,
                Costprice = dto.Costprice
            };
        }
    }
}

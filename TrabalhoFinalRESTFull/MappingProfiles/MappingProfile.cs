namespace TrabalhoFinalRESTFull.MappingProfiles
{
    using AutoMapper;
    using TrabalhoFinalRESTFull.BaseDados.Models;
    using TrabalhoFinalRESTFull.Services.DTOs;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TbProduct, ProductDTO>();
            CreateMap<TbPromotion, PromotionDTO>();
            CreateMap<TbSale, SaleDTO>();
            CreateMap<TbStockLog, StockLogDTO>();

            // Adicione outros mapeamentos aqui
        }
    }

}

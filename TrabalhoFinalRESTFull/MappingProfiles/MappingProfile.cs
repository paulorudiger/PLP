namespace TrabalhoFinalRESTFull.MappingProfiles
{
    using AutoMapper;
    using TrabalhoFinalRESTFull.BaseDados.Models;
    using TrabalhoFinalRESTFull.Services.DTOs;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ReverseMap() garante que a conversão será feita em ambos os sentidos
            CreateMap<TbProduct, ProductDTO>().ReverseMap();
            CreateMap<TbPromotion, PromotionDTO>().ReverseMap();
            CreateMap<TbSale, SaleDTO>().ReverseMap();
            CreateMap<TbStockLog, StockLogDTO>().ReverseMap();

        }
    }

}

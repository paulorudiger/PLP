using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using TrabalhoFinalRESTFull.BaseDados.Models;
using TrabalhoFinalRESTFull.Services.DTOs;
using TrabalhoFinalRESTFull.Services.Exceptions;
using TrabalhoFinalRESTFull.Services.Validate;

namespace TrabalhoFinalRESTFull.Services
{
    public class PromotionService
    {
        private readonly TfDbContext _dbcontext;
        private readonly IMapper _mapper;

        public PromotionService(TfDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public TbPromotion Insert(PromotionDTO dto)
        {
            var entity = _mapper.Map<TbPromotion>(dto);

            var validator = new PromotionValidator();
            validator.ValidateAndThrow(entity);

            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            return entity;
        }

        public TbPromotion Put(PromotionDTO dto, int id)
        {
            var promotionById = GetById(id);
            if (promotionById == null)
            {
                throw new NotFoundException($"A promoção com o id {id} não foi encontrada.");
            }

            Console.WriteLine(promotionById);
            Console.WriteLine(dto);

           // _mapper.Map(dto, promotionById);

            promotionById.Startdate = dto.Startdate;
            promotionById.Enddate = dto.Enddate;
            promotionById.Promotiontype = dto.Promotiontype;
            promotionById.Productid = dto.Productid;
            promotionById.Value = dto.Value;

            var validator = new PromotionValidator();
            validator.ValidateAndThrow(promotionById);

            _dbcontext.Update(promotionById);
            _dbcontext.SaveChanges();

            return promotionById;
        }

        public void Delete(int id)
        {
            var promotion = GetById(id);

            if (promotion == null)
            {
                throw new NotFoundException($"Promoção não encontrada com o id: {id}");
            }

            _dbcontext.Remove(promotion);
            _dbcontext.SaveChanges();
        }

        public TbPromotion GetById(int id)
        {
            var promotion = _dbcontext.TbPromotions.FirstOrDefault(p => p.Id == id);
            if (promotion == null)
            {
                throw new NotFoundException($"Promoção não encontrada com o id: {id}");
            }
            return promotion;
        }

        public IEnumerable<TbPromotion> GetPromotionsByProductAndPeriod(int productId, DateTime startDate, DateTime endDate)
        {
            var promotions = _dbcontext.TbPromotions
                .Where(p => p.Productid == productId && p.Startdate <= endDate && p.Enddate >= startDate)
                .ToList();
            if (promotions == null || promotions.Count == 0)
            {
                throw new NotFoundException("Nenhuma promoção encontrada para o período especificado");
            }
            return promotions;
        }

        public IEnumerable<TbPromotion> GetAll()
        {
            var promotions = _dbcontext.TbPromotions.ToList();
            if (promotions == null || promotions.Count == 0)
            {
                throw new NotFoundException("Nenhuma promoção encontrada");
            }
            return promotions;
        }
    }
}

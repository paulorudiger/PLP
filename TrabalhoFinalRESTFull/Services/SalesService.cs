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
    public class SalesService
    {
        private readonly TfDbContext _dbcontext;
        private readonly IMapper _mapper;

        public SalesService(TfDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public TbSale Insert(SaleDTO dto)
        {
            // Mapear DTO para entidade
            var entity = _mapper.Map<TbSale>(dto);

            // Validar entidade
            var validator = new SaleValidator();
            validator.ValidateAndThrow(entity);

            // Validar e atualizar estoque
            var product = _dbcontext.TbProducts.FirstOrDefault(p => p.Id == entity.Productid);
            if (product == null)
            {
                throw new NotFoundException($"Produto não encontrado com o id: {entity.Productid}");
            }

            if (product.Stock < entity.Qty)
            {
                throw new InvalidEntityException($"Estoque insuficiente para o produto {product.Description}");
            }

            product.Stock -= entity.Qty;
            _dbcontext.Update(product);

            // Calcular promoções ativas
            var promotions = _dbcontext.TbPromotions
                .Where(p => p.Productid == product.Id && p.Startdate <= DateTime.Now && p.Enddate >= DateTime.Now)
                .OrderBy(p => p.Promotiontype)
                .ToList();

            foreach (var promotion in promotions)
            {
                if (promotion.Promotiontype == 0)
                {
                    // % de desconto
                    entity.Price -= entity.Price * (promotion.Value / 100);
                }
                else if (promotion.Promotiontype == 1)
                {
                    // Valor fixo de desconto
                    entity.Price -= promotion.Value;
                }
            }

            // Inserir venda
            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            // Inserir log de estoque
            var log = new TbStockLog
            {
                Productid = product.Id,
                Qty = -entity.Qty,
                Createdat = DateTime.Now
            };

            _dbcontext.Add(log);
            _dbcontext.SaveChanges();

            return entity;
        }

        public TbSale GetByCode(string code)
        {
            var sale = _dbcontext.TbSales.FirstOrDefault(s => s.Code == code);
            if (sale == null)
            {
                throw new NotFoundException($"Venda não encontrada com o código: {code}");
            }
            return sale;
        }

        public IEnumerable<SaleReportDTO> GetSalesReportByPeriod(DateTime startDate, DateTime endDate)
        {
            var sales = _dbcontext.TbSales
                .Where(s => s.Createat >= startDate && s.Createat <= endDate)
                .GroupBy(s => s.Code)
                .Select(g => new SaleReportDTO
                {
                    Code = g.Key,
                    Sales = g.Select(s => new SaleItemDTO
                    {
                        Description = s.Product.Description,
                        Price = s.Price,
                        Qty = s.Qty,
                        Date = s.Createat
                    }).ToList()
                }).ToList();

            if (sales == null || sales.Count == 0)
            {
                throw new NotFoundException("Nenhuma venda encontrada para o período especificado");
            }
            return sales;
        }

        public IEnumerable<TbSale> GetAll()
        {
            var sales = _dbcontext.TbSales.ToList();
            if (sales == null || sales.Count == 0)
            {
                throw new NotFoundException("Nenhuma venda encontrada");
            }
            return sales;
        }
    }
}

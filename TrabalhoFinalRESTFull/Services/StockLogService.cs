using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using TrabalhoFinalRESTFull.BaseDados.Models;
using TrabalhoFinalRESTFull.Services.DTOs;
using TrabalhoFinalRESTFull.Services.Exceptions;
using TrabalhoFinalRESTFull.Services.Validate;

namespace TrabalhoFinalRESTFull.Services
{
    public class StockLogService
    {
        private readonly TfDbContext _dbcontext;
        private readonly IMapper _mapper;

        public StockLogService(TfDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public TbStockLog Insert(StockLogDTO dto)
        {
            var entity = _mapper.Map<TbStockLog>(dto);

            var validator = new StockLogValidator();
            validator.ValidateAndThrow(entity);

            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            return entity;
        }

        public TbStockLog Put(StockLogDTO dto, long id)
        {
            var stockLogById = GetById(id);
            if (stockLogById == null)
            {
                throw new NotFoundException($"O log de estoque com o id {id} não foi encontrado.");
            }

            _mapper.Map(dto, stockLogById);

            var validator = new StockLogValidator();
            validator.ValidateAndThrow(stockLogById);

            _dbcontext.Update(stockLogById);
            _dbcontext.SaveChanges();

            return stockLogById;
        }

        public void Delete(long id)
        {
            var stockLog = GetById(id);

            if (stockLog == null)
            {
                throw new NotFoundException($"Log de estoque não encontrado com o id: {id}");
            }

            _dbcontext.Remove(stockLog);
            _dbcontext.SaveChanges();
        }

        public TbStockLog GetById(long id)
        {
            var stockLog = _dbcontext.TbStockLogs.FirstOrDefault(s => s.Id == id);
            if (stockLog == null)
            {
                throw new NotFoundException($"Log de estoque não encontrado com o id: {id}");
            }
            return stockLog;
        }

        public IEnumerable<StockLogDTO> GetLogsByProduct(int productId)
        {
            var logs = _dbcontext.TbStockLogs
                .Where(l => l.Productid == productId)
                .Select(l => new StockLogDTO
                {
                    Createdat = l.Createdat,
                    Barcode = l.Product.Barcode,
                    Description = l.Product.Description,
                    Qty = l.Qty
                }).ToList();

            if (logs == null || logs.Count == 0)
            {
                throw new NotFoundException("Nenhum log encontrado para o produto especificado");
            }
            return logs;
        }

        public IEnumerable<TbStockLog> GetAll()
        {
            var stockLogs = _dbcontext.TbStockLogs.ToList();
            if (stockLogs == null || stockLogs.Count == 0)
            {
                throw new NotFoundException("Nenhum log de estoque encontrado");
            }
            return stockLogs;
        }
    }
}

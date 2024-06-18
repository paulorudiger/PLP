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
    public class ProductService
    {
        private readonly TfDbContext _dbcontext;
        private readonly IMapper _mapper;

        public ProductService(TfDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public TbProduct Insert(ProductDTO dto)
        {
            var entity = _mapper.Map<TbProduct>(dto);

            var validator = new ProductValidator();
            validator.ValidateAndThrow(entity);

            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            // Inserir log de estoque
            var log = new TbStockLog
            {
                Productid = entity.Id,
                Qty = entity.Stock,
                Createdat = DateTime.Now
            };

            _dbcontext.Add(log);
            _dbcontext.SaveChanges();

            return entity;
        }

        public TbProduct Put(ProductDTO dto, int id)
        {
            var productById = GetById(id);
            if (productById == null)
            {
                throw new NotFoundException($"O produto com o id {id} não foi encontrado.");
            }

            dto.Stock = productById.Stock; // Preservar o estoque atual
            _mapper.Map(dto, productById);

            var validator = new ProductValidator();
            validator.ValidateAndThrow(productById);

            _dbcontext.Update(productById);
            _dbcontext.SaveChanges();

            return productById;
        }

        public void Delete(int id)
        {
            var product = GetById(id);

            if (product == null)
            {
                throw new NotFoundException($"Produto não encontrado com o id: {id}");
            }

            _dbcontext.Remove(product);
            _dbcontext.SaveChanges();
        }

        public TbProduct GetById(int id)
        {
            var product = _dbcontext.TbProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new NotFoundException($"Produto não encontrado com o id: {id}");
            }
            return product;
        }

        public TbProduct GetByBarcode(string barcode)
        {
            var product = _dbcontext.TbProducts.FirstOrDefault(p => p.Barcode == barcode);
            if (product == null)
            {
                throw new NotFoundException($"Produto não encontrado com o código de barras: {barcode}");
            }
            return product;
        }

        public IEnumerable<TbProduct> GetByDescription(string description)
        {
            var products = _dbcontext.TbProducts.Where(p => p.Description.Contains(description)).ToList();
            if (products == null || products.Count == 0)
            {
                throw new NotFoundException("Nenhum produto encontrado com a descrição fornecida");
            }
            return products;
        }

        public TbProduct AdjustStock(int id, int qty)
        {
            var product = GetById(id);

            if (product.Stock + qty < 0)
            {
                throw new InvalidOperationException("Estoque insuficiente para realizar a operação.");
            }

            product.Stock += qty;

            _dbcontext.Update(product);
            _dbcontext.SaveChanges();

            // Inserir log de estoque
            var log = new TbStockLog
            {
                Productid = product.Id,
                Qty = qty,
                Createdat = DateTime.Now
            };

            _dbcontext.Add(log);
            _dbcontext.SaveChanges();

            return product;
        }

        public IEnumerable<TbProduct> GetAll()
        {
            var products = _dbcontext.TbProducts.ToList();
            if (products == null || products.Count == 0)
            {
                throw new NotFoundException("Nenhum produto encontrado");
            }
            return products;
        }
    }
}

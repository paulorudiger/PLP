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

            return entity;
        }

        public TbProduct Put(ProductDTO dto, int id)
        {
            var productById = GetById(id);
            if (productById == null)
            {
                throw new NotFoundException($"O produto com o id {id} não foi encontrado.");
            }

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

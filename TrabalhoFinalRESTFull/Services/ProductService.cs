using FluentValidation;
using System;
using TrabalhoFinalRESTFull.BaseDados.Models;
using TrabalhoFinalRESTFull.Services.DTOs;
using TrabalhoFinalRESTFull.Services.Parser;
using TrabalhoFinalRESTFull.Services.Validate;

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

            var entity = ProductParser.ToEntity(dto);

            Console.WriteLine(entity);

            var validator = new ProductValidator();
            validator.ValidateAndThrow(entity);



            //  _dbcontext.Add(entity);
            _dbcontext.SaveChanges();

            return entity;

        }



    }
}

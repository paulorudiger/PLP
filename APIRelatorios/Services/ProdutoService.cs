using APIRelatorios.Database;
using APIRelatorios.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIRelatorios.Services
{

    public class NotFoundException : Exception
    {
        public NotFoundException() { }

    }

    public class ProdutoService
    {

        private readonly ContextDB _contextDB;
        public ProdutoService(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public List<Produto> GetAll()
        {
            return _contextDB.Produtos;

        }
        public Produto GetByCodigo(int codigo)
        {
            try
            {
                return _contextDB.Produtos
                .Where(p => p.Codigo == codigo)
                .First();
            }
            catch
            {
                throw new NotFoundException();
            }
        }

    }
}

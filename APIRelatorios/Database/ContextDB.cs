using APIRelatorios.Database.Models;
using APIRelatorios.Database.Parser;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace APIRelatorios.Database
{
    public class ContextDB
    {

        private readonly string _dataset;

        private readonly List<Produto> _produtos;

        public ContextDB()
        {
            _dataset = File.ReadAllText("..\\..\\..\\Dataset.csv");
            _produtos = ProdutoParser.ConverterLista(_dataset);
        }

       public List<Produto> Produtos => _produtos;

    }
}

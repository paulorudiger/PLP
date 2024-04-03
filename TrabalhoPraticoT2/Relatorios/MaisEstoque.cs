using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPraticoT2.Classes;
using TrabalhoPraticoT2.Interfaces;

namespace TrabalhoPraticoT2.Relatorios
{
    public class MaisEstoque : IRelatorio
    {
        public List<Produto> Imprimir(List<Produto> produtos)
        {
            Console.WriteLine("Opção 2 selecionada: TOP 3 produtos com mais estoque");
            var produtosOrdenadosEstoque = produtos.OrderBy(p => p.Estoque);
            var top3Estoque = produtosOrdenadosEstoque.Take(3).ToList();
            return top3Estoque;
            /*
            Console.WriteLine("TOP 3 produtos com mais estoque: \n");
            foreach (var produto in top3Estoque)
            {
                Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: "
                    + produto.Descricao + " - " + "Qtd: " + produto.QtdVendida + "\n");
            }*/

        }
    }
}

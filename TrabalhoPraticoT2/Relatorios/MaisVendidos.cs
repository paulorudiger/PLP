using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPraticoT2.Classes;
using TrabalhoPraticoT2.Interfaces;

namespace TrabalhoPraticoT2.Relatorios
{
    public class MaisVendidos : IRelatorio
    {

        public List<Produto> Imprimir(List<Produto> produtos)
        {
            Console.WriteLine("Opção 1 selecionada: TOP 5 produtos mais vendidos");
            var produtosOrdenadosQtd = produtos.OrderBy(p => p.QtdVendida);
            var top5Qtd = produtosOrdenadosQtd.Take(5).ToList();
            return top5Qtd;

            /*

            Console.WriteLine("TOP 5 produtos mais vendidos: \n");
            foreach (var produto in top5Qtd)
            {
                Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: " + produto.Descricao + "\n");
            }*/

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPraticoT2.Classes;
using TrabalhoPraticoT2.Interfaces;

namespace TrabalhoPraticoT2.Relatorios
{
    public class MenosVendidos : IRelatorio
    {

        public List<Produto> Imprimir(List<Produto> produtos)
        {

            Console.WriteLine("Opção 4 selecionada: TOP 5 produtos menos vendidos");
            var produtosOrdenadosMenorQtd = produtos.OrderByDescending(p => p.QtdVendida);
            var top5MenosQtd = produtosOrdenadosMenorQtd.Take(5).ToList();
            return top5MenosQtd;
            /*
            Console.WriteLine("TOP 5 produtos mais vendidos: \n");
            foreach (var produto in top5MenosQtd)
            {
                Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: "
                    + produto.Descricao + " - " + "Qtd: " + produto.QtdVendida + "\n");
            }*/
            

        }



    }
}



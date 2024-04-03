using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPraticoT2.Classes;
using TrabalhoPraticoT2.Interfaces;

namespace TrabalhoPraticoT2.Relatorios
{
    public class ExcessoDeEstoque : IRelatorio
    {
        public List<Produto> Imprimir(List<Produto> produtos)
        {

         //   Console.WriteLine("Opção 6 selecionada: Excesso de estoque");

            var excessoEstoque = produtos.Where(p =>
                p.Estoque >= (p.QtdVendida * 3)).ToList();

            /*Console.WriteLine("Produtos em excesso no estoque:");
            foreach (var produto in excessoEstoque)
            {
                Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: "
                     + produto.Descricao + " - " + "Estoque: " + produto.Estoque + "\n");
            }*/

            return excessoEstoque;

        }
     }
}

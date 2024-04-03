using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPraticoT2.Classes;
using TrabalhoPraticoT2.Interfaces;

namespace TrabalhoPraticoT2.Relatorios
{
    public class EstoqueDeSeguranca : IRelatorio
    {

        public List<Produto> Imprimir(List<Produto> produtos)
        {
            Console.WriteLine("Opção 5 selecionada: Estoque de segurança");

            var estoqueSeguranca = produtos.Where(p =>
                p.Estoque < (p.QtdVendida * 0.33)).ToList();

            return estoqueSeguranca;

          /*  Console.WriteLine("Produtos no Estoque de Segurança:");

            foreach (var produto in estoqueSeguranca)
            {
                Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: "
                     + produto.Descricao + " - " + "Estoque: " + produto.Estoque + "\n");
            }

            */
        }



    }

}

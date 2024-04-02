using System;
using System.IO;
using System.Linq;
using TrabalhoPraticoT2.Classes;
//using System.Data.Linq.Mapping;


static void exibirMenu()
{
    Console.WriteLine("----------------------------------------------------------");
    Console.WriteLine("Selecione qual relatório será impresso:");
    Console.WriteLine("0) Encerrar programa");
    Console.WriteLine("1) Produtos mais vendidos (Top 5: código - descrição)");
    Console.WriteLine("2) Produtos com mais estoque (Top 3: código - descrição: estoque)");
    Console.WriteLine("3) Categoria mais vendida (Top 1: Somente a categoria)");
    Console.WriteLine("4) Produtos menos vendidos (Top 5: código – descrição: Qtd. vendida)");
    Console.WriteLine("5) Estoque de segurança (Produtos cujo estoque seja menor do que 33% do total vendido: código - descrição: estoque)");
    Console.WriteLine("6) Excesso de estoque (Produtos cujo estoque atual é, no mínimo, 3 vezes maior que o total vendido: Código - descrição: estoque)");
    Console.WriteLine("7) Média de preço por categoria (Média de preço dos produtos por categoria: Categoria: Preço médio)");
    Console.WriteLine("8) Limpar tela");
    Console.WriteLine("----------------------------------------------------------");
}

int parseStringToInt(string strNumero)
{
    int numeroConvertido;
    if (int.TryParse(strNumero, out numeroConvertido))
        return numeroConvertido;
    else
        return -1;
}

exibirMenu();
string opcaoStr = Console.ReadLine();

int opcaoInt = parseStringToInt(opcaoStr);

while (opcaoInt != 0)
{
    if (opcaoInt < 1 || opcaoInt > 8)
    {
        Console.WriteLine("Opção inválida! Digite novamente:");
    }
    else
    {
        var dataset = File.ReadAllText("..\\..\\..\\Dataset.csv");

        var listaProdutos = ProdutoParser.ConverterLista(dataset);

        switch (opcaoInt)
        {
            case 0:
                Console.WriteLine("Programa encerrado");
                break;
            case 1:
                Console.WriteLine("Opção 1 selecionada: TOP 5 produtos mais vendidos");
                var produtosOrdenadosQtd = listaProdutos.OrderBy(p => p.QtdVendida);
                var top5Qtd = produtosOrdenadosQtd.Take(5);
                Console.WriteLine("TOP 5 produtos mais vendidos: \n");
                foreach (var produto in top5Qtd)
                {
                    Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: " + produto.Descricao + "\n");
                }
                break;
            case 2:
                Console.WriteLine("Opção 2 selecionada: TOP 3 produtos com mais estoque");
                var produtosOrdenadosEstoque = listaProdutos.OrderBy(p => p.Estoque);
                var top3Estoque = produtosOrdenadosEstoque.Take(3);
                Console.WriteLine("TOP 3 produtos com mais estoque: \n");
                foreach (var produto in top3Estoque)
                {
                    Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: "
                        + produto.Descricao + " - " + "Qtd: " + produto.QtdVendida + "\n");
                }
                break;
            case 3:
                Console.WriteLine("Opção 3 selecionada: TOP 1 categoria mais vendida");
                var vendasAgrupadas = listaProdutos.GroupBy(p => p.Categoria).Select(g => new
                {
                    Categoria = g.Key,
                    QuantidadeVendida = g.Sum(p => p.QtdVendida)
                }); ;
                var catMaisVendida = vendasAgrupadas.OrderBy(c => c.QuantidadeVendida).First();
                Console.WriteLine("Categoria mais vendida: " + catMaisVendida.ToString());
                break;
            case 4:
                Console.WriteLine("Opção 4 selecionada: TOP 5 produtos menos vendidos");
                var produtosOrdenadosMenorQtd = listaProdutos.OrderByDescending(p => p.QtdVendida);
                var top5MenosQtd = produtosOrdenadosMenorQtd.Take(5);
                Console.WriteLine("TOP 5 produtos mais vendidos: \n");
                foreach (var produto in top5MenosQtd)
                {
                    Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: "
                        + produto.Descricao + " - " + "Qtd: " + produto.QtdVendida + "\n");
                }
                break;
            case 5:
                Console.WriteLine("Opção 5 selecionada: Estoque de segurança");

                var estoqueSeguranca = listaProdutos.Where(p =>
                    p.Estoque < (p.QtdVendida * 0.33));

                Console.WriteLine("Produtos no Estoque de Segurança:");

                foreach (var produto in estoqueSeguranca)
                {
                    Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: "
                         + produto.Descricao + " - " + "Estoque: " + produto.Estoque + "\n");
                }

                break;
            case 6:
                Console.WriteLine("Opção 6 selecionada: Excesso de estoque");

                var excessoEstoque = listaProdutos.Where(p =>
                    p.Estoque >= (p.QtdVendida * 3));

                Console.WriteLine("Produtos em excesso no estoque:");
                foreach (var produto in excessoEstoque)
                {
                    Console.WriteLine("Código: " + produto.Codigo + " - " + "Descrição: "
                         + produto.Descricao + " - " + "Estoque: " + produto.Estoque + "\n");
                }
                break;
            case 7:
                Console.WriteLine("Opção 7 selecionada: Média de preço por categoria");
                var Media = listaProdutos.GroupBy(p => p.Categoria).Select(g => new
                {
                    Categoria = g.Key,
                    PrecoMedio = g.Average(p => p.Preco)
                });
                foreach (var produto in Media)
                {
                    Console.WriteLine("Categoria: " + produto.Categoria + " - " + "Preço medio: " + produto.PrecoMedio);
                }

                break;
            case 8:
                Console.Clear();
                break;
        }

    }

    exibirMenu();
    opcaoStr = Console.ReadLine();
    opcaoInt = parseStringToInt(opcaoStr);

}

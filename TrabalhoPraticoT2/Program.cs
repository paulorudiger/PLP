using System;
using System.IO;
using TrabalhoPraticoT2.Classes;

static void exibirMenu()
{
    Console.WriteLine("Selecione qual relatório será impresso:");
    Console.WriteLine("1) Produtos mais vendidos (Top 5: código - descrição)");
    Console.WriteLine("2) Produtos com mais estoque (Top 3: código - descrição: estoque)");
    Console.WriteLine("3) Categoria mais vendida (Top 1: Somente a categoria)");
    Console.WriteLine("4) Produtos menos vendidos (Top 5: código – descrição: Qtd. vendida)");
    Console.WriteLine("5) Estoque de segurança (Produtos cujo estoque seja menor do que 33% do total vendido: código - descrição: estoque)");
    Console.WriteLine("6) Excesso de estoque (Produtos cujo estoque atual é, no mínimo, 3 vezes maior que o total vendido: Código - descrição: estoque)");
    Console.WriteLine("7) Média de preço por categoria (Média de preço dos produtos por categoria: Categoria: Preço médio)");
    Console.WriteLine("8) Sair");
}

int parseStringToInt(string strNumero)
{
    int numeroConvertido;
    if (int.TryParse(strNumero, out numeroConvertido))
        return numeroConvertido;
    else
        return -1;
}

bool ehValorValido(string numero)
{
    int num = parseStringToInt(numero);

    if (num == -1)
        return false;
    else if (num <= 0)
        return false;
    else
        return true;
}

exibirMenu();
string opcaoStr = Console.ReadLine();

int opcaoInt = parseStringToInt(opcaoStr);

while (opcaoInt < 0)
{
    Console.WriteLine("Opção inválida! Digite novamente:");
    opcaoStr = Console.ReadLine();
    opcaoInt = parseStringToInt(opcaoStr);
}

var dataset = File.ReadAllText("..\\..\\..\\Dataset.csv");

var produtosParse = ProdutoParser.ConverterLista(dataset);

switch (opcaoInt)
{
    case 0:
        Console.WriteLine("Programa encerrado");
        // Implemente o código para a opção 1 aqui
        break;
    case 1:
        Console.WriteLine("Opção 1 selecionada: Produtos mais vendidos");
        // Implemente o código para a opção 1 aqui



        break;
    case 2:
        Console.WriteLine("Opção 2 selecionada: Produtos com mais estoque");
        // Implemente o código para a opção 2 aqui
        break;
    case 3:
        Console.WriteLine("Opção 3 selecionada: Categoria mais vendida");
        // Implemente o código para a opção 3 aqui
        break;
    case 4:
        Console.WriteLine("Opção 4 selecionada: Produtos menos vendidos");
        // Implemente o código para a opção 4 aqui
        break;
    case 5:
        Console.WriteLine("Opção 5 selecionada: Estoque de segurança");
        // Implemente o código para a opção 5 aqui
        break;
    case 6:
        Console.WriteLine("Opção 6 selecionada: Excesso de estoque");
        // Implemente o código para a opção 6 aqui
        break;
    case 7:
        Console.WriteLine("Opção 7 selecionada: Média de preço por categoria");
        // Implemente o código para a opção 7 aqui
        break;
 }


/*
for (int i = 0; i < produtosParse.Count; i++)
{
    Console.WriteLine(produtosParse[i].Descricao);

}
*/
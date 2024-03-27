using System;
using System.IO;
using TrabalhoPraticoT2.Classes;

var dataset = File.ReadAllText("..\\..\\..\\Dataset.csv");


var produtosParse = ProdutoParser.ConverterLista(dataset);

Console.WriteLine(produtosParse);

for (int i = 0; i < produtosParse.Count; i++)
{
    Console.WriteLine(produtosParse[i].Descricao);

}

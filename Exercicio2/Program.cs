using System;
using System.Collections.Generic;
using System.Linq;

int parseStringToInt(string strNumero)
{
    int numeroConvertido;

    while (!int.TryParse(strNumero, out numeroConvertido))
    {
        if ((numeroConvertido <= 0)) 
        {
            throw new Exception("O numero informado é inválido (não é possível digitar um número negativo, zero ou caractere especial)");
        }

        Console.WriteLine("Digite a quantidade de numeros que será informada:");
        strNumero = Console.ReadLine();
    }

    return numeroConvertido;
}

Console.WriteLine("Digite a quantidade de numeros que será informada:");
string qtdString = Console.ReadLine();

int qtd = parseStringToInt(qtdString);

var lista = new List<int>();

for (int i = 0; i < qtd; i++)
{
    Console.WriteLine("Digite o " + (i+1) + "º numero.");

    string nInformado = Console.ReadLine();

    lista.Add(parseStringToInt(nInformado));


}


Console.WriteLine("Maior numero da lista: " + lista.Max());

Console.WriteLine("Menor numero da lista: " + lista.Min());

Console.WriteLine("Media dos numeros da lista: " + lista.Average());




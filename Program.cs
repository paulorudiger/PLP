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

int aoQuadrado(int num1)
{
    return num1 * num1;
}

Console.WriteLine("Digite o 1º número:");
string num1 = Console.ReadLine();
while (!ehValorValido(num1))
{
    Console.WriteLine("Por favor, digite um número válido (não é possível digitar um número ou caractere especial)");
    num1 = Console.ReadLine();
}
int a = parseStringToInt(num1);

Console.WriteLine("Digite o 2º número:");
string num2 = Console.ReadLine();
while (!ehValorValido(num2))
{
    Console.WriteLine("Por favor, digite um número válido (não é possível digitar um número ou caractere especial)");
    num2 = Console.ReadLine();
}
int b = parseStringToInt(num2);

Console.WriteLine("Digite o 3º número:");
string num3 = Console.ReadLine();
while (!ehValorValido(num3))
{
    Console.WriteLine("Por favor, digite um número válido (não é possível digitar um número ou caractere especial)");
    num3 = Console.ReadLine();
}

int c = parseStringToInt(num3);
int d;
int r = aoQuadrado(a+b);
int s = aoQuadrado(b + c);

d = (r + s) / 2;

Console.WriteLine("Valor= " + d);
Console.Read();
int numero;

Console.WriteLine("Digite o numero que voce deseja ver sua tabuada");

numero = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("\n");
for(int n = 1; n<=10;n++)
{
    int valor = numero*n;
    Console.WriteLine($"{numero} X {n}: {valor}");    
}

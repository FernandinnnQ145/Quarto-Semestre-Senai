static double multiplicacao(double n, double n2){
    double valor = n*n2;
    return valor;
}

Console.WriteLine($"Digite um numero para ver sua tabuada");

double numero = Convert.ToDouble(Console.ReadLine());
for (int i = 0; i <=10; i++)
{
    
    Console.WriteLine($"{multiplicacao(numero, i)}");
    
}


int tentativas = 0;
Random randon = new Random();
int valorCorreto = randon.Next(1,100);
int palpite;
do
{
    if(tentativas >0){
        Console.WriteLine($"Errou");
        
    }
    Console.WriteLine("\nTente adivinhar o valor correto de 0 a 100");
    palpite = Convert.ToInt32(Console.ReadLine());
    tentativas++;
} while (palpite != valorCorreto);
Console.WriteLine($"\nParabens!");
Console.WriteLine($"Seu numero de tentativas foi {tentativas}");

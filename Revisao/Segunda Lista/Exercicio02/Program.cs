string[] nome = new string[5];
for (var i = 0; i < 5; i++)
{
    Console.Clear();
    Console.WriteLine($"Escreva o {i + 1} nome: ");
    nome[i] = Console.ReadLine(); 
}

Console.Clear();
foreach (var item in nome.OrderBy(x => x))
{
    Console.WriteLine(item);
}

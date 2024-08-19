int[] n = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
int x = 0;
foreach (var item in n)
{
    if(item % 2 == 0){
        x += item;
    }
}

Console.WriteLine(x);


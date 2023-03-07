// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var input = new int[] { 2, 5, 6, 3, 9, -2, 8, 17, 1, 11, -4, 0, 7 };
int sum = 0;
//foreach (int i in input)
//{
//    if (sum <= 7)
//    {
//        sum = sum + i;
//        Console.WriteLine(i);
//    }
//}




for (int i = 0; i < input.Length; i++)
{
    for (int j = i; j < input.Length; j++)
    {
        if (input[i] + input[j] == sum)
        {
            Console.WriteLine(input[i] + "," + input[j]);
        }
    }
}
//foreach (int i in input)
//{
//    foreach (int j in input)
//    {
//        if (input[i] + input[j] == sum)
//        {
//            Console.WriteLine(input[i] + "," + input[j]);
//        }
//    }
//}

for (int i = 0; i < input.Length; i++)
{
    if (sum <= 7)
    {
        sum = sum + input[i];
    }
    Console.Write(input[i]+",");
}
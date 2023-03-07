// See https://aka.ms/new-console-template for more information
using Harsha_7_04_02_2023;

Console.WriteLine("Hello, World!");
int[] arr1=new int[] {4, 8, 3, 2, 1, 2};
int[] arr2 = new int[] { 4, 4, 5, 4, 3, 2, 1, 8, 3, 2, 1 };
int[] arr3 = new int[] { 4, 3, 2, 1, 3, 2, 1, 1 ,1};
int[] arr4 = new int[] { 1, 1, 2, 1 ,};
int[] arr5 = new int[] {};



//List<int[]> CountDownList = new List<int[]> 
//{
//    new int[] { 4, 8, 3, 2, 1, 2 },
//    new int[] { 4, 4, 5, 4, 3, 2, 1, 8, 3, 2, 1 },
//    new int[] { 4, 3, 2, 1, 3, 2, 1, 1 }, 
//    new int[] { 1, 1, 2, 1 },
//    new int[] { } 
//};

//foreach (int[] counting in CountDownList)
//{
//    int[][] resultcount = CountDown.CountSequence(counting);




// Console.WriteLine("Count of sequences : "+resultcount.Length);
//Console.Write("[ "+resultcount.Length+",");
//if (resultcount.Length > 1)
//{
//    Console.Write("[ ");
//}
//foreach (int[] values in resultcount)
//{
//    Console.Write("[ "+string.Join(", ", values)+" ]");
//}
//if(resultcount.Length > 0)
//{
//    Console.Write(" ]");
//}
//Console.Write(" ]");
//Console.WriteLine();
//    Console.Write("[" + resultcount[0][0]+",");
//    if (resultcount[0][0] > 0)
//    {
//        Console.Write("[");
//        for(int i = 1; i <= resultcount[0][0]; i++)
//        {
//            Console.Write("[" + string.Join(",", resultcount[i])+"]");
//        }
//        Console.Write("]");
//    }
//    Console.Write("]");
//    Console.WriteLine();
//}



int[][] result1 = CountDown.CountSequence(arr1);
Console.Write("[");
for (int i = 0; i < result1.Length; i++)
{
    Console.Write(string.Join(",", result1[i]) + "],[");
}
Console.Write("]");

//int[][] result2 = CountDown.CountSequence(arr2);
//Console.Write("\n[");
//for (int i = 0; i < result2.Length; i++)
//{
//    Console.Write(string.Join(",", result2[i]) + "],[");
//}
//Console.Write("]");

//int[][] result3 = CountDown.CountSequence(arr3);
//Console.Write("\n[");
//for (int i = 0; i < result3.Length; i++)
//{
//    Console.Write(string.Join(",", result3[i]) + "],[");
//}
//Console.Write("]");

//int[][] result4 = CountDown.CountSequence(arr4);
//Console.Write("\n[");
//for (int i = 0; i < result4.Length; i++)
//{
//    Console.Write(string.Join(",", result4[i]) + "],[");
//}
//Console.Write("]");

//int[][] result5 = CountDown.CountSequence(arr5);
//Console.Write("\n[");
//for (int i = 0; i < result5.Length; i++)
//{
//    Console.Write(string.Join(",", result5[i]) + "],[");
//}
//Console.Write("]");

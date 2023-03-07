using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Unit_Testing
{
    public class Class1
    {
        static void Main()
        {
            Console.WriteLine("Enter the width of the rectangle:");
            double width = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the height of the rectangle:");
            double height = double.Parse(Console.ReadLine());

            double area = width * height;

            Console.WriteLine("The area of the rectangle is: " + area);
        }
        public static double CalculateArea(double width, double height)
        {
            return width * height;
        }
    }
}

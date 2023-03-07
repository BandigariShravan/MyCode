using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Test
{
    public class AsyncClass
    {
       
        
        public static async Task Main()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            Console.WriteLine("Statting to make Biryani.....");
            Task cookRice = CookRice();
            Task marinateChicken = MarinateChicken();
            Task dum = Dum();
            await Task.WhenAll(cookRice, marinateChicken, dum);
            Console.WriteLine("Biryani is Ready......");
            s.Stop();
            Console.WriteLine("Time Taken:-"+s.ElapsedMilliseconds);
        }

        static async Task CookRice()
        {
            Console.WriteLine("Boiling Water....");
            await Task.Delay(3000);
            Console.WriteLine("Water boiled....");
            await Task.Delay(2000);
            Console.WriteLine("Putting Rice into Boiled Water....");
            await Task.Delay(5000);
            Console.WriteLine("Rice Cooked....");
        }

        static async Task MarinateChicken()
        {
            Console.WriteLine("Cleaning Chicken...");
            await Task.Delay(3000);
            Console.WriteLine("Chicken marinating...");
            await Task.Delay(5000);
            Console.WriteLine("Chicken Marinated...");
        }

        static async Task Dum()
        {
            Console.WriteLine("Taking Pan And putting Rice And Chicken in layers...");
            await Task.Delay(1000);
            Console.WriteLine("1st Layer is Completed...");
            await Task.Delay(1000);
            Console.WriteLine("2st Layer is Completed...");
            await Task.Delay(1000);
            Console.WriteLine("Final Layer is Completed...");
            await Task.Delay(5000);
            Console.WriteLine("Closed lid And Started Dum");
            await Task.Delay(10000);
            Console.WriteLine("Dum Completed...");

        }
    }
}

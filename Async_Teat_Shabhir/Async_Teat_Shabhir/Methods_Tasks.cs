using System.Diagnostics;

namespace Async_Teat_Shabhir
{
    public class Methods_Tasks
    {
        Stopwatch st= new Stopwatch();
        
        public async Task RiceBoil()
        {
            st.Start();
             Console.WriteLine("Rice Boiled..");
             await Task.CompletedTask;
        }
        public async Task ChickenCook()
        {
            Console.WriteLine("Chicken Cooked....");
            await Task.CompletedTask;
        }
        public async Task Dum()
        {
            Console.WriteLine("Chicken Dummed......");
            await Task.CompletedTask;
            st.Stop();
            
        }
        
    }

}

namespace Async
{
    public class Sync
    {
        public static void Demo()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            StartSchoolAssembly();
            TeachClass12();
            TeachClass11();
            watch.Stop();

            Console.WriteLine($"ExcecutionTime:{watch.ElapsedMilliseconds} ms");
        }

        private static void TeachClass11()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Taught class 11");
        }

        public static void StartSchoolAssembly()
        {
            Thread.Sleep(8000);
            Console.WriteLine("School Started");
        }
        public static void TeachClass12()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Taught class 12");
        }


    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Interface_Segregation_Principle
{
    //public class LiqyidInkjetPrinter : IPrinterTasks
    //{
    //    public void Fax(string FaxContent)
    //    {
    //        Console.WriteLine("Print Done");
    //    }

    //    public void Print(string PrintContent)
    //    {
    //        Console.WriteLine("Scane");
    //    }

    //    public void PrintDuplex(string PrintDuplexContent)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Scan(string ScanContent)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class LiqyidInkjetPrinter : IPrinterTasks
    {
        public void Print(string PrintContent)
        {
            throw new NotImplementedException();
        }

        public void Scan(string ScanContent)
        {
            throw new NotImplementedException();
        }
    }
}

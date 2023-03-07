namespace Solid_Interface_Segregation_Principle
{


    //public class HPLaserJetPrinter : IPrinterTasks
    //{
    //    public void Fax(string FaxContent)
    //    {
    //        Console.WriteLine("Print Done");
    //    }

    //    public void Print(string PrintContent)
    //    {
    //        Console.WriteLine("Scan Content");
    //    }

    //    public void PrintDuplex(string PrintDuplexContent)
    //    {
    //        Console.WriteLine("Fax Content");
    //    }

    //    public void Scan(string ScanContent)
    //    {
    //        Console.WriteLine("Print Duplex Content");
    //    }
    //}


    public class HPLaserJetPrinter : IPrinterTasks, IFaxTasks, IPrintDuplexTasks
    {

        public void Print(string PrintContent)
        {
            Console.WriteLine("Scan Content");
        }
        public void Scan(string ScanContent)
        {
            Console.WriteLine("Print Duplex Content");
        }
        public void Fax(string FaxContent)
        {
            Console.WriteLine("Print Done");
        }
        public void PrintDuplex(string PrintDuplexContent)
        {
            Console.WriteLine("Fax Content");
        }
    }

}

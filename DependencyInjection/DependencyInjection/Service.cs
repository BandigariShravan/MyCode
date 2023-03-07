using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    //using Abstraction 
    public class Service:IService //implementening Interface
    {
        void IService.UsefulMethod()
        {
            Console.WriteLine("Service-UsefulMethod");
            Console.WriteLine(int.MinValue);
        }
    }
}

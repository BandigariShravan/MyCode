using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Injector
    {
        public Client ResolveClient()
        {
            Service s = new Service();
            Client c=new Client(s);
            return c;
        }
    }
}

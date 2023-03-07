using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    //creating a class
    public class Client
    {
        //Using encapsulation
        // creating a private memeber in the interface return type
        private IService _iService1;
        public Client(IService injectedService = null)//By using a constructor getting input by parameter with interface return type 
        {

            _iService1 = injectedService;
        }
      
        //creating another method to call service method with interface object (Not depending on class)
        public void UseService()
        {
            _iService1?.UsefulMethod();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Solid_dependency_Inversion_Principle
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string department { get; set; }
        public int Salary { get; set; }
    }
}

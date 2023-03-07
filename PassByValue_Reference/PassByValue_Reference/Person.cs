using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassByValue_Reference
{
    public class Person
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public Person(string fName, string lName)
        {
            FName = fName;
            LName = lName;
        }
        public static void DoSomething(Person person)
        {
            person.FName = "Shravan";
            person.LName = "Kumar";
        }
    }
}

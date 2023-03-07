using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Liskov_Substitution_Principle_DotNetT
{
    //public class Apple
    //{
    //    public virtual string GetColor()
    //    {
    //        return "Red";
    //    }

    //}
    //public class Orange:Apple
    //{
    //    public override string GetColor()
    //    {
    //        return "Orange";
    //    }
    //}


    public class Apple : Fruit
    {
        public override string GetColor()
        {
            return "Red";
        }

    }
    public class Orange : Fruit
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }
}

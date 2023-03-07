using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Liskov_Substitution_Principle
{
    public class SumCalculator
    {
        protected readonly int[] _numbers;
        public SumCalculator(int[] numbers)
        {
            _numbers = numbers;
        }
        public int Calculate()
        {
            return _numbers.Sum();
        }
        //protected readonly int[] numbers;
        //public SumCalculator(int[] numbers):base(numbers)
        //{ }
        //public virtual int Calcul
    }


}

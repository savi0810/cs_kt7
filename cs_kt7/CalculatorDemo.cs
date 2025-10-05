using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_kt7
{
    internal static class CalculatorDemo
    {
        public static double Calculate(double x, double y, Func<double, double, double> operation)
        {
            return operation(x, y);
        }
    }
}

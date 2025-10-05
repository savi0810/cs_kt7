using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_kt7
{
    internal static class Calculator
    {
        public static double Add(double x, double y) => x + y;
        public static double Subtract(double x, double y) => x - y;
        public static double Multiply(double x, double y) => x * y;
        public static double Divide(double x, double y) => x / y;

        // Метод для строк (контрвариантность)
        public static double AddStrings(string x, string y) =>
            double.Parse(x) + double.Parse(y);

        // Метод возвращающий object (ковариантность)
        public static object MultiplyAsObject(double x, double y) => x * y;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal delegate double BinaryOperator(double lhs, double rhs);
    internal class SimpleMath
    {
        public static double Add(double a, double b) { return a + b; }
        public static double Subtract(double a, double b) { return a - b; }
        public static double Multiply(double a, double b) { return a * b; }
        public static double Divide(double a, double b) { return a / b; }
    }
}

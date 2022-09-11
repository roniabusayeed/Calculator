using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    internal delegate double BinaryOperator(double lhs, double rhs);
    internal class SimpleMath
    {
        public static double Add(double a, double b) { return a + b; }
        public static double Subtract(double a, double b) { return a - b; }
        public static double Multiply(double a, double b) { return a * b; }
        public static double Divide(double a, double b) {
            if (b == 0)
            {
                MessageBox.Show(
                    "Division by zero is not supported",
                    "Wrong Operation",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                
                return 0;
            }
            return a / b;
        }
    }
}

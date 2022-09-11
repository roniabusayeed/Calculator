using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    public delegate double BinaryOperator(double lhs, double rhs);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber;
        private BinaryOperator? selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            // Register event handlers.
            acButton.Click          += AcButton_Click;
            negativeButton.Click    += NegativeButton_Click;
            percentageButton.Click  += PercentageButton_Click;
            equalsButton.Click      += EqualsButton_Click;

            d0Button.Click += NumberButton_Click;
            d1Button.Click += NumberButton_Click;
            d2Button.Click += NumberButton_Click;
            d3Button.Click += NumberButton_Click;
            d4Button.Click += NumberButton_Click;
            d5Button.Click += NumberButton_Click;
            d6Button.Click += NumberButton_Click;
            d7Button.Click += NumberButton_Click;
            d8Button.Click += NumberButton_Click;
            d9Button.Click += NumberButton_Click;

            addButton.Click         += OperationButton_Click;
            subtractButton.Click    += OperationButton_Click;
            multiplyButton.Click    += OperationButton_Click;
            divideButton.Click      += OperationButton_Click;
        }

        private double Add(double a, double b) { return a + b; }
        private double Subtract(double a, double b) { return a - b; }
        private double Multiply(double a, double b) { return a * b; }
        private double Divide(double a, double b) { return a / b; }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // Save currently displayed number and reset result label to zero.
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            
            // Save selected operator.
            if (sender == addButton) { selectedOperator = Add; }
            else if (sender == subtractButton) { selectedOperator = Subtract; }
            else if (sender == multiplyButton) { selectedOperator = Multiply; }
            else if (sender == divideButton) { selectedOperator = Divide; }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button? numberButton = sender as Button;
            if (numberButton is not null && 
                double.TryParse(numberButton.Content.ToString(), out double number))
            {
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = number.ToString();
                }
                else
                {
                    resultLabel.Content = $"{resultLabel.Content}{number}";
                }
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double number)) 
            {
                if (selectedOperator is not null)
                {
                    resultLabel.Content = selectedOperator(lastNumber, number);
                }
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double number))
            {
                number /= 100;
                resultLabel.Content = number.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double number))
            {
                number = -number;
                resultLabel.Content = number.ToString();
            }
        }
    }
}

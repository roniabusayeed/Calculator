using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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
            dotButton.Click += DotButton_Click;

            addButton.Click         += OperationButton_Click;
            subtractButton.Click    += OperationButton_Click;
            multiplyButton.Click    += OperationButton_Click;
            divideButton.Click      += OperationButton_Click;
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            // Add a dot only if there is not already one present.
            if (! resultLabel.Content.ToString()!.Contains('.'))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // Save currently displayed number and reset result label to zero.
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            
            // Save selected operator.
            if (sender == addButton) { selectedOperator = SimpleMath.Add; }
            else if (sender == subtractButton) { selectedOperator = SimpleMath.Subtract; }
            else if (sender == multiplyButton) { selectedOperator = SimpleMath.Multiply; }
            else if (sender == divideButton) { selectedOperator = SimpleMath.Divide; }
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
                    selectedOperator = null;
                }
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double number))
            {
                if (selectedOperator != null)
                {
                    resultLabel.Content = selectedOperator(lastNumber, number / 100);
                    selectedOperator = null;
                }
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

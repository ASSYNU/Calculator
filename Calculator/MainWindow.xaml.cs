using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private int[] input = new int[2];

        private string _symbol;
        
        private int i = 0;
        private bool resultshow = false;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpdateMainText(int newData)
        {
            int content;
            if (!resultshow)
            {
                input[i] = input[i]*10+newData;
            }
            else
            {
                input[i] = newData;
                resultshow = false;
            }
            if (input[i].ToString().Length <= 26)
            {
                Output.Text = input[i].ToString();
            }
            else
            {
                Output.Text = "Too Long!";
            }
        }
        
        // Top bar

        private void MouseOnTopBar(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        
        // Inputs
        
        private void calculator_input(object sender, RoutedEventArgs e)
        {
            int content = Int32.Parse((sender as Button).Content.ToString());
            UpdateMainText(content);
        }

        private void calculator_symbol(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
               _symbol = (sender as Button).Content.ToString();
            }
            else
            {
                input[0] = result();
                _symbol = (sender as Button).Content.ToString();
            }
            i = 1;
            Output.Text = _symbol;
            resultshow = false;
        }

        private void calculator_result(object sender, RoutedEventArgs e)
        {
            int result = this.result();
            Output.Text = result.ToString();
        }
        
        private void calculator_negative(object sender, RoutedEventArgs e)
        {
            input[i] = input[i] * (-1);
            Output.Text = input[i].ToString();
        }

        private int result()
        {                
            int result = 0;
            
            if (input[0] != 0 && input[1] != 0)
            {
                int input_1 = input[0];
                int input_2 = input[1];
                if (_symbol == "+")
                {
                    result = (input_1 + input_2);
                }
                else if (_symbol == "-")
                {
                    result = (input_1 - input_2);
                }
                else if (_symbol == "x")
                {
                    result = (input_1 * input_2);
                }
                else if (_symbol == "/")
                {
                    result = (input_1 / input_2);
                }
                else
                {
                    result = input_1;
                }

                input[1] = 0;
            
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = 0;
                }

                input[0] = result;

                i = 0;
            
                resultshow = true;
            }

            return result;
        }
        
        private void clear(object sender, RoutedEventArgs e)
        {
            input[i] = 0;
            Output.Text = "";
        }
        private void calculator_clearall(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = 0;
            }
            
            Output.Text = "";

            i = 0;
        }
        
    }
}
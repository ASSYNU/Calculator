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
        private string[] input =
        {
            null,
            null,
            null,
        };
        
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

        private void UpdateMainText(string newData)
        {
            string content = "";
            if (!resultshow)
            {
                input[i] += newData;
            }
            else
            {
                input[i] = newData;
                resultshow = false;
            }
            if (input[i].Length <= 26)
            {
                content = input[i];
            }
            else
            {
                content = "Too Long!";
            }
            Output.Text = content;
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
            string content = (sender as Button).Content.ToString();
            UpdateMainText(content);
        }

        private void calculator_symbol(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
                input[1] = (sender as Button).Content.ToString();
            }
            else
            {
                input[0] = result().ToString();
                input[1] = (sender as Button).Content.ToString();
            }
            i = 2;
            Output.Text = input[1];
            resultshow = false;
        }

        private void calculator_result(object sender, RoutedEventArgs e)
        {
            int result = this.result();
            Output.Text = result.ToString();
        }

        private int result()
        {                
            int result = 0;
            
            if (input[0] != null && input[1] != null && input[2] != null)
            {
                if (input[0] != "0" && input[2] != "0")
                {
                    int input_1 = Int32.Parse(input[0]);
                    int input_2 = Int32.Parse(input[2]);
                    string symbol = input[1];
                    if (symbol == "+")
                    {
                        result = (input_1 + input_2);
                    }
                    else if (symbol == "-")
                    {
                        result = (input_1 - input_2);
                    }
                    else if (symbol == "x")
                    {
                        result = (input_1 * input_2);
                    }
                    else if (symbol == "/")
                    {
                        result = (input_1 / input_2);
                    }
                    else
                    {
                        result = input_1;
                    }

                    input[1] = null;
                
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = null;
                    }

                    input[0] = result.ToString();

                    i = 0;
                
                    resultshow = true;
                }
            }
            else if(input[0] != null)
            {
                result = Int32.Parse(input[0]);
            }

            return result;
        }
        
        private void clear(object sender, RoutedEventArgs e)
        {
            input[i] = "";
            Output.Text = input[i];
        }
        private void calculator_clearall(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = "";
            }
            
            Output.Text = "";

            i = 0;
        }
        
    }
}
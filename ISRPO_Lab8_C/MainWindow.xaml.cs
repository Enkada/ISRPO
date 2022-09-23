using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace ISRPO_Lab8_C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            foreach (Button btn in uniformGrid.Children)
            {
                btn.Click += Btn_Click;
            }

            for (int i = 0; i < 4; i++)
            {
                Button btn = toolBar.Items[i] as Button;
                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text += (sender as Button).Content;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = Calculator.Calculate(textBlock.Text).ToString();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "";
        }
    }
}

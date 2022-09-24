using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Elevator
{
    /// <summary>
    /// Логика взаимодействия для FloorInput.xaml
    /// </summary>
    public partial class FloorInput : Window
    {
        public FloorInput()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = new MainWindow(int.Parse(tbNumber.Text));
                mainWindow.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

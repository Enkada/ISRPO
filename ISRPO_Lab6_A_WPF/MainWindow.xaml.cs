using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ISRPO_Lab6_A_Lib;


namespace ISRPO_Lab6_A_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateInputPanel();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            Shape shape = new Shape();

            if ((bool)rbtnRect.IsChecked)
            {
                double rectA = double.Parse(tbA.Text);
                double rectB = double.Parse(tbB.Text);

                shape = new ISRPO_Lab6_A_Lib.Rect(rectA, rectB);
            }
            else if ((bool)rbtnCircle.IsChecked)
            {
                double circleR = double.Parse(tbA.Text);

                shape = new Circle(circleR);
            }
            else if ((bool)rbtnSquare.IsChecked)
            {
                double squareA = double.Parse(tbA.Text);

                shape = new Square(squareA);
            }

            MessageBox.Show($"Фигура \"{shape.Name}\"\nS = {shape.Area}\nP = {shape.Perimeter}");
        }

        private void rbtn_Checked(object sender, RoutedEventArgs e)
        {
            UpdateInputPanel();
        }

        public void UpdateInputPanel()
        {
            if ((bool)rbtnRect.IsChecked)
            {
                lblA.Text = "Сторона а:";
                lblB.Text = "Сторона b:";

                lblA.Visibility = Visibility.Visible;
                tbA.Visibility = Visibility.Visible;
                lblB.Visibility = Visibility.Visible;
                tbB.Visibility = Visibility.Visible;
            }
            else if ((bool)rbtnCircle.IsChecked)
            {
                lblA.Text = "Радиус r:";

                lblA.Visibility = Visibility.Visible;
                tbA.Visibility = Visibility.Visible;
                lblB.Visibility = Visibility.Collapsed;
                tbB.Visibility = Visibility.Collapsed;
            }
            else if ((bool)rbtnSquare.IsChecked)
            {
                lblA.Text = "Сторона:";

                lblA.Visibility = Visibility.Visible;
                tbA.Visibility = Visibility.Visible;
                lblB.Visibility = Visibility.Collapsed;
                tbB.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rbtnRect.Checked += rbtn_Checked;
            rbtnCircle.Checked += rbtn_Checked;
            rbtnSquare.Checked += rbtn_Checked;
        }
    }
}

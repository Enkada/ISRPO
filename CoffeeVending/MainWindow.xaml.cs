using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CoffeeVending
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Beverage> beverages = new List<Beverage>()
        {
            new Americano(), new Cappuccino(), new Espresso(), new Cocoa()
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        int moneyInMachine = 0;
        int change = 0;
        int sugarPrice = 20;
        int milkPrice = 25;
        Beverage selectedBeverage;

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                moneyInMachine += int.Parse(tbInput.Text);
                UpdateInfoText();
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }

        private void UpdateInfoText()
        {
            int beveragePrice = selectedBeverage != null ? selectedBeverage.price : 0;
            int additionalPrice = (bool)cbSugar.IsChecked ? (bool)cbMilk.IsChecked ? sugarPrice + milkPrice : sugarPrice : (bool)cbMilk.IsChecked ? milkPrice : 0;
            int totalPrice = beveragePrice + additionalPrice;
            change = moneyInMachine - totalPrice;
            tbInfoText.Text = $"Внесенная сумма: {moneyInMachine} ₽\nСдача: {(change > 0 ? change : 0)} ₽\nЦена напитка: {totalPrice} ₽";

            btnOK.IsEnabled = totalPrice > 0 && moneyInMachine >= totalPrice;
        }

        private void rbtn_Checked(object sender, RoutedEventArgs e)
        {
            selectedBeverage = (sender as RadioButton).Tag as Beverage;
            beverageImage.Source = selectedBeverage.image;
            UpdateInfoText();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Beverage beverage in beverages)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Checked += rbtn_Checked;
                radioButton.Content = beverage.name;
                radioButton.Tag = beverage;
                spBeverages.Children.Add(radioButton);
            }
            UpdateInfoText();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ваш напиток \"{selectedBeverage.name + ((bool)cbSugar.IsChecked ? (bool)cbMilk.IsChecked ? " с молоком и сахаром" : " с сахаром" : (bool)cbMilk.IsChecked ? " с молоком" : "")}\" готов!" +
                $"{(change > 0 ? $"\nВаша сдача: {change} ₽" : "")}", "Автомат");
            moneyInMachine = 0;
            UpdateInfoText();
        }

        private void cbSugar_Checked(object sender, RoutedEventArgs e)
        {
            bSugar.Opacity = (bool)cbSugar.IsChecked ? 1 : 0.2;
            UpdateInfoText();
        }

        private void cbMilk_Checked(object sender, RoutedEventArgs e)
        {
            bMilk.Opacity = (bool)cbMilk.IsChecked ? 1 : 0.2;
            UpdateInfoText();
        }
    }
}

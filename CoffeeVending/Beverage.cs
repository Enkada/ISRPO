
using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CoffeeVending
{
    class Beverage
    {
        public string name { get; set; }
        public int price { get; set; }
        public BitmapImage image { get; set; }
    }

    class Americano : Beverage
    {
        public Americano()
        {
            name = "Американо";
            price = 50;
            image = new BitmapImage(new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name
    + ";component/"
    + "Americano.png", UriKind.Absolute));
        }
    }

    class Cappuccino : Beverage
    {
        public Cappuccino()
        {
            name = "Капучино";
            price = 55;
            image = new BitmapImage(new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name
    + ";component/"
    + "Cappuccino.png", UriKind.Absolute));
        }
    }

    class Espresso : Beverage
    {
        public Espresso()
        {
            name = "Эспрессо";
            price = 60;
            image = new BitmapImage(new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name
    + ";component/"
    + "Espresso.png", UriKind.Absolute));
        }
    }

    class Cocoa : Beverage
    {
        public Cocoa()
        {
            name = "Какао";
            price = 45;
            image = new BitmapImage(new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name
    + ";component/"
    + "Cocoa.png", UriKind.Absolute));
        }
    }
}

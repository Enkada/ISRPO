using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Elevator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int floorCount;
        ElevatorHandler elevator;
        BitmapImage elevatorClosed = new BitmapImage(new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name
                + ";component/elevator_closed.jpg", UriKind.Absolute));
        BitmapImage elevatorOpened = new BitmapImage(new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name
                + ";component/elevator_opened.jpg", UriKind.Absolute));

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public MainWindow(int floorCount)
        {
            InitializeComponent();
            this.floorCount = floorCount;

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();

            elevator = new ElevatorHandler(floorCount);
        }

        private void sliderElevatorSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine(Convert.ToInt32(sliderElevatorSpeed.Value));
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(sliderElevatorSpeed.Value));
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            elevator.Update();
            int currentFloor = elevator.Currentfloor;
            Grid.SetRow(elevatorImage, floorCount - currentFloor);

            tbDisplay.Text = $"{elevator.Currentfloor + (elevator.state == ElevatorHandler.State.Up ? "▲" : elevator.state == ElevatorHandler.State.Down ? "▼" : " ")}";

            foreach (var child in floorBtns.Children)
            {
                if (child is Button && Convert.ToInt32((child as Button).Tag) == elevator.Currentfloor && elevator.GetTargetFloor() == elevator.Currentfloor)
                    (child as Button).BorderBrush = Brushes.Gray;
            }

            foreach (var child in buildingGrid.Children)
            {
                if (child is Button && Convert.ToInt32((child as Button).Tag) == elevator.Currentfloor && elevator.GetTargetFloor() == elevator.Currentfloor)
                    (child as Button).BorderBrush = Brushes.Gray;
            }

            elevatorImage.Source = elevator.state == ElevatorHandler.State.Opened ? elevatorOpened : elevatorClosed;
            elevatorImage.BringIntoView();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < floorCount; i++)
            {
                buildingGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });

                Border floorBg = new Border();
                floorBg.Style = FindResource("bFloor") as Style;
                floorBg.Background = new SolidColorBrush(Color.FromRgb((byte)r.Next(127, 255),
                                  (byte)r.Next(127, 255), (byte)r.Next(127, 255)));
                Grid.SetColumnSpan(floorBg, 2);
                Grid.SetRow(floorBg, i);
                buildingGrid.Children.Add(floorBg);

                Button button = new Button();
                button.Tag = floorCount - i;
                button.Style = FindResource("btnCall") as Style;
                button.Content = "⦿";
                button.Click += btnCall_Click;
                Grid.SetRow(button, i);
                Grid.SetColumn(button, 1);
                buildingGrid.Children.Add(button);

                TextBlock floor = new TextBlock();
                floor.Style = FindResource("tbFloor") as Style;
                floor.Text = $"{floorCount - i} этаж";
                Grid.SetRow(floor, i);
                buildingGrid.Children.Add(floor);

                floorBtns.RowDefinitions.Add(new RowDefinition() );
                Button btnFloor = new Button();
                btnFloor.Tag = floorCount - i;
                btnFloor.Style = FindResource("btnFloor") as Style;
                btnFloor.Content = floorCount - i;
                btnFloor.Click += btnFloor_Click;
                Grid.SetRow(btnFloor, (i) / 2);
                Grid.SetColumn(btnFloor, (i + 1) % 2);
                floorBtns.Children.Add(btnFloor);
            }
            Grid.SetRowSpan(elevatorBg, floorCount);
            Grid.SetRow(elevatorImage, floorCount - 1);
        }

        private void btnFloor_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.BorderBrush = Brushes.Red;
            int floor = Convert.ToInt32(button.Tag);
            elevator.Go(floor);
        }

        private void btnCall_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.BorderBrush = Brushes.Red;
            int floor = Convert.ToInt32(button.Tag);
            elevator.Call(floor);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

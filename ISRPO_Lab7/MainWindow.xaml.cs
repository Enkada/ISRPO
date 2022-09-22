using System;
using System.Collections.Generic;
using System.Data;
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

namespace ISRPO_Lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dataTable = new DataTable();

        public MainWindow()
        {
            InitializeComponent();

            dataTable.Columns.Add(new DataColumn("Event Type"));
            dataTable.Columns.Add(new DataColumn("Key Code"));
            dataTable.Columns.Add(new DataColumn("Key Value"));
            dataTable.Columns.Add(new DataColumn("Key State"));
            dataTable.Columns.Add(new DataColumn("System Key"));

            dataGrid.ItemsSource = dataTable.DefaultView;
        }

        public void AddRow(string type, KeyEventArgs e)
        {
            DataRow row = dataTable.NewRow();
            row["Event Type"] = type;
            row["Key Code"] = e.Key;
            row["Key Value"] = Convert.ToInt16(e.Key);
            row["Key State"] = e.KeyStates;
            row["System Key"] = e.SystemKey;

            dataTable.Rows.Add(row);

            dataGrid.ScrollIntoView(dataGrid.Items.GetItemAt(dataGrid.Items.Count - 1));
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            AddRow("KeyUp", e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            AddRow("KeyDown", e);
        }
    }
}

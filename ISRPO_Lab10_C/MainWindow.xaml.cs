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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using Microsoft.Win32;

namespace ISRPO_Lab10_C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.Title = $"Новый файл";

            btnSave.IsEnabled = false;
            btnSaveAs.IsEnabled = true;

            isNewFile = true;

            tbEditor.Text = "";
        }

        string selectedFilePath = "";
        bool isNewFile = false;

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDlg = new OpenFileDialog();
                openFileDlg.DefaultExt = ".txt";
                openFileDlg.Filter = "Text documents (.txt)|*.txt";
                
                if (openFileDlg.ShowDialog() == true)
                {
                    this.Title = $"Редактирование {Path.GetFileName(openFileDlg.FileName)}";
                    btnSave.IsEnabled = true;
                    selectedFilePath = openFileDlg.FileName;
                    tbEditor.Text = File.ReadAllText(openFileDlg.FileName);

                    isNewFile = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Title = $"Новый файл";
                btnSave.IsEnabled = true;
                isNewFile = true;

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Document"; 
                dlg.DefaultExt = ".txt"; 
                dlg.Filter = "Text documents (.txt)|*.txt"; 
                
                if (dlg.ShowDialog() == true)
                {
                    string filename = dlg.FileName;
                    File.WriteAllText();
                }

                MessageBox.Show("Файл сохранен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

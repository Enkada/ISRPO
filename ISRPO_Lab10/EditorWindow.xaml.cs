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
using System.IO;
using Microsoft.Win32;
using System.IO.Compression;

namespace ISRPO_Lab10
{
    /// <summary>
    /// Логика взаимодействия для EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        public EditorWindow()
        {
            InitializeComponent();
        }

        public EditorWindow(string filePath)
        {
            InitializeComponent();
            OpenFile(filePath);
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.Title = $"Новый файл";

            btnSave.IsEnabled = false;
            btnSaveAs.IsEnabled = true;
            btnZip.IsEnabled = false;

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
                    OpenFile(openFileDlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void OpenFile(string path)
        {
            this.Title = $"Редактирование {Path.GetFileName(path)}";

            btnSave.IsEnabled = true;
            btnSaveAs.IsEnabled = true;
            btnZip.IsEnabled = true;

            selectedFilePath = path;
            tbEditor.Text = ReadFile(path);

            isNewFile = false;
        }

        public void SaveFile(string path, string text)
        {
            FileStream fs = File.Create(path);
            var sr = new StreamWriter(fs);

            sr.WriteLine(text);

            sr.Close();
            fs.Close();

            if (isNewFile)
            {
                OpenFile(path);
            }
        }

        public string ReadFile(string path)
        {
            string result = "";
            FileStream fs = File.OpenRead(path);
            var sr = new StreamReader(fs);

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                result += line + Environment.NewLine;
            }
            sr.Close();
            fs.Close();
            return result;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFile(selectedFilePath, tbEditor.Text);
            MessageBox.Show("Файл сохранен!");
        }

        private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
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
                    SaveFile(filename, tbEditor.Text);
                    MessageBox.Show("Файл сохранен!");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void BtnZip_Click(object sender, RoutedEventArgs e)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var txtFile = archive.CreateEntry(Path.GetFileName(selectedFilePath));

                    using (var entryStream = txtFile.Open())
                    using (var streamWriter = new StreamWriter(entryStream))
                    {
                        streamWriter.Write(tbEditor.Text);
                    }
                }

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Archive";
                dlg.DefaultExt = ".zip";

                if (dlg.ShowDialog() == true)
                {
                    using (var fileStream = new FileStream(dlg.FileName, FileMode.Create))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        memoryStream.CopyTo(fileStream);
                    }
                    MessageBox.Show("Файл заархивирован!");
                }                
            }
        }
    }
}

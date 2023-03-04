using System;
using System.Collections.Generic;
using System.IO;
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

namespace ISRPO_Lab10
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

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnOpenTxt.IsEnabled = false;
                tvFiles.Items.Clear();
                SearchOption searchOption = (bool)cbFolder.IsChecked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                Dictionary<string, TreeViewItem> folderNodes = new Dictionary<string, TreeViewItem>();
                foreach (var file in Directory.GetFiles(tbPath.Text, tbName.Text, searchOption))
                {
                    var folderName = Path.GetDirectoryName(file);
                    if (!folderNodes.ContainsKey(folderName))
                    {
                        var folderNode = new TreeViewItem() { Header = Path.GetFileName(Path.GetDirectoryName(file)) };
                        if (folderNode.Header.ToString().Length == 0)
                            folderNode.Header = folderName;
                        folderNode.Tag = folderName;
                        folderNodes.Add(folderName, folderNode);
                        tvFiles.Items.Add(folderNode);
                    }

                    var fileNode = new TreeViewItem() { Header = Path.GetFileName(file) };
                    fileNode.Tag = file;
                    folderNodes[folderName].Items.Add(fileNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void BtnOpenTxt_Click(object sender, RoutedEventArgs e)
        {
            var fileFullPath = (tvFiles.SelectedItem as TreeViewItem).Tag as string;
            EditorWindow editorWindow = new EditorWindow(fileFullPath);
            editorWindow.Show();
        }

        private void TvFiles_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvFiles.Items.Count > 0)
            {
                var fileName = (tvFiles.SelectedItem as TreeViewItem).Header.ToString();
                var fileFullPath = (tvFiles.SelectedItem as TreeViewItem).Tag as string;
                btnOpenTxt.IsEnabled = Path.GetExtension(fileName) == ".txt";
                tbInfo.Text = $"Атрибуты: {File.GetAttributes(fileFullPath)}\n" +
                                $"Дата создания: {File.GetCreationTime(fileFullPath)}\n" +
                                $"Последнее открытие: {File.GetLastAccessTime(fileFullPath)}\n" +
                                $"Последнее изменение: {File.GetLastWriteTime(fileFullPath)}\n" +
                                $"Полное имя: {fileFullPath}";
            }
        }

        private void BtnOpenEditor_Click(object sender, RoutedEventArgs e)
        {
            EditorWindow editorWindow = new EditorWindow();
            editorWindow.Show();
        }
    }
}

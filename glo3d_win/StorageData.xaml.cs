
using Firebase.Storage;
using glo3d_win.Firebase.Storage;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace glo3d_win
{
    /// <summary>
    /// Interaction logic for StorageData.xaml
    /// </summary>
    public partial class StorageData : Page
    {
        public StorageData()
        {
            InitializeComponent();
            LoadAllSelectedFolder();
        }

        private async void LoadAllSelectedFolder() {
            StorageHelper stHelper = new StorageHelper();
            StorageDataGrid.ItemsSource = await stHelper.ListOfFilePrefix("amir","test");
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.FileOk += SelectFile_FileOk;
            selectFile.ShowDialog();
        }

        private void SelectFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SelectFilePath.Text = ((OpenFileDialog)sender).FileName;
        }

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectFilePath.Text))
            {
                var stream = File.Open(SelectFilePath.Text, FileMode.Open);
                var fileName = System.IO.Path.GetFileName(SelectFilePath.Text);
                StorageHelper stHelper = new StorageHelper();
                var downloadLink = await stHelper.UploadFile(stream, fileName, "amir", "test");
                DownloadUploadedFile.NavigateUri = new Uri(downloadLink);
                DownloadFileLinkLabel.Visibility = Visibility.Visible;
            }
        }
    }
}

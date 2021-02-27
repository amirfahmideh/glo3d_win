using glo3d_win.Firebase.Storage;

using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace glo3d_win
{
    /// <summary>
    /// Interaction logic for EditPhoto.xaml
    /// </summary>
    public partial class EditPhoto : Page
    {
        public string FileName { get; set; }
        public string FileUrl => "/Assets/logo-256.png";
        public EditPhoto(string _fileName = "")
        {
            InitializeComponent();
            FileName = _fileName;
            fileNameLabel.Content = FileName;
            LoadFileNameAsync();
        }

        private async void LoadFileNameAsync()
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                StorageHelper helper = new StorageHelper();
                var fileUrl = await helper.GetFilePath("amir", "test", FileName);
                SelectedImage.Source = new BitmapImage(new System.Uri(fileUrl,System.UriKind.Absolute), new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache));
            }
        }
    }
}

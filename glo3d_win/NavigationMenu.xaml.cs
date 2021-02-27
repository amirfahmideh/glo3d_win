using System;
using System.Collections.Generic;
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
    /// Interaction logic for NavigationMenu.xaml
    /// </summary>
    public partial class NavigationMenu : UserControl
    {
        public delegate void OnMenuClickHandler(object? sender);
        public event OnMenuClickHandler OnMenuClick;
        public NavigationMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = (Button)sender;
            switch (clickedButton.Name)
            {
                case "SampleData":
                    {
                        if (OnMenuClick != null)
                        {
                            OnMenuClick(new SampleData());
                        }
                        break;
                    }
                case "StorageData":
                    {
                        if (OnMenuClick != null)
                        {
                            OnMenuClick(new StorageData());
                        }
                        break;
                    }
                default:
                    break;
            }


        }
    }
}

using Firebase.Auth;
using Firebase.Auth.UI;
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
using System.Windows.Shapes;

namespace glo3d_win
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FirebaseUI.Instance.Client.AuthStateChanged += this.AuthStateChanged;

        }

        private void AuthStateChanged(object sender, UserEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(async () =>
            {
                if (e.User == null)
                {
                    _mainFrame.Navigate(new LoginPage());
                }
                else if (e.User.IsAnonymous)
                {
                    _mainFrame.Navigate(new LoginPage());
                }
                else if ((_mainFrame.Content == null || _mainFrame.Content.GetType() != typeof(MainPage)))
                {
                    _mainFrame.Navigate(new MainPage());
                }
            });
            Application.Current.Dispatcher.Invoke(async () =>
            {
                if (e.User == null)
                {
                    _leftFrame.Navigate(null);
                }
                else
                {
                    var navigationMenu = new NavigationMenu();
                    navigationMenu.OnMenuClick += NavigationMenu_OnMenuClick;
                    _leftFrame.Navigate(navigationMenu);
                }
            });
        }

        private void NavigationMenu_OnMenuClick(object sender)
        {
            if (_mainFrame.Content != null && _mainFrame.Content.GetType() != sender.GetType())
                _mainFrame.Navigate(sender);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

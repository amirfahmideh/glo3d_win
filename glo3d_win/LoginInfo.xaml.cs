using Firebase.Auth;
using Firebase.Auth.UI;
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
    /// Interaction logic for LoginInfo.xaml
    /// </summary>
    public partial class LoginInfo : UserControl
    {
        public LoginInfo()
        {
            InitializeComponent();
            FirebaseUI.Instance.Client.AuthStateChanged += this.AuthStateChanged;

        }


        private void AuthStateChanged(object sender, UserEventArgs e)
        {
            var user = e.User;
            if (user != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    this.DisplayName.Text = user.Info.DisplayName;
                    this.Email.Text = user.Info.Email;
                });
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FirebaseUI.Instance.Client.AuthStateChanged -= this.AuthStateChanged;
            await FirebaseUI.Instance.Client.SignOutAsync();
        }
    }
}

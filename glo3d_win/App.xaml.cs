using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth.UI;
using System.Windows;

namespace glo3d_win
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var config = Firebase.Common.Config.GetDefaultConfig();
            FirebaseUI.Initialize(new FirebaseUIConfig
            {
                ApiKey = config.ApiKey,
                AuthDomain = config.ApplicationDomain,
                Providers = new FirebaseAuthProvider[]
               {
                   new EmailProvider(),
                   new GoogleProvider(),
                   new AppleProvider()
               },
                PrivacyPolicyUrl = "https://github.com/step-up-labs/firebase-authentication-dotnet",
                TermsOfServiceUrl = "https://github.com/step-up-labs/firebase-database-dotnet",
                IsAnonymousAllowed = false,
                AutoUpgradeAnonymousUsers = false,
                UserRepository = new FileUserRepository("Glo3d"),
            });
        }
    }
}

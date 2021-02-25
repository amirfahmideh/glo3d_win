using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Auth.Providers;
namespace glo3d_win.Firebase.Authentication
{
    public class AuthenticationConfig
    {
        public static FirebaseAuthConfig GetDefaultConfig()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = Firebase.Common.Config.GetDefaultConfig().ApiKey,
                AuthDomain = Firebase.Common.Config.GetDefaultConfig().ApplicationDomain,
                Providers = new FirebaseAuthProvider[]
                {
                  new GoogleProvider(),
                  new AppleProvider(),
                  new EmailProvider()
                }
            };
            return config;
        }
    }
}

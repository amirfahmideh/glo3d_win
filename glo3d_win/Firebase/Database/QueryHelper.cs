using Firebase.Auth.UI;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace glo3d_win.Firebase.Database
{
    public class QueryHelper
    {
        private FirebaseClient _client { get; set; }
        public QueryHelper()
        {
            _client = new FirebaseClient(Firebase.Common.Config.GetDefaultConfig().DatabaseDomain, new FirebaseOptions() { 
                AuthTokenAsyncFactory = () => LoginAsync()
            });
        }

        public static async Task<string> LoginAsync()
        {
            var user = FirebaseUI.Instance.Client.User;
            if (user != null)
            {
                return await user.GetIdTokenAsync();
            }
            else return string.Empty;
        }

        public async Task<IReadOnlyCollection<FirebaseObject<T>>> Items<T>(string child) where T : class {
            return await _client.Child(child).OnceAsync<T>();
        }

    }
}

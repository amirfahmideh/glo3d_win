using Firebase.Auth.UI;
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glo3d_win.Firebase.Database
{
    public class QueryHelper
    {
        private FirebaseClient _client { get; set; }
        private string _child  { get; set; }
        public QueryHelper(string firstNode)
        {
            _child = firstNode;
            _client = new FirebaseClient(Firebase.Common.Config.GetDefaultConfig().DatabaseDomain, new FirebaseOptions() { 
                AuthTokenAsyncFactory = () => LoginAsync(),
            });
        }

        public static async Task<string> LoginAsync()
        {
            var user = FirebaseUI.Instance.Client.User;
            if (user != null)
            {
                var token = await user.GetIdTokenAsync();
                return token;
            }
            else return string.Empty;
        }

        public async Task<IReadOnlyCollection<FirebaseObject<T>>> Items<T>() where T : class {
            return await _client.Child(_child).OnceAsync<T>();
        }

        public async Task<FirebaseObject<string>> Post<T>(T item) where T : class {
            string serlized = JsonConvert.SerializeObject(item);
            return await _client.Child(_child).PostAsync(serlized);
        }

    }
}

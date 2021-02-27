using Firebase.Auth.UI;
using Firebase.Database;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glo3d_win.Firebase.Storage
{
    public class StorageHelper
    {
        FirebaseStorageOptions _option = null;
        public StorageHelper()
        {
            _option = new FirebaseStorageOptions()
            {
                AuthTokenAsyncFactory = () => LoginAsync()
            };
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

        public async Task<string> UploadFile(Stream fileStream, string fileName, params string[] path)
        {
            var pathToServer = Firebase.Common.Config.GetDefaultConfig().StorageDomain;

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var storagePath = new FirebaseStorage(pathToServer,_option).Child(path[0]);

            if (path.Length > 1)
            {
                foreach (var item in path.ToList().Skip(1))
                {
                    storagePath = storagePath.Child(item);
                }
            }

            var task = storagePath.Child(fileName).PutAsync(fileStream);


            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            return await task;
        }
    }
}

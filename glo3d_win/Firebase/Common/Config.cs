using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glo3d_win.Firebase.Common
{
    public class Config
    {
        public string ProjectId { get; set; }
        public string ProjectNumber { get; set; }
        public string ApiKey { get; set; }
        public string ApplicationDomain { get; set; }
        public string DatabaseDomain { get; set; }

        public static Config GetDefaultConfig() {
            return new Config()
            {
                ProjectId = "golden-quote",
                ProjectNumber = "golden-quote",
                ApiKey = "AIzaSyAAHxz0NYoJpOWRgKuNsoECqTTSbYkCwy0",
                ApplicationDomain = "golden-quote.firebaseapp.com",
                DatabaseDomain = "golden-quote.firebaseio.com"
                //ApplicationDomain = "localhost",
            };
        }
    }

   
}

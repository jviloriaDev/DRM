using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oAuth.WebApi
{
    public static class GlobalParameterConfiguration
    {
        public static string FileFolderLocation { set; get; }

        static GlobalParameterConfiguration()
        {
           // FileFolderLocation = ConfigurationManager.AppSettings["FileFolderPath"];
            FileFolderLocation = ConfigurationManager.AppSettings["PathFiles"];
        }
    }
}

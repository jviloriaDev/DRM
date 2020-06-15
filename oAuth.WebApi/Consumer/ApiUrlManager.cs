using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Printing;
using System.Linq;
using System.Text;


namespace oAuth.WebAPI.Consumer
{
    public static class ApiUrlManager
    {
        static ApiUrlManager()
        {
            _baseUrl = Convert.ToString(ConfigurationManager.AppSettings["BaseUrl"]);
        }
        //Base url of service
        private static string _baseUrl;
        public static string BaseUrl { get { return _baseUrl; } }
    }
}

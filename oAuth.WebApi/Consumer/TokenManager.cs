using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Configuration;
using System.Web.Script.Serialization;

namespace oAuth.WebAPI.Consumer
{
    public static class TokenManager
    {
        private static string UserName { set; get; }
        private static string Password { set; get; }

        static TokenManager()
        {
            UserName = "admin";
            Password = "admin";
        }
        private static AuthenticationToken _authenticationToken;

        public static WebHeaderCollection GetAuthenticationHeader()
        {
            GenerateToken();
            var webHeader = new WebHeaderCollection();
            webHeader.Add("Authorization", "Bearer " + _authenticationToken.access_token);
            return webHeader;
        }
        public static WebHeaderCollection GetAuthenticationHeader(string user, string password)
        {
            GenerateToken(user, password);
            var webHeader = new WebHeaderCollection();
            webHeader.Add("Authorization", "Bearer " + _authenticationToken.access_token);
            return webHeader;

        }
        /// <summary>
        /// Used to generate token
        /// </summary>
        /// <returns></returns>
        private static string GenerateToken(string user, string password)
        {
            string baseurl = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            var client = new System.Net.WebClient();
            var parameters = new NameValueCollection();
            if (_authenticationToken != null)
            {
                try
                {
                    client.Headers[HttpRequestHeader.Authorization] = "Bearer " + _authenticationToken.access_token;
                    var resultAuthByte = client.DownloadString(baseurl + "/api/Token/RefeshTokenMain");
                    return _authenticationToken.access_token;
                }
                catch (Exception)
                {

                }
            }

            parameters = new NameValueCollection();
            parameters.Add("grant_type", "password");
            parameters.Add("username", user);
            parameters.Add("password", password);

            var resultByte = client.UploadValues(baseurl + "/oauth/token", "POST", parameters);
            _authenticationToken =
                new JavaScriptSerializer().Deserialize<AuthenticationToken>(Encoding.Default.GetString(resultByte));
            return _authenticationToken.access_token;

        }
        /// <summary>
        /// Used to generate token
        /// </summary>
        /// <returns></returns>
        private static string GenerateToken()
        {

            var client = new System.Net.WebClient();
            var parameters = new NameValueCollection();
            if (_authenticationToken != null)
            {
                try
                {
                    client.Headers[HttpRequestHeader.Authorization] = "Bearer " + _authenticationToken.access_token;
                    var resultAuthByte = client.DownloadString(ApiUrlManager.BaseUrl + "/api/Token/RefeshTokenMain");
                    return _authenticationToken.access_token;
                }
                catch (Exception)
                {

                }
            }

            parameters = new NameValueCollection();
            parameters.Add("grant_type", "password");
            parameters.Add("username", UserName);
            parameters.Add("password", Password);

            var resultByte = client.UploadValues(ApiUrlManager.BaseUrl + "/oauth/token", "POST", parameters);
            _authenticationToken =
                new JavaScriptSerializer().Deserialize<AuthenticationToken>(Encoding.Default.GetString(resultByte));
            return _authenticationToken.access_token;

        }
    }
}
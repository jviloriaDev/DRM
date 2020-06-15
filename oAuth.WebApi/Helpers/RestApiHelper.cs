using Newtonsoft.Json;
using oAuth.WebAPI.Helpers;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace oAuth.WebAPI.BL.Helpers
{
    public static class RestApiHelper
    {
        

        public static T GetAuthentication<T>(string baseUrl, string url, Method httpMethod
           , string userName, string password, OAuthHeader oAuthHeader = null)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(url, Method.POST);
            string encodedBody = string.Format("username={0}&password={1}&grant_type={2}",
               userName, password, "password");
            request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static T InvokeApiAsync<T>(string baseUrl, string url, Method httpMethod, OAuthHeader oAuthHeader = null,
             object body = null)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(url, httpMethod);
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            if (oAuthHeader != null)
            {
                foreach (var header in oAuthHeader.GetHeaders())
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }
            else
            {
                var userCredentailsKeyValue = body as ApiTokenObject;
                if (userCredentailsKeyValue != null)
                {
                    client.Authenticator = new HttpBasicAuthenticator(userCredentailsKeyValue.username,
                        userCredentailsKeyValue.password);
                }
            }


            if ((httpMethod == Method.POST || httpMethod == Method.PUT || httpMethod == Method.DELETE) && body != null)
            {
                request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
                request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
                //request.AddBody(body);
            }


            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static T InvokeApi<T>(string baseUrl, string url, Method httpMethod, OAuthHeader oAuthHeader = null,
             object body = null)
        {
            return InvokeApiAsync<T>(baseUrl, url, httpMethod, oAuthHeader, body);
        }

        //private static void ProcessHttpErrorResponse(HttpResponseMessage response)
        //{
        //    var content = response.Content.ReadAsStringAsync().Result;
        //    // Process error for Post and Put api method.
        //    var apiErrorResponse = JsonConvert.DeserializeObject<ApiErrorResponse>(content);
        //    if (apiErrorResponse != null)
        //    {
        //        var message = string.Empty;
        //        if (apiErrorResponse.Errors != null)
        //        {
        //            message += string.Join(Environment.NewLine, apiErrorResponse.Errors.Select(e => e.Message));
        //        }
        //        if (apiErrorResponse.Warnings != null)
        //        {
        //            message += string.Join(Environment.NewLine, apiErrorResponse.Warnings.Select(w => w.Message));
        //        }
        //        throw new Exception(message);
        //    }

        //    // Process error for Get api method.
        //    var httpError = JsonConvert.DeserializeObject<HttpError>(content);
        //    if (httpError != null)
        //    {
        //        throw new Exception(httpError["ExceptionMessage"].ToString());
        //    }
        //    response.EnsureSuccessStatusCode();
        //}

    }
}
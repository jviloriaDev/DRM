using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using Spartane.Core.Exceptions.Service;using System.Web.Http.Description;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using oAuth.WebAPI.Consumer;
using oAuth.WebApi.Helpers;
using System.Configuration;
using System.Text;
using System.IO;
using PushSharp;
using PushSharp.Core;
using PushSharp.Apple;
using PushSharp.Google;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spartane.Services.Spartan_Query;
using System.Security.Cryptography.X509Certificates;
using FirebaseNet.Messaging;


namespace Spartane.WebApi.Controllers
{

    public class MensajesController : BaseApiController
    {
        #region Variables

        private ISpartan_QueryService service = null;
        public static string ApiControllerUrl { get; set; }
        public string baseApi;
        public string IOS_Ambiente;
        public string IOS_NombreCertificado;
        public string IOS_PasswordCertificado;
        public string Android_SenderId;
        public string Android_ServerKey;

        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public MensajesController(ISpartan_QueryService service)
        {
            this.service = service;
            IOS_Ambiente = ConfigurationManager.AppSettings["IOS_Ambiente"].ToString();
            IOS_NombreCertificado = ConfigurationManager.AppSettings["IOS_NombreCertificado"].ToString();
            IOS_PasswordCertificado = "";
            Android_SenderId = ConfigurationManager.AppSettings["Android_SenderId"].ToString();
            Android_ServerKey = ConfigurationManager.AppSettings["Android_ServerKey"].ToString();
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Mensajes";
        }
        #endregion Constructor

        public void eLog(string Donde, string Variable, string mensaje, StreamWriter sw)
        {
            DateTime f = DateTime.Now;
            string fecha = f.ToString("dd/MM/yyyy");
            mensaje = Donde + " | " + Variable;
            Console.WriteLine(mensaje);
            sw.WriteLine(mensaje);
        }

        #region API Methods
        [Authorize]
        [HttpGet]
        public HttpResponseMessage Push(string TokenDispositivo, string Mensaje, int TipoDispositivo)
        {
            IOS_Ambiente = ConfigurationManager.AppSettings["IOS_Ambiente"].ToString();
            IOS_PasswordCertificado = ConfigurationManager.AppSettings["IOS_PasswordCertificado"].ToString();
            Android_SenderId = ConfigurationManager.AppSettings["Android_SenderId"].ToString();
            Android_ServerKey = ConfigurationManager.AppSettings["Android_ServerKey"].ToString();
            string result = "";
            try
            {
                if (TipoDispositivo == 1)
                {
                    ///////////////////////////////// SECCION Android //////////////////////////////////////
                    var webAddr = "https://fcm.googleapis.com/fcm/send";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("Authorization:key=" + Android_ServerKey);
                    httpWebRequest.Headers.Add("Sender:id=" + Android_SenderId);
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\"to\": \"" + TokenDispositivo + "\",\"data\": {\"message\": \"" + Mensaje + "\",}}";
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }

                    if (result.Contains("\"failure\":1"))
                        result = "ERROR:" + result;
                    else
                        result = "MENSAJE ENVIADO";

                }
                else if (TipoDispositivo == 2)
                {

                    ///////////////////////////////// SECCION iOS //////////////////////////////////////

                    string ruta = HttpContext.Current.Server.MapPath("~/Certificates/" + IOS_NombreCertificado);

                    var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, ruta, IOS_PasswordCertificado);
                    var apnsBroker = new ApnsServiceBroker(config);


                    if (IOS_Ambiente == "1") //Desarrollo
                        apnsBroker = new ApnsServiceBroker(config);

                    if (IOS_Ambiente == "2") //Producción
                        apnsBroker = new ApnsServiceBroker(config);

                    apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
                    {
                        result = "ERROR: " + aggregateEx.Message; //Console.WriteLine("Error");
                    };

                    apnsBroker.OnNotificationSucceeded += (notification) =>
                    {
                        result = "Mensaje enviado";  //Console.WriteLine("Sent");
                    };

                    apnsBroker.Start();

                    apnsBroker.QueueNotification(new ApnsNotification
                    {
                        DeviceToken = TokenDispositivo,
                        Payload = JObject.Parse("{\"aps\":{\"alert\":{\"title\":\"\",\"body\":\"" + Mensaje + "\"},\"badge\":-1,\"sound\":\"chime.aiff\"}}")
                    });

                    apnsBroker.Stop();

                    result = "Mensaje enviado";
                }
            }
            catch (Exception ex)
            {

                result = "ERROR: " + ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage PushToClient(string TokenDispositivo, string Mensaje, int TipoDispositivo)
        {
            string result = "";
            try
            {
                if (TipoDispositivo == 1)
                {
                    ///////////////////////////////// SECCION Android //////////////////////////////////////
                    var webAddr = "https://fcm.googleapis.com/fcm/send";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("Authorization:key=" + Android_ServerKey);
                    httpWebRequest.Headers.Add("Sender:id=" + Android_SenderId);
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\"to\": \"" + TokenDispositivo + "\",\"data\": {\"message\": \"" + Mensaje + "\",}}";
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }

                    if (result.Contains("\"failure\":1"))
                        result = "ERROR:" + result;
                    else
                        result = "MENSAJE ENVIADO";
                }
                else if (TipoDispositivo == 2)
                {

                    ///////////////////////////////// SECCION iOS //////////////////////////////////////
                    var ios_certificate = "";
                    if (IOS_Ambiente == "1")
                        ios_certificate = "SLOOPClientesDev.p12";

                    if (IOS_Ambiente == "2")
                        ios_certificate = "SLOOPClientesRelease.p12";

                    string ruta = HttpContext.Current.Server.MapPath("~/Certificates/" + ios_certificate);
                    ApnsServiceBroker apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    if (IOS_Ambiente == "1") //Desarrollo
                        apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    if (IOS_Ambiente == "2") //Producción
                        apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
                    {
                        result = "ERROR: " + aggregateEx.Message; //Console.WriteLine("Error");
                    };

                    apnsBroker.OnNotificationSucceeded += (notification) =>
                    {
                        result = "Mensaje enviado";  //Console.WriteLine("Sent");
                    };

                    apnsBroker.Start();

                    apnsBroker.QueueNotification(new ApnsNotification
                    {
                        DeviceToken = TokenDispositivo,
                        Payload = JObject.Parse("{\"aps\":{\"alert\":{\"title\":\"\",\"body\":\"" + Mensaje + "\"},\"badge\":-1,\"sound\":\"chime.aiff\"}}")
                    });

                    apnsBroker.Stop();

                    result = "Mensaje enviado";
                }
            }
            catch (Exception ex)
            {

                result = "ERROR: " + ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage PushToDriver(string TokenDispositivo, string Mensaje, int TipoDispositivo)
        {
            string result = "";
            try
            {
                if (TipoDispositivo == 1)
                {
                    ///////////////////////////////// SECCION Android //////////////////////////////////////
                    var webAddr = "https://fcm.googleapis.com/fcm/send";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("Authorization:key=" + Android_ServerKey);
                    httpWebRequest.Headers.Add("Sender:id=" + Android_SenderId);
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\"to\": \"" + TokenDispositivo + "\",\"data\": {\"message\": \"" + Mensaje + "\",}}";
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }

                    if (result.Contains("\"failure\":1"))
                        result = "ERROR:" + result;
                    else
                        result = "MENSAJE ENVIADO";
                }
                else if (TipoDispositivo == 2)
                {

                    ///////////////////////////////// SECCION iOS //////////////////////////////////////
                    var ios_certificate = "";
                    if (IOS_Ambiente == "1")
                        ios_certificate = "SLOOPConductoresDev.p12";

                    if (IOS_Ambiente == "2")
                        ios_certificate = "SLOOPConductoresRelease.p12";

                    string ruta = HttpContext.Current.Server.MapPath("~/Certificates/" + ios_certificate);
                    ApnsServiceBroker apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    if (IOS_Ambiente == "1") //Desarrollo
                        apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    if (IOS_Ambiente == "2") //Producción
                        apnsBroker = new ApnsServiceBroker(new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, File.ReadAllBytes(ruta), IOS_PasswordCertificado, false));

                    apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
                    {
                        result = "ERROR: " + aggregateEx.Message; //Console.WriteLine("Error");
                    };

                    apnsBroker.OnNotificationSucceeded += (notification) =>
                    {
                        result = "Mensaje enviado";  //Console.WriteLine("Sent");
                    };

                    apnsBroker.Start();

                    apnsBroker.QueueNotification(new ApnsNotification
                    {
                        DeviceToken = TokenDispositivo,
                        Payload = JObject.Parse("{\"aps\":{\"alert\":{\"title\":\"\",\"body\":\"" + Mensaje + "\"},\"badge\":-1,\"sound\":\"chime.aiff\"}}")
                    });

                    apnsBroker.Stop();

                    result = "Mensaje enviado";
                }
            }
            catch (Exception ex)
            {

                result = "ERROR: " + ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        #endregion API Methods

    }
}


using oAuth.WebAPI.Consumer;
using Spartane.Core.Classes.LDAP;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;
using oAuth.WebApi.Helpers;
using System.Web.Http.Description;

namespace oAuth.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LDAPAuthenticationController : ApiController
    {
        #region "Variable Declaration"
        public string APIAction="";
        #endregion

        /// <summary>
        /// Declare constructor of class
        /// </summary>
        public LDAPAuthenticationController()
        {
            APIAction = "/api/LDAPAuthentication";
        }

        /// <summary>
        /// Validate LDAP using domain, username and password
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ValidateLDAP(ValidateUser objLDAP)
        {
            bool result = false;
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, objLDAP.Domain))
                {
                    result = pc.ValidateCredentials(objLDAP.User, objLDAP.Password);
                }
            }
            catch (Exception)
            {               
            }
            
          return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        
    }
}

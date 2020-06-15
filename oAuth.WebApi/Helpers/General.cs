using oAuth.WebAPI.Consumer;
using Spartane.Core.Classes.LDAP;
using Spartane.Core.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Web;

namespace oAuth.WebApi.Helpers
{
    public class General
    {


        public static bool AuthorizeUser()
        {

            bool result = false;
            string key = ConfigurationManager.AppSettings["AutherizeType"].ToString();
            //TODO : This is Temporarily taken from Config file as we dont have any credential to check.
            //Change the config details with User Details.
            string domain = ConfigurationManager.AppSettings["DomainName"].ToString();
            string userName = ConfigurationManager.AppSettings["UserName"].ToString();
            string password = ConfigurationManager.AppSettings["Password"].ToString();

            ValidateUser objLDAP = new ValidateUser();
            objLDAP.Domain = domain;
            objLDAP.User = userName;
            objLDAP.Password = password;

            var authorizationType = (AuthType)Enum.Parse(
                                  typeof(AuthType), key, true);


            switch (authorizationType)
            {
                case AuthType.DB:
                    result = ValidateUsingDatabase();
                    break;
                case AuthType.Dir:
                    result = ValidateUsingLdap(objLDAP);
                    break;
            }

            return result;

        }

        public static bool ValidateUsingLdap(ValidateUser objLDAP)
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

            return result;
        }

        public static bool ValidateUsingDatabase()
        {
            bool result = false;

            try
            {
                WebHeaderCollection token = TokenManager.GetAuthenticationHeader();
                if (token.Count != 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception)
            {


            }

            return result;

        }
    }
}
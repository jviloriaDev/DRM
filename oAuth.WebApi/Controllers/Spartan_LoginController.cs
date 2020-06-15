using Spartane.Core.Classes.Spartan_User;
using Spartane.Services.Spartan_User;
using Spartane.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace oAuth.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Spartan_LoginController : BaseApiController
    {
        #region Variables
        private ISpartan_UserService serviceUser = null;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Spartan_LoginController(ISpartan_UserService serviceUser)
        {
            this.serviceUser = serviceUser;
        }
        #endregion Constructor

        #region API Methods
        [Authorize]
        public HttpResponseMessage Login(SpartanUserLogin user)
        {
            try
            {
                int idUser = 0;
                int idUserRole = 0;
                int result = -1;
                string message = "Error";
                List<Spartan_User> users = this.serviceUser.ListaSelAll(1, 10, "Username = '" + user.username + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Password = '" + user.password + "'  COLLATE SQL_Latin1_General_CP1_CS_AS", "").Spartan_Users;
                if (users == null || users.Count == 0)
                {
                    result = 1;
                    message = "User or Password Invalid";
                }
                else
                {
                    if (users.First().Status.HasValue && users.First().Status == 0)
                    {
                        result = 2;
                        message = "Access Denied";
                    }
                    else
                    {
                        idUser = users.First().Id_User;
                        idUserRole = users.First().Role.Value;
                        result = 0;
                        message = "OK";
                    }
                }
                //var entity = this.service.GetByKey(id, false);
                var entity = new
                {
                    idUser = idUser,
                    idUserRole = idUserRole,
                    Result = result,
                    Message = message
                };
                return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                var entity = new
                {
                    idUser = 0,
                    idUserRole = 0,
                    Result = -1,
                    Message = "Error"
                };
                return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
            }
        #endregion
        }
    }

    public class SpartanUserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}

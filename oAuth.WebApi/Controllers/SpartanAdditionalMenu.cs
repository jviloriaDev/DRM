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
using Spartane.Core.Classes.Spartan_User;
using Spartane.Services.Spartan_User;
using Spartane.WebApi.Controllers;
using Spartane.Services.Spartan_Additional_Menu;

namespace oAuth.WebApi.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class SpartanAdditionalMenuController : BaseApiController
    {
        private ISpartan_Additional_Menu service = null;

        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public SpartanAdditionalMenuController(ISpartan_Additional_Menu service)
        {
            this.service = service;
        }

        //[Authorize]
        public HttpResponseMessage GetMenu(int user, int languageId)
        {
            var entity = this.service.GetMenu(user, languageId);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

    }
}
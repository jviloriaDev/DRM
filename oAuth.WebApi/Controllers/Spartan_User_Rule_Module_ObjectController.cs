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
using Spartane.Core.Classes.Spartan_User_Rule_Module_Object;
using Spartane.Services.Spartan_User_Rule_Module_Object;

namespace Spartane.WebApi.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class Spartan_User_Rule_Module_ObjectController : BaseApiController
    {
        private ISpartan_User_Rule_Module_ObjectService service = null;

        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Spartan_User_Rule_Module_ObjectController(ISpartan_User_Rule_Module_ObjectService service)
        {
            this.service = service;
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var entity = this.service.GetByKey(id, false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage GetAll()
        {
            var entity = this.service.SelAll(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        public HttpResponseMessage ListaSelAll(int startRowIndex, int maximumRows, string where = "", string order = "")
        {
            var entity = this.service.ListaSelAll(startRowIndex, maximumRows, where, order);
            entity.RowCount = this.service.ListaSelAllCount(where);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAllComplete()
        {
            var entity = this.service.SelAllComplete(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage GetAll(string where, string order)
        {
            var entity = this.service.SelAll(false, where, /*"Clave"*/order);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        public HttpResponseMessage Post(Spartan_User_Rule_Module_Object varSpartan_User_Rule_Module_Object)
        {
            if (ModelState.IsValid)
            {
                var data = -1;
                try
                {
                    data = this.service.Insert(varSpartan_User_Rule_Module_Object); //, globalData, dataReference);
                }
                catch (ServiceException ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Spartan_User_Rule_Module_Object varSpartan_User_Rule_Module_Object)
        {
            if (ModelState.IsValid && id == varSpartan_User_Rule_Module_Object.User_Rule_Module_Object_Id)
            {
                var data = -1;
                try
                {
                    data = this.service.Update(varSpartan_User_Rule_Module_Object);//, globalData, dataReference);
                }
                catch (ServiceException ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="spartanUserRole">
        /// Added as Required in the SP for Delete
        /// </param>
        /// <remarks>
        /// Date (06/03/2016)
        /// Deleted code in the section A as:
        /// 1.It is overhead to Delete functionality.
        /// 2.GetByKey(id,false) method calls the SP which takes spartanUserRole as 
        /// additional parameter. Adding this parameter would change the implementation of 
        /// GetByKey API method everywhere. Instead we should modify the sp sp_GetSpartan_User_Rule_Module_Object 
        /// to remove SpartaneUserRole parameter.
        /// 3. sp_GetSpartan_User_Rule_Module_Object only fires "Select * from" statement which is not needed in Delete
        /// functionality.
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage Delete(int id,int spartanUserRole)
        {
            // Deleted -- Section A -- Start
            //Spartan_User_Rule_Module_Object varSpartan_User_Rule_Module_Object = this.service.GetByKey(id, false);
            
            //if (varSpartan_User_Rule_Module_Object == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}
            // Section - A - END

            bool result = false;

            try
            {
                result = this.service.Delete(id, spartanUserRole);//, globalData, dataReference);
            }
            catch (ServiceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}



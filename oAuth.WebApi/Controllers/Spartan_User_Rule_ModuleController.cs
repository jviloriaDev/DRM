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
using Spartane.Core.Classes.Spartan_User_Rule_Module;
using Spartane.Services.Spartan_User_Rule_Module;

namespace Spartane.WebApi.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class Spartan_User_Rule_ModuleController : BaseApiController
    {
        private ISpartan_User_Rule_ModuleService service = null;

        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Spartan_User_Rule_ModuleController(ISpartan_User_Rule_ModuleService service)
        {
            this.service = service;
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage Get(short id)
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

        public HttpResponseMessage Post(Spartan_User_Rule_Module varSpartan_User_Rule_Module)
        {
            if (ModelState.IsValid)
            {
                var data = -1;
                try
                {
                    data = this.service.Insert(varSpartan_User_Rule_Module); //, globalData, dataReference);
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
        public HttpResponseMessage Put(short id, Spartan_User_Rule_Module varSpartan_User_Rule_Module)
        {
            if (ModelState.IsValid && id == varSpartan_User_Rule_Module.User_Rule_Module_Id)
            {
                var data = -1;
                try
                {
                    data = this.service.Update(varSpartan_User_Rule_Module);//, globalData, dataReference);
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
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SpartanUserRole">
        /// Added this parameter as required by Delete Stored procedure.
        /// </param>
        /// <remarks>
        /// Date (06/03/2015)
        /// 
        /// Deleted code in Section A as:
        /// 1. It is overhead to delete functionality.
        /// 2. GetByKey(id,false) method calls sp sp_GetSpartan_User_Rule_Module which requires 
        /// additional parameter @Spartan_User_Role.Adding this parameter would change the implementation of 
        /// GetByKey API method everywhere. Instead we should modify the sp sp_GetSpartan_User_Rule_Module 
        /// to remove @Spartan_User_Role parameter.
        /// 3.sp_GetSpartan_User_Rule_Module only fires "Select * from" statement which is not needed in Delete
        /// functionality.
        /// </remarks>
        /// <returns></returns>

        [HttpDelete]
        public HttpResponseMessage Delete(short id, int Spartan_User_Role)
        {
            //Section - A - Start
            //Deleted
            //Spartan_User_Rule_Module varSpartan_User_Rule_Module = this.service.GetByKey(id, false);
            //bool result = false;
            //if (varSpartan_User_Rule_Module == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}
            //Section - A - End

            bool result = false;
            try
            {
                result = this.service.Delete(id, Spartan_User_Role);//, globalData, dataReference);
            }
            catch (ServiceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}



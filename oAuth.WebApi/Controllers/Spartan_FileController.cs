using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using oAuth.WebApi;
using Spartane.Core.Exceptions.Service;using System.Web.Http.Description;
using System.Web;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Services.Spartan_File;

namespace Spartane.WebApi.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class Spartan_FileController : BaseApiController
    {
        private ISpartan_FileService service = null;
        private string fileSaveLocation = HttpContext.Current.Server.MapPath(GlobalParameterConfiguration.FileFolderLocation);

        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Spartan_FileController(ISpartan_FileService service)
        {
            this.service = service;
        }

        [NonAction]
        public Spartane_FileModel GetModelFromSpartaneFile(Spartane_File file)
        {
            if (file != null)
            {
                return new Spartane_FileModel()
                {
                    Date_Time = file.Date_Time,
                    Description = file.Description,
                    File = null,
                    File_Id = file.File_Id,
                    File_Size = file.File_Size
                };
            }
            else
            {
                return new Spartane_FileModel();
            }
        }

        [NonAction]
        public Spartane_File GetSpartaneFileFromModel(Spartane_FileModel file)
        {
            if (file != null)
            {
                return new Spartane_File()
                {
                    Date_Time = file.Date_Time,
                    Description = file.Description,
                    File_Id = file.File_Id,
                    File_Size = file.File_Size
                };
            }
            else
            {
                return new Spartane_File();
            }
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var entityData = this.service.GetByKey(id, false);

            var entity = GetModelFromSpartaneFile(entityData);
            if (entity != null)
                entity.File = GetFileBytes(entity);

            //File.WriteAllBytes(fileSaveLocation + "\\" + data + "\\" + varSpartan_File.Description, varSpartan_File.File);

            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage GetAll()
        {
            var entityData = this.service.SelAll(false);

            var entity = entityData.Select(GetModelFromSpartaneFile).ToList();
            for (int i = 0; i < entity.Count; i++)
                entity[i].File = GetFileBytes(entity[i]);

            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [NonAction]
        public byte[] GetFileBytes(Spartane_FileModel fileInfo)
        {
            if (fileInfo.File_Id > 0)
            {
                if (File.Exists(fileSaveLocation + "\\" + fileInfo.File_Id + "\\" + fileInfo.Description))
                {
                    return File.ReadAllBytes(fileSaveLocation + "\\" + fileInfo.File_Id + "\\" + fileInfo.Description);
                }
                else
                {
                    return new byte[0];
                }
            }
            else
            {
                return new byte[0];
            }
            
            // return fileInfo;
        }

        [NonAction]
        public List<Spartane_FileModel> GetFilesBytes(List<Spartane_FileModel> filesInfo)
        {
            for (int i = 0; i < filesInfo.Count; i++)
            {
                filesInfo[i].File = GetFileBytes(filesInfo[i]);
            }

            return filesInfo;
        }

        [HttpGet]
        public HttpResponseMessage ListaSelAll(int startRowIndex, int maximumRows, string where = "", string order = "")
        {
            var entity = this.service.ListaSelAll(startRowIndex, maximumRows, where, order);

            /*for (int i = 0; i < entity.Spartan_Files.Count; i++)
                entity.Spartan_Files[i].File = GetFileBytes(entity.Spartan_Files[i]);*/


            entity.RowCount = this.service.ListaSelAllCount(where);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAllComplete()
        {
            var entityData = this.service.SelAllComplete(false);

            var entity = entityData.Select(GetModelFromSpartaneFile).ToList();
            for (int i = 0; i < entity.Count; i++)
                entity[i].File = GetFileBytes(entity[i]);

            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage GetAll(string where, string order)
        {
            var entityData = this.service.SelAll(false, where, /*"Clave"*/order);

            var entity = entityData.Select(GetModelFromSpartaneFile).ToList();
            for (int i = 0; i < entity.Count; i++)
            {
                entity[i].File = GetFileBytes(entity[i]);
            }
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        public HttpResponseMessage Post(Spartane_FileModel varSpartan_File)
        {
            if (ModelState.IsValid)
            {
                var data = -1;
                try
                {
                    data = this.service.Insert(GetSpartaneFileFromModel(varSpartan_File)); //, globalData, dataReference);
                    
                    if (!Directory.Exists(fileSaveLocation))
                        Directory.CreateDirectory(fileSaveLocation);

                    if (!Directory.Exists(fileSaveLocation + "\\" + data))
                        Directory.CreateDirectory(fileSaveLocation + "\\" + data);

                    File.WriteAllBytes(fileSaveLocation + "\\" + data + "\\" + varSpartan_File.Description, varSpartan_File.File);
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
        public HttpResponseMessage Put(int id, Spartane_FileModel varSpartan_File)
        {
            if (ModelState.IsValid && id == varSpartan_File.File_Id)
            {
                var data = -1;
                try
                {
                    data = this.service.Update(GetSpartaneFileFromModel(varSpartan_File));//, globalData, dataReference);

                    if (!Directory.Exists(fileSaveLocation + "\\" + data))
                    {
                        Directory.Delete(fileSaveLocation + "\\" + data);
                        Directory.CreateDirectory(fileSaveLocation + "\\" + data);
                    }

                    File.WriteAllBytes(fileSaveLocation + "\\" + data + "\\" + varSpartan_File.Description, varSpartan_File.File);
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

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Spartane_File varSpartan_File = this.service.GetByKey(id, false);
            bool result = false;
            if (varSpartan_File == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                result = this.service.Delete(id);//, globalData, dataReference);
                if (!Directory.Exists(fileSaveLocation + "\\" + id))
                {
                    Directory.Delete(fileSaveLocation + "\\" + id);
                }
            }
            catch (ServiceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}



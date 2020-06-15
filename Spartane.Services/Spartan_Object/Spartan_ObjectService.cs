using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Object;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Object
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_ObjectService : ISpartan_ObjectService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Object.Spartan_Object> _Spartan_ObjectRepository;
        #endregion

        #region Ctor
        public Spartan_ObjectService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Object.Spartan_Object> Spartan_ObjectRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_ObjectRepository = Spartan_ObjectRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_ObjectRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object.Spartan_Object>("sp_SelAllSpartan_Object");
        }

        public IList<Core.Classes.Spartan_Object.Spartan_Object> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Object_Complete>("sp_SelAllComplete_Spartan_Object");
            return data.Select(m => new Core.Classes.Spartan_Object.Spartan_Object
            {
                Object_Id = m.Object_Id
                ,Name = m.Name
                ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Image.GetValueOrDefault(), Description = m.Image_Description }
                ,URL = m.URL
                ,Description = m.Description
                ,Tags = m.Tags
                ,Object_Type_Spartan_Object_Type = new Core.Classes.Spartan_Object_Type.Spartan_Object_Type() { Object_Type_Id = m.Object_Type.GetValueOrDefault(), Description = m.Object_Type_Description }
                ,Status_Spartan_Object_Status = new Core.Classes.Spartan_Object_Status.Spartan_Object_Status() { Object_Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Object>("sp_ListSelCount_Spartan_Object", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object>("sp_ListSelAll_Spartan_Object", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Object.Spartan_Object
                {
                    Object_Id = m.Spartan_Object_Object_Id,
                    Name = m.Spartan_Object_Name,
                    Image = m.Spartan_Object_Image,
                    URL = m.Spartan_Object_URL,
                    Description = m.Spartan_Object_Description,
                    Tags = m.Spartan_Object_Tags,
                    Object_Type = m.Spartan_Object_Object_Type,
                    Status = m.Spartan_Object_Status,

                    //Id = m.Id,
                }).ToList();
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

        }

        public IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_ObjectRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_ObjectRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object.Spartan_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var padstartRowIndex = _dataProvider.GetParameter();
            padstartRowIndex.ParameterName = "startRowIndex";
            padstartRowIndex.DbType = DbType.Int32;
            padstartRowIndex.Value = startRowIndex;

            var padmaximumRows = _dataProvider.GetParameter();
            padmaximumRows.ParameterName = "maximumRows";
            padmaximumRows.DbType = DbType.Int32;
            padmaximumRows.Value = maximumRows;

            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var padOrder = _dataProvider.GetParameter();
            padOrder.ParameterName = "Order";
            padOrder.DbType = DbType.String;
            padOrder.Value = Order;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object>("sp_ListSelAll_Spartan_Object", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_ObjectPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_ObjectPagingModel
                {
                    Spartan_Objects =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Object.Spartan_Object
                {
                    Object_Id = m.Spartan_Object_Object_Id
                    ,Name = m.Spartan_Object_Name
                    ,Image = m.Spartan_Object_Image
                    ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Spartan_Object_Image.GetValueOrDefault(), Description = m.Spartan_Object_Image_Description }
                    ,URL = m.Spartan_Object_URL
                    ,Description = m.Spartan_Object_Description
                    ,Tags = m.Spartan_Object_Tags
                    ,Object_Type = m.Spartan_Object_Object_Type
                    ,Object_Type_Spartan_Object_Type = new Core.Classes.Spartan_Object_Type.Spartan_Object_Type() { Object_Type_Id = m.Spartan_Object_Object_Type.GetValueOrDefault(), Description = m.Spartan_Object_Object_Type_Description }
                    ,Status = m.Spartan_Object_Status
                    ,Status_Spartan_Object_Status = new Core.Classes.Spartan_Object_Status.Spartan_Object_Status() { Object_Status_Id = m.Spartan_Object_Status.GetValueOrDefault(), Description = m.Spartan_Object_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_ObjectRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object.Spartan_Object GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Object_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object.Spartan_Object>("sp_GetSpartan_Object", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Object_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Object>("sp_DelSpartan_Object", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result == 1;
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Spartane.Core.Classes.Spartan_Object.Spartan_Object entity)
        {
            int rta;
            try
            {
                var padreObjectId = _dataProvider.GetParameter();
                padreObjectId.ParameterName = "Object_Id";
                padreObjectId.DbType = DbType.Int32;
                padreObjectId.Value = entity.Object_Id;

		                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = entity.Name;
                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreTags = _dataProvider.GetParameter();
                padreTags.ParameterName = "Tags";
                padreTags.DbType = DbType.String;
                padreTags.Value = entity.Tags;
                var padreObject_Type = _dataProvider.GetParameter();
                padreObject_Type.ParameterName = "Object_Type";
                padreObject_Type.DbType = DbType.Int16;
                if (entity.Object_Type == null)
                    padreObject_Type.Value = DBNull.Value;
                else
                    padreObject_Type.Value = entity.Object_Type;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Object>("sp_InsSpartan_Object", padreObjectId, padreName 
, padreImage 
, padreURL 
, padreDescription 
, padreTags 
, padreObject_Type 
, padreStatus 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Id);

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Spartane.Core.Classes.Spartan_Object.Spartan_Object entity)
        {
            int rta;
            try
            {

                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                padreObject_Id.Value = entity.Object_Id;
                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = entity.Name;
                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreTags = _dataProvider.GetParameter();
                padreTags.ParameterName = "Tags";
                padreTags.DbType = DbType.String;
                padreTags.Value = entity.Tags;
                var padreObject_Type = _dataProvider.GetParameter();
                padreObject_Type.ParameterName = "Object_Type";
                padreObject_Type.DbType = DbType.Int16;
                if (entity.Object_Type == null)
                    padreObject_Type.Value = DBNull.Value;
                else
                    padreObject_Type.Value = entity.Object_Type;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Object>("sp_UpdSpartan_Object" , padreObject_Id  , padreName  , padreImage  , padreURL  , padreDescription  , padreTags  , padreObject_Type  , padreStatus  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Id);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
        #endregion
    }
}


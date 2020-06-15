using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Object_Method;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Object_Method
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Object_MethodService : ISpartan_Object_MethodService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method> _Spartan_Object_MethodRepository;
        #endregion

        #region Ctor
        public Spartan_Object_MethodService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method> Spartan_Object_MethodRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Object_MethodRepository = Spartan_Object_MethodRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Object_MethodRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method>("sp_SelAllSpartan_Object_Method");
        }

        public IList<Core.Classes.Spartan_Object_Method.Spartan_Object_Method> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Object_Method_Complete>("sp_SelAllComplete_Spartan_Object_Method");
            return data.Select(m => new Core.Classes.Spartan_Object_Method.Spartan_Object_Method
            {
                Object_Method_Id = m.Object_Method_Id
                ,Module_Id = m.Module_Id
                ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object_Id.GetValueOrDefault(), Name = m.Object_Id_Name }
                ,Name = m.Name
                ,Physical_Name = m.Physical_Name
                ,URL = m.URL
                ,Method_Type_Spartan_Method_Type = new Core.Classes.Spartan_Method_Type.Spartan_Method_Type() { Method_Type_Id = m.Method_Type.GetValueOrDefault(), Description = m.Method_Type_Description }
                ,Scope = m.Scope
                ,Tags = m.Tags
                ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Image.GetValueOrDefault(), Description = m.Image_Description }
                ,Status_Spartan_Object_Method_Status = new Core.Classes.Spartan_Object_Method_Status.Spartan_Object_Method_Status() { Object_Method_Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Object_Method>("sp_ListSelCount_Spartan_Object_Method", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object_Method>("sp_ListSelAll_Spartan_Object_Method", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method
                {
                    Module_Id = m.Spartan_Object_Method_Module_Id,
                    Object_Id = m.Spartan_Object_Method_Object_Id,
                    Name = m.Spartan_Object_Method_Name,
                    Physical_Name = m.Spartan_Object_Method_Physical_Name,
                    URL = m.Spartan_Object_Method_URL,
                    Method_Type = m.Spartan_Object_Method_Method_Type,
                    Scope = m.Spartan_Object_Method_Scope,
                    Tags = m.Spartan_Object_Method_Tags,
                    Image = m.Spartan_Object_Method_Image,
                    Status = m.Spartan_Object_Method_Status,
                    Object_Method_Id = m.Spartan_Object_Method_Object_Method_Id,

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

        public IList<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Object_MethodRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Object_MethodRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_MethodPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object_Method>("sp_ListSelAll_Spartan_Object_Method", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Object_MethodPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Object_MethodPagingModel
                {
                    Spartan_Object_Methods =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method
                {
                    Object_Method_Id = m.Spartan_Object_Method_Object_Method_Id
                    ,Module_Id = m.Spartan_Object_Method_Module_Id
                    ,Object_Id = m.Spartan_Object_Method_Object_Id
                    ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Object_Method_Object_Id.GetValueOrDefault(), Name = m.Spartan_Object_Method_Object_Id_Name }
                    ,Name = m.Spartan_Object_Method_Name
                    ,Physical_Name = m.Spartan_Object_Method_Physical_Name
                    ,URL = m.Spartan_Object_Method_URL
                    ,Method_Type = m.Spartan_Object_Method_Method_Type
                    ,Method_Type_Spartan_Method_Type = new Core.Classes.Spartan_Method_Type.Spartan_Method_Type() { Method_Type_Id = m.Spartan_Object_Method_Method_Type.GetValueOrDefault(), Description = m.Spartan_Object_Method_Method_Type_Description }
                    ,Scope = m.Spartan_Object_Method_Scope
                    ,Tags = m.Spartan_Object_Method_Tags
                    ,Image = m.Spartan_Object_Method_Image
                    ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Spartan_Object_Method_Image.GetValueOrDefault(), Description = m.Spartan_Object_Method_Image_Description }
                    ,Status = m.Spartan_Object_Method_Status
                    ,Status_Spartan_Object_Method_Status = new Core.Classes.Spartan_Object_Method_Status.Spartan_Object_Method_Status() { Object_Method_Status_Id = m.Spartan_Object_Method_Status.GetValueOrDefault(), Description = m.Spartan_Object_Method_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Object_MethodRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Object_Method_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method>("sp_GetSpartan_Object_Method", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Object_Method_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Object_Method>("sp_DelSpartan_Object_Method", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method entity)
        {
            int rta;
            try
            {

		                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                padreModule_Id.Value = entity.Module_Id;
                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = entity.Name;
                var padrePhysical_Name = _dataProvider.GetParameter();
                padrePhysical_Name.ParameterName = "Physical_Name";
                padrePhysical_Name.DbType = DbType.String;
                padrePhysical_Name.Value = entity.Physical_Name;
                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreMethod_Type = _dataProvider.GetParameter();
                padreMethod_Type.ParameterName = "Method_Type";
                padreMethod_Type.DbType = DbType.Int16;
                if (entity.Method_Type == null)
                    padreMethod_Type.Value = DBNull.Value;
                else
                    padreMethod_Type.Value = entity.Method_Type;

                var padreScope = _dataProvider.GetParameter();
                padreScope.ParameterName = "Scope";
                padreScope.DbType = DbType.String;
                padreScope.Value = entity.Scope;
                var padreTags = _dataProvider.GetParameter();
                padreTags.ParameterName = "Tags";
                padreTags.DbType = DbType.String;
                padreTags.Value = entity.Tags;
                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Object_Method>("sp_InsSpartan_Object_Method" , padreModule_Id 
, padreObject_Id 
, padreName 
, padrePhysical_Name 
, padreURL 
, padreMethod_Type 
, padreScope 
, padreTags 
, padreImage 
, padreStatus 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Method_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method entity)
        {
            int rta;
            try
            {

                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                padreModule_Id.Value = entity.Module_Id;
                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = entity.Name;
                var padrePhysical_Name = _dataProvider.GetParameter();
                padrePhysical_Name.ParameterName = "Physical_Name";
                padrePhysical_Name.DbType = DbType.String;
                padrePhysical_Name.Value = entity.Physical_Name;
                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreMethod_Type = _dataProvider.GetParameter();
                padreMethod_Type.ParameterName = "Method_Type";
                padreMethod_Type.DbType = DbType.Int16;
                if (entity.Method_Type == null)
                    padreMethod_Type.Value = DBNull.Value;
                else
                    padreMethod_Type.Value = entity.Method_Type;

                var padreScope = _dataProvider.GetParameter();
                padreScope.ParameterName = "Scope";
                padreScope.DbType = DbType.String;
                padreScope.Value = entity.Scope;
                var padreTags = _dataProvider.GetParameter();
                padreTags.ParameterName = "Tags";
                padreTags.DbType = DbType.String;
                padreTags.Value = entity.Tags;
                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;

                var padreObject_Method_Id = _dataProvider.GetParameter();
                padreObject_Method_Id.ParameterName = "Object_Method_Id";
                padreObject_Method_Id.DbType = DbType.Int32;
                padreObject_Method_Id.Value = entity.Object_Method_Id;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Object_Method>("sp_UpdSpartan_Object_Method" , padreModule_Id  , padreObject_Id  , padreName  , padrePhysical_Name  , padreURL  , padreMethod_Type  , padreScope  , padreTags  , padreImage  , padreStatus  , padreObject_Method_Id  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Method_Id);
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


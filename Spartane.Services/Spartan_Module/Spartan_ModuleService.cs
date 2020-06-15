using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Module;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Module
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_ModuleService : ISpartan_ModuleService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Module.Spartan_Module> _Spartan_ModuleRepository;
        #endregion

        #region Ctor
        public Spartan_ModuleService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Module.Spartan_Module> Spartan_ModuleRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_ModuleRepository = Spartan_ModuleRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_ModuleRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module.Spartan_Module>("sp_SelAllSpartan_Module");
        }

        public IList<Core.Classes.Spartan_Module.Spartan_Module> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Module_Complete>("sp_SelAllComplete_Spartan_Module");
            return data.Select(m => new Core.Classes.Spartan_Module.Spartan_Module
            {
                Module_Id = m.Module_Id
                ,Name = m.Name
                ,System_Id_Spartan_System = new Core.Classes.Spartan_System.Spartan_System() { System_Id = m.System_Id.GetValueOrDefault(), Version = m.System_Id_Version }
                ,Parent_Module = m.Parent_Module
                ,Order_Shown = m.Order_Shown
                ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Image.GetValueOrDefault(), Description = m.Image_Description }
                ,Object_Config_Id_Spartan_Object_Config = new Core.Classes.Spartan_Object_Config.Spartan_Object_Config() { Object_Config_Id = m.Object_Config_Id.GetValueOrDefault(), Description = m.Object_Config_Id_Description }
                ,Description = m.Description
                ,Status_Spartan_Module_Status = new Core.Classes.Spartan_Module_Status.Spartan_Module_Status() { Module_Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Module>("sp_ListSelCount_Spartan_Module", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module>("sp_ListSelAll_Spartan_Module", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Module.Spartan_Module
                {
                    Module_Id = m.Spartan_Module_Module_Id,
                    Name = m.Spartan_Module_Name,
                    System_Id = m.Spartan_Module_System_Id,
                    Parent_Module = m.Spartan_Module_Parent_Module,
                    Order_Shown = m.Spartan_Module_Order_Shown,
                    Image = m.Spartan_Module_Image,
                    Object_Config_Id = m.Spartan_Module_Object_Config_Id,
                    Description = m.Spartan_Module_Description,
                    Status = m.Spartan_Module_Status,

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

        public IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_ModuleRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_ModuleRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module.Spartan_ModulePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module>("sp_ListSelAll_Spartan_Module", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_ModulePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_ModulePagingModel
                {
                    Spartan_Modules =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Module.Spartan_Module
                {
                    Module_Id = m.Spartan_Module_Module_Id
                    ,Name = m.Spartan_Module_Name
                    ,System_Id = m.Spartan_Module_System_Id
                    ,System_Id_Spartan_System = new Core.Classes.Spartan_System.Spartan_System() { System_Id = m.Spartan_Module_System_Id.GetValueOrDefault(), Version = m.Spartan_Module_System_Id_Version }
                    ,Parent_Module = m.Spartan_Module_Parent_Module
                    ,Order_Shown = m.Spartan_Module_Order_Shown
                    ,Image = m.Spartan_Module_Image
                    ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Spartan_Module_Image.GetValueOrDefault(), Description = m.Spartan_Module_Image_Description }
                    ,Object_Config_Id = m.Spartan_Module_Object_Config_Id
                    ,Object_Config_Id_Spartan_Object_Config = new Core.Classes.Spartan_Object_Config.Spartan_Object_Config() { Object_Config_Id = m.Spartan_Module_Object_Config_Id.GetValueOrDefault(), Description = m.Spartan_Module_Object_Config_Id_Description }
                    ,Description = m.Spartan_Module_Description
                    ,Status = m.Spartan_Module_Status
                    ,Status_Spartan_Module_Status = new Core.Classes.Spartan_Module_Status.Spartan_Module_Status() { Module_Status_Id = m.Spartan_Module_Status.GetValueOrDefault(), Description = m.Spartan_Module_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_ModuleRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module.Spartan_Module GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Module_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module.Spartan_Module>("sp_GetSpartan_Module", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Module_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Module>("sp_DelSpartan_Module", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Module.Spartan_Module entity)
        {
            short rta;
            try
            {

		                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = entity.Name;
                var padreSystem_Id = _dataProvider.GetParameter();
                padreSystem_Id.ParameterName = "System_Id";
                padreSystem_Id.DbType = DbType.Int16;
                if (entity.System_Id == null)
                    padreSystem_Id.Value = DBNull.Value;
                else
                    padreSystem_Id.Value = entity.System_Id;

                var padreParent_Module = _dataProvider.GetParameter();
                padreParent_Module.ParameterName = "Parent_Module";
                padreParent_Module.DbType = DbType.Int16;
                if (entity.Parent_Module == null)
                    padreParent_Module.Value = DBNull.Value;
                else
                    padreParent_Module.Value = entity.Parent_Module;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreObject_Config_Id = _dataProvider.GetParameter();
                padreObject_Config_Id.ParameterName = "Object_Config_Id";
                padreObject_Config_Id.DbType = DbType.Int16;
                if (entity.Object_Config_Id == null)
                    padreObject_Config_Id.Value = DBNull.Value;
                else
                    padreObject_Config_Id.Value = entity.Object_Config_Id;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Module>("sp_InsSpartan_Module" , padreName 
, padreSystem_Id 
, padreParent_Module 
, padreOrder_Shown 
, padreImage 
, padreObject_Config_Id 
, padreDescription 
, padreStatus 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Module_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Module.Spartan_Module entity)
        {
            short rta;
            try
            {

                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                padreModule_Id.Value = entity.Module_Id;
                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = entity.Name;
                var padreSystem_Id = _dataProvider.GetParameter();
                padreSystem_Id.ParameterName = "System_Id";
                padreSystem_Id.DbType = DbType.Int16;
                if (entity.System_Id == null)
                    padreSystem_Id.Value = DBNull.Value;
                else
                    padreSystem_Id.Value = entity.System_Id;

                var padreParent_Module = _dataProvider.GetParameter();
                padreParent_Module.ParameterName = "Parent_Module";
                padreParent_Module.DbType = DbType.Int16;
                if (entity.Parent_Module == null)
                    padreParent_Module.Value = DBNull.Value;
                else
                    padreParent_Module.Value = entity.Parent_Module;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreObject_Config_Id = _dataProvider.GetParameter();
                padreObject_Config_Id.ParameterName = "Object_Config_Id";
                padreObject_Config_Id.DbType = DbType.Int16;
                if (entity.Object_Config_Id == null)
                    padreObject_Config_Id.Value = DBNull.Value;
                else
                    padreObject_Config_Id.Value = entity.Object_Config_Id;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Module>("sp_UpdSpartan_Module" , padreModule_Id  , padreName  , padreSystem_Id  , padreParent_Module  , padreOrder_Shown  , padreImage  , padreObject_Config_Id  , padreDescription  , padreStatus  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Module_Id);
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


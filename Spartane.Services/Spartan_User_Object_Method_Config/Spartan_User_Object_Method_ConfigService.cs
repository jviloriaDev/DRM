using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User_Object_Method_Config;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Object_Method_Config
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_Object_Method_ConfigService : ISpartan_User_Object_Method_ConfigService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> _Spartan_User_Object_Method_ConfigRepository;
        #endregion

        #region Ctor
        public Spartan_User_Object_Method_ConfigService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> Spartan_User_Object_Method_ConfigRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_Object_Method_ConfigRepository = Spartan_User_Object_Method_ConfigRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_User_Object_Method_ConfigRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config>("sp_SelAllSpartan_User_Object_Method_Config");
        }

        public IList<Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Object_Method_Config_Complete>("sp_SelAllComplete_Spartan_User_Object_Method_Config");
            return data.Select(m => new Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config
            {
                User_Object_Method_Config_Id = m.User_Object_Method_Config_Id
                ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.User_Id.GetValueOrDefault(), Name = m.User_Id_Name }
                ,Module_Id_Spartan_Module = new Core.Classes.Spartan_Module.Spartan_Module() { Module_Id = m.Module_Id.GetValueOrDefault(), Name = m.Module_Id_Name }
                ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object_Id.GetValueOrDefault(), Name = m.Object_Id_Name }
                ,Characteristic_Spartan_Object_Method_Characteristic = new Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic() { Object_Method_Characteristic_Id = m.Characteristic.GetValueOrDefault(), Description = m.Characteristic_Description }
                ,Numeric_Value = m.Numeric_Value
                ,Text_Value = m.Text_Value


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User_Object_Method_Config>("sp_ListSelCount_Spartan_User_Object_Method_Config", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Object_Method_Config>("sp_ListSelAll_Spartan_User_Object_Method_Config", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config
                {
                    User_Object_Method_Config_Id = m.Spartan_User_Object_Method_Config_User_Object_Method_Config_Id,
                    User_Id = m.Spartan_User_Object_Method_Config_User_Id,
                    Module_Id = m.Spartan_User_Object_Method_Config_Module_Id,
                    Object_Id = m.Spartan_User_Object_Method_Config_Object_Id,
                    Characteristic = m.Spartan_User_Object_Method_Config_Characteristic,
                    Numeric_Value = m.Spartan_User_Object_Method_Config_Numeric_Value,
                    Text_Value = m.Spartan_User_Object_Method_Config_Text_Value,

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

        public IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_Object_Method_ConfigRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Object_Method_ConfigRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_ConfigPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Object_Method_Config>("sp_ListSelAll_Spartan_User_Object_Method_Config", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_User_Object_Method_ConfigPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_User_Object_Method_ConfigPagingModel
                {
                    Spartan_User_Object_Method_Configs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config
                {
                    User_Object_Method_Config_Id = m.Spartan_User_Object_Method_Config_User_Object_Method_Config_Id
                    ,User_Id = m.Spartan_User_Object_Method_Config_User_Id
                    ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_User_Object_Method_Config_User_Id.GetValueOrDefault(), Name = m.Spartan_User_Object_Method_Config_User_Id_Name }
                    ,Module_Id = m.Spartan_User_Object_Method_Config_Module_Id
                    ,Module_Id_Spartan_Module = new Core.Classes.Spartan_Module.Spartan_Module() { Module_Id = m.Spartan_User_Object_Method_Config_Module_Id.GetValueOrDefault(), Name = m.Spartan_User_Object_Method_Config_Module_Id_Name }
                    ,Object_Id = m.Spartan_User_Object_Method_Config_Object_Id
                    ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_User_Object_Method_Config_Object_Id.GetValueOrDefault(), Name = m.Spartan_User_Object_Method_Config_Object_Id_Name }
                    ,Characteristic = m.Spartan_User_Object_Method_Config_Characteristic
                    ,Characteristic_Spartan_Object_Method_Characteristic = new Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic() { Object_Method_Characteristic_Id = m.Spartan_User_Object_Method_Config_Characteristic.GetValueOrDefault(), Description = m.Spartan_User_Object_Method_Config_Characteristic_Description }
                    ,Numeric_Value = m.Spartan_User_Object_Method_Config_Numeric_Value
                    ,Text_Value = m.Spartan_User_Object_Method_Config_Text_Value

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_Object_Method_ConfigRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "User_Object_Method_Config_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config>("sp_GetSpartan_User_Object_Method_Config", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "User_Object_Method_Config_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User_Object_Method_Config>("sp_DelSpartan_User_Object_Method_Config", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config entity)
        {
            int rta;
            try
            {

		                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                if (entity.Module_Id == null)
                    padreModule_Id.Value = DBNull.Value;
                else
                    padreModule_Id.Value = entity.Module_Id;

                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreCharacteristic = _dataProvider.GetParameter();
                padreCharacteristic.ParameterName = "Characteristic";
                padreCharacteristic.DbType = DbType.Int32;
                if (entity.Characteristic == null)
                    padreCharacteristic.Value = DBNull.Value;
                else
                    padreCharacteristic.Value = entity.Characteristic;

                var padreNumeric_Value = _dataProvider.GetParameter();
                padreNumeric_Value.ParameterName = "Numeric_Value";
                padreNumeric_Value.DbType = DbType.Int32;
                if (entity.Numeric_Value == null)
                    padreNumeric_Value.Value = DBNull.Value;
                else
                    padreNumeric_Value.Value = entity.Numeric_Value;

                var padreText_Value = _dataProvider.GetParameter();
                padreText_Value.ParameterName = "Text_Value";
                padreText_Value.DbType = DbType.String;
                padreText_Value.Value = entity.Text_Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User_Object_Method_Config>("sp_InsSpartan_User_Object_Method_Config" , padreUser_Id 
, padreModule_Id 
, padreObject_Id 
, padreCharacteristic 
, padreNumeric_Value 
, padreText_Value 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Object_Method_Config_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config entity)
        {
            int rta;
            try
            {

                var padreUser_Object_Method_Config_Id = _dataProvider.GetParameter();
                padreUser_Object_Method_Config_Id.ParameterName = "User_Object_Method_Config_Id";
                padreUser_Object_Method_Config_Id.DbType = DbType.Int32;
                padreUser_Object_Method_Config_Id.Value = entity.User_Object_Method_Config_Id;
                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                if (entity.Module_Id == null)
                    padreModule_Id.Value = DBNull.Value;
                else
                    padreModule_Id.Value = entity.Module_Id;

                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreCharacteristic = _dataProvider.GetParameter();
                padreCharacteristic.ParameterName = "Characteristic";
                padreCharacteristic.DbType = DbType.Int32;
                if (entity.Characteristic == null)
                    padreCharacteristic.Value = DBNull.Value;
                else
                    padreCharacteristic.Value = entity.Characteristic;

                var padreNumeric_Value = _dataProvider.GetParameter();
                padreNumeric_Value.ParameterName = "Numeric_Value";
                padreNumeric_Value.DbType = DbType.Int32;
                if (entity.Numeric_Value == null)
                    padreNumeric_Value.Value = DBNull.Value;
                else
                    padreNumeric_Value.Value = entity.Numeric_Value;

                var padreText_Value = _dataProvider.GetParameter();
                padreText_Value.ParameterName = "Text_Value";
                padreText_Value.DbType = DbType.String;
                padreText_Value.Value = entity.Text_Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User_Object_Method_Config>("sp_UpdSpartan_User_Object_Method_Config" , padreUser_Object_Method_Config_Id  , padreUser_Id  , padreModule_Id  , padreObject_Id  , padreCharacteristic  , padreNumeric_Value  , padreText_Value  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Object_Method_Config_Id);
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


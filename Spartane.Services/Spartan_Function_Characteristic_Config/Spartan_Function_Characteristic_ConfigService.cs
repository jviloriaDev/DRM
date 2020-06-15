using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Function_Characteristic_Config;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Function_Characteristic_Config
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Function_Characteristic_ConfigService : ISpartan_Function_Characteristic_ConfigService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config> _Spartan_Function_Characteristic_ConfigRepository;
        #endregion

        #region Ctor
        public Spartan_Function_Characteristic_ConfigService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config> Spartan_Function_Characteristic_ConfigRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Function_Characteristic_ConfigRepository = Spartan_Function_Characteristic_ConfigRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Function_Characteristic_ConfigRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config>("sp_SelAllSpartan_Function_Characteristic_Config");
        }

        public IList<Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Function_Characteristic_Config_Complete>("sp_SelAllComplete_Spartan_Function_Characteristic_Config");
            return data.Select(m => new Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config
            {
                Function_Characteristic_Config_Id = m.Function_Characteristic_Config_Id
                ,Function_Characteristic_Id_Spartan_Function_Characteristic = new Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic() { Function_Characteristic = m.Function_Characteristic_Id.GetValueOrDefault(), Description = m.Function_Characteristic_Id_Description }
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Function_Characteristic_Config>("sp_ListSelCount_Spartan_Function_Characteristic_Config", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function_Characteristic_Config>("sp_ListSelAll_Spartan_Function_Characteristic_Config", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config
                {
                    Function_Characteristic_Config_Id = m.Spartan_Function_Characteristic_Config_Function_Characteristic_Config_Id,
                    Function_Characteristic_Id = m.Spartan_Function_Characteristic_Config_Function_Characteristic_Id,
                    Numeric_Value = m.Spartan_Function_Characteristic_Config_Numeric_Value,
                    Text_Value = m.Spartan_Function_Characteristic_Config_Text_Value,

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

        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Function_Characteristic_ConfigRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Function_Characteristic_ConfigRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_ConfigPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function_Characteristic_Config>("sp_ListSelAll_Spartan_Function_Characteristic_Config", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Function_Characteristic_ConfigPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Function_Characteristic_ConfigPagingModel
                {
                    Spartan_Function_Characteristic_Configs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config
                {
                    Function_Characteristic_Config_Id = m.Spartan_Function_Characteristic_Config_Function_Characteristic_Config_Id
                    ,Function_Characteristic_Id = m.Spartan_Function_Characteristic_Config_Function_Characteristic_Id
                    ,Function_Characteristic_Id_Spartan_Function_Characteristic = new Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic() { Function_Characteristic = m.Spartan_Function_Characteristic_Config_Function_Characteristic_Id.GetValueOrDefault(), Description = m.Spartan_Function_Characteristic_Config_Function_Characteristic_Id_Description }
                    ,Numeric_Value = m.Spartan_Function_Characteristic_Config_Numeric_Value
                    ,Text_Value = m.Spartan_Function_Characteristic_Config_Text_Value

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Function_Characteristic_ConfigRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Function_Characteristic_Config_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config>("sp_GetSpartan_Function_Characteristic_Config", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Function_Characteristic_Config_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Function_Characteristic_Config>("sp_DelSpartan_Function_Characteristic_Config", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config entity)
        {
            short rta;
            try
            {

		                var padreFunction_Characteristic_Id = _dataProvider.GetParameter();
                padreFunction_Characteristic_Id.ParameterName = "Function_Characteristic_Id";
                padreFunction_Characteristic_Id.DbType = DbType.Int16;
                if (entity.Function_Characteristic_Id == null)
                    padreFunction_Characteristic_Id.Value = DBNull.Value;
                else
                    padreFunction_Characteristic_Id.Value = entity.Function_Characteristic_Id;

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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Function_Characteristic_Config>("sp_InsSpartan_Function_Characteristic_Config" , padreFunction_Characteristic_Id 
, padreNumeric_Value 
, padreText_Value 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Characteristic_Config_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config entity)
        {
            short rta;
            try
            {

                var padreFunction_Characteristic_Config_Id = _dataProvider.GetParameter();
                padreFunction_Characteristic_Config_Id.ParameterName = "Function_Characteristic_Config_Id";
                padreFunction_Characteristic_Config_Id.DbType = DbType.Int16;
                padreFunction_Characteristic_Config_Id.Value = entity.Function_Characteristic_Config_Id;
                var padreFunction_Characteristic_Id = _dataProvider.GetParameter();
                padreFunction_Characteristic_Id.ParameterName = "Function_Characteristic_Id";
                padreFunction_Characteristic_Id.DbType = DbType.Int16;
                if (entity.Function_Characteristic_Id == null)
                    padreFunction_Characteristic_Id.Value = DBNull.Value;
                else
                    padreFunction_Characteristic_Id.Value = entity.Function_Characteristic_Id;

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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Function_Characteristic_Config>("sp_UpdSpartan_Function_Characteristic_Config" , padreFunction_Characteristic_Config_Id  , padreFunction_Characteristic_Id  , padreNumeric_Value  , padreText_Value  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Characteristic_Config_Id);
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


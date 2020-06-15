using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_History;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_History
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_HistoryService : ISpartan_BR_HistoryService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History> _Spartan_BR_HistoryRepository;
        #endregion

        #region Ctor
        public Spartan_BR_HistoryService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History> Spartan_BR_HistoryRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_HistoryRepository = Spartan_BR_HistoryRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_HistoryRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History>("sp_SelAllSpartan_BR_History");
        }

        public IList<Core.Classes.Spartan_BR_History.Spartan_BR_History> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_History_Complete>("sp_SelAllComplete_Spartan_BR_History");
            return data.Select(m => new Core.Classes.Spartan_BR_History.Spartan_BR_History
            {
                Key_History = m.Key_History
                ,User_logged_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.User_logged.GetValueOrDefault(), Name = m.User_logged_Name }
                ,Status_Spartan_BR_Status = new Core.Classes.Spartan_BR_Status.Spartan_BR_Status() { StatusId = m.Status.GetValueOrDefault(), Description = m.Status_Description }
                ,Change_Date = m.Change_Date
                ,Hour_Date = m.Hour_Date
                ,Time_elapsed = m.Time_elapsed
                ,Change_Type_Spartan_BR_Type_History = new Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History() { Key_Type_History = m.Change_Type.GetValueOrDefault(), Description = m.Change_Type_Description }
                ,Conditions = m.Conditions
                ,Actions_True = m.Actions_True
                ,Actions_False = m.Actions_False
                ,BusinessRule = m.BusinessRule


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_History>("sp_ListSelCount_Spartan_BR_History", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_History>("sp_ListSelAll_Spartan_BR_History", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History
                {
                    Key_History = m.Spartan_BR_History_Key_History,
                    User_logged = m.Spartan_BR_History_User_logged,
                    Status = m.Spartan_BR_History_Status,
                    Change_Date = m.Spartan_BR_History_Change_Date,
                    Hour_Date = m.Spartan_BR_History_Hour_Date,
                    Time_elapsed = m.Spartan_BR_History_Time_elapsed,
                    Change_Type = m.Spartan_BR_History_Change_Type,
                    Conditions = m.Spartan_BR_History_Conditions,
                    Actions_True = m.Spartan_BR_History_Actions_True,
                    Actions_False = m.Spartan_BR_History_Actions_False,
                    BusinessRule = m.Spartan_BR_History_BusinessRule,

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

        public IList<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_HistoryRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_HistoryRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_HistoryPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_History>("sp_ListSelAll_Spartan_BR_History", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_HistoryPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_HistoryPagingModel
                {
                    Spartan_BR_Historys =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History
                {
                    Key_History = m.Spartan_BR_History_Key_History
                    ,User_logged = m.Spartan_BR_History_User_logged
                    ,User_logged_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_BR_History_User_logged.GetValueOrDefault(), Name = m.Spartan_BR_History_User_logged_Name }
                    ,Status = m.Spartan_BR_History_Status
                    ,Status_Spartan_BR_Status = new Core.Classes.Spartan_BR_Status.Spartan_BR_Status() { StatusId = m.Spartan_BR_History_Status.GetValueOrDefault(), Description = m.Spartan_BR_History_Status_Description }
                    ,Change_Date = m.Spartan_BR_History_Change_Date
                    ,Hour_Date = m.Spartan_BR_History_Hour_Date
                    ,Time_elapsed = m.Spartan_BR_History_Time_elapsed
                    ,Change_Type = m.Spartan_BR_History_Change_Type
                    ,Change_Type_Spartan_BR_Type_History = new Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History() { Key_Type_History = m.Spartan_BR_History_Change_Type.GetValueOrDefault(), Description = m.Spartan_BR_History_Change_Type_Description }
                    ,Conditions = m.Spartan_BR_History_Conditions
                    ,Actions_True = m.Spartan_BR_History_Actions_True
                    ,Actions_False = m.Spartan_BR_History_Actions_False
                    ,BusinessRule = m.Spartan_BR_History_BusinessRule

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_HistoryRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Key_History";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History>("sp_GetSpartan_BR_History", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Key_History";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_History>("sp_DelSpartan_BR_History", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result.ToString() == "1";
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History entity)
        {
            int rta;
            try
            {

		var padreKey_History = _dataProvider.GetParameter();
                padreKey_History.ParameterName = "Key_History";
                padreKey_History.DbType = DbType.Int32;
                padreKey_History.Value = (object)entity.Key_History ?? DBNull.Value;
                var padreUser_logged = _dataProvider.GetParameter();
                padreUser_logged.ParameterName = "User_logged";
                padreUser_logged.DbType = DbType.Int32;
                padreUser_logged.Value = (object)entity.User_logged ?? DBNull.Value;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                padreStatus.Value = (object)entity.Status ?? DBNull.Value;

                var padreChange_Date = _dataProvider.GetParameter();
                padreChange_Date.ParameterName = "Change_Date";
                padreChange_Date.DbType = DbType.DateTime;
                padreChange_Date.Value = (object)entity.Change_Date ?? DBNull.Value;

                var padreHour_Date = _dataProvider.GetParameter();
                padreHour_Date.ParameterName = "Hour_Date";
                padreHour_Date.DbType = DbType.String;
                padreHour_Date.Value = (object)entity.Hour_Date ?? DBNull.Value;
                var padreTime_elapsed = _dataProvider.GetParameter();
                padreTime_elapsed.ParameterName = "Time_elapsed";
                padreTime_elapsed.DbType = DbType.Int32;
                padreTime_elapsed.Value = (object)entity.Time_elapsed ?? DBNull.Value;

                var padreChange_Type = _dataProvider.GetParameter();
                padreChange_Type.ParameterName = "Change_Type";
                padreChange_Type.DbType = DbType.Int32;
                padreChange_Type.Value = (object)entity.Change_Type ?? DBNull.Value;

                var padreConditions = _dataProvider.GetParameter();
                padreConditions.ParameterName = "Conditions";
                padreConditions.DbType = DbType.String;
                padreConditions.Value = (object)entity.Conditions ?? DBNull.Value;
                var padreActions_True = _dataProvider.GetParameter();
                padreActions_True.ParameterName = "Actions_True";
                padreActions_True.DbType = DbType.String;
                padreActions_True.Value = (object)entity.Actions_True ?? DBNull.Value;
                var padreActions_False = _dataProvider.GetParameter();
                padreActions_False.ParameterName = "Actions_False";
                padreActions_False.DbType = DbType.String;
                padreActions_False.Value = (object)entity.Actions_False ?? DBNull.Value;
                var padreBusinessRule = _dataProvider.GetParameter();
                padreBusinessRule.ParameterName = "BusinessRule";
                padreBusinessRule.DbType = DbType.Int32;
                padreBusinessRule.Value = (object)entity.BusinessRule ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_History>("sp_InsSpartan_BR_History" 
, padreUser_logged
, padreStatus
, padreChange_Date
, padreHour_Date
, padreTime_elapsed
, padreChange_Type
, padreConditions
, padreActions_True
, padreActions_False
, padreBusinessRule
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Key_History);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History entity)
        {
            int rta;
            try
            {

                var paramUpdKey_History = _dataProvider.GetParameter();
                paramUpdKey_History.ParameterName = "Key_History";
                paramUpdKey_History.DbType = DbType.Int32;
                paramUpdKey_History.Value = (object)entity.Key_History ?? DBNull.Value;
                var paramUpdUser_logged = _dataProvider.GetParameter();
                paramUpdUser_logged.ParameterName = "User_logged";
                paramUpdUser_logged.DbType = DbType.Int32;
                paramUpdUser_logged.Value = (object)entity.User_logged ?? DBNull.Value;

                var paramUpdStatus = _dataProvider.GetParameter();
                paramUpdStatus.ParameterName = "Status";
                paramUpdStatus.DbType = DbType.Int16;
                paramUpdStatus.Value = (object)entity.Status ?? DBNull.Value;

                var paramUpdChange_Date = _dataProvider.GetParameter();
                paramUpdChange_Date.ParameterName = "Change_Date";
                paramUpdChange_Date.DbType = DbType.DateTime;
                paramUpdChange_Date.Value = (object)entity.Change_Date ?? DBNull.Value;

                var paramUpdHour_Date = _dataProvider.GetParameter();
                paramUpdHour_Date.ParameterName = "Hour_Date";
                paramUpdHour_Date.DbType = DbType.String;
                paramUpdHour_Date.Value = (object)entity.Hour_Date ?? DBNull.Value;
                var paramUpdTime_elapsed = _dataProvider.GetParameter();
                paramUpdTime_elapsed.ParameterName = "Time_elapsed";
                paramUpdTime_elapsed.DbType = DbType.Int32;
                paramUpdTime_elapsed.Value = (object)entity.Time_elapsed ?? DBNull.Value;

                var paramUpdChange_Type = _dataProvider.GetParameter();
                paramUpdChange_Type.ParameterName = "Change_Type";
                paramUpdChange_Type.DbType = DbType.Int32;
                paramUpdChange_Type.Value = (object)entity.Change_Type ?? DBNull.Value;

                var paramUpdConditions = _dataProvider.GetParameter();
                paramUpdConditions.ParameterName = "Conditions";
                paramUpdConditions.DbType = DbType.String;
                paramUpdConditions.Value = (object)entity.Conditions ?? DBNull.Value;
                var paramUpdActions_True = _dataProvider.GetParameter();
                paramUpdActions_True.ParameterName = "Actions_True";
                paramUpdActions_True.DbType = DbType.String;
                paramUpdActions_True.Value = (object)entity.Actions_True ?? DBNull.Value;
                var paramUpdActions_False = _dataProvider.GetParameter();
                paramUpdActions_False.ParameterName = "Actions_False";
                paramUpdActions_False.DbType = DbType.String;
                paramUpdActions_False.Value = (object)entity.Actions_False ?? DBNull.Value;
                var paramUpdBusinessRule = _dataProvider.GetParameter();
                paramUpdBusinessRule.ParameterName = "BusinessRule";
                paramUpdBusinessRule.DbType = DbType.Int32;
                paramUpdBusinessRule.Value = (object)entity.BusinessRule ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_History>("sp_UpdSpartan_BR_History" , paramUpdKey_History , paramUpdUser_logged , paramUpdStatus , paramUpdChange_Date , paramUpdHour_Date , paramUpdTime_elapsed , paramUpdChange_Type , paramUpdConditions , paramUpdActions_True , paramUpdActions_False , paramUpdBusinessRule ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Key_History);
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

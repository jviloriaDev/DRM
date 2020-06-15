using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Transaction_Log;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Transaction_Log
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Transaction_LogService : ISpartan_Transaction_LogService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> _Spartan_Transaction_LogRepository;
        #endregion

        #region Ctor
        public Spartan_Transaction_LogService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> Spartan_Transaction_LogRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Transaction_LogRepository = Spartan_Transaction_LogRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Transaction_LogRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log>("sp_SelAllSpartan_Transaction_Log");
        }

        public IList<Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Transaction_Log_Complete>("sp_SelAllComplete_Spartan_Transaction_Log");
            return data.Select(m => new Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log
            {
                Transaction_Log_Id = m.Transaction_Log_Id
                ,Session_Log_Id_Spartan_Session_Log = new Core.Classes.Spartan_Session_Log.Spartan_Session_Log() { Session_Log_Id = m.Session_Log_Id.GetValueOrDefault(), Security_Log_Id = m.Session_Log_Id_Security_Log_Id }
                ,Log_Date = m.Log_Date
                ,Module_Id_Spartan_Module = new Core.Classes.Spartan_Module.Spartan_Module() { Module_Id = m.Module_Id.GetValueOrDefault(), Name = m.Module_Id_Name }
                ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object_Id.GetValueOrDefault(), Name = m.Object_Id_Name }
                ,Function_Id_Spartan_Transition_Log_Type = new Core.Classes.Spartan_Transition_Log_Type.Spartan_Transition_Log_Type() { Transaction_Log_Type_Id = m.Function_Id.GetValueOrDefault(), Description = m.Function_Id_Description }
                ,Log_Type_Id_Spartan_Transition_Event_Type = new Core.Classes.Spartan_Transition_Event_Type.Spartan_Transition_Event_Type() { Transition_Event_Type_Id = m.Log_Type_Id.GetValueOrDefault(), Description = m.Log_Type_Id_Description }
                ,Event_Type_Id_Spartan_Transition_Log_Type = new Core.Classes.Spartan_Transition_Log_Type.Spartan_Transition_Log_Type() { Transaction_Log_Type_Id = m.Event_Type_Id.GetValueOrDefault(), Description = m.Event_Type_Id_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Transaction_Log>("sp_ListSelCount_Spartan_Transaction_Log", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Transaction_Log>("sp_ListSelAll_Spartan_Transaction_Log", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log
                {
                    Transaction_Log_Id = m.Spartan_Transaction_Log_Transaction_Log_Id,
                    Session_Log_Id = m.Spartan_Transaction_Log_Session_Log_Id,
                    Log_Date = m.Spartan_Transaction_Log_Log_Date,
                    Module_Id = m.Spartan_Transaction_Log_Module_Id,
                    Object_Id = m.Spartan_Transaction_Log_Object_Id,
                    Function_Id = m.Spartan_Transaction_Log_Function_Id,
                    Log_Type_Id = m.Spartan_Transaction_Log_Log_Type_Id,
                    Event_Type_Id = m.Spartan_Transaction_Log_Event_Type_Id,

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

        public IList<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Transaction_LogRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Transaction_LogRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_LogPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Transaction_Log>("sp_ListSelAll_Spartan_Transaction_Log", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Transaction_LogPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Transaction_LogPagingModel
                {
                    Spartan_Transaction_Logs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log
                {
                    Transaction_Log_Id = m.Spartan_Transaction_Log_Transaction_Log_Id
                    ,Session_Log_Id = m.Spartan_Transaction_Log_Session_Log_Id
                    ,Session_Log_Id_Spartan_Session_Log = new Core.Classes.Spartan_Session_Log.Spartan_Session_Log() { Session_Log_Id = m.Spartan_Transaction_Log_Session_Log_Id.GetValueOrDefault(), Security_Log_Id = m.Spartan_Transaction_Log_Session_Log_Id_Security_Log_Id }
                    ,Log_Date = m.Spartan_Transaction_Log_Log_Date
                    ,Module_Id = m.Spartan_Transaction_Log_Module_Id
                    ,Module_Id_Spartan_Module = new Core.Classes.Spartan_Module.Spartan_Module() { Module_Id = m.Spartan_Transaction_Log_Module_Id.GetValueOrDefault(), Name = m.Spartan_Transaction_Log_Module_Id_Name }
                    ,Object_Id = m.Spartan_Transaction_Log_Object_Id
                    ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Transaction_Log_Object_Id.GetValueOrDefault(), Name = m.Spartan_Transaction_Log_Object_Id_Name }
                    ,Function_Id = m.Spartan_Transaction_Log_Function_Id
                    ,Function_Id_Spartan_Transition_Log_Type = new Core.Classes.Spartan_Transition_Log_Type.Spartan_Transition_Log_Type() { Transaction_Log_Type_Id = m.Spartan_Transaction_Log_Function_Id.GetValueOrDefault(), Description = m.Spartan_Transaction_Log_Function_Id_Description }
                    ,Log_Type_Id = m.Spartan_Transaction_Log_Log_Type_Id
                    ,Log_Type_Id_Spartan_Transition_Event_Type = new Core.Classes.Spartan_Transition_Event_Type.Spartan_Transition_Event_Type() { Transition_Event_Type_Id = m.Spartan_Transaction_Log_Log_Type_Id.GetValueOrDefault(), Description = m.Spartan_Transaction_Log_Log_Type_Id_Description }
                    ,Event_Type_Id = m.Spartan_Transaction_Log_Event_Type_Id
                    ,Event_Type_Id_Spartan_Transition_Log_Type = new Core.Classes.Spartan_Transition_Log_Type.Spartan_Transition_Log_Type() { Transaction_Log_Type_Id = m.Spartan_Transaction_Log_Event_Type_Id.GetValueOrDefault(), Description = m.Spartan_Transaction_Log_Event_Type_Id_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Transaction_LogRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Transaction_Log_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log>("sp_GetSpartan_Transaction_Log", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Transaction_Log_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Transaction_Log>("sp_DelSpartan_Transaction_Log", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log entity)
        {
            int rta;
            try
            {

		                var padreSession_Log_Id = _dataProvider.GetParameter();
                padreSession_Log_Id.ParameterName = "Session_Log_Id";
                padreSession_Log_Id.DbType = DbType.Int32;
                if (entity.Session_Log_Id == null)
                    padreSession_Log_Id.Value = DBNull.Value;
                else
                    padreSession_Log_Id.Value = entity.Session_Log_Id;

                var padreLog_Date = _dataProvider.GetParameter();
                padreLog_Date.ParameterName = "Log_Date";
                padreLog_Date.DbType = DbType.DateTime;
                if (entity.Log_Date == null)
                    padreLog_Date.Value = DBNull.Value;
                else
                    padreLog_Date.Value = entity.Log_Date;

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

                var padreFunction_Id = _dataProvider.GetParameter();
                padreFunction_Id.ParameterName = "Function_Id";
                padreFunction_Id.DbType = DbType.Int16;
                if (entity.Function_Id == null)
                    padreFunction_Id.Value = DBNull.Value;
                else
                    padreFunction_Id.Value = entity.Function_Id;

                var padreLog_Type_Id = _dataProvider.GetParameter();
                padreLog_Type_Id.ParameterName = "Log_Type_Id";
                padreLog_Type_Id.DbType = DbType.Int32;
                if (entity.Log_Type_Id == null)
                    padreLog_Type_Id.Value = DBNull.Value;
                else
                    padreLog_Type_Id.Value = entity.Log_Type_Id;

                var padreEvent_Type_Id = _dataProvider.GetParameter();
                padreEvent_Type_Id.ParameterName = "Event_Type_Id";
                padreEvent_Type_Id.DbType = DbType.Int16;
                if (entity.Event_Type_Id == null)
                    padreEvent_Type_Id.Value = DBNull.Value;
                else
                    padreEvent_Type_Id.Value = entity.Event_Type_Id;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Transaction_Log>("sp_InsSpartan_Transaction_Log" , padreSession_Log_Id 
, padreLog_Date 
, padreModule_Id 
, padreObject_Id 
, padreFunction_Id 
, padreLog_Type_Id 
, padreEvent_Type_Id 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Transaction_Log_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log entity)
        {
            int rta;
            try
            {

                var padreTransaction_Log_Id = _dataProvider.GetParameter();
                padreTransaction_Log_Id.ParameterName = "Transaction_Log_Id";
                padreTransaction_Log_Id.DbType = DbType.Int32;
                padreTransaction_Log_Id.Value = entity.Transaction_Log_Id;
                var padreSession_Log_Id = _dataProvider.GetParameter();
                padreSession_Log_Id.ParameterName = "Session_Log_Id";
                padreSession_Log_Id.DbType = DbType.Int32;
                if (entity.Session_Log_Id == null)
                    padreSession_Log_Id.Value = DBNull.Value;
                else
                    padreSession_Log_Id.Value = entity.Session_Log_Id;

                var padreLog_Date = _dataProvider.GetParameter();
                padreLog_Date.ParameterName = "Log_Date";
                padreLog_Date.DbType = DbType.DateTime;
                if (entity.Log_Date == null)
                    padreLog_Date.Value = DBNull.Value;
                else
                    padreLog_Date.Value = entity.Log_Date;

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

                var padreFunction_Id = _dataProvider.GetParameter();
                padreFunction_Id.ParameterName = "Function_Id";
                padreFunction_Id.DbType = DbType.Int16;
                if (entity.Function_Id == null)
                    padreFunction_Id.Value = DBNull.Value;
                else
                    padreFunction_Id.Value = entity.Function_Id;

                var padreLog_Type_Id = _dataProvider.GetParameter();
                padreLog_Type_Id.ParameterName = "Log_Type_Id";
                padreLog_Type_Id.DbType = DbType.Int32;
                if (entity.Log_Type_Id == null)
                    padreLog_Type_Id.Value = DBNull.Value;
                else
                    padreLog_Type_Id.Value = entity.Log_Type_Id;

                var padreEvent_Type_Id = _dataProvider.GetParameter();
                padreEvent_Type_Id.ParameterName = "Event_Type_Id";
                padreEvent_Type_Id.DbType = DbType.Int16;
                if (entity.Event_Type_Id == null)
                    padreEvent_Type_Id.Value = DBNull.Value;
                else
                    padreEvent_Type_Id.Value = entity.Event_Type_Id;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Transaction_Log>("sp_UpdSpartan_Transaction_Log" , padreTransaction_Log_Id  , padreSession_Log_Id  , padreLog_Date  , padreModule_Id  , padreObject_Id  , padreFunction_Id  , padreLog_Type_Id  , padreEvent_Type_Id  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Transaction_Log_Id);
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


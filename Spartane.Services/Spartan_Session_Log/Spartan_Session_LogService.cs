using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Session_Log;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Session_Log
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Session_LogService : ISpartan_Session_LogService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> _Spartan_Session_LogRepository;
        #endregion

        #region Ctor
        public Spartan_Session_LogService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> Spartan_Session_LogRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Session_LogRepository = Spartan_Session_LogRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Session_LogRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log>("sp_SelAllSpartan_Session_Log");
        }

        public IList<Core.Classes.Spartan_Session_Log.Spartan_Session_Log> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Session_Log_Complete>("sp_SelAllComplete_Spartan_Session_Log");
            return data.Select(m => new Core.Classes.Spartan_Session_Log.Spartan_Session_Log
            {
                Session_Log_Id = m.Session_Log_Id
                ,Security_Log_Id = m.Security_Log_Id
                ,Log_Date = m.Log_Date
                ,User_Role_Id_Spartan_User_Role = new Core.Classes.Spartan_User_Role.Spartan_User_Role() { User_Role_Id = m.User_Role_Id.GetValueOrDefault(), Description = m.User_Role_Id_Description }
                ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.User_Id.GetValueOrDefault(), Name = m.User_Id_Name }
                ,IP_Address_Source = m.IP_Address_Source
                ,IP_Address_Target = m.IP_Address_Target
                ,Computer_Name = m.Computer_Name
                ,Language_Id_Spartan_System_Language = new Core.Classes.Spartan_System_Language.Spartan_System_Language() { System_Language_Id = m.Language_Id.GetValueOrDefault(), Resource_File = m.Language_Id_Resource_File }
                ,URL = m.URL
                ,Event_Type_Spartan_Security_Event_Type = new Core.Classes.Spartan_Security_Event_Type.Spartan_Security_Event_Type() { Security_Event_Type_Id = m.Event_Type.GetValueOrDefault(), Description = m.Event_Type_Description }
                ,Result_Id_Spartan_Security_Event_Result = new Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result() { Security_Event_Result_Id = m.Result_Id.GetValueOrDefault(), Description = m.Result_Id_Description }
                ,Event_Type2_Spartan_Session_Event_Type = new Core.Classes.Spartan_Session_Event_Type.Spartan_Session_Event_Type() { Session_Event_Type_Id = m.Event_Type2.GetValueOrDefault(), Description = m.Event_Type2_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Session_Log>("sp_ListSelCount_Spartan_Session_Log", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Session_Log>("sp_ListSelAll_Spartan_Session_Log", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log
                {
                    Session_Log_Id = m.Spartan_Session_Log_Session_Log_Id,
                    Security_Log_Id = m.Spartan_Session_Log_Security_Log_Id,
                    Log_Date = m.Spartan_Session_Log_Log_Date,
                    User_Role_Id = m.Spartan_Session_Log_User_Role_Id,
                    User_Id = m.Spartan_Session_Log_User_Id,
                    IP_Address_Source = m.Spartan_Session_Log_IP_Address_Source,
                    IP_Address_Target = m.Spartan_Session_Log_IP_Address_Target,
                    Computer_Name = m.Spartan_Session_Log_Computer_Name,
                    Language_Id = m.Spartan_Session_Log_Language_Id,
                    URL = m.Spartan_Session_Log_URL,
                    Event_Type = m.Spartan_Session_Log_Event_Type,
                    Result_Id = m.Spartan_Session_Log_Result_Id,
                    Event_Type2 = m.Spartan_Session_Log_Event_Type2,

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

        public IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Session_LogRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Session_LogRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_LogPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Session_Log>("sp_ListSelAll_Spartan_Session_Log", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Session_LogPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Session_LogPagingModel
                {
                    Spartan_Session_Logs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log
                {
                    Session_Log_Id = m.Spartan_Session_Log_Session_Log_Id
                    ,Security_Log_Id = m.Spartan_Session_Log_Security_Log_Id
                    ,Log_Date = m.Spartan_Session_Log_Log_Date
                    ,User_Role_Id = m.Spartan_Session_Log_User_Role_Id
                    ,User_Role_Id_Spartan_User_Role = new Core.Classes.Spartan_User_Role.Spartan_User_Role() { User_Role_Id = m.Spartan_Session_Log_User_Role_Id.GetValueOrDefault(), Description = m.Spartan_Session_Log_User_Role_Id_Description }
                    ,User_Id = m.Spartan_Session_Log_User_Id
                    ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_Session_Log_User_Id.GetValueOrDefault(), Name = m.Spartan_Session_Log_User_Id_Name }
                    ,IP_Address_Source = m.Spartan_Session_Log_IP_Address_Source
                    ,IP_Address_Target = m.Spartan_Session_Log_IP_Address_Target
                    ,Computer_Name = m.Spartan_Session_Log_Computer_Name
                    ,Language_Id = m.Spartan_Session_Log_Language_Id
                    ,Language_Id_Spartan_System_Language = new Core.Classes.Spartan_System_Language.Spartan_System_Language() { System_Language_Id = m.Spartan_Session_Log_Language_Id.GetValueOrDefault(), Resource_File = m.Spartan_Session_Log_Language_Id_Resource_File }
                    ,URL = m.Spartan_Session_Log_URL
                    ,Event_Type = m.Spartan_Session_Log_Event_Type
                    ,Event_Type_Spartan_Security_Event_Type = new Core.Classes.Spartan_Security_Event_Type.Spartan_Security_Event_Type() { Security_Event_Type_Id = m.Spartan_Session_Log_Event_Type.GetValueOrDefault(), Description = m.Spartan_Session_Log_Event_Type_Description }
                    ,Result_Id = m.Spartan_Session_Log_Result_Id
                    ,Result_Id_Spartan_Security_Event_Result = new Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result() { Security_Event_Result_Id = m.Spartan_Session_Log_Result_Id.GetValueOrDefault(), Description = m.Spartan_Session_Log_Result_Id_Description }
                    ,Event_Type2 = m.Spartan_Session_Log_Event_Type2
                    ,Event_Type2_Spartan_Session_Event_Type = new Core.Classes.Spartan_Session_Event_Type.Spartan_Session_Event_Type() { Session_Event_Type_Id = m.Spartan_Session_Log_Event_Type2.GetValueOrDefault(), Description = m.Spartan_Session_Log_Event_Type2_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Session_LogRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Session_Log_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log>("sp_GetSpartan_Session_Log", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Session_Log_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Session_Log>("sp_DelSpartan_Session_Log", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log entity)
        {
            int rta;
            try
            {

		                var padreSecurity_Log_Id = _dataProvider.GetParameter();
                padreSecurity_Log_Id.ParameterName = "Security_Log_Id";
                padreSecurity_Log_Id.DbType = DbType.Int32;
                if (entity.Security_Log_Id == null)
                    padreSecurity_Log_Id.Value = DBNull.Value;
                else
                    padreSecurity_Log_Id.Value = entity.Security_Log_Id;

                var padreLog_Date = _dataProvider.GetParameter();
                padreLog_Date.ParameterName = "Log_Date";
                padreLog_Date.DbType = DbType.DateTime;
                if (entity.Log_Date == null)
                    padreLog_Date.Value = DBNull.Value;
                else
                    padreLog_Date.Value = entity.Log_Date;

                var padreUser_Role_Id = _dataProvider.GetParameter();
                padreUser_Role_Id.ParameterName = "User_Role_Id";
                padreUser_Role_Id.DbType = DbType.Int32;
                if (entity.User_Role_Id == null)
                    padreUser_Role_Id.Value = DBNull.Value;
                else
                    padreUser_Role_Id.Value = entity.User_Role_Id;

                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreIP_Address_Source = _dataProvider.GetParameter();
                padreIP_Address_Source.ParameterName = "IP_Address_Source";
                padreIP_Address_Source.DbType = DbType.String;
                padreIP_Address_Source.Value = entity.IP_Address_Source;
                var padreIP_Address_Target = _dataProvider.GetParameter();
                padreIP_Address_Target.ParameterName = "IP_Address_Target";
                padreIP_Address_Target.DbType = DbType.String;
                padreIP_Address_Target.Value = entity.IP_Address_Target;
                var padreComputer_Name = _dataProvider.GetParameter();
                padreComputer_Name.ParameterName = "Computer_Name";
                padreComputer_Name.DbType = DbType.String;
                padreComputer_Name.Value = entity.Computer_Name;
                var padreLanguage_Id = _dataProvider.GetParameter();
                padreLanguage_Id.ParameterName = "Language_Id";
                padreLanguage_Id.DbType = DbType.Int16;
                if (entity.Language_Id == null)
                    padreLanguage_Id.Value = DBNull.Value;
                else
                    padreLanguage_Id.Value = entity.Language_Id;

                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreEvent_Type = _dataProvider.GetParameter();
                padreEvent_Type.ParameterName = "Event_Type";
                padreEvent_Type.DbType = DbType.Int16;
                if (entity.Event_Type == null)
                    padreEvent_Type.Value = DBNull.Value;
                else
                    padreEvent_Type.Value = entity.Event_Type;

                var padreResult_Id = _dataProvider.GetParameter();
                padreResult_Id.ParameterName = "Result_Id";
                padreResult_Id.DbType = DbType.Int16;
                if (entity.Result_Id == null)
                    padreResult_Id.Value = DBNull.Value;
                else
                    padreResult_Id.Value = entity.Result_Id;

                var padreEvent_Type2 = _dataProvider.GetParameter();
                padreEvent_Type2.ParameterName = "Event_Type2";
                padreEvent_Type2.DbType = DbType.Int16;
                if (entity.Event_Type2 == null)
                    padreEvent_Type2.Value = DBNull.Value;
                else
                    padreEvent_Type2.Value = entity.Event_Type2;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Session_Log>("sp_InsSpartan_Session_Log" , padreSecurity_Log_Id 
, padreLog_Date 
, padreUser_Role_Id 
, padreUser_Id 
, padreIP_Address_Source 
, padreIP_Address_Target 
, padreComputer_Name 
, padreLanguage_Id 
, padreURL 
, padreEvent_Type 
, padreResult_Id 
, padreEvent_Type2 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Session_Log_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log entity)
        {
            int rta;
            try
            {

                var padreSession_Log_Id = _dataProvider.GetParameter();
                padreSession_Log_Id.ParameterName = "Session_Log_Id";
                padreSession_Log_Id.DbType = DbType.Int32;
                padreSession_Log_Id.Value = entity.Session_Log_Id;
                var padreSecurity_Log_Id = _dataProvider.GetParameter();
                padreSecurity_Log_Id.ParameterName = "Security_Log_Id";
                padreSecurity_Log_Id.DbType = DbType.Int32;
                if (entity.Security_Log_Id == null)
                    padreSecurity_Log_Id.Value = DBNull.Value;
                else
                    padreSecurity_Log_Id.Value = entity.Security_Log_Id;

                var padreLog_Date = _dataProvider.GetParameter();
                padreLog_Date.ParameterName = "Log_Date";
                padreLog_Date.DbType = DbType.DateTime;
                if (entity.Log_Date == null)
                    padreLog_Date.Value = DBNull.Value;
                else
                    padreLog_Date.Value = entity.Log_Date;

                var padreUser_Role_Id = _dataProvider.GetParameter();
                padreUser_Role_Id.ParameterName = "User_Role_Id";
                padreUser_Role_Id.DbType = DbType.Int32;
                if (entity.User_Role_Id == null)
                    padreUser_Role_Id.Value = DBNull.Value;
                else
                    padreUser_Role_Id.Value = entity.User_Role_Id;

                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreIP_Address_Source = _dataProvider.GetParameter();
                padreIP_Address_Source.ParameterName = "IP_Address_Source";
                padreIP_Address_Source.DbType = DbType.String;
                padreIP_Address_Source.Value = entity.IP_Address_Source;
                var padreIP_Address_Target = _dataProvider.GetParameter();
                padreIP_Address_Target.ParameterName = "IP_Address_Target";
                padreIP_Address_Target.DbType = DbType.String;
                padreIP_Address_Target.Value = entity.IP_Address_Target;
                var padreComputer_Name = _dataProvider.GetParameter();
                padreComputer_Name.ParameterName = "Computer_Name";
                padreComputer_Name.DbType = DbType.String;
                padreComputer_Name.Value = entity.Computer_Name;
                var padreLanguage_Id = _dataProvider.GetParameter();
                padreLanguage_Id.ParameterName = "Language_Id";
                padreLanguage_Id.DbType = DbType.Int16;
                if (entity.Language_Id == null)
                    padreLanguage_Id.Value = DBNull.Value;
                else
                    padreLanguage_Id.Value = entity.Language_Id;

                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreEvent_Type = _dataProvider.GetParameter();
                padreEvent_Type.ParameterName = "Event_Type";
                padreEvent_Type.DbType = DbType.Int16;
                if (entity.Event_Type == null)
                    padreEvent_Type.Value = DBNull.Value;
                else
                    padreEvent_Type.Value = entity.Event_Type;

                var padreResult_Id = _dataProvider.GetParameter();
                padreResult_Id.ParameterName = "Result_Id";
                padreResult_Id.DbType = DbType.Int16;
                if (entity.Result_Id == null)
                    padreResult_Id.Value = DBNull.Value;
                else
                    padreResult_Id.Value = entity.Result_Id;

                var padreEvent_Type2 = _dataProvider.GetParameter();
                padreEvent_Type2.ParameterName = "Event_Type2";
                padreEvent_Type2.DbType = DbType.Int16;
                if (entity.Event_Type2 == null)
                    padreEvent_Type2.Value = DBNull.Value;
                else
                    padreEvent_Type2.Value = entity.Event_Type2;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Session_Log>("sp_UpdSpartan_Session_Log" , padreSession_Log_Id  , padreSecurity_Log_Id  , padreLog_Date  , padreUser_Role_Id  , padreUser_Id  , padreIP_Address_Source  , padreIP_Address_Target  , padreComputer_Name  , padreLanguage_Id  , padreURL  , padreEvent_Type  , padreResult_Id  , padreEvent_Type2  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Session_Log_Id);
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


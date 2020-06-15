using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Bitacora_SQL;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Bitacora_SQL
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Bitacora_SQLService : ISpartan_Bitacora_SQLService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> _Spartan_Bitacora_SQLRepository;
        #endregion

        #region Ctor
        public Spartan_Bitacora_SQLService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> Spartan_Bitacora_SQLRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Bitacora_SQLRepository = Spartan_Bitacora_SQLRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Bitacora_SQLRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>("sp_SelAllSpartan_Bitacora_SQL");
        }

        public IList<Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Bitacora_SQL_Complete>("sp_SelAllComplete_Spartan_Bitacora_SQL");
            return data.Select(m => new Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL
            {
                Folio = m.Folio
                ,Id_User = m.Id_User
                ,Type_SQL = m.Type_SQL
                ,Register_Date = m.Register_Date
                ,Computer_Name = m.Computer_Name
                ,Server_Name = m.Server_Name
                ,Database_Name = m.Database_Name
                ,System_Name = m.System_Name
                ,System_Version = m.System_Version
                ,Windows_Version = m.Windows_Version
                ,Command_SQL = m.Command_SQL
                ,Folio_SQL = m.Folio_SQL
                ,Object_Id = m.Object_Id
                ,IP = m.IP
                ,Json = m.Json
                ,Result = m.Result.GetValueOrDefault()
                ,Error = m.Error


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Bitacora_SQL>("sp_ListSelCount_Spartan_Bitacora_SQL", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Bitacora_SQL>("sp_ListSelAll_Spartan_Bitacora_SQL", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL
                {
                    Folio = m.Spartan_Bitacora_SQL_Folio,
                    Id_User = m.Spartan_Bitacora_SQL_Id_User,
                    Type_SQL = m.Spartan_Bitacora_SQL_Type_SQL,
                    Register_Date = m.Spartan_Bitacora_SQL_Register_Date,
                    Computer_Name = m.Spartan_Bitacora_SQL_Computer_Name,
                    Server_Name = m.Spartan_Bitacora_SQL_Server_Name,
                    Database_Name = m.Spartan_Bitacora_SQL_Database_Name,
                    System_Name = m.Spartan_Bitacora_SQL_System_Name,
                    System_Version = m.Spartan_Bitacora_SQL_System_Version,
                    Windows_Version = m.Spartan_Bitacora_SQL_Windows_Version,
                    Command_SQL = m.Spartan_Bitacora_SQL_Command_SQL,
                    Folio_SQL = m.Spartan_Bitacora_SQL_Folio_SQL,
                    Object_Id = m.Spartan_Bitacora_SQL_Object_Id,
                    IP = m.Spartan_Bitacora_SQL_IP,
                    Json = m.Spartan_Bitacora_SQL_Json,
                    Result = m.Spartan_Bitacora_SQL_Result ?? false,
                    Error = m.Spartan_Bitacora_SQL_Error,

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

        public IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Bitacora_SQL>("sp_ListSelAll_Spartan_Bitacora_SQL", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Bitacora_SQLPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Bitacora_SQLPagingModel
                {
                    Spartan_Bitacora_SQLs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL
                {
                    Folio = m.Spartan_Bitacora_SQL_Folio
                    ,Id_User = m.Spartan_Bitacora_SQL_Id_User
                    ,Type_SQL = m.Spartan_Bitacora_SQL_Type_SQL
                    ,Register_Date = m.Spartan_Bitacora_SQL_Register_Date
                    ,Computer_Name = m.Spartan_Bitacora_SQL_Computer_Name
                    ,Server_Name = m.Spartan_Bitacora_SQL_Server_Name
                    ,Database_Name = m.Spartan_Bitacora_SQL_Database_Name
                    ,System_Name = m.Spartan_Bitacora_SQL_System_Name
                    ,System_Version = m.Spartan_Bitacora_SQL_System_Version
                    ,Windows_Version = m.Spartan_Bitacora_SQL_Windows_Version
                    ,Command_SQL = m.Spartan_Bitacora_SQL_Command_SQL
                    ,Folio_SQL = m.Spartan_Bitacora_SQL_Folio_SQL
                    ,Object_Id = m.Spartan_Bitacora_SQL_Object_Id
                    ,IP = m.Spartan_Bitacora_SQL_IP
                    ,Json = m.Spartan_Bitacora_SQL_Json
                    ,Result = m.Spartan_Bitacora_SQL_Result ?? false
                    ,Error = m.Spartan_Bitacora_SQL_Error

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>("sp_GetSpartan_Bitacora_SQL", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Bitacora_SQL>("sp_DelSpartan_Bitacora_SQL", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity)
        {
            int rta;
            try
            {

		                var padreId_User = _dataProvider.GetParameter();
                padreId_User.ParameterName = "Id_User";
                padreId_User.DbType = DbType.Int32;
                padreId_User.Value = (object)entity.Id_User ?? DBNull.Value;

                var padreType_SQL = _dataProvider.GetParameter();
                padreType_SQL.ParameterName = "Type_SQL";
                padreType_SQL.DbType = DbType.String;
                padreType_SQL.Value = (object)entity.Type_SQL ?? DBNull.Value;
                var padreRegister_Date = _dataProvider.GetParameter();
                padreRegister_Date.ParameterName = "Register_Date";
                padreRegister_Date.DbType = DbType.DateTime;
                padreRegister_Date.Value = (object)entity.Register_Date ?? DBNull.Value;

                var padreComputer_Name = _dataProvider.GetParameter();
                padreComputer_Name.ParameterName = "Computer_Name";
                padreComputer_Name.DbType = DbType.String;
                padreComputer_Name.Value = (object)entity.Computer_Name ?? DBNull.Value;
                var padreServer_Name = _dataProvider.GetParameter();
                padreServer_Name.ParameterName = "Server_Name";
                padreServer_Name.DbType = DbType.String;
                padreServer_Name.Value = (object)entity.Server_Name ?? DBNull.Value;
                var padreDatabase_Name = _dataProvider.GetParameter();
                padreDatabase_Name.ParameterName = "Database_Name";
                padreDatabase_Name.DbType = DbType.String;
                padreDatabase_Name.Value = (object)entity.Database_Name ?? DBNull.Value;
                var padreSystem_Name = _dataProvider.GetParameter();
                padreSystem_Name.ParameterName = "System_Name";
                padreSystem_Name.DbType = DbType.String;
                padreSystem_Name.Value = (object)entity.System_Name ?? DBNull.Value;
                var padreSystem_Version = _dataProvider.GetParameter();
                padreSystem_Version.ParameterName = "System_Version";
                padreSystem_Version.DbType = DbType.String;
                padreSystem_Version.Value = (object)entity.System_Version ?? DBNull.Value;
                var padreWindows_Version = _dataProvider.GetParameter();
                padreWindows_Version.ParameterName = "Windows_Version";
                padreWindows_Version.DbType = DbType.String;
                padreWindows_Version.Value = (object)entity.Windows_Version ?? DBNull.Value;
                var padreCommand_SQL = _dataProvider.GetParameter();
                padreCommand_SQL.ParameterName = "Command_SQL";
                padreCommand_SQL.DbType = DbType.String;
                padreCommand_SQL.Value = (object)entity.Command_SQL ?? DBNull.Value;
                var padreFolio_SQL = _dataProvider.GetParameter();
                padreFolio_SQL.ParameterName = "Folio_SQL";
                padreFolio_SQL.DbType = DbType.String;
                padreFolio_SQL.Value = (object)entity.Folio_SQL ?? DBNull.Value;
                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                padreObject_Id.Value = (object)entity.Object_Id ?? DBNull.Value;

                var padreIP = _dataProvider.GetParameter();
                padreIP.ParameterName = "IP";
                padreIP.DbType = DbType.String;
                padreIP.Value = (object)entity.IP ?? DBNull.Value;
                var padreJson = _dataProvider.GetParameter();
                padreJson.ParameterName = "Json";
                padreJson.DbType = DbType.String;
                padreJson.Value = (object)entity.Json ?? DBNull.Value;
                var padreResult = _dataProvider.GetParameter();
                padreResult.ParameterName = "Result";
                padreResult.DbType = DbType.Boolean;
                padreResult.Value = (object)entity.Result ?? DBNull.Value;
                var padreError = _dataProvider.GetParameter();
                padreError.ParameterName = "Error";
                padreError.DbType = DbType.String;
                padreError.Value = (object)entity.Error ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Bitacora_SQL>("sp_InsSpartan_Bitacora_SQL" 
, padreId_User
, padreType_SQL
, padreRegister_Date
, padreComputer_Name
, padreServer_Name
, padreDatabase_Name
, padreSystem_Name
, padreSystem_Version
, padreWindows_Version
, padreCommand_SQL
, padreFolio_SQL
, padreObject_Id
, padreIP
, padreJson
, padreResult
, padreError
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

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

        public int Update(Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdId_User = _dataProvider.GetParameter();
                paramUpdId_User.ParameterName = "Id_User";
                paramUpdId_User.DbType = DbType.Int32;
                paramUpdId_User.Value = (object)entity.Id_User ?? DBNull.Value;

                var paramUpdType_SQL = _dataProvider.GetParameter();
                paramUpdType_SQL.ParameterName = "Type_SQL";
                paramUpdType_SQL.DbType = DbType.String;
                paramUpdType_SQL.Value = (object)entity.Type_SQL ?? DBNull.Value;
                var paramUpdRegister_Date = _dataProvider.GetParameter();
                paramUpdRegister_Date.ParameterName = "Register_Date";
                paramUpdRegister_Date.DbType = DbType.DateTime;
                paramUpdRegister_Date.Value = (object)entity.Register_Date ?? DBNull.Value;

                var paramUpdComputer_Name = _dataProvider.GetParameter();
                paramUpdComputer_Name.ParameterName = "Computer_Name";
                paramUpdComputer_Name.DbType = DbType.String;
                paramUpdComputer_Name.Value = (object)entity.Computer_Name ?? DBNull.Value;
                var paramUpdServer_Name = _dataProvider.GetParameter();
                paramUpdServer_Name.ParameterName = "Server_Name";
                paramUpdServer_Name.DbType = DbType.String;
                paramUpdServer_Name.Value = (object)entity.Server_Name ?? DBNull.Value;
                var paramUpdDatabase_Name = _dataProvider.GetParameter();
                paramUpdDatabase_Name.ParameterName = "Database_Name";
                paramUpdDatabase_Name.DbType = DbType.String;
                paramUpdDatabase_Name.Value = (object)entity.Database_Name ?? DBNull.Value;
                var paramUpdSystem_Name = _dataProvider.GetParameter();
                paramUpdSystem_Name.ParameterName = "System_Name";
                paramUpdSystem_Name.DbType = DbType.String;
                paramUpdSystem_Name.Value = (object)entity.System_Name ?? DBNull.Value;
                var paramUpdSystem_Version = _dataProvider.GetParameter();
                paramUpdSystem_Version.ParameterName = "System_Version";
                paramUpdSystem_Version.DbType = DbType.String;
                paramUpdSystem_Version.Value = (object)entity.System_Version ?? DBNull.Value;
                var paramUpdWindows_Version = _dataProvider.GetParameter();
                paramUpdWindows_Version.ParameterName = "Windows_Version";
                paramUpdWindows_Version.DbType = DbType.String;
                paramUpdWindows_Version.Value = (object)entity.Windows_Version ?? DBNull.Value;
                var paramUpdCommand_SQL = _dataProvider.GetParameter();
                paramUpdCommand_SQL.ParameterName = "Command_SQL";
                paramUpdCommand_SQL.DbType = DbType.String;
                paramUpdCommand_SQL.Value = (object)entity.Command_SQL ?? DBNull.Value;
                var paramUpdFolio_SQL = _dataProvider.GetParameter();
                paramUpdFolio_SQL.ParameterName = "Folio_SQL";
                paramUpdFolio_SQL.DbType = DbType.String;
                paramUpdFolio_SQL.Value = (object)entity.Folio_SQL ?? DBNull.Value;
                var paramUpdObject_Id = _dataProvider.GetParameter();
                paramUpdObject_Id.ParameterName = "Object_Id";
                paramUpdObject_Id.DbType = DbType.Int32;
                paramUpdObject_Id.Value = (object)entity.Object_Id ?? DBNull.Value;

                var paramUpdIP = _dataProvider.GetParameter();
                paramUpdIP.ParameterName = "IP";
                paramUpdIP.DbType = DbType.String;
                paramUpdIP.Value = (object)entity.IP ?? DBNull.Value;
                var paramUpdJson = _dataProvider.GetParameter();
                paramUpdJson.ParameterName = "Json";
                paramUpdJson.DbType = DbType.String;
                paramUpdJson.Value = (object)entity.Json ?? DBNull.Value;
                var paramUpdResult = _dataProvider.GetParameter();
                paramUpdResult.ParameterName = "Result";
                paramUpdResult.DbType = DbType.Boolean;
                paramUpdResult.Value = (object)entity.Result ?? DBNull.Value;
                var paramUpdError = _dataProvider.GetParameter();
                paramUpdError.ParameterName = "Error";
                paramUpdError.DbType = DbType.String;
                paramUpdError.Value = (object)entity.Error ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Bitacora_SQL>("sp_UpdSpartan_Bitacora_SQL" , paramUpdFolio , paramUpdId_User , paramUpdType_SQL , paramUpdRegister_Date , paramUpdComputer_Name , paramUpdServer_Name , paramUpdDatabase_Name , paramUpdSystem_Name , paramUpdSystem_Version , paramUpdWindows_Version , paramUpdCommand_SQL , paramUpdFolio_SQL , paramUpdObject_Id , paramUpdIP , paramUpdJson , paramUpdResult , paramUpdError ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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

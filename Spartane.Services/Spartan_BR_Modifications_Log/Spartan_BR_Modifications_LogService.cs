using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Modifications_Log;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Modifications_Log
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Modifications_LogService : ISpartan_BR_Modifications_LogService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> _Spartan_BR_Modifications_LogRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Modifications_LogService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> Spartan_BR_Modifications_LogRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Modifications_LogRepository = Spartan_BR_Modifications_LogRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>("sp_SelAllSpartan_BR_Modifications_Log");
        }

        public IList<Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Modifications_Log_Complete>("sp_SelAllComplete_Spartan_BR_Modifications_Log");
            return data.Select(m => new Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log
            {
                ModificationId = m.ModificationId
                ,Business_Rule = m.Business_Rule
                ,Modification_Date = m.Modification_Date
                ,Modification_Hour = m.Modification_Hour
                ,Modification_User = m.Modification_User
                ,Comments = m.Comments
                ,Implementation_Code = m.Implementation_Code


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Modifications_Log>("sp_ListSelCount_Spartan_BR_Modifications_Log", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Modifications_Log>("sp_ListSelAll_Spartan_BR_Modifications_Log", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log
                {
                    ModificationId = m.Spartan_BR_Modifications_Log_ModificationId,
                    Business_Rule = m.Spartan_BR_Modifications_Log_Business_Rule,
                    Modification_Date = m.Spartan_BR_Modifications_Log_Modification_Date,
                    Modification_Hour = m.Spartan_BR_Modifications_Log_Modification_Hour,
                    Modification_User = m.Spartan_BR_Modifications_Log_Modification_User,
                    Comments = m.Spartan_BR_Modifications_Log_Comments,
                    Implementation_Code = m.Spartan_BR_Modifications_Log_Implementation_Code,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_LogPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Modifications_Log>("sp_ListSelAll_Spartan_BR_Modifications_Log", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Modifications_LogPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Modifications_LogPagingModel
                {
                    Spartan_BR_Modifications_Logs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log
                {
                    ModificationId = m.Spartan_BR_Modifications_Log_ModificationId
                    ,Business_Rule = m.Spartan_BR_Modifications_Log_Business_Rule
                    ,Modification_Date = m.Spartan_BR_Modifications_Log_Modification_Date
                    ,Modification_Hour = m.Spartan_BR_Modifications_Log_Modification_Hour
                    ,Modification_User = m.Spartan_BR_Modifications_Log_Modification_User
                    ,Comments = m.Spartan_BR_Modifications_Log_Comments
                    ,Implementation_Code = m.Spartan_BR_Modifications_Log_Implementation_Code

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ModificationId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>("sp_GetSpartan_BR_Modifications_Log", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ModificationId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Modifications_Log>("sp_DelSpartan_BR_Modifications_Log", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity)
        {
            int rta;
            try
            {

		                var padreBusiness_Rule = _dataProvider.GetParameter();
                padreBusiness_Rule.ParameterName = "Business_Rule";
                padreBusiness_Rule.DbType = DbType.Int32;
                padreBusiness_Rule.Value = (object)entity.Business_Rule ?? DBNull.Value;
                var padreModification_Date = _dataProvider.GetParameter();
                padreModification_Date.ParameterName = "Modification_Date";
                padreModification_Date.DbType = DbType.DateTime;
                padreModification_Date.Value = (object)entity.Modification_Date ?? DBNull.Value;

                var padreModification_Hour = _dataProvider.GetParameter();
                padreModification_Hour.ParameterName = "Modification_Hour";
                padreModification_Hour.DbType = DbType.String;
                padreModification_Hour.Value = (object)entity.Modification_Hour ?? DBNull.Value;
                var padreModification_User = _dataProvider.GetParameter();
                padreModification_User.ParameterName = "Modification_User";
                padreModification_User.DbType = DbType.Int32;
                padreModification_User.Value = (object)entity.Modification_User ?? DBNull.Value;

                var padreComments = _dataProvider.GetParameter();
                padreComments.ParameterName = "Comments";
                padreComments.DbType = DbType.String;
                padreComments.Value = (object)entity.Comments ?? DBNull.Value;
                var padreImplementation_Code = _dataProvider.GetParameter();
                padreImplementation_Code.ParameterName = "Implementation_Code";
                padreImplementation_Code.DbType = DbType.String;
                padreImplementation_Code.Value = (object)entity.Implementation_Code ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Modifications_Log>("sp_InsSpartan_BR_Modifications_Log" , padreBusiness_Rule
, padreModification_Date
, padreModification_Hour
, padreModification_User
, padreComments
, padreImplementation_Code
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ModificationId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity)
        {
            int rta;
            try
            {

                var paramUpdModificationId = _dataProvider.GetParameter();
                paramUpdModificationId.ParameterName = "ModificationId";
                paramUpdModificationId.DbType = DbType.Int32;
                paramUpdModificationId.Value = entity.ModificationId;
                var paramUpdBusiness_Rule = _dataProvider.GetParameter();
                paramUpdBusiness_Rule.ParameterName = "Business_Rule";
                paramUpdBusiness_Rule.DbType = DbType.Int32;
                paramUpdBusiness_Rule.Value = entity.Business_Rule;
                var paramUpdModification_Date = _dataProvider.GetParameter();
                paramUpdModification_Date.ParameterName = "Modification_Date";
                paramUpdModification_Date.DbType = DbType.DateTime;
                if (entity.Modification_Date == null)
                    paramUpdModification_Date.Value = DBNull.Value;
                else
                    paramUpdModification_Date.Value = entity.Modification_Date;

                var paramUpdModification_Hour = _dataProvider.GetParameter();
                paramUpdModification_Hour.ParameterName = "Modification_Hour";
                paramUpdModification_Hour.DbType = DbType.String;
                paramUpdModification_Hour.Value = entity.Modification_Hour;
                var paramUpdModification_User = _dataProvider.GetParameter();
                paramUpdModification_User.ParameterName = "Modification_User";
                paramUpdModification_User.DbType = DbType.Int32;
                if (entity.Modification_User == null)
                    paramUpdModification_User.Value = DBNull.Value;
                else
                    paramUpdModification_User.Value = entity.Modification_User;

                var paramUpdComments = _dataProvider.GetParameter();
                paramUpdComments.ParameterName = "Comments";
                paramUpdComments.DbType = DbType.String;
                paramUpdComments.Value = entity.Comments;
                var paramUpdImplementation_Code = _dataProvider.GetParameter();
                paramUpdImplementation_Code.ParameterName = "Implementation_Code";
                paramUpdImplementation_Code.DbType = DbType.String;
                paramUpdImplementation_Code.Value = entity.Implementation_Code;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Modifications_Log>("sp_UpdSpartan_BR_Modifications_Log" , paramUpdModificationId , paramUpdBusiness_Rule , paramUpdModification_Date , paramUpdModification_Hour , paramUpdModification_User , paramUpdComments , paramUpdImplementation_Code ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ModificationId);
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


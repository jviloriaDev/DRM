using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Roles_by_State
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Roles_by_StateService : ISpartan_WorkFlow_Roles_by_StateService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> _Spartan_WorkFlow_Roles_by_StateRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Roles_by_StateService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> Spartan_WorkFlow_Roles_by_StateRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Roles_by_StateRepository = Spartan_WorkFlow_Roles_by_StateRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>("sp_SelAllSpartan_WorkFlow_Roles_by_State");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Roles_by_State_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Roles_by_State");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State
            {
                Roles_by_StateId = m.Roles_by_StateId
                ,Spartan_WorkFlow = m.Spartan_WorkFlow
                ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Phase.GetValueOrDefault(), Name = m.Phase_Name }
                ,State_Spartan_WorkFlow_State = new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State() { StateId = m.State.GetValueOrDefault(), Name = m.State_Name }
                ,User_Role = m.User_Role
                ,Phase_Transition = m.Phase_Transition
                ,Permission_To_Consult = m.Permission_To_Consult.GetValueOrDefault()
                ,Permission_To_New = m.Permission_To_New.GetValueOrDefault()
                ,Permission_To_Modify = m.Permission_To_Modify.GetValueOrDefault()
                ,Permission_to_Delete = m.Permission_to_Delete.GetValueOrDefault()
                ,Permission_To_Export = m.Permission_To_Export.GetValueOrDefault()
                ,Permission_To_Print = m.Permission_To_Print.GetValueOrDefault()
                ,Permission_Settings = m.Permission_Settings.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Roles_by_State>("sp_ListSelCount_Spartan_WorkFlow_Roles_by_State", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Roles_by_State>("sp_ListSelAll_Spartan_WorkFlow_Roles_by_State", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State
                {
                    Spartan_WorkFlow = m.Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow,
                    Roles_by_StateId = m.Spartan_WorkFlow_Roles_by_State_Roles_by_StateId,
                    Phase = m.Spartan_WorkFlow_Roles_by_State_Phase,
                    State = m.Spartan_WorkFlow_Roles_by_State_State,
                    User_Role = m.Spartan_WorkFlow_Roles_by_State_User_Role,
                    Phase_Transition = m.Spartan_WorkFlow_Roles_by_State_Phase_Transition,
                    Permission_To_Consult = m.Spartan_WorkFlow_Roles_by_State_Permission_To_Consult ?? false,
                    Permission_To_New = m.Spartan_WorkFlow_Roles_by_State_Permission_To_New ?? false,
                    Permission_To_Modify = m.Spartan_WorkFlow_Roles_by_State_Permission_To_Modify ?? false,
                    Permission_to_Delete = m.Spartan_WorkFlow_Roles_by_State_Permission_to_Delete ?? false,
                    Permission_To_Export = m.Spartan_WorkFlow_Roles_by_State_Permission_To_Export ?? false,
                    Permission_To_Print = m.Spartan_WorkFlow_Roles_by_State_Permission_To_Print ?? false,
                    Permission_Settings = m.Spartan_WorkFlow_Roles_by_State_Permission_Settings ?? false,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Roles_by_State>("sp_ListSelAll_Spartan_WorkFlow_Roles_by_State", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_Roles_by_StatePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_Roles_by_StatePagingModel
                {
                    Spartan_WorkFlow_Roles_by_States =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State
                {
                    Roles_by_StateId = m.Spartan_WorkFlow_Roles_by_State_Roles_by_StateId
                    ,Spartan_WorkFlow = m.Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow
                    ,Phase = m.Spartan_WorkFlow_Roles_by_State_Phase
                    ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Spartan_WorkFlow_Roles_by_State_Phase.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Roles_by_State_Phase_Name }
                    ,State = m.Spartan_WorkFlow_Roles_by_State_State
                    ,State_Spartan_WorkFlow_State = new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State() { StateId = m.Spartan_WorkFlow_Roles_by_State_State.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Roles_by_State_State_Name }
                    ,User_Role = m.Spartan_WorkFlow_Roles_by_State_User_Role
                    ,Phase_Transition = m.Spartan_WorkFlow_Roles_by_State_Phase_Transition
                    ,Permission_To_Consult = m.Spartan_WorkFlow_Roles_by_State_Permission_To_Consult ?? false
                    ,Permission_To_New = m.Spartan_WorkFlow_Roles_by_State_Permission_To_New ?? false
                    ,Permission_To_Modify = m.Spartan_WorkFlow_Roles_by_State_Permission_To_Modify ?? false
                    ,Permission_to_Delete = m.Spartan_WorkFlow_Roles_by_State_Permission_to_Delete ?? false
                    ,Permission_To_Export = m.Spartan_WorkFlow_Roles_by_State_Permission_To_Export ?? false
                    ,Permission_To_Print = m.Spartan_WorkFlow_Roles_by_State_Permission_To_Print ?? false
                    ,Permission_Settings = m.Spartan_WorkFlow_Roles_by_State_Permission_Settings ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Roles_by_StateId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>("sp_GetSpartan_WorkFlow_Roles_by_State", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Roles_by_StateId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Roles_by_State>("sp_DelSpartan_WorkFlow_Roles_by_State", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State entity)
        {
            int rta;
            try
            {

		                var padreSpartan_WorkFlow = _dataProvider.GetParameter();
                padreSpartan_WorkFlow.ParameterName = "Spartan_WorkFlow";
                padreSpartan_WorkFlow.DbType = DbType.Int32;
                padreSpartan_WorkFlow.Value = (object)entity.Spartan_WorkFlow ?? DBNull.Value;
                var padrePhase = _dataProvider.GetParameter();
                padrePhase.ParameterName = "Phase";
                padrePhase.DbType = DbType.Int32;
                padrePhase.Value = (object)entity.Phase ?? DBNull.Value;

                var padreState = _dataProvider.GetParameter();
                padreState.ParameterName = "State";
                padreState.DbType = DbType.Int32;
                padreState.Value = (object)entity.State ?? DBNull.Value;

                var padreUser_Role = _dataProvider.GetParameter();
                padreUser_Role.ParameterName = "User_Role";
                padreUser_Role.DbType = DbType.Int16;
                padreUser_Role.Value = (object)entity.User_Role ?? DBNull.Value;

                var padrePhase_Transition = _dataProvider.GetParameter();
                padrePhase_Transition.ParameterName = "Phase_Transition";
                padrePhase_Transition.DbType = DbType.Int16;
                padrePhase_Transition.Value = (object)entity.Phase_Transition ?? DBNull.Value;

                var padrePermission_To_Consult = _dataProvider.GetParameter();
                padrePermission_To_Consult.ParameterName = "Permission_To_Consult";
                padrePermission_To_Consult.DbType = DbType.Boolean;
                padrePermission_To_Consult.Value = (object)entity.Permission_To_Consult ?? DBNull.Value;
                var padrePermission_To_New = _dataProvider.GetParameter();
                padrePermission_To_New.ParameterName = "Permission_To_New";
                padrePermission_To_New.DbType = DbType.Boolean;
                padrePermission_To_New.Value = (object)entity.Permission_To_New ?? DBNull.Value;
                var padrePermission_To_Modify = _dataProvider.GetParameter();
                padrePermission_To_Modify.ParameterName = "Permission_To_Modify";
                padrePermission_To_Modify.DbType = DbType.Boolean;
                padrePermission_To_Modify.Value = (object)entity.Permission_To_Modify ?? DBNull.Value;
                var padrePermission_to_Delete = _dataProvider.GetParameter();
                padrePermission_to_Delete.ParameterName = "Permission_to_Delete";
                padrePermission_to_Delete.DbType = DbType.Boolean;
                padrePermission_to_Delete.Value = (object)entity.Permission_to_Delete ?? DBNull.Value;
                var padrePermission_To_Export = _dataProvider.GetParameter();
                padrePermission_To_Export.ParameterName = "Permission_To_Export";
                padrePermission_To_Export.DbType = DbType.Boolean;
                padrePermission_To_Export.Value = (object)entity.Permission_To_Export ?? DBNull.Value;
                var padrePermission_To_Print = _dataProvider.GetParameter();
                padrePermission_To_Print.ParameterName = "Permission_To_Print";
                padrePermission_To_Print.DbType = DbType.Boolean;
                padrePermission_To_Print.Value = (object)entity.Permission_To_Print ?? DBNull.Value;
                var padrePermission_Settings = _dataProvider.GetParameter();
                padrePermission_Settings.ParameterName = "Permission_Settings";
                padrePermission_Settings.DbType = DbType.Boolean;
                padrePermission_Settings.Value = (object)entity.Permission_Settings ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Roles_by_State>("sp_InsSpartan_WorkFlow_Roles_by_State" , padreSpartan_WorkFlow

, padrePhase
, padreState
, padreUser_Role
, padrePhase_Transition
, padrePermission_To_Consult
, padrePermission_To_New
, padrePermission_To_Modify
, padrePermission_to_Delete
, padrePermission_To_Export
, padrePermission_To_Print
, padrePermission_Settings
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Roles_by_StateId);

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

        public int Update(Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State entity)
        {
            int rta;
            try
            {

                var paramUpdSpartan_WorkFlow = _dataProvider.GetParameter();
                paramUpdSpartan_WorkFlow.ParameterName = "Spartan_WorkFlow";
                paramUpdSpartan_WorkFlow.DbType = DbType.Int32;
                paramUpdSpartan_WorkFlow.Value = (object)entity.Spartan_WorkFlow ?? DBNull.Value;
                var paramUpdRoles_by_StateId = _dataProvider.GetParameter();
                paramUpdRoles_by_StateId.ParameterName = "Roles_by_StateId";
                paramUpdRoles_by_StateId.DbType = DbType.Int32;
                paramUpdRoles_by_StateId.Value = (object)entity.Roles_by_StateId ?? DBNull.Value;
                var paramUpdPhase = _dataProvider.GetParameter();
                paramUpdPhase.ParameterName = "Phase";
                paramUpdPhase.DbType = DbType.Int32;
                paramUpdPhase.Value = (object)entity.Phase ?? DBNull.Value;

                var paramUpdState = _dataProvider.GetParameter();
                paramUpdState.ParameterName = "State";
                paramUpdState.DbType = DbType.Int32;
                paramUpdState.Value = (object)entity.State ?? DBNull.Value;

                var paramUpdUser_Role = _dataProvider.GetParameter();
                paramUpdUser_Role.ParameterName = "User_Role";
                paramUpdUser_Role.DbType = DbType.Int16;
                paramUpdUser_Role.Value = (object)entity.User_Role ?? DBNull.Value;

                var paramUpdPhase_Transition = _dataProvider.GetParameter();
                paramUpdPhase_Transition.ParameterName = "Phase_Transition";
                paramUpdPhase_Transition.DbType = DbType.Int16;
                paramUpdPhase_Transition.Value = (object)entity.Phase_Transition ?? DBNull.Value;

                var paramUpdPermission_To_Consult = _dataProvider.GetParameter();
                paramUpdPermission_To_Consult.ParameterName = "Permission_To_Consult";
                paramUpdPermission_To_Consult.DbType = DbType.Boolean;
                paramUpdPermission_To_Consult.Value = (object)entity.Permission_To_Consult ?? DBNull.Value;
                var paramUpdPermission_To_New = _dataProvider.GetParameter();
                paramUpdPermission_To_New.ParameterName = "Permission_To_New";
                paramUpdPermission_To_New.DbType = DbType.Boolean;
                paramUpdPermission_To_New.Value = (object)entity.Permission_To_New ?? DBNull.Value;
                var paramUpdPermission_To_Modify = _dataProvider.GetParameter();
                paramUpdPermission_To_Modify.ParameterName = "Permission_To_Modify";
                paramUpdPermission_To_Modify.DbType = DbType.Boolean;
                paramUpdPermission_To_Modify.Value = (object)entity.Permission_To_Modify ?? DBNull.Value;
                var paramUpdPermission_to_Delete = _dataProvider.GetParameter();
                paramUpdPermission_to_Delete.ParameterName = "Permission_to_Delete";
                paramUpdPermission_to_Delete.DbType = DbType.Boolean;
                paramUpdPermission_to_Delete.Value = (object)entity.Permission_to_Delete ?? DBNull.Value;
                var paramUpdPermission_To_Export = _dataProvider.GetParameter();
                paramUpdPermission_To_Export.ParameterName = "Permission_To_Export";
                paramUpdPermission_To_Export.DbType = DbType.Boolean;
                paramUpdPermission_To_Export.Value = (object)entity.Permission_To_Export ?? DBNull.Value;
                var paramUpdPermission_To_Print = _dataProvider.GetParameter();
                paramUpdPermission_To_Print.ParameterName = "Permission_To_Print";
                paramUpdPermission_To_Print.DbType = DbType.Boolean;
                paramUpdPermission_To_Print.Value = (object)entity.Permission_To_Print ?? DBNull.Value;
                var paramUpdPermission_Settings = _dataProvider.GetParameter();
                paramUpdPermission_Settings.ParameterName = "Permission_Settings";
                paramUpdPermission_Settings.DbType = DbType.Boolean;
                paramUpdPermission_Settings.Value = (object)entity.Permission_Settings ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Roles_by_State>("sp_UpdSpartan_WorkFlow_Roles_by_State" , paramUpdSpartan_WorkFlow , paramUpdRoles_by_StateId , paramUpdPhase , paramUpdState , paramUpdUser_Role , paramUpdPhase_Transition , paramUpdPermission_To_Consult , paramUpdPermission_To_New , paramUpdPermission_To_Modify , paramUpdPermission_to_Delete , paramUpdPermission_To_Export , paramUpdPermission_To_Print , paramUpdPermission_Settings ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Roles_by_StateId);
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

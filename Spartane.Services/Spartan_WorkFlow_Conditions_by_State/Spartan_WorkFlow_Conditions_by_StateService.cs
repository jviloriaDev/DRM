using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Conditions_by_State
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Conditions_by_StateService : ISpartan_WorkFlow_Conditions_by_StateService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State> _Spartan_WorkFlow_Conditions_by_StateRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Conditions_by_StateService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State> Spartan_WorkFlow_Conditions_by_StateRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Conditions_by_StateRepository = Spartan_WorkFlow_Conditions_by_StateRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_Conditions_by_StateRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State>("sp_SelAllSpartan_WorkFlow_Conditions_by_State");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Conditions_by_State_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Conditions_by_State");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State
            {
                Conditions_by_StateId = m.Conditions_by_StateId
                ,Spartan_WorkFlow = m.Spartan_WorkFlow
                ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Phase.GetValueOrDefault(), Name = m.Phase_Name }
                ,State_Spartan_WorkFlow_State = new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State() { StateId = m.State.GetValueOrDefault(), Name = m.State_Name }
                ,Condition_Operator_Spartan_WorkFlow_Condition_Operator = new Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator() { Condition_OperatorId = m.Condition_Operator.GetValueOrDefault(), Description = m.Condition_Operator_Description }
                ,Attribute_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Attribute.GetValueOrDefault(), Logical_Name = m.Attribute_Logical_Name }
                ,Condition_Spartan_WorkFlow_Condition = new Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition() { ConditionId = m.Condition.GetValueOrDefault(), Description = m.Condition_Description }
                ,Operator_Spartan_WorkFlow_Operator = new Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator() { OperatorId = m.Operator.GetValueOrDefault(), Description = m.Operator_Description }
                ,Operator_Value = m.Operator_Value
                ,Priority = m.Priority


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Conditions_by_State>("sp_ListSelCount_Spartan_WorkFlow_Conditions_by_State", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Conditions_by_State>("sp_ListSelAll_Spartan_WorkFlow_Conditions_by_State", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State
                {
                    Spartan_WorkFlow = m.Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow,
                    Conditions_by_StateId = m.Spartan_WorkFlow_Conditions_by_State_Conditions_by_StateId,
                    Phase = m.Spartan_WorkFlow_Conditions_by_State_Phase,
                    State = m.Spartan_WorkFlow_Conditions_by_State_State,
                    Condition_Operator = m.Spartan_WorkFlow_Conditions_by_State_Condition_Operator,
                    Attribute = m.Spartan_WorkFlow_Conditions_by_State_Attribute,
                    Condition = m.Spartan_WorkFlow_Conditions_by_State_Condition,
                    Operator = m.Spartan_WorkFlow_Conditions_by_State_Operator,
                    Operator_Value = m.Spartan_WorkFlow_Conditions_by_State_Operator_Value,
                    Priority = m.Spartan_WorkFlow_Conditions_by_State_Priority,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Conditions_by_StateRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Conditions_by_StateRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_StatePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Conditions_by_State>("sp_ListSelAll_Spartan_WorkFlow_Conditions_by_State", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_Conditions_by_StatePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_Conditions_by_StatePagingModel
                {
                    Spartan_WorkFlow_Conditions_by_States =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State
                {
                    Conditions_by_StateId = m.Spartan_WorkFlow_Conditions_by_State_Conditions_by_StateId
                    ,Spartan_WorkFlow = m.Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow
                    ,Phase = m.Spartan_WorkFlow_Conditions_by_State_Phase
                    ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Spartan_WorkFlow_Conditions_by_State_Phase.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Conditions_by_State_Phase_Name }
                    ,State = m.Spartan_WorkFlow_Conditions_by_State_State
                    ,State_Spartan_WorkFlow_State = new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State() { StateId = m.Spartan_WorkFlow_Conditions_by_State_State.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Conditions_by_State_State_Name }
                    ,Condition_Operator = m.Spartan_WorkFlow_Conditions_by_State_Condition_Operator
                    ,Condition_Operator_Spartan_WorkFlow_Condition_Operator = new Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator() { Condition_OperatorId = m.Spartan_WorkFlow_Conditions_by_State_Condition_Operator.GetValueOrDefault(), Description = m.Spartan_WorkFlow_Conditions_by_State_Condition_Operator_Description }
                    ,Attribute = m.Spartan_WorkFlow_Conditions_by_State_Attribute
                    ,Attribute_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Spartan_WorkFlow_Conditions_by_State_Attribute.GetValueOrDefault(), Logical_Name = m.Spartan_WorkFlow_Conditions_by_State_Attribute_Logical_Name }
                    ,Condition = m.Spartan_WorkFlow_Conditions_by_State_Condition
                    ,Condition_Spartan_WorkFlow_Condition = new Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition() { ConditionId = m.Spartan_WorkFlow_Conditions_by_State_Condition.GetValueOrDefault(), Description = m.Spartan_WorkFlow_Conditions_by_State_Condition_Description }
                    ,Operator = m.Spartan_WorkFlow_Conditions_by_State_Operator
                    ,Operator_Spartan_WorkFlow_Operator = new Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator() { OperatorId = m.Spartan_WorkFlow_Conditions_by_State_Operator.GetValueOrDefault(), Description = m.Spartan_WorkFlow_Conditions_by_State_Operator_Description }
                    ,Operator_Value = m.Spartan_WorkFlow_Conditions_by_State_Operator_Value
                    ,Priority = m.Spartan_WorkFlow_Conditions_by_State_Priority

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Conditions_by_StateRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Conditions_by_StateId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State>("sp_GetSpartan_WorkFlow_Conditions_by_State", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Conditions_by_StateId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Conditions_by_State>("sp_DelSpartan_WorkFlow_Conditions_by_State", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State entity)
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

                var padreCondition_Operator = _dataProvider.GetParameter();
                padreCondition_Operator.ParameterName = "Condition_Operator";
                padreCondition_Operator.DbType = DbType.Int32;
                padreCondition_Operator.Value = (object)entity.Condition_Operator ?? DBNull.Value;

                var padreAttribute = _dataProvider.GetParameter();
                padreAttribute.ParameterName = "Attribute";
                padreAttribute.DbType = DbType.Int32;
                padreAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var padreCondition = _dataProvider.GetParameter();
                padreCondition.ParameterName = "Condition";
                padreCondition.DbType = DbType.Int16;
                padreCondition.Value = (object)entity.Condition ?? DBNull.Value;

                var padreOperator = _dataProvider.GetParameter();
                padreOperator.ParameterName = "Operator";
                padreOperator.DbType = DbType.Int16;
                padreOperator.Value = (object)entity.Operator ?? DBNull.Value;

                var padreOperator_Value = _dataProvider.GetParameter();
                padreOperator_Value.ParameterName = "Operator_Value";
                padreOperator_Value.DbType = DbType.String;
                padreOperator_Value.Value = (object)entity.Operator_Value ?? DBNull.Value;
                var padrePriority = _dataProvider.GetParameter();
                padrePriority.ParameterName = "Priority";
                padrePriority.DbType = DbType.Int16;
                padrePriority.Value = (object)entity.Priority ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Conditions_by_State>("sp_InsSpartan_WorkFlow_Conditions_by_State" , padreSpartan_WorkFlow

, padrePhase
, padreState
, padreCondition_Operator
, padreAttribute
, padreCondition
, padreOperator
, padreOperator_Value
, padrePriority
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Conditions_by_StateId);

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

        public int Update(Spartane.Core.Classes.Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow_Conditions_by_State entity)
        {
            int rta;
            try
            {

                var paramUpdSpartan_WorkFlow = _dataProvider.GetParameter();
                paramUpdSpartan_WorkFlow.ParameterName = "Spartan_WorkFlow";
                paramUpdSpartan_WorkFlow.DbType = DbType.Int32;
                paramUpdSpartan_WorkFlow.Value = (object)entity.Spartan_WorkFlow ?? DBNull.Value;
                var paramUpdConditions_by_StateId = _dataProvider.GetParameter();
                paramUpdConditions_by_StateId.ParameterName = "Conditions_by_StateId";
                paramUpdConditions_by_StateId.DbType = DbType.Int32;
                paramUpdConditions_by_StateId.Value = (object)entity.Conditions_by_StateId ?? DBNull.Value;
                var paramUpdPhase = _dataProvider.GetParameter();
                paramUpdPhase.ParameterName = "Phase";
                paramUpdPhase.DbType = DbType.Int32;
                paramUpdPhase.Value = (object)entity.Phase ?? DBNull.Value;

                var paramUpdState = _dataProvider.GetParameter();
                paramUpdState.ParameterName = "State";
                paramUpdState.DbType = DbType.Int32;
                paramUpdState.Value = (object)entity.State ?? DBNull.Value;

                var paramUpdCondition_Operator = _dataProvider.GetParameter();
                paramUpdCondition_Operator.ParameterName = "Condition_Operator";
                paramUpdCondition_Operator.DbType = DbType.Int32;
                paramUpdCondition_Operator.Value = (object)entity.Condition_Operator ?? DBNull.Value;

                var paramUpdAttribute = _dataProvider.GetParameter();
                paramUpdAttribute.ParameterName = "Attribute";
                paramUpdAttribute.DbType = DbType.Int32;
                paramUpdAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var paramUpdCondition = _dataProvider.GetParameter();
                paramUpdCondition.ParameterName = "Condition";
                paramUpdCondition.DbType = DbType.Int16;
                paramUpdCondition.Value = (object)entity.Condition ?? DBNull.Value;

                var paramUpdOperator = _dataProvider.GetParameter();
                paramUpdOperator.ParameterName = "Operator";
                paramUpdOperator.DbType = DbType.Int16;
                paramUpdOperator.Value = (object)entity.Operator ?? DBNull.Value;

                var paramUpdOperator_Value = _dataProvider.GetParameter();
                paramUpdOperator_Value.ParameterName = "Operator_Value";
                paramUpdOperator_Value.DbType = DbType.String;
                paramUpdOperator_Value.Value = (object)entity.Operator_Value ?? DBNull.Value;
                var paramUpdPriority = _dataProvider.GetParameter();
                paramUpdPriority.ParameterName = "Priority";
                paramUpdPriority.DbType = DbType.Int16;
                paramUpdPriority.Value = (object)entity.Priority ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Conditions_by_State>("sp_UpdSpartan_WorkFlow_Conditions_by_State" , paramUpdSpartan_WorkFlow , paramUpdConditions_by_StateId , paramUpdPhase , paramUpdState , paramUpdCondition_Operator , paramUpdAttribute , paramUpdCondition , paramUpdOperator , paramUpdOperator_Value , paramUpdPriority ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Conditions_by_StateId);
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

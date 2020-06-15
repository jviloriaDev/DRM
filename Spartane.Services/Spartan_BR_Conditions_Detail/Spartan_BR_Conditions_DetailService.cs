using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Conditions_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Conditions_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Conditions_DetailService : ISpartan_BR_Conditions_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> _Spartan_BR_Conditions_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Conditions_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> Spartan_BR_Conditions_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Conditions_DetailRepository = Spartan_BR_Conditions_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail>("sp_SelAllSpartan_BR_Conditions_Detail");
        }

        public IList<Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Conditions_Detail_Complete>("sp_SelAllComplete_Spartan_BR_Conditions_Detail");
            return data.Select(m => new Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail
            {
                ConditionsDetailId = m.ConditionsDetailId
                ,Business_Rule = m.Business_Rule
                ,Condition_Operator_Spartan_BR_Condition_Operator = new Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator() { ConditionOperatorId = m.Condition_Operator.GetValueOrDefault(), Description = m.Condition_Operator_Description }
                ,First_Operator_Type_Spartan_BR_Operator_Type = new Core.Classes.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type() { OperatorTypeId = m.First_Operator_Type.GetValueOrDefault(), Description = m.First_Operator_Type_Description }
                ,First_Operator_Value = m.First_Operator_Value
                ,Condition_Spartan_BR_Condition = new Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition() { ConditionId = m.Condition.GetValueOrDefault(), Description = m.Condition_Description }
                ,Second_Operator_Type_Spartan_BR_Operator_Type = new Core.Classes.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type() { OperatorTypeId = m.Second_Operator_Type.GetValueOrDefault(), Description = m.Second_Operator_Type_Description }
                ,Second_Operator_Value = m.Second_Operator_Value


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Conditions_Detail>("sp_ListSelCount_Spartan_BR_Conditions_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Conditions_Detail>("sp_ListSelAll_Spartan_BR_Conditions_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail
                {
                    ConditionsDetailId = m.Spartan_BR_Conditions_Detail_ConditionsDetailId,
                    Business_Rule = m.Spartan_BR_Conditions_Detail_Business_Rule,
                    Condition_Operator = m.Spartan_BR_Conditions_Detail_Condition_Operator,
                    First_Operator_Type = m.Spartan_BR_Conditions_Detail_First_Operator_Type,
                    First_Operator_Value = m.Spartan_BR_Conditions_Detail_First_Operator_Value,
                    Condition = m.Spartan_BR_Conditions_Detail_Condition,
                    Second_Operator_Type = m.Spartan_BR_Conditions_Detail_Second_Operator_Type,
                    Second_Operator_Value = m.Spartan_BR_Conditions_Detail_Second_Operator_Value,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Conditions_Detail>("sp_ListSelAll_Spartan_BR_Conditions_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Conditions_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Conditions_DetailPagingModel
                {
                    Spartan_BR_Conditions_Details =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail
                {
                    ConditionsDetailId = m.Spartan_BR_Conditions_Detail_ConditionsDetailId
                    ,Business_Rule = m.Spartan_BR_Conditions_Detail_Business_Rule
                    ,Condition_Operator = m.Spartan_BR_Conditions_Detail_Condition_Operator
                    ,Condition_Operator_Spartan_BR_Condition_Operator = new Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator() { ConditionOperatorId = m.Spartan_BR_Conditions_Detail_Condition_Operator.GetValueOrDefault(), Description = m.Spartan_BR_Conditions_Detail_Condition_Operator_Description }
                    ,First_Operator_Type = m.Spartan_BR_Conditions_Detail_First_Operator_Type
                    ,First_Operator_Type_Spartan_BR_Operator_Type = new Core.Classes.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type() { OperatorTypeId = m.Spartan_BR_Conditions_Detail_First_Operator_Type.GetValueOrDefault(), Description = m.Spartan_BR_Conditions_Detail_First_Operator_Type_Description }
                    ,First_Operator_Value = m.Spartan_BR_Conditions_Detail_First_Operator_Value
                    ,Condition = m.Spartan_BR_Conditions_Detail_Condition
                    ,Condition_Spartan_BR_Condition = new Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition() { ConditionId = m.Spartan_BR_Conditions_Detail_Condition.GetValueOrDefault(), Description = m.Spartan_BR_Conditions_Detail_Condition_Description }
                    ,Second_Operator_Type = m.Spartan_BR_Conditions_Detail_Second_Operator_Type
                    ,Second_Operator_Type_Spartan_BR_Operator_Type = new Core.Classes.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type() { OperatorTypeId = m.Spartan_BR_Conditions_Detail_Second_Operator_Type.GetValueOrDefault(), Description = m.Spartan_BR_Conditions_Detail_Second_Operator_Type_Description }
                    ,Second_Operator_Value = m.Spartan_BR_Conditions_Detail_Second_Operator_Value

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ConditionsDetailId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail>("sp_GetSpartan_BR_Conditions_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ConditionsDetailId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Conditions_Detail>("sp_DelSpartan_BR_Conditions_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail entity)
        {
            int rta;
            try
            {

		                var padreBusiness_Rule = _dataProvider.GetParameter();
                padreBusiness_Rule.ParameterName = "Business_Rule";
                padreBusiness_Rule.DbType = DbType.Int32;
                padreBusiness_Rule.Value = (object)entity.Business_Rule ?? DBNull.Value;
                var padreCondition_Operator = _dataProvider.GetParameter();
                padreCondition_Operator.ParameterName = "Condition_Operator";
                padreCondition_Operator.DbType = DbType.Int16;
                padreCondition_Operator.Value = (object)entity.Condition_Operator ?? DBNull.Value;

                var padreFirst_Operator_Type = _dataProvider.GetParameter();
                padreFirst_Operator_Type.ParameterName = "First_Operator_Type";
                padreFirst_Operator_Type.DbType = DbType.Int32;
                padreFirst_Operator_Type.Value = (object)entity.First_Operator_Type ?? DBNull.Value;

                var padreFirst_Operator_Value = _dataProvider.GetParameter();
                padreFirst_Operator_Value.ParameterName = "First_Operator_Value";
                padreFirst_Operator_Value.DbType = DbType.String;
                padreFirst_Operator_Value.Value = (object)entity.First_Operator_Value ?? DBNull.Value;
                var padreCondition = _dataProvider.GetParameter();
                padreCondition.ParameterName = "Condition";
                padreCondition.DbType = DbType.Int16;
                padreCondition.Value = (object)entity.Condition ?? DBNull.Value;

                var padreSecond_Operator_Type = _dataProvider.GetParameter();
                padreSecond_Operator_Type.ParameterName = "Second_Operator_Type";
                padreSecond_Operator_Type.DbType = DbType.Int32;
                padreSecond_Operator_Type.Value = (object)entity.Second_Operator_Type ?? DBNull.Value;

                var padreSecond_Operator_Value = _dataProvider.GetParameter();
                padreSecond_Operator_Value.ParameterName = "Second_Operator_Value";
                padreSecond_Operator_Value.DbType = DbType.String;
                padreSecond_Operator_Value.Value = (object)entity.Second_Operator_Value ?? DBNull.Value;
 
                //CAMBIOS MANUALES(padre Condition no estaba en la ejecucion)
                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Conditions_Detail>("sp_InsSpartan_BR_Conditions_Detail" , padreBusiness_Rule
, padreCondition_Operator
, padreFirst_Operator_Type
, padreFirst_Operator_Value
, padreCondition
, padreSecond_Operator_Type
, padreSecond_Operator_Value
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ConditionsDetailId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdConditionsDetailId = _dataProvider.GetParameter();
                paramUpdConditionsDetailId.ParameterName = "ConditionsDetailId";
                paramUpdConditionsDetailId.DbType = DbType.Int32;
                paramUpdConditionsDetailId.Value = entity.ConditionsDetailId;
                var paramUpdBusiness_Rule = _dataProvider.GetParameter();
                paramUpdBusiness_Rule.ParameterName = "Business_Rule";
                paramUpdBusiness_Rule.DbType = DbType.Int32;
                paramUpdBusiness_Rule.Value = entity.Business_Rule;
                var paramUpdCondition_Operator = _dataProvider.GetParameter();
                paramUpdCondition_Operator.ParameterName = "Condition_Operator";
                paramUpdCondition_Operator.DbType = DbType.Int16;
                if (entity.Condition_Operator == null)
                    paramUpdCondition_Operator.Value = DBNull.Value;
                else
                    paramUpdCondition_Operator.Value = entity.Condition_Operator;

                var paramUpdFirst_Operator_Type = _dataProvider.GetParameter();
                paramUpdFirst_Operator_Type.ParameterName = "First_Operator_Type";
                paramUpdFirst_Operator_Type.DbType = DbType.Int32;
                if (entity.First_Operator_Type == null)
                    paramUpdFirst_Operator_Type.Value = DBNull.Value;
                else
                    paramUpdFirst_Operator_Type.Value = entity.First_Operator_Type;

                var paramUpdFirst_Operator_Value = _dataProvider.GetParameter();
                paramUpdFirst_Operator_Value.ParameterName = "First_Operator_Value";
                paramUpdFirst_Operator_Value.DbType = DbType.String;
                paramUpdFirst_Operator_Value.Value = entity.First_Operator_Value;
                var paramUpdCondition = _dataProvider.GetParameter();
                paramUpdCondition.ParameterName = "Condition";
                paramUpdCondition.DbType = DbType.Int16;
                if (entity.Condition == null)
                    paramUpdCondition.Value = DBNull.Value;
                else
                    paramUpdCondition.Value = entity.Condition;

                var paramUpdSecond_Operator_Type = _dataProvider.GetParameter();
                paramUpdSecond_Operator_Type.ParameterName = "Second_Operator_Type";
                paramUpdSecond_Operator_Type.DbType = DbType.Int32;
                if (entity.Second_Operator_Type == null)
                    paramUpdSecond_Operator_Type.Value = DBNull.Value;
                else
                    paramUpdSecond_Operator_Type.Value = entity.Second_Operator_Type;

                var paramUpdSecond_Operator_Value = _dataProvider.GetParameter();
                paramUpdSecond_Operator_Value.ParameterName = "Second_Operator_Value";
                paramUpdSecond_Operator_Value.DbType = DbType.String;
                paramUpdSecond_Operator_Value.Value = entity.Second_Operator_Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Conditions_Detail>("sp_UpdSpartan_BR_Conditions_Detail" , 
                    paramUpdConditionsDetailId ,
                    paramUpdBusiness_Rule,
                    paramUpdCondition_Operator,
                    paramUpdFirst_Operator_Type ,
                    paramUpdFirst_Operator_Value,
                    paramUpdCondition,
                    paramUpdSecond_Operator_Type , 
                    paramUpdSecond_Operator_Value ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ConditionsDetailId);
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


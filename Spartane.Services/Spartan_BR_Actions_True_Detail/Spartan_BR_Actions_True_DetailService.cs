using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Actions_True_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Actions_True_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Actions_True_DetailService : ISpartan_BR_Actions_True_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> _Spartan_BR_Actions_True_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Actions_True_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> Spartan_BR_Actions_True_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Actions_True_DetailRepository = Spartan_BR_Actions_True_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Actions_True_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail>("sp_SelAllSpartan_BR_Actions_True_Detail");
        }

        public IList<Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Actions_True_Detail_Complete>("sp_SelAllComplete_Spartan_BR_Actions_True_Detail");
            return data.Select(m => new Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail
            {
                ActionsTrueDetailId = m.ActionsTrueDetailId
                ,Business_Rule = m.Business_Rule
                ,Action_Classification_Spartan_BR_Action_Classification = new Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification() { ClassificationId = m.Action_Classification.GetValueOrDefault(), Description = m.Action_Classification_Description }
                ,Action_Spartan_BR_Action = new Core.Classes.Spartan_BR_Action.Spartan_BR_Action() { ActionId = m.Action.GetValueOrDefault(), Description = m.Action_Description }
                ,Action_Result_Spartan_BR_Action_Result = new Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result() { ActionResultId = m.Action_Result.GetValueOrDefault(), Description = m.Action_Result_Description }
                ,Parameter_1 = m.Parameter_1
                ,Parameter_2 = m.Parameter_2
                ,Parameter_3 = m.Parameter_3
                ,Parameter_4 = m.Parameter_4
                ,Parameter_5 = m.Parameter_5


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Actions_True_Detail>("sp_ListSelCount_Spartan_BR_Actions_True_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Actions_True_Detail>("sp_ListSelAll_Spartan_BR_Actions_True_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail
                {
                    ActionsTrueDetailId = m.Spartan_BR_Actions_True_Detail_ActionsTrueDetailId,
                    Business_Rule = m.Spartan_BR_Actions_True_Detail_Business_Rule,
                    Action_Classification = m.Spartan_BR_Actions_True_Detail_Action_Classification,
                    Action = m.Spartan_BR_Actions_True_Detail_Action,
                    Action_Result = m.Spartan_BR_Actions_True_Detail_Action_Result,
                    Parameter_1 = m.Spartan_BR_Actions_True_Detail_Parameter_1,
                    Parameter_2 = m.Spartan_BR_Actions_True_Detail_Parameter_2,
                    Parameter_3 = m.Spartan_BR_Actions_True_Detail_Parameter_3,
                    Parameter_4 = m.Spartan_BR_Actions_True_Detail_Parameter_4,
                    Parameter_5 = m.Spartan_BR_Actions_True_Detail_Parameter_5,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Actions_True_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Actions_True_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Actions_True_Detail>("sp_ListSelAll_Spartan_BR_Actions_True_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Actions_True_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Actions_True_DetailPagingModel
                {
                    Spartan_BR_Actions_True_Details =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail
                {
                    ActionsTrueDetailId = m.Spartan_BR_Actions_True_Detail_ActionsTrueDetailId
                    ,Business_Rule = m.Spartan_BR_Actions_True_Detail_Business_Rule
                    ,Action_Classification = m.Spartan_BR_Actions_True_Detail_Action_Classification
                    ,Action_Classification_Spartan_BR_Action_Classification = new Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification() { ClassificationId = m.Spartan_BR_Actions_True_Detail_Action_Classification.GetValueOrDefault(), Description = m.Spartan_BR_Actions_True_Detail_Action_Classification_Description }
                    ,Action = m.Spartan_BR_Actions_True_Detail_Action
                    ,Action_Spartan_BR_Action = new Core.Classes.Spartan_BR_Action.Spartan_BR_Action() { ActionId = m.Spartan_BR_Actions_True_Detail_Action.GetValueOrDefault(), Description = m.Spartan_BR_Actions_True_Detail_Action_Description }
                    ,Action_Result = m.Spartan_BR_Actions_True_Detail_Action_Result
                    ,Action_Result_Spartan_BR_Action_Result = new Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result() { ActionResultId = m.Spartan_BR_Actions_True_Detail_Action_Result.GetValueOrDefault(), Description = m.Spartan_BR_Actions_True_Detail_Action_Result_Description }
                    ,Parameter_1 = m.Spartan_BR_Actions_True_Detail_Parameter_1
                    ,Parameter_2 = m.Spartan_BR_Actions_True_Detail_Parameter_2
                    ,Parameter_3 = m.Spartan_BR_Actions_True_Detail_Parameter_3
                    ,Parameter_4 = m.Spartan_BR_Actions_True_Detail_Parameter_4
                    ,Parameter_5 = m.Spartan_BR_Actions_True_Detail_Parameter_5

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Actions_True_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ActionsTrueDetailId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail>("sp_GetSpartan_BR_Actions_True_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ActionsTrueDetailId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Actions_True_Detail>("sp_DelSpartan_BR_Actions_True_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail entity)
        {
            int rta;
            try
            {

		                var padreBusiness_Rule = _dataProvider.GetParameter();
                padreBusiness_Rule.ParameterName = "Business_Rule";
                padreBusiness_Rule.DbType = DbType.Int32;
                padreBusiness_Rule.Value = (object)entity.Business_Rule ?? DBNull.Value;
                var padreAction_Classification = _dataProvider.GetParameter();
                padreAction_Classification.ParameterName = "Action_Classification";
                padreAction_Classification.DbType = DbType.Int16;
                padreAction_Classification.Value = (object)entity.Action_Classification ?? DBNull.Value;

                var padreAction = _dataProvider.GetParameter();
                padreAction.ParameterName = "Action";
                padreAction.DbType = DbType.Int32;
                padreAction.Value = (object)entity.Action ?? DBNull.Value;

                var padreAction_Result = _dataProvider.GetParameter();
                padreAction_Result.ParameterName = "Action_Result";
                padreAction_Result.DbType = DbType.Int16;
                padreAction_Result.Value = (object)entity.Action_Result ?? DBNull.Value;

                var padreParameter_1 = _dataProvider.GetParameter();
                padreParameter_1.ParameterName = "Parameter_1";
                padreParameter_1.DbType = DbType.String;
                padreParameter_1.Value = (object)entity.Parameter_1 ?? DBNull.Value;
                var padreParameter_2 = _dataProvider.GetParameter();
                padreParameter_2.ParameterName = "Parameter_2";
                padreParameter_2.DbType = DbType.String;
                padreParameter_2.Value = (object)entity.Parameter_2 ?? DBNull.Value;
                var padreParameter_3 = _dataProvider.GetParameter();
                padreParameter_3.ParameterName = "Parameter_3";
                padreParameter_3.DbType = DbType.String;
                padreParameter_3.Value = (object)entity.Parameter_3 ?? DBNull.Value;
                var padreParameter_4 = _dataProvider.GetParameter();
                padreParameter_4.ParameterName = "Parameter_4";
                padreParameter_4.DbType = DbType.String;
                padreParameter_4.Value = (object)entity.Parameter_4 ?? DBNull.Value;
                var padreParameter_5 = _dataProvider.GetParameter();
                padreParameter_5.ParameterName = "Parameter_5";
                padreParameter_5.DbType = DbType.String;
                padreParameter_5.Value = (object)entity.Parameter_5 ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Actions_True_Detail>("sp_InsSpartan_BR_Actions_True_Detail" , padreBusiness_Rule
, padreAction_Classification
, padreAction
, padreAction_Result
, padreParameter_1
, padreParameter_2
, padreParameter_3
, padreParameter_4
, padreParameter_5
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ActionsTrueDetailId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail entity)
        {
            int rta;
            try
            {
                //CAMBIOS MANUALES
                var paramUpdActionsTrueDetailId = _dataProvider.GetParameter();
                paramUpdActionsTrueDetailId.ParameterName = "ActionsTrueDetailId";
                paramUpdActionsTrueDetailId.DbType = DbType.Int32;
                paramUpdActionsTrueDetailId.Value = (object)entity.ActionsTrueDetailId ?? DBNull.Value; //entity.ActionsTrueDetailId;
                var paramUpdBusiness_Rule = _dataProvider.GetParameter();
                paramUpdBusiness_Rule.ParameterName = "Business_Rule";
                paramUpdBusiness_Rule.DbType = DbType.Int32;
                paramUpdBusiness_Rule.Value = (object)entity.Business_Rule ?? DBNull.Value; //entity.Business_Rule;
                var paramUpdAction_Classification = _dataProvider.GetParameter();
                paramUpdAction_Classification.ParameterName = "Action_Classification";
                paramUpdAction_Classification.DbType = DbType.Int16;
                if (entity.Action_Classification == null)
                    paramUpdAction_Classification.Value = DBNull.Value;
                else
                    paramUpdAction_Classification.Value = entity.Action_Classification;

                var paramUpdAction = _dataProvider.GetParameter();
                paramUpdAction.ParameterName = "Action";
                paramUpdAction.DbType = DbType.Int32;
                if (entity.Action == null)
                    paramUpdAction.Value = DBNull.Value;
                else
                    paramUpdAction.Value = entity.Action;

                var paramUpdAction_Result = _dataProvider.GetParameter();
                paramUpdAction_Result.ParameterName = "Action_Result";
                paramUpdAction_Result.DbType = DbType.Int16;
                if (entity.Action_Result == null)
                    paramUpdAction_Result.Value = DBNull.Value;
                else
                    paramUpdAction_Result.Value = entity.Action_Result;

                var paramUpdParameter_1 = _dataProvider.GetParameter();
                paramUpdParameter_1.ParameterName = "Parameter_1";
                paramUpdParameter_1.DbType = DbType.String;
                paramUpdParameter_1.Value = (object)entity.Parameter_1 ?? DBNull.Value; //entity.Parameter_1;
                var paramUpdParameter_2 = _dataProvider.GetParameter();
                paramUpdParameter_2.ParameterName = "Parameter_2";
                paramUpdParameter_2.DbType = DbType.String;
                paramUpdParameter_2.Value = (object)entity.Parameter_2 ?? DBNull.Value; //entity.Parameter_2;
                var paramUpdParameter_3 = _dataProvider.GetParameter();
                paramUpdParameter_3.ParameterName = "Parameter_3";
                paramUpdParameter_3.DbType = DbType.String;
                paramUpdParameter_3.Value = (object)entity.Parameter_3 ?? DBNull.Value; //entity.Parameter_3;
                var paramUpdParameter_4 = _dataProvider.GetParameter();
                paramUpdParameter_4.ParameterName = "Parameter_4";
                paramUpdParameter_4.DbType = DbType.String;
                paramUpdParameter_4.Value = (object)entity.Parameter_4 ?? DBNull.Value; //entity.Parameter_4;
                var paramUpdParameter_5 = _dataProvider.GetParameter();
                paramUpdParameter_5.ParameterName = "Parameter_5";
                paramUpdParameter_5.DbType = DbType.String;
                paramUpdParameter_5.Value = (object)entity.Parameter_5 ?? DBNull.Value; //entity.Parameter_5;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Actions_True_Detail>("sp_UpdSpartan_BR_Actions_True_Detail", paramUpdActionsTrueDetailId, paramUpdBusiness_Rule, paramUpdAction_Classification, paramUpdAction, paramUpdAction_Result, paramUpdParameter_1, paramUpdParameter_2, paramUpdParameter_3, paramUpdParameter_4, paramUpdParameter_5).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ActionsTrueDetailId);
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


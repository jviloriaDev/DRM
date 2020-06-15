using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Condition_Operator
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Condition_OperatorService : ISpartan_WorkFlow_Condition_OperatorService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> _Spartan_WorkFlow_Condition_OperatorRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Condition_OperatorService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> Spartan_WorkFlow_Condition_OperatorRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Condition_OperatorRepository = Spartan_WorkFlow_Condition_OperatorRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator>("sp_SelAllSpartan_WorkFlow_Condition_Operator");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Condition_Operator_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Condition_Operator");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator
            {
                Condition_OperatorId = m.Condition_OperatorId
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Condition_Operator>("sp_ListSelCount_Spartan_WorkFlow_Condition_Operator", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Condition_Operator>("sp_ListSelAll_Spartan_WorkFlow_Condition_Operator", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator
                {
                    Condition_OperatorId = m.Spartan_WorkFlow_Condition_Operator_Condition_OperatorId,
                    Description = m.Spartan_WorkFlow_Condition_Operator_Description,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_OperatorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Condition_Operator>("sp_ListSelAll_Spartan_WorkFlow_Condition_Operator", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_Condition_OperatorPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_Condition_OperatorPagingModel
                {
                    Spartan_WorkFlow_Condition_Operators =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator
                {
                    Condition_OperatorId = m.Spartan_WorkFlow_Condition_Operator_Condition_OperatorId
                    ,Description = m.Spartan_WorkFlow_Condition_Operator_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Condition_OperatorId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator>("sp_GetSpartan_WorkFlow_Condition_Operator", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Condition_OperatorId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Condition_Operator>("sp_DelSpartan_WorkFlow_Condition_Operator", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator entity)
        {
            int rta;
            try
            {

		                var padreCondition_OperatorId = _dataProvider.GetParameter();
                padreCondition_OperatorId.ParameterName = "Condition_OperatorId";
                padreCondition_OperatorId.DbType = DbType.Int32;
                padreCondition_OperatorId.Value = entity.Condition_OperatorId;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Condition_Operator>("sp_InsSpartan_WorkFlow_Condition_Operator" , padreCondition_OperatorId
, padreDescription
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Condition_OperatorId);

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

        public int Update(Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator entity)
        {
            int rta;
            try
            {

                var paramUpdCondition_OperatorId = _dataProvider.GetParameter();
                paramUpdCondition_OperatorId.ParameterName = "Condition_OperatorId";
                paramUpdCondition_OperatorId.DbType = DbType.Int32;
                paramUpdCondition_OperatorId.Value = (object)entity.Condition_OperatorId ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Condition_Operator>("sp_UpdSpartan_WorkFlow_Condition_Operator" , paramUpdCondition_OperatorId , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Condition_OperatorId);
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

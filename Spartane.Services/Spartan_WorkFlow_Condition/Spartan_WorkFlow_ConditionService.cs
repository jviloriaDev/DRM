using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Condition;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Condition
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_ConditionService : ISpartan_WorkFlow_ConditionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> _Spartan_WorkFlow_ConditionRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_ConditionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> Spartan_WorkFlow_ConditionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_ConditionRepository = Spartan_WorkFlow_ConditionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>("sp_SelAllSpartan_WorkFlow_Condition");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Condition_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Condition");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition
            {
                ConditionId = m.ConditionId
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Condition>("sp_ListSelCount_Spartan_WorkFlow_Condition", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Condition>("sp_ListSelAll_Spartan_WorkFlow_Condition", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition
                {
                    ConditionId = m.Spartan_WorkFlow_Condition_ConditionId,
                    Description = m.Spartan_WorkFlow_Condition_Description,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_ConditionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Condition>("sp_ListSelAll_Spartan_WorkFlow_Condition", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_ConditionPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_ConditionPagingModel
                {
                    Spartan_WorkFlow_Conditions =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition
                {
                    ConditionId = m.Spartan_WorkFlow_Condition_ConditionId
                    ,Description = m.Spartan_WorkFlow_Condition_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ConditionId";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>("sp_GetSpartan_WorkFlow_Condition", padreKey).SingleOrDefault();
        }

        public bool Delete(short Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ConditionId";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Condition>("sp_DelSpartan_WorkFlow_Condition", padreKey).FirstOrDefault();
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

        public short Insert(Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Condition>("sp_InsSpartan_WorkFlow_Condition" 
, padreDescription
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.ConditionId);

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

        public short Update(Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition entity)
        {
            short rta;
            try
            {

                var paramUpdConditionId = _dataProvider.GetParameter();
                paramUpdConditionId.ParameterName = "ConditionId";
                paramUpdConditionId.DbType = DbType.Int16;
                paramUpdConditionId.Value = (object)entity.ConditionId ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Condition>("sp_UpdSpartan_WorkFlow_Condition" , paramUpdConditionId , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.ConditionId);
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

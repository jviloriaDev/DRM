using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Condition;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Condition
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_ConditionService : ISpartan_BR_ConditionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> _Spartan_BR_ConditionRepository;
        #endregion

        #region Ctor
        public Spartan_BR_ConditionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> Spartan_BR_ConditionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_ConditionRepository = Spartan_BR_ConditionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_ConditionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition>("sp_SelAllSpartan_BR_Condition");
        }

        public IList<Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Condition_Complete>("sp_SelAllComplete_Spartan_BR_Condition");
            return data.Select(m => new Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition
            {
                ConditionId = m.ConditionId
                ,Description = m.Description
                ,Implementation_Code = m.Implementation_Code


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Condition>("sp_ListSelCount_Spartan_BR_Condition", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Condition>("sp_ListSelAll_Spartan_BR_Condition", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition
                {
                    ConditionId = m.Spartan_BR_Condition_ConditionId,
                    Description = m.Spartan_BR_Condition_Description,
                    Implementation_Code = m.Spartan_BR_Condition_Implementation_Code,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_ConditionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_ConditionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_ConditionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Condition>("sp_ListSelAll_Spartan_BR_Condition", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_ConditionPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_ConditionPagingModel
                {
                    Spartan_BR_Conditions =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition
                {
                    ConditionId = m.Spartan_BR_Condition_ConditionId
                    ,Description = m.Spartan_BR_Condition_Description
                    ,Implementation_Code = m.Spartan_BR_Condition_Implementation_Code

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_ConditionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ConditionId";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition>("sp_GetSpartan_BR_Condition", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Condition>("sp_DelSpartan_BR_Condition", padreKey).FirstOrDefault();
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

        public short Insert(Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
                var padreImplementation_Code = _dataProvider.GetParameter();
                padreImplementation_Code.ParameterName = "Implementation_Code";
                padreImplementation_Code.DbType = DbType.String;
                padreImplementation_Code.Value = (object)entity.Implementation_Code ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Condition>("sp_InsSpartan_BR_Condition" , padreDescription
, padreImplementation_Code
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

        public short Update(Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition entity)
        {
            short rta;
            try
            {

                var paramUpdConditionId = _dataProvider.GetParameter();
                paramUpdConditionId.ParameterName = "ConditionId";
                paramUpdConditionId.DbType = DbType.Int16;
                paramUpdConditionId.Value = entity.ConditionId;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = entity.Description;
                var paramUpdImplementation_Code = _dataProvider.GetParameter();
                paramUpdImplementation_Code.ParameterName = "Implementation_Code";
                paramUpdImplementation_Code.DbType = DbType.String;
                paramUpdImplementation_Code.Value = entity.Implementation_Code;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Condition>("sp_UpdSpartan_BR_Condition" , paramUpdConditionId , paramUpdDescription , paramUpdImplementation_Code ).FirstOrDefault();

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


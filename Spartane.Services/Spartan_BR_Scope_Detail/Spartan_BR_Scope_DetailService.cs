using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Scope_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Scope_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Scope_DetailService : ISpartan_BR_Scope_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail> _Spartan_BR_Scope_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Scope_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail> Spartan_BR_Scope_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Scope_DetailRepository = Spartan_BR_Scope_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Scope_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail>("sp_SelAllSpartan_BR_Scope_Detail");
        }

        public IList<Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Scope_Detail_Complete>("sp_SelAllComplete_Spartan_BR_Scope_Detail");
            return data.Select(m => new Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail
            {
                ScopeDetailId = m.ScopeDetailId
                ,Business_Rule = m.Business_Rule
                ,Scope_Spartan_BR_Scope = new Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope() { ScopeId = m.Scope.GetValueOrDefault(), Description = m.Scope_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Scope_Detail>("sp_ListSelCount_Spartan_BR_Scope_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Scope_Detail>("sp_ListSelAll_Spartan_BR_Scope_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail
                {
                    ScopeDetailId = m.Spartan_BR_Scope_Detail_ScopeDetailId,
                    Business_Rule = m.Spartan_BR_Scope_Detail_Business_Rule,
                    Scope = m.Spartan_BR_Scope_Detail_Scope,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Scope_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Scope_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Scope_Detail>("sp_ListSelAll_Spartan_BR_Scope_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Scope_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Scope_DetailPagingModel
                {
                    Spartan_BR_Scope_Details =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail
                {
                    ScopeDetailId = m.Spartan_BR_Scope_Detail_ScopeDetailId
                    ,Business_Rule = m.Spartan_BR_Scope_Detail_Business_Rule
                    ,Scope = m.Spartan_BR_Scope_Detail_Scope
                    ,Scope_Spartan_BR_Scope = new Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope() { ScopeId = m.Spartan_BR_Scope_Detail_Scope.GetValueOrDefault(), Description = m.Spartan_BR_Scope_Detail_Scope_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Scope_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ScopeDetailId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail>("sp_GetSpartan_BR_Scope_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ScopeDetailId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Scope_Detail>("sp_DelSpartan_BR_Scope_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail entity)
        {
            int rta;
            try
            {

		                var padreBusiness_Rule = _dataProvider.GetParameter();
                padreBusiness_Rule.ParameterName = "Business_Rule";
                padreBusiness_Rule.DbType = DbType.Int32;
                padreBusiness_Rule.Value = (object)entity.Business_Rule ?? DBNull.Value;
                var padreScope = _dataProvider.GetParameter();
                padreScope.ParameterName = "Scope";
                padreScope.DbType = DbType.Int16;
                padreScope.Value = (object)entity.Scope ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Scope_Detail>("sp_InsSpartan_BR_Scope_Detail" , padreBusiness_Rule
, padreScope
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ScopeDetailId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdScopeDetailId = _dataProvider.GetParameter();
                paramUpdScopeDetailId.ParameterName = "ScopeDetailId";
                paramUpdScopeDetailId.DbType = DbType.Int32;
                paramUpdScopeDetailId.Value = entity.ScopeDetailId;
                var paramUpdBusiness_Rule = _dataProvider.GetParameter();
                paramUpdBusiness_Rule.ParameterName = "Business_Rule";
                paramUpdBusiness_Rule.DbType = DbType.Int32;
                paramUpdBusiness_Rule.Value = entity.Business_Rule;
                var paramUpdScope = _dataProvider.GetParameter();
                paramUpdScope.ParameterName = "Scope";
                paramUpdScope.DbType = DbType.Int16;
                if (entity.Scope == null)
                    paramUpdScope.Value = DBNull.Value;
                else
                    paramUpdScope.Value = entity.Scope;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Scope_Detail>("sp_UpdSpartan_BR_Scope_Detail" , paramUpdScopeDetailId , paramUpdBusiness_Rule ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ScopeDetailId);
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


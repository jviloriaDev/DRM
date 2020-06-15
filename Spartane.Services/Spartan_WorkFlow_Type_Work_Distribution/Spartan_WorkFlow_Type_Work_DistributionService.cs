using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Type_Work_Distribution
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Type_Work_DistributionService : ISpartan_WorkFlow_Type_Work_DistributionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> _Spartan_WorkFlow_Type_Work_DistributionRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Type_Work_DistributionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> Spartan_WorkFlow_Type_Work_DistributionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Type_Work_DistributionRepository = Spartan_WorkFlow_Type_Work_DistributionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_Type_Work_DistributionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>("sp_SelAllSpartan_WorkFlow_Type_Work_Distribution");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Type_Work_Distribution_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Type_Work_Distribution");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution
            {
                Type_of_Work_DistributionId = m.Type_of_Work_DistributionId
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Type_Work_Distribution>("sp_ListSelCount_Spartan_WorkFlow_Type_Work_Distribution", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Type_Work_Distribution>("sp_ListSelAll_Spartan_WorkFlow_Type_Work_Distribution", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution
                {
                    Type_of_Work_DistributionId = m.Spartan_WorkFlow_Type_Work_Distribution_Type_of_Work_DistributionId,
                    Description = m.Spartan_WorkFlow_Type_Work_Distribution_Description,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Type_Work_DistributionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Type_Work_DistributionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_DistributionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Type_Work_Distribution>("sp_ListSelAll_Spartan_WorkFlow_Type_Work_Distribution", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_Type_Work_DistributionPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_Type_Work_DistributionPagingModel
                {
                    Spartan_WorkFlow_Type_Work_Distributions =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution
                {
                    Type_of_Work_DistributionId = m.Spartan_WorkFlow_Type_Work_Distribution_Type_of_Work_DistributionId
                    ,Description = m.Spartan_WorkFlow_Type_Work_Distribution_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Type_Work_DistributionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Type_of_Work_DistributionId";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>("sp_GetSpartan_WorkFlow_Type_Work_Distribution", padreKey).SingleOrDefault();
        }

        public bool Delete(short Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Type_of_Work_DistributionId";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Type_Work_Distribution>("sp_DelSpartan_WorkFlow_Type_Work_Distribution", padreKey).FirstOrDefault();
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

        public short Insert(Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Type_Work_Distribution>("sp_InsSpartan_WorkFlow_Type_Work_Distribution" 
, padreDescription
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Type_of_Work_DistributionId);

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

        public short Update(Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution entity)
        {
            short rta;
            try
            {

                var paramUpdType_of_Work_DistributionId = _dataProvider.GetParameter();
                paramUpdType_of_Work_DistributionId.ParameterName = "Type_of_Work_DistributionId";
                paramUpdType_of_Work_DistributionId.DbType = DbType.Int16;
                paramUpdType_of_Work_DistributionId.Value = (object)entity.Type_of_Work_DistributionId ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Type_Work_Distribution>("sp_UpdSpartan_WorkFlow_Type_Work_Distribution" , paramUpdType_of_Work_DistributionId , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Type_of_Work_DistributionId);
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

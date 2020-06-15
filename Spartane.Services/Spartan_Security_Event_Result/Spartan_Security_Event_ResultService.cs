using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Security_Event_Result;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Security_Event_Result
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Security_Event_ResultService : ISpartan_Security_Event_ResultService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result> _Spartan_Security_Event_ResultRepository;
        #endregion

        #region Ctor
        public Spartan_Security_Event_ResultService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result> Spartan_Security_Event_ResultRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Security_Event_ResultRepository = Spartan_Security_Event_ResultRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Security_Event_ResultRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result>("sp_SelAllSpartan_Security_Event_Result");
        }

        public IList<Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Security_Event_Result_Complete>("sp_SelAllComplete_Spartan_Security_Event_Result");
            return data.Select(m => new Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result
            {
                Security_Event_Result_Id = m.Security_Event_Result_Id
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Security_Event_Result>("sp_ListSelCount_Spartan_Security_Event_Result", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Security_Event_Result>("sp_ListSelAll_Spartan_Security_Event_Result", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result
                {
                    Security_Event_Result_Id = m.Spartan_Security_Event_Result_Security_Event_Result_Id,
                    Description = m.Spartan_Security_Event_Result_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Security_Event_ResultRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Security_Event_ResultRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_ResultPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Security_Event_Result>("sp_ListSelAll_Spartan_Security_Event_Result", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Security_Event_ResultPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Security_Event_ResultPagingModel
                {
                    Spartan_Security_Event_Results =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result
                {
                    Security_Event_Result_Id = m.Spartan_Security_Event_Result_Security_Event_Result_Id
                    ,Description = m.Spartan_Security_Event_Result_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Security_Event_ResultRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Security_Event_Result_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result>("sp_GetSpartan_Security_Event_Result", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Security_Event_Result_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Security_Event_Result>("sp_DelSpartan_Security_Event_Result", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result == 1;
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

        public int Insert(Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Security_Event_Result>("sp_InsSpartan_Security_Event_Result" , padreDescription 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Security_Event_Result_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result entity)
        {
            short rta;
            try
            {

                var padreSecurity_Event_Result_Id = _dataProvider.GetParameter();
                padreSecurity_Event_Result_Id.ParameterName = "Security_Event_Result_Id";
                padreSecurity_Event_Result_Id.DbType = DbType.Int16;
                padreSecurity_Event_Result_Id.Value = entity.Security_Event_Result_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Security_Event_Result>("sp_UpdSpartan_Security_Event_Result" , padreSecurity_Event_Result_Id  , padreDescription  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Security_Event_Result_Id);
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


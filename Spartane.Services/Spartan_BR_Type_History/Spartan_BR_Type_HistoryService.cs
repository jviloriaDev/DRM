using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Type_History;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Type_History
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Type_HistoryService : ISpartan_BR_Type_HistoryService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> _Spartan_BR_Type_HistoryRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Type_HistoryService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> Spartan_BR_Type_HistoryRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Type_HistoryRepository = Spartan_BR_Type_HistoryRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Type_HistoryRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History>("sp_SelAllSpartan_BR_Type_History");
        }

        public IList<Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Type_History_Complete>("sp_SelAllComplete_Spartan_BR_Type_History");
            return data.Select(m => new Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History
            {
                Key_Type_History = m.Key_Type_History
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Type_History>("sp_ListSelCount_Spartan_BR_Type_History", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Type_History>("sp_ListSelAll_Spartan_BR_Type_History", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History
                {
                    Key_Type_History = m.Spartan_BR_Type_History_Key_Type_History,
                    Description = m.Spartan_BR_Type_History_Description,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Type_HistoryRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Type_HistoryRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_HistoryPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Type_History>("sp_ListSelAll_Spartan_BR_Type_History", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Type_HistoryPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Type_HistoryPagingModel
                {
                    Spartan_BR_Type_Historys =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History
                {
                    Key_Type_History = m.Spartan_BR_Type_History_Key_Type_History
                    ,Description = m.Spartan_BR_Type_History_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Type_HistoryRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Key_Type_History";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History>("sp_GetSpartan_BR_Type_History", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Key_Type_History";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Type_History>("sp_DelSpartan_BR_Type_History", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History entity)
        {
            int rta;
            try
            {

		var padreKey_Type_History = _dataProvider.GetParameter();
                padreKey_Type_History.ParameterName = "Key_Type_History";
                padreKey_Type_History.DbType = DbType.Int32;
                padreKey_Type_History.Value = (object)entity.Key_Type_History ?? DBNull.Value;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Type_History>("sp_InsSpartan_BR_Type_History" 
, padreDescription
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Key_Type_History);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History entity)
        {
            int rta;
            try
            {

                var paramUpdKey_Type_History = _dataProvider.GetParameter();
                paramUpdKey_Type_History.ParameterName = "Key_Type_History";
                paramUpdKey_Type_History.DbType = DbType.Int32;
                paramUpdKey_Type_History.Value = (object)entity.Key_Type_History ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Type_History>("sp_UpdSpartan_BR_Type_History" , paramUpdKey_Type_History , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Key_Type_History);
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

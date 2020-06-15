using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Dashboard_Config_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Dashboard_Config_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Dashboard_Config_DetailService : IDashboard_Config_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> _Dashboard_Config_DetailRepository;
        #endregion

        #region Ctor
        public Dashboard_Config_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> Dashboard_Config_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Dashboard_Config_DetailRepository = Dashboard_Config_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Dashboard_Config_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail>("sp_SelAllDashboard_Config_Detail");
        }

        public IList<Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDashboard_Config_Detail_Complete>("sp_SelAllComplete_Dashboard_Config_Detail");
            return data.Select(m => new Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail
            {
                Detail_Id = m.Detail_Id
                ,Dashboard = m.Dashboard
                ,Report_Id = m.Report_Id
                ,Report_Name = m.Report_Name
                ,ConfigRow = m.ConfigRow
                ,ConfigColumn = m.ConfigColumn


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Dashboard_Config_Detail>("sp_ListSelCount_Dashboard_Config_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDashboard_Config_Detail>("sp_ListSelAll_Dashboard_Config_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail
                {
                    Detail_Id = m.Dashboard_Config_Detail_Detail_Id,
                    Dashboard = m.Dashboard_Config_Detail_Dashboard,
                    Report_Id = m.Dashboard_Config_Detail_Report_Id,
                    Report_Name = m.Dashboard_Config_Detail_Report_Name,
                    ConfigRow = m.Dashboard_Config_Detail_ConfigRow,
                    ConfigColumn = m.Dashboard_Config_Detail_ConfigColumn,

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

        public IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Dashboard_Config_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dashboard_Config_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDashboard_Config_Detail>("sp_ListSelAll_Dashboard_Config_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Dashboard_Config_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Dashboard_Config_DetailPagingModel
                {
                    Dashboard_Config_Details =
                        data.Select(m => new Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail
                {
                    Detail_Id = m.Dashboard_Config_Detail_Detail_Id
                    ,Dashboard = m.Dashboard_Config_Detail_Dashboard
                    ,Report_Id = m.Dashboard_Config_Detail_Report_Id
                    ,Report_Name = m.Dashboard_Config_Detail_Report_Name
                    ,ConfigRow = m.Dashboard_Config_Detail_ConfigRow
                    ,ConfigColumn = m.Dashboard_Config_Detail_ConfigColumn

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Dashboard_Config_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Detail_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail>("sp_GetDashboard_Config_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Detail_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDashboard_Config_Detail>("sp_DelDashboard_Config_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail entity)
        {
            int rta;
            try
            {

		var padreDetail_Id = _dataProvider.GetParameter();
                padreDetail_Id.ParameterName = "Detail_Id";
                padreDetail_Id.DbType = DbType.Int32;
                padreDetail_Id.Value = (object)entity.Detail_Id ?? DBNull.Value;
                var padreDashboard = _dataProvider.GetParameter();
                padreDashboard.ParameterName = "Dashboard";
                padreDashboard.DbType = DbType.Int32;
                padreDashboard.Value = (object)entity.Dashboard ?? DBNull.Value;
                var padreReport_Id = _dataProvider.GetParameter();
                padreReport_Id.ParameterName = "Report_Id";
                padreReport_Id.DbType = DbType.Int32;
                padreReport_Id.Value = (object)entity.Report_Id ?? DBNull.Value;

                var padreReport_Name = _dataProvider.GetParameter();
                padreReport_Name.ParameterName = "Report_Name";
                padreReport_Name.DbType = DbType.String;
                padreReport_Name.Value = (object)entity.Report_Name ?? DBNull.Value;
                var padreConfigRow = _dataProvider.GetParameter();
                padreConfigRow.ParameterName = "ConfigRow";
                padreConfigRow.DbType = DbType.Int16;
                padreConfigRow.Value = (object)entity.ConfigRow ?? DBNull.Value;

                var padreConfigColumn = _dataProvider.GetParameter();
                padreConfigColumn.ParameterName = "ConfigColumn";
                padreConfigColumn.DbType = DbType.Int16;
                padreConfigColumn.Value = (object)entity.ConfigColumn ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDashboard_Config_Detail>("sp_InsDashboard_Config_Detail" , padreDashboard
, padreReport_Id
, padreReport_Name
, padreConfigRow
, padreConfigColumn
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Detail_Id);

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

        public int Update(Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdDetail_Id = _dataProvider.GetParameter();
                paramUpdDetail_Id.ParameterName = "Detail_Id";
                paramUpdDetail_Id.DbType = DbType.Int32;
                paramUpdDetail_Id.Value = (object)entity.Detail_Id ?? DBNull.Value;
                var paramUpdDashboard = _dataProvider.GetParameter();
                paramUpdDashboard.ParameterName = "Dashboard";
                paramUpdDashboard.DbType = DbType.Int32;
                paramUpdDashboard.Value = (object)entity.Dashboard ?? DBNull.Value;
                var paramUpdReport_Id = _dataProvider.GetParameter();
                paramUpdReport_Id.ParameterName = "Report_Id";
                paramUpdReport_Id.DbType = DbType.Int32;
                paramUpdReport_Id.Value = (object)entity.Report_Id ?? DBNull.Value;

                var paramUpdReport_Name = _dataProvider.GetParameter();
                paramUpdReport_Name.ParameterName = "Report_Name";
                paramUpdReport_Name.DbType = DbType.String;
                paramUpdReport_Name.Value = (object)entity.Report_Name ?? DBNull.Value;
                var paramUpdConfigRow = _dataProvider.GetParameter();
                paramUpdConfigRow.ParameterName = "ConfigRow";
                paramUpdConfigRow.DbType = DbType.Int16;
                paramUpdConfigRow.Value = (object)entity.ConfigRow ?? DBNull.Value;

                var paramUpdConfigColumn = _dataProvider.GetParameter();
                paramUpdConfigColumn.ParameterName = "ConfigColumn";
                paramUpdConfigColumn.DbType = DbType.Int16;
                paramUpdConfigColumn.Value = (object)entity.ConfigColumn ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDashboard_Config_Detail>("sp_UpdDashboard_Config_Detail" , paramUpdDetail_Id , paramUpdDashboard , paramUpdReport_Id , paramUpdReport_Name , paramUpdConfigRow , paramUpdConfigColumn ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Detail_Id);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail Dashboard_Config_DetailDB = GetByKey(entity.Detail_Id, false);
                var paramUpdDetail_Id = _dataProvider.GetParameter();
                paramUpdDetail_Id.ParameterName = "Detail_Id";
                paramUpdDetail_Id.DbType = DbType.Int32;
                paramUpdDetail_Id.Value = (object)entity.Detail_Id ?? DBNull.Value;
                var paramUpdDashboard = _dataProvider.GetParameter();
                paramUpdDashboard.ParameterName = "Dashboard";
                paramUpdDashboard.DbType = DbType.Int32;
                paramUpdDashboard.Value = (object)entity.Dashboard ?? DBNull.Value;
                var paramUpdReport_Id = _dataProvider.GetParameter();
                paramUpdReport_Id.ParameterName = "Report_Id";
                paramUpdReport_Id.DbType = DbType.Int32;
                paramUpdReport_Id.Value = (object)entity.Report_Id ?? DBNull.Value;
                var paramUpdReport_Name = _dataProvider.GetParameter();
                paramUpdReport_Name.ParameterName = "Report_Name";
                paramUpdReport_Name.DbType = DbType.String;
                paramUpdReport_Name.Value = (object)entity.Report_Name ?? DBNull.Value;
                var paramUpdConfigRow = _dataProvider.GetParameter();
                paramUpdConfigRow.ParameterName = "ConfigRow";
                paramUpdConfigRow.DbType = DbType.Int16;
                paramUpdConfigRow.Value = (object)entity.ConfigRow ?? DBNull.Value;
                var paramUpdConfigColumn = _dataProvider.GetParameter();
                paramUpdConfigColumn.ParameterName = "ConfigColumn";
                paramUpdConfigColumn.DbType = DbType.Int16;
                paramUpdConfigColumn.Value = (object)entity.ConfigColumn ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDashboard_Config_Detail>("sp_UpdDashboard_Config_Detail" , paramUpdDetail_Id , paramUpdDashboard , paramUpdReport_Id , paramUpdReport_Name , paramUpdConfigRow , paramUpdConfigColumn ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Detail_Id);
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


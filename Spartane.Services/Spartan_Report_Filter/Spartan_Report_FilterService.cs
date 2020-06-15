using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Report_Filter;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Filter
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_FilterService : ISpartan_Report_FilterService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter> _Spartan_Report_FilterRepository;
        #endregion

        #region Ctor
        public Spartan_Report_FilterService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter> Spartan_Report_FilterRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_FilterRepository = Spartan_Report_FilterRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Report_FilterRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter>("sp_SelAllSpartan_Report_Filter");
        }

        public IList<Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Report_Filter_Complete>("sp_SelAllComplete_Spartan_Report_Filter");
            return data.Select(m => new Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter
            {
                ReportFilterId = m.ReportFilterId
                ,Report = m.Report
                ,Field_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Field.GetValueOrDefault(), Logical_Name = m.Field_Logical_Name }
                ,QuickFilter = m.QuickFilter.GetValueOrDefault()
                ,AdvanceFilter = m.AdvanceFilter.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Report_Filter>("sp_ListSelCount_Spartan_Report_Filter", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Filter>("sp_ListSelAll_Spartan_Report_Filter", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter
                {
                    ReportFilterId = m.Spartan_Report_Filter_ReportFilterId,
                    Report = m.Spartan_Report_Filter_Report,
                    Field = m.Spartan_Report_Filter_Field,
                    QuickFilter = m.Spartan_Report_Filter_QuickFilter ?? false,
                    AdvanceFilter = m.Spartan_Report_Filter_AdvanceFilter ?? false,

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

        public IList<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_FilterRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_FilterRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_FilterPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Filter>("sp_ListSelAll_Spartan_Report_Filter", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Report_FilterPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Report_FilterPagingModel
                {
                    Spartan_Report_Filters =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter
                {
                    ReportFilterId = m.Spartan_Report_Filter_ReportFilterId
                    ,Report = m.Spartan_Report_Filter_Report
                    ,Field = m.Spartan_Report_Filter_Field
                    ,Field_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Spartan_Report_Filter_Field.GetValueOrDefault(), Logical_Name = m.Spartan_Report_Filter_Field_Logical_Name }
                    ,QuickFilter = m.Spartan_Report_Filter_QuickFilter ?? false
                    ,AdvanceFilter = m.Spartan_Report_Filter_AdvanceFilter ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_FilterRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ReportFilterId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter>("sp_GetSpartan_Report_Filter", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ReportFilterId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Report_Filter>("sp_DelSpartan_Report_Filter", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter entity)
        {
            int rta;
            try
            {

		var padreReportFilterId = _dataProvider.GetParameter();
                padreReportFilterId.ParameterName = "ReportFilterId";
                padreReportFilterId.DbType = DbType.Int32;
                padreReportFilterId.Value = (object)entity.ReportFilterId ?? DBNull.Value;
                var padreReport = _dataProvider.GetParameter();
                padreReport.ParameterName = "Report";
                padreReport.DbType = DbType.Int32;
                padreReport.Value = (object)entity.Report ?? DBNull.Value;
                var padreField = _dataProvider.GetParameter();
                padreField.ParameterName = "Field";
                padreField.DbType = DbType.Int32;
                padreField.Value = (object)entity.Field ?? DBNull.Value;

                var padreQuickFilter = _dataProvider.GetParameter();
                padreQuickFilter.ParameterName = "QuickFilter";
                padreQuickFilter.DbType = DbType.Boolean;
                padreQuickFilter.Value = (object)entity.QuickFilter ?? DBNull.Value;
                var padreAdvanceFilter = _dataProvider.GetParameter();
                padreAdvanceFilter.ParameterName = "AdvanceFilter";
                padreAdvanceFilter.DbType = DbType.Boolean;
                padreAdvanceFilter.Value = (object)entity.AdvanceFilter ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Report_Filter>("sp_InsSpartan_Report_Filter" 
, padreReport
, padreField
, padreQuickFilter
, padreAdvanceFilter
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ReportFilterId);

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

        public int Update(Spartane.Core.Classes.Spartan_Report_Filter.Spartan_Report_Filter entity)
        {
            int rta;
            try
            {

                var paramUpdReportFilterId = _dataProvider.GetParameter();
                paramUpdReportFilterId.ParameterName = "ReportFilterId";
                paramUpdReportFilterId.DbType = DbType.Int32;
                paramUpdReportFilterId.Value = (object)entity.ReportFilterId ?? DBNull.Value;
                var paramUpdReport = _dataProvider.GetParameter();
                paramUpdReport.ParameterName = "Report";
                paramUpdReport.DbType = DbType.Int32;
                paramUpdReport.Value = (object)entity.Report ?? DBNull.Value;
                var paramUpdField = _dataProvider.GetParameter();
                paramUpdField.ParameterName = "Field";
                paramUpdField.DbType = DbType.Int32;
                paramUpdField.Value = (object)entity.Field ?? DBNull.Value;

                var paramUpdQuickFilter = _dataProvider.GetParameter();
                paramUpdQuickFilter.ParameterName = "QuickFilter";
                paramUpdQuickFilter.DbType = DbType.Boolean;
                paramUpdQuickFilter.Value = (object)entity.QuickFilter ?? DBNull.Value;
                var paramUpdAdvanceFilter = _dataProvider.GetParameter();
                paramUpdAdvanceFilter.ParameterName = "AdvanceFilter";
                paramUpdAdvanceFilter.DbType = DbType.Boolean;
                paramUpdAdvanceFilter.Value = (object)entity.AdvanceFilter ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Report_Filter>("sp_UpdSpartan_Report_Filter" , paramUpdReportFilterId , paramUpdReport , paramUpdField , paramUpdQuickFilter , paramUpdAdvanceFilter ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ReportFilterId);
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

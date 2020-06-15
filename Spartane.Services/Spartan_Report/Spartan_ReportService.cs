using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Report;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_ReportService : ISpartan_ReportService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Report.Spartan_Report> _Spartan_ReportRepository;
        #endregion

        #region Ctor
        public Spartan_ReportService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Report.Spartan_Report> Spartan_ReportRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_ReportRepository = Spartan_ReportRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_ReportRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report.Spartan_Report>("sp_SelAllSpartan_Report");
        }

        public IList<Core.Classes.Spartan_Report.Spartan_Report> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Report_Complete>("sp_SelAllComplete_Spartan_Report");
            return data.Select(m => new Core.Classes.Spartan_Report.Spartan_Report
            {
                ReportId = m.ReportId
                ,Registration_Date = m.Registration_Date
                ,Registration_Hour = m.Registration_Hour
                ,Registration_User = m.Registration_User
                ,Object = m.Object
                ,Report_Name = m.Report_Name
                ,Presentation_Type_Spartan_Report_Presentation_Type = new Core.Classes.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type() { PresentationTypeId = m.Presentation_Type.GetValueOrDefault(), Description = m.Presentation_Type_Description }
                ,Presentation_View_Spartan_Report_Presentation_View = new Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View() { PresentationViewId = m.Presentation_View.GetValueOrDefault(), Description = m.Presentation_View_Description }
                ,Status_Spartan_Report_Status = new Core.Classes.Spartan_Report_Status.Spartan_Report_Status() { StatusId = m.Status.GetValueOrDefault(), Description = m.Status_Description }
                ,Query = m.Query
                ,Filters = m.Filters
                ,Header = m.Header
                ,Footer = m.Footer
                ,
                TotalColumns = m.TotalColumns
                    ,
                TotalRows = m.TotalRows

            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Report>("sp_ListSelCount_Spartan_Report", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report>("sp_ListSelAll_Spartan_Report", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Report.Spartan_Report
                {
                    ReportId = m.Spartan_Report_ReportId,
                    Registration_Date = m.Spartan_Report_Registration_Date,
                    Registration_Hour = m.Spartan_Report_Registration_Hour,
                    Registration_User = m.Spartan_Report_Registration_User,
                    Object = m.Spartan_Report_Object,
                    Report_Name = m.Spartan_Report_Report_Name,
                    Presentation_Type = m.Spartan_Report_Presentation_Type,
                    Presentation_View = m.Spartan_Report_Presentation_View,
                    Status = m.Spartan_Report_Status,
                    Query = m.Spartan_Report_Query,
                    Filters = m.Spartan_Report_Filters,
                    Header = m.Spartan_Report_Header,
                    Footer = m.Spartan_Report_Footer,
                    TotalColumns = m.Spartan_Report_TotalColumns,
                    TotalRows = m.Spartan_Report_TotalRows,

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

        public IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_ReportRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_ReportRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report.Spartan_ReportPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report>("sp_ListSelAll_Spartan_Report", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_ReportPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_ReportPagingModel
                {
                    Spartan_Reports =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Report.Spartan_Report
                {
                    ReportId = m.Spartan_Report_ReportId
                    ,Registration_Date = m.Spartan_Report_Registration_Date
                    ,Registration_Hour = m.Spartan_Report_Registration_Hour
                    ,Registration_User = m.Spartan_Report_Registration_User
                    ,Object = m.Spartan_Report_Object
                    ,Report_Name = m.Spartan_Report_Report_Name
                    ,Presentation_Type = m.Spartan_Report_Presentation_Type
                    ,Presentation_Type_Spartan_Report_Presentation_Type = new Core.Classes.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type() { PresentationTypeId = m.Spartan_Report_Presentation_Type.GetValueOrDefault(), Description = m.Spartan_Report_Presentation_Type_Description }
                    ,Presentation_View = m.Spartan_Report_Presentation_View
                    ,Presentation_View_Spartan_Report_Presentation_View = new Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View() { PresentationViewId = m.Spartan_Report_Presentation_View.GetValueOrDefault(), Description = m.Spartan_Report_Presentation_View_Description }
                    ,Status = m.Spartan_Report_Status
                    ,Status_Spartan_Report_Status = new Core.Classes.Spartan_Report_Status.Spartan_Report_Status() { StatusId = m.Spartan_Report_Status.GetValueOrDefault(), Description = m.Spartan_Report_Status_Description }
                    ,Query = m.Spartan_Report_Query
                    ,Filters = m.Spartan_Report_Filters
                    ,Header = m.Spartan_Report_Header
                    ,Footer = m.Spartan_Report_Footer
                    ,Spartan_Object_Spartan_Report_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Report_Object ?? 0, Name = m.Spartan_Report_Object_Name }
                    ,User_Spartan_Report_User = new Core.Classes.Spartan_User.Spartan_User { Id_User = Convert.ToInt32(m.Spartan_Report_Registration_User), Name = m.Spartan_Report_Registration_User_Name, Role = 0, Status = 0 }
                    , TotalColumns = m.Spartan_Report_TotalColumns
                    , TotalRows = m.Spartan_Report_TotalRows
                            //,Id = m.Id
                        }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_ReportRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report.Spartan_Report GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ReportId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report.Spartan_Report>("sp_GetSpartan_Report", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ReportId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Report>("sp_DelSpartan_Report", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Report.Spartan_Report entity)
        {
            int rta;
            try
            {

		                var padreRegistration_Date = _dataProvider.GetParameter();
                padreRegistration_Date.ParameterName = "Registration_Date";
                padreRegistration_Date.DbType = DbType.DateTime;
                padreRegistration_Date.Value = (object)entity.Registration_Date ?? DBNull.Value;

                var padreRegistration_Hour = _dataProvider.GetParameter();
                padreRegistration_Hour.ParameterName = "Registration_Hour";
                padreRegistration_Hour.DbType = DbType.String;
                padreRegistration_Hour.Value = (object)entity.Registration_Hour ?? DBNull.Value;
                var padreRegistration_User = _dataProvider.GetParameter();
                padreRegistration_User.ParameterName = "Registration_User";
                padreRegistration_User.DbType = DbType.Int32;
                padreRegistration_User.Value = (object)entity.Registration_User ?? DBNull.Value;

                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                padreObject.Value = (object)entity.Object ?? DBNull.Value;

                var padreReport_Name = _dataProvider.GetParameter();
                padreReport_Name.ParameterName = "Report_Name";
                padreReport_Name.DbType = DbType.String;
                padreReport_Name.Value = (object)entity.Report_Name ?? DBNull.Value;
                var padrePresentation_Type = _dataProvider.GetParameter();
                padrePresentation_Type.ParameterName = "Presentation_Type";
                padrePresentation_Type.DbType = DbType.Int32;
                padrePresentation_Type.Value = (object)entity.Presentation_Type ?? DBNull.Value;

                var padrePresentation_View = _dataProvider.GetParameter();
                padrePresentation_View.ParameterName = "Presentation_View";
                padrePresentation_View.DbType = DbType.Int32;
                padrePresentation_View.Value = (object)entity.Presentation_View ?? DBNull.Value;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                padreStatus.Value = (object)entity.Status ?? DBNull.Value;

                var padreQuery = _dataProvider.GetParameter();
                padreQuery.ParameterName = "Query";
                padreQuery.DbType = DbType.String;
                padreQuery.Value = (object)entity.Query ?? DBNull.Value;
                var padreFilters = _dataProvider.GetParameter();
                padreFilters.ParameterName = "Filters";
                padreFilters.DbType = DbType.String;
                padreFilters.Value = (object)entity.Filters ?? DBNull.Value;
                var padreHeader = _dataProvider.GetParameter();
                padreHeader.ParameterName = "Header";
                padreHeader.DbType = DbType.String;
                padreHeader.Value = (object)entity.Header ?? DBNull.Value;
                var padreFooter = _dataProvider.GetParameter();
                padreFooter.ParameterName = "Footer";
                padreFooter.DbType = DbType.String;
                padreFooter.Value = (object)entity.Footer ?? DBNull.Value;
                var padreTotalColumns = _dataProvider.GetParameter();
                padreTotalColumns.ParameterName = "TotalColumns";
                padreTotalColumns.DbType = DbType.Boolean;
                padreTotalColumns.Value = (object)entity.TotalColumns ?? DBNull.Value;
                var padreTotalRows = _dataProvider.GetParameter();
                padreTotalRows.ParameterName = "TotalRows";
                padreTotalRows.DbType = DbType.Boolean;
                padreTotalRows.Value = (object)entity.TotalRows ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Report>("sp_InsSpartan_Report" 
, padreRegistration_Date
, padreRegistration_Hour
, padreRegistration_User
, padreObject
, padreReport_Name
, padrePresentation_Type
, padrePresentation_View
, padreStatus
, padreQuery

, padreFilters
, padreHeader
, padreFooter
, padreTotalColumns
, padreTotalRows
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ReportId);

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

        public int Update(Spartane.Core.Classes.Spartan_Report.Spartan_Report entity)
        {
            int rta;
            try
            {

                var paramUpdReportId = _dataProvider.GetParameter();
                paramUpdReportId.ParameterName = "ReportId";
                paramUpdReportId.DbType = DbType.Int32;
                paramUpdReportId.Value = (object)entity.ReportId ?? DBNull.Value;
                var paramUpdRegistration_Date = _dataProvider.GetParameter();
                paramUpdRegistration_Date.ParameterName = "Registration_Date";
                paramUpdRegistration_Date.DbType = DbType.DateTime;
                paramUpdRegistration_Date.Value = (object)entity.Registration_Date ?? DBNull.Value;

                var paramUpdRegistration_Hour = _dataProvider.GetParameter();
                paramUpdRegistration_Hour.ParameterName = "Registration_Hour";
                paramUpdRegistration_Hour.DbType = DbType.String;
                paramUpdRegistration_Hour.Value = (object)entity.Registration_Hour ?? DBNull.Value;
                var paramUpdRegistration_User = _dataProvider.GetParameter();
                paramUpdRegistration_User.ParameterName = "Registration_User";
                paramUpdRegistration_User.DbType = DbType.Int32;
                paramUpdRegistration_User.Value = (object)entity.Registration_User ?? DBNull.Value;

                var paramUpdObject = _dataProvider.GetParameter();
                paramUpdObject.ParameterName = "Object";
                paramUpdObject.DbType = DbType.Int32;
                paramUpdObject.Value = (object)entity.Object ?? DBNull.Value;

                var paramUpdReport_Name = _dataProvider.GetParameter();
                paramUpdReport_Name.ParameterName = "Report_Name";
                paramUpdReport_Name.DbType = DbType.String;
                paramUpdReport_Name.Value = (object)entity.Report_Name ?? DBNull.Value;
                var paramUpdPresentation_Type = _dataProvider.GetParameter();
                paramUpdPresentation_Type.ParameterName = "Presentation_Type";
                paramUpdPresentation_Type.DbType = DbType.Int32;
                paramUpdPresentation_Type.Value = (object)entity.Presentation_Type ?? DBNull.Value;

                var paramUpdPresentation_View = _dataProvider.GetParameter();
                paramUpdPresentation_View.ParameterName = "Presentation_View";
                paramUpdPresentation_View.DbType = DbType.Int32;
                paramUpdPresentation_View.Value = (object)entity.Presentation_View ?? DBNull.Value;

                var paramUpdStatus = _dataProvider.GetParameter();
                paramUpdStatus.ParameterName = "Status";
                paramUpdStatus.DbType = DbType.Int16;
                paramUpdStatus.Value = (object)entity.Status ?? DBNull.Value;

                var paramUpdQuery = _dataProvider.GetParameter();
                paramUpdQuery.ParameterName = "Query";
                paramUpdQuery.DbType = DbType.String;
                paramUpdQuery.Value = (object)entity.Query ?? DBNull.Value;
                var paramUpdFilters = _dataProvider.GetParameter();
                paramUpdFilters.ParameterName = "Filters";
                paramUpdFilters.DbType = DbType.String;
                paramUpdFilters.Value = (object)entity.Filters ?? DBNull.Value;
                var paramUpdHeader = _dataProvider.GetParameter();
                paramUpdHeader.ParameterName = "Header";
                paramUpdHeader.DbType = DbType.String;
                paramUpdHeader.Value = (object)entity.Header ?? DBNull.Value;
                var paramUpdFooter = _dataProvider.GetParameter();
                paramUpdFooter.ParameterName = "Footer";
                paramUpdFooter.DbType = DbType.String;
                paramUpdFooter.Value = (object)entity.Footer ?? DBNull.Value;
                var paramUpdTotalColumns = _dataProvider.GetParameter();
                paramUpdTotalColumns.ParameterName = "TotalColumns";
                paramUpdTotalColumns.DbType = DbType.Boolean;
                paramUpdTotalColumns.Value = (object)entity.TotalColumns ?? DBNull.Value;
                var paramUpdTotalRows = _dataProvider.GetParameter();
                paramUpdTotalRows.ParameterName = "TotalRows";
                paramUpdTotalRows.DbType = DbType.Boolean;
                paramUpdTotalRows.Value = (object)entity.TotalRows ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Report>("sp_UpdSpartan_Report", paramUpdReportId, paramUpdRegistration_Date, paramUpdRegistration_Hour, paramUpdRegistration_User, paramUpdObject, paramUpdReport_Name, paramUpdPresentation_Type, paramUpdPresentation_View, paramUpdStatus, paramUpdQuery, paramUpdFilters, paramUpdHeader, paramUpdFooter, paramUpdTotalColumns, paramUpdTotalRows).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ReportId);
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

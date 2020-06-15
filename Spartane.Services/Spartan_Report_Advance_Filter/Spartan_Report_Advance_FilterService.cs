using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Report_Advance_Filter;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Advance_Filter
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_Advance_FilterService : ISpartan_Report_Advance_FilterService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> _Spartan_Report_Advance_FilterRepository;
        #endregion

        #region Ctor
        public Spartan_Report_Advance_FilterService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> Spartan_Report_Advance_FilterRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_Advance_FilterRepository = Spartan_Report_Advance_FilterRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter>("sp_SelAllSpartan_Report_Advance_Filter");
        }

        public IList<Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Report_Advance_Filter_Complete>("sp_SelAllComplete_Spartan_Report_Advance_Filter");
            return data.Select(m => new Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter
            {
                Clave = m.Clave
                ,Report_Spartan_Report = new Core.Classes.Spartan_Report.Spartan_Report() { ReportId = m.Report.GetValueOrDefault(), Report_Name = m.Report_Report_Name }
                ,AttributeId_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.AttributeId.GetValueOrDefault(), Physical_Name = m.AttributeId_Physical_Name }
                ,Defect_Value_From = m.Defect_Value_From
                ,Defect_Value_To = m.Defect_Value_To


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Report_Advance_Filter>("sp_ListSelCount_Spartan_Report_Advance_Filter", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Advance_Filter>("sp_ListSelAll_Spartan_Report_Advance_Filter", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter
                {
                    Clave = m.Spartan_Report_Advance_Filter_Clave,
                    Report = m.Spartan_Report_Advance_Filter_Report,
                    AttributeId = m.Spartan_Report_Advance_Filter_AttributeId,
                    Defect_Value_From = m.Spartan_Report_Advance_Filter_Defect_Value_From,
                    Defect_Value_To = m.Spartan_Report_Advance_Filter_Defect_Value_To,
                    PathField = m.Spartan_Report_Advance_Filter_PathField,
                    CampoQuery = m.Spartan_Report_Advance_Filter_CampoQuery,

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

        public IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_FilterPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Advance_Filter>("sp_ListSelAll_Spartan_Report_Advance_Filter", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Report_Advance_FilterPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Report_Advance_FilterPagingModel
                {
                    Spartan_Report_Advance_Filters =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter
                {
                    Clave = m.Spartan_Report_Advance_Filter_Clave
                    ,Report = m.Spartan_Report_Advance_Filter_Report
                    ,Report_Spartan_Report = new Core.Classes.Spartan_Report.Spartan_Report() { ReportId = m.Spartan_Report_Advance_Filter_Report.GetValueOrDefault(), Report_Name = m.Spartan_Report_Advance_Filter_Report_Report_Name }
                    ,AttributeId = m.Spartan_Report_Advance_Filter_AttributeId
                    ,AttributeId_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Spartan_Report_Advance_Filter_AttributeId.GetValueOrDefault(), Physical_Name = m.Spartan_Report_Advance_Filter_AttributeId_Physical_Name }
                    ,Defect_Value_From = m.Spartan_Report_Advance_Filter_Defect_Value_From
                    ,
                    Defect_Value_To = m.Spartan_Report_Advance_Filter_Defect_Value_To
                    ,
                    ObjectId = m.Spartan_Report_Advance_Filter_ObjectId,
                    PathField = m.Spartan_Report_Advance_Filter_PathField,
                    CampoQuery = m.Spartan_Report_Advance_Filter_CampoQuery,
                    Visible = m.Spartan_Report_Advance_Filter_Visible

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter>("sp_GetSpartan_Report_Advance_Filter", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Report_Advance_Filter>("sp_DelSpartan_Report_Advance_Filter", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter entity)
        {
            int rta;
            try
            {

		                var padreReport = _dataProvider.GetParameter();
                padreReport.ParameterName = "Report";
                padreReport.DbType = DbType.Int32;
                padreReport.Value = (object)entity.Report ?? DBNull.Value;

                var padreAttributeId = _dataProvider.GetParameter();
                padreAttributeId.ParameterName = "AttributeId";
                padreAttributeId.DbType = DbType.Int32;
                padreAttributeId.Value = (object)entity.AttributeId ?? DBNull.Value;

                var padreObjectId = _dataProvider.GetParameter();
                padreObjectId.ParameterName = "ObjectId";
                padreObjectId.DbType = DbType.Int32;
                padreObjectId.Value = (object)entity.ObjectId ?? DBNull.Value;

                var padreDefect_Value_From = _dataProvider.GetParameter();
                padreDefect_Value_From.ParameterName = "Defect_Value_From";
                padreDefect_Value_From.DbType = DbType.String;
                padreDefect_Value_From.Value = (object)entity.Defect_Value_From ?? DBNull.Value;
                var padreDefect_Value_To = _dataProvider.GetParameter();
                padreDefect_Value_To.ParameterName = "Defect_Value_To";
                padreDefect_Value_To.DbType = DbType.String;
                padreDefect_Value_To.Value = (object)entity.Defect_Value_To ?? DBNull.Value;
                var padrePathField = _dataProvider.GetParameter();
                padrePathField.ParameterName = "PathField";
                padrePathField.DbType = DbType.String;
                padrePathField.Value = (object)entity.PathField ?? DBNull.Value;
                var padreVisible = _dataProvider.GetParameter();
                padreVisible.ParameterName = "Visible";
                padreVisible.DbType = DbType.Boolean;
                padreVisible.Value = (object)entity.Visible ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Report_Advance_Filter>("sp_InsSpartan_Report_Advance_Filter" 
, padreReport
, padreAttributeId
, padreDefect_Value_From
, padreDefect_Value_To
, padreObjectId
, padrePathField
, padreVisible
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

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

        public int Update(Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdReport = _dataProvider.GetParameter();
                paramUpdReport.ParameterName = "Report";
                paramUpdReport.DbType = DbType.Int32;
                paramUpdReport.Value = (object)entity.Report ?? DBNull.Value;

                var paramUpdAttributeId = _dataProvider.GetParameter();
                paramUpdAttributeId.ParameterName = "AttributeId";
                paramUpdAttributeId.DbType = DbType.Int32;
                paramUpdAttributeId.Value = (object)entity.AttributeId ?? DBNull.Value;

                var paramUpdDefect_Value_From = _dataProvider.GetParameter();
                paramUpdDefect_Value_From.ParameterName = "Defect_Value_From";
                paramUpdDefect_Value_From.DbType = DbType.String;
                paramUpdDefect_Value_From.Value = (object)entity.Defect_Value_From ?? DBNull.Value;
                var paramUpdDefect_Value_To = _dataProvider.GetParameter();
                paramUpdDefect_Value_To.ParameterName = "Defect_Value_To";
                paramUpdDefect_Value_To.DbType = DbType.String;
                paramUpdDefect_Value_To.Value = (object)entity.Defect_Value_To ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Report_Advance_Filter>("sp_UpdSpartan_Report_Advance_Filter" , paramUpdClave , paramUpdReport , paramUpdAttributeId , paramUpdDefect_Value_From , paramUpdDefect_Value_To ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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

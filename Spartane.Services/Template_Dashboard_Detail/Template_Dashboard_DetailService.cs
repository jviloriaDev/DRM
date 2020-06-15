using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Template_Dashboard_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Template_Dashboard_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Template_Dashboard_DetailService : ITemplate_Dashboard_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail> _Template_Dashboard_DetailRepository;
        #endregion

        #region Ctor
        public Template_Dashboard_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail> Template_Dashboard_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Template_Dashboard_DetailRepository = Template_Dashboard_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Template_Dashboard_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail>("sp_SelAllTemplate_Dashboard_Detail");
        }

        public IList<Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTemplate_Dashboard_Detail_Complete>("sp_SelAllComplete_Template_Dashboard_Detail");
            return data.Select(m => new Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail
            {
                Detail_Id = m.Detail_Id
                ,Template = m.Template
                ,Row_Number = m.Row_Number
                ,Columns = m.Columns


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Template_Dashboard_Detail>("sp_ListSelCount_Template_Dashboard_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTemplate_Dashboard_Detail>("sp_ListSelAll_Template_Dashboard_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail
                {
                    Detail_Id = m.Template_Dashboard_Detail_Detail_Id,
                    Template = m.Template_Dashboard_Detail_Template,
                    Row_Number = m.Template_Dashboard_Detail_Row_Number,
                    Columns = m.Template_Dashboard_Detail_Columns,

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

        public IList<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Template_Dashboard_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Template_Dashboard_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTemplate_Dashboard_Detail>("sp_ListSelAll_Template_Dashboard_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Template_Dashboard_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Template_Dashboard_DetailPagingModel
                {
                    Template_Dashboard_Details =
                        data.Select(m => new Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail
                {
                    Detail_Id = m.Template_Dashboard_Detail_Detail_Id
                    ,Template = m.Template_Dashboard_Detail_Template
                    ,Row_Number = m.Template_Dashboard_Detail_Row_Number
                    ,Columns = m.Template_Dashboard_Detail_Columns

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Template_Dashboard_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Detail_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail>("sp_GetTemplate_Dashboard_Detail", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTemplate_Dashboard_Detail>("sp_DelTemplate_Dashboard_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail entity)
        {
            int rta;
            try
            {

		var padreDetail_Id = _dataProvider.GetParameter();
                padreDetail_Id.ParameterName = "Detail_Id";
                padreDetail_Id.DbType = DbType.Int32;
                padreDetail_Id.Value = (object)entity.Detail_Id ?? DBNull.Value;
                var padreTemplate = _dataProvider.GetParameter();
                padreTemplate.ParameterName = "Template";
                padreTemplate.DbType = DbType.Int32;
                padreTemplate.Value = (object)entity.Template ?? DBNull.Value;
                var padreRow_Number = _dataProvider.GetParameter();
                padreRow_Number.ParameterName = "Row_Number";
                padreRow_Number.DbType = DbType.Int16;
                padreRow_Number.Value = (object)entity.Row_Number ?? DBNull.Value;

                var padreColumns = _dataProvider.GetParameter();
                padreColumns.ParameterName = "Columns";
                padreColumns.DbType = DbType.Int16;
                padreColumns.Value = (object)entity.Columns ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTemplate_Dashboard_Detail>("sp_InsTemplate_Dashboard_Detail" , padreTemplate
, padreRow_Number
, padreColumns
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

        public int Update(Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdDetail_Id = _dataProvider.GetParameter();
                paramUpdDetail_Id.ParameterName = "Detail_Id";
                paramUpdDetail_Id.DbType = DbType.Int32;
                paramUpdDetail_Id.Value = (object)entity.Detail_Id ?? DBNull.Value;
                var paramUpdTemplate = _dataProvider.GetParameter();
                paramUpdTemplate.ParameterName = "Template";
                paramUpdTemplate.DbType = DbType.Int32;
                paramUpdTemplate.Value = (object)entity.Template ?? DBNull.Value;
                var paramUpdRow_Number = _dataProvider.GetParameter();
                paramUpdRow_Number.ParameterName = "Row_Number";
                paramUpdRow_Number.DbType = DbType.Int16;
                paramUpdRow_Number.Value = (object)entity.Row_Number ?? DBNull.Value;

                var paramUpdColumns = _dataProvider.GetParameter();
                paramUpdColumns.ParameterName = "Columns";
                paramUpdColumns.DbType = DbType.Int16;
                paramUpdColumns.Value = (object)entity.Columns ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTemplate_Dashboard_Detail>("sp_UpdTemplate_Dashboard_Detail" , paramUpdDetail_Id , paramUpdTemplate , paramUpdRow_Number , paramUpdColumns ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail Template_Dashboard_DetailDB = GetByKey(entity.Detail_Id, false);
                var paramUpdDetail_Id = _dataProvider.GetParameter();
                paramUpdDetail_Id.ParameterName = "Detail_Id";
                paramUpdDetail_Id.DbType = DbType.Int32;
                paramUpdDetail_Id.Value = (object)entity.Detail_Id ?? DBNull.Value;
                var paramUpdTemplate = _dataProvider.GetParameter();
                paramUpdTemplate.ParameterName = "Template";
                paramUpdTemplate.DbType = DbType.Int32;
                paramUpdTemplate.Value = (object)entity.Template ?? DBNull.Value;
                var paramUpdRow_Number = _dataProvider.GetParameter();
                paramUpdRow_Number.ParameterName = "Row_Number";
                paramUpdRow_Number.DbType = DbType.Int16;
                paramUpdRow_Number.Value = (object)entity.Row_Number ?? DBNull.Value;
                var paramUpdColumns = _dataProvider.GetParameter();
                paramUpdColumns.ParameterName = "Columns";
                paramUpdColumns.DbType = DbType.Int16;
                paramUpdColumns.Value = (object)entity.Columns ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTemplate_Dashboard_Detail>("sp_UpdTemplate_Dashboard_Detail" , paramUpdDetail_Id , paramUpdTemplate , paramUpdRow_Number , paramUpdColumns ).FirstOrDefault();

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


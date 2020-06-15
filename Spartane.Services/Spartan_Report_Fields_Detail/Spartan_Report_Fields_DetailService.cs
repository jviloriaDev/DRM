using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Report_Fields_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Fields_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_Fields_DetailService : ISpartan_Report_Fields_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> _Spartan_Report_Fields_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_Report_Fields_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> Spartan_Report_Fields_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_Fields_DetailRepository = Spartan_Report_Fields_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Report_Fields_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>("sp_SelAllSpartan_Report_Fields_Detail");
        }

        public IList<Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Report_Fields_Detail_Complete>("sp_SelAllComplete_Spartan_Report_Fields_Detail");
            return data.Select(m => new Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail
            {
                DesignDetailId = m.DesignDetailId
                ,Report = m.Report
                ,PathField = m.PathField
                ,Physical_Name = m.Physical_Name
                ,Title = m.Title
                ,Function_Spartan_Report_Function = new Core.Classes.Spartan_Report_Function.Spartan_Report_Function() { FunctionId = m.Function.GetValueOrDefault(), Description = m.Function_Description }
                ,Format_Spartan_Report_Format = new Core.Classes.Spartan_Report_Format.Spartan_Report_Format() { FormatId = m.Format.GetValueOrDefault(), Description = m.Format_Description }
                ,Order_Type_Spartan_Report_Order_Type = new Core.Classes.Spartan_Report_Order_Type.Spartan_Report_Order_Type() { OrderTypeId = m.Order_Type.GetValueOrDefault(), Description = m.Order_Type_Description }
                ,Field_Type_Spartan_Report_Field_Type = new Core.Classes.Spartan_Report_Field_Type.Spartan_Report_Field_Type() { FieldTypeId = m.Field_Type.GetValueOrDefault(), Description = m.Field_Type_Description }
                ,Order_Number = m.Order_Number
                ,AttributeId_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.AttributeId.GetValueOrDefault(), Physical_Name = m.AttributeId_Physical_Name }
                ,
                Subtotal = m.Subtotal

            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Report_Fields_Detail>("sp_ListSelCount_Spartan_Report_Fields_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Fields_Detail>("sp_ListSelAll_Spartan_Report_Fields_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail
                {
                    DesignDetailId = m.Spartan_Report_Fields_Detail_DesignDetailId,
                    Report = m.Spartan_Report_Fields_Detail_Report,
                    PathField = m.Spartan_Report_Fields_Detail_PathField,
                    Physical_Name = m.Spartan_Report_Fields_Detail_Physical_Name,
                    Title = m.Spartan_Report_Fields_Detail_Title,
                    Function = m.Spartan_Report_Fields_Detail_Function,
                    Format = m.Spartan_Report_Fields_Detail_Format,
                    Order_Type = m.Spartan_Report_Fields_Detail_Order_Type,
                    Field_Type = m.Spartan_Report_Fields_Detail_Field_Type,
                    Order_Number = m.Spartan_Report_Fields_Detail_Order_Number,
                    AttributeId = m.Spartan_Report_Fields_Detail_AttributeId,
                    Subtotal = m.Spartan_Report_Fields_Detail_Subtotal
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

        public IList<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_Fields_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Fields_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Fields_Detail>("sp_ListSelAll_Spartan_Report_Fields_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Report_Fields_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Report_Fields_DetailPagingModel
                {
                    Spartan_Report_Fields_Details =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail
                {
                    DesignDetailId = m.Spartan_Report_Fields_Detail_DesignDetailId
                    ,Report = m.Spartan_Report_Fields_Detail_Report
                    ,PathField = m.Spartan_Report_Fields_Detail_PathField
                    ,Physical_Name = m.Spartan_Report_Fields_Detail_Physical_Name
                    ,Title = m.Spartan_Report_Fields_Detail_Title
                    ,Function = m.Spartan_Report_Fields_Detail_Function
                    ,Function_Spartan_Report_Function = new Core.Classes.Spartan_Report_Function.Spartan_Report_Function() { FunctionId = m.Spartan_Report_Fields_Detail_Function.GetValueOrDefault(), Description = m.Spartan_Report_Fields_Detail_Function_Description }
                    ,Format = m.Spartan_Report_Fields_Detail_Format
                    ,Format_Spartan_Report_Format = new Core.Classes.Spartan_Report_Format.Spartan_Report_Format() { FormatId = m.Spartan_Report_Fields_Detail_Format.GetValueOrDefault(), Description = m.Spartan_Report_Fields_Detail_Format_Description }
                    ,Order_Type = m.Spartan_Report_Fields_Detail_Order_Type
                    ,Order_Type_Spartan_Report_Order_Type = new Core.Classes.Spartan_Report_Order_Type.Spartan_Report_Order_Type() { OrderTypeId = m.Spartan_Report_Fields_Detail_Order_Type.GetValueOrDefault(), Description = m.Spartan_Report_Fields_Detail_Order_Type_Description }
                    ,Field_Type = m.Spartan_Report_Fields_Detail_Field_Type
                    ,Field_Type_Spartan_Report_Field_Type = new Core.Classes.Spartan_Report_Field_Type.Spartan_Report_Field_Type() { FieldTypeId = m.Spartan_Report_Fields_Detail_Field_Type.GetValueOrDefault(), Description = m.Spartan_Report_Fields_Detail_Field_Type_Description }
                    ,Order_Number = m.Spartan_Report_Fields_Detail_Order_Number
                    ,AttributeId = m.Spartan_Report_Fields_Detail_AttributeId
                    ,AttributeId_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Spartan_Report_Fields_Detail_AttributeId.GetValueOrDefault(), Physical_Name = m.Spartan_Report_Fields_Detail_AttributeId_Physical_Name }
                    , Subtotal = m.Spartan_Report_Fields_Detail_Subtotal
                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_Fields_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "DesignDetailId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>("sp_GetSpartan_Report_Fields_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "DesignDetailId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Report_Fields_Detail>("sp_DelSpartan_Report_Fields_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail entity)
        {
            int rta;
            try
            {

		                var padreReport = _dataProvider.GetParameter();
                padreReport.ParameterName = "Report";
                padreReport.DbType = DbType.Int32;
                padreReport.Value = (object)entity.Report ?? DBNull.Value;
                var padrePathField = _dataProvider.GetParameter();
                padrePathField.ParameterName = "PathField";
                padrePathField.DbType = DbType.String;
                padrePathField.Value = (object)entity.PathField ?? DBNull.Value;
                var padrePhysical_Name = _dataProvider.GetParameter();
                padrePhysical_Name.ParameterName = "Physical_Name";
                padrePhysical_Name.DbType = DbType.String;
                padrePhysical_Name.Value = (object)entity.Physical_Name ?? DBNull.Value;
                var padreTitle = _dataProvider.GetParameter();
                padreTitle.ParameterName = "Title";
                padreTitle.DbType = DbType.String;
                padreTitle.Value = (object)entity.Title ?? DBNull.Value;
                var padreFunction = _dataProvider.GetParameter();
                padreFunction.ParameterName = "Function";
                padreFunction.DbType = DbType.Int32;
                padreFunction.Value = (object)entity.Function ?? DBNull.Value;

                var padreFormat = _dataProvider.GetParameter();
                padreFormat.ParameterName = "Format";
                padreFormat.DbType = DbType.Int32;
                padreFormat.Value = (object)entity.Format ?? DBNull.Value;

                var padreOrder_Type = _dataProvider.GetParameter();
                padreOrder_Type.ParameterName = "Order_Type";
                padreOrder_Type.DbType = DbType.Int32;
                padreOrder_Type.Value = (object)entity.Order_Type ?? DBNull.Value;

                var padreField_Type = _dataProvider.GetParameter();
                padreField_Type.ParameterName = "Field_Type";
                padreField_Type.DbType = DbType.Int16;
                padreField_Type.Value = (object)entity.Field_Type ?? DBNull.Value;

                var padreOrder_Number = _dataProvider.GetParameter();
                padreOrder_Number.ParameterName = "Order_Number";
                padreOrder_Number.DbType = DbType.Int32;
                padreOrder_Number.Value = (object)entity.Order_Number ?? DBNull.Value;

                var padreAttributeId = _dataProvider.GetParameter();
                padreAttributeId.ParameterName = "AttributeId";
                padreAttributeId.DbType = DbType.Int32;
                padreAttributeId.Value = (object)entity.AttributeId ?? DBNull.Value;

                var padreSubtotal = _dataProvider.GetParameter();
                padreSubtotal.ParameterName = "Subtotal";
                padreSubtotal.DbType = DbType.Boolean;
                padreSubtotal.Value = (object)entity.Subtotal ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Report_Fields_Detail>("sp_InsSpartan_Report_Fields_Detail" 
, padreReport
, padrePathField
, padrePhysical_Name
, padreTitle
, padreFunction
, padreFormat
, padreOrder_Type
, padreField_Type
, padreOrder_Number
, padreAttributeId
, padreSubtotal
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.DesignDetailId);

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

        public int Update(Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdDesignDetailId = _dataProvider.GetParameter();
                paramUpdDesignDetailId.ParameterName = "DesignDetailId";
                paramUpdDesignDetailId.DbType = DbType.Int32;
                paramUpdDesignDetailId.Value = (object)entity.DesignDetailId ?? DBNull.Value;
                var paramUpdReport = _dataProvider.GetParameter();
                paramUpdReport.ParameterName = "Report";
                paramUpdReport.DbType = DbType.Int32;
                paramUpdReport.Value = (object)entity.Report ?? DBNull.Value;
                var paramUpdPathField = _dataProvider.GetParameter();
                paramUpdPathField.ParameterName = "PathField";
                paramUpdPathField.DbType = DbType.String;
                paramUpdPathField.Value = (object)entity.PathField ?? DBNull.Value;
                var paramUpdPhysical_Name = _dataProvider.GetParameter();
                paramUpdPhysical_Name.ParameterName = "Physical_Name";
                paramUpdPhysical_Name.DbType = DbType.String;
                paramUpdPhysical_Name.Value = (object)entity.Physical_Name ?? DBNull.Value;
                var paramUpdTitle = _dataProvider.GetParameter();
                paramUpdTitle.ParameterName = "Title";
                paramUpdTitle.DbType = DbType.String;
                paramUpdTitle.Value = (object)entity.Title ?? DBNull.Value;
                var paramUpdFunction = _dataProvider.GetParameter();
                paramUpdFunction.ParameterName = "Function";
                paramUpdFunction.DbType = DbType.Int32;
                paramUpdFunction.Value = (object)entity.Function ?? DBNull.Value;

                var paramUpdFormat = _dataProvider.GetParameter();
                paramUpdFormat.ParameterName = "Format";
                paramUpdFormat.DbType = DbType.Int32;
                paramUpdFormat.Value = (object)entity.Format ?? DBNull.Value;

                var paramUpdOrder_Type = _dataProvider.GetParameter();
                paramUpdOrder_Type.ParameterName = "Order_Type";
                paramUpdOrder_Type.DbType = DbType.Int32;
                paramUpdOrder_Type.Value = (object)entity.Order_Type ?? DBNull.Value;

                var paramUpdField_Type = _dataProvider.GetParameter();
                paramUpdField_Type.ParameterName = "Field_Type";
                paramUpdField_Type.DbType = DbType.Int16;
                paramUpdField_Type.Value = (object)entity.Field_Type ?? DBNull.Value;

                var paramUpdOrder_Number = _dataProvider.GetParameter();
                paramUpdOrder_Number.ParameterName = "Order_Number";
                paramUpdOrder_Number.DbType = DbType.Int32;
                paramUpdOrder_Number.Value = (object)entity.Order_Number ?? DBNull.Value;

                var paramUpdAttributeId = _dataProvider.GetParameter();
                paramUpdAttributeId.ParameterName = "AttributeId";
                paramUpdAttributeId.DbType = DbType.Int32;
                paramUpdAttributeId.Value = (object)entity.AttributeId ?? DBNull.Value;

                var paramUpdSubtotal = _dataProvider.GetParameter();
                paramUpdSubtotal.ParameterName = "Subtotal";
                paramUpdSubtotal.DbType = DbType.Boolean;
                paramUpdSubtotal.Value = (object)entity.Subtotal ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Report_Fields_Detail>("sp_UpdSpartan_Report_Fields_Detail", paramUpdDesignDetailId, paramUpdReport, paramUpdPathField, paramUpdPhysical_Name, paramUpdTitle, paramUpdFunction, paramUpdFormat, paramUpdOrder_Type, paramUpdField_Type, paramUpdOrder_Number, paramUpdAttributeId, paramUpdSubtotal).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.DesignDetailId);
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

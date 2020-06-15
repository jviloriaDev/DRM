using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Function;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Function
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_FunctionService : ISpartan_FunctionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Function.Spartan_Function> _Spartan_FunctionRepository;
        #endregion

        #region Ctor
        public Spartan_FunctionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Function.Spartan_Function> Spartan_FunctionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_FunctionRepository = Spartan_FunctionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_FunctionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Function.Spartan_Function> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function.Spartan_Function>("sp_SelAllSpartan_Function");
        }

        public IList<Core.Classes.Spartan_Function.Spartan_Function> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Function_Complete>("sp_SelAllComplete_Spartan_Function");
            return data.Select(m => new Core.Classes.Spartan_Function.Spartan_Function
            {
                Function_Id = m.Function_Id
                ,Description = m.Description
                ,Function_Type_Id_Spartan_Function_Type = new Core.Classes.Spartan_Function_Type.Spartan_Function_Type() { Function_Type_Id = m.Function_Type_Id.GetValueOrDefault(), Description = m.Function_Type_Id_Description }
                ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Image.GetValueOrDefault(), Description = m.Image_Description }
                ,Order_Shown = m.Order_Shown
                ,Status_Spartan_Function_Status = new Core.Classes.Spartan_Function_Status.Spartan_Function_Status() { Function_Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Function>("sp_ListSelCount_Spartan_Function", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Function.Spartan_Function> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function>("sp_ListSelAll_Spartan_Function", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Function.Spartan_Function
                {
                    Function_Id = m.Spartan_Function_Function_Id,
                    Description = m.Spartan_Function_Description,
                    Function_Type_Id = m.Spartan_Function_Function_Type_Id,
                    Image = m.Spartan_Function_Image,
                    Order_Shown = m.Spartan_Function_Order_Shown,
                    Status = m.Spartan_Function_Status,

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

        public IList<Spartane.Core.Classes.Spartan_Function.Spartan_Function> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_FunctionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Function.Spartan_Function> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_FunctionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function.Spartan_FunctionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function>("sp_ListSelAll_Spartan_Function", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_FunctionPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_FunctionPagingModel
                {
                    Spartan_Functions =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Function.Spartan_Function
                {
                    Function_Id = m.Spartan_Function_Function_Id
                    ,Description = m.Spartan_Function_Description
                    ,Function_Type_Id = m.Spartan_Function_Function_Type_Id
                    ,Function_Type_Id_Spartan_Function_Type = new Core.Classes.Spartan_Function_Type.Spartan_Function_Type() { Function_Type_Id = m.Spartan_Function_Function_Type_Id.GetValueOrDefault(), Description = m.Spartan_Function_Function_Type_Id_Description }
                    ,Image = m.Spartan_Function_Image
                    ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Spartan_Function_Image.GetValueOrDefault(), Description = m.Spartan_Function_Image_Description }
                    ,Order_Shown = m.Spartan_Function_Order_Shown
                    ,Status = m.Spartan_Function_Status
                    ,Status_Spartan_Function_Status = new Core.Classes.Spartan_Function_Status.Spartan_Function_Status() { Function_Status_Id = m.Spartan_Function_Status.GetValueOrDefault(), Description = m.Spartan_Function_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Function.Spartan_Function> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_FunctionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function.Spartan_Function GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Function_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function.Spartan_Function>("sp_GetSpartan_Function", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Function_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Function>("sp_DelSpartan_Function", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Function.Spartan_Function entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreFunction_Type_Id = _dataProvider.GetParameter();
                padreFunction_Type_Id.ParameterName = "Function_Type_Id";
                padreFunction_Type_Id.DbType = DbType.Int16;
                if (entity.Function_Type_Id == null)
                    padreFunction_Type_Id.Value = DBNull.Value;
                else
                    padreFunction_Type_Id.Value = entity.Function_Type_Id;

                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Function>("sp_InsSpartan_Function" , padreDescription 
, padreFunction_Type_Id 
, padreImage 
, padreOrder_Shown 
, padreStatus 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Function.Spartan_Function entity)
        {
            short rta;
            try
            {

                var padreFunction_Id = _dataProvider.GetParameter();
                padreFunction_Id.ParameterName = "Function_Id";
                padreFunction_Id.DbType = DbType.Int16;
                padreFunction_Id.Value = entity.Function_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreFunction_Type_Id = _dataProvider.GetParameter();
                padreFunction_Type_Id.ParameterName = "Function_Type_Id";
                padreFunction_Type_Id.DbType = DbType.Int16;
                if (entity.Function_Type_Id == null)
                    padreFunction_Type_Id.Value = DBNull.Value;
                else
                    padreFunction_Type_Id.Value = entity.Function_Type_Id;

                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Function>("sp_UpdSpartan_Function" , padreFunction_Id  , padreDescription  , padreFunction_Type_Id  , padreImage  , padreOrder_Shown  , padreStatus  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Id);
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


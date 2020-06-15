using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Method_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Method_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Method_TypeService : ISpartan_Method_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type> _Spartan_Method_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Method_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type> Spartan_Method_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Method_TypeRepository = Spartan_Method_TypeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Method_TypeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type>("sp_SelAllSpartan_Method_Type");
        }

        public IList<Core.Classes.Spartan_Method_Type.Spartan_Method_Type> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Method_Type_Complete>("sp_SelAllComplete_Spartan_Method_Type");
            return data.Select(m => new Core.Classes.Spartan_Method_Type.Spartan_Method_Type
            {
                Method_Type_Id = m.Method_Type_Id
                ,Description = m.Description
                ,Clasification_Spartan_Method_Clasification = new Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification() { Method_Classification_Id = m.Clasification.GetValueOrDefault(), Description = m.Clasification_Description }
                ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Image.GetValueOrDefault(), Description = m.Image_Description }
                ,Status_Spartan_Method_Type_Status = new Core.Classes.Spartan_Method_Type_Status.Spartan_Method_Type_Status() { Method_Type_Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Method_Type>("sp_ListSelCount_Spartan_Method_Type", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Method_Type>("sp_ListSelAll_Spartan_Method_Type", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type
                {
                    Method_Type_Id = m.Spartan_Method_Type_Method_Type_Id,
                    Description = m.Spartan_Method_Type_Description,
                    Clasification = m.Spartan_Method_Type_Clasification,
                    Image = m.Spartan_Method_Type_Image,
                    Status = m.Spartan_Method_Type_Status,

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

        public IList<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Method_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Method_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Method_Type>("sp_ListSelAll_Spartan_Method_Type", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Method_TypePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Method_TypePagingModel
                {
                    Spartan_Method_Types =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type
                {
                    Method_Type_Id = m.Spartan_Method_Type_Method_Type_Id
                    ,Description = m.Spartan_Method_Type_Description
                    ,Clasification = m.Spartan_Method_Type_Clasification
                    ,Clasification_Spartan_Method_Clasification = new Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification() { Method_Classification_Id = m.Spartan_Method_Type_Clasification.GetValueOrDefault(), Description = m.Spartan_Method_Type_Clasification_Description }
                    ,Image = m.Spartan_Method_Type_Image
                    ,Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Spartan_Method_Type_Image.GetValueOrDefault(), Description = m.Spartan_Method_Type_Image_Description }
                    ,Status = m.Spartan_Method_Type_Status
                    ,Status_Spartan_Method_Type_Status = new Core.Classes.Spartan_Method_Type_Status.Spartan_Method_Type_Status() { Method_Type_Status_Id = m.Spartan_Method_Type_Status.GetValueOrDefault(), Description = m.Spartan_Method_Type_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Method_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Method_Type_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type>("sp_GetSpartan_Method_Type", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Method_Type_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Method_Type>("sp_DelSpartan_Method_Type", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreClasification = _dataProvider.GetParameter();
                padreClasification.ParameterName = "Clasification";
                padreClasification.DbType = DbType.Int16;
                if (entity.Clasification == null)
                    padreClasification.Value = DBNull.Value;
                else
                    padreClasification.Value = entity.Clasification;

                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Method_Type>("sp_InsSpartan_Method_Type" , padreDescription 
, padreClasification 
, padreImage 
, padreStatus 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Method_Type_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type entity)
        {
            short rta;
            try
            {

                var padreMethod_Type_Id = _dataProvider.GetParameter();
                padreMethod_Type_Id.ParameterName = "Method_Type_Id";
                padreMethod_Type_Id.DbType = DbType.Int16;
                padreMethod_Type_Id.Value = entity.Method_Type_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreClasification = _dataProvider.GetParameter();
                padreClasification.ParameterName = "Clasification";
                padreClasification.DbType = DbType.Int16;
                if (entity.Clasification == null)
                    padreClasification.Value = DBNull.Value;
                else
                    padreClasification.Value = entity.Clasification;

                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                if (entity.Image == null)
                    padreImage.Value = DBNull.Value;
                else
                    padreImage.Value = entity.Image;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Method_Type>("sp_UpdSpartan_Method_Type" , padreMethod_Type_Id  , padreDescription  , padreClasification  , padreImage  , padreStatus  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Method_Type_Id);
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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_System;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_System
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_SystemService : ISpartan_SystemService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_System.Spartan_System> _Spartan_SystemRepository;
        #endregion

        #region Ctor
        public Spartan_SystemService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_System.Spartan_System> Spartan_SystemRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_SystemRepository = Spartan_SystemRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_SystemRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_System.Spartan_System> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_System.Spartan_System>("sp_SelAllSpartan_System");
        }

        public IList<Core.Classes.Spartan_System.Spartan_System> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_System_Complete>("sp_SelAllComplete_Spartan_System");
            return data.Select(m => new Core.Classes.Spartan_System.Spartan_System
            {
                System_Id = m.System_Id
                ,Version = m.Version
                ,System_Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.System_Image.GetValueOrDefault(), Description = m.System_Image_Description }
                ,Customer_Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Customer_Image.GetValueOrDefault(), Description = m.Customer_Image_Description }
                ,Developer_Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Developer_Image.GetValueOrDefault(), Description = m.Developer_Image_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_System>("sp_ListSelCount_Spartan_System", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_System.Spartan_System> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_System>("sp_ListSelAll_Spartan_System", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_System.Spartan_System
                {
                    System_Id = m.Spartan_System_System_Id,
                    Version = m.Spartan_System_Version,
                    System_Image = m.Spartan_System_System_Image,
                    Customer_Image = m.Spartan_System_Customer_Image,
                    Developer_Image = m.Spartan_System_Developer_Image,

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

        public IList<Spartane.Core.Classes.Spartan_System.Spartan_System> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_SystemRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_System.Spartan_System> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_SystemRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_System.Spartan_SystemPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_System>("sp_ListSelAll_Spartan_System", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_SystemPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_SystemPagingModel
                {
                    Spartan_Systems =
                        data.Select(m => new Spartane.Core.Classes.Spartan_System.Spartan_System
                {
                    System_Id = m.Spartan_System_System_Id
                    ,Version = m.Spartan_System_Version
                    ,System_Image = m.Spartan_System_System_Image
                    ,System_Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Spartan_System_System_Image.GetValueOrDefault(), Description = m.Spartan_System_System_Image_Description }
                    ,Customer_Image = m.Spartan_System_Customer_Image
                    ,Customer_Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Spartan_System_Customer_Image.GetValueOrDefault(), Description = m.Spartan_System_Customer_Image_Description }
                    ,Developer_Image = m.Spartan_System_Developer_Image
                    ,Developer_Image_Spartane_File = new Core.Classes.Spartane_File.Spartane_File() { File_Id = m.Spartan_System_Developer_Image.GetValueOrDefault(), Description = m.Spartan_System_Developer_Image_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_System.Spartan_System> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_SystemRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_System.Spartan_System GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "System_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_System.Spartan_System>("sp_GetSpartan_System", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "System_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_System>("sp_DelSpartan_System", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_System.Spartan_System entity)
        {
            short rta;
            try
            {

		                var padreVersion = _dataProvider.GetParameter();
                padreVersion.ParameterName = "Version";
                padreVersion.DbType = DbType.String;
                padreVersion.Value = entity.Version;
                var padreSystem_Image = _dataProvider.GetParameter();
                padreSystem_Image.ParameterName = "System_Image";
                padreSystem_Image.DbType = DbType.Int32;
                if (entity.System_Image == null)
                    padreSystem_Image.Value = DBNull.Value;
                else
                    padreSystem_Image.Value = entity.System_Image;

                var padreCustomer_Image = _dataProvider.GetParameter();
                padreCustomer_Image.ParameterName = "Customer_Image";
                padreCustomer_Image.DbType = DbType.Int32;
                if (entity.Customer_Image == null)
                    padreCustomer_Image.Value = DBNull.Value;
                else
                    padreCustomer_Image.Value = entity.Customer_Image;

                var padreDeveloper_Image = _dataProvider.GetParameter();
                padreDeveloper_Image.ParameterName = "Developer_Image";
                padreDeveloper_Image.DbType = DbType.Int32;
                if (entity.Developer_Image == null)
                    padreDeveloper_Image.Value = DBNull.Value;
                else
                    padreDeveloper_Image.Value = entity.Developer_Image;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_System>("sp_InsSpartan_System" , padreVersion 
, padreSystem_Image 
, padreCustomer_Image 
, padreDeveloper_Image 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.System_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_System.Spartan_System entity)
        {
            short rta;
            try
            {

                var padreSystem_Id = _dataProvider.GetParameter();
                padreSystem_Id.ParameterName = "System_Id";
                padreSystem_Id.DbType = DbType.Int16;
                padreSystem_Id.Value = entity.System_Id;
                var padreVersion = _dataProvider.GetParameter();
                padreVersion.ParameterName = "Version";
                padreVersion.DbType = DbType.String;
                padreVersion.Value = entity.Version;
                var padreSystem_Image = _dataProvider.GetParameter();
                padreSystem_Image.ParameterName = "System_Image";
                padreSystem_Image.DbType = DbType.Int32;
                if (entity.System_Image == null)
                    padreSystem_Image.Value = DBNull.Value;
                else
                    padreSystem_Image.Value = entity.System_Image;

                var padreCustomer_Image = _dataProvider.GetParameter();
                padreCustomer_Image.ParameterName = "Customer_Image";
                padreCustomer_Image.DbType = DbType.Int32;
                if (entity.Customer_Image == null)
                    padreCustomer_Image.Value = DBNull.Value;
                else
                    padreCustomer_Image.Value = entity.Customer_Image;

                var padreDeveloper_Image = _dataProvider.GetParameter();
                padreDeveloper_Image.ParameterName = "Developer_Image";
                padreDeveloper_Image.DbType = DbType.Int32;
                if (entity.Developer_Image == null)
                    padreDeveloper_Image.Value = DBNull.Value;
                else
                    padreDeveloper_Image.Value = entity.Developer_Image;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_System>("sp_UpdSpartan_System" , padreSystem_Id  , padreVersion  , padreSystem_Image  , padreCustomer_Image  , padreDeveloper_Image  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.System_Id);
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


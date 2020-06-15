using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User_Alert;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Alert
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_AlertService : ISpartan_User_AlertService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> _Spartan_User_AlertRepository;
        #endregion

        #region Ctor
        public Spartan_User_AlertService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> Spartan_User_AlertRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_AlertRepository = Spartan_User_AlertRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_User_AlertRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert>("sp_SelAllSpartan_User_Alert");
        }

        public IList<Core.Classes.Spartan_User_Alert.Spartan_User_Alert> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Alert_Complete>("sp_SelAllComplete_Spartan_User_Alert");
            return data.Select(m => new Core.Classes.Spartan_User_Alert.Spartan_User_Alert
            {
                User__Alert_Id = m.User__Alert_Id
                ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.User_Id.GetValueOrDefault(), Name = m.User_Id_Name }
                ,Alert_Type_Spartan_User_Alert_Type = new Core.Classes.Spartan_User_Alert_Type.Spartan_User_Alert_Type() { User_Alert_Type_Id = m.Alert_Type.GetValueOrDefault(), Description = m.Alert_Type_Description }
                ,Description = m.Description
                ,URL = m.URL
                ,Status_Spartan_User_Alert_Status = new Core.Classes.Spartan_User_Alert_Status.Spartan_User_Alert_Status() { User_Alert_Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User_Alert>("sp_ListSelCount_Spartan_User_Alert", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Alert>("sp_ListSelAll_Spartan_User_Alert", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert
                {
                    User__Alert_Id = m.Spartan_User_Alert_User__Alert_Id,
                    User_Id = m.Spartan_User_Alert_User_Id,
                    Alert_Type = m.Spartan_User_Alert_Alert_Type,
                    Description = m.Spartan_User_Alert_Description,
                    URL = m.Spartan_User_Alert_URL,
                    Status = m.Spartan_User_Alert_Status,

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

        public IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_AlertRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_AlertRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_AlertPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Alert>("sp_ListSelAll_Spartan_User_Alert", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_User_AlertPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_User_AlertPagingModel
                {
                    Spartan_User_Alerts =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert
                {
                    User__Alert_Id = m.Spartan_User_Alert_User__Alert_Id
                    ,User_Id = m.Spartan_User_Alert_User_Id
                    ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_User_Alert_User_Id.GetValueOrDefault(), Name = m.Spartan_User_Alert_User_Id_Name }
                    ,Alert_Type = m.Spartan_User_Alert_Alert_Type
                    ,Alert_Type_Spartan_User_Alert_Type = new Core.Classes.Spartan_User_Alert_Type.Spartan_User_Alert_Type() { User_Alert_Type_Id = m.Spartan_User_Alert_Alert_Type.GetValueOrDefault(), Description = m.Spartan_User_Alert_Alert_Type_Description }
                    ,Description = m.Spartan_User_Alert_Description
                    ,URL = m.Spartan_User_Alert_URL
                    ,Status = m.Spartan_User_Alert_Status
                    ,Status_Spartan_User_Alert_Status = new Core.Classes.Spartan_User_Alert_Status.Spartan_User_Alert_Status() { User_Alert_Status_Id = m.Spartan_User_Alert_Status.GetValueOrDefault(), Description = m.Spartan_User_Alert_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_AlertRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "User__Alert_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert>("sp_GetSpartan_User_Alert", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "User__Alert_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User_Alert>("sp_DelSpartan_User_Alert", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert entity)
        {
            int rta;
            try
            {

		                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreAlert_Type = _dataProvider.GetParameter();
                padreAlert_Type.ParameterName = "Alert_Type";
                padreAlert_Type.DbType = DbType.Int16;
                if (entity.Alert_Type == null)
                    padreAlert_Type.Value = DBNull.Value;
                else
                    padreAlert_Type.Value = entity.Alert_Type;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User_Alert>("sp_InsSpartan_User_Alert" , padreUser_Id 
, padreAlert_Type 
, padreDescription 
, padreURL 
, padreStatus 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User__Alert_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert entity)
        {
            int rta;
            try
            {

                var padreUser__Alert_Id = _dataProvider.GetParameter();
                padreUser__Alert_Id.ParameterName = "User__Alert_Id";
                padreUser__Alert_Id.DbType = DbType.Int32;
                padreUser__Alert_Id.Value = entity.User__Alert_Id;
                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreAlert_Type = _dataProvider.GetParameter();
                padreAlert_Type.ParameterName = "Alert_Type";
                padreAlert_Type.DbType = DbType.Int16;
                if (entity.Alert_Type == null)
                    padreAlert_Type.Value = DBNull.Value;
                else
                    padreAlert_Type.Value = entity.Alert_Type;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User_Alert>("sp_UpdSpartan_User_Alert" , padreUser__Alert_Id  , padreUser_Id  , padreAlert_Type  , padreDescription  , padreURL  , padreStatus  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User__Alert_Id);
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


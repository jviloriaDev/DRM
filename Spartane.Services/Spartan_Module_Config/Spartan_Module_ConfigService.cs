using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Module_Config;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Module_Config
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Module_ConfigService : ISpartan_Module_ConfigService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> _Spartan_Module_ConfigRepository;
        #endregion

        #region Ctor
        public Spartan_Module_ConfigService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> Spartan_Module_ConfigRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Module_ConfigRepository = Spartan_Module_ConfigRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Module_ConfigRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config>("sp_SelAllSpartan_Module_Config");
        }

        public IList<Core.Classes.Spartan_Module_Config.Spartan_Module_Config> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Module_Config_Complete>("sp_SelAllComplete_Spartan_Module_Config");
            return data.Select(m => new Core.Classes.Spartan_Module_Config.Spartan_Module_Config
            {
                Module_Config_Id = m.Module_Config_Id
                ,Order_Type_Spartan_Order_Type = new Core.Classes.Spartan_Order_Type.Spartan_Order_Type() { Order_Type_Id = m.Order_Type.GetValueOrDefault(), Description = m.Order_Type_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Module_Config>("sp_ListSelCount_Spartan_Module_Config", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module_Config>("sp_ListSelAll_Spartan_Module_Config", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config
                {
                    Module_Config_Id = m.Spartan_Module_Config_Module_Config_Id,
                    Order_Type = m.Spartan_Module_Config_Order_Type,

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

        public IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Module_ConfigRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Module_ConfigRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_ConfigPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module_Config>("sp_ListSelAll_Spartan_Module_Config", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Module_ConfigPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Module_ConfigPagingModel
                {
                    Spartan_Module_Configs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config
                {
                    Module_Config_Id = m.Spartan_Module_Config_Module_Config_Id
                    ,Order_Type = m.Spartan_Module_Config_Order_Type
                    ,Order_Type_Spartan_Order_Type = new Core.Classes.Spartan_Order_Type.Spartan_Order_Type() { Order_Type_Id = m.Spartan_Module_Config_Order_Type.GetValueOrDefault(), Description = m.Spartan_Module_Config_Order_Type_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Module_ConfigRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Module_Config_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config>("sp_GetSpartan_Module_Config", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Module_Config_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Module_Config>("sp_DelSpartan_Module_Config", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config entity)
        {
            short rta;
            try
            {

		                var padreOrder_Type = _dataProvider.GetParameter();
                padreOrder_Type.ParameterName = "Order_Type";
                padreOrder_Type.DbType = DbType.Int16;
                if (entity.Order_Type == null)
                    padreOrder_Type.Value = DBNull.Value;
                else
                    padreOrder_Type.Value = entity.Order_Type;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Module_Config>("sp_InsSpartan_Module_Config" , padreOrder_Type 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Module_Config_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config entity)
        {
            short rta;
            try
            {

                var padreModule_Config_Id = _dataProvider.GetParameter();
                padreModule_Config_Id.ParameterName = "Module_Config_Id";
                padreModule_Config_Id.DbType = DbType.Int16;
                padreModule_Config_Id.Value = entity.Module_Config_Id;
                var padreOrder_Type = _dataProvider.GetParameter();
                padreOrder_Type.ParameterName = "Order_Type";
                padreOrder_Type.DbType = DbType.Int16;
                if (entity.Order_Type == null)
                    padreOrder_Type.Value = DBNull.Value;
                else
                    padreOrder_Type.Value = entity.Order_Type;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Module_Config>("sp_UpdSpartan_Module_Config" , padreModule_Config_Id  , padreOrder_Type  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Module_Config_Id);
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


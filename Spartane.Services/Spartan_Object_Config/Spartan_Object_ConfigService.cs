using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Object_Config;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Object_Config
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Object_ConfigService : ISpartan_Object_ConfigService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> _Spartan_Object_ConfigRepository;
        #endregion

        #region Ctor
        public Spartan_Object_ConfigService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> Spartan_Object_ConfigRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Object_ConfigRepository = Spartan_Object_ConfigRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Object_ConfigRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config>("sp_SelAllSpartan_Object_Config");
        }

        public IList<Core.Classes.Spartan_Object_Config.Spartan_Object_Config> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Object_Config_Complete>("sp_SelAllComplete_Spartan_Object_Config");
            return data.Select(m => new Core.Classes.Spartan_Object_Config.Spartan_Object_Config
            {
                Object_Config_Id = m.Object_Config_Id
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Object_Config>("sp_ListSelCount_Spartan_Object_Config", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object_Config>("sp_ListSelAll_Spartan_Object_Config", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config
                {
                    Object_Config_Id = m.Spartan_Object_Config_Object_Config_Id,
                    Description = m.Spartan_Object_Config_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Object_ConfigRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Object_ConfigRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_ConfigPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object_Config>("sp_ListSelAll_Spartan_Object_Config", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Object_ConfigPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Object_ConfigPagingModel
                {
                    Spartan_Object_Configs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config
                {
                    Object_Config_Id = m.Spartan_Object_Config_Object_Config_Id
                    ,Description = m.Spartan_Object_Config_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Object_ConfigRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Object_Config_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config>("sp_GetSpartan_Object_Config", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Object_Config_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Object_Config>("sp_DelSpartan_Object_Config", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Object_Config>("sp_InsSpartan_Object_Config" , padreDescription 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Object_Config_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config entity)
        {
            short rta;
            try
            {

                var padreObject_Config_Id = _dataProvider.GetParameter();
                padreObject_Config_Id.ParameterName = "Object_Config_Id";
                padreObject_Config_Id.DbType = DbType.Int16;
                padreObject_Config_Id.Value = entity.Object_Config_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Object_Config>("sp_UpdSpartan_Object_Config" , padreObject_Config_Id  , padreDescription  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Object_Config_Id);
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


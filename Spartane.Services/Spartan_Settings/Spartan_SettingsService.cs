using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Settings;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Settings
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_SettingsService : ISpartan_SettingsService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> _Spartan_SettingsRepository;
        #endregion

        #region Ctor
        public Spartan_SettingsService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> Spartan_SettingsRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_SettingsRepository = Spartan_SettingsRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_SettingsRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings>("sp_SelAllSpartan_Settings");
        }

        public IList<Core.Classes.Spartan_Settings.Spartan_Settings> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Settings_Complete>("sp_SelAllComplete_Spartan_Settings");
            return data.Select(m => new Core.Classes.Spartan_Settings.Spartan_Settings
            {
                Clave = m.Clave
                ,Valor = m.Valor


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Settings>("sp_ListSelCount_Spartan_Settings", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Settings>("sp_ListSelAll_Spartan_Settings", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Settings.Spartan_Settings
                {
                    Clave = m.Spartan_Settings_Clave,
                    Valor = m.Spartan_Settings_Valor,

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

        public IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_SettingsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_SettingsRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Settings.Spartan_SettingsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Settings>("sp_ListSelAll_Spartan_Settings", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_SettingsPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_SettingsPagingModel
                {
                    Spartan_Settingss =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Settings.Spartan_Settings
                {
                    Clave = m.Spartan_Settings_Clave
                    ,Valor = m.Spartan_Settings_Valor

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_SettingsRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Settings.Spartan_Settings GetByKey(string Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.String;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings>("sp_GetSpartan_Settings", padreKey).SingleOrDefault();
        }

        public bool Delete(string Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.String;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Settings>("sp_DelSpartan_Settings", padreKey).FirstOrDefault();
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

        public string Insert(Spartane.Core.Classes.Spartan_Settings.Spartan_Settings entity)
        {
            string rta;
            try
            {

		                var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.String;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreValor = _dataProvider.GetParameter();
                padreValor.ParameterName = "Valor";
                padreValor.DbType = DbType.String;
                padreValor.Value = (object)entity.Valor ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Settings>("sp_InsSpartan_Settings" , padreClave
, padreValor
).FirstOrDefault();

                rta = Convert.ToString(empEntity.Clave);

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

        public string Update(Spartane.Core.Classes.Spartan_Settings.Spartan_Settings entity)
        {
            string rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.String;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdValor = _dataProvider.GetParameter();
                paramUpdValor.ParameterName = "Valor";
                paramUpdValor.DbType = DbType.String;
                paramUpdValor.Value = (object)entity.Valor ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Settings>("sp_UpdSpartan_Settings" , paramUpdClave , paramUpdValor ).FirstOrDefault();

                rta = Convert.ToString(empEntity.Clave);
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

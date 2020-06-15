using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Regimenes_Fiscales;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Regimenes_Fiscales
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Regimenes_FiscalesService : IRegimenes_FiscalesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> _Regimenes_FiscalesRepository;
        #endregion

        #region Ctor
        public Regimenes_FiscalesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> Regimenes_FiscalesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Regimenes_FiscalesRepository = Regimenes_FiscalesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Regimenes_FiscalesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales>("sp_SelAllRegimenes_Fiscales");
        }

        public IList<Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRegimenes_Fiscales_Complete>("sp_SelAllComplete_Regimenes_Fiscales");
            return data.Select(m => new Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Regimenes_Fiscales>("sp_ListSelCount_Regimenes_Fiscales", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegimenes_Fiscales>("sp_ListSelAll_Regimenes_Fiscales", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales
                {
                    Clave = m.Regimenes_Fiscales_Clave,
                    Descripcion = m.Regimenes_Fiscales_Descripcion,

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

        public IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Regimenes_FiscalesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Regimenes_FiscalesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_FiscalesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegimenes_Fiscales>("sp_ListSelAll_Regimenes_Fiscales", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Regimenes_FiscalesPagingModel result = null;

            if (data != null)
            {
                result = new Regimenes_FiscalesPagingModel
                {
                    Regimenes_Fiscaless =
                        data.Select(m => new Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales
                {
                    Clave = m.Regimenes_Fiscales_Clave
                    ,Descripcion = m.Regimenes_Fiscales_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Regimenes_FiscalesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales>("sp_GetRegimenes_Fiscales", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRegimenes_Fiscales>("sp_DelRegimenes_Fiscales", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRegimenes_Fiscales>("sp_InsRegimenes_Fiscales" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegimenes_Fiscales>("sp_UpdRegimenes_Fiscales" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales Regimenes_FiscalesDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegimenes_Fiscales>("sp_UpdRegimenes_Fiscales" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Frecuencia_Ejercicio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Frecuencia_Ejercicio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Frecuencia_EjercicioService : IFrecuencia_EjercicioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio> _Frecuencia_EjercicioRepository;
        #endregion

        #region Ctor
        public Frecuencia_EjercicioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio> Frecuencia_EjercicioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Frecuencia_EjercicioRepository = Frecuencia_EjercicioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Frecuencia_EjercicioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio>("sp_SelAllFrecuencia_Ejercicio");
        }

        public IList<Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallFrecuencia_Ejercicio_Complete>("sp_SelAllComplete_Frecuencia_Ejercicio");
            return data.Select(m => new Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Frecuencia_Ejercicio>("sp_ListSelCount_Frecuencia_Ejercicio", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFrecuencia_Ejercicio>("sp_ListSelAll_Frecuencia_Ejercicio", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio
                {
                    Clave = m.Frecuencia_Ejercicio_Clave,
                    Descripcion = m.Frecuencia_Ejercicio_Descripcion,

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

        public IList<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Frecuencia_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_EjercicioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_EjercicioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFrecuencia_Ejercicio>("sp_ListSelAll_Frecuencia_Ejercicio", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Frecuencia_EjercicioPagingModel result = null;

            if (data != null)
            {
                result = new Frecuencia_EjercicioPagingModel
                {
                    Frecuencia_Ejercicios =
                        data.Select(m => new Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio
                {
                    Clave = m.Frecuencia_Ejercicio_Clave
                    ,Descripcion = m.Frecuencia_Ejercicio_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Frecuencia_EjercicioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio>("sp_GetFrecuencia_Ejercicio", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelFrecuencia_Ejercicio>("sp_DelFrecuencia_Ejercicio", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsFrecuencia_Ejercicio>("sp_InsFrecuencia_Ejercicio" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFrecuencia_Ejercicio>("sp_UpdFrecuencia_Ejercicio" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio Frecuencia_EjercicioDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFrecuencia_Ejercicio>("sp_UpdFrecuencia_Ejercicio" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


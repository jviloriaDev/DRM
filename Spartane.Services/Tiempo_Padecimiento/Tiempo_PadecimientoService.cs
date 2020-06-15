using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tiempo_Padecimiento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tiempo_Padecimiento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tiempo_PadecimientoService : ITiempo_PadecimientoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> _Tiempo_PadecimientoRepository;
        #endregion

        #region Ctor
        public Tiempo_PadecimientoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> Tiempo_PadecimientoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tiempo_PadecimientoRepository = Tiempo_PadecimientoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tiempo_PadecimientoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento>("sp_SelAllTiempo_Padecimiento");
        }

        public IList<Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTiempo_Padecimiento_Complete>("sp_SelAllComplete_Tiempo_Padecimiento");
            return data.Select(m => new Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tiempo_Padecimiento>("sp_ListSelCount_Tiempo_Padecimiento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTiempo_Padecimiento>("sp_ListSelAll_Tiempo_Padecimiento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento
                {
                    Clave = m.Tiempo_Padecimiento_Clave,
                    Descripcion = m.Tiempo_Padecimiento_Descripcion,

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

        public IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tiempo_PadecimientoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tiempo_PadecimientoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_PadecimientoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTiempo_Padecimiento>("sp_ListSelAll_Tiempo_Padecimiento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tiempo_PadecimientoPagingModel result = null;

            if (data != null)
            {
                result = new Tiempo_PadecimientoPagingModel
                {
                    Tiempo_Padecimientos =
                        data.Select(m => new Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento
                {
                    Clave = m.Tiempo_Padecimiento_Clave
                    ,Descripcion = m.Tiempo_Padecimiento_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tiempo_PadecimientoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento>("sp_GetTiempo_Padecimiento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTiempo_Padecimiento>("sp_DelTiempo_Padecimiento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTiempo_Padecimiento>("sp_InsTiempo_Padecimiento" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTiempo_Padecimiento>("sp_UpdTiempo_Padecimiento" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento Tiempo_PadecimientoDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTiempo_Padecimiento>("sp_UpdTiempo_Padecimiento" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


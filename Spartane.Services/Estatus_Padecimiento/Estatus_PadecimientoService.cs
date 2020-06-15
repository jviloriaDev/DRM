using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_Padecimiento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Padecimiento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_PadecimientoService : IEstatus_PadecimientoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> _Estatus_PadecimientoRepository;
        #endregion

        #region Ctor
        public Estatus_PadecimientoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> Estatus_PadecimientoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_PadecimientoRepository = Estatus_PadecimientoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_PadecimientoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento>("sp_SelAllEstatus_Padecimiento");
        }

        public IList<Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_Padecimiento_Complete>("sp_SelAllComplete_Estatus_Padecimiento");
            return data.Select(m => new Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_Padecimiento>("sp_ListSelCount_Estatus_Padecimiento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Padecimiento>("sp_ListSelAll_Estatus_Padecimiento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento
                {
                    Clave = m.Estatus_Padecimiento_Clave,
                    Descripcion = m.Estatus_Padecimiento_Descripcion,

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

        public IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_PadecimientoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_PadecimientoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Padecimiento.Estatus_PadecimientoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Padecimiento>("sp_ListSelAll_Estatus_Padecimiento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_PadecimientoPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_PadecimientoPagingModel
                {
                    Estatus_Padecimientos =
                        data.Select(m => new Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento
                {
                    Clave = m.Estatus_Padecimiento_Clave
                    ,Descripcion = m.Estatus_Padecimiento_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_PadecimientoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento>("sp_GetEstatus_Padecimiento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_Padecimiento>("sp_DelEstatus_Padecimiento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_Padecimiento>("sp_InsEstatus_Padecimiento" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Padecimiento>("sp_UpdEstatus_Padecimiento" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento Estatus_PadecimientoDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Padecimiento>("sp_UpdEstatus_Padecimiento" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


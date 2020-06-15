using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_Reservaciones_Actividad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Reservaciones_Actividad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_Reservaciones_ActividadService : IEstatus_Reservaciones_ActividadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> _Estatus_Reservaciones_ActividadRepository;
        #endregion

        #region Ctor
        public Estatus_Reservaciones_ActividadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> Estatus_Reservaciones_ActividadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_Reservaciones_ActividadRepository = Estatus_Reservaciones_ActividadRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>("sp_SelAllEstatus_Reservaciones_Actividad");
        }

        public IList<Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_Reservaciones_Actividad_Complete>("sp_SelAllComplete_Estatus_Reservaciones_Actividad");
            return data.Select(m => new Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad
            {
                Folio = m.Folio
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_Reservaciones_Actividad>("sp_ListSelCount_Estatus_Reservaciones_Actividad", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Reservaciones_Actividad>("sp_ListSelAll_Estatus_Reservaciones_Actividad", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad
                {
                    Folio = m.Estatus_Reservaciones_Actividad_Folio,
                    Descripcion = m.Estatus_Reservaciones_Actividad_Descripcion,

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

        public IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_ActividadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Reservaciones_Actividad>("sp_ListSelAll_Estatus_Reservaciones_Actividad", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_Reservaciones_ActividadPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_Reservaciones_ActividadPagingModel
                {
                    Estatus_Reservaciones_Actividads =
                        data.Select(m => new Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad
                {
                    Folio = m.Estatus_Reservaciones_Actividad_Folio
                    ,Descripcion = m.Estatus_Reservaciones_Actividad_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>("sp_GetEstatus_Reservaciones_Actividad", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_Reservaciones_Actividad>("sp_DelEstatus_Reservaciones_Actividad", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_Reservaciones_Actividad>("sp_InsEstatus_Reservaciones_Actividad" , padreDescripcion
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

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

        public int Update(Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Reservaciones_Actividad>("sp_UpdEstatus_Reservaciones_Actividad" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad Estatus_Reservaciones_ActividadDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Reservaciones_Actividad>("sp_UpdEstatus_Reservaciones_Actividad" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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


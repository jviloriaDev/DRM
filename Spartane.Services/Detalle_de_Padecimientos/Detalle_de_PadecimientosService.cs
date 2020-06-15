using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Padecimientos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Padecimientos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_PadecimientosService : IDetalle_de_PadecimientosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> _Detalle_de_PadecimientosRepository;
        #endregion

        #region Ctor
        public Detalle_de_PadecimientosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> Detalle_de_PadecimientosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_PadecimientosRepository = Detalle_de_PadecimientosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_PadecimientosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos>("sp_SelAllDetalle_de_Padecimientos");
        }

        public IList<Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Padecimientos_Complete>("sp_SelAllComplete_Detalle_de_Padecimientos");
            return data.Select(m => new Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Padecimiento_Padecimientos = new Core.Classes.Padecimientos.Padecimientos() { Clave = m.Padecimiento.GetValueOrDefault(), Descripcion = m.Padecimiento_Descripcion }
                ,Tiempo_con_el_diagnostico_Tiempo_Padecimiento = new Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento() { Clave = m.Tiempo_con_el_diagnostico.GetValueOrDefault(), Descripcion = m.Tiempo_con_el_diagnostico_Descripcion }
                ,Intervencion_quirurgica_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Intervencion_quirurgica.GetValueOrDefault(), Descripcion = m.Intervencion_quirurgica_Descripcion }
                ,Tratamiento = m.Tratamiento
                ,Estado_actual_Estatus_Padecimiento = new Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento() { Clave = m.Estado_actual.GetValueOrDefault(), Descripcion = m.Estado_actual_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Padecimientos>("sp_ListSelCount_Detalle_de_Padecimientos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Padecimientos>("sp_ListSelAll_Detalle_de_Padecimientos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos
                {
                    Folio = m.Detalle_de_Padecimientos_Folio,
                    Folio_Pacientes = m.Detalle_de_Padecimientos_Folio_Pacientes,
                    Padecimiento = m.Detalle_de_Padecimientos_Padecimiento,
                    Tiempo_con_el_diagnostico = m.Detalle_de_Padecimientos_Tiempo_con_el_diagnostico,
                    Intervencion_quirurgica = m.Detalle_de_Padecimientos_Intervencion_quirurgica,
                    Tratamiento = m.Detalle_de_Padecimientos_Tratamiento,
                    Estado_actual = m.Detalle_de_Padecimientos_Estado_actual,

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

        public IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_PadecimientosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Padecimientos>("sp_ListSelAll_Detalle_de_Padecimientos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_PadecimientosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_PadecimientosPagingModel
                {
                    Detalle_de_Padecimientoss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos
                {
                    Folio = m.Detalle_de_Padecimientos_Folio
                    ,Folio_Pacientes = m.Detalle_de_Padecimientos_Folio_Pacientes
                    ,Padecimiento = m.Detalle_de_Padecimientos_Padecimiento
                    ,Padecimiento_Padecimientos = new Core.Classes.Padecimientos.Padecimientos() { Clave = m.Detalle_de_Padecimientos_Padecimiento.GetValueOrDefault(), Descripcion = m.Detalle_de_Padecimientos_Padecimiento_Descripcion }
                    ,Tiempo_con_el_diagnostico = m.Detalle_de_Padecimientos_Tiempo_con_el_diagnostico
                    ,Tiempo_con_el_diagnostico_Tiempo_Padecimiento = new Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento() { Clave = m.Detalle_de_Padecimientos_Tiempo_con_el_diagnostico.GetValueOrDefault(), Descripcion = m.Detalle_de_Padecimientos_Tiempo_con_el_diagnostico_Descripcion }
                    ,Intervencion_quirurgica = m.Detalle_de_Padecimientos_Intervencion_quirurgica
                    ,Intervencion_quirurgica_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Detalle_de_Padecimientos_Intervencion_quirurgica.GetValueOrDefault(), Descripcion = m.Detalle_de_Padecimientos_Intervencion_quirurgica_Descripcion }
                    ,Tratamiento = m.Detalle_de_Padecimientos_Tratamiento
                    ,Estado_actual = m.Detalle_de_Padecimientos_Estado_actual
                    ,Estado_actual_Estatus_Padecimiento = new Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento() { Clave = m.Detalle_de_Padecimientos_Estado_actual.GetValueOrDefault(), Descripcion = m.Detalle_de_Padecimientos_Estado_actual_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_PadecimientosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos>("sp_GetDetalle_de_Padecimientos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Padecimientos>("sp_DelDetalle_de_Padecimientos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Pacientes = _dataProvider.GetParameter();
                padreFolio_Pacientes.ParameterName = "Folio_Pacientes";
                padreFolio_Pacientes.DbType = DbType.Int32;
                padreFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var padrePadecimiento = _dataProvider.GetParameter();
                padrePadecimiento.ParameterName = "Padecimiento";
                padrePadecimiento.DbType = DbType.Int32;
                padrePadecimiento.Value = (object)entity.Padecimiento ?? DBNull.Value;

                var padreTiempo_con_el_diagnostico = _dataProvider.GetParameter();
                padreTiempo_con_el_diagnostico.ParameterName = "Tiempo_con_el_diagnostico";
                padreTiempo_con_el_diagnostico.DbType = DbType.Int32;
                padreTiempo_con_el_diagnostico.Value = (object)entity.Tiempo_con_el_diagnostico ?? DBNull.Value;

                var padreIntervencion_quirurgica = _dataProvider.GetParameter();
                padreIntervencion_quirurgica.ParameterName = "Intervencion_quirurgica";
                padreIntervencion_quirurgica.DbType = DbType.Int32;
                padreIntervencion_quirurgica.Value = (object)entity.Intervencion_quirurgica ?? DBNull.Value;

                var padreTratamiento = _dataProvider.GetParameter();
                padreTratamiento.ParameterName = "Tratamiento";
                padreTratamiento.DbType = DbType.String;
                padreTratamiento.Value = (object)entity.Tratamiento ?? DBNull.Value;
                var padreEstado_actual = _dataProvider.GetParameter();
                padreEstado_actual.ParameterName = "Estado_actual";
                padreEstado_actual.DbType = DbType.Int32;
                padreEstado_actual.Value = (object)entity.Estado_actual ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Padecimientos>("sp_InsDetalle_de_Padecimientos" , padreFolio_Pacientes
, padrePadecimiento
, padreTiempo_con_el_diagnostico
, padreIntervencion_quirurgica
, padreTratamiento
, padreEstado_actual
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

        public int Update(Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var paramUpdPadecimiento = _dataProvider.GetParameter();
                paramUpdPadecimiento.ParameterName = "Padecimiento";
                paramUpdPadecimiento.DbType = DbType.Int32;
                paramUpdPadecimiento.Value = (object)entity.Padecimiento ?? DBNull.Value;

                var paramUpdTiempo_con_el_diagnostico = _dataProvider.GetParameter();
                paramUpdTiempo_con_el_diagnostico.ParameterName = "Tiempo_con_el_diagnostico";
                paramUpdTiempo_con_el_diagnostico.DbType = DbType.Int32;
                paramUpdTiempo_con_el_diagnostico.Value = (object)entity.Tiempo_con_el_diagnostico ?? DBNull.Value;

                var paramUpdIntervencion_quirurgica = _dataProvider.GetParameter();
                paramUpdIntervencion_quirurgica.ParameterName = "Intervencion_quirurgica";
                paramUpdIntervencion_quirurgica.DbType = DbType.Int32;
                paramUpdIntervencion_quirurgica.Value = (object)entity.Intervencion_quirurgica ?? DBNull.Value;

                var paramUpdTratamiento = _dataProvider.GetParameter();
                paramUpdTratamiento.ParameterName = "Tratamiento";
                paramUpdTratamiento.DbType = DbType.String;
                paramUpdTratamiento.Value = (object)entity.Tratamiento ?? DBNull.Value;
                var paramUpdEstado_actual = _dataProvider.GetParameter();
                paramUpdEstado_actual.ParameterName = "Estado_actual";
                paramUpdEstado_actual.DbType = DbType.Int32;
                paramUpdEstado_actual.Value = (object)entity.Estado_actual ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Padecimientos>("sp_UpdDetalle_de_Padecimientos" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdPadecimiento , paramUpdTiempo_con_el_diagnostico , paramUpdIntervencion_quirurgica , paramUpdTratamiento , paramUpdEstado_actual ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos Detalle_de_PadecimientosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
		var paramUpdPadecimiento = _dataProvider.GetParameter();
                paramUpdPadecimiento.ParameterName = "Padecimiento";
                paramUpdPadecimiento.DbType = DbType.Int32;
                paramUpdPadecimiento.Value = (object)entity.Padecimiento ?? DBNull.Value;
		var paramUpdTiempo_con_el_diagnostico = _dataProvider.GetParameter();
                paramUpdTiempo_con_el_diagnostico.ParameterName = "Tiempo_con_el_diagnostico";
                paramUpdTiempo_con_el_diagnostico.DbType = DbType.Int32;
                paramUpdTiempo_con_el_diagnostico.Value = (object)entity.Tiempo_con_el_diagnostico ?? DBNull.Value;
		var paramUpdIntervencion_quirurgica = _dataProvider.GetParameter();
                paramUpdIntervencion_quirurgica.ParameterName = "Intervencion_quirurgica";
                paramUpdIntervencion_quirurgica.DbType = DbType.Int32;
                paramUpdIntervencion_quirurgica.Value = (object)entity.Intervencion_quirurgica ?? DBNull.Value;
                var paramUpdTratamiento = _dataProvider.GetParameter();
                paramUpdTratamiento.ParameterName = "Tratamiento";
                paramUpdTratamiento.DbType = DbType.String;
                paramUpdTratamiento.Value = (object)entity.Tratamiento ?? DBNull.Value;
		var paramUpdEstado_actual = _dataProvider.GetParameter();
                paramUpdEstado_actual.ParameterName = "Estado_actual";
                paramUpdEstado_actual.DbType = DbType.Int32;
                paramUpdEstado_actual.Value = (object)entity.Estado_actual ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Padecimientos>("sp_UpdDetalle_de_Padecimientos" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdPadecimiento , paramUpdTiempo_con_el_diagnostico , paramUpdIntervencion_quirurgica , paramUpdTratamiento , paramUpdEstado_actual ).FirstOrDefault();

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


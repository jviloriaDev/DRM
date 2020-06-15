using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Horarios_Actividad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Horarios_Actividad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Horarios_ActividadService : IDetalle_Horarios_ActividadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> _Detalle_Horarios_ActividadRepository;
        #endregion

        #region Ctor
        public Detalle_Horarios_ActividadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> Detalle_Horarios_ActividadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Horarios_ActividadRepository = Detalle_Horarios_ActividadRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Horarios_ActividadRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>("sp_SelAllDetalle_Horarios_Actividad");
        }

        public IList<Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Horarios_Actividad_Complete>("sp_SelAllComplete_Detalle_Horarios_Actividad");
            return data.Select(m => new Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad
            {
                Folio = m.Folio
                ,Folio_Actividades = m.Folio_Actividades
                ,Reservada = m.Reservada.GetValueOrDefault()
                ,Numero_de_Cita = m.Numero_de_Cita
                ,Hora_inicio = m.Hora_inicio
                ,Hora_fin = m.Hora_fin
                ,Horario = m.Horario
                ,Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento = new Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento() { Folio = m.Codigo_de_Reservacion.GetValueOrDefault(), Codigo_Reservacion = m.Codigo_de_Reservacion_Codigo_Reservacion }
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,Familiar_del_Empleado = m.Familiar_del_Empleado.GetValueOrDefault()
                ,Nombre_Completo = m.Nombre_Completo
                ,Parentesco_con_el_Empleado_Parentescos_Empleados = new Core.Classes.Parentescos_Empleados.Parentescos_Empleados() { Folio = m.Parentesco_con_el_Empleado.GetValueOrDefault(), Descripcion = m.Parentesco_con_el_Empleado_Descripcion }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Edad = m.Edad
                ,Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad = new Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad() { Folio = m.Estatus_de_la_Reservacion.GetValueOrDefault(), Descripcion = m.Estatus_de_la_Reservacion_Descripcion }
                ,Asistio = m.Asistio.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Horarios_Actividad>("sp_ListSelCount_Detalle_Horarios_Actividad", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Horarios_Actividad>("sp_ListSelAll_Detalle_Horarios_Actividad", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad
                {
                    Folio = m.Detalle_Horarios_Actividad_Folio,
                    Folio_Actividades = m.Detalle_Horarios_Actividad_Folio_Actividades,
                    Reservada = m.Detalle_Horarios_Actividad_Reservada ?? false,
                    Numero_de_Cita = m.Detalle_Horarios_Actividad_Numero_de_Cita,
                    Hora_inicio = m.Detalle_Horarios_Actividad_Hora_inicio,
                    Hora_fin = m.Detalle_Horarios_Actividad_Hora_fin,
                    Horario = m.Detalle_Horarios_Actividad_Horario,
                    Codigo_de_Reservacion = m.Detalle_Horarios_Actividad_Codigo_de_Reservacion,
                    Numero_de_Empleado = m.Detalle_Horarios_Actividad_Numero_de_Empleado,
                    Familiar_del_Empleado = m.Detalle_Horarios_Actividad_Familiar_del_Empleado ?? false,
                    Nombre_Completo = m.Detalle_Horarios_Actividad_Nombre_Completo,
                    Parentesco_con_el_Empleado = m.Detalle_Horarios_Actividad_Parentesco_con_el_Empleado,
                    Sexo = m.Detalle_Horarios_Actividad_Sexo,
                    Edad = m.Detalle_Horarios_Actividad_Edad,
                    Estatus_de_la_Reservacion = m.Detalle_Horarios_Actividad_Estatus_de_la_Reservacion,
                    Asistio = m.Detalle_Horarios_Actividad_Asistio ?? false,

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

        public IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Horarios_ActividadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Horarios_ActividadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_ActividadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Horarios_Actividad>("sp_ListSelAll_Detalle_Horarios_Actividad", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Horarios_ActividadPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Horarios_ActividadPagingModel
                {
                    Detalle_Horarios_Actividads =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad
                {
                    Folio = m.Detalle_Horarios_Actividad_Folio
                    ,Folio_Actividades = m.Detalle_Horarios_Actividad_Folio_Actividades
                    ,Reservada = m.Detalle_Horarios_Actividad_Reservada ?? false
                    ,Numero_de_Cita = m.Detalle_Horarios_Actividad_Numero_de_Cita
                    ,Hora_inicio = m.Detalle_Horarios_Actividad_Hora_inicio
                    ,Hora_fin = m.Detalle_Horarios_Actividad_Hora_fin
                    ,Horario = m.Detalle_Horarios_Actividad_Horario
                    ,Codigo_de_Reservacion = m.Detalle_Horarios_Actividad_Codigo_de_Reservacion
                    ,Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento = new Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento() { Folio = m.Detalle_Horarios_Actividad_Codigo_de_Reservacion.GetValueOrDefault(), Codigo_Reservacion = m.Detalle_Horarios_Actividad_Codigo_de_Reservacion_Codigo_Reservacion }
                    ,Numero_de_Empleado = m.Detalle_Horarios_Actividad_Numero_de_Empleado
                    ,Familiar_del_Empleado = m.Detalle_Horarios_Actividad_Familiar_del_Empleado ?? false
                    ,Nombre_Completo = m.Detalle_Horarios_Actividad_Nombre_Completo
                    ,Parentesco_con_el_Empleado = m.Detalle_Horarios_Actividad_Parentesco_con_el_Empleado
                    ,Parentesco_con_el_Empleado_Parentescos_Empleados = new Core.Classes.Parentescos_Empleados.Parentescos_Empleados() { Folio = m.Detalle_Horarios_Actividad_Parentesco_con_el_Empleado.GetValueOrDefault(), Descripcion = m.Detalle_Horarios_Actividad_Parentesco_con_el_Empleado_Descripcion }
                    ,Sexo = m.Detalle_Horarios_Actividad_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Detalle_Horarios_Actividad_Sexo.GetValueOrDefault(), Descripcion = m.Detalle_Horarios_Actividad_Sexo_Descripcion }
                    ,Edad = m.Detalle_Horarios_Actividad_Edad
                    ,Estatus_de_la_Reservacion = m.Detalle_Horarios_Actividad_Estatus_de_la_Reservacion
                    ,Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad = new Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad() { Folio = m.Detalle_Horarios_Actividad_Estatus_de_la_Reservacion.GetValueOrDefault(), Descripcion = m.Detalle_Horarios_Actividad_Estatus_de_la_Reservacion_Descripcion }
                    ,Asistio = m.Detalle_Horarios_Actividad_Asistio ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Horarios_ActividadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>("sp_GetDetalle_Horarios_Actividad", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Horarios_Actividad>("sp_DelDetalle_Horarios_Actividad", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Actividades = _dataProvider.GetParameter();
                padreFolio_Actividades.ParameterName = "Folio_Actividades";
                padreFolio_Actividades.DbType = DbType.Int32;
                padreFolio_Actividades.Value = (object)entity.Folio_Actividades ?? DBNull.Value;
                var padreReservada = _dataProvider.GetParameter();
                padreReservada.ParameterName = "Reservada";
                padreReservada.DbType = DbType.Boolean;
                padreReservada.Value = (object)entity.Reservada ?? DBNull.Value;
                var padreNumero_de_Cita = _dataProvider.GetParameter();
                padreNumero_de_Cita.ParameterName = "Numero_de_Cita";
                padreNumero_de_Cita.DbType = DbType.Int32;
                padreNumero_de_Cita.Value = (object)entity.Numero_de_Cita ?? DBNull.Value;

                var padreHora_inicio = _dataProvider.GetParameter();
                padreHora_inicio.ParameterName = "Hora_inicio";
                padreHora_inicio.DbType = DbType.String;
                padreHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var padreHora_fin = _dataProvider.GetParameter();
                padreHora_fin.ParameterName = "Hora_fin";
                padreHora_fin.DbType = DbType.String;
                padreHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var padreHorario = _dataProvider.GetParameter();
                padreHorario.ParameterName = "Horario";
                padreHorario.DbType = DbType.String;
                padreHorario.Value = (object)entity.Horario ?? DBNull.Value;
                var padreCodigo_de_Reservacion = _dataProvider.GetParameter();
                padreCodigo_de_Reservacion.ParameterName = "Codigo_de_Reservacion";
                padreCodigo_de_Reservacion.DbType = DbType.Int32;
                padreCodigo_de_Reservacion.Value = (object)entity.Codigo_de_Reservacion ?? DBNull.Value;

                var padreNumero_de_Empleado = _dataProvider.GetParameter();
                padreNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                padreNumero_de_Empleado.DbType = DbType.String;
                padreNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var padreFamiliar_del_Empleado = _dataProvider.GetParameter();
                padreFamiliar_del_Empleado.ParameterName = "Familiar_del_Empleado";
                padreFamiliar_del_Empleado.DbType = DbType.Boolean;
                padreFamiliar_del_Empleado.Value = (object)entity.Familiar_del_Empleado ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreParentesco_con_el_Empleado = _dataProvider.GetParameter();
                padreParentesco_con_el_Empleado.ParameterName = "Parentesco_con_el_Empleado";
                padreParentesco_con_el_Empleado.DbType = DbType.Int32;
                padreParentesco_con_el_Empleado.Value = (object)entity.Parentesco_con_el_Empleado ?? DBNull.Value;

                var padreSexo = _dataProvider.GetParameter();
                padreSexo.ParameterName = "Sexo";
                padreSexo.DbType = DbType.Int32;
                padreSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var padreEdad = _dataProvider.GetParameter();
                padreEdad.ParameterName = "Edad";
                padreEdad.DbType = DbType.Int32;
                padreEdad.Value = (object)entity.Edad ?? DBNull.Value;

                var padreEstatus_de_la_Reservacion = _dataProvider.GetParameter();
                padreEstatus_de_la_Reservacion.ParameterName = "Estatus_de_la_Reservacion";
                padreEstatus_de_la_Reservacion.DbType = DbType.Int32;
                padreEstatus_de_la_Reservacion.Value = (object)entity.Estatus_de_la_Reservacion ?? DBNull.Value;

                var padreAsistio = _dataProvider.GetParameter();
                padreAsistio.ParameterName = "Asistio";
                padreAsistio.DbType = DbType.Boolean;
                padreAsistio.Value = (object)entity.Asistio ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Horarios_Actividad>("sp_InsDetalle_Horarios_Actividad" , padreFolio_Actividades
, padreReservada
, padreNumero_de_Cita
, padreHora_inicio
, padreHora_fin
, padreHorario
, padreCodigo_de_Reservacion
, padreNumero_de_Empleado
, padreFamiliar_del_Empleado
, padreNombre_Completo
, padreParentesco_con_el_Empleado
, padreSexo
, padreEdad
, padreEstatus_de_la_Reservacion
, padreAsistio
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

        public int Update(Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Actividades = _dataProvider.GetParameter();
                paramUpdFolio_Actividades.ParameterName = "Folio_Actividades";
                paramUpdFolio_Actividades.DbType = DbType.Int32;
                paramUpdFolio_Actividades.Value = (object)entity.Folio_Actividades ?? DBNull.Value;
                var paramUpdReservada = _dataProvider.GetParameter();
                paramUpdReservada.ParameterName = "Reservada";
                paramUpdReservada.DbType = DbType.Boolean;
                paramUpdReservada.Value = (object)entity.Reservada ?? DBNull.Value;
                var paramUpdNumero_de_Cita = _dataProvider.GetParameter();
                paramUpdNumero_de_Cita.ParameterName = "Numero_de_Cita";
                paramUpdNumero_de_Cita.DbType = DbType.Int32;
                paramUpdNumero_de_Cita.Value = (object)entity.Numero_de_Cita ?? DBNull.Value;

                var paramUpdHora_inicio = _dataProvider.GetParameter();
                paramUpdHora_inicio.ParameterName = "Hora_inicio";
                paramUpdHora_inicio.DbType = DbType.String;
                paramUpdHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var paramUpdHora_fin = _dataProvider.GetParameter();
                paramUpdHora_fin.ParameterName = "Hora_fin";
                paramUpdHora_fin.DbType = DbType.String;
                paramUpdHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var paramUpdHorario = _dataProvider.GetParameter();
                paramUpdHorario.ParameterName = "Horario";
                paramUpdHorario.DbType = DbType.String;
                paramUpdHorario.Value = (object)entity.Horario ?? DBNull.Value;
                var paramUpdCodigo_de_Reservacion = _dataProvider.GetParameter();
                paramUpdCodigo_de_Reservacion.ParameterName = "Codigo_de_Reservacion";
                paramUpdCodigo_de_Reservacion.DbType = DbType.Int32;
                paramUpdCodigo_de_Reservacion.Value = (object)entity.Codigo_de_Reservacion ?? DBNull.Value;

                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdFamiliar_del_Empleado = _dataProvider.GetParameter();
                paramUpdFamiliar_del_Empleado.ParameterName = "Familiar_del_Empleado";
                paramUpdFamiliar_del_Empleado.DbType = DbType.Boolean;
                paramUpdFamiliar_del_Empleado.Value = (object)entity.Familiar_del_Empleado ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdParentesco_con_el_Empleado = _dataProvider.GetParameter();
                paramUpdParentesco_con_el_Empleado.ParameterName = "Parentesco_con_el_Empleado";
                paramUpdParentesco_con_el_Empleado.DbType = DbType.Int32;
                paramUpdParentesco_con_el_Empleado.Value = (object)entity.Parentesco_con_el_Empleado ?? DBNull.Value;

                var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var paramUpdEdad = _dataProvider.GetParameter();
                paramUpdEdad.ParameterName = "Edad";
                paramUpdEdad.DbType = DbType.Int32;
                paramUpdEdad.Value = (object)entity.Edad ?? DBNull.Value;

                var paramUpdEstatus_de_la_Reservacion = _dataProvider.GetParameter();
                paramUpdEstatus_de_la_Reservacion.ParameterName = "Estatus_de_la_Reservacion";
                paramUpdEstatus_de_la_Reservacion.DbType = DbType.Int32;
                paramUpdEstatus_de_la_Reservacion.Value = (object)entity.Estatus_de_la_Reservacion ?? DBNull.Value;

                var paramUpdAsistio = _dataProvider.GetParameter();
                paramUpdAsistio.ParameterName = "Asistio";
                paramUpdAsistio.DbType = DbType.Boolean;
                paramUpdAsistio.Value = (object)entity.Asistio ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Horarios_Actividad>("sp_UpdDetalle_Horarios_Actividad" , paramUpdFolio , paramUpdFolio_Actividades , paramUpdReservada , paramUpdNumero_de_Cita , paramUpdHora_inicio , paramUpdHora_fin , paramUpdHorario , paramUpdCodigo_de_Reservacion , paramUpdNumero_de_Empleado , paramUpdFamiliar_del_Empleado , paramUpdNombre_Completo , paramUpdParentesco_con_el_Empleado , paramUpdSexo , paramUpdEdad , paramUpdEstatus_de_la_Reservacion , paramUpdAsistio ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad Detalle_Horarios_ActividadDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Actividades = _dataProvider.GetParameter();
                paramUpdFolio_Actividades.ParameterName = "Folio_Actividades";
                paramUpdFolio_Actividades.DbType = DbType.Int32;
                paramUpdFolio_Actividades.Value = (object)entity.Folio_Actividades ?? DBNull.Value;
                var paramUpdReservada = _dataProvider.GetParameter();
                paramUpdReservada.ParameterName = "Reservada";
                paramUpdReservada.DbType = DbType.Boolean;
                paramUpdReservada.Value = (object)entity.Reservada ?? DBNull.Value;
                var paramUpdNumero_de_Cita = _dataProvider.GetParameter();
                paramUpdNumero_de_Cita.ParameterName = "Numero_de_Cita";
                paramUpdNumero_de_Cita.DbType = DbType.Int32;
                paramUpdNumero_de_Cita.Value = (object)entity.Numero_de_Cita ?? DBNull.Value;
                var paramUpdHora_inicio = _dataProvider.GetParameter();
                paramUpdHora_inicio.ParameterName = "Hora_inicio";
                paramUpdHora_inicio.DbType = DbType.String;
                paramUpdHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var paramUpdHora_fin = _dataProvider.GetParameter();
                paramUpdHora_fin.ParameterName = "Hora_fin";
                paramUpdHora_fin.DbType = DbType.String;
                paramUpdHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var paramUpdHorario = _dataProvider.GetParameter();
                paramUpdHorario.ParameterName = "Horario";
                paramUpdHorario.DbType = DbType.String;
                paramUpdHorario.Value = (object)entity.Horario ?? DBNull.Value;
		var paramUpdCodigo_de_Reservacion = _dataProvider.GetParameter();
                paramUpdCodigo_de_Reservacion.ParameterName = "Codigo_de_Reservacion";
                paramUpdCodigo_de_Reservacion.DbType = DbType.Int32;
                paramUpdCodigo_de_Reservacion.Value = (object)entity.Codigo_de_Reservacion ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdFamiliar_del_Empleado = _dataProvider.GetParameter();
                paramUpdFamiliar_del_Empleado.ParameterName = "Familiar_del_Empleado";
                paramUpdFamiliar_del_Empleado.DbType = DbType.Boolean;
                paramUpdFamiliar_del_Empleado.Value = (object)entity.Familiar_del_Empleado ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
		var paramUpdParentesco_con_el_Empleado = _dataProvider.GetParameter();
                paramUpdParentesco_con_el_Empleado.ParameterName = "Parentesco_con_el_Empleado";
                paramUpdParentesco_con_el_Empleado.DbType = DbType.Int32;
                paramUpdParentesco_con_el_Empleado.Value = (object)entity.Parentesco_con_el_Empleado ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;
                var paramUpdEdad = _dataProvider.GetParameter();
                paramUpdEdad.ParameterName = "Edad";
                paramUpdEdad.DbType = DbType.Int32;
                paramUpdEdad.Value = (object)entity.Edad ?? DBNull.Value;
		var paramUpdEstatus_de_la_Reservacion = _dataProvider.GetParameter();
                paramUpdEstatus_de_la_Reservacion.ParameterName = "Estatus_de_la_Reservacion";
                paramUpdEstatus_de_la_Reservacion.DbType = DbType.Int32;
                paramUpdEstatus_de_la_Reservacion.Value = (object)entity.Estatus_de_la_Reservacion ?? DBNull.Value;
                var paramUpdAsistio = _dataProvider.GetParameter();
                paramUpdAsistio.ParameterName = "Asistio";
                paramUpdAsistio.DbType = DbType.Boolean;
                paramUpdAsistio.Value = (object)entity.Asistio ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Horarios_Actividad>("sp_UpdDetalle_Horarios_Actividad" , paramUpdFolio , paramUpdFolio_Actividades , paramUpdReservada , paramUpdNumero_de_Cita , paramUpdHora_inicio , paramUpdHora_fin , paramUpdHorario , paramUpdCodigo_de_Reservacion , paramUpdNumero_de_Empleado , paramUpdFamiliar_del_Empleado , paramUpdNombre_Completo , paramUpdParentesco_con_el_Empleado , paramUpdSexo , paramUpdEdad , paramUpdEstatus_de_la_Reservacion , paramUpdAsistio ).FirstOrDefault();

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


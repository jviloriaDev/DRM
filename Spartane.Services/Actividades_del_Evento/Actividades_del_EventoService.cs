using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Actividades_del_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Actividades_del_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Actividades_del_EventoService : IActividades_del_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento> _Actividades_del_EventoRepository;
        #endregion

        #region Ctor
        public Actividades_del_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento> Actividades_del_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Actividades_del_EventoRepository = Actividades_del_EventoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Actividades_del_EventoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento>("sp_SelAllActividades_del_Evento");
        }

        public IList<Core.Classes.Actividades_del_Evento.Actividades_del_Evento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallActividades_del_Evento_Complete>("sp_SelAllComplete_Actividades_del_Evento");
            return data.Select(m => new Core.Classes.Actividades_del_Evento.Actividades_del_Evento
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Evento_Eventos = new Core.Classes.Eventos.Eventos() { Folio = m.Evento.GetValueOrDefault(), Nombre_del_Evento = m.Evento_Nombre_del_Evento }
                ,Actividad_Detalle_Actividades_Evento = new Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento() { Folio = m.Actividad.GetValueOrDefault(), Nombre_de_la_Actividad = m.Actividad_Nombre_de_la_Actividad }
                ,Descripcion = m.Descripcion
                ,Dia = m.Dia
                ,Hora_inicio = m.Hora_inicio
                ,Hora_fin = m.Hora_fin
                ,Tiene_receso = m.Tiene_receso.GetValueOrDefault()
                ,Hora_inicio_receso = m.Hora_inicio_receso
                ,Hora_fin_receso = m.Hora_fin_receso
                ,Ubicacion_Ubicaciones_Eventos_Empresa = new Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa() { Folio = m.Ubicacion.GetValueOrDefault(), Nombre = m.Ubicacion_Nombre }
                ,Tipo_de_Actividad_Tipos_de_Actividades = new Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades() { Folio = m.Tipo_de_Actividad.GetValueOrDefault(), Descripcion = m.Tipo_de_Actividad_Descripcion }
                ,Quien_imparte_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Quien_imparte.GetValueOrDefault(), Name = m.Quien_imparte_Name }
                ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Especialidad.GetValueOrDefault(), Especialidad = m.Especialidad_Especialidad }
                ,Cupo_limitado = m.Cupo_limitado.GetValueOrDefault()
                ,Cupo_maximo = m.Cupo_maximo
                ,Duracion_maxima_por_Paciente_mins = m.Duracion_maxima_por_Paciente_mins
                ,Estatus_Estatus_Actividades_Evento = new Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento() { Folio = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Actividades_del_Evento>("sp_ListSelCount_Actividades_del_Evento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllActividades_del_Evento>("sp_ListSelAll_Actividades_del_Evento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento
                {
                    Folio = m.Actividades_del_Evento_Folio,
                    Fecha_de_Registro = m.Actividades_del_Evento_Fecha_de_Registro,
                    Hora_de_Registro = m.Actividades_del_Evento_Hora_de_Registro,
                    Usuario_que_Registra = m.Actividades_del_Evento_Usuario_que_Registra,
                    Evento = m.Actividades_del_Evento_Evento,
                    Actividad = m.Actividades_del_Evento_Actividad,
                    Descripcion = m.Actividades_del_Evento_Descripcion,
                    Dia = m.Actividades_del_Evento_Dia,
                    Hora_inicio = m.Actividades_del_Evento_Hora_inicio,
                    Hora_fin = m.Actividades_del_Evento_Hora_fin,
                    Tiene_receso = m.Actividades_del_Evento_Tiene_receso ?? false,
                    Hora_inicio_receso = m.Actividades_del_Evento_Hora_inicio_receso,
                    Hora_fin_receso = m.Actividades_del_Evento_Hora_fin_receso,
                    Ubicacion = m.Actividades_del_Evento_Ubicacion,
                    Tipo_de_Actividad = m.Actividades_del_Evento_Tipo_de_Actividad,
                    Quien_imparte = m.Actividades_del_Evento_Quien_imparte,
                    Especialidad = m.Actividades_del_Evento_Especialidad,
                    Cupo_limitado = m.Actividades_del_Evento_Cupo_limitado ?? false,
                    Cupo_maximo = m.Actividades_del_Evento_Cupo_maximo,
                    Duracion_maxima_por_Paciente_mins = m.Actividades_del_Evento_Duracion_maxima_por_Paciente_mins,
                    Estatus = m.Actividades_del_Evento_Estatus,

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

        public IList<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Actividades_del_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Actividades_del_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllActividades_del_Evento>("sp_ListSelAll_Actividades_del_Evento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Actividades_del_EventoPagingModel result = null;

            if (data != null)
            {
                result = new Actividades_del_EventoPagingModel
                {
                    Actividades_del_Eventos =
                        data.Select(m => new Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento
                {
                    Folio = m.Actividades_del_Evento_Folio
                    ,Fecha_de_Registro = m.Actividades_del_Evento_Fecha_de_Registro
                    ,Hora_de_Registro = m.Actividades_del_Evento_Hora_de_Registro
                    ,Usuario_que_Registra = m.Actividades_del_Evento_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Actividades_del_Evento_Usuario_que_Registra.GetValueOrDefault(), Name = m.Actividades_del_Evento_Usuario_que_Registra_Name }
                    ,Evento = m.Actividades_del_Evento_Evento
                    ,Evento_Eventos = new Core.Classes.Eventos.Eventos() { Folio = m.Actividades_del_Evento_Evento.GetValueOrDefault(), Nombre_del_Evento = m.Actividades_del_Evento_Evento_Nombre_del_Evento }
                    ,Actividad = m.Actividades_del_Evento_Actividad
                    ,Actividad_Detalle_Actividades_Evento = new Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento() { Folio = m.Actividades_del_Evento_Actividad.GetValueOrDefault(), Nombre_de_la_Actividad = m.Actividades_del_Evento_Actividad_Nombre_de_la_Actividad }
                    ,Descripcion = m.Actividades_del_Evento_Descripcion
                    ,Dia = m.Actividades_del_Evento_Dia
                    ,Hora_inicio = m.Actividades_del_Evento_Hora_inicio
                    ,Hora_fin = m.Actividades_del_Evento_Hora_fin
                    ,Tiene_receso = m.Actividades_del_Evento_Tiene_receso ?? false
                    ,Hora_inicio_receso = m.Actividades_del_Evento_Hora_inicio_receso
                    ,Hora_fin_receso = m.Actividades_del_Evento_Hora_fin_receso
                    ,Ubicacion = m.Actividades_del_Evento_Ubicacion
                    ,Ubicacion_Ubicaciones_Eventos_Empresa = new Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa() { Folio = m.Actividades_del_Evento_Ubicacion.GetValueOrDefault(), Nombre = m.Actividades_del_Evento_Ubicacion_Nombre }
                    ,Tipo_de_Actividad = m.Actividades_del_Evento_Tipo_de_Actividad
                    ,Tipo_de_Actividad_Tipos_de_Actividades = new Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades() { Folio = m.Actividades_del_Evento_Tipo_de_Actividad.GetValueOrDefault(), Descripcion = m.Actividades_del_Evento_Tipo_de_Actividad_Descripcion }
                    ,Quien_imparte = m.Actividades_del_Evento_Quien_imparte
                    ,Quien_imparte_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Actividades_del_Evento_Quien_imparte.GetValueOrDefault(), Name = m.Actividades_del_Evento_Quien_imparte_Name }
                    ,Especialidad = m.Actividades_del_Evento_Especialidad
                    ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Actividades_del_Evento_Especialidad.GetValueOrDefault(), Especialidad = m.Actividades_del_Evento_Especialidad_Especialidad }
                    ,Cupo_limitado = m.Actividades_del_Evento_Cupo_limitado ?? false
                    ,Cupo_maximo = m.Actividades_del_Evento_Cupo_maximo
                    ,Duracion_maxima_por_Paciente_mins = m.Actividades_del_Evento_Duracion_maxima_por_Paciente_mins
                    ,Estatus = m.Actividades_del_Evento_Estatus
                    ,Estatus_Estatus_Actividades_Evento = new Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento() { Folio = m.Actividades_del_Evento_Estatus.GetValueOrDefault(), Descripcion = m.Actividades_del_Evento_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Actividades_del_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento>("sp_GetActividades_del_Evento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelActividades_del_Evento>("sp_DelActividades_del_Evento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreEvento = _dataProvider.GetParameter();
                padreEvento.ParameterName = "Evento";
                padreEvento.DbType = DbType.Int32;
                padreEvento.Value = (object)entity.Evento ?? DBNull.Value;

                var padreActividad = _dataProvider.GetParameter();
                padreActividad.ParameterName = "Actividad";
                padreActividad.DbType = DbType.Int32;
                padreActividad.Value = (object)entity.Actividad ?? DBNull.Value;

                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreDia = _dataProvider.GetParameter();
                padreDia.ParameterName = "Dia";
                padreDia.DbType = DbType.DateTime;
                padreDia.Value = (object)entity.Dia ?? DBNull.Value;

                var padreHora_inicio = _dataProvider.GetParameter();
                padreHora_inicio.ParameterName = "Hora_inicio";
                padreHora_inicio.DbType = DbType.String;
                padreHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var padreHora_fin = _dataProvider.GetParameter();
                padreHora_fin.ParameterName = "Hora_fin";
                padreHora_fin.DbType = DbType.String;
                padreHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var padreTiene_receso = _dataProvider.GetParameter();
                padreTiene_receso.ParameterName = "Tiene_receso";
                padreTiene_receso.DbType = DbType.Boolean;
                padreTiene_receso.Value = (object)entity.Tiene_receso ?? DBNull.Value;
                var padreHora_inicio_receso = _dataProvider.GetParameter();
                padreHora_inicio_receso.ParameterName = "Hora_inicio_receso";
                padreHora_inicio_receso.DbType = DbType.String;
                padreHora_inicio_receso.Value = (object)entity.Hora_inicio_receso ?? DBNull.Value;
                var padreHora_fin_receso = _dataProvider.GetParameter();
                padreHora_fin_receso.ParameterName = "Hora_fin_receso";
                padreHora_fin_receso.DbType = DbType.String;
                padreHora_fin_receso.Value = (object)entity.Hora_fin_receso ?? DBNull.Value;
                var padreUbicacion = _dataProvider.GetParameter();
                padreUbicacion.ParameterName = "Ubicacion";
                padreUbicacion.DbType = DbType.Int32;
                padreUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;

                var padreTipo_de_Actividad = _dataProvider.GetParameter();
                padreTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                padreTipo_de_Actividad.DbType = DbType.Int32;
                padreTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;

                var padreQuien_imparte = _dataProvider.GetParameter();
                padreQuien_imparte.ParameterName = "Quien_imparte";
                padreQuien_imparte.DbType = DbType.Int32;
                padreQuien_imparte.Value = (object)entity.Quien_imparte ?? DBNull.Value;

                var padreEspecialidad = _dataProvider.GetParameter();
                padreEspecialidad.ParameterName = "Especialidad";
                padreEspecialidad.DbType = DbType.Int32;
                padreEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var padreCupo_limitado = _dataProvider.GetParameter();
                padreCupo_limitado.ParameterName = "Cupo_limitado";
                padreCupo_limitado.DbType = DbType.Boolean;
                padreCupo_limitado.Value = (object)entity.Cupo_limitado ?? DBNull.Value;
                var padreCupo_maximo = _dataProvider.GetParameter();
                padreCupo_maximo.ParameterName = "Cupo_maximo";
                padreCupo_maximo.DbType = DbType.Int32;
                padreCupo_maximo.Value = (object)entity.Cupo_maximo ?? DBNull.Value;

                var padreDuracion_maxima_por_Paciente_mins = _dataProvider.GetParameter();
                padreDuracion_maxima_por_Paciente_mins.ParameterName = "Duracion_maxima_por_Paciente_mins";
                padreDuracion_maxima_por_Paciente_mins.DbType = DbType.Int32;
                padreDuracion_maxima_por_Paciente_mins.Value = (object)entity.Duracion_maxima_por_Paciente_mins ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsActividades_del_Evento>("sp_InsActividades_del_Evento" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreEvento
, padreActividad
, padreDescripcion
, padreDia
, padreHora_inicio
, padreHora_fin
, padreTiene_receso
, padreHora_inicio_receso
, padreHora_fin_receso
, padreUbicacion
, padreTipo_de_Actividad
, padreQuien_imparte
, padreEspecialidad
, padreCupo_limitado
, padreCupo_maximo
, padreDuracion_maxima_por_Paciente_mins
, padreEstatus
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

        public int Update(Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdEvento = _dataProvider.GetParameter();
                paramUpdEvento.ParameterName = "Evento";
                paramUpdEvento.DbType = DbType.Int32;
                paramUpdEvento.Value = (object)entity.Evento ?? DBNull.Value;

                var paramUpdActividad = _dataProvider.GetParameter();
                paramUpdActividad.ParameterName = "Actividad";
                paramUpdActividad.DbType = DbType.Int32;
                paramUpdActividad.Value = (object)entity.Actividad ?? DBNull.Value;

                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.DateTime;
                paramUpdDia.Value = (object)entity.Dia ?? DBNull.Value;

                var paramUpdHora_inicio = _dataProvider.GetParameter();
                paramUpdHora_inicio.ParameterName = "Hora_inicio";
                paramUpdHora_inicio.DbType = DbType.String;
                paramUpdHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var paramUpdHora_fin = _dataProvider.GetParameter();
                paramUpdHora_fin.ParameterName = "Hora_fin";
                paramUpdHora_fin.DbType = DbType.String;
                paramUpdHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var paramUpdTiene_receso = _dataProvider.GetParameter();
                paramUpdTiene_receso.ParameterName = "Tiene_receso";
                paramUpdTiene_receso.DbType = DbType.Boolean;
                paramUpdTiene_receso.Value = (object)entity.Tiene_receso ?? DBNull.Value;
                var paramUpdHora_inicio_receso = _dataProvider.GetParameter();
                paramUpdHora_inicio_receso.ParameterName = "Hora_inicio_receso";
                paramUpdHora_inicio_receso.DbType = DbType.String;
                paramUpdHora_inicio_receso.Value = (object)entity.Hora_inicio_receso ?? DBNull.Value;
                var paramUpdHora_fin_receso = _dataProvider.GetParameter();
                paramUpdHora_fin_receso.ParameterName = "Hora_fin_receso";
                paramUpdHora_fin_receso.DbType = DbType.String;
                paramUpdHora_fin_receso.Value = (object)entity.Hora_fin_receso ?? DBNull.Value;
                var paramUpdUbicacion = _dataProvider.GetParameter();
                paramUpdUbicacion.ParameterName = "Ubicacion";
                paramUpdUbicacion.DbType = DbType.Int32;
                paramUpdUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;

                var paramUpdTipo_de_Actividad = _dataProvider.GetParameter();
                paramUpdTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                paramUpdTipo_de_Actividad.DbType = DbType.Int32;
                paramUpdTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;

                var paramUpdQuien_imparte = _dataProvider.GetParameter();
                paramUpdQuien_imparte.ParameterName = "Quien_imparte";
                paramUpdQuien_imparte.DbType = DbType.Int32;
                paramUpdQuien_imparte.Value = (object)entity.Quien_imparte ?? DBNull.Value;

                var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var paramUpdCupo_limitado = _dataProvider.GetParameter();
                paramUpdCupo_limitado.ParameterName = "Cupo_limitado";
                paramUpdCupo_limitado.DbType = DbType.Boolean;
                paramUpdCupo_limitado.Value = (object)entity.Cupo_limitado ?? DBNull.Value;
                var paramUpdCupo_maximo = _dataProvider.GetParameter();
                paramUpdCupo_maximo.ParameterName = "Cupo_maximo";
                paramUpdCupo_maximo.DbType = DbType.Int32;
                paramUpdCupo_maximo.Value = (object)entity.Cupo_maximo ?? DBNull.Value;

                var paramUpdDuracion_maxima_por_Paciente_mins = _dataProvider.GetParameter();
                paramUpdDuracion_maxima_por_Paciente_mins.ParameterName = "Duracion_maxima_por_Paciente_mins";
                paramUpdDuracion_maxima_por_Paciente_mins.DbType = DbType.Int32;
                paramUpdDuracion_maxima_por_Paciente_mins.Value = (object)entity.Duracion_maxima_por_Paciente_mins ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdActividades_del_Evento>("sp_UpdActividades_del_Evento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdEvento , paramUpdActividad , paramUpdDescripcion , paramUpdDia , paramUpdHora_inicio , paramUpdHora_fin , paramUpdTiene_receso , paramUpdHora_inicio_receso , paramUpdHora_fin_receso , paramUpdUbicacion , paramUpdTipo_de_Actividad , paramUpdQuien_imparte , paramUpdEspecialidad , paramUpdCupo_limitado , paramUpdCupo_maximo , paramUpdDuracion_maxima_por_Paciente_mins , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento Actividades_del_EventoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdEvento = _dataProvider.GetParameter();
                paramUpdEvento.ParameterName = "Evento";
                paramUpdEvento.DbType = DbType.Int32;
                paramUpdEvento.Value = (object)entity.Evento ?? DBNull.Value;
		var paramUpdActividad = _dataProvider.GetParameter();
                paramUpdActividad.ParameterName = "Actividad";
                paramUpdActividad.DbType = DbType.Int32;
                paramUpdActividad.Value = (object)entity.Actividad ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.DateTime;
                paramUpdDia.Value = (object)entity.Dia ?? DBNull.Value;
                var paramUpdHora_inicio = _dataProvider.GetParameter();
                paramUpdHora_inicio.ParameterName = "Hora_inicio";
                paramUpdHora_inicio.DbType = DbType.String;
                paramUpdHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var paramUpdHora_fin = _dataProvider.GetParameter();
                paramUpdHora_fin.ParameterName = "Hora_fin";
                paramUpdHora_fin.DbType = DbType.String;
                paramUpdHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var paramUpdTiene_receso = _dataProvider.GetParameter();
                paramUpdTiene_receso.ParameterName = "Tiene_receso";
                paramUpdTiene_receso.DbType = DbType.Boolean;
                paramUpdTiene_receso.Value = (object)entity.Tiene_receso ?? DBNull.Value;
                var paramUpdHora_inicio_receso = _dataProvider.GetParameter();
                paramUpdHora_inicio_receso.ParameterName = "Hora_inicio_receso";
                paramUpdHora_inicio_receso.DbType = DbType.String;
                paramUpdHora_inicio_receso.Value = (object)entity.Hora_inicio_receso ?? DBNull.Value;
                var paramUpdHora_fin_receso = _dataProvider.GetParameter();
                paramUpdHora_fin_receso.ParameterName = "Hora_fin_receso";
                paramUpdHora_fin_receso.DbType = DbType.String;
                paramUpdHora_fin_receso.Value = (object)entity.Hora_fin_receso ?? DBNull.Value;
		var paramUpdUbicacion = _dataProvider.GetParameter();
                paramUpdUbicacion.ParameterName = "Ubicacion";
                paramUpdUbicacion.DbType = DbType.Int32;
                paramUpdUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;
		var paramUpdTipo_de_Actividad = _dataProvider.GetParameter();
                paramUpdTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                paramUpdTipo_de_Actividad.DbType = DbType.Int32;
                paramUpdTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;
		var paramUpdQuien_imparte = _dataProvider.GetParameter();
                paramUpdQuien_imparte.ParameterName = "Quien_imparte";
                paramUpdQuien_imparte.DbType = DbType.Int32;
                paramUpdQuien_imparte.Value = (object)entity.Quien_imparte ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
                var paramUpdCupo_limitado = _dataProvider.GetParameter();
                paramUpdCupo_limitado.ParameterName = "Cupo_limitado";
                paramUpdCupo_limitado.DbType = DbType.Boolean;
                paramUpdCupo_limitado.Value = (object)entity.Cupo_limitado ?? DBNull.Value;
                var paramUpdCupo_maximo = _dataProvider.GetParameter();
                paramUpdCupo_maximo.ParameterName = "Cupo_maximo";
                paramUpdCupo_maximo.DbType = DbType.Int32;
                paramUpdCupo_maximo.Value = (object)entity.Cupo_maximo ?? DBNull.Value;
                var paramUpdDuracion_maxima_por_Paciente_mins = _dataProvider.GetParameter();
                paramUpdDuracion_maxima_por_Paciente_mins.ParameterName = "Duracion_maxima_por_Paciente_mins";
                paramUpdDuracion_maxima_por_Paciente_mins.DbType = DbType.Int32;
                paramUpdDuracion_maxima_por_Paciente_mins.Value = (object)entity.Duracion_maxima_por_Paciente_mins ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdActividades_del_Evento>("sp_UpdActividades_del_Evento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdEvento , paramUpdActividad , paramUpdDescripcion , paramUpdDia , paramUpdHora_inicio , paramUpdHora_fin , paramUpdTiene_receso , paramUpdHora_inicio_receso , paramUpdHora_fin_receso , paramUpdUbicacion , paramUpdTipo_de_Actividad , paramUpdQuien_imparte , paramUpdEspecialidad , paramUpdCupo_limitado , paramUpdCupo_maximo , paramUpdDuracion_maxima_por_Paciente_mins , paramUpdEstatus ).FirstOrDefault();

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

		public int Update_Agenda(Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento Actividades_del_EventoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)Actividades_del_EventoDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)Actividades_del_EventoDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)Actividades_del_EventoDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)Actividades_del_EventoDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdEvento = _dataProvider.GetParameter();
                paramUpdEvento.ParameterName = "Evento";
                paramUpdEvento.DbType = DbType.Int32;
                paramUpdEvento.Value = (object)Actividades_del_EventoDB.Evento ?? DBNull.Value;
		var paramUpdActividad = _dataProvider.GetParameter();
                paramUpdActividad.ParameterName = "Actividad";
                paramUpdActividad.DbType = DbType.Int32;
                paramUpdActividad.Value = (object)Actividades_del_EventoDB.Actividad ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)Actividades_del_EventoDB.Descripcion ?? DBNull.Value;
                var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.DateTime;
                paramUpdDia.Value = (object)Actividades_del_EventoDB.Dia ?? DBNull.Value;
                var paramUpdHora_inicio = _dataProvider.GetParameter();
                paramUpdHora_inicio.ParameterName = "Hora_inicio";
                paramUpdHora_inicio.DbType = DbType.String;
                paramUpdHora_inicio.Value = (object)Actividades_del_EventoDB.Hora_inicio ?? DBNull.Value;
                var paramUpdHora_fin = _dataProvider.GetParameter();
                paramUpdHora_fin.ParameterName = "Hora_fin";
                paramUpdHora_fin.DbType = DbType.String;
                paramUpdHora_fin.Value = (object)Actividades_del_EventoDB.Hora_fin ?? DBNull.Value;
                var paramUpdTiene_receso = _dataProvider.GetParameter();
                paramUpdTiene_receso.ParameterName = "Tiene_receso";
                paramUpdTiene_receso.DbType = DbType.Boolean;
                paramUpdTiene_receso.Value = (object)Actividades_del_EventoDB.Tiene_receso ?? DBNull.Value;
                var paramUpdHora_inicio_receso = _dataProvider.GetParameter();
                paramUpdHora_inicio_receso.ParameterName = "Hora_inicio_receso";
                paramUpdHora_inicio_receso.DbType = DbType.String;
                paramUpdHora_inicio_receso.Value = (object)Actividades_del_EventoDB.Hora_inicio_receso ?? DBNull.Value;
                var paramUpdHora_fin_receso = _dataProvider.GetParameter();
                paramUpdHora_fin_receso.ParameterName = "Hora_fin_receso";
                paramUpdHora_fin_receso.DbType = DbType.String;
                paramUpdHora_fin_receso.Value = (object)Actividades_del_EventoDB.Hora_fin_receso ?? DBNull.Value;
		var paramUpdUbicacion = _dataProvider.GetParameter();
                paramUpdUbicacion.ParameterName = "Ubicacion";
                paramUpdUbicacion.DbType = DbType.Int32;
                paramUpdUbicacion.Value = (object)Actividades_del_EventoDB.Ubicacion ?? DBNull.Value;
		var paramUpdTipo_de_Actividad = _dataProvider.GetParameter();
                paramUpdTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                paramUpdTipo_de_Actividad.DbType = DbType.Int32;
                paramUpdTipo_de_Actividad.Value = (object)Actividades_del_EventoDB.Tipo_de_Actividad ?? DBNull.Value;
		var paramUpdQuien_imparte = _dataProvider.GetParameter();
                paramUpdQuien_imparte.ParameterName = "Quien_imparte";
                paramUpdQuien_imparte.DbType = DbType.Int32;
                paramUpdQuien_imparte.Value = (object)Actividades_del_EventoDB.Quien_imparte ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)Actividades_del_EventoDB.Especialidad ?? DBNull.Value;
                var paramUpdCupo_limitado = _dataProvider.GetParameter();
                paramUpdCupo_limitado.ParameterName = "Cupo_limitado";
                paramUpdCupo_limitado.DbType = DbType.Boolean;
                paramUpdCupo_limitado.Value = (object)Actividades_del_EventoDB.Cupo_limitado ?? DBNull.Value;
                var paramUpdCupo_maximo = _dataProvider.GetParameter();
                paramUpdCupo_maximo.ParameterName = "Cupo_maximo";
                paramUpdCupo_maximo.DbType = DbType.Int32;
                paramUpdCupo_maximo.Value = (object)Actividades_del_EventoDB.Cupo_maximo ?? DBNull.Value;
                var paramUpdDuracion_maxima_por_Paciente_mins = _dataProvider.GetParameter();
                paramUpdDuracion_maxima_por_Paciente_mins.ParameterName = "Duracion_maxima_por_Paciente_mins";
                paramUpdDuracion_maxima_por_Paciente_mins.DbType = DbType.Int32;
                paramUpdDuracion_maxima_por_Paciente_mins.Value = (object)Actividades_del_EventoDB.Duracion_maxima_por_Paciente_mins ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Actividades_del_EventoDB.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdActividades_del_Evento>("sp_UpdActividades_del_Evento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdEvento , paramUpdActividad , paramUpdDescripcion , paramUpdDia , paramUpdHora_inicio , paramUpdHora_fin , paramUpdTiene_receso , paramUpdHora_inicio_receso , paramUpdHora_fin_receso , paramUpdUbicacion , paramUpdTipo_de_Actividad , paramUpdQuien_imparte , paramUpdEspecialidad , paramUpdCupo_limitado , paramUpdCupo_maximo , paramUpdDuracion_maxima_por_Paciente_mins , paramUpdEstatus ).FirstOrDefault();

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


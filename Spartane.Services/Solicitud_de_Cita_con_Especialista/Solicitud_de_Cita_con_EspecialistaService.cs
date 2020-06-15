using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Solicitud_de_Cita_con_Especialista
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Solicitud_de_Cita_con_EspecialistaService : ISolicitud_de_Cita_con_EspecialistaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> _Solicitud_de_Cita_con_EspecialistaRepository;
        #endregion

        #region Ctor
        public Solicitud_de_Cita_con_EspecialistaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> Solicitud_de_Cita_con_EspecialistaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Solicitud_de_Cita_con_EspecialistaRepository = Solicitud_de_Cita_con_EspecialistaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>("sp_SelAllSolicitud_de_Cita_con_Especialista");
        }

        public IList<Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSolicitud_de_Cita_con_Especialista_Complete>("sp_SelAllComplete_Solicitud_de_Cita_con_Especialista");
            return data.Select(m => new Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista
            {
                Folio = m.Folio
                ,Fecha_de_solicitud = m.Fecha_de_solicitud
                ,Hora_de_solicitud = m.Hora_de_solicitud
                ,Usuario_que_solicita_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_solicita.GetValueOrDefault(), Name = m.Usuario_que_solicita_Name }
                ,Nombre_Completo = m.Nombre_Completo
                ,Correo_del_Paciente = m.Correo_del_Paciente
                ,Celular_del_Paciente = m.Celular_del_Paciente
                ,Especialista_Medicos = new Core.Classes.Medicos.Medicos() { Folio = m.Especialista.GetValueOrDefault(), Nombre_Completo = m.Especialista_Nombre_Completo }
                ,Correo_del_Especialista = m.Correo_del_Especialista
                ,Correo_enviado = m.Correo_enviado.GetValueOrDefault()
                ,Fecha_de_Retroalimentacion = m.Fecha_de_Retroalimentacion
                ,Hora_de_Retroalimentacion = m.Hora_de_Retroalimentacion
                ,Asististe_a_tu_cita_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Asististe_a_tu_cita.GetValueOrDefault(), Descripcion = m.Asististe_a_tu_cita_Descripcion }
                ,Calificacion_Especialista_Calificacion = new Core.Classes.Calificacion.Calificacion() { Clave = m.Calificacion_Especialista.GetValueOrDefault(), Descripcion = m.Calificacion_Especialista_Descripcion }
                ,Motivo_no_concreto_cita_Motivos = new Core.Classes.Motivos.Motivos() { Clave = m.Motivo_no_concreto_cita.GetValueOrDefault(), Descripcion = m.Motivo_no_concreto_cita_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Solicitud_de_Cita_con_Especialista>("sp_ListSelCount_Solicitud_de_Cita_con_Especialista", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSolicitud_de_Cita_con_Especialista>("sp_ListSelAll_Solicitud_de_Cita_con_Especialista", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista
                {
                    Folio = m.Solicitud_de_Cita_con_Especialista_Folio,
                    Fecha_de_solicitud = m.Solicitud_de_Cita_con_Especialista_Fecha_de_solicitud,
                    Hora_de_solicitud = m.Solicitud_de_Cita_con_Especialista_Hora_de_solicitud,
                    Usuario_que_solicita = m.Solicitud_de_Cita_con_Especialista_Usuario_que_solicita,
                    Nombre_Completo = m.Solicitud_de_Cita_con_Especialista_Nombre_Completo,
                    Correo_del_Paciente = m.Solicitud_de_Cita_con_Especialista_Correo_del_Paciente,
                    Celular_del_Paciente = m.Solicitud_de_Cita_con_Especialista_Celular_del_Paciente,
                    Especialista = m.Solicitud_de_Cita_con_Especialista_Especialista,
                    Correo_del_Especialista = m.Solicitud_de_Cita_con_Especialista_Correo_del_Especialista,
                    Correo_enviado = m.Solicitud_de_Cita_con_Especialista_Correo_enviado ?? false,
                    Fecha_de_Retroalimentacion = m.Solicitud_de_Cita_con_Especialista_Fecha_de_Retroalimentacion,
                    Hora_de_Retroalimentacion = m.Solicitud_de_Cita_con_Especialista_Hora_de_Retroalimentacion,
                    Asististe_a_tu_cita = m.Solicitud_de_Cita_con_Especialista_Asististe_a_tu_cita,
                    Calificacion_Especialista = m.Solicitud_de_Cita_con_Especialista_Calificacion_Especialista,
                    Motivo_no_concreto_cita = m.Solicitud_de_Cita_con_Especialista_Motivo_no_concreto_cita,

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

        public IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_EspecialistaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSolicitud_de_Cita_con_Especialista>("sp_ListSelAll_Solicitud_de_Cita_con_Especialista", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Solicitud_de_Cita_con_EspecialistaPagingModel result = null;

            if (data != null)
            {
                result = new Solicitud_de_Cita_con_EspecialistaPagingModel
                {
                    Solicitud_de_Cita_con_Especialistas =
                        data.Select(m => new Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista
                {
                    Folio = m.Solicitud_de_Cita_con_Especialista_Folio
                    ,Fecha_de_solicitud = m.Solicitud_de_Cita_con_Especialista_Fecha_de_solicitud
                    ,Hora_de_solicitud = m.Solicitud_de_Cita_con_Especialista_Hora_de_solicitud
                    ,Usuario_que_solicita = m.Solicitud_de_Cita_con_Especialista_Usuario_que_solicita
                    ,Usuario_que_solicita_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Solicitud_de_Cita_con_Especialista_Usuario_que_solicita.GetValueOrDefault(), Name = m.Solicitud_de_Cita_con_Especialista_Usuario_que_solicita_Name }
                    ,Nombre_Completo = m.Solicitud_de_Cita_con_Especialista_Nombre_Completo
                    ,Correo_del_Paciente = m.Solicitud_de_Cita_con_Especialista_Correo_del_Paciente
                    ,Celular_del_Paciente = m.Solicitud_de_Cita_con_Especialista_Celular_del_Paciente
                    ,Especialista = m.Solicitud_de_Cita_con_Especialista_Especialista
                    ,Especialista_Medicos = new Core.Classes.Medicos.Medicos() { Folio = m.Solicitud_de_Cita_con_Especialista_Especialista.GetValueOrDefault(), Nombre_Completo = m.Solicitud_de_Cita_con_Especialista_Especialista_Nombre_Completo }
                    ,Correo_del_Especialista = m.Solicitud_de_Cita_con_Especialista_Correo_del_Especialista
                    ,Correo_enviado = m.Solicitud_de_Cita_con_Especialista_Correo_enviado ?? false
                    ,Fecha_de_Retroalimentacion = m.Solicitud_de_Cita_con_Especialista_Fecha_de_Retroalimentacion
                    ,Hora_de_Retroalimentacion = m.Solicitud_de_Cita_con_Especialista_Hora_de_Retroalimentacion
                    ,Asististe_a_tu_cita = m.Solicitud_de_Cita_con_Especialista_Asististe_a_tu_cita
                    ,Asististe_a_tu_cita_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Solicitud_de_Cita_con_Especialista_Asististe_a_tu_cita.GetValueOrDefault(), Descripcion = m.Solicitud_de_Cita_con_Especialista_Asististe_a_tu_cita_Descripcion }
                    ,Calificacion_Especialista = m.Solicitud_de_Cita_con_Especialista_Calificacion_Especialista
                    ,Calificacion_Especialista_Calificacion = new Core.Classes.Calificacion.Calificacion() { Clave = m.Solicitud_de_Cita_con_Especialista_Calificacion_Especialista.GetValueOrDefault(), Descripcion = m.Solicitud_de_Cita_con_Especialista_Calificacion_Especialista_Descripcion }
                    ,Motivo_no_concreto_cita = m.Solicitud_de_Cita_con_Especialista_Motivo_no_concreto_cita
                    ,Motivo_no_concreto_cita_Motivos = new Core.Classes.Motivos.Motivos() { Clave = m.Solicitud_de_Cita_con_Especialista_Motivo_no_concreto_cita.GetValueOrDefault(), Descripcion = m.Solicitud_de_Cita_con_Especialista_Motivo_no_concreto_cita_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>("sp_GetSolicitud_de_Cita_con_Especialista", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSolicitud_de_Cita_con_Especialista>("sp_DelSolicitud_de_Cita_con_Especialista", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_solicitud = _dataProvider.GetParameter();
                padreFecha_de_solicitud.ParameterName = "Fecha_de_solicitud";
                padreFecha_de_solicitud.DbType = DbType.DateTime;
                padreFecha_de_solicitud.Value = (object)entity.Fecha_de_solicitud ?? DBNull.Value;

                var padreHora_de_solicitud = _dataProvider.GetParameter();
                padreHora_de_solicitud.ParameterName = "Hora_de_solicitud";
                padreHora_de_solicitud.DbType = DbType.String;
                padreHora_de_solicitud.Value = (object)entity.Hora_de_solicitud ?? DBNull.Value;
                var padreUsuario_que_solicita = _dataProvider.GetParameter();
                padreUsuario_que_solicita.ParameterName = "Usuario_que_solicita";
                padreUsuario_que_solicita.DbType = DbType.Int32;
                padreUsuario_que_solicita.Value = (object)entity.Usuario_que_solicita ?? DBNull.Value;

                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreCorreo_del_Paciente = _dataProvider.GetParameter();
                padreCorreo_del_Paciente.ParameterName = "Correo_del_Paciente";
                padreCorreo_del_Paciente.DbType = DbType.String;
                padreCorreo_del_Paciente.Value = (object)entity.Correo_del_Paciente ?? DBNull.Value;
                var padreCelular_del_Paciente = _dataProvider.GetParameter();
                padreCelular_del_Paciente.ParameterName = "Celular_del_Paciente";
                padreCelular_del_Paciente.DbType = DbType.String;
                padreCelular_del_Paciente.Value = (object)entity.Celular_del_Paciente ?? DBNull.Value;
                var padreEspecialista = _dataProvider.GetParameter();
                padreEspecialista.ParameterName = "Especialista";
                padreEspecialista.DbType = DbType.Int32;
                padreEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;

                var padreCorreo_del_Especialista = _dataProvider.GetParameter();
                padreCorreo_del_Especialista.ParameterName = "Correo_del_Especialista";
                padreCorreo_del_Especialista.DbType = DbType.String;
                padreCorreo_del_Especialista.Value = (object)entity.Correo_del_Especialista ?? DBNull.Value;
                var padreCorreo_enviado = _dataProvider.GetParameter();
                padreCorreo_enviado.ParameterName = "Correo_enviado";
                padreCorreo_enviado.DbType = DbType.Boolean;
                padreCorreo_enviado.Value = (object)entity.Correo_enviado ?? DBNull.Value;
                var padreFecha_de_Retroalimentacion = _dataProvider.GetParameter();
                padreFecha_de_Retroalimentacion.ParameterName = "Fecha_de_Retroalimentacion";
                padreFecha_de_Retroalimentacion.DbType = DbType.DateTime;
                padreFecha_de_Retroalimentacion.Value = (object)entity.Fecha_de_Retroalimentacion ?? DBNull.Value;

                var padreHora_de_Retroalimentacion = _dataProvider.GetParameter();
                padreHora_de_Retroalimentacion.ParameterName = "Hora_de_Retroalimentacion";
                padreHora_de_Retroalimentacion.DbType = DbType.String;
                padreHora_de_Retroalimentacion.Value = (object)entity.Hora_de_Retroalimentacion ?? DBNull.Value;
                var padreAsististe_a_tu_cita = _dataProvider.GetParameter();
                padreAsististe_a_tu_cita.ParameterName = "Asististe_a_tu_cita";
                padreAsististe_a_tu_cita.DbType = DbType.Int32;
                padreAsististe_a_tu_cita.Value = (object)entity.Asististe_a_tu_cita ?? DBNull.Value;

                var padreCalificacion_Especialista = _dataProvider.GetParameter();
                padreCalificacion_Especialista.ParameterName = "Calificacion_Especialista";
                padreCalificacion_Especialista.DbType = DbType.Int32;
                padreCalificacion_Especialista.Value = (object)entity.Calificacion_Especialista ?? DBNull.Value;

                var padreMotivo_no_concreto_cita = _dataProvider.GetParameter();
                padreMotivo_no_concreto_cita.ParameterName = "Motivo_no_concreto_cita";
                padreMotivo_no_concreto_cita.DbType = DbType.Int32;
                padreMotivo_no_concreto_cita.Value = (object)entity.Motivo_no_concreto_cita ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSolicitud_de_Cita_con_Especialista>("sp_InsSolicitud_de_Cita_con_Especialista" , padreFecha_de_solicitud
, padreHora_de_solicitud
, padreUsuario_que_solicita
, padreNombre_Completo
, padreCorreo_del_Paciente
, padreCelular_del_Paciente
, padreEspecialista
, padreCorreo_del_Especialista
, padreCorreo_enviado
, padreFecha_de_Retroalimentacion
, padreHora_de_Retroalimentacion
, padreAsististe_a_tu_cita
, padreCalificacion_Especialista
, padreMotivo_no_concreto_cita
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

        public int Update(Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_solicitud = _dataProvider.GetParameter();
                paramUpdFecha_de_solicitud.ParameterName = "Fecha_de_solicitud";
                paramUpdFecha_de_solicitud.DbType = DbType.DateTime;
                paramUpdFecha_de_solicitud.Value = (object)entity.Fecha_de_solicitud ?? DBNull.Value;

                var paramUpdHora_de_solicitud = _dataProvider.GetParameter();
                paramUpdHora_de_solicitud.ParameterName = "Hora_de_solicitud";
                paramUpdHora_de_solicitud.DbType = DbType.String;
                paramUpdHora_de_solicitud.Value = (object)entity.Hora_de_solicitud ?? DBNull.Value;
                var paramUpdUsuario_que_solicita = _dataProvider.GetParameter();
                paramUpdUsuario_que_solicita.ParameterName = "Usuario_que_solicita";
                paramUpdUsuario_que_solicita.DbType = DbType.Int32;
                paramUpdUsuario_que_solicita.Value = (object)entity.Usuario_que_solicita ?? DBNull.Value;

                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdCorreo_del_Paciente = _dataProvider.GetParameter();
                paramUpdCorreo_del_Paciente.ParameterName = "Correo_del_Paciente";
                paramUpdCorreo_del_Paciente.DbType = DbType.String;
                paramUpdCorreo_del_Paciente.Value = (object)entity.Correo_del_Paciente ?? DBNull.Value;
                var paramUpdCelular_del_Paciente = _dataProvider.GetParameter();
                paramUpdCelular_del_Paciente.ParameterName = "Celular_del_Paciente";
                paramUpdCelular_del_Paciente.DbType = DbType.String;
                paramUpdCelular_del_Paciente.Value = (object)entity.Celular_del_Paciente ?? DBNull.Value;
                var paramUpdEspecialista = _dataProvider.GetParameter();
                paramUpdEspecialista.ParameterName = "Especialista";
                paramUpdEspecialista.DbType = DbType.Int32;
                paramUpdEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;

                var paramUpdCorreo_del_Especialista = _dataProvider.GetParameter();
                paramUpdCorreo_del_Especialista.ParameterName = "Correo_del_Especialista";
                paramUpdCorreo_del_Especialista.DbType = DbType.String;
                paramUpdCorreo_del_Especialista.Value = (object)entity.Correo_del_Especialista ?? DBNull.Value;
                var paramUpdCorreo_enviado = _dataProvider.GetParameter();
                paramUpdCorreo_enviado.ParameterName = "Correo_enviado";
                paramUpdCorreo_enviado.DbType = DbType.Boolean;
                paramUpdCorreo_enviado.Value = (object)entity.Correo_enviado ?? DBNull.Value;
                var paramUpdFecha_de_Retroalimentacion = _dataProvider.GetParameter();
                paramUpdFecha_de_Retroalimentacion.ParameterName = "Fecha_de_Retroalimentacion";
                paramUpdFecha_de_Retroalimentacion.DbType = DbType.DateTime;
                paramUpdFecha_de_Retroalimentacion.Value = (object)entity.Fecha_de_Retroalimentacion ?? DBNull.Value;

                var paramUpdHora_de_Retroalimentacion = _dataProvider.GetParameter();
                paramUpdHora_de_Retroalimentacion.ParameterName = "Hora_de_Retroalimentacion";
                paramUpdHora_de_Retroalimentacion.DbType = DbType.String;
                paramUpdHora_de_Retroalimentacion.Value = (object)entity.Hora_de_Retroalimentacion ?? DBNull.Value;
                var paramUpdAsististe_a_tu_cita = _dataProvider.GetParameter();
                paramUpdAsististe_a_tu_cita.ParameterName = "Asististe_a_tu_cita";
                paramUpdAsististe_a_tu_cita.DbType = DbType.Int32;
                paramUpdAsististe_a_tu_cita.Value = (object)entity.Asististe_a_tu_cita ?? DBNull.Value;

                var paramUpdCalificacion_Especialista = _dataProvider.GetParameter();
                paramUpdCalificacion_Especialista.ParameterName = "Calificacion_Especialista";
                paramUpdCalificacion_Especialista.DbType = DbType.Int32;
                paramUpdCalificacion_Especialista.Value = (object)entity.Calificacion_Especialista ?? DBNull.Value;

                var paramUpdMotivo_no_concreto_cita = _dataProvider.GetParameter();
                paramUpdMotivo_no_concreto_cita.ParameterName = "Motivo_no_concreto_cita";
                paramUpdMotivo_no_concreto_cita.DbType = DbType.Int32;
                paramUpdMotivo_no_concreto_cita.Value = (object)entity.Motivo_no_concreto_cita ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitud_de_Cita_con_Especialista>("sp_UpdSolicitud_de_Cita_con_Especialista" , paramUpdFolio , paramUpdFecha_de_solicitud , paramUpdHora_de_solicitud , paramUpdUsuario_que_solicita , paramUpdNombre_Completo , paramUpdCorreo_del_Paciente , paramUpdCelular_del_Paciente , paramUpdEspecialista , paramUpdCorreo_del_Especialista , paramUpdCorreo_enviado , paramUpdFecha_de_Retroalimentacion , paramUpdHora_de_Retroalimentacion , paramUpdAsististe_a_tu_cita , paramUpdCalificacion_Especialista , paramUpdMotivo_no_concreto_cita ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista Solicitud_de_Cita_con_EspecialistaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_solicitud = _dataProvider.GetParameter();
                paramUpdFecha_de_solicitud.ParameterName = "Fecha_de_solicitud";
                paramUpdFecha_de_solicitud.DbType = DbType.DateTime;
                paramUpdFecha_de_solicitud.Value = (object)entity.Fecha_de_solicitud ?? DBNull.Value;
                var paramUpdHora_de_solicitud = _dataProvider.GetParameter();
                paramUpdHora_de_solicitud.ParameterName = "Hora_de_solicitud";
                paramUpdHora_de_solicitud.DbType = DbType.String;
                paramUpdHora_de_solicitud.Value = (object)entity.Hora_de_solicitud ?? DBNull.Value;
		var paramUpdUsuario_que_solicita = _dataProvider.GetParameter();
                paramUpdUsuario_que_solicita.ParameterName = "Usuario_que_solicita";
                paramUpdUsuario_que_solicita.DbType = DbType.Int32;
                paramUpdUsuario_que_solicita.Value = (object)entity.Usuario_que_solicita ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdCorreo_del_Paciente = _dataProvider.GetParameter();
                paramUpdCorreo_del_Paciente.ParameterName = "Correo_del_Paciente";
                paramUpdCorreo_del_Paciente.DbType = DbType.String;
                paramUpdCorreo_del_Paciente.Value = (object)entity.Correo_del_Paciente ?? DBNull.Value;
                var paramUpdCelular_del_Paciente = _dataProvider.GetParameter();
                paramUpdCelular_del_Paciente.ParameterName = "Celular_del_Paciente";
                paramUpdCelular_del_Paciente.DbType = DbType.String;
                paramUpdCelular_del_Paciente.Value = (object)entity.Celular_del_Paciente ?? DBNull.Value;
		var paramUpdEspecialista = _dataProvider.GetParameter();
                paramUpdEspecialista.ParameterName = "Especialista";
                paramUpdEspecialista.DbType = DbType.Int32;
                paramUpdEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;
                var paramUpdCorreo_del_Especialista = _dataProvider.GetParameter();
                paramUpdCorreo_del_Especialista.ParameterName = "Correo_del_Especialista";
                paramUpdCorreo_del_Especialista.DbType = DbType.String;
                paramUpdCorreo_del_Especialista.Value = (object)entity.Correo_del_Especialista ?? DBNull.Value;
                var paramUpdCorreo_enviado = _dataProvider.GetParameter();
                paramUpdCorreo_enviado.ParameterName = "Correo_enviado";
                paramUpdCorreo_enviado.DbType = DbType.Boolean;
                paramUpdCorreo_enviado.Value = (object)entity.Correo_enviado ?? DBNull.Value;
                var paramUpdFecha_de_Retroalimentacion = _dataProvider.GetParameter();
                paramUpdFecha_de_Retroalimentacion.ParameterName = "Fecha_de_Retroalimentacion";
                paramUpdFecha_de_Retroalimentacion.DbType = DbType.DateTime;
                paramUpdFecha_de_Retroalimentacion.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Fecha_de_Retroalimentacion ?? DBNull.Value;
                var paramUpdHora_de_Retroalimentacion = _dataProvider.GetParameter();
                paramUpdHora_de_Retroalimentacion.ParameterName = "Hora_de_Retroalimentacion";
                paramUpdHora_de_Retroalimentacion.DbType = DbType.String;
                paramUpdHora_de_Retroalimentacion.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Hora_de_Retroalimentacion ?? DBNull.Value;
		var paramUpdAsististe_a_tu_cita = _dataProvider.GetParameter();
                paramUpdAsististe_a_tu_cita.ParameterName = "Asististe_a_tu_cita";
                paramUpdAsististe_a_tu_cita.DbType = DbType.Int32;
                paramUpdAsististe_a_tu_cita.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Asististe_a_tu_cita ?? DBNull.Value;
		var paramUpdCalificacion_Especialista = _dataProvider.GetParameter();
                paramUpdCalificacion_Especialista.ParameterName = "Calificacion_Especialista";
                paramUpdCalificacion_Especialista.DbType = DbType.Int32;
                paramUpdCalificacion_Especialista.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Calificacion_Especialista ?? DBNull.Value;
		var paramUpdMotivo_no_concreto_cita = _dataProvider.GetParameter();
                paramUpdMotivo_no_concreto_cita.ParameterName = "Motivo_no_concreto_cita";
                paramUpdMotivo_no_concreto_cita.DbType = DbType.Int32;
                paramUpdMotivo_no_concreto_cita.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Motivo_no_concreto_cita ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitud_de_Cita_con_Especialista>("sp_UpdSolicitud_de_Cita_con_Especialista" , paramUpdFolio , paramUpdFecha_de_solicitud , paramUpdHora_de_solicitud , paramUpdUsuario_que_solicita , paramUpdNombre_Completo , paramUpdCorreo_del_Paciente , paramUpdCelular_del_Paciente , paramUpdEspecialista , paramUpdCorreo_del_Especialista , paramUpdCorreo_enviado , paramUpdFecha_de_Retroalimentacion , paramUpdHora_de_Retroalimentacion , paramUpdAsististe_a_tu_cita , paramUpdCalificacion_Especialista , paramUpdMotivo_no_concreto_cita ).FirstOrDefault();

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

		public int Update_Solicitud(Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista Solicitud_de_Cita_con_EspecialistaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_solicitud = _dataProvider.GetParameter();
                paramUpdFecha_de_solicitud.ParameterName = "Fecha_de_solicitud";
                paramUpdFecha_de_solicitud.DbType = DbType.DateTime;
                paramUpdFecha_de_solicitud.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Fecha_de_solicitud ?? DBNull.Value;
                var paramUpdHora_de_solicitud = _dataProvider.GetParameter();
                paramUpdHora_de_solicitud.ParameterName = "Hora_de_solicitud";
                paramUpdHora_de_solicitud.DbType = DbType.String;
                paramUpdHora_de_solicitud.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Hora_de_solicitud ?? DBNull.Value;
		var paramUpdUsuario_que_solicita = _dataProvider.GetParameter();
                paramUpdUsuario_que_solicita.ParameterName = "Usuario_que_solicita";
                paramUpdUsuario_que_solicita.DbType = DbType.Int32;
                paramUpdUsuario_que_solicita.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Usuario_que_solicita ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCorreo_del_Paciente = _dataProvider.GetParameter();
                paramUpdCorreo_del_Paciente.ParameterName = "Correo_del_Paciente";
                paramUpdCorreo_del_Paciente.DbType = DbType.String;
                paramUpdCorreo_del_Paciente.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Correo_del_Paciente ?? DBNull.Value;
                var paramUpdCelular_del_Paciente = _dataProvider.GetParameter();
                paramUpdCelular_del_Paciente.ParameterName = "Celular_del_Paciente";
                paramUpdCelular_del_Paciente.DbType = DbType.String;
                paramUpdCelular_del_Paciente.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Celular_del_Paciente ?? DBNull.Value;
		var paramUpdEspecialista = _dataProvider.GetParameter();
                paramUpdEspecialista.ParameterName = "Especialista";
                paramUpdEspecialista.DbType = DbType.Int32;
                paramUpdEspecialista.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Especialista ?? DBNull.Value;
                var paramUpdCorreo_del_Especialista = _dataProvider.GetParameter();
                paramUpdCorreo_del_Especialista.ParameterName = "Correo_del_Especialista";
                paramUpdCorreo_del_Especialista.DbType = DbType.String;
                paramUpdCorreo_del_Especialista.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Correo_del_Especialista ?? DBNull.Value;
                var paramUpdCorreo_enviado = _dataProvider.GetParameter();
                paramUpdCorreo_enviado.ParameterName = "Correo_enviado";
                paramUpdCorreo_enviado.DbType = DbType.Boolean;
                paramUpdCorreo_enviado.Value = (object)Solicitud_de_Cita_con_EspecialistaDB.Correo_enviado ?? DBNull.Value;
                var paramUpdFecha_de_Retroalimentacion = _dataProvider.GetParameter();
                paramUpdFecha_de_Retroalimentacion.ParameterName = "Fecha_de_Retroalimentacion";
                paramUpdFecha_de_Retroalimentacion.DbType = DbType.DateTime;
                paramUpdFecha_de_Retroalimentacion.Value = (object)entity.Fecha_de_Retroalimentacion ?? DBNull.Value;
                var paramUpdHora_de_Retroalimentacion = _dataProvider.GetParameter();
                paramUpdHora_de_Retroalimentacion.ParameterName = "Hora_de_Retroalimentacion";
                paramUpdHora_de_Retroalimentacion.DbType = DbType.String;
                paramUpdHora_de_Retroalimentacion.Value = (object)entity.Hora_de_Retroalimentacion ?? DBNull.Value;
		var paramUpdAsististe_a_tu_cita = _dataProvider.GetParameter();
                paramUpdAsististe_a_tu_cita.ParameterName = "Asististe_a_tu_cita";
                paramUpdAsististe_a_tu_cita.DbType = DbType.Int32;
                paramUpdAsististe_a_tu_cita.Value = (object)entity.Asististe_a_tu_cita ?? DBNull.Value;
		var paramUpdCalificacion_Especialista = _dataProvider.GetParameter();
                paramUpdCalificacion_Especialista.ParameterName = "Calificacion_Especialista";
                paramUpdCalificacion_Especialista.DbType = DbType.Int32;
                paramUpdCalificacion_Especialista.Value = (object)entity.Calificacion_Especialista ?? DBNull.Value;
		var paramUpdMotivo_no_concreto_cita = _dataProvider.GetParameter();
                paramUpdMotivo_no_concreto_cita.ParameterName = "Motivo_no_concreto_cita";
                paramUpdMotivo_no_concreto_cita.DbType = DbType.Int32;
                paramUpdMotivo_no_concreto_cita.Value = (object)entity.Motivo_no_concreto_cita ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitud_de_Cita_con_Especialista>("sp_UpdSolicitud_de_Cita_con_Especialista" , paramUpdFolio , paramUpdFecha_de_solicitud , paramUpdHora_de_solicitud , paramUpdUsuario_que_solicita , paramUpdNombre_Completo , paramUpdCorreo_del_Paciente , paramUpdCelular_del_Paciente , paramUpdEspecialista , paramUpdCorreo_del_Especialista , paramUpdCorreo_enviado , paramUpdFecha_de_Retroalimentacion , paramUpdHora_de_Retroalimentacion , paramUpdAsististe_a_tu_cita , paramUpdCalificacion_Especialista , paramUpdMotivo_no_concreto_cita ).FirstOrDefault();

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


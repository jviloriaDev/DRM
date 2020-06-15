using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Registro_de_Asistencia_Telefonica;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro_de_Asistencia_Telefonica
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Registro_de_Asistencia_TelefonicaService : IRegistro_de_Asistencia_TelefonicaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> _Registro_de_Asistencia_TelefonicaRepository;
        #endregion

        #region Ctor
        public Registro_de_Asistencia_TelefonicaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> Registro_de_Asistencia_TelefonicaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_de_Asistencia_TelefonicaRepository = Registro_de_Asistencia_TelefonicaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Registro_de_Asistencia_TelefonicaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica>("sp_SelAllRegistro_de_Asistencia_Telefonica");
        }

        public IList<Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRegistro_de_Asistencia_Telefonica_Complete>("sp_SelAllComplete_Registro_de_Asistencia_Telefonica");
            return data.Select(m => new Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica
            {
                Folio = m.Folio
                ,Fecha_de_llamada = m.Fecha_de_llamada
                ,Hora_de_llamada = m.Hora_de_llamada
                ,Usuario_que_llama_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_llama.GetValueOrDefault(), Name = m.Usuario_que_llama_Name }
                ,Dispositivo = m.Dispositivo
                ,Nombre_Paciente_Pacientes = new Core.Classes.Pacientes.Pacientes() { Folio = m.Nombre_Paciente.GetValueOrDefault(), Nombre_Completo = m.Nombre_Paciente_Nombre_Completo }
                ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Suscripcion_Nombre_del_Plan }
                ,Numero_telefonico_del_Paciente = m.Numero_telefonico_del_Paciente
                ,Correo_del_Paciente = m.Correo_del_Paciente
                ,Telefono_de_Asistencia_marcado = m.Telefono_de_Asistencia_marcado
                ,Hora_inicio_de_la_Llamada = m.Hora_inicio_de_la_Llamada
                ,Hora_fin_de_la_Llamada = m.Hora_fin_de_la_Llamada
                ,Duracion_minutos = m.Duracion_minutos
                ,Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica = new Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica() { Clave = m.Asunto_de_la_Llamada.GetValueOrDefault(), Descripcion = m.Asunto_de_la_Llamada_Descripcion }
                ,Atendio_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Atendio.GetValueOrDefault(), Name = m.Atendio_Name }
                ,Comentarios = m.Comentarios
                ,Estatus_Estatus_Llamadas = new Core.Classes.Estatus_Llamadas.Estatus_Llamadas() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Registro_de_Asistencia_Telefonica>("sp_ListSelCount_Registro_de_Asistencia_Telefonica", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Asistencia_Telefonica>("sp_ListSelAll_Registro_de_Asistencia_Telefonica", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica
                {
                    Folio = m.Registro_de_Asistencia_Telefonica_Folio,
                    Fecha_de_llamada = m.Registro_de_Asistencia_Telefonica_Fecha_de_llamada,
                    Hora_de_llamada = m.Registro_de_Asistencia_Telefonica_Hora_de_llamada,
                    Usuario_que_llama = m.Registro_de_Asistencia_Telefonica_Usuario_que_llama,
                    Dispositivo = m.Registro_de_Asistencia_Telefonica_Dispositivo,
                    Nombre_Paciente = m.Registro_de_Asistencia_Telefonica_Nombre_Paciente,
                    Suscripcion = m.Registro_de_Asistencia_Telefonica_Suscripcion,
                    Numero_telefonico_del_Paciente = m.Registro_de_Asistencia_Telefonica_Numero_telefonico_del_Paciente,
                    Correo_del_Paciente = m.Registro_de_Asistencia_Telefonica_Correo_del_Paciente,
                    Telefono_de_Asistencia_marcado = m.Registro_de_Asistencia_Telefonica_Telefono_de_Asistencia_marcado,
                    Hora_inicio_de_la_Llamada = m.Registro_de_Asistencia_Telefonica_Hora_inicio_de_la_Llamada,
                    Hora_fin_de_la_Llamada = m.Registro_de_Asistencia_Telefonica_Hora_fin_de_la_Llamada,
                    Duracion_minutos = m.Registro_de_Asistencia_Telefonica_Duracion_minutos,
                    Asunto_de_la_Llamada = m.Registro_de_Asistencia_Telefonica_Asunto_de_la_Llamada,
                    Atendio = m.Registro_de_Asistencia_Telefonica_Atendio,
                    Comentarios = m.Registro_de_Asistencia_Telefonica_Comentarios,
                    Estatus = m.Registro_de_Asistencia_Telefonica_Estatus,

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

        public IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_de_Asistencia_TelefonicaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_de_Asistencia_TelefonicaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_TelefonicaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Asistencia_Telefonica>("sp_ListSelAll_Registro_de_Asistencia_Telefonica", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Registro_de_Asistencia_TelefonicaPagingModel result = null;

            if (data != null)
            {
                result = new Registro_de_Asistencia_TelefonicaPagingModel
                {
                    Registro_de_Asistencia_Telefonicas =
                        data.Select(m => new Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica
                {
                    Folio = m.Registro_de_Asistencia_Telefonica_Folio
                    ,Fecha_de_llamada = m.Registro_de_Asistencia_Telefonica_Fecha_de_llamada
                    ,Hora_de_llamada = m.Registro_de_Asistencia_Telefonica_Hora_de_llamada
                    ,Usuario_que_llama = m.Registro_de_Asistencia_Telefonica_Usuario_que_llama
                    ,Usuario_que_llama_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Registro_de_Asistencia_Telefonica_Usuario_que_llama.GetValueOrDefault(), Name = m.Registro_de_Asistencia_Telefonica_Usuario_que_llama_Name }
                    ,Dispositivo = m.Registro_de_Asistencia_Telefonica_Dispositivo
                    ,Nombre_Paciente = m.Registro_de_Asistencia_Telefonica_Nombre_Paciente
                    ,Nombre_Paciente_Pacientes = new Core.Classes.Pacientes.Pacientes() { Folio = m.Registro_de_Asistencia_Telefonica_Nombre_Paciente.GetValueOrDefault(), Nombre_Completo = m.Registro_de_Asistencia_Telefonica_Nombre_Paciente_Nombre_Completo }
                    ,Suscripcion = m.Registro_de_Asistencia_Telefonica_Suscripcion
                    ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Registro_de_Asistencia_Telefonica_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Registro_de_Asistencia_Telefonica_Suscripcion_Nombre_del_Plan }
                    ,Numero_telefonico_del_Paciente = m.Registro_de_Asistencia_Telefonica_Numero_telefonico_del_Paciente
                    ,Correo_del_Paciente = m.Registro_de_Asistencia_Telefonica_Correo_del_Paciente
                    ,Telefono_de_Asistencia_marcado = m.Registro_de_Asistencia_Telefonica_Telefono_de_Asistencia_marcado
                    ,Hora_inicio_de_la_Llamada = m.Registro_de_Asistencia_Telefonica_Hora_inicio_de_la_Llamada
                    ,Hora_fin_de_la_Llamada = m.Registro_de_Asistencia_Telefonica_Hora_fin_de_la_Llamada
                    ,Duracion_minutos = m.Registro_de_Asistencia_Telefonica_Duracion_minutos
                    ,Asunto_de_la_Llamada = m.Registro_de_Asistencia_Telefonica_Asunto_de_la_Llamada
                    ,Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica = new Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica() { Clave = m.Registro_de_Asistencia_Telefonica_Asunto_de_la_Llamada.GetValueOrDefault(), Descripcion = m.Registro_de_Asistencia_Telefonica_Asunto_de_la_Llamada_Descripcion }
                    ,Atendio = m.Registro_de_Asistencia_Telefonica_Atendio
                    ,Atendio_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Registro_de_Asistencia_Telefonica_Atendio.GetValueOrDefault(), Name = m.Registro_de_Asistencia_Telefonica_Atendio_Name }
                    ,Comentarios = m.Registro_de_Asistencia_Telefonica_Comentarios
                    ,Estatus = m.Registro_de_Asistencia_Telefonica_Estatus
                    ,Estatus_Estatus_Llamadas = new Core.Classes.Estatus_Llamadas.Estatus_Llamadas() { Clave = m.Registro_de_Asistencia_Telefonica_Estatus.GetValueOrDefault(), Descripcion = m.Registro_de_Asistencia_Telefonica_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_de_Asistencia_TelefonicaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica>("sp_GetRegistro_de_Asistencia_Telefonica", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRegistro_de_Asistencia_Telefonica>("sp_DelRegistro_de_Asistencia_Telefonica", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_llamada = _dataProvider.GetParameter();
                padreFecha_de_llamada.ParameterName = "Fecha_de_llamada";
                padreFecha_de_llamada.DbType = DbType.DateTime;
                padreFecha_de_llamada.Value = (object)entity.Fecha_de_llamada ?? DBNull.Value;

                var padreHora_de_llamada = _dataProvider.GetParameter();
                padreHora_de_llamada.ParameterName = "Hora_de_llamada";
                padreHora_de_llamada.DbType = DbType.String;
                padreHora_de_llamada.Value = (object)entity.Hora_de_llamada ?? DBNull.Value;
                var padreUsuario_que_llama = _dataProvider.GetParameter();
                padreUsuario_que_llama.ParameterName = "Usuario_que_llama";
                padreUsuario_que_llama.DbType = DbType.Int32;
                padreUsuario_que_llama.Value = (object)entity.Usuario_que_llama ?? DBNull.Value;

                var padreDispositivo = _dataProvider.GetParameter();
                padreDispositivo.ParameterName = "Dispositivo";
                padreDispositivo.DbType = DbType.String;
                padreDispositivo.Value = (object)entity.Dispositivo ?? DBNull.Value;
                var padreNombre_Paciente = _dataProvider.GetParameter();
                padreNombre_Paciente.ParameterName = "Nombre_Paciente";
                padreNombre_Paciente.DbType = DbType.Int32;
                padreNombre_Paciente.Value = (object)entity.Nombre_Paciente ?? DBNull.Value;

                var padreSuscripcion = _dataProvider.GetParameter();
                padreSuscripcion.ParameterName = "Suscripcion";
                padreSuscripcion.DbType = DbType.Int32;
                padreSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var padreNumero_telefonico_del_Paciente = _dataProvider.GetParameter();
                padreNumero_telefonico_del_Paciente.ParameterName = "Numero_telefonico_del_Paciente";
                padreNumero_telefonico_del_Paciente.DbType = DbType.String;
                padreNumero_telefonico_del_Paciente.Value = (object)entity.Numero_telefonico_del_Paciente ?? DBNull.Value;
                var padreCorreo_del_Paciente = _dataProvider.GetParameter();
                padreCorreo_del_Paciente.ParameterName = "Correo_del_Paciente";
                padreCorreo_del_Paciente.DbType = DbType.String;
                padreCorreo_del_Paciente.Value = (object)entity.Correo_del_Paciente ?? DBNull.Value;
                var padreTelefono_de_Asistencia_marcado = _dataProvider.GetParameter();
                padreTelefono_de_Asistencia_marcado.ParameterName = "Telefono_de_Asistencia_marcado";
                padreTelefono_de_Asistencia_marcado.DbType = DbType.String;
                padreTelefono_de_Asistencia_marcado.Value = (object)entity.Telefono_de_Asistencia_marcado ?? DBNull.Value;
                var padreHora_inicio_de_la_Llamada = _dataProvider.GetParameter();
                padreHora_inicio_de_la_Llamada.ParameterName = "Hora_inicio_de_la_Llamada";
                padreHora_inicio_de_la_Llamada.DbType = DbType.String;
                padreHora_inicio_de_la_Llamada.Value = (object)entity.Hora_inicio_de_la_Llamada ?? DBNull.Value;
                var padreHora_fin_de_la_Llamada = _dataProvider.GetParameter();
                padreHora_fin_de_la_Llamada.ParameterName = "Hora_fin_de_la_Llamada";
                padreHora_fin_de_la_Llamada.DbType = DbType.String;
                padreHora_fin_de_la_Llamada.Value = (object)entity.Hora_fin_de_la_Llamada ?? DBNull.Value;
                var padreDuracion_minutos = _dataProvider.GetParameter();
                padreDuracion_minutos.ParameterName = "Duracion_minutos";
                padreDuracion_minutos.DbType = DbType.Decimal;
                padreDuracion_minutos.Value = (object)entity.Duracion_minutos ?? DBNull.Value;

                var padreAsunto_de_la_Llamada = _dataProvider.GetParameter();
                padreAsunto_de_la_Llamada.ParameterName = "Asunto_de_la_Llamada";
                padreAsunto_de_la_Llamada.DbType = DbType.Int32;
                padreAsunto_de_la_Llamada.Value = (object)entity.Asunto_de_la_Llamada ?? DBNull.Value;

                var padreAtendio = _dataProvider.GetParameter();
                padreAtendio.ParameterName = "Atendio";
                padreAtendio.DbType = DbType.Int32;
                padreAtendio.Value = (object)entity.Atendio ?? DBNull.Value;

                var padreComentarios = _dataProvider.GetParameter();
                padreComentarios.ParameterName = "Comentarios";
                padreComentarios.DbType = DbType.String;
                padreComentarios.Value = (object)entity.Comentarios ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRegistro_de_Asistencia_Telefonica>("sp_InsRegistro_de_Asistencia_Telefonica" , padreFecha_de_llamada
, padreHora_de_llamada
, padreUsuario_que_llama
, padreDispositivo
, padreNombre_Paciente
, padreSuscripcion
, padreNumero_telefonico_del_Paciente
, padreCorreo_del_Paciente
, padreTelefono_de_Asistencia_marcado
, padreHora_inicio_de_la_Llamada
, padreHora_fin_de_la_Llamada
, padreDuracion_minutos
, padreAsunto_de_la_Llamada
, padreAtendio
, padreComentarios
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

        public int Update(Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_llamada = _dataProvider.GetParameter();
                paramUpdFecha_de_llamada.ParameterName = "Fecha_de_llamada";
                paramUpdFecha_de_llamada.DbType = DbType.DateTime;
                paramUpdFecha_de_llamada.Value = (object)entity.Fecha_de_llamada ?? DBNull.Value;

                var paramUpdHora_de_llamada = _dataProvider.GetParameter();
                paramUpdHora_de_llamada.ParameterName = "Hora_de_llamada";
                paramUpdHora_de_llamada.DbType = DbType.String;
                paramUpdHora_de_llamada.Value = (object)entity.Hora_de_llamada ?? DBNull.Value;
                var paramUpdUsuario_que_llama = _dataProvider.GetParameter();
                paramUpdUsuario_que_llama.ParameterName = "Usuario_que_llama";
                paramUpdUsuario_que_llama.DbType = DbType.Int32;
                paramUpdUsuario_que_llama.Value = (object)entity.Usuario_que_llama ?? DBNull.Value;

                var paramUpdDispositivo = _dataProvider.GetParameter();
                paramUpdDispositivo.ParameterName = "Dispositivo";
                paramUpdDispositivo.DbType = DbType.String;
                paramUpdDispositivo.Value = (object)entity.Dispositivo ?? DBNull.Value;
                var paramUpdNombre_Paciente = _dataProvider.GetParameter();
                paramUpdNombre_Paciente.ParameterName = "Nombre_Paciente";
                paramUpdNombre_Paciente.DbType = DbType.Int32;
                paramUpdNombre_Paciente.Value = (object)entity.Nombre_Paciente ?? DBNull.Value;

                var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var paramUpdNumero_telefonico_del_Paciente = _dataProvider.GetParameter();
                paramUpdNumero_telefonico_del_Paciente.ParameterName = "Numero_telefonico_del_Paciente";
                paramUpdNumero_telefonico_del_Paciente.DbType = DbType.String;
                paramUpdNumero_telefonico_del_Paciente.Value = (object)entity.Numero_telefonico_del_Paciente ?? DBNull.Value;
                var paramUpdCorreo_del_Paciente = _dataProvider.GetParameter();
                paramUpdCorreo_del_Paciente.ParameterName = "Correo_del_Paciente";
                paramUpdCorreo_del_Paciente.DbType = DbType.String;
                paramUpdCorreo_del_Paciente.Value = (object)entity.Correo_del_Paciente ?? DBNull.Value;
                var paramUpdTelefono_de_Asistencia_marcado = _dataProvider.GetParameter();
                paramUpdTelefono_de_Asistencia_marcado.ParameterName = "Telefono_de_Asistencia_marcado";
                paramUpdTelefono_de_Asistencia_marcado.DbType = DbType.String;
                paramUpdTelefono_de_Asistencia_marcado.Value = (object)entity.Telefono_de_Asistencia_marcado ?? DBNull.Value;
                var paramUpdHora_inicio_de_la_Llamada = _dataProvider.GetParameter();
                paramUpdHora_inicio_de_la_Llamada.ParameterName = "Hora_inicio_de_la_Llamada";
                paramUpdHora_inicio_de_la_Llamada.DbType = DbType.String;
                paramUpdHora_inicio_de_la_Llamada.Value = (object)entity.Hora_inicio_de_la_Llamada ?? DBNull.Value;
                var paramUpdHora_fin_de_la_Llamada = _dataProvider.GetParameter();
                paramUpdHora_fin_de_la_Llamada.ParameterName = "Hora_fin_de_la_Llamada";
                paramUpdHora_fin_de_la_Llamada.DbType = DbType.String;
                paramUpdHora_fin_de_la_Llamada.Value = (object)entity.Hora_fin_de_la_Llamada ?? DBNull.Value;
                var paramUpdDuracion_minutos = _dataProvider.GetParameter();
                paramUpdDuracion_minutos.ParameterName = "Duracion_minutos";
                paramUpdDuracion_minutos.DbType = DbType.Decimal;
                paramUpdDuracion_minutos.Value = (object)entity.Duracion_minutos ?? DBNull.Value;

                var paramUpdAsunto_de_la_Llamada = _dataProvider.GetParameter();
                paramUpdAsunto_de_la_Llamada.ParameterName = "Asunto_de_la_Llamada";
                paramUpdAsunto_de_la_Llamada.DbType = DbType.Int32;
                paramUpdAsunto_de_la_Llamada.Value = (object)entity.Asunto_de_la_Llamada ?? DBNull.Value;

                var paramUpdAtendio = _dataProvider.GetParameter();
                paramUpdAtendio.ParameterName = "Atendio";
                paramUpdAtendio.DbType = DbType.Int32;
                paramUpdAtendio.Value = (object)entity.Atendio ?? DBNull.Value;

                var paramUpdComentarios = _dataProvider.GetParameter();
                paramUpdComentarios.ParameterName = "Comentarios";
                paramUpdComentarios.DbType = DbType.String;
                paramUpdComentarios.Value = (object)entity.Comentarios ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_de_Asistencia_Telefonica>("sp_UpdRegistro_de_Asistencia_Telefonica" , paramUpdFolio , paramUpdFecha_de_llamada , paramUpdHora_de_llamada , paramUpdUsuario_que_llama , paramUpdDispositivo , paramUpdNombre_Paciente , paramUpdSuscripcion , paramUpdNumero_telefonico_del_Paciente , paramUpdCorreo_del_Paciente , paramUpdTelefono_de_Asistencia_marcado , paramUpdHora_inicio_de_la_Llamada , paramUpdHora_fin_de_la_Llamada , paramUpdDuracion_minutos , paramUpdAsunto_de_la_Llamada , paramUpdAtendio , paramUpdComentarios , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica Registro_de_Asistencia_TelefonicaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_llamada = _dataProvider.GetParameter();
                paramUpdFecha_de_llamada.ParameterName = "Fecha_de_llamada";
                paramUpdFecha_de_llamada.DbType = DbType.DateTime;
                paramUpdFecha_de_llamada.Value = (object)entity.Fecha_de_llamada ?? DBNull.Value;
                var paramUpdHora_de_llamada = _dataProvider.GetParameter();
                paramUpdHora_de_llamada.ParameterName = "Hora_de_llamada";
                paramUpdHora_de_llamada.DbType = DbType.String;
                paramUpdHora_de_llamada.Value = (object)entity.Hora_de_llamada ?? DBNull.Value;
		var paramUpdUsuario_que_llama = _dataProvider.GetParameter();
                paramUpdUsuario_que_llama.ParameterName = "Usuario_que_llama";
                paramUpdUsuario_que_llama.DbType = DbType.Int32;
                paramUpdUsuario_que_llama.Value = (object)entity.Usuario_que_llama ?? DBNull.Value;
                var paramUpdDispositivo = _dataProvider.GetParameter();
                paramUpdDispositivo.ParameterName = "Dispositivo";
                paramUpdDispositivo.DbType = DbType.String;
                paramUpdDispositivo.Value = (object)entity.Dispositivo ?? DBNull.Value;
		var paramUpdNombre_Paciente = _dataProvider.GetParameter();
                paramUpdNombre_Paciente.ParameterName = "Nombre_Paciente";
                paramUpdNombre_Paciente.DbType = DbType.Int32;
                paramUpdNombre_Paciente.Value = (object)entity.Nombre_Paciente ?? DBNull.Value;
                var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;
                var paramUpdNumero_telefonico_del_Paciente = _dataProvider.GetParameter();
                paramUpdNumero_telefonico_del_Paciente.ParameterName = "Numero_telefonico_del_Paciente";
                paramUpdNumero_telefonico_del_Paciente.DbType = DbType.String;
                paramUpdNumero_telefonico_del_Paciente.Value = (object)entity.Numero_telefonico_del_Paciente ?? DBNull.Value;
                var paramUpdCorreo_del_Paciente = _dataProvider.GetParameter();
                paramUpdCorreo_del_Paciente.ParameterName = "Correo_del_Paciente";
                paramUpdCorreo_del_Paciente.DbType = DbType.String;
                paramUpdCorreo_del_Paciente.Value = (object)entity.Correo_del_Paciente ?? DBNull.Value;
                var paramUpdTelefono_de_Asistencia_marcado = _dataProvider.GetParameter();
                paramUpdTelefono_de_Asistencia_marcado.ParameterName = "Telefono_de_Asistencia_marcado";
                paramUpdTelefono_de_Asistencia_marcado.DbType = DbType.String;
                paramUpdTelefono_de_Asistencia_marcado.Value = (object)entity.Telefono_de_Asistencia_marcado ?? DBNull.Value;
                var paramUpdHora_inicio_de_la_Llamada = _dataProvider.GetParameter();
                paramUpdHora_inicio_de_la_Llamada.ParameterName = "Hora_inicio_de_la_Llamada";
                paramUpdHora_inicio_de_la_Llamada.DbType = DbType.String;
                paramUpdHora_inicio_de_la_Llamada.Value = (object)entity.Hora_inicio_de_la_Llamada ?? DBNull.Value;
                var paramUpdHora_fin_de_la_Llamada = _dataProvider.GetParameter();
                paramUpdHora_fin_de_la_Llamada.ParameterName = "Hora_fin_de_la_Llamada";
                paramUpdHora_fin_de_la_Llamada.DbType = DbType.String;
                paramUpdHora_fin_de_la_Llamada.Value = (object)entity.Hora_fin_de_la_Llamada ?? DBNull.Value;
                var paramUpdDuracion_minutos = _dataProvider.GetParameter();
                paramUpdDuracion_minutos.ParameterName = "Duracion_minutos";
                paramUpdDuracion_minutos.DbType = DbType.Decimal;
                paramUpdDuracion_minutos.Value = (object)entity.Duracion_minutos ?? DBNull.Value;
		var paramUpdAsunto_de_la_Llamada = _dataProvider.GetParameter();
                paramUpdAsunto_de_la_Llamada.ParameterName = "Asunto_de_la_Llamada";
                paramUpdAsunto_de_la_Llamada.DbType = DbType.Int32;
                paramUpdAsunto_de_la_Llamada.Value = (object)entity.Asunto_de_la_Llamada ?? DBNull.Value;
		var paramUpdAtendio = _dataProvider.GetParameter();
                paramUpdAtendio.ParameterName = "Atendio";
                paramUpdAtendio.DbType = DbType.Int32;
                paramUpdAtendio.Value = (object)entity.Atendio ?? DBNull.Value;
                var paramUpdComentarios = _dataProvider.GetParameter();
                paramUpdComentarios.ParameterName = "Comentarios";
                paramUpdComentarios.DbType = DbType.String;
                paramUpdComentarios.Value = (object)entity.Comentarios ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_de_Asistencia_Telefonica>("sp_UpdRegistro_de_Asistencia_Telefonica" , paramUpdFolio , paramUpdFecha_de_llamada , paramUpdHora_de_llamada , paramUpdUsuario_que_llama , paramUpdDispositivo , paramUpdNombre_Paciente , paramUpdSuscripcion , paramUpdNumero_telefonico_del_Paciente , paramUpdCorreo_del_Paciente , paramUpdTelefono_de_Asistencia_marcado , paramUpdHora_inicio_de_la_Llamada , paramUpdHora_fin_de_la_Llamada , paramUpdDuracion_minutos , paramUpdAsunto_de_la_Llamada , paramUpdAtendio , paramUpdComentarios , paramUpdEstatus ).FirstOrDefault();

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


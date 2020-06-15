using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Eventos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Eventos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EventosService : IEventosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Eventos.Eventos> _EventosRepository;
        #endregion

        #region Ctor
        public EventosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Eventos.Eventos> EventosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EventosRepository = EventosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._EventosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Eventos.Eventos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Eventos.Eventos>("sp_SelAllEventos");
        }

        public IList<Core.Classes.Eventos.Eventos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEventos_Complete>("sp_SelAllComplete_Eventos");
            return data.Select(m => new Core.Classes.Eventos.Eventos
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Empresa_Empresas = new Core.Classes.Empresas.Empresas() { Folio = m.Empresa.GetValueOrDefault(), Nombre_de_la_Empresa = m.Empresa_Nombre_de_la_Empresa }
                ,Nombre_del_Evento = m.Nombre_del_Evento
                ,Descripcion = m.Descripcion
                ,Fecha_inicio_del_Evento = m.Fecha_inicio_del_Evento
                ,Fecha_fin_del_Evento = m.Fecha_fin_del_Evento
                ,Cantidad_de_dias = m.Cantidad_de_dias
                ,Evento_en_Empresa_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Evento_en_Empresa.GetValueOrDefault(), Descripcion = m.Evento_en_Empresa_Descripcion }
                ,Nombre_del_Lugar = m.Nombre_del_Lugar
                ,Calle = m.Calle
                ,Numero_exterior = m.Numero_exterior
                ,Numero_interior = m.Numero_interior
                ,Colonia = m.Colonia
                ,CP = m.CP
                ,Ciudad = m.Ciudad
                ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Estado.GetValueOrDefault(), Nombre_del_Estado = m.Estado_Nombre_del_Estado }
                ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais.GetValueOrDefault(), Nombre_del_Pais = m.Pais_Nombre_del_Pais }
                ,Permite_Familiares_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Permite_Familiares.GetValueOrDefault(), Descripcion = m.Permite_Familiares_Descripcion }
                ,Estatus_Estatus_Eventos = new Core.Classes.Estatus_Eventos.Estatus_Eventos() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Eventos>("sp_ListSelCount_Eventos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Eventos.Eventos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEventos>("sp_ListSelAll_Eventos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Eventos.Eventos
                {
                    Folio = m.Eventos_Folio,
                    Fecha_de_Registro = m.Eventos_Fecha_de_Registro,
                    Hora_de_Registro = m.Eventos_Hora_de_Registro,
                    Usuario_que_Registra = m.Eventos_Usuario_que_Registra,
                    Empresa = m.Eventos_Empresa,
                    Nombre_del_Evento = m.Eventos_Nombre_del_Evento,
                    Descripcion = m.Eventos_Descripcion,
                    Fecha_inicio_del_Evento = m.Eventos_Fecha_inicio_del_Evento,
                    Fecha_fin_del_Evento = m.Eventos_Fecha_fin_del_Evento,
                    Cantidad_de_dias = m.Eventos_Cantidad_de_dias,
                    Evento_en_Empresa = m.Eventos_Evento_en_Empresa,
                    Nombre_del_Lugar = m.Eventos_Nombre_del_Lugar,
                    Calle = m.Eventos_Calle,
                    Numero_exterior = m.Eventos_Numero_exterior,
                    Numero_interior = m.Eventos_Numero_interior,
                    Colonia = m.Eventos_Colonia,
                    CP = m.Eventos_CP,
                    Ciudad = m.Eventos_Ciudad,
                    Estado = m.Eventos_Estado,
                    Pais = m.Eventos_Pais,
                    Permite_Familiares = m.Eventos_Permite_Familiares,
                    Estatus = m.Eventos_Estatus,

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

        public IList<Spartane.Core.Classes.Eventos.Eventos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EventosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Eventos.Eventos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EventosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Eventos.EventosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEventos>("sp_ListSelAll_Eventos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            EventosPagingModel result = null;

            if (data != null)
            {
                result = new EventosPagingModel
                {
                    Eventoss =
                        data.Select(m => new Spartane.Core.Classes.Eventos.Eventos
                {
                    Folio = m.Eventos_Folio
                    ,Fecha_de_Registro = m.Eventos_Fecha_de_Registro
                    ,Hora_de_Registro = m.Eventos_Hora_de_Registro
                    ,Usuario_que_Registra = m.Eventos_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Eventos_Usuario_que_Registra.GetValueOrDefault(), Name = m.Eventos_Usuario_que_Registra_Name }
                    ,Empresa = m.Eventos_Empresa
                    ,Empresa_Empresas = new Core.Classes.Empresas.Empresas() { Folio = m.Eventos_Empresa.GetValueOrDefault(), Nombre_de_la_Empresa = m.Eventos_Empresa_Nombre_de_la_Empresa }
                    ,Nombre_del_Evento = m.Eventos_Nombre_del_Evento
                    ,Descripcion = m.Eventos_Descripcion
                    ,Fecha_inicio_del_Evento = m.Eventos_Fecha_inicio_del_Evento
                    ,Fecha_fin_del_Evento = m.Eventos_Fecha_fin_del_Evento
                    ,Cantidad_de_dias = m.Eventos_Cantidad_de_dias
                    ,Evento_en_Empresa = m.Eventos_Evento_en_Empresa
                    ,Evento_en_Empresa_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Eventos_Evento_en_Empresa.GetValueOrDefault(), Descripcion = m.Eventos_Evento_en_Empresa_Descripcion }
                    ,Nombre_del_Lugar = m.Eventos_Nombre_del_Lugar
                    ,Calle = m.Eventos_Calle
                    ,Numero_exterior = m.Eventos_Numero_exterior
                    ,Numero_interior = m.Eventos_Numero_interior
                    ,Colonia = m.Eventos_Colonia
                    ,CP = m.Eventos_CP
                    ,Ciudad = m.Eventos_Ciudad
                    ,Estado = m.Eventos_Estado
                    ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Eventos_Estado.GetValueOrDefault(), Nombre_del_Estado = m.Eventos_Estado_Nombre_del_Estado }
                    ,Pais = m.Eventos_Pais
                    ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Eventos_Pais.GetValueOrDefault(), Nombre_del_Pais = m.Eventos_Pais_Nombre_del_Pais }
                    ,Permite_Familiares = m.Eventos_Permite_Familiares
                    ,Permite_Familiares_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Eventos_Permite_Familiares.GetValueOrDefault(), Descripcion = m.Eventos_Permite_Familiares_Descripcion }
                    ,Estatus = m.Eventos_Estatus
                    ,Estatus_Estatus_Eventos = new Core.Classes.Estatus_Eventos.Estatus_Eventos() { Clave = m.Eventos_Estatus.GetValueOrDefault(), Descripcion = m.Eventos_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Eventos.Eventos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EventosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Eventos.Eventos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Eventos.Eventos>("sp_GetEventos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEventos>("sp_DelEventos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Eventos.Eventos entity)
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

                var padreEmpresa = _dataProvider.GetParameter();
                padreEmpresa.ParameterName = "Empresa";
                padreEmpresa.DbType = DbType.Int32;
                padreEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;

                var padreNombre_del_Evento = _dataProvider.GetParameter();
                padreNombre_del_Evento.ParameterName = "Nombre_del_Evento";
                padreNombre_del_Evento.DbType = DbType.String;
                padreNombre_del_Evento.Value = (object)entity.Nombre_del_Evento ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreFecha_inicio_del_Evento = _dataProvider.GetParameter();
                padreFecha_inicio_del_Evento.ParameterName = "Fecha_inicio_del_Evento";
                padreFecha_inicio_del_Evento.DbType = DbType.DateTime;
                padreFecha_inicio_del_Evento.Value = (object)entity.Fecha_inicio_del_Evento ?? DBNull.Value;

                var padreFecha_fin_del_Evento = _dataProvider.GetParameter();
                padreFecha_fin_del_Evento.ParameterName = "Fecha_fin_del_Evento";
                padreFecha_fin_del_Evento.DbType = DbType.DateTime;
                padreFecha_fin_del_Evento.Value = (object)entity.Fecha_fin_del_Evento ?? DBNull.Value;

                var padreCantidad_de_dias = _dataProvider.GetParameter();
                padreCantidad_de_dias.ParameterName = "Cantidad_de_dias";
                padreCantidad_de_dias.DbType = DbType.Int32;
                padreCantidad_de_dias.Value = (object)entity.Cantidad_de_dias ?? DBNull.Value;

                var padreEvento_en_Empresa = _dataProvider.GetParameter();
                padreEvento_en_Empresa.ParameterName = "Evento_en_Empresa";
                padreEvento_en_Empresa.DbType = DbType.Int32;
                padreEvento_en_Empresa.Value = (object)entity.Evento_en_Empresa ?? DBNull.Value;

                var padreNombre_del_Lugar = _dataProvider.GetParameter();
                padreNombre_del_Lugar.ParameterName = "Nombre_del_Lugar";
                padreNombre_del_Lugar.DbType = DbType.String;
                padreNombre_del_Lugar.Value = (object)entity.Nombre_del_Lugar ?? DBNull.Value;
                var padreCalle = _dataProvider.GetParameter();
                padreCalle.ParameterName = "Calle";
                padreCalle.DbType = DbType.String;
                padreCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var padreNumero_exterior = _dataProvider.GetParameter();
                padreNumero_exterior.ParameterName = "Numero_exterior";
                padreNumero_exterior.DbType = DbType.String;
                padreNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var padreNumero_interior = _dataProvider.GetParameter();
                padreNumero_interior.ParameterName = "Numero_interior";
                padreNumero_interior.DbType = DbType.String;
                padreNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var padreColonia = _dataProvider.GetParameter();
                padreColonia.ParameterName = "Colonia";
                padreColonia.DbType = DbType.String;
                padreColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var padreCP = _dataProvider.GetParameter();
                padreCP.ParameterName = "CP";
                padreCP.DbType = DbType.String;
                padreCP.Value = (object)entity.CP ?? DBNull.Value;
                var padreCiudad = _dataProvider.GetParameter();
                padreCiudad.ParameterName = "Ciudad";
                padreCiudad.DbType = DbType.String;
                padreCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var padreEstado = _dataProvider.GetParameter();
                padreEstado.ParameterName = "Estado";
                padreEstado.DbType = DbType.Int32;
                padreEstado.Value = (object)entity.Estado ?? DBNull.Value;

                var padrePais = _dataProvider.GetParameter();
                padrePais.ParameterName = "Pais";
                padrePais.DbType = DbType.Int32;
                padrePais.Value = (object)entity.Pais ?? DBNull.Value;

                var padrePermite_Familiares = _dataProvider.GetParameter();
                padrePermite_Familiares.ParameterName = "Permite_Familiares";
                padrePermite_Familiares.DbType = DbType.Int32;
                padrePermite_Familiares.Value = (object)entity.Permite_Familiares ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEventos>("sp_InsEventos" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreEmpresa
, padreNombre_del_Evento
, padreDescripcion
, padreFecha_inicio_del_Evento
, padreFecha_fin_del_Evento
, padreCantidad_de_dias
, padreEvento_en_Empresa
, padreNombre_del_Lugar
, padreCalle
, padreNumero_exterior
, padreNumero_interior
, padreColonia
, padreCP
, padreCiudad
, padreEstado
, padrePais
, padrePermite_Familiares
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

        public int Update(Spartane.Core.Classes.Eventos.Eventos entity)
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

                var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;

                var paramUpdNombre_del_Evento = _dataProvider.GetParameter();
                paramUpdNombre_del_Evento.ParameterName = "Nombre_del_Evento";
                paramUpdNombre_del_Evento.DbType = DbType.String;
                paramUpdNombre_del_Evento.Value = (object)entity.Nombre_del_Evento ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdFecha_inicio_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_Evento.ParameterName = "Fecha_inicio_del_Evento";
                paramUpdFecha_inicio_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_Evento.Value = (object)entity.Fecha_inicio_del_Evento ?? DBNull.Value;

                var paramUpdFecha_fin_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_Evento.ParameterName = "Fecha_fin_del_Evento";
                paramUpdFecha_fin_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_Evento.Value = (object)entity.Fecha_fin_del_Evento ?? DBNull.Value;

                var paramUpdCantidad_de_dias = _dataProvider.GetParameter();
                paramUpdCantidad_de_dias.ParameterName = "Cantidad_de_dias";
                paramUpdCantidad_de_dias.DbType = DbType.Int32;
                paramUpdCantidad_de_dias.Value = (object)entity.Cantidad_de_dias ?? DBNull.Value;

                var paramUpdEvento_en_Empresa = _dataProvider.GetParameter();
                paramUpdEvento_en_Empresa.ParameterName = "Evento_en_Empresa";
                paramUpdEvento_en_Empresa.DbType = DbType.Int32;
                paramUpdEvento_en_Empresa.Value = (object)entity.Evento_en_Empresa ?? DBNull.Value;

                var paramUpdNombre_del_Lugar = _dataProvider.GetParameter();
                paramUpdNombre_del_Lugar.ParameterName = "Nombre_del_Lugar";
                paramUpdNombre_del_Lugar.DbType = DbType.String;
                paramUpdNombre_del_Lugar.Value = (object)entity.Nombre_del_Lugar ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.String;
                paramUpdCP.Value = (object)entity.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;

                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;

                var paramUpdPermite_Familiares = _dataProvider.GetParameter();
                paramUpdPermite_Familiares.ParameterName = "Permite_Familiares";
                paramUpdPermite_Familiares.DbType = DbType.Int32;
                paramUpdPermite_Familiares.Value = (object)entity.Permite_Familiares ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEventos>("sp_UpdEventos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdEmpresa , paramUpdNombre_del_Evento , paramUpdDescripcion , paramUpdFecha_inicio_del_Evento , paramUpdFecha_fin_del_Evento , paramUpdCantidad_de_dias , paramUpdEvento_en_Empresa , paramUpdNombre_del_Lugar , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdPermite_Familiares , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Eventos.Eventos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Eventos.Eventos EventosDB = GetByKey(entity.Folio, false);
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
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;
                var paramUpdNombre_del_Evento = _dataProvider.GetParameter();
                paramUpdNombre_del_Evento.ParameterName = "Nombre_del_Evento";
                paramUpdNombre_del_Evento.DbType = DbType.String;
                paramUpdNombre_del_Evento.Value = (object)entity.Nombre_del_Evento ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdFecha_inicio_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_Evento.ParameterName = "Fecha_inicio_del_Evento";
                paramUpdFecha_inicio_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_Evento.Value = (object)entity.Fecha_inicio_del_Evento ?? DBNull.Value;
                var paramUpdFecha_fin_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_Evento.ParameterName = "Fecha_fin_del_Evento";
                paramUpdFecha_fin_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_Evento.Value = (object)entity.Fecha_fin_del_Evento ?? DBNull.Value;
                var paramUpdCantidad_de_dias = _dataProvider.GetParameter();
                paramUpdCantidad_de_dias.ParameterName = "Cantidad_de_dias";
                paramUpdCantidad_de_dias.DbType = DbType.Int32;
                paramUpdCantidad_de_dias.Value = (object)entity.Cantidad_de_dias ?? DBNull.Value;
		var paramUpdEvento_en_Empresa = _dataProvider.GetParameter();
                paramUpdEvento_en_Empresa.ParameterName = "Evento_en_Empresa";
                paramUpdEvento_en_Empresa.DbType = DbType.Int32;
                paramUpdEvento_en_Empresa.Value = (object)entity.Evento_en_Empresa ?? DBNull.Value;
                var paramUpdNombre_del_Lugar = _dataProvider.GetParameter();
                paramUpdNombre_del_Lugar.ParameterName = "Nombre_del_Lugar";
                paramUpdNombre_del_Lugar.DbType = DbType.String;
                paramUpdNombre_del_Lugar.Value = (object)entity.Nombre_del_Lugar ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.String;
                paramUpdCP.Value = (object)entity.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;
		var paramUpdPermite_Familiares = _dataProvider.GetParameter();
                paramUpdPermite_Familiares.ParameterName = "Permite_Familiares";
                paramUpdPermite_Familiares.DbType = DbType.Int32;
                paramUpdPermite_Familiares.Value = (object)entity.Permite_Familiares ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEventos>("sp_UpdEventos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdEmpresa , paramUpdNombre_del_Evento , paramUpdDescripcion , paramUpdFecha_inicio_del_Evento , paramUpdFecha_fin_del_Evento , paramUpdCantidad_de_dias , paramUpdEvento_en_Empresa , paramUpdNombre_del_Lugar , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdPermite_Familiares , paramUpdEstatus ).FirstOrDefault();

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

		public int Update_Actividades(Spartane.Core.Classes.Eventos.Eventos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Eventos.Eventos EventosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)EventosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)EventosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)EventosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)EventosDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)EventosDB.Empresa ?? DBNull.Value;
                var paramUpdNombre_del_Evento = _dataProvider.GetParameter();
                paramUpdNombre_del_Evento.ParameterName = "Nombre_del_Evento";
                paramUpdNombre_del_Evento.DbType = DbType.String;
                paramUpdNombre_del_Evento.Value = (object)EventosDB.Nombre_del_Evento ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)EventosDB.Descripcion ?? DBNull.Value;
                var paramUpdFecha_inicio_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_Evento.ParameterName = "Fecha_inicio_del_Evento";
                paramUpdFecha_inicio_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_Evento.Value = (object)EventosDB.Fecha_inicio_del_Evento ?? DBNull.Value;
                var paramUpdFecha_fin_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_Evento.ParameterName = "Fecha_fin_del_Evento";
                paramUpdFecha_fin_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_Evento.Value = (object)EventosDB.Fecha_fin_del_Evento ?? DBNull.Value;
                var paramUpdCantidad_de_dias = _dataProvider.GetParameter();
                paramUpdCantidad_de_dias.ParameterName = "Cantidad_de_dias";
                paramUpdCantidad_de_dias.DbType = DbType.Int32;
                paramUpdCantidad_de_dias.Value = (object)EventosDB.Cantidad_de_dias ?? DBNull.Value;
		var paramUpdEvento_en_Empresa = _dataProvider.GetParameter();
                paramUpdEvento_en_Empresa.ParameterName = "Evento_en_Empresa";
                paramUpdEvento_en_Empresa.DbType = DbType.Int32;
                paramUpdEvento_en_Empresa.Value = (object)EventosDB.Evento_en_Empresa ?? DBNull.Value;
                var paramUpdNombre_del_Lugar = _dataProvider.GetParameter();
                paramUpdNombre_del_Lugar.ParameterName = "Nombre_del_Lugar";
                paramUpdNombre_del_Lugar.DbType = DbType.String;
                paramUpdNombre_del_Lugar.Value = (object)EventosDB.Nombre_del_Lugar ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)EventosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)EventosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)EventosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)EventosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.String;
                paramUpdCP.Value = (object)EventosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)EventosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)EventosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)EventosDB.Pais ?? DBNull.Value;
		var paramUpdPermite_Familiares = _dataProvider.GetParameter();
                paramUpdPermite_Familiares.ParameterName = "Permite_Familiares";
                paramUpdPermite_Familiares.DbType = DbType.Int32;
                paramUpdPermite_Familiares.Value = (object)EventosDB.Permite_Familiares ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)EventosDB.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEventos>("sp_UpdEventos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdEmpresa , paramUpdNombre_del_Evento , paramUpdDescripcion , paramUpdFecha_inicio_del_Evento , paramUpdFecha_fin_del_Evento , paramUpdCantidad_de_dias , paramUpdEvento_en_Empresa , paramUpdNombre_del_Lugar , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdPermite_Familiares , paramUpdEstatus ).FirstOrDefault();

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


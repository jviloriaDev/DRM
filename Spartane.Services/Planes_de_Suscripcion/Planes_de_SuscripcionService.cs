using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Planes_de_Suscripcion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Planes_de_Suscripcion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Planes_de_SuscripcionService : IPlanes_de_SuscripcionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion> _Planes_de_SuscripcionRepository;
        #endregion

        #region Ctor
        public Planes_de_SuscripcionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion> Planes_de_SuscripcionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Planes_de_SuscripcionRepository = Planes_de_SuscripcionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Planes_de_SuscripcionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion>("sp_SelAllPlanes_de_Suscripcion");
        }

        public IList<Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPlanes_de_Suscripcion_Complete>("sp_SelAllComplete_Planes_de_Suscripcion");
            return data.Select(m => new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Tipo_de_Beneficiario_Tipo_de_Plan_de_Suscripcion = new Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion() { Clave = m.Tipo_de_Beneficiario.GetValueOrDefault(), Nombre = m.Tipo_de_Beneficiario_Nombre }
                ,Nombre = m.Nombre
                ,Nombre_del_Plan = m.Nombre_del_Plan
                ,Duracion_en_meses = m.Duracion_en_meses
                ,Duracion = m.Duracion
                ,Dietas_por_mes = m.Dietas_por_mes
                ,Rutinas_por_mes = m.Rutinas_por_mes
                ,Costo_mensual = m.Costo_mensual
                ,Precio_Final = m.Precio_Final
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Planes_de_Suscripcion>("sp_ListSelCount_Planes_de_Suscripcion", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlanes_de_Suscripcion>("sp_ListSelAll_Planes_de_Suscripcion", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion
                {
                    Folio = m.Planes_de_Suscripcion_Folio,
                    Fecha_de_Registro = m.Planes_de_Suscripcion_Fecha_de_Registro,
                    Hora_de_Registro = m.Planes_de_Suscripcion_Hora_de_Registro,
                    Usuario_que_Registra = m.Planes_de_Suscripcion_Usuario_que_Registra,
                    Tipo_de_Beneficiario = m.Planes_de_Suscripcion_Tipo_de_Beneficiario,
                    Nombre = m.Planes_de_Suscripcion_Nombre,
                    Nombre_del_Plan = m.Planes_de_Suscripcion_Nombre_del_Plan,
                    Duracion_en_meses = m.Planes_de_Suscripcion_Duracion_en_meses,
                    Duracion = m.Planes_de_Suscripcion_Duracion,
                    Dietas_por_mes = m.Planes_de_Suscripcion_Dietas_por_mes,
                    Rutinas_por_mes = m.Planes_de_Suscripcion_Rutinas_por_mes,
                    Costo_mensual = m.Planes_de_Suscripcion_Costo_mensual,
                    Precio_Final = m.Planes_de_Suscripcion_Precio_Final,
                    Estatus = m.Planes_de_Suscripcion_Estatus,

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

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Planes_de_SuscripcionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_de_SuscripcionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_SuscripcionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlanes_de_Suscripcion>("sp_ListSelAll_Planes_de_Suscripcion", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Planes_de_SuscripcionPagingModel result = null;

            if (data != null)
            {
                result = new Planes_de_SuscripcionPagingModel
                {
                    Planes_de_Suscripcions =
                        data.Select(m => new Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion
                {
                    Folio = m.Planes_de_Suscripcion_Folio
                    ,Fecha_de_Registro = m.Planes_de_Suscripcion_Fecha_de_Registro
                    ,Hora_de_Registro = m.Planes_de_Suscripcion_Hora_de_Registro
                    ,Usuario_que_Registra = m.Planes_de_Suscripcion_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Planes_de_Suscripcion_Usuario_que_Registra.GetValueOrDefault(), Name = m.Planes_de_Suscripcion_Usuario_que_Registra_Name }
                    ,Tipo_de_Beneficiario = m.Planes_de_Suscripcion_Tipo_de_Beneficiario
                    ,Tipo_de_Beneficiario_Tipo_de_Plan_de_Suscripcion = new Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion() { Clave = m.Planes_de_Suscripcion_Tipo_de_Beneficiario.GetValueOrDefault(), Nombre = m.Planes_de_Suscripcion_Tipo_de_Beneficiario_Nombre }
                    ,Nombre = m.Planes_de_Suscripcion_Nombre
                    ,Nombre_del_Plan = m.Planes_de_Suscripcion_Nombre_del_Plan
                    ,Duracion_en_meses = m.Planes_de_Suscripcion_Duracion_en_meses
                    ,Duracion = m.Planes_de_Suscripcion_Duracion
                    ,Dietas_por_mes = m.Planes_de_Suscripcion_Dietas_por_mes
                    ,Rutinas_por_mes = m.Planes_de_Suscripcion_Rutinas_por_mes
                    ,Costo_mensual = m.Planes_de_Suscripcion_Costo_mensual
                    ,Precio_Final = m.Planes_de_Suscripcion_Precio_Final
                    ,Estatus = m.Planes_de_Suscripcion_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Planes_de_Suscripcion_Estatus.GetValueOrDefault(), Descripcion = m.Planes_de_Suscripcion_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Planes_de_SuscripcionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion>("sp_GetPlanes_de_Suscripcion", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPlanes_de_Suscripcion>("sp_DelPlanes_de_Suscripcion", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion entity)
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

                var padreTipo_de_Beneficiario = _dataProvider.GetParameter();
                padreTipo_de_Beneficiario.ParameterName = "Tipo_de_Beneficiario";
                padreTipo_de_Beneficiario.DbType = DbType.Int32;
                padreTipo_de_Beneficiario.Value = (object)entity.Tipo_de_Beneficiario ?? DBNull.Value;

                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreNombre_del_Plan = _dataProvider.GetParameter();
                padreNombre_del_Plan.ParameterName = "Nombre_del_Plan";
                padreNombre_del_Plan.DbType = DbType.String;
                padreNombre_del_Plan.Value = (object)entity.Nombre_del_Plan ?? DBNull.Value;
                var padreDuracion_en_meses = _dataProvider.GetParameter();
                padreDuracion_en_meses.ParameterName = "Duracion_en_meses";
                padreDuracion_en_meses.DbType = DbType.Int32;
                padreDuracion_en_meses.Value = (object)entity.Duracion_en_meses ?? DBNull.Value;

                var padreDuracion = _dataProvider.GetParameter();
                padreDuracion.ParameterName = "Duracion";
                padreDuracion.DbType = DbType.Int32;
                padreDuracion.Value = (object)entity.Duracion ?? DBNull.Value;

                var padreDietas_por_mes = _dataProvider.GetParameter();
                padreDietas_por_mes.ParameterName = "Dietas_por_mes";
                padreDietas_por_mes.DbType = DbType.Int32;
                padreDietas_por_mes.Value = (object)entity.Dietas_por_mes ?? DBNull.Value;

                var padreRutinas_por_mes = _dataProvider.GetParameter();
                padreRutinas_por_mes.ParameterName = "Rutinas_por_mes";
                padreRutinas_por_mes.DbType = DbType.Int32;
                padreRutinas_por_mes.Value = (object)entity.Rutinas_por_mes ?? DBNull.Value;

                var padreCosto_mensual = _dataProvider.GetParameter();
                padreCosto_mensual.ParameterName = "Costo_mensual";
                padreCosto_mensual.DbType = DbType.Decimal;
                padreCosto_mensual.Value = (object)entity.Costo_mensual ?? DBNull.Value;

                var padrePrecio_Final = _dataProvider.GetParameter();
                padrePrecio_Final.ParameterName = "Precio_Final";
                padrePrecio_Final.DbType = DbType.Decimal;
                padrePrecio_Final.Value = (object)entity.Precio_Final ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPlanes_de_Suscripcion>("sp_InsPlanes_de_Suscripcion" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreTipo_de_Beneficiario
, padreNombre
, padreNombre_del_Plan
, padreDuracion_en_meses
, padreDuracion
, padreDietas_por_mes
, padreRutinas_por_mes
, padreCosto_mensual
, padrePrecio_Final
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

        public int Update(Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion entity)
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

                var paramUpdTipo_de_Beneficiario = _dataProvider.GetParameter();
                paramUpdTipo_de_Beneficiario.ParameterName = "Tipo_de_Beneficiario";
                paramUpdTipo_de_Beneficiario.DbType = DbType.Int32;
                paramUpdTipo_de_Beneficiario.Value = (object)entity.Tipo_de_Beneficiario ?? DBNull.Value;

                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdNombre_del_Plan = _dataProvider.GetParameter();
                paramUpdNombre_del_Plan.ParameterName = "Nombre_del_Plan";
                paramUpdNombre_del_Plan.DbType = DbType.String;
                paramUpdNombre_del_Plan.Value = (object)entity.Nombre_del_Plan ?? DBNull.Value;
                var paramUpdDuracion_en_meses = _dataProvider.GetParameter();
                paramUpdDuracion_en_meses.ParameterName = "Duracion_en_meses";
                paramUpdDuracion_en_meses.DbType = DbType.Int32;
                paramUpdDuracion_en_meses.Value = (object)entity.Duracion_en_meses ?? DBNull.Value;

                var paramUpdDuracion = _dataProvider.GetParameter();
                paramUpdDuracion.ParameterName = "Duracion";
                paramUpdDuracion.DbType = DbType.Int32;
                paramUpdDuracion.Value = (object)entity.Duracion ?? DBNull.Value;

                var paramUpdDietas_por_mes = _dataProvider.GetParameter();
                paramUpdDietas_por_mes.ParameterName = "Dietas_por_mes";
                paramUpdDietas_por_mes.DbType = DbType.Int32;
                paramUpdDietas_por_mes.Value = (object)entity.Dietas_por_mes ?? DBNull.Value;

                var paramUpdRutinas_por_mes = _dataProvider.GetParameter();
                paramUpdRutinas_por_mes.ParameterName = "Rutinas_por_mes";
                paramUpdRutinas_por_mes.DbType = DbType.Int32;
                paramUpdRutinas_por_mes.Value = (object)entity.Rutinas_por_mes ?? DBNull.Value;

                var paramUpdCosto_mensual = _dataProvider.GetParameter();
                paramUpdCosto_mensual.ParameterName = "Costo_mensual";
                paramUpdCosto_mensual.DbType = DbType.Decimal;
                paramUpdCosto_mensual.Value = (object)entity.Costo_mensual ?? DBNull.Value;

                var paramUpdPrecio_Final = _dataProvider.GetParameter();
                paramUpdPrecio_Final.ParameterName = "Precio_Final";
                paramUpdPrecio_Final.DbType = DbType.Decimal;
                paramUpdPrecio_Final.Value = (object)entity.Precio_Final ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlanes_de_Suscripcion>("sp_UpdPlanes_de_Suscripcion" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Beneficiario , paramUpdNombre , paramUpdNombre_del_Plan , paramUpdDuracion_en_meses , paramUpdDuracion , paramUpdDietas_por_mes , paramUpdRutinas_por_mes , paramUpdCosto_mensual , paramUpdPrecio_Final , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion Planes_de_SuscripcionDB = GetByKey(entity.Folio, false);
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
		var paramUpdTipo_de_Beneficiario = _dataProvider.GetParameter();
                paramUpdTipo_de_Beneficiario.ParameterName = "Tipo_de_Beneficiario";
                paramUpdTipo_de_Beneficiario.DbType = DbType.Int32;
                paramUpdTipo_de_Beneficiario.Value = (object)entity.Tipo_de_Beneficiario ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdNombre_del_Plan = _dataProvider.GetParameter();
                paramUpdNombre_del_Plan.ParameterName = "Nombre_del_Plan";
                paramUpdNombre_del_Plan.DbType = DbType.String;
                paramUpdNombre_del_Plan.Value = (object)entity.Nombre_del_Plan ?? DBNull.Value;
                var paramUpdDuracion_en_meses = _dataProvider.GetParameter();
                paramUpdDuracion_en_meses.ParameterName = "Duracion_en_meses";
                paramUpdDuracion_en_meses.DbType = DbType.Int32;
                paramUpdDuracion_en_meses.Value = (object)entity.Duracion_en_meses ?? DBNull.Value;
                var paramUpdDuracion = _dataProvider.GetParameter();
                paramUpdDuracion.ParameterName = "Duracion";
                paramUpdDuracion.DbType = DbType.Int32;
                paramUpdDuracion.Value = (object)entity.Duracion ?? DBNull.Value;
                var paramUpdDietas_por_mes = _dataProvider.GetParameter();
                paramUpdDietas_por_mes.ParameterName = "Dietas_por_mes";
                paramUpdDietas_por_mes.DbType = DbType.Int32;
                paramUpdDietas_por_mes.Value = (object)entity.Dietas_por_mes ?? DBNull.Value;
                var paramUpdRutinas_por_mes = _dataProvider.GetParameter();
                paramUpdRutinas_por_mes.ParameterName = "Rutinas_por_mes";
                paramUpdRutinas_por_mes.DbType = DbType.Int32;
                paramUpdRutinas_por_mes.Value = (object)entity.Rutinas_por_mes ?? DBNull.Value;
                var paramUpdCosto_mensual = _dataProvider.GetParameter();
                paramUpdCosto_mensual.ParameterName = "Costo_mensual";
                paramUpdCosto_mensual.DbType = DbType.Decimal;
                paramUpdCosto_mensual.Value = (object)entity.Costo_mensual ?? DBNull.Value;
                var paramUpdPrecio_Final = _dataProvider.GetParameter();
                paramUpdPrecio_Final.ParameterName = "Precio_Final";
                paramUpdPrecio_Final.DbType = DbType.Decimal;
                paramUpdPrecio_Final.Value = (object)entity.Precio_Final ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlanes_de_Suscripcion>("sp_UpdPlanes_de_Suscripcion" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Beneficiario , paramUpdNombre , paramUpdNombre_del_Plan , paramUpdDuracion_en_meses , paramUpdDuracion , paramUpdDietas_por_mes , paramUpdRutinas_por_mes , paramUpdCosto_mensual , paramUpdPrecio_Final , paramUpdEstatus ).FirstOrDefault();

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


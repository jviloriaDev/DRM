using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Codigos_Referidos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Codigos_Referidos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Codigos_ReferidosService : IDetalle_Codigos_ReferidosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> _Detalle_Codigos_ReferidosRepository;
        #endregion

        #region Ctor
        public Detalle_Codigos_ReferidosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> Detalle_Codigos_ReferidosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Codigos_ReferidosRepository = Detalle_Codigos_ReferidosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos>("sp_SelAllDetalle_Codigos_Referidos");
        }

        public IList<Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Codigos_Referidos_Complete>("sp_SelAllComplete_Detalle_Codigos_Referidos");
            return data.Select(m => new Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos
            {
                Folio = m.Folio
                ,Folio_Medicos = m.Folio_Medicos
                ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Suscripcion_Nombre_del_Plan }
                ,Porcentaje_de_descuento = m.Porcentaje_de_descuento
                ,Fecha_inicio_vigencia = m.Fecha_inicio_vigencia
                ,Fecha_fin_vigencia = m.Fecha_fin_vigencia
                ,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
                ,Codigo_para_Referenciados = m.Codigo_para_Referenciados
                ,Autorizado = m.Autorizado.GetValueOrDefault()
                ,Usuario_que_autoriza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_autoriza.GetValueOrDefault(), Name = m.Usuario_que_autoriza_Name }
                ,Fecha_de_autorizacion = m.Fecha_de_autorizacion
                ,Hora_de_autorizacion = m.Hora_de_autorizacion
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Codigos_Referidos>("sp_ListSelCount_Detalle_Codigos_Referidos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Codigos_Referidos>("sp_ListSelAll_Detalle_Codigos_Referidos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos
                {
                    Folio = m.Detalle_Codigos_Referidos_Folio,
                    Folio_Medicos = m.Detalle_Codigos_Referidos_Folio_Medicos,
                    Suscripcion = m.Detalle_Codigos_Referidos_Suscripcion,
                    Porcentaje_de_descuento = m.Detalle_Codigos_Referidos_Porcentaje_de_descuento,
                    Fecha_inicio_vigencia = m.Detalle_Codigos_Referidos_Fecha_inicio_vigencia,
                    Fecha_fin_vigencia = m.Detalle_Codigos_Referidos_Fecha_fin_vigencia,
                    Cantidad_maxima_de_referenciados = m.Detalle_Codigos_Referidos_Cantidad_maxima_de_referenciados,
                    Codigo_para_Referenciados = m.Detalle_Codigos_Referidos_Codigo_para_Referenciados,
                    Autorizado = m.Detalle_Codigos_Referidos_Autorizado ?? false,
                    Usuario_que_autoriza = m.Detalle_Codigos_Referidos_Usuario_que_autoriza,
                    Fecha_de_autorizacion = m.Detalle_Codigos_Referidos_Fecha_de_autorizacion,
                    Hora_de_autorizacion = m.Detalle_Codigos_Referidos_Hora_de_autorizacion,
                    Estatus = m.Detalle_Codigos_Referidos_Estatus,

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

        public IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_ReferidosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Codigos_Referidos>("sp_ListSelAll_Detalle_Codigos_Referidos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Codigos_ReferidosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Codigos_ReferidosPagingModel
                {
                    Detalle_Codigos_Referidoss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos
                {
                    Folio = m.Detalle_Codigos_Referidos_Folio
                    ,Folio_Medicos = m.Detalle_Codigos_Referidos_Folio_Medicos
                    ,Suscripcion = m.Detalle_Codigos_Referidos_Suscripcion
                    ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Detalle_Codigos_Referidos_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Detalle_Codigos_Referidos_Suscripcion_Nombre_del_Plan }
                    ,Porcentaje_de_descuento = m.Detalle_Codigos_Referidos_Porcentaje_de_descuento
                    ,Fecha_inicio_vigencia = m.Detalle_Codigos_Referidos_Fecha_inicio_vigencia
                    ,Fecha_fin_vigencia = m.Detalle_Codigos_Referidos_Fecha_fin_vigencia
                    ,Cantidad_maxima_de_referenciados = m.Detalle_Codigos_Referidos_Cantidad_maxima_de_referenciados
                    ,Codigo_para_Referenciados = m.Detalle_Codigos_Referidos_Codigo_para_Referenciados
                    ,Autorizado = m.Detalle_Codigos_Referidos_Autorizado ?? false
                    ,Usuario_que_autoriza = m.Detalle_Codigos_Referidos_Usuario_que_autoriza
                    ,Usuario_que_autoriza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Detalle_Codigos_Referidos_Usuario_que_autoriza.GetValueOrDefault(), Name = m.Detalle_Codigos_Referidos_Usuario_que_autoriza_Name }
                    ,Fecha_de_autorizacion = m.Detalle_Codigos_Referidos_Fecha_de_autorizacion
                    ,Hora_de_autorizacion = m.Detalle_Codigos_Referidos_Hora_de_autorizacion
                    ,Estatus = m.Detalle_Codigos_Referidos_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Detalle_Codigos_Referidos_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Codigos_Referidos_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos>("sp_GetDetalle_Codigos_Referidos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Codigos_Referidos>("sp_DelDetalle_Codigos_Referidos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Medicos = _dataProvider.GetParameter();
                padreFolio_Medicos.ParameterName = "Folio_Medicos";
                padreFolio_Medicos.DbType = DbType.Int32;
                padreFolio_Medicos.Value = (object)entity.Folio_Medicos ?? DBNull.Value;
                var padreSuscripcion = _dataProvider.GetParameter();
                padreSuscripcion.ParameterName = "Suscripcion";
                padreSuscripcion.DbType = DbType.Int32;
                padreSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var padrePorcentaje_de_descuento = _dataProvider.GetParameter();
                padrePorcentaje_de_descuento.ParameterName = "Porcentaje_de_descuento";
                padrePorcentaje_de_descuento.DbType = DbType.Int32;
                padrePorcentaje_de_descuento.Value = (object)entity.Porcentaje_de_descuento ?? DBNull.Value;

                var padreFecha_inicio_vigencia = _dataProvider.GetParameter();
                padreFecha_inicio_vigencia.ParameterName = "Fecha_inicio_vigencia";
                padreFecha_inicio_vigencia.DbType = DbType.DateTime;
                padreFecha_inicio_vigencia.Value = (object)entity.Fecha_inicio_vigencia ?? DBNull.Value;

                var padreFecha_fin_vigencia = _dataProvider.GetParameter();
                padreFecha_fin_vigencia.ParameterName = "Fecha_fin_vigencia";
                padreFecha_fin_vigencia.DbType = DbType.DateTime;
                padreFecha_fin_vigencia.Value = (object)entity.Fecha_fin_vigencia ?? DBNull.Value;

                var padreCantidad_maxima_de_referenciados = _dataProvider.GetParameter();
                padreCantidad_maxima_de_referenciados.ParameterName = "Cantidad_maxima_de_referenciados";
                padreCantidad_maxima_de_referenciados.DbType = DbType.Int32;
                padreCantidad_maxima_de_referenciados.Value = (object)entity.Cantidad_maxima_de_referenciados ?? DBNull.Value;

                var padreCodigo_para_Referenciados = _dataProvider.GetParameter();
                padreCodigo_para_Referenciados.ParameterName = "Codigo_para_Referenciados";
                padreCodigo_para_Referenciados.DbType = DbType.String;
                padreCodigo_para_Referenciados.Value = (object)entity.Codigo_para_Referenciados ?? DBNull.Value;
                var padreAutorizado = _dataProvider.GetParameter();
                padreAutorizado.ParameterName = "Autorizado";
                padreAutorizado.DbType = DbType.Boolean;
                padreAutorizado.Value = (object)entity.Autorizado ?? DBNull.Value;
                var padreUsuario_que_autoriza = _dataProvider.GetParameter();
                padreUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                padreUsuario_que_autoriza.DbType = DbType.Int32;
                padreUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;

                var padreFecha_de_autorizacion = _dataProvider.GetParameter();
                padreFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                padreFecha_de_autorizacion.DbType = DbType.DateTime;
                padreFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;

                var padreHora_de_autorizacion = _dataProvider.GetParameter();
                padreHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                padreHora_de_autorizacion.DbType = DbType.String;
                padreHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Codigos_Referidos>("sp_InsDetalle_Codigos_Referidos" , padreFolio_Medicos
, padreSuscripcion
, padrePorcentaje_de_descuento
, padreFecha_inicio_vigencia
, padreFecha_fin_vigencia
, padreCantidad_maxima_de_referenciados
, padreCodigo_para_Referenciados
, padreAutorizado
, padreUsuario_que_autoriza
, padreFecha_de_autorizacion
, padreHora_de_autorizacion
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

        public int Update(Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Medicos = _dataProvider.GetParameter();
                paramUpdFolio_Medicos.ParameterName = "Folio_Medicos";
                paramUpdFolio_Medicos.DbType = DbType.Int32;
                paramUpdFolio_Medicos.Value = (object)entity.Folio_Medicos ?? DBNull.Value;
                var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var paramUpdPorcentaje_de_descuento = _dataProvider.GetParameter();
                paramUpdPorcentaje_de_descuento.ParameterName = "Porcentaje_de_descuento";
                paramUpdPorcentaje_de_descuento.DbType = DbType.Int32;
                paramUpdPorcentaje_de_descuento.Value = (object)entity.Porcentaje_de_descuento ?? DBNull.Value;

                var paramUpdFecha_inicio_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_inicio_vigencia.ParameterName = "Fecha_inicio_vigencia";
                paramUpdFecha_inicio_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_inicio_vigencia.Value = (object)entity.Fecha_inicio_vigencia ?? DBNull.Value;

                var paramUpdFecha_fin_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_fin_vigencia.ParameterName = "Fecha_fin_vigencia";
                paramUpdFecha_fin_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_fin_vigencia.Value = (object)entity.Fecha_fin_vigencia ?? DBNull.Value;

                var paramUpdCantidad_maxima_de_referenciados = _dataProvider.GetParameter();
                paramUpdCantidad_maxima_de_referenciados.ParameterName = "Cantidad_maxima_de_referenciados";
                paramUpdCantidad_maxima_de_referenciados.DbType = DbType.Int32;
                paramUpdCantidad_maxima_de_referenciados.Value = (object)entity.Cantidad_maxima_de_referenciados ?? DBNull.Value;

                var paramUpdCodigo_para_Referenciados = _dataProvider.GetParameter();
                paramUpdCodigo_para_Referenciados.ParameterName = "Codigo_para_Referenciados";
                paramUpdCodigo_para_Referenciados.DbType = DbType.String;
                paramUpdCodigo_para_Referenciados.Value = (object)entity.Codigo_para_Referenciados ?? DBNull.Value;
                var paramUpdAutorizado = _dataProvider.GetParameter();
                paramUpdAutorizado.ParameterName = "Autorizado";
                paramUpdAutorizado.DbType = DbType.Boolean;
                paramUpdAutorizado.Value = (object)entity.Autorizado ?? DBNull.Value;
                var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;

                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;

                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Codigos_Referidos>("sp_UpdDetalle_Codigos_Referidos" , paramUpdFolio , paramUpdFolio_Medicos , paramUpdSuscripcion , paramUpdPorcentaje_de_descuento , paramUpdFecha_inicio_vigencia , paramUpdFecha_fin_vigencia , paramUpdCantidad_maxima_de_referenciados , paramUpdCodigo_para_Referenciados , paramUpdAutorizado , paramUpdUsuario_que_autoriza , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos Detalle_Codigos_ReferidosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Medicos = _dataProvider.GetParameter();
                paramUpdFolio_Medicos.ParameterName = "Folio_Medicos";
                paramUpdFolio_Medicos.DbType = DbType.Int32;
                paramUpdFolio_Medicos.Value = (object)entity.Folio_Medicos ?? DBNull.Value;
		var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;
                var paramUpdPorcentaje_de_descuento = _dataProvider.GetParameter();
                paramUpdPorcentaje_de_descuento.ParameterName = "Porcentaje_de_descuento";
                paramUpdPorcentaje_de_descuento.DbType = DbType.Int32;
                paramUpdPorcentaje_de_descuento.Value = (object)entity.Porcentaje_de_descuento ?? DBNull.Value;
                var paramUpdFecha_inicio_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_inicio_vigencia.ParameterName = "Fecha_inicio_vigencia";
                paramUpdFecha_inicio_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_inicio_vigencia.Value = (object)entity.Fecha_inicio_vigencia ?? DBNull.Value;
                var paramUpdFecha_fin_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_fin_vigencia.ParameterName = "Fecha_fin_vigencia";
                paramUpdFecha_fin_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_fin_vigencia.Value = (object)entity.Fecha_fin_vigencia ?? DBNull.Value;
                var paramUpdCantidad_maxima_de_referenciados = _dataProvider.GetParameter();
                paramUpdCantidad_maxima_de_referenciados.ParameterName = "Cantidad_maxima_de_referenciados";
                paramUpdCantidad_maxima_de_referenciados.DbType = DbType.Int32;
                paramUpdCantidad_maxima_de_referenciados.Value = (object)entity.Cantidad_maxima_de_referenciados ?? DBNull.Value;
                var paramUpdCodigo_para_Referenciados = _dataProvider.GetParameter();
                paramUpdCodigo_para_Referenciados.ParameterName = "Codigo_para_Referenciados";
                paramUpdCodigo_para_Referenciados.DbType = DbType.String;
                paramUpdCodigo_para_Referenciados.Value = (object)entity.Codigo_para_Referenciados ?? DBNull.Value;
                var paramUpdAutorizado = _dataProvider.GetParameter();
                paramUpdAutorizado.ParameterName = "Autorizado";
                paramUpdAutorizado.DbType = DbType.Boolean;
                paramUpdAutorizado.Value = (object)entity.Autorizado ?? DBNull.Value;
		var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Codigos_Referidos>("sp_UpdDetalle_Codigos_Referidos" , paramUpdFolio , paramUpdFolio_Medicos , paramUpdSuscripcion , paramUpdPorcentaje_de_descuento , paramUpdFecha_inicio_vigencia , paramUpdFecha_fin_vigencia , paramUpdCantidad_maxima_de_referenciados , paramUpdCodigo_para_Referenciados , paramUpdAutorizado , paramUpdUsuario_que_autoriza , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdEstatus ).FirstOrDefault();

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


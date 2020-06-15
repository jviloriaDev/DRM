using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Suscripciones_Empresa;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Suscripciones_Empresa
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Suscripciones_EmpresaService : IDetalle_Suscripciones_EmpresaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> _Detalle_Suscripciones_EmpresaRepository;
        #endregion

        #region Ctor
        public Detalle_Suscripciones_EmpresaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> Detalle_Suscripciones_EmpresaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Suscripciones_EmpresaRepository = Detalle_Suscripciones_EmpresaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Suscripciones_EmpresaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>("sp_SelAllDetalle_Suscripciones_Empresa");
        }

        public IList<Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Suscripciones_Empresa_Complete>("sp_SelAllComplete_Detalle_Suscripciones_Empresa");
            return data.Select(m => new Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa
            {
                Folio = m.Folio
                ,Folio_Empresas = m.Folio_Empresas
                ,Cantidad_de_Beneficiarios = m.Cantidad_de_Beneficiarios
                ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Suscripcion_Nombre_del_Plan }
                ,Fecha_de_inicio = m.Fecha_de_inicio
                ,Fecha_Fin = m.Fecha_Fin
                ,Nombre_de_la_Suscripcion = m.Nombre_de_la_Suscripcion
                ,Frecuencia_de_Pago_Frecuencia_de_pago_Empresas = new Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas() { Clave = m.Frecuencia_de_Pago.GetValueOrDefault(), Nombre = m.Frecuencia_de_Pago_Nombre }
                ,Costo = m.Costo
                ,Estatus_Estatus_de_Suscripcion = new Core.Classes.Estatus_de_Suscripcion.Estatus_de_Suscripcion() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Suscripciones_Empresa>("sp_ListSelCount_Detalle_Suscripciones_Empresa", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Suscripciones_Empresa>("sp_ListSelAll_Detalle_Suscripciones_Empresa", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa
                {
                    Folio = m.Detalle_Suscripciones_Empresa_Folio,
                    Folio_Empresas = m.Detalle_Suscripciones_Empresa_Folio_Empresas,
                    Cantidad_de_Beneficiarios = m.Detalle_Suscripciones_Empresa_Cantidad_de_Beneficiarios,
                    Suscripcion = m.Detalle_Suscripciones_Empresa_Suscripcion,
                    Fecha_de_inicio = m.Detalle_Suscripciones_Empresa_Fecha_de_inicio,
                    Fecha_Fin = m.Detalle_Suscripciones_Empresa_Fecha_Fin,
                    Nombre_de_la_Suscripcion = m.Detalle_Suscripciones_Empresa_Nombre_de_la_Suscripcion,
                    Frecuencia_de_Pago = m.Detalle_Suscripciones_Empresa_Frecuencia_de_Pago,
                    Costo = m.Detalle_Suscripciones_Empresa_Costo,
                    Estatus = m.Detalle_Suscripciones_Empresa_Estatus,

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

        public IList<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Suscripciones_EmpresaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Suscripciones_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Suscripciones_Empresa>("sp_ListSelAll_Detalle_Suscripciones_Empresa", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Suscripciones_EmpresaPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Suscripciones_EmpresaPagingModel
                {
                    Detalle_Suscripciones_Empresas =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa
                {
                    Folio = m.Detalle_Suscripciones_Empresa_Folio
                    ,Folio_Empresas = m.Detalle_Suscripciones_Empresa_Folio_Empresas
                    ,Cantidad_de_Beneficiarios = m.Detalle_Suscripciones_Empresa_Cantidad_de_Beneficiarios
                    ,Suscripcion = m.Detalle_Suscripciones_Empresa_Suscripcion
                    ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Detalle_Suscripciones_Empresa_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Detalle_Suscripciones_Empresa_Suscripcion_Nombre_del_Plan }
                    ,Fecha_de_inicio = m.Detalle_Suscripciones_Empresa_Fecha_de_inicio
                    ,Fecha_Fin = m.Detalle_Suscripciones_Empresa_Fecha_Fin
                    ,Nombre_de_la_Suscripcion = m.Detalle_Suscripciones_Empresa_Nombre_de_la_Suscripcion
                    ,Frecuencia_de_Pago = m.Detalle_Suscripciones_Empresa_Frecuencia_de_Pago
                    ,Frecuencia_de_Pago_Frecuencia_de_pago_Empresas = new Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas() { Clave = m.Detalle_Suscripciones_Empresa_Frecuencia_de_Pago.GetValueOrDefault(), Nombre = m.Detalle_Suscripciones_Empresa_Frecuencia_de_Pago_Nombre }
                    ,Costo = m.Detalle_Suscripciones_Empresa_Costo
                    ,Estatus = m.Detalle_Suscripciones_Empresa_Estatus
                    ,Estatus_Estatus_de_Suscripcion = new Core.Classes.Estatus_de_Suscripcion.Estatus_de_Suscripcion() { Clave = m.Detalle_Suscripciones_Empresa_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Suscripciones_Empresa_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Suscripciones_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>("sp_GetDetalle_Suscripciones_Empresa", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Suscripciones_Empresa>("sp_DelDetalle_Suscripciones_Empresa", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Empresas = _dataProvider.GetParameter();
                padreFolio_Empresas.ParameterName = "Folio_Empresas";
                padreFolio_Empresas.DbType = DbType.Int32;
                padreFolio_Empresas.Value = (object)entity.Folio_Empresas ?? DBNull.Value;
                var padreCantidad_de_Beneficiarios = _dataProvider.GetParameter();
                padreCantidad_de_Beneficiarios.ParameterName = "Cantidad_de_Beneficiarios";
                padreCantidad_de_Beneficiarios.DbType = DbType.Int32;
                padreCantidad_de_Beneficiarios.Value = (object)entity.Cantidad_de_Beneficiarios ?? DBNull.Value;

                var padreSuscripcion = _dataProvider.GetParameter();
                padreSuscripcion.ParameterName = "Suscripcion";
                padreSuscripcion.DbType = DbType.Int32;
                padreSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var padreFecha_de_inicio = _dataProvider.GetParameter();
                padreFecha_de_inicio.ParameterName = "Fecha_de_inicio";
                padreFecha_de_inicio.DbType = DbType.DateTime;
                padreFecha_de_inicio.Value = (object)entity.Fecha_de_inicio ?? DBNull.Value;

                var padreFecha_Fin = _dataProvider.GetParameter();
                padreFecha_Fin.ParameterName = "Fecha_Fin";
                padreFecha_Fin.DbType = DbType.DateTime;
                padreFecha_Fin.Value = (object)entity.Fecha_Fin ?? DBNull.Value;

                var padreNombre_de_la_Suscripcion = _dataProvider.GetParameter();
                padreNombre_de_la_Suscripcion.ParameterName = "Nombre_de_la_Suscripcion";
                padreNombre_de_la_Suscripcion.DbType = DbType.String;
                padreNombre_de_la_Suscripcion.Value = (object)entity.Nombre_de_la_Suscripcion ?? DBNull.Value;
                var padreFrecuencia_de_Pago = _dataProvider.GetParameter();
                padreFrecuencia_de_Pago.ParameterName = "Frecuencia_de_Pago";
                padreFrecuencia_de_Pago.DbType = DbType.Int32;
                padreFrecuencia_de_Pago.Value = (object)entity.Frecuencia_de_Pago ?? DBNull.Value;

                var padreCosto = _dataProvider.GetParameter();
                padreCosto.ParameterName = "Costo";
                padreCosto.DbType = DbType.Decimal;
                padreCosto.Value = (object)entity.Costo ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Suscripciones_Empresa>("sp_InsDetalle_Suscripciones_Empresa" , padreFolio_Empresas
, padreCantidad_de_Beneficiarios
, padreSuscripcion
, padreFecha_de_inicio
, padreFecha_Fin
, padreNombre_de_la_Suscripcion
, padreFrecuencia_de_Pago
, padreCosto
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

        public int Update(Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Empresas = _dataProvider.GetParameter();
                paramUpdFolio_Empresas.ParameterName = "Folio_Empresas";
                paramUpdFolio_Empresas.DbType = DbType.Int32;
                paramUpdFolio_Empresas.Value = (object)entity.Folio_Empresas ?? DBNull.Value;
                var paramUpdCantidad_de_Beneficiarios = _dataProvider.GetParameter();
                paramUpdCantidad_de_Beneficiarios.ParameterName = "Cantidad_de_Beneficiarios";
                paramUpdCantidad_de_Beneficiarios.DbType = DbType.Int32;
                paramUpdCantidad_de_Beneficiarios.Value = (object)entity.Cantidad_de_Beneficiarios ?? DBNull.Value;

                var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var paramUpdFecha_de_inicio = _dataProvider.GetParameter();
                paramUpdFecha_de_inicio.ParameterName = "Fecha_de_inicio";
                paramUpdFecha_de_inicio.DbType = DbType.DateTime;
                paramUpdFecha_de_inicio.Value = (object)entity.Fecha_de_inicio ?? DBNull.Value;

                var paramUpdFecha_Fin = _dataProvider.GetParameter();
                paramUpdFecha_Fin.ParameterName = "Fecha_Fin";
                paramUpdFecha_Fin.DbType = DbType.DateTime;
                paramUpdFecha_Fin.Value = (object)entity.Fecha_Fin ?? DBNull.Value;

                var paramUpdNombre_de_la_Suscripcion = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Suscripcion.ParameterName = "Nombre_de_la_Suscripcion";
                paramUpdNombre_de_la_Suscripcion.DbType = DbType.String;
                paramUpdNombre_de_la_Suscripcion.Value = (object)entity.Nombre_de_la_Suscripcion ?? DBNull.Value;
                var paramUpdFrecuencia_de_Pago = _dataProvider.GetParameter();
                paramUpdFrecuencia_de_Pago.ParameterName = "Frecuencia_de_Pago";
                paramUpdFrecuencia_de_Pago.DbType = DbType.Int32;
                paramUpdFrecuencia_de_Pago.Value = (object)entity.Frecuencia_de_Pago ?? DBNull.Value;

                var paramUpdCosto = _dataProvider.GetParameter();
                paramUpdCosto.ParameterName = "Costo";
                paramUpdCosto.DbType = DbType.Decimal;
                paramUpdCosto.Value = (object)entity.Costo ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Suscripciones_Empresa>("sp_UpdDetalle_Suscripciones_Empresa" , paramUpdFolio , paramUpdFolio_Empresas , paramUpdCantidad_de_Beneficiarios , paramUpdSuscripcion , paramUpdFecha_de_inicio , paramUpdFecha_Fin , paramUpdNombre_de_la_Suscripcion , paramUpdFrecuencia_de_Pago , paramUpdCosto , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa Detalle_Suscripciones_EmpresaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Empresas = _dataProvider.GetParameter();
                paramUpdFolio_Empresas.ParameterName = "Folio_Empresas";
                paramUpdFolio_Empresas.DbType = DbType.Int32;
                paramUpdFolio_Empresas.Value = (object)entity.Folio_Empresas ?? DBNull.Value;
                var paramUpdCantidad_de_Beneficiarios = _dataProvider.GetParameter();
                paramUpdCantidad_de_Beneficiarios.ParameterName = "Cantidad_de_Beneficiarios";
                paramUpdCantidad_de_Beneficiarios.DbType = DbType.Int32;
                paramUpdCantidad_de_Beneficiarios.Value = (object)entity.Cantidad_de_Beneficiarios ?? DBNull.Value;
		var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;
                var paramUpdFecha_de_inicio = _dataProvider.GetParameter();
                paramUpdFecha_de_inicio.ParameterName = "Fecha_de_inicio";
                paramUpdFecha_de_inicio.DbType = DbType.DateTime;
                paramUpdFecha_de_inicio.Value = (object)entity.Fecha_de_inicio ?? DBNull.Value;
                var paramUpdFecha_Fin = _dataProvider.GetParameter();
                paramUpdFecha_Fin.ParameterName = "Fecha_Fin";
                paramUpdFecha_Fin.DbType = DbType.DateTime;
                paramUpdFecha_Fin.Value = (object)entity.Fecha_Fin ?? DBNull.Value;
                var paramUpdNombre_de_la_Suscripcion = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Suscripcion.ParameterName = "Nombre_de_la_Suscripcion";
                paramUpdNombre_de_la_Suscripcion.DbType = DbType.String;
                paramUpdNombre_de_la_Suscripcion.Value = (object)entity.Nombre_de_la_Suscripcion ?? DBNull.Value;
		var paramUpdFrecuencia_de_Pago = _dataProvider.GetParameter();
                paramUpdFrecuencia_de_Pago.ParameterName = "Frecuencia_de_Pago";
                paramUpdFrecuencia_de_Pago.DbType = DbType.Int32;
                paramUpdFrecuencia_de_Pago.Value = (object)entity.Frecuencia_de_Pago ?? DBNull.Value;
                var paramUpdCosto = _dataProvider.GetParameter();
                paramUpdCosto.ParameterName = "Costo";
                paramUpdCosto.DbType = DbType.Decimal;
                paramUpdCosto.Value = (object)entity.Costo ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Suscripciones_Empresa>("sp_UpdDetalle_Suscripciones_Empresa" , paramUpdFolio , paramUpdFolio_Empresas , paramUpdCantidad_de_Beneficiarios , paramUpdSuscripcion , paramUpdFecha_de_inicio , paramUpdFecha_Fin , paramUpdNombre_de_la_Suscripcion , paramUpdFrecuencia_de_Pago , paramUpdCosto , paramUpdEstatus ).FirstOrDefault();

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


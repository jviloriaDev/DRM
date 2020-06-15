using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Planes_de_Suscripcion_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Planes_de_Suscripcion_EspecialistasService : IDetalle_Planes_de_Suscripcion_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> _Detalle_Planes_de_Suscripcion_EspecialistasRepository;
        #endregion

        #region Ctor
        public Detalle_Planes_de_Suscripcion_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> Detalle_Planes_de_Suscripcion_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Planes_de_Suscripcion_EspecialistasRepository = Detalle_Planes_de_Suscripcion_EspecialistasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Planes_de_Suscripcion_EspecialistasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>("sp_SelAllDetalle_Planes_de_Suscripcion_Especialistas");
        }

        public IList<Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Planes_de_Suscripcion_Especialistas_Complete>("sp_SelAllComplete_Detalle_Planes_de_Suscripcion_Especialistas");
            return data.Select(m => new Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas
            {
                Folio = m.Folio
                ,Folio_Especialistas = m.Folio_Especialistas
                ,Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas = new Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas() { Folio = m.Plan_de_Suscripcion.GetValueOrDefault(), Nombre = m.Plan_de_Suscripcion_Nombre }
                ,Fecha_de_inicio = m.Fecha_de_inicio
                ,Fecha_fin = m.Fecha_fin
                ,Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas = new Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas() { Clave = m.Frecuencia_de_Pago.GetValueOrDefault(), Nombre = m.Frecuencia_de_Pago_Nombre }
                ,Costo = m.Costo
                ,Contrato = m.Contrato
                ,Firmo_Contrato = m.Firmo_Contrato.GetValueOrDefault()
                ,Estatus_Estatus_de_Suscripcion = new Core.Classes.Estatus_de_Suscripcion.Estatus_de_Suscripcion() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Planes_de_Suscripcion_Especialistas>("sp_ListSelCount_Detalle_Planes_de_Suscripcion_Especialistas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Planes_de_Suscripcion_Especialistas>("sp_ListSelAll_Detalle_Planes_de_Suscripcion_Especialistas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas
                {
                    Folio = m.Detalle_Planes_de_Suscripcion_Especialistas_Folio,
                    Folio_Especialistas = m.Detalle_Planes_de_Suscripcion_Especialistas_Folio_Especialistas,
                    Plan_de_Suscripcion = m.Detalle_Planes_de_Suscripcion_Especialistas_Plan_de_Suscripcion,
                    Fecha_de_inicio = m.Detalle_Planes_de_Suscripcion_Especialistas_Fecha_de_inicio,
                    Fecha_fin = m.Detalle_Planes_de_Suscripcion_Especialistas_Fecha_fin,
                    Frecuencia_de_Pago = m.Detalle_Planes_de_Suscripcion_Especialistas_Frecuencia_de_Pago,
                    Costo = m.Detalle_Planes_de_Suscripcion_Especialistas_Costo,
                    Contrato = m.Detalle_Planes_de_Suscripcion_Especialistas_Contrato,
                    Firmo_Contrato = m.Detalle_Planes_de_Suscripcion_Especialistas_Firmo_Contrato ?? false,
                    Estatus = m.Detalle_Planes_de_Suscripcion_Especialistas_Estatus,

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

        public IList<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Planes_de_Suscripcion_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Planes_de_Suscripcion_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Planes_de_Suscripcion_Especialistas>("sp_ListSelAll_Detalle_Planes_de_Suscripcion_Especialistas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Planes_de_Suscripcion_EspecialistasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Planes_de_Suscripcion_EspecialistasPagingModel
                {
                    Detalle_Planes_de_Suscripcion_Especialistass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas
                {
                    Folio = m.Detalle_Planes_de_Suscripcion_Especialistas_Folio
                    ,Folio_Especialistas = m.Detalle_Planes_de_Suscripcion_Especialistas_Folio_Especialistas
                    ,Plan_de_Suscripcion = m.Detalle_Planes_de_Suscripcion_Especialistas_Plan_de_Suscripcion
                    ,Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas = new Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas() { Folio = m.Detalle_Planes_de_Suscripcion_Especialistas_Plan_de_Suscripcion.GetValueOrDefault(), Nombre = m.Detalle_Planes_de_Suscripcion_Especialistas_Plan_de_Suscripcion_Nombre }
                    ,Fecha_de_inicio = m.Detalle_Planes_de_Suscripcion_Especialistas_Fecha_de_inicio
                    ,Fecha_fin = m.Detalle_Planes_de_Suscripcion_Especialistas_Fecha_fin
                    ,Frecuencia_de_Pago = m.Detalle_Planes_de_Suscripcion_Especialistas_Frecuencia_de_Pago
                    ,Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas = new Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas() { Clave = m.Detalle_Planes_de_Suscripcion_Especialistas_Frecuencia_de_Pago.GetValueOrDefault(), Nombre = m.Detalle_Planes_de_Suscripcion_Especialistas_Frecuencia_de_Pago_Nombre }
                    ,Costo = m.Detalle_Planes_de_Suscripcion_Especialistas_Costo
                    ,Contrato = m.Detalle_Planes_de_Suscripcion_Especialistas_Contrato
                    ,Firmo_Contrato = m.Detalle_Planes_de_Suscripcion_Especialistas_Firmo_Contrato ?? false
                    ,Estatus = m.Detalle_Planes_de_Suscripcion_Especialistas_Estatus
                    ,Estatus_Estatus_de_Suscripcion = new Core.Classes.Estatus_de_Suscripcion.Estatus_de_Suscripcion() { Clave = m.Detalle_Planes_de_Suscripcion_Especialistas_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Planes_de_Suscripcion_Especialistas_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Planes_de_Suscripcion_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>("sp_GetDetalle_Planes_de_Suscripcion_Especialistas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Planes_de_Suscripcion_Especialistas>("sp_DelDetalle_Planes_de_Suscripcion_Especialistas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Especialistas = _dataProvider.GetParameter();
                padreFolio_Especialistas.ParameterName = "Folio_Especialistas";
                padreFolio_Especialistas.DbType = DbType.Int32;
                padreFolio_Especialistas.Value = (object)entity.Folio_Especialistas ?? DBNull.Value;
                var padrePlan_de_Suscripcion = _dataProvider.GetParameter();
                padrePlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                padrePlan_de_Suscripcion.DbType = DbType.Int32;
                padrePlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;

                var padreFecha_de_inicio = _dataProvider.GetParameter();
                padreFecha_de_inicio.ParameterName = "Fecha_de_inicio";
                padreFecha_de_inicio.DbType = DbType.DateTime;
                padreFecha_de_inicio.Value = (object)entity.Fecha_de_inicio ?? DBNull.Value;

                var padreFecha_fin = _dataProvider.GetParameter();
                padreFecha_fin.ParameterName = "Fecha_fin";
                padreFecha_fin.DbType = DbType.DateTime;
                padreFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;

                var padreFrecuencia_de_Pago = _dataProvider.GetParameter();
                padreFrecuencia_de_Pago.ParameterName = "Frecuencia_de_Pago";
                padreFrecuencia_de_Pago.DbType = DbType.Int32;
                padreFrecuencia_de_Pago.Value = (object)entity.Frecuencia_de_Pago ?? DBNull.Value;

                var padreCosto = _dataProvider.GetParameter();
                padreCosto.ParameterName = "Costo";
                padreCosto.DbType = DbType.Decimal;
                padreCosto.Value = (object)entity.Costo ?? DBNull.Value;

                var padreContrato = _dataProvider.GetParameter();
                padreContrato.ParameterName = "Contrato";
                padreContrato.DbType = DbType.Int32;
                padreContrato.Value = (object)entity.Contrato ?? DBNull.Value;

                var padreFirmo_Contrato = _dataProvider.GetParameter();
                padreFirmo_Contrato.ParameterName = "Firmo_Contrato";
                padreFirmo_Contrato.DbType = DbType.Boolean;
                padreFirmo_Contrato.Value = (object)entity.Firmo_Contrato ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Planes_de_Suscripcion_Especialistas>("sp_InsDetalle_Planes_de_Suscripcion_Especialistas" , padreFolio_Especialistas
, padrePlan_de_Suscripcion
, padreFecha_de_inicio
, padreFecha_fin
, padreFrecuencia_de_Pago
, padreCosto
, padreContrato
, padreFirmo_Contrato
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

        public int Update(Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Especialistas = _dataProvider.GetParameter();
                paramUpdFolio_Especialistas.ParameterName = "Folio_Especialistas";
                paramUpdFolio_Especialistas.DbType = DbType.Int32;
                paramUpdFolio_Especialistas.Value = (object)entity.Folio_Especialistas ?? DBNull.Value;
                var paramUpdPlan_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdPlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                paramUpdPlan_de_Suscripcion.DbType = DbType.Int32;
                paramUpdPlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;

                var paramUpdFecha_de_inicio = _dataProvider.GetParameter();
                paramUpdFecha_de_inicio.ParameterName = "Fecha_de_inicio";
                paramUpdFecha_de_inicio.DbType = DbType.DateTime;
                paramUpdFecha_de_inicio.Value = (object)entity.Fecha_de_inicio ?? DBNull.Value;

                var paramUpdFecha_fin = _dataProvider.GetParameter();
                paramUpdFecha_fin.ParameterName = "Fecha_fin";
                paramUpdFecha_fin.DbType = DbType.DateTime;
                paramUpdFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;

                var paramUpdFrecuencia_de_Pago = _dataProvider.GetParameter();
                paramUpdFrecuencia_de_Pago.ParameterName = "Frecuencia_de_Pago";
                paramUpdFrecuencia_de_Pago.DbType = DbType.Int32;
                paramUpdFrecuencia_de_Pago.Value = (object)entity.Frecuencia_de_Pago ?? DBNull.Value;

                var paramUpdCosto = _dataProvider.GetParameter();
                paramUpdCosto.ParameterName = "Costo";
                paramUpdCosto.DbType = DbType.Decimal;
                paramUpdCosto.Value = (object)entity.Costo ?? DBNull.Value;

                var paramUpdContrato = _dataProvider.GetParameter();
                paramUpdContrato.ParameterName = "Contrato";
                paramUpdContrato.DbType = DbType.Int32;
                paramUpdContrato.Value = (object)entity.Contrato ?? DBNull.Value;

                var paramUpdFirmo_Contrato = _dataProvider.GetParameter();
                paramUpdFirmo_Contrato.ParameterName = "Firmo_Contrato";
                paramUpdFirmo_Contrato.DbType = DbType.Boolean;
                paramUpdFirmo_Contrato.Value = (object)entity.Firmo_Contrato ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Planes_de_Suscripcion_Especialistas>("sp_UpdDetalle_Planes_de_Suscripcion_Especialistas" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdPlan_de_Suscripcion , paramUpdFecha_de_inicio , paramUpdFecha_fin , paramUpdFrecuencia_de_Pago , paramUpdCosto , paramUpdContrato , paramUpdFirmo_Contrato , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas Detalle_Planes_de_Suscripcion_EspecialistasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Especialistas = _dataProvider.GetParameter();
                paramUpdFolio_Especialistas.ParameterName = "Folio_Especialistas";
                paramUpdFolio_Especialistas.DbType = DbType.Int32;
                paramUpdFolio_Especialistas.Value = (object)entity.Folio_Especialistas ?? DBNull.Value;
		var paramUpdPlan_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdPlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                paramUpdPlan_de_Suscripcion.DbType = DbType.Int32;
                paramUpdPlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;
                var paramUpdFecha_de_inicio = _dataProvider.GetParameter();
                paramUpdFecha_de_inicio.ParameterName = "Fecha_de_inicio";
                paramUpdFecha_de_inicio.DbType = DbType.DateTime;
                paramUpdFecha_de_inicio.Value = (object)entity.Fecha_de_inicio ?? DBNull.Value;
                var paramUpdFecha_fin = _dataProvider.GetParameter();
                paramUpdFecha_fin.ParameterName = "Fecha_fin";
                paramUpdFecha_fin.DbType = DbType.DateTime;
                paramUpdFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;
		var paramUpdFrecuencia_de_Pago = _dataProvider.GetParameter();
                paramUpdFrecuencia_de_Pago.ParameterName = "Frecuencia_de_Pago";
                paramUpdFrecuencia_de_Pago.DbType = DbType.Int32;
                paramUpdFrecuencia_de_Pago.Value = (object)entity.Frecuencia_de_Pago ?? DBNull.Value;
                var paramUpdCosto = _dataProvider.GetParameter();
                paramUpdCosto.ParameterName = "Costo";
                paramUpdCosto.DbType = DbType.Decimal;
                paramUpdCosto.Value = (object)entity.Costo ?? DBNull.Value;
                var paramUpdContrato = _dataProvider.GetParameter();
                paramUpdContrato.ParameterName = "Contrato";
                paramUpdContrato.DbType = DbType.Int32;
                paramUpdContrato.Value = (object)entity.Contrato ?? DBNull.Value;
                var paramUpdFirmo_Contrato = _dataProvider.GetParameter();
                paramUpdFirmo_Contrato.ParameterName = "Firmo_Contrato";
                paramUpdFirmo_Contrato.DbType = DbType.Boolean;
                paramUpdFirmo_Contrato.Value = (object)entity.Firmo_Contrato ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Planes_de_Suscripcion_Especialistas>("sp_UpdDetalle_Planes_de_Suscripcion_Especialistas" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdPlan_de_Suscripcion , paramUpdFecha_de_inicio , paramUpdFecha_fin , paramUpdFrecuencia_de_Pago , paramUpdCosto , paramUpdContrato , paramUpdFirmo_Contrato , paramUpdEstatus ).FirstOrDefault();

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


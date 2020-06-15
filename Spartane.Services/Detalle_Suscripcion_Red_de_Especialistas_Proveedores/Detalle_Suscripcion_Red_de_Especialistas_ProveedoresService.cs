using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Suscripcion_Red_de_Especialistas_Proveedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Suscripcion_Red_de_Especialistas_ProveedoresService : IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> _Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository;
        #endregion

        #region Ctor
        public Detalle_Suscripcion_Red_de_Especialistas_ProveedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_SelAllDetalle_Suscripcion_Red_de_Especialistas_Proveedores");
        }

        public IList<Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Complete>("sp_SelAllComplete_Detalle_Suscripcion_Red_de_Especialistas_Proveedores");
            return data.Select(m => new Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores
            {
                Folio = m.Folio
                ,Folio_Proveedores = m.Folio_Proveedores
                ,Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores = new Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores() { Clave = m.Plan_de_Suscripcion.GetValueOrDefault(), Descripcion = m.Plan_de_Suscripcion_Descripcion }
                ,Fecha_inicio = m.Fecha_inicio
                ,Fecha_fin = m.Fecha_fin
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_ListSelCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_ListSelAll_Detalle_Suscripcion_Red_de_Especialistas_Proveedores", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores
                {
                    Folio = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Folio,
                    Folio_Proveedores = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Folio_Proveedores,
                    Plan_de_Suscripcion = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Plan_de_Suscripcion,
                    Fecha_inicio = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_inicio,
                    Fecha_fin = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_fin,
                    Costo = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Costo,
                    Contrato = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Contrato,
                    Firmo_Contrato = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Firmo_Contrato ?? false,
                    Estatus = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus,

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

        public IList<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_ListSelAll_Detalle_Suscripcion_Red_de_Especialistas_Proveedores", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPagingModel
                {
                    Detalle_Suscripcion_Red_de_Especialistas_Proveedoress =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores
                {
                    Folio = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Folio
                    ,Folio_Proveedores = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Folio_Proveedores
                    ,Plan_de_Suscripcion = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Plan_de_Suscripcion
                    ,Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores = new Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores() { Clave = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Plan_de_Suscripcion.GetValueOrDefault(), Descripcion = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Plan_de_Suscripcion_Descripcion }
                    ,Fecha_inicio = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_inicio
                    ,Fecha_fin = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_fin
                    ,Costo = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Costo
                    ,Contrato = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Contrato
                    ,Firmo_Contrato = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Firmo_Contrato ?? false
                    ,Estatus = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus
                    ,Estatus_Estatus_de_Suscripcion = new Core.Classes.Estatus_de_Suscripcion.Estatus_de_Suscripcion() { Clave = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_DelDetalle_Suscripcion_Red_de_Especialistas_Proveedores", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Proveedores = _dataProvider.GetParameter();
                padreFolio_Proveedores.ParameterName = "Folio_Proveedores";
                padreFolio_Proveedores.DbType = DbType.Int32;
                padreFolio_Proveedores.Value = (object)entity.Folio_Proveedores ?? DBNull.Value;
                var padrePlan_de_Suscripcion = _dataProvider.GetParameter();
                padrePlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                padrePlan_de_Suscripcion.DbType = DbType.Int32;
                padrePlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;

                var padreFecha_inicio = _dataProvider.GetParameter();
                padreFecha_inicio.ParameterName = "Fecha_inicio";
                padreFecha_inicio.DbType = DbType.DateTime;
                padreFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;

                var padreFecha_fin = _dataProvider.GetParameter();
                padreFecha_fin.ParameterName = "Fecha_fin";
                padreFecha_fin.DbType = DbType.DateTime;
                padreFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;

                var padreCosto = _dataProvider.GetParameter();
                padreCosto.ParameterName = "Costo";
                padreCosto.DbType = DbType.Currency;
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_InsDetalle_Suscripcion_Red_de_Especialistas_Proveedores" , padreFolio_Proveedores
, padrePlan_de_Suscripcion
, padreFecha_inicio
, padreFecha_fin
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

        public int Update(Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Proveedores = _dataProvider.GetParameter();
                paramUpdFolio_Proveedores.ParameterName = "Folio_Proveedores";
                paramUpdFolio_Proveedores.DbType = DbType.Int32;
                paramUpdFolio_Proveedores.Value = (object)entity.Folio_Proveedores ?? DBNull.Value;
                var paramUpdPlan_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdPlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                paramUpdPlan_de_Suscripcion.DbType = DbType.Int32;
                paramUpdPlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;

                var paramUpdFecha_inicio = _dataProvider.GetParameter();
                paramUpdFecha_inicio.ParameterName = "Fecha_inicio";
                paramUpdFecha_inicio.DbType = DbType.DateTime;
                paramUpdFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;

                var paramUpdFecha_fin = _dataProvider.GetParameter();
                paramUpdFecha_fin.ParameterName = "Fecha_fin";
                paramUpdFecha_fin.DbType = DbType.DateTime;
                paramUpdFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;

                var paramUpdCosto = _dataProvider.GetParameter();
                paramUpdCosto.ParameterName = "Costo";
                paramUpdCosto.DbType = DbType.Currency;
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_UpdDetalle_Suscripcion_Red_de_Especialistas_Proveedores" , paramUpdFolio , paramUpdFolio_Proveedores , paramUpdPlan_de_Suscripcion , paramUpdFecha_inicio , paramUpdFecha_fin , paramUpdCosto , paramUpdContrato , paramUpdFirmo_Contrato , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Proveedores = _dataProvider.GetParameter();
                paramUpdFolio_Proveedores.ParameterName = "Folio_Proveedores";
                paramUpdFolio_Proveedores.DbType = DbType.Int32;
                paramUpdFolio_Proveedores.Value = (object)entity.Folio_Proveedores ?? DBNull.Value;
		var paramUpdPlan_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdPlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                paramUpdPlan_de_Suscripcion.DbType = DbType.Int32;
                paramUpdPlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;
                var paramUpdFecha_inicio = _dataProvider.GetParameter();
                paramUpdFecha_inicio.ParameterName = "Fecha_inicio";
                paramUpdFecha_inicio.DbType = DbType.DateTime;
                paramUpdFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;
                var paramUpdFecha_fin = _dataProvider.GetParameter();
                paramUpdFecha_fin.ParameterName = "Fecha_fin";
                paramUpdFecha_fin.DbType = DbType.DateTime;
                paramUpdFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;
                var paramUpdCosto = _dataProvider.GetParameter();
                paramUpdCosto.ParameterName = "Costo";
                paramUpdCosto.DbType = DbType.Currency;
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Suscripcion_Red_de_Especialistas_Proveedores>("sp_UpdDetalle_Suscripcion_Red_de_Especialistas_Proveedores" , paramUpdFolio , paramUpdFolio_Proveedores , paramUpdPlan_de_Suscripcion , paramUpdFecha_inicio , paramUpdFecha_fin , paramUpdCosto , paramUpdContrato , paramUpdFirmo_Contrato , paramUpdEstatus ).FirstOrDefault();

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


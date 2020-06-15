using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Pagos_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Pagos_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Pagos_EspecialistasService : IDetalle_Pagos_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> _Detalle_Pagos_EspecialistasRepository;
        #endregion

        #region Ctor
        public Detalle_Pagos_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> Detalle_Pagos_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Pagos_EspecialistasRepository = Detalle_Pagos_EspecialistasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas>("sp_SelAllDetalle_Pagos_Especialistas");
        }

        public IList<Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Pagos_Especialistas_Complete>("sp_SelAllComplete_Detalle_Pagos_Especialistas");
            return data.Select(m => new Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas
            {
                Folio = m.Folio
                ,Folio_Especialistas = m.Folio_Especialistas
                ,Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas = new Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas() { Folio = m.Plan_de_Suscripcion.GetValueOrDefault(), Nombre = m.Plan_de_Suscripcion_Nombre }
                ,Concepto_de_Pago = m.Concepto_de_Pago
                ,Fecha_Limite_de_Pago = m.Fecha_Limite_de_Pago
                ,Recordatorio_dias = m.Recordatorio_dias
                ,Forma_de_Pago_Formas_de_Pago = new Core.Classes.Formas_de_Pago.Formas_de_Pago() { Clave = m.Forma_de_Pago.GetValueOrDefault(), Nombre = m.Forma_de_Pago_Nombre }
                ,Fecha_de_Pago = m.Fecha_de_Pago
                ,Estatus_Estatus_de_Pago = new Core.Classes.Estatus_de_Pago.Estatus_de_Pago() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Fecha_de_Suscripcion = m.Fecha_de_Suscripcion
                ,Numero_de_Pago = m.Numero_de_Pago
                ,De_Total_de_Pagos = m.De_Total_de_Pagos


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Pagos_Especialistas>("sp_ListSelCount_Detalle_Pagos_Especialistas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Pagos_Especialistas>("sp_ListSelAll_Detalle_Pagos_Especialistas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas
                {
                    Folio = m.Detalle_Pagos_Especialistas_Folio,
                    Folio_Especialistas = m.Detalle_Pagos_Especialistas_Folio_Especialistas,
                    Plan_de_Suscripcion = m.Detalle_Pagos_Especialistas_Plan_de_Suscripcion,
                    Concepto_de_Pago = m.Detalle_Pagos_Especialistas_Concepto_de_Pago,
                    Fecha_Limite_de_Pago = m.Detalle_Pagos_Especialistas_Fecha_Limite_de_Pago,
                    Recordatorio_dias = m.Detalle_Pagos_Especialistas_Recordatorio_dias,
                    Forma_de_Pago = m.Detalle_Pagos_Especialistas_Forma_de_Pago,
                    Fecha_de_Pago = m.Detalle_Pagos_Especialistas_Fecha_de_Pago,
                    Estatus = m.Detalle_Pagos_Especialistas_Estatus,
                    Fecha_de_Suscripcion = m.Detalle_Pagos_Especialistas_Fecha_de_Suscripcion,
                    Numero_de_Pago = m.Detalle_Pagos_Especialistas_Numero_de_Pago,
                    De_Total_de_Pagos = m.Detalle_Pagos_Especialistas_De_Total_de_Pagos,

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

        public IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Pagos_Especialistas>("sp_ListSelAll_Detalle_Pagos_Especialistas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Pagos_EspecialistasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Pagos_EspecialistasPagingModel
                {
                    Detalle_Pagos_Especialistass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas
                {
                    Folio = m.Detalle_Pagos_Especialistas_Folio
                    ,Folio_Especialistas = m.Detalle_Pagos_Especialistas_Folio_Especialistas
                    ,Plan_de_Suscripcion = m.Detalle_Pagos_Especialistas_Plan_de_Suscripcion
                    ,Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas = new Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas() { Folio = m.Detalle_Pagos_Especialistas_Plan_de_Suscripcion.GetValueOrDefault(), Nombre = m.Detalle_Pagos_Especialistas_Plan_de_Suscripcion_Nombre }
                    ,Concepto_de_Pago = m.Detalle_Pagos_Especialistas_Concepto_de_Pago
                    ,Fecha_Limite_de_Pago = m.Detalle_Pagos_Especialistas_Fecha_Limite_de_Pago
                    ,Recordatorio_dias = m.Detalle_Pagos_Especialistas_Recordatorio_dias
                    ,Forma_de_Pago = m.Detalle_Pagos_Especialistas_Forma_de_Pago
                    ,Forma_de_Pago_Formas_de_Pago = new Core.Classes.Formas_de_Pago.Formas_de_Pago() { Clave = m.Detalle_Pagos_Especialistas_Forma_de_Pago.GetValueOrDefault(), Nombre = m.Detalle_Pagos_Especialistas_Forma_de_Pago_Nombre }
                    ,Fecha_de_Pago = m.Detalle_Pagos_Especialistas_Fecha_de_Pago
                    ,Estatus = m.Detalle_Pagos_Especialistas_Estatus
                    ,Estatus_Estatus_de_Pago = new Core.Classes.Estatus_de_Pago.Estatus_de_Pago() { Clave = m.Detalle_Pagos_Especialistas_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Pagos_Especialistas_Estatus_Descripcion }
                    ,Fecha_de_Suscripcion = m.Detalle_Pagos_Especialistas_Fecha_de_Suscripcion
                    ,Numero_de_Pago = m.Detalle_Pagos_Especialistas_Numero_de_Pago
                    ,De_Total_de_Pagos = m.Detalle_Pagos_Especialistas_De_Total_de_Pagos

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas>("sp_GetDetalle_Pagos_Especialistas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Pagos_Especialistas>("sp_DelDetalle_Pagos_Especialistas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas entity)
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

                var padreConcepto_de_Pago = _dataProvider.GetParameter();
                padreConcepto_de_Pago.ParameterName = "Concepto_de_Pago";
                padreConcepto_de_Pago.DbType = DbType.String;
                padreConcepto_de_Pago.Value = (object)entity.Concepto_de_Pago ?? DBNull.Value;
                var padreFecha_Limite_de_Pago = _dataProvider.GetParameter();
                padreFecha_Limite_de_Pago.ParameterName = "Fecha_Limite_de_Pago";
                padreFecha_Limite_de_Pago.DbType = DbType.DateTime;
                padreFecha_Limite_de_Pago.Value = (object)entity.Fecha_Limite_de_Pago ?? DBNull.Value;

                var padreRecordatorio_dias = _dataProvider.GetParameter();
                padreRecordatorio_dias.ParameterName = "Recordatorio_dias";
                padreRecordatorio_dias.DbType = DbType.Int32;
                padreRecordatorio_dias.Value = (object)entity.Recordatorio_dias ?? DBNull.Value;

                var padreForma_de_Pago = _dataProvider.GetParameter();
                padreForma_de_Pago.ParameterName = "Forma_de_Pago";
                padreForma_de_Pago.DbType = DbType.Int32;
                padreForma_de_Pago.Value = (object)entity.Forma_de_Pago ?? DBNull.Value;

                var padreFecha_de_Pago = _dataProvider.GetParameter();
                padreFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                padreFecha_de_Pago.DbType = DbType.DateTime;
                padreFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreFecha_de_Suscripcion = _dataProvider.GetParameter();
                padreFecha_de_Suscripcion.ParameterName = "Fecha_de_Suscripcion";
                padreFecha_de_Suscripcion.DbType = DbType.DateTime;
                padreFecha_de_Suscripcion.Value = (object)entity.Fecha_de_Suscripcion ?? DBNull.Value;

                var padreNumero_de_Pago = _dataProvider.GetParameter();
                padreNumero_de_Pago.ParameterName = "Numero_de_Pago";
                padreNumero_de_Pago.DbType = DbType.Int32;
                padreNumero_de_Pago.Value = (object)entity.Numero_de_Pago ?? DBNull.Value;

                var padreDe_Total_de_Pagos = _dataProvider.GetParameter();
                padreDe_Total_de_Pagos.ParameterName = "De_Total_de_Pagos";
                padreDe_Total_de_Pagos.DbType = DbType.Int32;
                padreDe_Total_de_Pagos.Value = (object)entity.De_Total_de_Pagos ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Pagos_Especialistas>("sp_InsDetalle_Pagos_Especialistas" , padreFolio_Especialistas
, padrePlan_de_Suscripcion
, padreConcepto_de_Pago
, padreFecha_Limite_de_Pago
, padreRecordatorio_dias
, padreForma_de_Pago
, padreFecha_de_Pago
, padreEstatus
, padreFecha_de_Suscripcion
, padreNumero_de_Pago
, padreDe_Total_de_Pagos
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

        public int Update(Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas entity)
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

                var paramUpdConcepto_de_Pago = _dataProvider.GetParameter();
                paramUpdConcepto_de_Pago.ParameterName = "Concepto_de_Pago";
                paramUpdConcepto_de_Pago.DbType = DbType.String;
                paramUpdConcepto_de_Pago.Value = (object)entity.Concepto_de_Pago ?? DBNull.Value;
                var paramUpdFecha_Limite_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_Limite_de_Pago.ParameterName = "Fecha_Limite_de_Pago";
                paramUpdFecha_Limite_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_Limite_de_Pago.Value = (object)entity.Fecha_Limite_de_Pago ?? DBNull.Value;

                var paramUpdRecordatorio_dias = _dataProvider.GetParameter();
                paramUpdRecordatorio_dias.ParameterName = "Recordatorio_dias";
                paramUpdRecordatorio_dias.DbType = DbType.Int32;
                paramUpdRecordatorio_dias.Value = (object)entity.Recordatorio_dias ?? DBNull.Value;

                var paramUpdForma_de_Pago = _dataProvider.GetParameter();
                paramUpdForma_de_Pago.ParameterName = "Forma_de_Pago";
                paramUpdForma_de_Pago.DbType = DbType.Int32;
                paramUpdForma_de_Pago.Value = (object)entity.Forma_de_Pago ?? DBNull.Value;

                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdFecha_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdFecha_de_Suscripcion.ParameterName = "Fecha_de_Suscripcion";
                paramUpdFecha_de_Suscripcion.DbType = DbType.DateTime;
                paramUpdFecha_de_Suscripcion.Value = (object)entity.Fecha_de_Suscripcion ?? DBNull.Value;

                var paramUpdNumero_de_Pago = _dataProvider.GetParameter();
                paramUpdNumero_de_Pago.ParameterName = "Numero_de_Pago";
                paramUpdNumero_de_Pago.DbType = DbType.Int32;
                paramUpdNumero_de_Pago.Value = (object)entity.Numero_de_Pago ?? DBNull.Value;

                var paramUpdDe_Total_de_Pagos = _dataProvider.GetParameter();
                paramUpdDe_Total_de_Pagos.ParameterName = "De_Total_de_Pagos";
                paramUpdDe_Total_de_Pagos.DbType = DbType.Int32;
                paramUpdDe_Total_de_Pagos.Value = (object)entity.De_Total_de_Pagos ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Pagos_Especialistas>("sp_UpdDetalle_Pagos_Especialistas" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdPlan_de_Suscripcion , paramUpdConcepto_de_Pago , paramUpdFecha_Limite_de_Pago , paramUpdRecordatorio_dias , paramUpdForma_de_Pago , paramUpdFecha_de_Pago , paramUpdEstatus , paramUpdFecha_de_Suscripcion , paramUpdNumero_de_Pago , paramUpdDe_Total_de_Pagos ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas Detalle_Pagos_EspecialistasDB = GetByKey(entity.Folio, false);
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
                var paramUpdConcepto_de_Pago = _dataProvider.GetParameter();
                paramUpdConcepto_de_Pago.ParameterName = "Concepto_de_Pago";
                paramUpdConcepto_de_Pago.DbType = DbType.String;
                paramUpdConcepto_de_Pago.Value = (object)entity.Concepto_de_Pago ?? DBNull.Value;
                var paramUpdFecha_Limite_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_Limite_de_Pago.ParameterName = "Fecha_Limite_de_Pago";
                paramUpdFecha_Limite_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_Limite_de_Pago.Value = (object)entity.Fecha_Limite_de_Pago ?? DBNull.Value;
                var paramUpdRecordatorio_dias = _dataProvider.GetParameter();
                paramUpdRecordatorio_dias.ParameterName = "Recordatorio_dias";
                paramUpdRecordatorio_dias.DbType = DbType.Int32;
                paramUpdRecordatorio_dias.Value = (object)entity.Recordatorio_dias ?? DBNull.Value;
		var paramUpdForma_de_Pago = _dataProvider.GetParameter();
                paramUpdForma_de_Pago.ParameterName = "Forma_de_Pago";
                paramUpdForma_de_Pago.DbType = DbType.Int32;
                paramUpdForma_de_Pago.Value = (object)entity.Forma_de_Pago ?? DBNull.Value;
                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdFecha_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdFecha_de_Suscripcion.ParameterName = "Fecha_de_Suscripcion";
                paramUpdFecha_de_Suscripcion.DbType = DbType.DateTime;
                paramUpdFecha_de_Suscripcion.Value = (object)entity.Fecha_de_Suscripcion ?? DBNull.Value;
                var paramUpdNumero_de_Pago = _dataProvider.GetParameter();
                paramUpdNumero_de_Pago.ParameterName = "Numero_de_Pago";
                paramUpdNumero_de_Pago.DbType = DbType.Int32;
                paramUpdNumero_de_Pago.Value = (object)entity.Numero_de_Pago ?? DBNull.Value;
                var paramUpdDe_Total_de_Pagos = _dataProvider.GetParameter();
                paramUpdDe_Total_de_Pagos.ParameterName = "De_Total_de_Pagos";
                paramUpdDe_Total_de_Pagos.DbType = DbType.Int32;
                paramUpdDe_Total_de_Pagos.Value = (object)entity.De_Total_de_Pagos ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Pagos_Especialistas>("sp_UpdDetalle_Pagos_Especialistas" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdPlan_de_Suscripcion , paramUpdConcepto_de_Pago , paramUpdFecha_Limite_de_Pago , paramUpdRecordatorio_dias , paramUpdForma_de_Pago , paramUpdFecha_de_Pago , paramUpdEstatus , paramUpdFecha_de_Suscripcion , paramUpdNumero_de_Pago , paramUpdDe_Total_de_Pagos ).FirstOrDefault();

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


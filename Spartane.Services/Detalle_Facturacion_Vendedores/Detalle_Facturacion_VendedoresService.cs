using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Facturacion_Vendedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Facturacion_Vendedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Facturacion_VendedoresService : IDetalle_Facturacion_VendedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> _Detalle_Facturacion_VendedoresRepository;
        #endregion

        #region Ctor
        public Detalle_Facturacion_VendedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> Detalle_Facturacion_VendedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Facturacion_VendedoresRepository = Detalle_Facturacion_VendedoresRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Facturacion_VendedoresRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores>("sp_SelAllDetalle_Facturacion_Vendedores");
        }

        public IList<Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Facturacion_Vendedores_Complete>("sp_SelAllComplete_Detalle_Facturacion_Vendedores");
            return data.Select(m => new Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Folio_Factura = m.Folio_Factura
                ,Periodo_Facturado = m.Periodo_Facturado
                ,Cantidad = m.Cantidad
                ,Archivo_XML = m.Archivo_XML
                ,Archivo_PDF = m.Archivo_PDF
                ,Estatus_Estatus_Facturas = new Core.Classes.Estatus_Facturas.Estatus_Facturas() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Fecha_programada_de_Pago = m.Fecha_programada_de_Pago
                ,Pagada = m.Pagada.GetValueOrDefault()
                ,Fecha_de_Pago = m.Fecha_de_Pago


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Facturacion_Vendedores>("sp_ListSelCount_Detalle_Facturacion_Vendedores", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Facturacion_Vendedores>("sp_ListSelAll_Detalle_Facturacion_Vendedores", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores
                {
                    Folio = m.Detalle_Facturacion_Vendedores_Folio,
                    Fecha_de_Registro = m.Detalle_Facturacion_Vendedores_Fecha_de_Registro,
                    Folio_Factura = m.Detalle_Facturacion_Vendedores_Folio_Factura,
                    Periodo_Facturado = m.Detalle_Facturacion_Vendedores_Periodo_Facturado,
                    Cantidad = m.Detalle_Facturacion_Vendedores_Cantidad,
                    Archivo_XML = m.Detalle_Facturacion_Vendedores_Archivo_XML,
                    Archivo_PDF = m.Detalle_Facturacion_Vendedores_Archivo_PDF,
                    Estatus = m.Detalle_Facturacion_Vendedores_Estatus,
                    Fecha_programada_de_Pago = m.Detalle_Facturacion_Vendedores_Fecha_programada_de_Pago,
                    Pagada = m.Detalle_Facturacion_Vendedores_Pagada ?? false,
                    Fecha_de_Pago = m.Detalle_Facturacion_Vendedores_Fecha_de_Pago,

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

        public IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Facturacion_VendedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Facturacion_VendedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_VendedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Facturacion_Vendedores>("sp_ListSelAll_Detalle_Facturacion_Vendedores", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Facturacion_VendedoresPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Facturacion_VendedoresPagingModel
                {
                    Detalle_Facturacion_Vendedoress =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores
                {
                    Folio = m.Detalle_Facturacion_Vendedores_Folio
                    ,Fecha_de_Registro = m.Detalle_Facturacion_Vendedores_Fecha_de_Registro
                    ,Folio_Factura = m.Detalle_Facturacion_Vendedores_Folio_Factura
                    ,Periodo_Facturado = m.Detalle_Facturacion_Vendedores_Periodo_Facturado
                    ,Cantidad = m.Detalle_Facturacion_Vendedores_Cantidad
                    ,Archivo_XML = m.Detalle_Facturacion_Vendedores_Archivo_XML
                    ,Archivo_PDF = m.Detalle_Facturacion_Vendedores_Archivo_PDF
                    ,Estatus = m.Detalle_Facturacion_Vendedores_Estatus
                    ,Estatus_Estatus_Facturas = new Core.Classes.Estatus_Facturas.Estatus_Facturas() { Clave = m.Detalle_Facturacion_Vendedores_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Facturacion_Vendedores_Estatus_Descripcion }
                    ,Fecha_programada_de_Pago = m.Detalle_Facturacion_Vendedores_Fecha_programada_de_Pago
                    ,Pagada = m.Detalle_Facturacion_Vendedores_Pagada ?? false
                    ,Fecha_de_Pago = m.Detalle_Facturacion_Vendedores_Fecha_de_Pago

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Facturacion_VendedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores>("sp_GetDetalle_Facturacion_Vendedores", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Facturacion_Vendedores>("sp_DelDetalle_Facturacion_Vendedores", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores entity)
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

                var padreFolio_Factura = _dataProvider.GetParameter();
                padreFolio_Factura.ParameterName = "Folio_Factura";
                padreFolio_Factura.DbType = DbType.String;
                padreFolio_Factura.Value = (object)entity.Folio_Factura ?? DBNull.Value;
                var padrePeriodo_Facturado = _dataProvider.GetParameter();
                padrePeriodo_Facturado.ParameterName = "Periodo_Facturado";
                padrePeriodo_Facturado.DbType = DbType.String;
                padrePeriodo_Facturado.Value = (object)entity.Periodo_Facturado ?? DBNull.Value;
                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.Decimal;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;

                var padreArchivo_XML = _dataProvider.GetParameter();
                padreArchivo_XML.ParameterName = "Archivo_XML";
                padreArchivo_XML.DbType = DbType.Int32;
                padreArchivo_XML.Value = (object)entity.Archivo_XML ?? DBNull.Value;

                var padreArchivo_PDF = _dataProvider.GetParameter();
                padreArchivo_PDF.ParameterName = "Archivo_PDF";
                padreArchivo_PDF.DbType = DbType.Int32;
                padreArchivo_PDF.Value = (object)entity.Archivo_PDF ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreFecha_programada_de_Pago = _dataProvider.GetParameter();
                padreFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                padreFecha_programada_de_Pago.DbType = DbType.DateTime;
                padreFecha_programada_de_Pago.Value = (object)entity.Fecha_programada_de_Pago ?? DBNull.Value;

                var padrePagada = _dataProvider.GetParameter();
                padrePagada.ParameterName = "Pagada";
                padrePagada.DbType = DbType.Boolean;
                padrePagada.Value = (object)entity.Pagada ?? DBNull.Value;
                var padreFecha_de_Pago = _dataProvider.GetParameter();
                padreFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                padreFecha_de_Pago.DbType = DbType.DateTime;
                padreFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Facturacion_Vendedores>("sp_InsDetalle_Facturacion_Vendedores" , padreFecha_de_Registro
, padreFolio_Factura
, padrePeriodo_Facturado
, padreCantidad
, padreArchivo_XML
, padreArchivo_PDF
, padreEstatus
, padreFecha_programada_de_Pago
, padrePagada
, padreFecha_de_Pago
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

        public int Update(Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores entity)
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

                var paramUpdFolio_Factura = _dataProvider.GetParameter();
                paramUpdFolio_Factura.ParameterName = "Folio_Factura";
                paramUpdFolio_Factura.DbType = DbType.String;
                paramUpdFolio_Factura.Value = (object)entity.Folio_Factura ?? DBNull.Value;
                var paramUpdPeriodo_Facturado = _dataProvider.GetParameter();
                paramUpdPeriodo_Facturado.ParameterName = "Periodo_Facturado";
                paramUpdPeriodo_Facturado.DbType = DbType.String;
                paramUpdPeriodo_Facturado.Value = (object)entity.Periodo_Facturado ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Decimal;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;

                var paramUpdArchivo_XML = _dataProvider.GetParameter();
                paramUpdArchivo_XML.ParameterName = "Archivo_XML";
                paramUpdArchivo_XML.DbType = DbType.Int32;
                paramUpdArchivo_XML.Value = (object)entity.Archivo_XML ?? DBNull.Value;

                var paramUpdArchivo_PDF = _dataProvider.GetParameter();
                paramUpdArchivo_PDF.ParameterName = "Archivo_PDF";
                paramUpdArchivo_PDF.DbType = DbType.Int32;
                paramUpdArchivo_PDF.Value = (object)entity.Archivo_PDF ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdFecha_programada_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                paramUpdFecha_programada_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_programada_de_Pago.Value = (object)entity.Fecha_programada_de_Pago ?? DBNull.Value;

                var paramUpdPagada = _dataProvider.GetParameter();
                paramUpdPagada.ParameterName = "Pagada";
                paramUpdPagada.DbType = DbType.Boolean;
                paramUpdPagada.Value = (object)entity.Pagada ?? DBNull.Value;
                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Facturacion_Vendedores>("sp_UpdDetalle_Facturacion_Vendedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdFolio_Factura , paramUpdPeriodo_Facturado , paramUpdCantidad , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdEstatus , paramUpdFecha_programada_de_Pago , paramUpdPagada , paramUpdFecha_de_Pago ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores Detalle_Facturacion_VendedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdFolio_Factura = _dataProvider.GetParameter();
                paramUpdFolio_Factura.ParameterName = "Folio_Factura";
                paramUpdFolio_Factura.DbType = DbType.String;
                paramUpdFolio_Factura.Value = (object)entity.Folio_Factura ?? DBNull.Value;
                var paramUpdPeriodo_Facturado = _dataProvider.GetParameter();
                paramUpdPeriodo_Facturado.ParameterName = "Periodo_Facturado";
                paramUpdPeriodo_Facturado.DbType = DbType.String;
                paramUpdPeriodo_Facturado.Value = (object)entity.Periodo_Facturado ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Decimal;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var paramUpdArchivo_XML = _dataProvider.GetParameter();
                paramUpdArchivo_XML.ParameterName = "Archivo_XML";
                paramUpdArchivo_XML.DbType = DbType.Int32;
                paramUpdArchivo_XML.Value = (object)entity.Archivo_XML ?? DBNull.Value;
                var paramUpdArchivo_PDF = _dataProvider.GetParameter();
                paramUpdArchivo_PDF.ParameterName = "Archivo_PDF";
                paramUpdArchivo_PDF.DbType = DbType.Int32;
                paramUpdArchivo_PDF.Value = (object)entity.Archivo_PDF ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdFecha_programada_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                paramUpdFecha_programada_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_programada_de_Pago.Value = (object)entity.Fecha_programada_de_Pago ?? DBNull.Value;
                var paramUpdPagada = _dataProvider.GetParameter();
                paramUpdPagada.ParameterName = "Pagada";
                paramUpdPagada.DbType = DbType.Boolean;
                paramUpdPagada.Value = (object)entity.Pagada ?? DBNull.Value;
                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Facturacion_Vendedores>("sp_UpdDetalle_Facturacion_Vendedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdFolio_Factura , paramUpdPeriodo_Facturado , paramUpdCantidad , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdEstatus , paramUpdFecha_programada_de_Pago , paramUpdPagada , paramUpdFecha_de_Pago ).FirstOrDefault();

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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Facturacion_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Facturacion_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Facturacion_EspecialistasService : IDetalle_Facturacion_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas> _Detalle_Facturacion_EspecialistasRepository;
        #endregion

        #region Ctor
        public Detalle_Facturacion_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas> Detalle_Facturacion_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Facturacion_EspecialistasRepository = Detalle_Facturacion_EspecialistasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Facturacion_EspecialistasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas>("sp_SelAllDetalle_Facturacion_Especialistas");
        }

        public IList<Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Facturacion_Especialistas_Complete>("sp_SelAllComplete_Detalle_Facturacion_Especialistas");
            return data.Select(m => new Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas
            {
                Folio = m.Folio
                ,Folio_Especialistas = m.Folio_Especialistas
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Folio_Factura = m.Folio_Factura
                ,Periodo_Facturado = m.Periodo_Facturado
                ,Cantidad = m.Cantidad
                ,Archivo_XML = m.Archivo_XML
                ,Archivo_PDF = m.Archivo_PDF
                ,Estatus = m.Estatus
                ,Fecha_programada_de_Pago = m.Fecha_programada_de_Pago
                ,Pagada = m.Pagada.GetValueOrDefault()
                ,Fecha_de_pago = m.Fecha_de_pago


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Facturacion_Especialistas>("sp_ListSelCount_Detalle_Facturacion_Especialistas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Facturacion_Especialistas>("sp_ListSelAll_Detalle_Facturacion_Especialistas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas
                {
                    Folio = m.Detalle_Facturacion_Especialistas_Folio,
                    Folio_Especialistas = m.Detalle_Facturacion_Especialistas_Folio_Especialistas,
                    Fecha_de_Registro = m.Detalle_Facturacion_Especialistas_Fecha_de_Registro,
                    Folio_Factura = m.Detalle_Facturacion_Especialistas_Folio_Factura,
                    Periodo_Facturado = m.Detalle_Facturacion_Especialistas_Periodo_Facturado,
                    Cantidad = m.Detalle_Facturacion_Especialistas_Cantidad,
                    Archivo_XML = m.Detalle_Facturacion_Especialistas_Archivo_XML,
                    Archivo_PDF = m.Detalle_Facturacion_Especialistas_Archivo_PDF,
                    Estatus = m.Detalle_Facturacion_Especialistas_Estatus,
                    Fecha_programada_de_Pago = m.Detalle_Facturacion_Especialistas_Fecha_programada_de_Pago,
                    Pagada = m.Detalle_Facturacion_Especialistas_Pagada ?? false,
                    Fecha_de_pago = m.Detalle_Facturacion_Especialistas_Fecha_de_pago,

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

        public IList<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Facturacion_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Facturacion_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Facturacion_Especialistas>("sp_ListSelAll_Detalle_Facturacion_Especialistas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Facturacion_EspecialistasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Facturacion_EspecialistasPagingModel
                {
                    Detalle_Facturacion_Especialistass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas
                {
                    Folio = m.Detalle_Facturacion_Especialistas_Folio
                    ,Folio_Especialistas = m.Detalle_Facturacion_Especialistas_Folio_Especialistas
                    ,Fecha_de_Registro = m.Detalle_Facturacion_Especialistas_Fecha_de_Registro
                    ,Folio_Factura = m.Detalle_Facturacion_Especialistas_Folio_Factura
                    ,Periodo_Facturado = m.Detalle_Facturacion_Especialistas_Periodo_Facturado
                    ,Cantidad = m.Detalle_Facturacion_Especialistas_Cantidad
                    ,Archivo_XML = m.Detalle_Facturacion_Especialistas_Archivo_XML
                    ,Archivo_PDF = m.Detalle_Facturacion_Especialistas_Archivo_PDF
                    ,Estatus = m.Detalle_Facturacion_Especialistas_Estatus
                    ,Fecha_programada_de_Pago = m.Detalle_Facturacion_Especialistas_Fecha_programada_de_Pago
                    ,Pagada = m.Detalle_Facturacion_Especialistas_Pagada ?? false
                    ,Fecha_de_pago = m.Detalle_Facturacion_Especialistas_Fecha_de_pago

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Facturacion_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas>("sp_GetDetalle_Facturacion_Especialistas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Facturacion_Especialistas>("sp_DelDetalle_Facturacion_Especialistas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas entity)
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
                var padreFecha_de_pago = _dataProvider.GetParameter();
                padreFecha_de_pago.ParameterName = "Fecha_de_pago";
                padreFecha_de_pago.DbType = DbType.DateTime;
                padreFecha_de_pago.Value = (object)entity.Fecha_de_pago ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Facturacion_Especialistas>("sp_InsDetalle_Facturacion_Especialistas" , padreFolio_Especialistas
, padreFecha_de_Registro
, padreFolio_Factura
, padrePeriodo_Facturado
, padreCantidad
, padreArchivo_XML
, padreArchivo_PDF
, padreEstatus
, padreFecha_programada_de_Pago
, padrePagada
, padreFecha_de_pago
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

        public int Update(Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas entity)
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
                var paramUpdFecha_de_pago = _dataProvider.GetParameter();
                paramUpdFecha_de_pago.ParameterName = "Fecha_de_pago";
                paramUpdFecha_de_pago.DbType = DbType.DateTime;
                paramUpdFecha_de_pago.Value = (object)entity.Fecha_de_pago ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Facturacion_Especialistas>("sp_UpdDetalle_Facturacion_Especialistas" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdFecha_de_Registro , paramUpdFolio_Factura , paramUpdPeriodo_Facturado , paramUpdCantidad , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdEstatus , paramUpdFecha_programada_de_Pago , paramUpdPagada , paramUpdFecha_de_pago ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas Detalle_Facturacion_EspecialistasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Especialistas = _dataProvider.GetParameter();
                paramUpdFolio_Especialistas.ParameterName = "Folio_Especialistas";
                paramUpdFolio_Especialistas.DbType = DbType.Int32;
                paramUpdFolio_Especialistas.Value = (object)entity.Folio_Especialistas ?? DBNull.Value;
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
                var paramUpdFecha_de_pago = _dataProvider.GetParameter();
                paramUpdFecha_de_pago.ParameterName = "Fecha_de_pago";
                paramUpdFecha_de_pago.DbType = DbType.DateTime;
                paramUpdFecha_de_pago.Value = (object)entity.Fecha_de_pago ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Facturacion_Especialistas>("sp_UpdDetalle_Facturacion_Especialistas" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdFecha_de_Registro , paramUpdFolio_Factura , paramUpdPeriodo_Facturado , paramUpdCantidad , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdEstatus , paramUpdFecha_programada_de_Pago , paramUpdPagada , paramUpdFecha_de_pago ).FirstOrDefault();

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


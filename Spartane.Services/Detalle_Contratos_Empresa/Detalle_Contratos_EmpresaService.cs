using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Contratos_Empresa;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Contratos_Empresa
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Contratos_EmpresaService : IDetalle_Contratos_EmpresaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> _Detalle_Contratos_EmpresaRepository;
        #endregion

        #region Ctor
        public Detalle_Contratos_EmpresaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> Detalle_Contratos_EmpresaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Contratos_EmpresaRepository = Detalle_Contratos_EmpresaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Contratos_EmpresaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa>("sp_SelAllDetalle_Contratos_Empresa");
        }

        public IList<Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Contratos_Empresa_Complete>("sp_SelAllComplete_Detalle_Contratos_Empresa");
            return data.Select(m => new Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa
            {
                Folio = m.Folio
                ,Folio_Empresas = m.Folio_Empresas
                ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Suscripcion_Nombre_del_Plan }
                ,Tipo_de_Contrato_Tipos_de_Contrato = new Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato() { Clave = m.Tipo_de_Contrato.GetValueOrDefault(), Descripcion = m.Tipo_de_Contrato_Descripcion }
                ,Documento = m.Documento
                ,Fecha_de_Firma_de_Contrato = m.Fecha_de_Firma_de_Contrato


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Contratos_Empresa>("sp_ListSelCount_Detalle_Contratos_Empresa", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Contratos_Empresa>("sp_ListSelAll_Detalle_Contratos_Empresa", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa
                {
                    Folio = m.Detalle_Contratos_Empresa_Folio,
                    Folio_Empresas = m.Detalle_Contratos_Empresa_Folio_Empresas,
                    Suscripcion = m.Detalle_Contratos_Empresa_Suscripcion,
                    Tipo_de_Contrato = m.Detalle_Contratos_Empresa_Tipo_de_Contrato,
                    Documento = m.Detalle_Contratos_Empresa_Documento,
                    Fecha_de_Firma_de_Contrato = m.Detalle_Contratos_Empresa_Fecha_de_Firma_de_Contrato,

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

        public IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Contratos_EmpresaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Contratos_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Contratos_Empresa>("sp_ListSelAll_Detalle_Contratos_Empresa", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Contratos_EmpresaPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Contratos_EmpresaPagingModel
                {
                    Detalle_Contratos_Empresas =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa
                {
                    Folio = m.Detalle_Contratos_Empresa_Folio
                    ,Folio_Empresas = m.Detalle_Contratos_Empresa_Folio_Empresas
                    ,Suscripcion = m.Detalle_Contratos_Empresa_Suscripcion
                    ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Detalle_Contratos_Empresa_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Detalle_Contratos_Empresa_Suscripcion_Nombre_del_Plan }
                    ,Tipo_de_Contrato = m.Detalle_Contratos_Empresa_Tipo_de_Contrato
                    ,Tipo_de_Contrato_Tipos_de_Contrato = new Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato() { Clave = m.Detalle_Contratos_Empresa_Tipo_de_Contrato.GetValueOrDefault(), Descripcion = m.Detalle_Contratos_Empresa_Tipo_de_Contrato_Descripcion }
                    ,Documento = m.Detalle_Contratos_Empresa_Documento
                    ,Fecha_de_Firma_de_Contrato = m.Detalle_Contratos_Empresa_Fecha_de_Firma_de_Contrato

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Contratos_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa>("sp_GetDetalle_Contratos_Empresa", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Contratos_Empresa>("sp_DelDetalle_Contratos_Empresa", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa entity)
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
                var padreSuscripcion = _dataProvider.GetParameter();
                padreSuscripcion.ParameterName = "Suscripcion";
                padreSuscripcion.DbType = DbType.Int32;
                padreSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var padreTipo_de_Contrato = _dataProvider.GetParameter();
                padreTipo_de_Contrato.ParameterName = "Tipo_de_Contrato";
                padreTipo_de_Contrato.DbType = DbType.Int32;
                padreTipo_de_Contrato.Value = (object)entity.Tipo_de_Contrato ?? DBNull.Value;

                var padreDocumento = _dataProvider.GetParameter();
                padreDocumento.ParameterName = "Documento";
                padreDocumento.DbType = DbType.Int32;
                padreDocumento.Value = (object)entity.Documento ?? DBNull.Value;

                var padreFecha_de_Firma_de_Contrato = _dataProvider.GetParameter();
                padreFecha_de_Firma_de_Contrato.ParameterName = "Fecha_de_Firma_de_Contrato";
                padreFecha_de_Firma_de_Contrato.DbType = DbType.DateTime;
                padreFecha_de_Firma_de_Contrato.Value = (object)entity.Fecha_de_Firma_de_Contrato ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Contratos_Empresa>("sp_InsDetalle_Contratos_Empresa" , padreFolio_Empresas
, padreSuscripcion
, padreTipo_de_Contrato
, padreDocumento
, padreFecha_de_Firma_de_Contrato
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

        public int Update(Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa entity)
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
                var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var paramUpdTipo_de_Contrato = _dataProvider.GetParameter();
                paramUpdTipo_de_Contrato.ParameterName = "Tipo_de_Contrato";
                paramUpdTipo_de_Contrato.DbType = DbType.Int32;
                paramUpdTipo_de_Contrato.Value = (object)entity.Tipo_de_Contrato ?? DBNull.Value;

                var paramUpdDocumento = _dataProvider.GetParameter();
                paramUpdDocumento.ParameterName = "Documento";
                paramUpdDocumento.DbType = DbType.Int32;
                paramUpdDocumento.Value = (object)entity.Documento ?? DBNull.Value;

                var paramUpdFecha_de_Firma_de_Contrato = _dataProvider.GetParameter();
                paramUpdFecha_de_Firma_de_Contrato.ParameterName = "Fecha_de_Firma_de_Contrato";
                paramUpdFecha_de_Firma_de_Contrato.DbType = DbType.DateTime;
                paramUpdFecha_de_Firma_de_Contrato.Value = (object)entity.Fecha_de_Firma_de_Contrato ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Contratos_Empresa>("sp_UpdDetalle_Contratos_Empresa" , paramUpdFolio , paramUpdFolio_Empresas , paramUpdSuscripcion , paramUpdTipo_de_Contrato , paramUpdDocumento , paramUpdFecha_de_Firma_de_Contrato ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa Detalle_Contratos_EmpresaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Empresas = _dataProvider.GetParameter();
                paramUpdFolio_Empresas.ParameterName = "Folio_Empresas";
                paramUpdFolio_Empresas.DbType = DbType.Int32;
                paramUpdFolio_Empresas.Value = (object)entity.Folio_Empresas ?? DBNull.Value;
		var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;
		var paramUpdTipo_de_Contrato = _dataProvider.GetParameter();
                paramUpdTipo_de_Contrato.ParameterName = "Tipo_de_Contrato";
                paramUpdTipo_de_Contrato.DbType = DbType.Int32;
                paramUpdTipo_de_Contrato.Value = (object)entity.Tipo_de_Contrato ?? DBNull.Value;
                var paramUpdDocumento = _dataProvider.GetParameter();
                paramUpdDocumento.ParameterName = "Documento";
                paramUpdDocumento.DbType = DbType.Int32;
                paramUpdDocumento.Value = (object)entity.Documento ?? DBNull.Value;
                var paramUpdFecha_de_Firma_de_Contrato = _dataProvider.GetParameter();
                paramUpdFecha_de_Firma_de_Contrato.ParameterName = "Fecha_de_Firma_de_Contrato";
                paramUpdFecha_de_Firma_de_Contrato.DbType = DbType.DateTime;
                paramUpdFecha_de_Firma_de_Contrato.Value = (object)entity.Fecha_de_Firma_de_Contrato ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Contratos_Empresa>("sp_UpdDetalle_Contratos_Empresa" , paramUpdFolio , paramUpdFolio_Empresas , paramUpdSuscripcion , paramUpdTipo_de_Contrato , paramUpdDocumento , paramUpdFecha_de_Firma_de_Contrato ).FirstOrDefault();

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


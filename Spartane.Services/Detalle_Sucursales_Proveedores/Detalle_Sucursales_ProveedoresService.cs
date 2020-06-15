using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Sucursales_Proveedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Sucursales_Proveedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Sucursales_ProveedoresService : IDetalle_Sucursales_ProveedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> _Detalle_Sucursales_ProveedoresRepository;
        #endregion

        #region Ctor
        public Detalle_Sucursales_ProveedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> Detalle_Sucursales_ProveedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Sucursales_ProveedoresRepository = Detalle_Sucursales_ProveedoresRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores>("sp_SelAllDetalle_Sucursales_Proveedores");
        }

        public IList<Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Sucursales_Proveedores_Complete>("sp_SelAllComplete_Detalle_Sucursales_Proveedores");
            return data.Select(m => new Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores
            {
                Folio = m.Folio
                ,FolioProveedores = m.FolioProveedores
                ,Tipo_de_Sucursal_Tipo_de_Sucursal = new Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal() { Clave = m.Tipo_de_Sucursal.GetValueOrDefault(), Descripcion = m.Tipo_de_Sucursal_Descripcion }
                ,Email = m.Email
                ,Telefono = m.Telefono
                ,Calle = m.Calle
                ,Numero_exterior = m.Numero_exterior
                ,Numero_interior = m.Numero_interior
                ,Colonia = m.Colonia
                ,C_P_ = m.C_P_
                ,Ciudad = m.Ciudad
                ,Estado = m.Estado
                ,Pais = m.Pais


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Sucursales_Proveedores>("sp_ListSelCount_Detalle_Sucursales_Proveedores", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Sucursales_Proveedores>("sp_ListSelAll_Detalle_Sucursales_Proveedores", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores
                {
                    Folio = m.Detalle_Sucursales_Proveedores_Folio,
                    FolioProveedores = m.Detalle_Sucursales_Proveedores_FolioProveedores,
                    Tipo_de_Sucursal = m.Detalle_Sucursales_Proveedores_Tipo_de_Sucursal,
                    Email = m.Detalle_Sucursales_Proveedores_Email,
                    Telefono = m.Detalle_Sucursales_Proveedores_Telefono,
                    Calle = m.Detalle_Sucursales_Proveedores_Calle,
                    Numero_exterior = m.Detalle_Sucursales_Proveedores_Numero_exterior,
                    Numero_interior = m.Detalle_Sucursales_Proveedores_Numero_interior,
                    Colonia = m.Detalle_Sucursales_Proveedores_Colonia,
                    C_P_ = m.Detalle_Sucursales_Proveedores_C_P_,
                    Ciudad = m.Detalle_Sucursales_Proveedores_Ciudad,
                    Estado = m.Detalle_Sucursales_Proveedores_Estado,
                    Pais = m.Detalle_Sucursales_Proveedores_Pais,

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

        public IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Sucursales_Proveedores>("sp_ListSelAll_Detalle_Sucursales_Proveedores", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Sucursales_ProveedoresPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Sucursales_ProveedoresPagingModel
                {
                    Detalle_Sucursales_Proveedoress =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores
                {
                    Folio = m.Detalle_Sucursales_Proveedores_Folio
                    ,FolioProveedores = m.Detalle_Sucursales_Proveedores_FolioProveedores
                    ,Tipo_de_Sucursal = m.Detalle_Sucursales_Proveedores_Tipo_de_Sucursal
                    ,Tipo_de_Sucursal_Tipo_de_Sucursal = new Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal() { Clave = m.Detalle_Sucursales_Proveedores_Tipo_de_Sucursal.GetValueOrDefault(), Descripcion = m.Detalle_Sucursales_Proveedores_Tipo_de_Sucursal_Descripcion }
                    ,Email = m.Detalle_Sucursales_Proveedores_Email
                    ,Telefono = m.Detalle_Sucursales_Proveedores_Telefono
                    ,Calle = m.Detalle_Sucursales_Proveedores_Calle
                    ,Numero_exterior = m.Detalle_Sucursales_Proveedores_Numero_exterior
                    ,Numero_interior = m.Detalle_Sucursales_Proveedores_Numero_interior
                    ,Colonia = m.Detalle_Sucursales_Proveedores_Colonia
                    ,C_P_ = m.Detalle_Sucursales_Proveedores_C_P_
                    ,Ciudad = m.Detalle_Sucursales_Proveedores_Ciudad
                    ,Estado = m.Detalle_Sucursales_Proveedores_Estado
                    ,Pais = m.Detalle_Sucursales_Proveedores_Pais

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores>("sp_GetDetalle_Sucursales_Proveedores", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Sucursales_Proveedores>("sp_DelDetalle_Sucursales_Proveedores", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolioProveedores = _dataProvider.GetParameter();
                padreFolioProveedores.ParameterName = "FolioProveedores";
                padreFolioProveedores.DbType = DbType.Int32;
                padreFolioProveedores.Value = (object)entity.FolioProveedores ?? DBNull.Value;
                var padreTipo_de_Sucursal = _dataProvider.GetParameter();
                padreTipo_de_Sucursal.ParameterName = "Tipo_de_Sucursal";
                padreTipo_de_Sucursal.DbType = DbType.Int32;
                padreTipo_de_Sucursal.Value = (object)entity.Tipo_de_Sucursal ?? DBNull.Value;

                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
                var padreTelefono = _dataProvider.GetParameter();
                padreTelefono.ParameterName = "Telefono";
                padreTelefono.DbType = DbType.String;
                padreTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var padreCalle = _dataProvider.GetParameter();
                padreCalle.ParameterName = "Calle";
                padreCalle.DbType = DbType.String;
                padreCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var padreNumero_exterior = _dataProvider.GetParameter();
                padreNumero_exterior.ParameterName = "Numero_exterior";
                padreNumero_exterior.DbType = DbType.Int32;
                padreNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;

                var padreNumero_interior = _dataProvider.GetParameter();
                padreNumero_interior.ParameterName = "Numero_interior";
                padreNumero_interior.DbType = DbType.Int32;
                padreNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;

                var padreColonia = _dataProvider.GetParameter();
                padreColonia.ParameterName = "Colonia";
                padreColonia.DbType = DbType.String;
                padreColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var padreC_P_ = _dataProvider.GetParameter();
                padreC_P_.ParameterName = "C_P_";
                padreC_P_.DbType = DbType.Int32;
                padreC_P_.Value = (object)entity.C_P_ ?? DBNull.Value;

                var padreCiudad = _dataProvider.GetParameter();
                padreCiudad.ParameterName = "Ciudad";
                padreCiudad.DbType = DbType.String;
                padreCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var padreEstado = _dataProvider.GetParameter();
                padreEstado.ParameterName = "Estado";
                padreEstado.DbType = DbType.String;
                padreEstado.Value = (object)entity.Estado ?? DBNull.Value;
                var padrePais = _dataProvider.GetParameter();
                padrePais.ParameterName = "Pais";
                padrePais.DbType = DbType.String;
                padrePais.Value = (object)entity.Pais ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Sucursales_Proveedores>("sp_InsDetalle_Sucursales_Proveedores" , padreFolioProveedores
, padreTipo_de_Sucursal
, padreEmail
, padreTelefono
, padreCalle
, padreNumero_exterior
, padreNumero_interior
, padreColonia
, padreC_P_
, padreCiudad
, padreEstado
, padrePais
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

        public int Update(Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolioProveedores = _dataProvider.GetParameter();
                paramUpdFolioProveedores.ParameterName = "FolioProveedores";
                paramUpdFolioProveedores.DbType = DbType.Int32;
                paramUpdFolioProveedores.Value = (object)entity.FolioProveedores ?? DBNull.Value;
                var paramUpdTipo_de_Sucursal = _dataProvider.GetParameter();
                paramUpdTipo_de_Sucursal.ParameterName = "Tipo_de_Sucursal";
                paramUpdTipo_de_Sucursal.DbType = DbType.Int32;
                paramUpdTipo_de_Sucursal.Value = (object)entity.Tipo_de_Sucursal ?? DBNull.Value;

                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.Int32;
                paramUpdNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;

                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.Int32;
                paramUpdNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;

                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var paramUpdC_P_ = _dataProvider.GetParameter();
                paramUpdC_P_.ParameterName = "C_P_";
                paramUpdC_P_.DbType = DbType.Int32;
                paramUpdC_P_.Value = (object)entity.C_P_ ?? DBNull.Value;

                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.String;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;
                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.String;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Sucursales_Proveedores>("sp_UpdDetalle_Sucursales_Proveedores" , paramUpdFolio , paramUpdFolioProveedores , paramUpdTipo_de_Sucursal , paramUpdEmail , paramUpdTelefono , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdC_P_ , paramUpdCiudad , paramUpdEstado , paramUpdPais ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores Detalle_Sucursales_ProveedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolioProveedores = _dataProvider.GetParameter();
                paramUpdFolioProveedores.ParameterName = "FolioProveedores";
                paramUpdFolioProveedores.DbType = DbType.Int32;
                paramUpdFolioProveedores.Value = (object)entity.FolioProveedores ?? DBNull.Value;
                var paramUpdTipo_de_Sucursal = _dataProvider.GetParameter();
                paramUpdTipo_de_Sucursal.ParameterName = "Tipo_de_Sucursal";
                paramUpdTipo_de_Sucursal.DbType = DbType.Int32;
                paramUpdTipo_de_Sucursal.Value = (object)entity.Tipo_de_Sucursal ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.Int32;
                paramUpdNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.Int32;
                paramUpdNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var paramUpdC_P_ = _dataProvider.GetParameter();
                paramUpdC_P_.ParameterName = "C_P_";
                paramUpdC_P_.DbType = DbType.Int32;
                paramUpdC_P_.Value = (object)entity.C_P_ ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.String;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;
                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.String;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Sucursales_Proveedores>("sp_UpdDetalle_Sucursales_Proveedores" , paramUpdFolio , paramUpdFolioProveedores , paramUpdTipo_de_Sucursal , paramUpdEmail , paramUpdTelefono , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdC_P_ , paramUpdCiudad , paramUpdEstado , paramUpdPais ).FirstOrDefault();

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


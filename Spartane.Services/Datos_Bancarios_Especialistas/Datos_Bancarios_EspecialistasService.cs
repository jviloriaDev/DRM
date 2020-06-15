using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Datos_Bancarios_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Datos_Bancarios_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Datos_Bancarios_EspecialistasService : IDatos_Bancarios_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> _Datos_Bancarios_EspecialistasRepository;
        #endregion

        #region Ctor
        public Datos_Bancarios_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> Datos_Bancarios_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Datos_Bancarios_EspecialistasRepository = Datos_Bancarios_EspecialistasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Datos_Bancarios_EspecialistasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas>("sp_SelAllDatos_Bancarios_Especialistas");
        }

        public IList<Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDatos_Bancarios_Especialistas_Complete>("sp_SelAllComplete_Datos_Bancarios_Especialistas");
            return data.Select(m => new Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas
            {
                Folio = m.Folio
                ,Folio_Especialistas = m.Folio_Especialistas
                ,Banco_Bancos = new Core.Classes.Bancos.Bancos() { Clave = m.Banco.GetValueOrDefault(), Nombre = m.Banco_Nombre }
                ,CLABE_Interbancaria = m.CLABE_Interbancaria
                ,Num_Cuenta = m.Num_Cuenta
                ,Nombre_del_Titular = m.Nombre_del_Titular
                ,Principal = m.Principal.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Datos_Bancarios_Especialistas>("sp_ListSelCount_Datos_Bancarios_Especialistas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDatos_Bancarios_Especialistas>("sp_ListSelAll_Datos_Bancarios_Especialistas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas
                {
                    Folio = m.Datos_Bancarios_Especialistas_Folio,
                    Folio_Especialistas = m.Datos_Bancarios_Especialistas_Folio_Especialistas,
                    Banco = m.Datos_Bancarios_Especialistas_Banco,
                    CLABE_Interbancaria = m.Datos_Bancarios_Especialistas_CLABE_Interbancaria,
                    Num_Cuenta = m.Datos_Bancarios_Especialistas_Num_Cuenta,
                    Nombre_del_Titular = m.Datos_Bancarios_Especialistas_Nombre_del_Titular,
                    Principal = m.Datos_Bancarios_Especialistas_Principal ?? false,

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

        public IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Datos_Bancarios_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Datos_Bancarios_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDatos_Bancarios_Especialistas>("sp_ListSelAll_Datos_Bancarios_Especialistas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Datos_Bancarios_EspecialistasPagingModel result = null;

            if (data != null)
            {
                result = new Datos_Bancarios_EspecialistasPagingModel
                {
                    Datos_Bancarios_Especialistass =
                        data.Select(m => new Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas
                {
                    Folio = m.Datos_Bancarios_Especialistas_Folio
                    ,Folio_Especialistas = m.Datos_Bancarios_Especialistas_Folio_Especialistas
                    ,Banco = m.Datos_Bancarios_Especialistas_Banco
                    ,Banco_Bancos = new Core.Classes.Bancos.Bancos() { Clave = m.Datos_Bancarios_Especialistas_Banco.GetValueOrDefault(), Nombre = m.Datos_Bancarios_Especialistas_Banco_Nombre }
                    ,CLABE_Interbancaria = m.Datos_Bancarios_Especialistas_CLABE_Interbancaria
                    ,Num_Cuenta = m.Datos_Bancarios_Especialistas_Num_Cuenta
                    ,Nombre_del_Titular = m.Datos_Bancarios_Especialistas_Nombre_del_Titular
                    ,Principal = m.Datos_Bancarios_Especialistas_Principal ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Datos_Bancarios_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas>("sp_GetDatos_Bancarios_Especialistas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDatos_Bancarios_Especialistas>("sp_DelDatos_Bancarios_Especialistas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas entity)
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
                var padreBanco = _dataProvider.GetParameter();
                padreBanco.ParameterName = "Banco";
                padreBanco.DbType = DbType.Int32;
                padreBanco.Value = (object)entity.Banco ?? DBNull.Value;

                var padreCLABE_Interbancaria = _dataProvider.GetParameter();
                padreCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                padreCLABE_Interbancaria.DbType = DbType.String;
                padreCLABE_Interbancaria.Value = (object)entity.CLABE_Interbancaria ?? DBNull.Value;
                var padreNum_Cuenta = _dataProvider.GetParameter();
                padreNum_Cuenta.ParameterName = "Num_Cuenta";
                padreNum_Cuenta.DbType = DbType.String;
                padreNum_Cuenta.Value = (object)entity.Num_Cuenta ?? DBNull.Value;
                var padreNombre_del_Titular = _dataProvider.GetParameter();
                padreNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                padreNombre_del_Titular.DbType = DbType.String;
                padreNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;
                var padrePrincipal = _dataProvider.GetParameter();
                padrePrincipal.ParameterName = "Principal";
                padrePrincipal.DbType = DbType.Boolean;
                padrePrincipal.Value = (object)entity.Principal ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDatos_Bancarios_Especialistas>("sp_InsDatos_Bancarios_Especialistas" , padreFolio_Especialistas
, padreBanco
, padreCLABE_Interbancaria
, padreNum_Cuenta
, padreNombre_del_Titular
, padrePrincipal
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

        public int Update(Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas entity)
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
                var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)entity.Banco ?? DBNull.Value;

                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)entity.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNum_Cuenta = _dataProvider.GetParameter();
                paramUpdNum_Cuenta.ParameterName = "Num_Cuenta";
                paramUpdNum_Cuenta.DbType = DbType.String;
                paramUpdNum_Cuenta.Value = (object)entity.Num_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;
                var paramUpdPrincipal = _dataProvider.GetParameter();
                paramUpdPrincipal.ParameterName = "Principal";
                paramUpdPrincipal.DbType = DbType.Boolean;
                paramUpdPrincipal.Value = (object)entity.Principal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDatos_Bancarios_Especialistas>("sp_UpdDatos_Bancarios_Especialistas" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNum_Cuenta , paramUpdNombre_del_Titular , paramUpdPrincipal ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas Datos_Bancarios_EspecialistasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Especialistas = _dataProvider.GetParameter();
                paramUpdFolio_Especialistas.ParameterName = "Folio_Especialistas";
                paramUpdFolio_Especialistas.DbType = DbType.Int32;
                paramUpdFolio_Especialistas.Value = (object)entity.Folio_Especialistas ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)entity.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)entity.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNum_Cuenta = _dataProvider.GetParameter();
                paramUpdNum_Cuenta.ParameterName = "Num_Cuenta";
                paramUpdNum_Cuenta.DbType = DbType.String;
                paramUpdNum_Cuenta.Value = (object)entity.Num_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;
                var paramUpdPrincipal = _dataProvider.GetParameter();
                paramUpdPrincipal.ParameterName = "Principal";
                paramUpdPrincipal.DbType = DbType.Boolean;
                paramUpdPrincipal.Value = (object)entity.Principal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDatos_Bancarios_Especialistas>("sp_UpdDatos_Bancarios_Especialistas" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNum_Cuenta , paramUpdNombre_del_Titular , paramUpdPrincipal ).FirstOrDefault();

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


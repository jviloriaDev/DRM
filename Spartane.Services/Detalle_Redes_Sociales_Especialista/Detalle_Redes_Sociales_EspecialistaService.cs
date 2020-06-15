using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Redes_Sociales_Especialista
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Redes_Sociales_EspecialistaService : IDetalle_Redes_Sociales_EspecialistaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> _Detalle_Redes_Sociales_EspecialistaRepository;
        #endregion

        #region Ctor
        public Detalle_Redes_Sociales_EspecialistaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> Detalle_Redes_Sociales_EspecialistaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Redes_Sociales_EspecialistaRepository = Detalle_Redes_Sociales_EspecialistaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista>("sp_SelAllDetalle_Redes_Sociales_Especialista");
        }

        public IList<Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Redes_Sociales_Especialista_Complete>("sp_SelAllComplete_Detalle_Redes_Sociales_Especialista");
            return data.Select(m => new Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista
            {
                Folio = m.Folio
                ,Folio_Especialistas = m.Folio_Especialistas
                ,Red_Social_Redes_sociales = new Core.Classes.Redes_sociales.Redes_sociales() { Clave = m.Red_Social.GetValueOrDefault(), Descripcion = m.Red_Social_Descripcion }
                ,URL = m.URL
                ,Principal = m.Principal.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Redes_Sociales_Especialista>("sp_ListSelCount_Detalle_Redes_Sociales_Especialista", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Redes_Sociales_Especialista>("sp_ListSelAll_Detalle_Redes_Sociales_Especialista", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista
                {
                    Folio = m.Detalle_Redes_Sociales_Especialista_Folio,
                    Folio_Especialistas = m.Detalle_Redes_Sociales_Especialista_Folio_Especialistas,
                    Red_Social = m.Detalle_Redes_Sociales_Especialista_Red_Social,
                    URL = m.Detalle_Redes_Sociales_Especialista_URL,
                    Principal = m.Detalle_Redes_Sociales_Especialista_Principal ?? false,

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

        public IList<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_EspecialistaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Redes_Sociales_Especialista>("sp_ListSelAll_Detalle_Redes_Sociales_Especialista", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Redes_Sociales_EspecialistaPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Redes_Sociales_EspecialistaPagingModel
                {
                    Detalle_Redes_Sociales_Especialistas =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista
                {
                    Folio = m.Detalle_Redes_Sociales_Especialista_Folio
                    ,Folio_Especialistas = m.Detalle_Redes_Sociales_Especialista_Folio_Especialistas
                    ,Red_Social = m.Detalle_Redes_Sociales_Especialista_Red_Social
                    ,Red_Social_Redes_sociales = new Core.Classes.Redes_sociales.Redes_sociales() { Clave = m.Detalle_Redes_Sociales_Especialista_Red_Social.GetValueOrDefault(), Descripcion = m.Detalle_Redes_Sociales_Especialista_Red_Social_Descripcion }
                    ,URL = m.Detalle_Redes_Sociales_Especialista_URL
                    ,Principal = m.Detalle_Redes_Sociales_Especialista_Principal ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista>("sp_GetDetalle_Redes_Sociales_Especialista", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Redes_Sociales_Especialista>("sp_DelDetalle_Redes_Sociales_Especialista", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista entity)
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
                var padreRed_Social = _dataProvider.GetParameter();
                padreRed_Social.ParameterName = "Red_Social";
                padreRed_Social.DbType = DbType.Int32;
                padreRed_Social.Value = (object)entity.Red_Social ?? DBNull.Value;

                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = (object)entity.URL ?? DBNull.Value;
                var padrePrincipal = _dataProvider.GetParameter();
                padrePrincipal.ParameterName = "Principal";
                padrePrincipal.DbType = DbType.Boolean;
                padrePrincipal.Value = (object)entity.Principal ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Redes_Sociales_Especialista>("sp_InsDetalle_Redes_Sociales_Especialista" , padreFolio_Especialistas
, padreRed_Social
, padreURL
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

        public int Update(Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista entity)
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
                var paramUpdRed_Social = _dataProvider.GetParameter();
                paramUpdRed_Social.ParameterName = "Red_Social";
                paramUpdRed_Social.DbType = DbType.Int32;
                paramUpdRed_Social.Value = (object)entity.Red_Social ?? DBNull.Value;

                var paramUpdURL = _dataProvider.GetParameter();
                paramUpdURL.ParameterName = "URL";
                paramUpdURL.DbType = DbType.String;
                paramUpdURL.Value = (object)entity.URL ?? DBNull.Value;
                var paramUpdPrincipal = _dataProvider.GetParameter();
                paramUpdPrincipal.ParameterName = "Principal";
                paramUpdPrincipal.DbType = DbType.Boolean;
                paramUpdPrincipal.Value = (object)entity.Principal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Redes_Sociales_Especialista>("sp_UpdDetalle_Redes_Sociales_Especialista" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdRed_Social , paramUpdURL , paramUpdPrincipal ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista Detalle_Redes_Sociales_EspecialistaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Especialistas = _dataProvider.GetParameter();
                paramUpdFolio_Especialistas.ParameterName = "Folio_Especialistas";
                paramUpdFolio_Especialistas.DbType = DbType.Int32;
                paramUpdFolio_Especialistas.Value = (object)entity.Folio_Especialistas ?? DBNull.Value;
		var paramUpdRed_Social = _dataProvider.GetParameter();
                paramUpdRed_Social.ParameterName = "Red_Social";
                paramUpdRed_Social.DbType = DbType.Int32;
                paramUpdRed_Social.Value = (object)entity.Red_Social ?? DBNull.Value;
                var paramUpdURL = _dataProvider.GetParameter();
                paramUpdURL.ParameterName = "URL";
                paramUpdURL.DbType = DbType.String;
                paramUpdURL.Value = (object)entity.URL ?? DBNull.Value;
                var paramUpdPrincipal = _dataProvider.GetParameter();
                paramUpdPrincipal.ParameterName = "Principal";
                paramUpdPrincipal.DbType = DbType.Boolean;
                paramUpdPrincipal.Value = (object)entity.Principal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Redes_Sociales_Especialista>("sp_UpdDetalle_Redes_Sociales_Especialista" , paramUpdFolio , paramUpdFolio_Especialistas , paramUpdRed_Social , paramUpdURL , paramUpdPrincipal ).FirstOrDefault();

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


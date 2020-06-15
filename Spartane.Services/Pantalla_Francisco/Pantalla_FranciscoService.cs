using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Pantalla_Francisco;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Pantalla_Francisco
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Pantalla_FranciscoService : IPantalla_FranciscoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco> _Pantalla_FranciscoRepository;
        #endregion

        #region Ctor
        public Pantalla_FranciscoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco> Pantalla_FranciscoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Pantalla_FranciscoRepository = Pantalla_FranciscoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Pantalla_FranciscoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco>("sp_SelAllPantalla_Francisco");
        }

        public IList<Core.Classes.Pantalla_Francisco.Pantalla_Francisco> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPantalla_Francisco_Complete>("sp_SelAllComplete_Pantalla_Francisco");
            return data.Select(m => new Core.Classes.Pantalla_Francisco.Pantalla_Francisco
            {
                Folio = m.Folio
                ,Campo = m.Campo


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Pantalla_Francisco>("sp_ListSelCount_Pantalla_Francisco", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPantalla_Francisco>("sp_ListSelAll_Pantalla_Francisco", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco
                {
                    Folio = m.Pantalla_Francisco_Folio,
                    Campo = m.Pantalla_Francisco_Campo,

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

        public IList<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Pantalla_FranciscoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Pantalla_FranciscoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Pantalla_Francisco.Pantalla_FranciscoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPantalla_Francisco>("sp_ListSelAll_Pantalla_Francisco", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Pantalla_FranciscoPagingModel result = null;

            if (data != null)
            {
                result = new Pantalla_FranciscoPagingModel
                {
                    Pantalla_Franciscos =
                        data.Select(m => new Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco
                {
                    Folio = m.Pantalla_Francisco_Folio
                    ,Campo = m.Pantalla_Francisco_Campo

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Pantalla_FranciscoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco>("sp_GetPantalla_Francisco", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPantalla_Francisco>("sp_DelPantalla_Francisco", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreCampo = _dataProvider.GetParameter();
                padreCampo.ParameterName = "Campo";
                padreCampo.DbType = DbType.String;
                padreCampo.Value = (object)entity.Campo ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPantalla_Francisco>("sp_InsPantalla_Francisco" , padreCampo
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

        public int Update(Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdCampo = _dataProvider.GetParameter();
                paramUpdCampo.ParameterName = "Campo";
                paramUpdCampo.DbType = DbType.String;
                paramUpdCampo.Value = (object)entity.Campo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPantalla_Francisco>("sp_UpdPantalla_Francisco" , paramUpdFolio , paramUpdCampo ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco Pantalla_FranciscoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdCampo = _dataProvider.GetParameter();
                paramUpdCampo.ParameterName = "Campo";
                paramUpdCampo.DbType = DbType.String;
                paramUpdCampo.Value = (object)entity.Campo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPantalla_Francisco>("sp_UpdPantalla_Francisco" , paramUpdFolio , paramUpdCampo ).FirstOrDefault();

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


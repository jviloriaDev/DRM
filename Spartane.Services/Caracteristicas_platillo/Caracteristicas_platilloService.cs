using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Caracteristicas_platillo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Caracteristicas_platillo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Caracteristicas_platilloService : ICaracteristicas_platilloService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> _Caracteristicas_platilloRepository;
        #endregion

        #region Ctor
        public Caracteristicas_platilloService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> Caracteristicas_platilloRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Caracteristicas_platilloRepository = Caracteristicas_platilloRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Caracteristicas_platilloRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo>("sp_SelAllCaracteristicas_platillo");
        }

        public IList<Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCaracteristicas_platillo_Complete>("sp_SelAllComplete_Caracteristicas_platillo");
            return data.Select(m => new Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo
            {
                Folio = m.Folio
                ,Caracteristicas = m.Caracteristicas


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Caracteristicas_platillo>("sp_ListSelCount_Caracteristicas_platillo", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCaracteristicas_platillo>("sp_ListSelAll_Caracteristicas_platillo", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo
                {
                    Folio = m.Caracteristicas_platillo_Folio,
                    Caracteristicas = m.Caracteristicas_platillo_Caracteristicas,

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

        public IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Caracteristicas_platilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Caracteristicas_platilloRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCaracteristicas_platillo>("sp_ListSelAll_Caracteristicas_platillo", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Caracteristicas_platilloPagingModel result = null;

            if (data != null)
            {
                result = new Caracteristicas_platilloPagingModel
                {
                    Caracteristicas_platillos =
                        data.Select(m => new Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo
                {
                    Folio = m.Caracteristicas_platillo_Folio
                    ,Caracteristicas = m.Caracteristicas_platillo_Caracteristicas

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Caracteristicas_platilloRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo>("sp_GetCaracteristicas_platillo", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCaracteristicas_platillo>("sp_DelCaracteristicas_platillo", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreCaracteristicas = _dataProvider.GetParameter();
                padreCaracteristicas.ParameterName = "Caracteristicas";
                padreCaracteristicas.DbType = DbType.String;
                padreCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCaracteristicas_platillo>("sp_InsCaracteristicas_platillo" , padreCaracteristicas
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

        public int Update(Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdCaracteristicas = _dataProvider.GetParameter();
                paramUpdCaracteristicas.ParameterName = "Caracteristicas";
                paramUpdCaracteristicas.DbType = DbType.String;
                paramUpdCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCaracteristicas_platillo>("sp_UpdCaracteristicas_platillo" , paramUpdFolio , paramUpdCaracteristicas ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo Caracteristicas_platilloDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdCaracteristicas = _dataProvider.GetParameter();
                paramUpdCaracteristicas.ParameterName = "Caracteristicas";
                paramUpdCaracteristicas.DbType = DbType.String;
                paramUpdCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCaracteristicas_platillo>("sp_UpdCaracteristicas_platillo" , paramUpdFolio , paramUpdCaracteristicas ).FirstOrDefault();

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


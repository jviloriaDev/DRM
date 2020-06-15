using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Cantidad_fraccion_platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Cantidad_fraccion_platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Cantidad_fraccion_platillosService : ICantidad_fraccion_platillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> _Cantidad_fraccion_platillosRepository;
        #endregion

        #region Ctor
        public Cantidad_fraccion_platillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> Cantidad_fraccion_platillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Cantidad_fraccion_platillosRepository = Cantidad_fraccion_platillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Cantidad_fraccion_platillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>("sp_SelAllCantidad_fraccion_platillos");
        }

        public IList<Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCantidad_fraccion_platillos_Complete>("sp_SelAllComplete_Cantidad_fraccion_platillos");
            return data.Select(m => new Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos
            {
                Folio = m.Folio
                ,Cantidad = m.Cantidad


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Cantidad_fraccion_platillos>("sp_ListSelCount_Cantidad_fraccion_platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCantidad_fraccion_platillos>("sp_ListSelAll_Cantidad_fraccion_platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos
                {
                    Folio = m.Cantidad_fraccion_platillos_Folio,
                    Cantidad = m.Cantidad_fraccion_platillos_Cantidad,

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

        public IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCantidad_fraccion_platillos>("sp_ListSelAll_Cantidad_fraccion_platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Cantidad_fraccion_platillosPagingModel result = null;

            if (data != null)
            {
                result = new Cantidad_fraccion_platillosPagingModel
                {
                    Cantidad_fraccion_platilloss =
                        data.Select(m => new Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos
                {
                    Folio = m.Cantidad_fraccion_platillos_Folio
                    ,Cantidad = m.Cantidad_fraccion_platillos_Cantidad

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>("sp_GetCantidad_fraccion_platillos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCantidad_fraccion_platillos>("sp_DelCantidad_fraccion_platillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.String;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCantidad_fraccion_platillos>("sp_InsCantidad_fraccion_platillos" , padreCantidad
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

        public int Update(Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCantidad_fraccion_platillos>("sp_UpdCantidad_fraccion_platillos" , paramUpdFolio , paramUpdCantidad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos Cantidad_fraccion_platillosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCantidad_fraccion_platillos>("sp_UpdCantidad_fraccion_platillos" , paramUpdFolio , paramUpdCantidad ).FirstOrDefault();

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


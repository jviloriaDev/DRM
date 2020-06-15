using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Cantidad_Comidas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Cantidad_Comidas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Cantidad_ComidasService : ICantidad_ComidasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> _Cantidad_ComidasRepository;
        #endregion

        #region Ctor
        public Cantidad_ComidasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> Cantidad_ComidasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Cantidad_ComidasRepository = Cantidad_ComidasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Cantidad_ComidasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas>("sp_SelAllCantidad_Comidas");
        }

        public IList<Core.Classes.Cantidad_Comidas.Cantidad_Comidas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCantidad_Comidas_Complete>("sp_SelAllComplete_Cantidad_Comidas");
            return data.Select(m => new Core.Classes.Cantidad_Comidas.Cantidad_Comidas
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Cantidad_Comidas>("sp_ListSelCount_Cantidad_Comidas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCantidad_Comidas>("sp_ListSelAll_Cantidad_Comidas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas
                {
                    Clave = m.Cantidad_Comidas_Clave,
                    Descripcion = m.Cantidad_Comidas_Descripcion,

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

        public IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Cantidad_ComidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Cantidad_ComidasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Cantidad_Comidas.Cantidad_ComidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCantidad_Comidas>("sp_ListSelAll_Cantidad_Comidas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Cantidad_ComidasPagingModel result = null;

            if (data != null)
            {
                result = new Cantidad_ComidasPagingModel
                {
                    Cantidad_Comidass =
                        data.Select(m => new Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas
                {
                    Clave = m.Cantidad_Comidas_Clave
                    ,Descripcion = m.Cantidad_Comidas_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Cantidad_ComidasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas>("sp_GetCantidad_Comidas", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCantidad_Comidas>("sp_DelCantidad_Comidas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCantidad_Comidas>("sp_InsCantidad_Comidas" , padreDescripcion
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

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

        public int Update(Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCantidad_Comidas>("sp_UpdCantidad_Comidas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas Cantidad_ComidasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCantidad_Comidas>("sp_UpdCantidad_Comidas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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


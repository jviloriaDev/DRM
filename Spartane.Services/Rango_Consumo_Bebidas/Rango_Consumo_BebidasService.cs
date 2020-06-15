using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Rango_Consumo_Bebidas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rango_Consumo_Bebidas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Rango_Consumo_BebidasService : IRango_Consumo_BebidasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> _Rango_Consumo_BebidasRepository;
        #endregion

        #region Ctor
        public Rango_Consumo_BebidasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> Rango_Consumo_BebidasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Rango_Consumo_BebidasRepository = Rango_Consumo_BebidasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Rango_Consumo_BebidasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>("sp_SelAllRango_Consumo_Bebidas");
        }

        public IList<Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRango_Consumo_Bebidas_Complete>("sp_SelAllComplete_Rango_Consumo_Bebidas");
            return data.Select(m => new Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Rango_Consumo_Bebidas>("sp_ListSelCount_Rango_Consumo_Bebidas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRango_Consumo_Bebidas>("sp_ListSelAll_Rango_Consumo_Bebidas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas
                {
                    Clave = m.Rango_Consumo_Bebidas_Clave,
                    Descripcion = m.Rango_Consumo_Bebidas_Descripcion,

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

        public IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Rango_Consumo_BebidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rango_Consumo_BebidasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRango_Consumo_Bebidas>("sp_ListSelAll_Rango_Consumo_Bebidas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Rango_Consumo_BebidasPagingModel result = null;

            if (data != null)
            {
                result = new Rango_Consumo_BebidasPagingModel
                {
                    Rango_Consumo_Bebidass =
                        data.Select(m => new Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas
                {
                    Clave = m.Rango_Consumo_Bebidas_Clave
                    ,Descripcion = m.Rango_Consumo_Bebidas_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Rango_Consumo_BebidasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>("sp_GetRango_Consumo_Bebidas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRango_Consumo_Bebidas>("sp_DelRango_Consumo_Bebidas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRango_Consumo_Bebidas>("sp_InsRango_Consumo_Bebidas" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRango_Consumo_Bebidas>("sp_UpdRango_Consumo_Bebidas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas Rango_Consumo_BebidasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRango_Consumo_Bebidas>("sp_UpdRango_Consumo_Bebidas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


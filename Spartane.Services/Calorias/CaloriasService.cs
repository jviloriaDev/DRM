using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Calorias;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Calorias
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class CaloriasService : ICaloriasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Calorias.Calorias> _CaloriasRepository;
        #endregion

        #region Ctor
        public CaloriasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Calorias.Calorias> CaloriasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._CaloriasRepository = CaloriasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._CaloriasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Calorias.Calorias> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Calorias.Calorias>("sp_SelAllCalorias");
        }

        public IList<Core.Classes.Calorias.Calorias> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCalorias_Complete>("sp_SelAllComplete_Calorias");
            return data.Select(m => new Core.Classes.Calorias.Calorias
            {
                Clave = m.Clave
                ,Cantidad = m.Cantidad


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Calorias>("sp_ListSelCount_Calorias", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Calorias.Calorias> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCalorias>("sp_ListSelAll_Calorias", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Calorias.Calorias
                {
                    Clave = m.Calorias_Clave,
                    Cantidad = m.Calorias_Cantidad,

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

        public IList<Spartane.Core.Classes.Calorias.Calorias> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._CaloriasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Calorias.Calorias> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._CaloriasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Calorias.CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCalorias>("sp_ListSelAll_Calorias", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            CaloriasPagingModel result = null;

            if (data != null)
            {
                result = new CaloriasPagingModel
                {
                    Caloriass =
                        data.Select(m => new Spartane.Core.Classes.Calorias.Calorias
                {
                    Clave = m.Calorias_Clave
                    ,Cantidad = m.Calorias_Cantidad

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Calorias.Calorias> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._CaloriasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Calorias.Calorias GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Calorias.Calorias>("sp_GetCalorias", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCalorias>("sp_DelCalorias", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Calorias.Calorias entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.String;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCalorias>("sp_InsCalorias" , padreCantidad
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

        public int Update(Spartane.Core.Classes.Calorias.Calorias entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCalorias>("sp_UpdCalorias" , paramUpdClave , paramUpdCantidad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Calorias.Calorias entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Calorias.Calorias CaloriasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCalorias>("sp_UpdCalorias" , paramUpdClave , paramUpdCantidad ).FirstOrDefault();

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


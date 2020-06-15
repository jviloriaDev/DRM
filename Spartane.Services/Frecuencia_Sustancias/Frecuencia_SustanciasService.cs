using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Frecuencia_Sustancias;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Frecuencia_Sustancias
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Frecuencia_SustanciasService : IFrecuencia_SustanciasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> _Frecuencia_SustanciasRepository;
        #endregion

        #region Ctor
        public Frecuencia_SustanciasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> Frecuencia_SustanciasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Frecuencia_SustanciasRepository = Frecuencia_SustanciasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Frecuencia_SustanciasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias>("sp_SelAllFrecuencia_Sustancias");
        }

        public IList<Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallFrecuencia_Sustancias_Complete>("sp_SelAllComplete_Frecuencia_Sustancias");
            return data.Select(m => new Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Frecuencia_Sustancias>("sp_ListSelCount_Frecuencia_Sustancias", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFrecuencia_Sustancias>("sp_ListSelAll_Frecuencia_Sustancias", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias
                {
                    Clave = m.Frecuencia_Sustancias_Clave,
                    Descripcion = m.Frecuencia_Sustancias_Descripcion,

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

        public IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Frecuencia_SustanciasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_SustanciasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_SustanciasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFrecuencia_Sustancias>("sp_ListSelAll_Frecuencia_Sustancias", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Frecuencia_SustanciasPagingModel result = null;

            if (data != null)
            {
                result = new Frecuencia_SustanciasPagingModel
                {
                    Frecuencia_Sustanciass =
                        data.Select(m => new Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias
                {
                    Clave = m.Frecuencia_Sustancias_Clave
                    ,Descripcion = m.Frecuencia_Sustancias_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Frecuencia_SustanciasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias>("sp_GetFrecuencia_Sustancias", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelFrecuencia_Sustancias>("sp_DelFrecuencia_Sustancias", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsFrecuencia_Sustancias>("sp_InsFrecuencia_Sustancias" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFrecuencia_Sustancias>("sp_UpdFrecuencia_Sustancias" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias Frecuencia_SustanciasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFrecuencia_Sustancias>("sp_UpdFrecuencia_Sustancias" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


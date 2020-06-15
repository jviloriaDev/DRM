using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Antiguedad_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Antiguedad_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Antiguedad_EjerciciosService : IAntiguedad_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> _Antiguedad_EjerciciosRepository;
        #endregion

        #region Ctor
        public Antiguedad_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> Antiguedad_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Antiguedad_EjerciciosRepository = Antiguedad_EjerciciosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Antiguedad_EjerciciosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios>("sp_SelAllAntiguedad_Ejercicios");
        }

        public IList<Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallAntiguedad_Ejercicios_Complete>("sp_SelAllComplete_Antiguedad_Ejercicios");
            return data.Select(m => new Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Antiguedad_Ejercicios>("sp_ListSelCount_Antiguedad_Ejercicios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllAntiguedad_Ejercicios>("sp_ListSelAll_Antiguedad_Ejercicios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios
                {
                    Clave = m.Antiguedad_Ejercicios_Clave,
                    Descripcion = m.Antiguedad_Ejercicios_Descripcion,

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

        public IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Antiguedad_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Antiguedad_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllAntiguedad_Ejercicios>("sp_ListSelAll_Antiguedad_Ejercicios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Antiguedad_EjerciciosPagingModel result = null;

            if (data != null)
            {
                result = new Antiguedad_EjerciciosPagingModel
                {
                    Antiguedad_Ejercicioss =
                        data.Select(m => new Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios
                {
                    Clave = m.Antiguedad_Ejercicios_Clave
                    ,Descripcion = m.Antiguedad_Ejercicios_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Antiguedad_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios>("sp_GetAntiguedad_Ejercicios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelAntiguedad_Ejercicios>("sp_DelAntiguedad_Ejercicios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsAntiguedad_Ejercicios>("sp_InsAntiguedad_Ejercicios" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdAntiguedad_Ejercicios>("sp_UpdAntiguedad_Ejercicios" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios Antiguedad_EjerciciosDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdAntiguedad_Ejercicios>("sp_UpdAntiguedad_Ejercicios" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


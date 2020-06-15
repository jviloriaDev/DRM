using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Seleccion_de_Rangos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Seleccion_de_Rangos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Seleccion_de_RangosService : ISeleccion_de_RangosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> _Seleccion_de_RangosRepository;
        #endregion

        #region Ctor
        public Seleccion_de_RangosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> Seleccion_de_RangosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Seleccion_de_RangosRepository = Seleccion_de_RangosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Seleccion_de_RangosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos>("sp_SelAllSeleccion_de_Rangos");
        }

        public IList<Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSeleccion_de_Rangos_Complete>("sp_SelAllComplete_Seleccion_de_Rangos");
            return data.Select(m => new Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Seleccion_de_Rangos>("sp_ListSelCount_Seleccion_de_Rangos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSeleccion_de_Rangos>("sp_ListSelAll_Seleccion_de_Rangos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos
                {
                    Clave = m.Seleccion_de_Rangos_Clave,
                    Descripcion = m.Seleccion_de_Rangos_Descripcion,

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

        public IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Seleccion_de_RangosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Seleccion_de_RangosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_RangosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSeleccion_de_Rangos>("sp_ListSelAll_Seleccion_de_Rangos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Seleccion_de_RangosPagingModel result = null;

            if (data != null)
            {
                result = new Seleccion_de_RangosPagingModel
                {
                    Seleccion_de_Rangoss =
                        data.Select(m => new Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos
                {
                    Clave = m.Seleccion_de_Rangos_Clave
                    ,Descripcion = m.Seleccion_de_Rangos_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Seleccion_de_RangosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos>("sp_GetSeleccion_de_Rangos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSeleccion_de_Rangos>("sp_DelSeleccion_de_Rangos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSeleccion_de_Rangos>("sp_InsSeleccion_de_Rangos" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSeleccion_de_Rangos>("sp_UpdSeleccion_de_Rangos" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos Seleccion_de_RangosDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSeleccion_de_Rangos>("sp_UpdSeleccion_de_Rangos" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


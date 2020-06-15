using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Nivel_de_Satisfaccion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Nivel_de_Satisfaccion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Nivel_de_SatisfaccionService : INivel_de_SatisfaccionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> _Nivel_de_SatisfaccionRepository;
        #endregion

        #region Ctor
        public Nivel_de_SatisfaccionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> Nivel_de_SatisfaccionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Nivel_de_SatisfaccionRepository = Nivel_de_SatisfaccionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Nivel_de_SatisfaccionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>("sp_SelAllNivel_de_Satisfaccion");
        }

        public IList<Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallNivel_de_Satisfaccion_Complete>("sp_SelAllComplete_Nivel_de_Satisfaccion");
            return data.Select(m => new Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Nivel_de_Satisfaccion>("sp_ListSelCount_Nivel_de_Satisfaccion", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllNivel_de_Satisfaccion>("sp_ListSelAll_Nivel_de_Satisfaccion", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion
                {
                    Clave = m.Nivel_de_Satisfaccion_Clave,
                    Descripcion = m.Nivel_de_Satisfaccion_Descripcion,

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

        public IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Nivel_de_SatisfaccionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nivel_de_SatisfaccionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_SatisfaccionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllNivel_de_Satisfaccion>("sp_ListSelAll_Nivel_de_Satisfaccion", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Nivel_de_SatisfaccionPagingModel result = null;

            if (data != null)
            {
                result = new Nivel_de_SatisfaccionPagingModel
                {
                    Nivel_de_Satisfaccions =
                        data.Select(m => new Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion
                {
                    Clave = m.Nivel_de_Satisfaccion_Clave
                    ,Descripcion = m.Nivel_de_Satisfaccion_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Nivel_de_SatisfaccionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>("sp_GetNivel_de_Satisfaccion", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelNivel_de_Satisfaccion>("sp_DelNivel_de_Satisfaccion", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsNivel_de_Satisfaccion>("sp_InsNivel_de_Satisfaccion" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdNivel_de_Satisfaccion>("sp_UpdNivel_de_Satisfaccion" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion Nivel_de_SatisfaccionDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdNivel_de_Satisfaccion>("sp_UpdNivel_de_Satisfaccion" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


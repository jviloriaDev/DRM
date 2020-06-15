using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Clasificacion_Ingredientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Clasificacion_Ingredientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Clasificacion_IngredientesService : IClasificacion_IngredientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> _Clasificacion_IngredientesRepository;
        #endregion

        #region Ctor
        public Clasificacion_IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> Clasificacion_IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Clasificacion_IngredientesRepository = Clasificacion_IngredientesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Clasificacion_IngredientesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes>("sp_SelAllClasificacion_Ingredientes");
        }

        public IList<Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallClasificacion_Ingredientes_Complete>("sp_SelAllComplete_Clasificacion_Ingredientes");
            return data.Select(m => new Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Clasificacion_Ingredientes>("sp_ListSelCount_Clasificacion_Ingredientes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllClasificacion_Ingredientes>("sp_ListSelAll_Clasificacion_Ingredientes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes
                {
                    Clave = m.Clasificacion_Ingredientes_Clave,
                    Descripcion = m.Clasificacion_Ingredientes_Descripcion,

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

        public IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Clasificacion_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Clasificacion_IngredientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllClasificacion_Ingredientes>("sp_ListSelAll_Clasificacion_Ingredientes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Clasificacion_IngredientesPagingModel result = null;

            if (data != null)
            {
                result = new Clasificacion_IngredientesPagingModel
                {
                    Clasificacion_Ingredientess =
                        data.Select(m => new Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes
                {
                    Clave = m.Clasificacion_Ingredientes_Clave
                    ,Descripcion = m.Clasificacion_Ingredientes_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Clasificacion_IngredientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes>("sp_GetClasificacion_Ingredientes", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelClasificacion_Ingredientes>("sp_DelClasificacion_Ingredientes", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsClasificacion_Ingredientes>("sp_InsClasificacion_Ingredientes" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdClasificacion_Ingredientes>("sp_UpdClasificacion_Ingredientes" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes Clasificacion_IngredientesDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdClasificacion_Ingredientes>("sp_UpdClasificacion_Ingredientes" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


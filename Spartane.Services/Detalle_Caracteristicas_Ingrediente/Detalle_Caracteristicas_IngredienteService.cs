using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Caracteristicas_Ingrediente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Caracteristicas_IngredienteService : IDetalle_Caracteristicas_IngredienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> _Detalle_Caracteristicas_IngredienteRepository;
        #endregion

        #region Ctor
        public Detalle_Caracteristicas_IngredienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> Detalle_Caracteristicas_IngredienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Caracteristicas_IngredienteRepository = Detalle_Caracteristicas_IngredienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>("sp_SelAllDetalle_Caracteristicas_Ingrediente");
        }

        public IList<Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Caracteristicas_Ingrediente_Complete>("sp_SelAllComplete_Detalle_Caracteristicas_Ingrediente");
            return data.Select(m => new Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente
            {
                Folio = m.Folio
                ,Folio_Ingrediente = m.Folio_Ingrediente
                ,Caracteristica_combo = m.Caracteristica_combo
                ,Descripcion_texto = m.Descripcion_texto


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Caracteristicas_Ingrediente>("sp_ListSelCount_Detalle_Caracteristicas_Ingrediente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Caracteristicas_Ingrediente>("sp_ListSelAll_Detalle_Caracteristicas_Ingrediente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente
                {
                    Folio = m.Detalle_Caracteristicas_Ingrediente_Folio,
                    Folio_Ingrediente = m.Detalle_Caracteristicas_Ingrediente_Folio_Ingrediente,
                    Caracteristica_combo = m.Detalle_Caracteristicas_Ingrediente_Caracteristica_combo,
                    Descripcion_texto = m.Detalle_Caracteristicas_Ingrediente_Descripcion_texto,

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

        public IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_IngredientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Caracteristicas_Ingrediente>("sp_ListSelAll_Detalle_Caracteristicas_Ingrediente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Caracteristicas_IngredientePagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Caracteristicas_IngredientePagingModel
                {
                    Detalle_Caracteristicas_Ingredientes =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente
                {
                    Folio = m.Detalle_Caracteristicas_Ingrediente_Folio
                    ,Folio_Ingrediente = m.Detalle_Caracteristicas_Ingrediente_Folio_Ingrediente
                    ,Caracteristica_combo = m.Detalle_Caracteristicas_Ingrediente_Caracteristica_combo
                    ,Descripcion_texto = m.Detalle_Caracteristicas_Ingrediente_Descripcion_texto

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>("sp_GetDetalle_Caracteristicas_Ingrediente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Caracteristicas_Ingrediente>("sp_DelDetalle_Caracteristicas_Ingrediente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Ingrediente = _dataProvider.GetParameter();
                padreFolio_Ingrediente.ParameterName = "Folio_Ingrediente";
                padreFolio_Ingrediente.DbType = DbType.Int32;
                padreFolio_Ingrediente.Value = (object)entity.Folio_Ingrediente ?? DBNull.Value;
                var padreCaracteristica_combo = _dataProvider.GetParameter();
                padreCaracteristica_combo.ParameterName = "Caracteristica_combo";
                padreCaracteristica_combo.DbType = DbType.String;
                padreCaracteristica_combo.Value = (object)entity.Caracteristica_combo ?? DBNull.Value;
                var padreDescripcion_texto = _dataProvider.GetParameter();
                padreDescripcion_texto.ParameterName = "Descripcion_texto";
                padreDescripcion_texto.DbType = DbType.String;
                padreDescripcion_texto.Value = (object)entity.Descripcion_texto ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Caracteristicas_Ingrediente>("sp_InsDetalle_Caracteristicas_Ingrediente" , padreFolio_Ingrediente
, padreCaracteristica_combo
, padreDescripcion_texto
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

        public int Update(Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Ingrediente = _dataProvider.GetParameter();
                paramUpdFolio_Ingrediente.ParameterName = "Folio_Ingrediente";
                paramUpdFolio_Ingrediente.DbType = DbType.Int32;
                paramUpdFolio_Ingrediente.Value = (object)entity.Folio_Ingrediente ?? DBNull.Value;
                var paramUpdCaracteristica_combo = _dataProvider.GetParameter();
                paramUpdCaracteristica_combo.ParameterName = "Caracteristica_combo";
                paramUpdCaracteristica_combo.DbType = DbType.String;
                paramUpdCaracteristica_combo.Value = (object)entity.Caracteristica_combo ?? DBNull.Value;
                var paramUpdDescripcion_texto = _dataProvider.GetParameter();
                paramUpdDescripcion_texto.ParameterName = "Descripcion_texto";
                paramUpdDescripcion_texto.DbType = DbType.String;
                paramUpdDescripcion_texto.Value = (object)entity.Descripcion_texto ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Caracteristicas_Ingrediente>("sp_UpdDetalle_Caracteristicas_Ingrediente" , paramUpdFolio , paramUpdFolio_Ingrediente , paramUpdCaracteristica_combo , paramUpdDescripcion_texto ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente Detalle_Caracteristicas_IngredienteDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Ingrediente = _dataProvider.GetParameter();
                paramUpdFolio_Ingrediente.ParameterName = "Folio_Ingrediente";
                paramUpdFolio_Ingrediente.DbType = DbType.Int32;
                paramUpdFolio_Ingrediente.Value = (object)entity.Folio_Ingrediente ?? DBNull.Value;
                var paramUpdCaracteristica_combo = _dataProvider.GetParameter();
                paramUpdCaracteristica_combo.ParameterName = "Caracteristica_combo";
                paramUpdCaracteristica_combo.DbType = DbType.String;
                paramUpdCaracteristica_combo.Value = (object)entity.Caracteristica_combo ?? DBNull.Value;
                var paramUpdDescripcion_texto = _dataProvider.GetParameter();
                paramUpdDescripcion_texto.ParameterName = "Descripcion_texto";
                paramUpdDescripcion_texto.DbType = DbType.String;
                paramUpdDescripcion_texto.Value = (object)entity.Descripcion_texto ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Caracteristicas_Ingrediente>("sp_UpdDetalle_Caracteristicas_Ingrediente" , paramUpdFolio , paramUpdFolio_Ingrediente , paramUpdCaracteristica_combo , paramUpdDescripcion_texto ).FirstOrDefault();

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


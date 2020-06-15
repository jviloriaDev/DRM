using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipos_de_Actividades;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipos_de_Actividades
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipos_de_ActividadesService : ITipos_de_ActividadesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades> _Tipos_de_ActividadesRepository;
        #endregion

        #region Ctor
        public Tipos_de_ActividadesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades> Tipos_de_ActividadesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipos_de_ActividadesRepository = Tipos_de_ActividadesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipos_de_ActividadesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades>("sp_SelAllTipos_de_Actividades");
        }

        public IList<Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipos_de_Actividades_Complete>("sp_SelAllComplete_Tipos_de_Actividades");
            return data.Select(m => new Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades
            {
                Folio = m.Folio
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipos_de_Actividades>("sp_ListSelCount_Tipos_de_Actividades", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipos_de_Actividades>("sp_ListSelAll_Tipos_de_Actividades", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades
                {
                    Folio = m.Tipos_de_Actividades_Folio,
                    Descripcion = m.Tipos_de_Actividades_Descripcion,

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

        public IList<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipos_de_ActividadesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipos_de_ActividadesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_ActividadesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipos_de_Actividades>("sp_ListSelAll_Tipos_de_Actividades", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipos_de_ActividadesPagingModel result = null;

            if (data != null)
            {
                result = new Tipos_de_ActividadesPagingModel
                {
                    Tipos_de_Actividadess =
                        data.Select(m => new Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades
                {
                    Folio = m.Tipos_de_Actividades_Folio
                    ,Descripcion = m.Tipos_de_Actividades_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipos_de_ActividadesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades>("sp_GetTipos_de_Actividades", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipos_de_Actividades>("sp_DelTipos_de_Actividades", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipos_de_Actividades>("sp_InsTipos_de_Actividades" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipos_de_Actividades>("sp_UpdTipos_de_Actividades" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades Tipos_de_ActividadesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipos_de_Actividades>("sp_UpdTipos_de_Actividades" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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


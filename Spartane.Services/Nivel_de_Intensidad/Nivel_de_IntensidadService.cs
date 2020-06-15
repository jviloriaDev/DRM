using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Nivel_de_Intensidad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Nivel_de_Intensidad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Nivel_de_IntensidadService : INivel_de_IntensidadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> _Nivel_de_IntensidadRepository;
        #endregion

        #region Ctor
        public Nivel_de_IntensidadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> Nivel_de_IntensidadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Nivel_de_IntensidadRepository = Nivel_de_IntensidadRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Nivel_de_IntensidadRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad>("sp_SelAllNivel_de_Intensidad");
        }

        public IList<Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallNivel_de_Intensidad_Complete>("sp_SelAllComplete_Nivel_de_Intensidad");
            return data.Select(m => new Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad
            {
                Folio = m.Folio
                ,Intensidad = m.Intensidad


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Nivel_de_Intensidad>("sp_ListSelCount_Nivel_de_Intensidad", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllNivel_de_Intensidad>("sp_ListSelAll_Nivel_de_Intensidad", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad
                {
                    Folio = m.Nivel_de_Intensidad_Folio,
                    Intensidad = m.Nivel_de_Intensidad_Intensidad,

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

        public IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Nivel_de_IntensidadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nivel_de_IntensidadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllNivel_de_Intensidad>("sp_ListSelAll_Nivel_de_Intensidad", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Nivel_de_IntensidadPagingModel result = null;

            if (data != null)
            {
                result = new Nivel_de_IntensidadPagingModel
                {
                    Nivel_de_Intensidads =
                        data.Select(m => new Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad
                {
                    Folio = m.Nivel_de_Intensidad_Folio
                    ,Intensidad = m.Nivel_de_Intensidad_Intensidad

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Nivel_de_IntensidadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad>("sp_GetNivel_de_Intensidad", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelNivel_de_Intensidad>("sp_DelNivel_de_Intensidad", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreIntensidad = _dataProvider.GetParameter();
                padreIntensidad.ParameterName = "Intensidad";
                padreIntensidad.DbType = DbType.String;
                padreIntensidad.Value = (object)entity.Intensidad ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsNivel_de_Intensidad>("sp_InsNivel_de_Intensidad" , padreIntensidad
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

        public int Update(Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdIntensidad = _dataProvider.GetParameter();
                paramUpdIntensidad.ParameterName = "Intensidad";
                paramUpdIntensidad.DbType = DbType.String;
                paramUpdIntensidad.Value = (object)entity.Intensidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdNivel_de_Intensidad>("sp_UpdNivel_de_Intensidad" , paramUpdFolio , paramUpdIntensidad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad Nivel_de_IntensidadDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdIntensidad = _dataProvider.GetParameter();
                paramUpdIntensidad.ParameterName = "Intensidad";
                paramUpdIntensidad.DbType = DbType.String;
                paramUpdIntensidad.Value = (object)entity.Intensidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdNivel_de_Intensidad>("sp_UpdNivel_de_Intensidad" , paramUpdFolio , paramUpdIntensidad ).FirstOrDefault();

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


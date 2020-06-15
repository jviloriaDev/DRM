using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Nivel_de_dificultad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Nivel_de_dificultad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Nivel_de_dificultadService : INivel_de_dificultadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> _Nivel_de_dificultadRepository;
        #endregion

        #region Ctor
        public Nivel_de_dificultadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> Nivel_de_dificultadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Nivel_de_dificultadRepository = Nivel_de_dificultadRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Nivel_de_dificultadRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad>("sp_SelAllNivel_de_dificultad");
        }

        public IList<Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallNivel_de_dificultad_Complete>("sp_SelAllComplete_Nivel_de_dificultad");
            return data.Select(m => new Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad
            {
                Folio = m.Folio
                ,Dificultad = m.Dificultad


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Nivel_de_dificultad>("sp_ListSelCount_Nivel_de_dificultad", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllNivel_de_dificultad>("sp_ListSelAll_Nivel_de_dificultad", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad
                {
                    Folio = m.Nivel_de_dificultad_Folio,
                    Dificultad = m.Nivel_de_dificultad_Dificultad,

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

        public IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Nivel_de_dificultadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nivel_de_dificultadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllNivel_de_dificultad>("sp_ListSelAll_Nivel_de_dificultad", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Nivel_de_dificultadPagingModel result = null;

            if (data != null)
            {
                result = new Nivel_de_dificultadPagingModel
                {
                    Nivel_de_dificultads =
                        data.Select(m => new Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad
                {
                    Folio = m.Nivel_de_dificultad_Folio
                    ,Dificultad = m.Nivel_de_dificultad_Dificultad

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Nivel_de_dificultadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad>("sp_GetNivel_de_dificultad", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelNivel_de_dificultad>("sp_DelNivel_de_dificultad", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreDificultad = _dataProvider.GetParameter();
                padreDificultad.ParameterName = "Dificultad";
                padreDificultad.DbType = DbType.String;
                padreDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsNivel_de_dificultad>("sp_InsNivel_de_dificultad" , padreDificultad
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

        public int Update(Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDificultad = _dataProvider.GetParameter();
                paramUpdDificultad.ParameterName = "Dificultad";
                paramUpdDificultad.DbType = DbType.String;
                paramUpdDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdNivel_de_dificultad>("sp_UpdNivel_de_dificultad" , paramUpdFolio , paramUpdDificultad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_dificultadDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDificultad = _dataProvider.GetParameter();
                paramUpdDificultad.ParameterName = "Dificultad";
                paramUpdDificultad.DbType = DbType.String;
                paramUpdDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdNivel_de_dificultad>("sp_UpdNivel_de_dificultad" , paramUpdFolio , paramUpdDificultad ).FirstOrDefault();

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


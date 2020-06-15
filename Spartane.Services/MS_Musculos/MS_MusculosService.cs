using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Musculos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Musculos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_MusculosService : IMS_MusculosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Musculos.MS_Musculos> _MS_MusculosRepository;
        #endregion

        #region Ctor
        public MS_MusculosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Musculos.MS_Musculos> MS_MusculosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_MusculosRepository = MS_MusculosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_MusculosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Musculos.MS_Musculos>("sp_SelAllMS_Musculos");
        }

        public IList<Core.Classes.MS_Musculos.MS_Musculos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Musculos_Complete>("sp_SelAllComplete_MS_Musculos");
            return data.Select(m => new Core.Classes.MS_Musculos.MS_Musculos
            {
                Folio = m.Folio
                ,Folio_Ejercicios = m.Folio_Ejercicios
                ,Musculo_Musculos = new Core.Classes.Musculos.Musculos() { Folio = m.Musculo.GetValueOrDefault(), Descripcion = m.Musculo_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Musculos>("sp_ListSelCount_MS_Musculos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Musculos>("sp_ListSelAll_MS_Musculos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Musculos.MS_Musculos
                {
                    Folio = m.MS_Musculos_Folio,
                    Folio_Ejercicios = m.MS_Musculos_Folio_Ejercicios,
                    Musculo = m.MS_Musculos_Musculo,

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

        public IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_MusculosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_MusculosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Musculos.MS_MusculosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Musculos>("sp_ListSelAll_MS_Musculos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_MusculosPagingModel result = null;

            if (data != null)
            {
                result = new MS_MusculosPagingModel
                {
                    MS_Musculoss =
                        data.Select(m => new Spartane.Core.Classes.MS_Musculos.MS_Musculos
                {
                    Folio = m.MS_Musculos_Folio
                    ,Folio_Ejercicios = m.MS_Musculos_Folio_Ejercicios
                    ,Musculo = m.MS_Musculos_Musculo
                    ,Musculo_Musculos = new Core.Classes.Musculos.Musculos() { Folio = m.MS_Musculos_Musculo.GetValueOrDefault(), Descripcion = m.MS_Musculos_Musculo_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_MusculosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Musculos.MS_Musculos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Musculos.MS_Musculos>("sp_GetMS_Musculos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Musculos>("sp_DelMS_Musculos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Musculos.MS_Musculos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Ejercicios = _dataProvider.GetParameter();
                padreFolio_Ejercicios.ParameterName = "Folio_Ejercicios";
                padreFolio_Ejercicios.DbType = DbType.Int32;
                padreFolio_Ejercicios.Value = (object)entity.Folio_Ejercicios ?? DBNull.Value;
                var padreMusculo = _dataProvider.GetParameter();
                padreMusculo.ParameterName = "Musculo";
                padreMusculo.DbType = DbType.Int32;
                padreMusculo.Value = (object)entity.Musculo ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Musculos>("sp_InsMS_Musculos" , padreFolio_Ejercicios
, padreMusculo
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

        public int Update(Spartane.Core.Classes.MS_Musculos.MS_Musculos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Ejercicios = _dataProvider.GetParameter();
                paramUpdFolio_Ejercicios.ParameterName = "Folio_Ejercicios";
                paramUpdFolio_Ejercicios.DbType = DbType.Int32;
                paramUpdFolio_Ejercicios.Value = (object)entity.Folio_Ejercicios ?? DBNull.Value;
                var paramUpdMusculo = _dataProvider.GetParameter();
                paramUpdMusculo.ParameterName = "Musculo";
                paramUpdMusculo.DbType = DbType.Int32;
                paramUpdMusculo.Value = (object)entity.Musculo ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Musculos>("sp_UpdMS_Musculos" , paramUpdFolio , paramUpdFolio_Ejercicios , paramUpdMusculo ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Musculos.MS_Musculos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Musculos.MS_Musculos MS_MusculosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Ejercicios = _dataProvider.GetParameter();
                paramUpdFolio_Ejercicios.ParameterName = "Folio_Ejercicios";
                paramUpdFolio_Ejercicios.DbType = DbType.Int32;
                paramUpdFolio_Ejercicios.Value = (object)entity.Folio_Ejercicios ?? DBNull.Value;
                var paramUpdMusculo = _dataProvider.GetParameter();
                paramUpdMusculo.ParameterName = "Musculo";
                paramUpdMusculo.DbType = DbType.Int32;
                paramUpdMusculo.Value = (object)entity.Musculo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Musculos>("sp_UpdMS_Musculos" , paramUpdFolio , paramUpdFolio_Ejercicios , paramUpdMusculo ).FirstOrDefault();

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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Equipamiento_para_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Equipamiento_para_EjerciciosService : IMS_Equipamiento_para_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios> _MS_Equipamiento_para_EjerciciosRepository;
        #endregion

        #region Ctor
        public MS_Equipamiento_para_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios> MS_Equipamiento_para_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Equipamiento_para_EjerciciosRepository = MS_Equipamiento_para_EjerciciosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Equipamiento_para_EjerciciosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios>("sp_SelAllMS_Equipamiento_para_Ejercicios");
        }

        public IList<Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Equipamiento_para_Ejercicios_Complete>("sp_SelAllComplete_MS_Equipamiento_para_Ejercicios");
            return data.Select(m => new Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios
            {
                Folio = m.Folio
                ,Folio_Ejercicios = m.Folio_Ejercicios
                ,Equipamento_Equipamiento_para_Ejercicios = new Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios() { Folio = m.Equipamento.GetValueOrDefault(), Descripcion = m.Equipamento_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Equipamiento_para_Ejercicios>("sp_ListSelCount_MS_Equipamiento_para_Ejercicios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Equipamiento_para_Ejercicios>("sp_ListSelAll_MS_Equipamiento_para_Ejercicios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios
                {
                    Folio = m.MS_Equipamiento_para_Ejercicios_Folio,
                    Folio_Ejercicios = m.MS_Equipamiento_para_Ejercicios_Folio_Ejercicios,
                    Equipamento = m.MS_Equipamiento_para_Ejercicios_Equipamento,

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

        public IList<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Equipamiento_para_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Equipamiento_para_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Equipamiento_para_Ejercicios>("sp_ListSelAll_MS_Equipamiento_para_Ejercicios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Equipamiento_para_EjerciciosPagingModel result = null;

            if (data != null)
            {
                result = new MS_Equipamiento_para_EjerciciosPagingModel
                {
                    MS_Equipamiento_para_Ejercicioss =
                        data.Select(m => new Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios
                {
                    Folio = m.MS_Equipamiento_para_Ejercicios_Folio
                    ,Folio_Ejercicios = m.MS_Equipamiento_para_Ejercicios_Folio_Ejercicios
                    ,Equipamento = m.MS_Equipamiento_para_Ejercicios_Equipamento
                    ,Equipamento_Equipamiento_para_Ejercicios = new Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios() { Folio = m.MS_Equipamiento_para_Ejercicios_Equipamento.GetValueOrDefault(), Descripcion = m.MS_Equipamiento_para_Ejercicios_Equipamento_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Equipamiento_para_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios>("sp_GetMS_Equipamiento_para_Ejercicios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Equipamiento_para_Ejercicios>("sp_DelMS_Equipamiento_para_Ejercicios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios entity)
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
                var padreEquipamento = _dataProvider.GetParameter();
                padreEquipamento.ParameterName = "Equipamento";
                padreEquipamento.DbType = DbType.Int32;
                padreEquipamento.Value = (object)entity.Equipamento ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Equipamiento_para_Ejercicios>("sp_InsMS_Equipamiento_para_Ejercicios" , padreFolio_Ejercicios
, padreEquipamento
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

        public int Update(Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios entity)
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
                var paramUpdEquipamento = _dataProvider.GetParameter();
                paramUpdEquipamento.ParameterName = "Equipamento";
                paramUpdEquipamento.DbType = DbType.Int32;
                paramUpdEquipamento.Value = (object)entity.Equipamento ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Equipamiento_para_Ejercicios>("sp_UpdMS_Equipamiento_para_Ejercicios" , paramUpdFolio , paramUpdFolio_Ejercicios , paramUpdEquipamento ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios MS_Equipamiento_para_EjerciciosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Ejercicios = _dataProvider.GetParameter();
                paramUpdFolio_Ejercicios.ParameterName = "Folio_Ejercicios";
                paramUpdFolio_Ejercicios.DbType = DbType.Int32;
                paramUpdFolio_Ejercicios.Value = (object)entity.Folio_Ejercicios ?? DBNull.Value;
		var paramUpdEquipamento = _dataProvider.GetParameter();
                paramUpdEquipamento.ParameterName = "Equipamento";
                paramUpdEquipamento.DbType = DbType.Int32;
                paramUpdEquipamento.Value = (object)entity.Equipamento ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Equipamiento_para_Ejercicios>("sp_UpdMS_Equipamiento_para_Ejercicios" , paramUpdFolio , paramUpdFolio_Ejercicios , paramUpdEquipamento ).FirstOrDefault();

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


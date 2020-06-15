using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Suscripciones_Codigos_Referidos_Especialista
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Suscripciones_Codigos_Referidos_EspecialistaService : IMS_Suscripciones_Codigos_Referidos_EspecialistaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> _MS_Suscripciones_Codigos_Referidos_EspecialistaRepository;
        #endregion

        #region Ctor
        public MS_Suscripciones_Codigos_Referidos_EspecialistaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> MS_Suscripciones_Codigos_Referidos_EspecialistaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository = MS_Suscripciones_Codigos_Referidos_EspecialistaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista>("sp_SelAllMS_Suscripciones_Codigos_Referidos_Especialista");
        }

        public IList<Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Suscripciones_Codigos_Referidos_Especialista_Complete>("sp_SelAllComplete_MS_Suscripciones_Codigos_Referidos_Especialista");
            return data.Select(m => new Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista
            {
                Folio = m.Folio
                ,Folio_Codigos = m.Folio_Codigos
                ,Plan_de_Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Plan_de_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Plan_de_Suscripcion_Nombre_del_Plan }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Suscripciones_Codigos_Referidos_Especialista>("sp_ListSelCount_MS_Suscripciones_Codigos_Referidos_Especialista", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Suscripciones_Codigos_Referidos_Especialista>("sp_ListSelAll_MS_Suscripciones_Codigos_Referidos_Especialista", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista
                {
                    Folio = m.MS_Suscripciones_Codigos_Referidos_Especialista_Folio,
                    Folio_Codigos = m.MS_Suscripciones_Codigos_Referidos_Especialista_Folio_Codigos,
                    Plan_de_Suscripcion = m.MS_Suscripciones_Codigos_Referidos_Especialista_Plan_de_Suscripcion,

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

        public IList<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_EspecialistaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Suscripciones_Codigos_Referidos_Especialista>("sp_ListSelAll_MS_Suscripciones_Codigos_Referidos_Especialista", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Suscripciones_Codigos_Referidos_EspecialistaPagingModel result = null;

            if (data != null)
            {
                result = new MS_Suscripciones_Codigos_Referidos_EspecialistaPagingModel
                {
                    MS_Suscripciones_Codigos_Referidos_Especialistas =
                        data.Select(m => new Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista
                {
                    Folio = m.MS_Suscripciones_Codigos_Referidos_Especialista_Folio
                    ,Folio_Codigos = m.MS_Suscripciones_Codigos_Referidos_Especialista_Folio_Codigos
                    ,Plan_de_Suscripcion = m.MS_Suscripciones_Codigos_Referidos_Especialista_Plan_de_Suscripcion
                    ,Plan_de_Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.MS_Suscripciones_Codigos_Referidos_Especialista_Plan_de_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.MS_Suscripciones_Codigos_Referidos_Especialista_Plan_de_Suscripcion_Nombre_del_Plan }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista>("sp_GetMS_Suscripciones_Codigos_Referidos_Especialista", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Suscripciones_Codigos_Referidos_Especialista>("sp_DelMS_Suscripciones_Codigos_Referidos_Especialista", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Codigos = _dataProvider.GetParameter();
                padreFolio_Codigos.ParameterName = "Folio_Codigos";
                padreFolio_Codigos.DbType = DbType.Int32;
                padreFolio_Codigos.Value = (object)entity.Folio_Codigos ?? DBNull.Value;
                var padrePlan_de_Suscripcion = _dataProvider.GetParameter();
                padrePlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                padrePlan_de_Suscripcion.DbType = DbType.Int32;
                padrePlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Suscripciones_Codigos_Referidos_Especialista>("sp_InsMS_Suscripciones_Codigos_Referidos_Especialista" , padreFolio_Codigos
, padrePlan_de_Suscripcion
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

        public int Update(Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Codigos = _dataProvider.GetParameter();
                paramUpdFolio_Codigos.ParameterName = "Folio_Codigos";
                paramUpdFolio_Codigos.DbType = DbType.Int32;
                paramUpdFolio_Codigos.Value = (object)entity.Folio_Codigos ?? DBNull.Value;
                var paramUpdPlan_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdPlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                paramUpdPlan_de_Suscripcion.DbType = DbType.Int32;
                paramUpdPlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Suscripciones_Codigos_Referidos_Especialista>("sp_UpdMS_Suscripciones_Codigos_Referidos_Especialista" , paramUpdFolio , paramUpdFolio_Codigos , paramUpdPlan_de_Suscripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista MS_Suscripciones_Codigos_Referidos_EspecialistaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Codigos = _dataProvider.GetParameter();
                paramUpdFolio_Codigos.ParameterName = "Folio_Codigos";
                paramUpdFolio_Codigos.DbType = DbType.Int32;
                paramUpdFolio_Codigos.Value = (object)entity.Folio_Codigos ?? DBNull.Value;
		var paramUpdPlan_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdPlan_de_Suscripcion.ParameterName = "Plan_de_Suscripcion";
                paramUpdPlan_de_Suscripcion.DbType = DbType.Int32;
                paramUpdPlan_de_Suscripcion.Value = (object)entity.Plan_de_Suscripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Suscripciones_Codigos_Referidos_Especialista>("sp_UpdMS_Suscripciones_Codigos_Referidos_Especialista" , paramUpdFolio , paramUpdFolio_Codigos , paramUpdPlan_de_Suscripcion ).FirstOrDefault();

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


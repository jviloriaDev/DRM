using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Process_Event_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Process_Event_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Process_Event_DetailService : ISpartan_BR_Process_Event_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail> _Spartan_BR_Process_Event_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Process_Event_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail> Spartan_BR_Process_Event_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Process_Event_DetailRepository = Spartan_BR_Process_Event_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Process_Event_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail>("sp_SelAllSpartan_BR_Process_Event_Detail");
        }

        public IList<Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Process_Event_Detail_Complete>("sp_SelAllComplete_Spartan_BR_Process_Event_Detail");
            return data.Select(m => new Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail
            {
                ProcessEventDetailId = m.ProcessEventDetailId
                ,Business_Rule = m.Business_Rule
                ,Process_Event_Spartan_BR_Process_Event = new Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event() { ProcessEventId = m.Process_Event.GetValueOrDefault(), Description = m.Process_Event_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Process_Event_Detail>("sp_ListSelCount_Spartan_BR_Process_Event_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Process_Event_Detail>("sp_ListSelAll_Spartan_BR_Process_Event_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail
                {
                    ProcessEventDetailId = m.Spartan_BR_Process_Event_Detail_ProcessEventDetailId,
                    Business_Rule = m.Spartan_BR_Process_Event_Detail_Business_Rule,
                    Process_Event = m.Spartan_BR_Process_Event_Detail_Process_Event,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Process_Event_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Process_Event_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Process_Event_Detail>("sp_ListSelAll_Spartan_BR_Process_Event_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Process_Event_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Process_Event_DetailPagingModel
                {
                    Spartan_BR_Process_Event_Details =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail
                {
                    ProcessEventDetailId = m.Spartan_BR_Process_Event_Detail_ProcessEventDetailId
                    ,Business_Rule = m.Spartan_BR_Process_Event_Detail_Business_Rule
                    ,Process_Event = m.Spartan_BR_Process_Event_Detail_Process_Event
                    ,Process_Event_Spartan_BR_Process_Event = new Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event() { ProcessEventId = m.Spartan_BR_Process_Event_Detail_Process_Event.GetValueOrDefault(), Description = m.Spartan_BR_Process_Event_Detail_Process_Event_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Process_Event_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ProcessEventDetailId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail>("sp_GetSpartan_BR_Process_Event_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ProcessEventDetailId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Process_Event_Detail>("sp_DelSpartan_BR_Process_Event_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail entity)
        {
            int rta;
            try
            {

		                var padreBusiness_Rule = _dataProvider.GetParameter();
                padreBusiness_Rule.ParameterName = "Business_Rule";
                padreBusiness_Rule.DbType = DbType.Int32;
                padreBusiness_Rule.Value = (object)entity.Business_Rule ?? DBNull.Value;
                var padreProcess_Event = _dataProvider.GetParameter();
                padreProcess_Event.ParameterName = "Process_Event";
                padreProcess_Event.DbType = DbType.Int16;
                padreProcess_Event.Value = (object)entity.Process_Event ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Process_Event_Detail>("sp_InsSpartan_BR_Process_Event_Detail" , padreBusiness_Rule
, padreProcess_Event
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ProcessEventDetailId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdProcessEventDetailId = _dataProvider.GetParameter();
                paramUpdProcessEventDetailId.ParameterName = "ProcessEventDetailId";
                paramUpdProcessEventDetailId.DbType = DbType.Int32;
                paramUpdProcessEventDetailId.Value = entity.ProcessEventDetailId;
                var paramUpdBusiness_Rule = _dataProvider.GetParameter();
                paramUpdBusiness_Rule.ParameterName = "Business_Rule";
                paramUpdBusiness_Rule.DbType = DbType.Int32;
                paramUpdBusiness_Rule.Value = entity.Business_Rule;
                var paramUpdProcess_Event = _dataProvider.GetParameter();
                paramUpdProcess_Event.ParameterName = "Process_Event";
                paramUpdProcess_Event.DbType = DbType.Int16;
                if (entity.Process_Event == null)
                    paramUpdProcess_Event.Value = DBNull.Value;
                else
                    paramUpdProcess_Event.Value = entity.Process_Event;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Process_Event_Detail>("sp_UpdSpartan_BR_Process_Event_Detail" , paramUpdProcessEventDetailId , paramUpdBusiness_Rule , paramUpdProcess_Event ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ProcessEventDetailId);
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


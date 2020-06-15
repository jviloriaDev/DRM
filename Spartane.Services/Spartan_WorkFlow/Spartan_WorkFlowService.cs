using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlowService : ISpartan_WorkFlowService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> _Spartan_WorkFlowRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlowService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> Spartan_WorkFlowRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlowRepository = Spartan_WorkFlowRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlowRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow>("sp_SelAllSpartan_WorkFlow");
        }

        public IList<Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Complete>("sp_SelAllComplete_Spartan_WorkFlow");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow
            {
                WorkFlowId = m.WorkFlowId
                ,Name = m.Name
                ,Description = m.Description
                ,Objective = m.Objective
                ,Status_Spartan_WorkFlow_Status = new Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status() { StatusId = m.Status.GetValueOrDefault(), Description = m.Status_Description }
                ,Object_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object.GetValueOrDefault(), Name = m.Object_Name }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow>("sp_ListSelCount_Spartan_WorkFlow", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow>("sp_ListSelAll_Spartan_WorkFlow", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow
                {
                    WorkFlowId = m.Spartan_WorkFlow_WorkFlowId,
                    Name = m.Spartan_WorkFlow_Name,
                    Description = m.Spartan_WorkFlow_Description,
                    Objective = m.Spartan_WorkFlow_Objective,
                    Status = m.Spartan_WorkFlow_Status,
                    Object = m.Spartan_WorkFlow_Object,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlowRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlowRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlowPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow>("sp_ListSelAll_Spartan_WorkFlow", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlowPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlowPagingModel
                {
                    Spartan_WorkFlows =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow
                {
                    WorkFlowId = m.Spartan_WorkFlow_WorkFlowId
                    ,Name = m.Spartan_WorkFlow_Name
                    ,Description = m.Spartan_WorkFlow_Description
                    ,Objective = m.Spartan_WorkFlow_Objective
                    ,Status = m.Spartan_WorkFlow_Status
                    ,Status_Spartan_WorkFlow_Status = new Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status() { StatusId = m.Spartan_WorkFlow_Status.GetValueOrDefault(), Description = m.Spartan_WorkFlow_Status_Description }
                    ,Object = m.Spartan_WorkFlow_Object
                    ,Object_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_WorkFlow_Object.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Object_Name }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlowRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "WorkFlowId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow>("sp_GetSpartan_WorkFlow", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "WorkFlowId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow>("sp_DelSpartan_WorkFlow", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow entity)
        {
            int rta;
            try
            {

		                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = (object)entity.Name ?? DBNull.Value;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
                var padreObjective = _dataProvider.GetParameter();
                padreObjective.ParameterName = "Objective";
                padreObjective.DbType = DbType.String;
                padreObjective.Value = (object)entity.Objective ?? DBNull.Value;
                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                padreStatus.Value = (object)entity.Status ?? DBNull.Value;

                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                padreObject.Value = (object)entity.Object ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow>("sp_InsSpartan_WorkFlow" 
, padreName
, padreDescription
, padreObjective
, padreStatus
, padreObject






).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.WorkFlowId);

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

        public int Update(Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow entity)
        {
            int rta;
            try
            {

                var paramUpdWorkFlowId = _dataProvider.GetParameter();
                paramUpdWorkFlowId.ParameterName = "WorkFlowId";
                paramUpdWorkFlowId.DbType = DbType.Int32;
                paramUpdWorkFlowId.Value = (object)entity.WorkFlowId ?? DBNull.Value;
                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)entity.Name ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;
                var paramUpdObjective = _dataProvider.GetParameter();
                paramUpdObjective.ParameterName = "Objective";
                paramUpdObjective.DbType = DbType.String;
                paramUpdObjective.Value = (object)entity.Objective ?? DBNull.Value;
                var paramUpdStatus = _dataProvider.GetParameter();
                paramUpdStatus.ParameterName = "Status";
                paramUpdStatus.DbType = DbType.Int16;
                paramUpdStatus.Value = (object)entity.Status ?? DBNull.Value;

                var paramUpdObject = _dataProvider.GetParameter();
                paramUpdObject.ParameterName = "Object";
                paramUpdObject.DbType = DbType.Int32;
                paramUpdObject.Value = (object)entity.Object ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow>("sp_UpdSpartan_WorkFlow" , paramUpdWorkFlowId , paramUpdName , paramUpdDescription , paramUpdObjective , paramUpdStatus , paramUpdObject       ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.WorkFlowId);
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

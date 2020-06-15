using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Phases;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Phases
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_PhasesService : ISpartan_WorkFlow_PhasesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> _Spartan_WorkFlow_PhasesRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_PhasesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> Spartan_WorkFlow_PhasesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_PhasesRepository = Spartan_WorkFlow_PhasesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>("sp_SelAllSpartan_WorkFlow_Phases");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Phases_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Phases");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases
            {
                PhasesId = m.PhasesId
                ,WorkFlow = m.WorkFlow
                ,Phase_Number = m.Phase_Number
                ,Name = m.Name
                ,Phase_Type_Spartan_WorkFlow_Phase_Type = new Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type() { Phase_TypeId = m.Phase_Type.GetValueOrDefault(), Description = m.Phase_Type_Description }
                ,Type_of_Work_Distribution_Spartan_WorkFlow_Type_Work_Distribution = new Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution() { Type_of_Work_DistributionId = m.Type_of_Work_Distribution.GetValueOrDefault(), Description = m.Type_of_Work_Distribution_Description }
                ,Type_Flow_Control_Spartan_WorkFlow_Type_Flow_Control = new Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control() { Type_Flow_ControlId = m.Type_Flow_Control.GetValueOrDefault(), Description = m.Type_Flow_Control_Description }
                ,Phase_Status_Spartan_WorkFlow_Phase_Status = new Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status() { StatusId = m.Phase_Status.GetValueOrDefault(), Description = m.Phase_Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Phases>("sp_ListSelCount_Spartan_WorkFlow_Phases", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Phases>("sp_ListSelAll_Spartan_WorkFlow_Phases", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases
                {
                    WorkFlow = m.Spartan_WorkFlow_Phases_WorkFlow,
                    PhasesId = m.Spartan_WorkFlow_Phases_PhasesId,
                    Phase_Number = m.Spartan_WorkFlow_Phases_Phase_Number,
                    Name = m.Spartan_WorkFlow_Phases_Name,
                    Phase_Type = m.Spartan_WorkFlow_Phases_Phase_Type,
                    Type_of_Work_Distribution = m.Spartan_WorkFlow_Phases_Type_of_Work_Distribution,
                    Type_Flow_Control = m.Spartan_WorkFlow_Phases_Type_Flow_Control,
                    Phase_Status = m.Spartan_WorkFlow_Phases_Phase_Status,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_PhasesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Phases>("sp_ListSelAll_Spartan_WorkFlow_Phases", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_PhasesPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_PhasesPagingModel
                {
                    Spartan_WorkFlow_Phasess =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases
                {
                    PhasesId = m.Spartan_WorkFlow_Phases_PhasesId
                    ,WorkFlow = m.Spartan_WorkFlow_Phases_WorkFlow
                    ,Phase_Number = m.Spartan_WorkFlow_Phases_Phase_Number
                    ,Name = m.Spartan_WorkFlow_Phases_Name
                    ,Phase_Type = m.Spartan_WorkFlow_Phases_Phase_Type
                    ,Phase_Type_Spartan_WorkFlow_Phase_Type = new Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type() { Phase_TypeId = m.Spartan_WorkFlow_Phases_Phase_Type.GetValueOrDefault(), Description = m.Spartan_WorkFlow_Phases_Phase_Type_Description }
                    ,Type_of_Work_Distribution = m.Spartan_WorkFlow_Phases_Type_of_Work_Distribution
                    ,Type_of_Work_Distribution_Spartan_WorkFlow_Type_Work_Distribution = new Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution() { Type_of_Work_DistributionId = m.Spartan_WorkFlow_Phases_Type_of_Work_Distribution.GetValueOrDefault(), Description = m.Spartan_WorkFlow_Phases_Type_of_Work_Distribution_Description }
                    ,Type_Flow_Control = m.Spartan_WorkFlow_Phases_Type_Flow_Control
                    ,Type_Flow_Control_Spartan_WorkFlow_Type_Flow_Control = new Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control() { Type_Flow_ControlId = m.Spartan_WorkFlow_Phases_Type_Flow_Control.GetValueOrDefault(), Description = m.Spartan_WorkFlow_Phases_Type_Flow_Control_Description }
                    ,Phase_Status = m.Spartan_WorkFlow_Phases_Phase_Status
                    ,Phase_Status_Spartan_WorkFlow_Phase_Status = new Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status() { StatusId = m.Spartan_WorkFlow_Phases_Phase_Status.GetValueOrDefault(), Description = m.Spartan_WorkFlow_Phases_Phase_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "PhasesId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>("sp_GetSpartan_WorkFlow_Phases", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "PhasesId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Phases>("sp_DelSpartan_WorkFlow_Phases", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases entity)
        {
            int rta;
            try
            {

		                var padreWorkFlow = _dataProvider.GetParameter();
                padreWorkFlow.ParameterName = "WorkFlow";
                padreWorkFlow.DbType = DbType.Int32;
                padreWorkFlow.Value = (object)entity.WorkFlow ?? DBNull.Value;
                var padrePhase_Number = _dataProvider.GetParameter();
                padrePhase_Number.ParameterName = "Phase_Number";
                padrePhase_Number.DbType = DbType.Int16;
                padrePhase_Number.Value = (object)entity.Phase_Number ?? DBNull.Value;

                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = (object)entity.Name ?? DBNull.Value;
                var padrePhase_Type = _dataProvider.GetParameter();
                padrePhase_Type.ParameterName = "Phase_Type";
                padrePhase_Type.DbType = DbType.Int16;
                padrePhase_Type.Value = (object)entity.Phase_Type ?? DBNull.Value;

                var padreType_of_Work_Distribution = _dataProvider.GetParameter();
                padreType_of_Work_Distribution.ParameterName = "Type_of_Work_Distribution";
                padreType_of_Work_Distribution.DbType = DbType.Int16;
                padreType_of_Work_Distribution.Value = (object)entity.Type_of_Work_Distribution ?? DBNull.Value;

                var padreType_Flow_Control = _dataProvider.GetParameter();
                padreType_Flow_Control.ParameterName = "Type_Flow_Control";
                padreType_Flow_Control.DbType = DbType.Int16;
                padreType_Flow_Control.Value = (object)entity.Type_Flow_Control ?? DBNull.Value;

                var padrePhase_Status = _dataProvider.GetParameter();
                padrePhase_Status.ParameterName = "Phase_Status";
                padrePhase_Status.DbType = DbType.Int16;
                padrePhase_Status.Value = (object)entity.Phase_Status ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Phases>("sp_InsSpartan_WorkFlow_Phases" , padreWorkFlow

, padrePhase_Number
, padreName
, padrePhase_Type
, padreType_of_Work_Distribution
, padreType_Flow_Control
, padrePhase_Status
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.PhasesId);

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

        public int Update(Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases entity)
        {
            int rta;
            try
            {

                var paramUpdWorkFlow = _dataProvider.GetParameter();
                paramUpdWorkFlow.ParameterName = "WorkFlow";
                paramUpdWorkFlow.DbType = DbType.Int32;
                paramUpdWorkFlow.Value = (object)entity.WorkFlow ?? DBNull.Value;
                var paramUpdPhasesId = _dataProvider.GetParameter();
                paramUpdPhasesId.ParameterName = "PhasesId";
                paramUpdPhasesId.DbType = DbType.Int32;
                paramUpdPhasesId.Value = (object)entity.PhasesId ?? DBNull.Value;
                var paramUpdPhase_Number = _dataProvider.GetParameter();
                paramUpdPhase_Number.ParameterName = "Phase_Number";
                paramUpdPhase_Number.DbType = DbType.Int16;
                paramUpdPhase_Number.Value = (object)entity.Phase_Number ?? DBNull.Value;

                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)entity.Name ?? DBNull.Value;
                var paramUpdPhase_Type = _dataProvider.GetParameter();
                paramUpdPhase_Type.ParameterName = "Phase_Type";
                paramUpdPhase_Type.DbType = DbType.Int16;
                paramUpdPhase_Type.Value = (object)entity.Phase_Type ?? DBNull.Value;

                var paramUpdType_of_Work_Distribution = _dataProvider.GetParameter();
                paramUpdType_of_Work_Distribution.ParameterName = "Type_of_Work_Distribution";
                paramUpdType_of_Work_Distribution.DbType = DbType.Int16;
                paramUpdType_of_Work_Distribution.Value = (object)entity.Type_of_Work_Distribution ?? DBNull.Value;

                var paramUpdType_Flow_Control = _dataProvider.GetParameter();
                paramUpdType_Flow_Control.ParameterName = "Type_Flow_Control";
                paramUpdType_Flow_Control.DbType = DbType.Int16;
                paramUpdType_Flow_Control.Value = (object)entity.Type_Flow_Control ?? DBNull.Value;

                var paramUpdPhase_Status = _dataProvider.GetParameter();
                paramUpdPhase_Status.ParameterName = "Phase_Status";
                paramUpdPhase_Status.DbType = DbType.Int16;
                paramUpdPhase_Status.Value = (object)entity.Phase_Status ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Phases>("sp_UpdSpartan_WorkFlow_Phases" , paramUpdWorkFlow , paramUpdPhasesId , paramUpdPhase_Number , paramUpdName , paramUpdPhase_Type , paramUpdType_of_Work_Distribution , paramUpdType_Flow_Control , paramUpdPhase_Status ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.PhasesId);
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

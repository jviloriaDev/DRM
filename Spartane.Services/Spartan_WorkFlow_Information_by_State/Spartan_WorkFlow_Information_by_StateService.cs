using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Information_by_State
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Information_by_StateService : ISpartan_WorkFlow_Information_by_StateService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> _Spartan_WorkFlow_Information_by_StateRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Information_by_StateService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> Spartan_WorkFlow_Information_by_StateRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Information_by_StateRepository = Spartan_WorkFlow_Information_by_StateRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_Information_by_StateRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State>("sp_SelAllSpartan_WorkFlow_Information_by_State");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Information_by_State_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Information_by_State");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State
            {
                Information_by_StateId = m.Information_by_StateId
                ,Spartan_WorkFlow = m.Spartan_WorkFlow
                ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Phase.GetValueOrDefault(), Name = m.Phase_Name }
                ,State_Spartan_WorkFlow_State = new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State() { StateId = m.State.GetValueOrDefault(), Name = m.State_Name }
                ,Folder_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Folder.GetValueOrDefault(), Group_Name = m.Folder_Group_Name }
                ,Visible = m.Visible.GetValueOrDefault()
                ,Read_Only = m.Read_Only.GetValueOrDefault()
                ,Required = m.Required.GetValueOrDefault()
                ,Label = m.Label


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Information_by_State>("sp_ListSelCount_Spartan_WorkFlow_Information_by_State", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Information_by_State>("sp_ListSelAll_Spartan_WorkFlow_Information_by_State", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State
                {
                    Spartan_WorkFlow = m.Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow,
                    Information_by_StateId = m.Spartan_WorkFlow_Information_by_State_Information_by_StateId,
                    Phase = m.Spartan_WorkFlow_Information_by_State_Phase,
                    State = m.Spartan_WorkFlow_Information_by_State_State,
                    Folder = m.Spartan_WorkFlow_Information_by_State_Folder,
                    Visible = m.Spartan_WorkFlow_Information_by_State_Visible ?? false,
                    Read_Only = m.Spartan_WorkFlow_Information_by_State_Read_Only ?? false,
                    Required = m.Spartan_WorkFlow_Information_by_State_Required ?? false,
                    Label = m.Spartan_WorkFlow_Information_by_State_Label,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Information_by_StateRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Information_by_StateRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_StatePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Information_by_State>("sp_ListSelAll_Spartan_WorkFlow_Information_by_State", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_Information_by_StatePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_Information_by_StatePagingModel
                {
                    Spartan_WorkFlow_Information_by_States =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State
                {
                    Information_by_StateId = m.Spartan_WorkFlow_Information_by_State_Information_by_StateId
                    ,Spartan_WorkFlow = m.Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow
                    ,Phase = m.Spartan_WorkFlow_Information_by_State_Phase
                    ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Spartan_WorkFlow_Information_by_State_Phase.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Information_by_State_Phase_Name }
                    ,State = m.Spartan_WorkFlow_Information_by_State_State
                    ,State_Spartan_WorkFlow_State = new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State() { StateId = m.Spartan_WorkFlow_Information_by_State_State.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Information_by_State_State_Name }
                    ,Folder = m.Spartan_WorkFlow_Information_by_State_Folder
                    ,Folder_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Spartan_WorkFlow_Information_by_State_Folder.GetValueOrDefault(), Group_Name = m.Spartan_WorkFlow_Information_by_State_Folder_Group_Name }
                    ,Visible = m.Spartan_WorkFlow_Information_by_State_Visible ?? false
                    ,Read_Only = m.Spartan_WorkFlow_Information_by_State_Read_Only ?? false
                    ,Required = m.Spartan_WorkFlow_Information_by_State_Required ?? false
                    ,Label = m.Spartan_WorkFlow_Information_by_State_Label

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Information_by_StateRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Information_by_StateId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State>("sp_GetSpartan_WorkFlow_Information_by_State", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Information_by_StateId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Information_by_State>("sp_DelSpartan_WorkFlow_Information_by_State", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State entity)
        {
            int rta;
            try
            {

		                var padreSpartan_WorkFlow = _dataProvider.GetParameter();
                padreSpartan_WorkFlow.ParameterName = "Spartan_WorkFlow";
                padreSpartan_WorkFlow.DbType = DbType.Int32;
                padreSpartan_WorkFlow.Value = (object)entity.Spartan_WorkFlow ?? DBNull.Value;
                var padrePhase = _dataProvider.GetParameter();
                padrePhase.ParameterName = "Phase";
                padrePhase.DbType = DbType.Int32;
                padrePhase.Value = (object)entity.Phase ?? DBNull.Value;

                var padreState = _dataProvider.GetParameter();
                padreState.ParameterName = "State";
                padreState.DbType = DbType.Int32;
                padreState.Value = (object)entity.State ?? DBNull.Value;

                var padreFolder = _dataProvider.GetParameter();
                padreFolder.ParameterName = "Folder";
                padreFolder.DbType = DbType.Int32;
                padreFolder.Value = (object)entity.Folder ?? DBNull.Value;

                var padreVisible = _dataProvider.GetParameter();
                padreVisible.ParameterName = "Visible";
                padreVisible.DbType = DbType.Boolean;
                padreVisible.Value = (object)entity.Visible ?? DBNull.Value;
                var padreRead_Only = _dataProvider.GetParameter();
                padreRead_Only.ParameterName = "Read_Only";
                padreRead_Only.DbType = DbType.Boolean;
                padreRead_Only.Value = (object)entity.Read_Only ?? DBNull.Value;
                var padreRequired = _dataProvider.GetParameter();
                padreRequired.ParameterName = "Required";
                padreRequired.DbType = DbType.Boolean;
                padreRequired.Value = (object)entity.Required ?? DBNull.Value;
                var padreLabel = _dataProvider.GetParameter();
                padreLabel.ParameterName = "Label";
                padreLabel.DbType = DbType.String;
                padreLabel.Value = (object)entity.Label ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Information_by_State>("sp_InsSpartan_WorkFlow_Information_by_State" , padreSpartan_WorkFlow

, padrePhase
, padreState
, padreFolder
, padreVisible
, padreRead_Only
, padreRequired
, padreLabel
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Information_by_StateId);

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

        public int Update(Spartane.Core.Classes.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State entity)
        {
            int rta;
            try
            {

                var paramUpdSpartan_WorkFlow = _dataProvider.GetParameter();
                paramUpdSpartan_WorkFlow.ParameterName = "Spartan_WorkFlow";
                paramUpdSpartan_WorkFlow.DbType = DbType.Int32;
                paramUpdSpartan_WorkFlow.Value = (object)entity.Spartan_WorkFlow ?? DBNull.Value;
                var paramUpdInformation_by_StateId = _dataProvider.GetParameter();
                paramUpdInformation_by_StateId.ParameterName = "Information_by_StateId";
                paramUpdInformation_by_StateId.DbType = DbType.Int32;
                paramUpdInformation_by_StateId.Value = (object)entity.Information_by_StateId ?? DBNull.Value;
                var paramUpdPhase = _dataProvider.GetParameter();
                paramUpdPhase.ParameterName = "Phase";
                paramUpdPhase.DbType = DbType.Int32;
                paramUpdPhase.Value = (object)entity.Phase ?? DBNull.Value;

                var paramUpdState = _dataProvider.GetParameter();
                paramUpdState.ParameterName = "State";
                paramUpdState.DbType = DbType.Int32;
                paramUpdState.Value = (object)entity.State ?? DBNull.Value;

                var paramUpdFolder = _dataProvider.GetParameter();
                paramUpdFolder.ParameterName = "Folder";
                paramUpdFolder.DbType = DbType.Int32;
                paramUpdFolder.Value = (object)entity.Folder ?? DBNull.Value;

                var paramUpdVisible = _dataProvider.GetParameter();
                paramUpdVisible.ParameterName = "Visible";
                paramUpdVisible.DbType = DbType.Boolean;
                paramUpdVisible.Value = (object)entity.Visible ?? DBNull.Value;
                var paramUpdRead_Only = _dataProvider.GetParameter();
                paramUpdRead_Only.ParameterName = "Read_Only";
                paramUpdRead_Only.DbType = DbType.Boolean;
                paramUpdRead_Only.Value = (object)entity.Read_Only ?? DBNull.Value;
                var paramUpdRequired = _dataProvider.GetParameter();
                paramUpdRequired.ParameterName = "Required";
                paramUpdRequired.DbType = DbType.Boolean;
                paramUpdRequired.Value = (object)entity.Required ?? DBNull.Value;
                var paramUpdLabel = _dataProvider.GetParameter();
                paramUpdLabel.ParameterName = "Label";
                paramUpdLabel.DbType = DbType.String;
                paramUpdLabel.Value = (object)entity.Label ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Information_by_State>("sp_UpdSpartan_WorkFlow_Information_by_State" , paramUpdSpartan_WorkFlow , paramUpdInformation_by_StateId , paramUpdPhase , paramUpdState , paramUpdFolder , paramUpdVisible , paramUpdRead_Only , paramUpdRequired , paramUpdLabel ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Information_by_StateId);
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

using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Matrix_of_States
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Matrix_of_StatesService : ISpartan_WorkFlow_Matrix_of_StatesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> _Spartan_WorkFlow_Matrix_of_StatesRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Matrix_of_StatesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> Spartan_WorkFlow_Matrix_of_StatesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Matrix_of_StatesRepository = Spartan_WorkFlow_Matrix_of_StatesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>("sp_SelAllSpartan_WorkFlow_Matrix_of_States");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Matrix_of_States_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Matrix_of_States");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States
            {
                Matrix_of_StatesId = m.Matrix_of_StatesId
                ,Spartan_WorkFlow = m.Spartan_WorkFlow
                ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Phase.GetValueOrDefault(), Name = m.Phase_Name }
                ,State_Spartan_WorkFlow_State = new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State() { StateId = m.State.GetValueOrDefault(), Name = m.State_Name }
                ,Attribute_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Attribute.GetValueOrDefault(), Logical_Name = m.Attribute_Logical_Name }
                ,Visible = m.Visible.GetValueOrDefault()
                ,Required = m.Required.GetValueOrDefault()
                ,Read_Only = m.Read_Only.GetValueOrDefault()
                ,Label = m.Label
                ,Default_Value = m.Default_Value
                ,Help_Text = m.Help_Text


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Matrix_of_States>("sp_ListSelCount_Spartan_WorkFlow_Matrix_of_States", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Matrix_of_States>("sp_ListSelAll_Spartan_WorkFlow_Matrix_of_States", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States
                {
                    Spartan_WorkFlow = m.Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow,
                    Matrix_of_StatesId = m.Spartan_WorkFlow_Matrix_of_States_Matrix_of_StatesId,
                    Phase = m.Spartan_WorkFlow_Matrix_of_States_Phase,
                    State = m.Spartan_WorkFlow_Matrix_of_States_State,
                    Attribute = m.Spartan_WorkFlow_Matrix_of_States_Attribute,
                    Visible = m.Spartan_WorkFlow_Matrix_of_States_Visible ?? false,
                    Required = m.Spartan_WorkFlow_Matrix_of_States_Required ?? false,
                    Read_Only = m.Spartan_WorkFlow_Matrix_of_States_Read_Only ?? false,
                    Label = m.Spartan_WorkFlow_Matrix_of_States_Label,
                    Default_Value = m.Spartan_WorkFlow_Matrix_of_States_Default_Value,
                    Help_Text = m.Spartan_WorkFlow_Matrix_of_States_Help_Text,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Matrix_of_States>("sp_ListSelAll_Spartan_WorkFlow_Matrix_of_States", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_Matrix_of_StatesPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_Matrix_of_StatesPagingModel
                {
                    Spartan_WorkFlow_Matrix_of_Statess =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States
                {
                    Matrix_of_StatesId = m.Spartan_WorkFlow_Matrix_of_States_Matrix_of_StatesId
                    ,Spartan_WorkFlow = m.Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow
                    ,Phase = m.Spartan_WorkFlow_Matrix_of_States_Phase
                    ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Spartan_WorkFlow_Matrix_of_States_Phase.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Matrix_of_States_Phase_Name }
                    ,State = m.Spartan_WorkFlow_Matrix_of_States_State
                    ,State_Spartan_WorkFlow_State = new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State() { StateId = m.Spartan_WorkFlow_Matrix_of_States_State.GetValueOrDefault(), Name = m.Spartan_WorkFlow_Matrix_of_States_State_Name }
                    ,Attribute = m.Spartan_WorkFlow_Matrix_of_States_Attribute
                    ,Attribute_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Spartan_WorkFlow_Matrix_of_States_Attribute.GetValueOrDefault(), Logical_Name = m.Spartan_WorkFlow_Matrix_of_States_Attribute_Logical_Name }
                    ,Visible = m.Spartan_WorkFlow_Matrix_of_States_Visible ?? false
                    ,Required = m.Spartan_WorkFlow_Matrix_of_States_Required ?? false
                    ,Read_Only = m.Spartan_WorkFlow_Matrix_of_States_Read_Only ?? false
                    ,Label = m.Spartan_WorkFlow_Matrix_of_States_Label
                    ,Default_Value = m.Spartan_WorkFlow_Matrix_of_States_Default_Value
                    ,Help_Text = m.Spartan_WorkFlow_Matrix_of_States_Help_Text

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Matrix_of_StatesId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>("sp_GetSpartan_WorkFlow_Matrix_of_States", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Matrix_of_StatesId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Matrix_of_States>("sp_DelSpartan_WorkFlow_Matrix_of_States", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States entity)
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

                var padreAttribute = _dataProvider.GetParameter();
                padreAttribute.ParameterName = "Attribute";
                padreAttribute.DbType = DbType.Int32;
                padreAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var padreVisible = _dataProvider.GetParameter();
                padreVisible.ParameterName = "Visible";
                padreVisible.DbType = DbType.Boolean;
                padreVisible.Value = (object)entity.Visible ?? DBNull.Value;
                var padreRequired = _dataProvider.GetParameter();
                padreRequired.ParameterName = "Required";
                padreRequired.DbType = DbType.Boolean;
                padreRequired.Value = (object)entity.Required ?? DBNull.Value;
                var padreRead_Only = _dataProvider.GetParameter();
                padreRead_Only.ParameterName = "Read_Only";
                padreRead_Only.DbType = DbType.Boolean;
                padreRead_Only.Value = (object)entity.Read_Only ?? DBNull.Value;
                var padreLabel = _dataProvider.GetParameter();
                padreLabel.ParameterName = "Label";
                padreLabel.DbType = DbType.String;
                padreLabel.Value = (object)entity.Label ?? DBNull.Value;
                var padreDefault_Value = _dataProvider.GetParameter();
                padreDefault_Value.ParameterName = "Default_Value";
                padreDefault_Value.DbType = DbType.String;
                padreDefault_Value.Value = (object)entity.Default_Value ?? DBNull.Value;
                var padreHelp_Text = _dataProvider.GetParameter();
                padreHelp_Text.ParameterName = "Help_Text";
                padreHelp_Text.DbType = DbType.String;
                padreHelp_Text.Value = (object)entity.Help_Text ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Matrix_of_States>("sp_InsSpartan_WorkFlow_Matrix_of_States" , padreSpartan_WorkFlow

, padrePhase
, padreState
, padreAttribute
, padreVisible
, padreRequired
, padreRead_Only
, padreLabel
, padreDefault_Value
, padreHelp_Text
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Matrix_of_StatesId);

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

        public int Update(Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States entity)
        {
            int rta;
            try
            {

                var paramUpdSpartan_WorkFlow = _dataProvider.GetParameter();
                paramUpdSpartan_WorkFlow.ParameterName = "Spartan_WorkFlow";
                paramUpdSpartan_WorkFlow.DbType = DbType.Int32;
                paramUpdSpartan_WorkFlow.Value = (object)entity.Spartan_WorkFlow ?? DBNull.Value;
                var paramUpdMatrix_of_StatesId = _dataProvider.GetParameter();
                paramUpdMatrix_of_StatesId.ParameterName = "Matrix_of_StatesId";
                paramUpdMatrix_of_StatesId.DbType = DbType.Int32;
                paramUpdMatrix_of_StatesId.Value = (object)entity.Matrix_of_StatesId ?? DBNull.Value;
                var paramUpdPhase = _dataProvider.GetParameter();
                paramUpdPhase.ParameterName = "Phase";
                paramUpdPhase.DbType = DbType.Int32;
                paramUpdPhase.Value = (object)entity.Phase ?? DBNull.Value;

                var paramUpdState = _dataProvider.GetParameter();
                paramUpdState.ParameterName = "State";
                paramUpdState.DbType = DbType.Int32;
                paramUpdState.Value = (object)entity.State ?? DBNull.Value;

                var paramUpdAttribute = _dataProvider.GetParameter();
                paramUpdAttribute.ParameterName = "Attribute";
                paramUpdAttribute.DbType = DbType.Int32;
                paramUpdAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var paramUpdVisible = _dataProvider.GetParameter();
                paramUpdVisible.ParameterName = "Visible";
                paramUpdVisible.DbType = DbType.Boolean;
                paramUpdVisible.Value = (object)entity.Visible ?? DBNull.Value;
                var paramUpdRequired = _dataProvider.GetParameter();
                paramUpdRequired.ParameterName = "Required";
                paramUpdRequired.DbType = DbType.Boolean;
                paramUpdRequired.Value = (object)entity.Required ?? DBNull.Value;
                var paramUpdRead_Only = _dataProvider.GetParameter();
                paramUpdRead_Only.ParameterName = "Read_Only";
                paramUpdRead_Only.DbType = DbType.Boolean;
                paramUpdRead_Only.Value = (object)entity.Read_Only ?? DBNull.Value;
                var paramUpdLabel = _dataProvider.GetParameter();
                paramUpdLabel.ParameterName = "Label";
                paramUpdLabel.DbType = DbType.String;
                paramUpdLabel.Value = (object)entity.Label ?? DBNull.Value;
                var paramUpdDefault_Value = _dataProvider.GetParameter();
                paramUpdDefault_Value.ParameterName = "Default_Value";
                paramUpdDefault_Value.DbType = DbType.String;
                paramUpdDefault_Value.Value = (object)entity.Default_Value ?? DBNull.Value;
                var paramUpdHelp_Text = _dataProvider.GetParameter();
                paramUpdHelp_Text.ParameterName = "Help_Text";
                paramUpdHelp_Text.DbType = DbType.String;
                paramUpdHelp_Text.Value = (object)entity.Help_Text ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Matrix_of_States>("sp_UpdSpartan_WorkFlow_Matrix_of_States" , paramUpdSpartan_WorkFlow , paramUpdMatrix_of_StatesId , paramUpdPhase , paramUpdState , paramUpdAttribute , paramUpdVisible , paramUpdRequired , paramUpdRead_Only , paramUpdLabel , paramUpdDefault_Value , paramUpdHelp_Text ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Matrix_of_StatesId);
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

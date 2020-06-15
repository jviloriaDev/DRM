using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_State;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_State
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_StateService : ISpartan_WorkFlow_StateService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> _Spartan_WorkFlow_StateRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_StateService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> Spartan_WorkFlow_StateRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_StateRepository = Spartan_WorkFlow_StateRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_StateRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State>("sp_SelAllSpartan_WorkFlow_State");
        }

        public IList<Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_State_Complete>("sp_SelAllComplete_Spartan_WorkFlow_State");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State
            {
                StateId = m.StateId
                ,Spartan_WorkFlow = m.Spartan_WorkFlow
                ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Phase.GetValueOrDefault(), Name = m.Phase_Name }
                ,Attribute_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Attribute.GetValueOrDefault(), Logical_Name = m.Attribute_Logical_Name }
                ,State_Code = m.State_Code
                ,Name = m.Name
                ,Value = m.Value
                ,Text = m.Text


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_State>("sp_ListSelCount_Spartan_WorkFlow_State", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_State>("sp_ListSelAll_Spartan_WorkFlow_State", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State
                {
                    Spartan_WorkFlow = m.Spartan_WorkFlow_State_Spartan_WorkFlow,
                    StateId = m.Spartan_WorkFlow_State_StateId,
                    Phase = m.Spartan_WorkFlow_State_Phase,
                    Attribute = m.Spartan_WorkFlow_State_Attribute,
                    State_Code = m.Spartan_WorkFlow_State_State_Code,
                    Name = m.Spartan_WorkFlow_State_Name,
                    Value = m.Spartan_WorkFlow_State_Value,
                    Text = m.Spartan_WorkFlow_State_Text,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_StateRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_StateRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_StatePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_State>("sp_ListSelAll_Spartan_WorkFlow_State", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_StatePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_StatePagingModel
                {
                    Spartan_WorkFlow_States =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State
                {
                    StateId = m.Spartan_WorkFlow_State_StateId
                    ,Spartan_WorkFlow = m.Spartan_WorkFlow_State_Spartan_WorkFlow
                    ,Phase = m.Spartan_WorkFlow_State_Phase
                    ,Phase_Spartan_WorkFlow_Phases = new Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases() { PhasesId = m.Spartan_WorkFlow_State_Phase.GetValueOrDefault(), Name = m.Spartan_WorkFlow_State_Phase_Name }
                    ,Attribute = m.Spartan_WorkFlow_State_Attribute
                    ,Attribute_Spartan_Metadata = new Core.Classes.Spartan_Metadata.Spartan_Metadata() { AttributeId = m.Spartan_WorkFlow_State_Attribute.GetValueOrDefault(), Logical_Name = m.Spartan_WorkFlow_State_Attribute_Logical_Name }
                    ,State_Code = m.Spartan_WorkFlow_State_State_Code
                    ,Name = m.Spartan_WorkFlow_State_Name
                    ,Value = m.Spartan_WorkFlow_State_Value
                    ,Text = m.Spartan_WorkFlow_State_Text

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_StateRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "StateId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State>("sp_GetSpartan_WorkFlow_State", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "StateId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_State>("sp_DelSpartan_WorkFlow_State", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State entity)
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

                var padreAttribute = _dataProvider.GetParameter();
                padreAttribute.ParameterName = "Attribute";
                padreAttribute.DbType = DbType.Int32;
                padreAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var padreState_Code = _dataProvider.GetParameter();
                padreState_Code.ParameterName = "State_Code";
                padreState_Code.DbType = DbType.Int32;
                padreState_Code.Value = (object)entity.State_Code ?? DBNull.Value;

                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = (object)entity.Name ?? DBNull.Value;
                var padreValue = _dataProvider.GetParameter();
                padreValue.ParameterName = "Value";
                padreValue.DbType = DbType.Int32;
                padreValue.Value = (object)entity.Value ?? DBNull.Value;

                var padreText = _dataProvider.GetParameter();
                padreText.ParameterName = "Text";
                padreText.DbType = DbType.String;
                padreText.Value = (object)entity.Text ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_State>("sp_InsSpartan_WorkFlow_State" , padreSpartan_WorkFlow

, padrePhase
, padreAttribute
, padreState_Code
, padreName
, padreValue
, padreText
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.StateId);

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

        public int Update(Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State entity)
        {
            int rta;
            try
            {

                var paramUpdSpartan_WorkFlow = _dataProvider.GetParameter();
                paramUpdSpartan_WorkFlow.ParameterName = "Spartan_WorkFlow";
                paramUpdSpartan_WorkFlow.DbType = DbType.Int32;
                paramUpdSpartan_WorkFlow.Value = (object)entity.Spartan_WorkFlow ?? DBNull.Value;
                var paramUpdStateId = _dataProvider.GetParameter();
                paramUpdStateId.ParameterName = "StateId";
                paramUpdStateId.DbType = DbType.Int32;
                paramUpdStateId.Value = (object)entity.StateId ?? DBNull.Value;
                var paramUpdPhase = _dataProvider.GetParameter();
                paramUpdPhase.ParameterName = "Phase";
                paramUpdPhase.DbType = DbType.Int32;
                paramUpdPhase.Value = (object)entity.Phase ?? DBNull.Value;

                var paramUpdAttribute = _dataProvider.GetParameter();
                paramUpdAttribute.ParameterName = "Attribute";
                paramUpdAttribute.DbType = DbType.Int32;
                paramUpdAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var paramUpdState_Code = _dataProvider.GetParameter();
                paramUpdState_Code.ParameterName = "State_Code";
                paramUpdState_Code.DbType = DbType.Int32;
                paramUpdState_Code.Value = (object)entity.State_Code ?? DBNull.Value;

                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)entity.Name ?? DBNull.Value;
                var paramUpdValue = _dataProvider.GetParameter();
                paramUpdValue.ParameterName = "Value";
                paramUpdValue.DbType = DbType.Int32;
                paramUpdValue.Value = (object)entity.Value ?? DBNull.Value;

                var paramUpdText = _dataProvider.GetParameter();
                paramUpdText.ParameterName = "Text";
                paramUpdText.DbType = DbType.String;
                paramUpdText.Value = (object)entity.Text ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_State>("sp_UpdSpartan_WorkFlow_State" , paramUpdSpartan_WorkFlow , paramUpdStateId , paramUpdPhase , paramUpdAttribute , paramUpdState_Code , paramUpdName , paramUpdValue , paramUpdText ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.StateId);
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

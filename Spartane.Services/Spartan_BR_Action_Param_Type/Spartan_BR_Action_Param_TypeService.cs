using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Action_Param_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Action_Param_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Action_Param_TypeService : ISpartan_BR_Action_Param_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> _Spartan_BR_Action_Param_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Action_Param_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> Spartan_BR_Action_Param_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Action_Param_TypeRepository = Spartan_BR_Action_Param_TypeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Action_Param_TypeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type>("sp_SelAllSpartan_BR_Action_Param_Type");
        }

        public IList<Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Action_Param_Type_Complete>("sp_SelAllComplete_Spartan_BR_Action_Param_Type");
            return data.Select(m => new Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type
            {
                ParameterTypeId = m.ParameterTypeId
                ,Description = m.Description
                ,Presentation_Control_Type_Spartan_BR_Presentation_Control_Type = new Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type() { PresentationControlTypeId = m.Presentation_Control_Type.GetValueOrDefault(), Description = m.Presentation_Control_Type_Description }
                ,Query_for_Fill_Condition = m.Query_for_Fill_Condition
                ,Code_for_Fill_Condition = m.Code_for_Fill_Condition
                ,Implementation_Code = m.Implementation_Code


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Action_Param_Type>("sp_ListSelCount_Spartan_BR_Action_Param_Type", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Action_Param_Type>("sp_ListSelAll_Spartan_BR_Action_Param_Type", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type
                {
                    ParameterTypeId = m.Spartan_BR_Action_Param_Type_ParameterTypeId,
                    Description = m.Spartan_BR_Action_Param_Type_Description,
                    Presentation_Control_Type = m.Spartan_BR_Action_Param_Type_Presentation_Control_Type,
                    Query_for_Fill_Condition = m.Spartan_BR_Action_Param_Type_Query_for_Fill_Condition,
                    Code_for_Fill_Condition = m.Spartan_BR_Action_Param_Type_Code_for_Fill_Condition,
                    Implementation_Code = m.Spartan_BR_Action_Param_Type_Implementation_Code,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Action_Param_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Action_Param_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Action_Param_Type>("sp_ListSelAll_Spartan_BR_Action_Param_Type", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Action_Param_TypePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Action_Param_TypePagingModel
                {
                    Spartan_BR_Action_Param_Types =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type
                {
                    ParameterTypeId = m.Spartan_BR_Action_Param_Type_ParameterTypeId
                    ,Description = m.Spartan_BR_Action_Param_Type_Description
                    ,Presentation_Control_Type = m.Spartan_BR_Action_Param_Type_Presentation_Control_Type
                    ,Presentation_Control_Type_Spartan_BR_Presentation_Control_Type = new Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type() { PresentationControlTypeId = m.Spartan_BR_Action_Param_Type_Presentation_Control_Type.GetValueOrDefault(), Description = m.Spartan_BR_Action_Param_Type_Presentation_Control_Type_Description }
                    ,Query_for_Fill_Condition = m.Spartan_BR_Action_Param_Type_Query_for_Fill_Condition
                    ,Code_for_Fill_Condition = m.Spartan_BR_Action_Param_Type_Code_for_Fill_Condition
                    ,Implementation_Code = m.Spartan_BR_Action_Param_Type_Implementation_Code

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Action_Param_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ParameterTypeId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type>("sp_GetSpartan_BR_Action_Param_Type", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ParameterTypeId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Action_Param_Type>("sp_DelSpartan_BR_Action_Param_Type", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
                var padrePresentation_Control_Type = _dataProvider.GetParameter();
                padrePresentation_Control_Type.ParameterName = "Presentation_Control_Type";
                padrePresentation_Control_Type.DbType = DbType.Int32;
                padrePresentation_Control_Type.Value = (object)entity.Presentation_Control_Type ?? DBNull.Value;

                var padreQuery_for_Fill_Condition = _dataProvider.GetParameter();
                padreQuery_for_Fill_Condition.ParameterName = "Query_for_Fill_Condition";
                padreQuery_for_Fill_Condition.DbType = DbType.String;
                padreQuery_for_Fill_Condition.Value = (object)entity.Query_for_Fill_Condition ?? DBNull.Value;
                var padreCode_for_Fill_Condition = _dataProvider.GetParameter();
                padreCode_for_Fill_Condition.ParameterName = "Code_for_Fill_Condition";
                padreCode_for_Fill_Condition.DbType = DbType.String;
                padreCode_for_Fill_Condition.Value = (object)entity.Code_for_Fill_Condition ?? DBNull.Value;
                var padreImplementation_Code = _dataProvider.GetParameter();
                padreImplementation_Code.ParameterName = "Implementation_Code";
                padreImplementation_Code.DbType = DbType.String;
                padreImplementation_Code.Value = (object)entity.Implementation_Code ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Action_Param_Type>("sp_InsSpartan_BR_Action_Param_Type" , padreDescription
, padrePresentation_Control_Type
, padreQuery_for_Fill_Condition
, padreCode_for_Fill_Condition
, padreImplementation_Code
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ParameterTypeId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type entity)
        {
            int rta;
            try
            {

                var paramUpdParameterTypeId = _dataProvider.GetParameter();
                paramUpdParameterTypeId.ParameterName = "ParameterTypeId";
                paramUpdParameterTypeId.DbType = DbType.Int32;
                paramUpdParameterTypeId.Value = entity.ParameterTypeId;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = entity.Description;
                var paramUpdPresentation_Control_Type = _dataProvider.GetParameter();
                paramUpdPresentation_Control_Type.ParameterName = "Presentation_Control_Type";
                paramUpdPresentation_Control_Type.DbType = DbType.Int32;
                if (entity.Presentation_Control_Type == null)
                    paramUpdPresentation_Control_Type.Value = DBNull.Value;
                else
                    paramUpdPresentation_Control_Type.Value = entity.Presentation_Control_Type;

                var paramUpdQuery_for_Fill_Condition = _dataProvider.GetParameter();
                paramUpdQuery_for_Fill_Condition.ParameterName = "Query_for_Fill_Condition";
                paramUpdQuery_for_Fill_Condition.DbType = DbType.String;
                paramUpdQuery_for_Fill_Condition.Value = entity.Query_for_Fill_Condition;
                var paramUpdCode_for_Fill_Condition = _dataProvider.GetParameter();
                paramUpdCode_for_Fill_Condition.ParameterName = "Code_for_Fill_Condition";
                paramUpdCode_for_Fill_Condition.DbType = DbType.String;
                paramUpdCode_for_Fill_Condition.Value = entity.Code_for_Fill_Condition;
                var paramUpdImplementation_Code = _dataProvider.GetParameter();
                paramUpdImplementation_Code.ParameterName = "Implementation_Code";
                paramUpdImplementation_Code.DbType = DbType.String;
                paramUpdImplementation_Code.Value = entity.Implementation_Code;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Action_Param_Type>("sp_UpdSpartan_BR_Action_Param_Type" , paramUpdParameterTypeId , paramUpdDescription , paramUpdPresentation_Control_Type , paramUpdQuery_for_Fill_Condition , paramUpdCode_for_Fill_Condition , paramUpdImplementation_Code ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ParameterTypeId);
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


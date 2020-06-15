using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Action_Configuration_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Action_Configuration_DetailService : ISpartan_BR_Action_Configuration_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> _Spartan_BR_Action_Configuration_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Action_Configuration_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> Spartan_BR_Action_Configuration_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Action_Configuration_DetailRepository = Spartan_BR_Action_Configuration_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Action_Configuration_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>("sp_SelAllSpartan_BR_Action_Configuration_Detail");
        }

        public IList<Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Action_Configuration_Detail_Complete>("sp_SelAllComplete_Spartan_BR_Action_Configuration_Detail");
            return data.Select(m => new Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail
            {
                ActionConfigurationId = m.ActionConfigurationId
                ,Action = m.Action
                ,Parameter_Name = m.Parameter_Name
                ,Parameter_Type_Spartan_BR_Action_Param_Type = new Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type() { ParameterTypeId = m.Parameter_Type.GetValueOrDefault(), Description = m.Parameter_Type_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Action_Configuration_Detail>("sp_ListSelCount_Spartan_BR_Action_Configuration_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Action_Configuration_Detail>("sp_ListSelAll_Spartan_BR_Action_Configuration_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail
                {
                    ActionConfigurationId = m.Spartan_BR_Action_Configuration_Detail_ActionConfigurationId,
                    Action = m.Spartan_BR_Action_Configuration_Detail_Action,
                    Parameter_Name = m.Spartan_BR_Action_Configuration_Detail_Parameter_Name,
                    Parameter_Type = m.Spartan_BR_Action_Configuration_Detail_Parameter_Type,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Action_Configuration_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Action_Configuration_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Action_Configuration_Detail>("sp_ListSelAll_Spartan_BR_Action_Configuration_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Action_Configuration_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Action_Configuration_DetailPagingModel
                {
                    Spartan_BR_Action_Configuration_Details =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail
                {
                    ActionConfigurationId = m.Spartan_BR_Action_Configuration_Detail_ActionConfigurationId
                    ,Action = m.Spartan_BR_Action_Configuration_Detail_Action
                    ,Parameter_Name = m.Spartan_BR_Action_Configuration_Detail_Parameter_Name
                    ,Parameter_Type = m.Spartan_BR_Action_Configuration_Detail_Parameter_Type
                    ,Parameter_Type_Spartan_BR_Action_Param_Type = new Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type() { ParameterTypeId = m.Spartan_BR_Action_Configuration_Detail_Parameter_Type.GetValueOrDefault(), Description = m.Spartan_BR_Action_Configuration_Detail_Parameter_Type_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Action_Configuration_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ActionConfigurationId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>("sp_GetSpartan_BR_Action_Configuration_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ActionConfigurationId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Action_Configuration_Detail>("sp_DelSpartan_BR_Action_Configuration_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail entity)
        {
            int rta;
            try
            {

		                var padreAction = _dataProvider.GetParameter();
                padreAction.ParameterName = "Action";
                padreAction.DbType = DbType.Int32;
                padreAction.Value = (object)entity.Action ?? DBNull.Value;
                var padreParameter_Name = _dataProvider.GetParameter();
                padreParameter_Name.ParameterName = "Parameter_Name";
                padreParameter_Name.DbType = DbType.String;
                padreParameter_Name.Value = (object)entity.Parameter_Name ?? DBNull.Value;
                var padreParameter_Type = _dataProvider.GetParameter();
                padreParameter_Type.ParameterName = "Parameter_Type";
                padreParameter_Type.DbType = DbType.Int32;
                padreParameter_Type.Value = (object)entity.Parameter_Type ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Action_Configuration_Detail>("sp_InsSpartan_BR_Action_Configuration_Detail" , padreAction
, padreParameter_Name
, padreParameter_Type
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ActionConfigurationId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdActionConfigurationId = _dataProvider.GetParameter();
                paramUpdActionConfigurationId.ParameterName = "ActionConfigurationId";
                paramUpdActionConfigurationId.DbType = DbType.Int32;
                paramUpdActionConfigurationId.Value = entity.ActionConfigurationId;
                var paramUpdAction = _dataProvider.GetParameter();
                paramUpdAction.ParameterName = "Action";
                paramUpdAction.DbType = DbType.Int32;
                paramUpdAction.Value = entity.Action;
                var paramUpdParameter_Name = _dataProvider.GetParameter();
                paramUpdParameter_Name.ParameterName = "Parameter_Name";
                paramUpdParameter_Name.DbType = DbType.String;
                paramUpdParameter_Name.Value = entity.Parameter_Name;
                var paramUpdParameter_Type = _dataProvider.GetParameter();
                paramUpdParameter_Type.ParameterName = "Parameter_Type";
                paramUpdParameter_Type.DbType = DbType.Int32;
                if (entity.Parameter_Type == null)
                    paramUpdParameter_Type.Value = DBNull.Value;
                else
                    paramUpdParameter_Type.Value = entity.Parameter_Type;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Action_Configuration_Detail>("sp_UpdSpartan_BR_Action_Configuration_Detail" , paramUpdActionConfigurationId , paramUpdParameter_Name , paramUpdParameter_Type ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ActionConfigurationId);
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


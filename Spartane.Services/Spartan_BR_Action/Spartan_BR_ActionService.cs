using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Action;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Action
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_ActionService : ISpartan_BR_ActionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> _Spartan_BR_ActionRepository;
        #endregion

        #region Ctor
        public Spartan_BR_ActionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> Spartan_BR_ActionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_ActionRepository = Spartan_BR_ActionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_ActionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action>("sp_SelAllSpartan_BR_Action");
        }

        public IList<Core.Classes.Spartan_BR_Action.Spartan_BR_Action> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Action_Complete>("sp_SelAllComplete_Spartan_BR_Action");
            return data.Select(m => new Core.Classes.Spartan_BR_Action.Spartan_BR_Action
            {
                ActionId = m.ActionId
                ,Description = m.Description
                ,Classification_Spartan_BR_Action_Classification = new Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification() { ClassificationId = m.Classification.GetValueOrDefault(), Description = m.Classification_Description }
                ,Implementation_Code = m.Implementation_Code


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Action>("sp_ListSelCount_Spartan_BR_Action", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Action>("sp_ListSelAll_Spartan_BR_Action", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action
                {
                    ActionId = m.Spartan_BR_Action_ActionId,
                    Description = m.Spartan_BR_Action_Description,
                    Classification = m.Spartan_BR_Action_Classification,
                    Implementation_Code = m.Spartan_BR_Action_Implementation_Code,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_ActionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_ActionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_ActionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Action>("sp_ListSelAll_Spartan_BR_Action", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_ActionPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_ActionPagingModel
                {
                    Spartan_BR_Actions =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action
                {
                    ActionId = m.Spartan_BR_Action_ActionId
                    ,Description = m.Spartan_BR_Action_Description
                    ,Classification = m.Spartan_BR_Action_Classification
                    ,Classification_Spartan_BR_Action_Classification = new Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification() { ClassificationId = m.Spartan_BR_Action_Classification.GetValueOrDefault(), Description = m.Spartan_BR_Action_Classification_Description }
                    ,Implementation_Code = m.Spartan_BR_Action_Implementation_Code

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_ActionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ActionId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action>("sp_GetSpartan_BR_Action", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ActionId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Action>("sp_DelSpartan_BR_Action", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
                var padreClassification = _dataProvider.GetParameter();
                padreClassification.ParameterName = "Classification";
                padreClassification.DbType = DbType.Int16;
                padreClassification.Value = (object)entity.Classification ?? DBNull.Value;

                var padreImplementation_Code = _dataProvider.GetParameter();
                padreImplementation_Code.ParameterName = "Implementation_Code";
                padreImplementation_Code.DbType = DbType.String;
                padreImplementation_Code.Value = (object)entity.Implementation_Code ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Action>("sp_InsSpartan_BR_Action" , padreDescription
, padreClassification
, padreImplementation_Code
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ActionId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action entity)
        {
            int rta;
            try
            {

                var paramUpdActionId = _dataProvider.GetParameter();
                paramUpdActionId.ParameterName = "ActionId";
                paramUpdActionId.DbType = DbType.Int32;
                paramUpdActionId.Value = entity.ActionId;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = entity.Description;
                var paramUpdClassification = _dataProvider.GetParameter();
                paramUpdClassification.ParameterName = "Classification";
                paramUpdClassification.DbType = DbType.Int16;
                if (entity.Classification == null)
                    paramUpdClassification.Value = DBNull.Value;
                else
                    paramUpdClassification.Value = entity.Classification;

                var paramUpdImplementation_Code = _dataProvider.GetParameter();
                paramUpdImplementation_Code.ParameterName = "Implementation_Code";
                paramUpdImplementation_Code.DbType = DbType.String;
                paramUpdImplementation_Code.Value = entity.Implementation_Code;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Action>("sp_UpdSpartan_BR_Action" , paramUpdActionId , paramUpdDescription , paramUpdClassification , paramUpdImplementation_Code ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ActionId);
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


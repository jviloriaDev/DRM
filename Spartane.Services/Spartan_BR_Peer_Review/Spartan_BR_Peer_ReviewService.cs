using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Peer_Review;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Peer_Review
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Peer_ReviewService : ISpartan_BR_Peer_ReviewService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> _Spartan_BR_Peer_ReviewRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Peer_ReviewService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> Spartan_BR_Peer_ReviewRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Peer_ReviewRepository = Spartan_BR_Peer_ReviewRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Peer_ReviewRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>("sp_SelAllSpartan_BR_Peer_Review");
        }

        public IList<Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Peer_Review_Complete>("sp_SelAllComplete_Spartan_BR_Peer_Review");
            return data.Select(m => new Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review
            {
                Key_Peer_Review = m.Key_Peer_Review
                ,User_that_reviewed_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.User_that_reviewed.GetValueOrDefault(), Name = m.User_that_reviewed_Name }
                ,Acceptance_Criteria = m.Acceptance_Criteria
                ,It_worked = m.It_worked.GetValueOrDefault()
                ,Rejection_reason_Spartan_BR_Rejection_Reason = new Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason() { Key_Rejection_Reason = m.Rejection_reason.GetValueOrDefault(), Description = m.Rejection_reason_Description }
                ,Comments = m.Comments
                ,Evidence = m.Evidence
                ,Business_Rule = m.Business_Rule


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Peer_Review>("sp_ListSelCount_Spartan_BR_Peer_Review", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Peer_Review>("sp_ListSelAll_Spartan_BR_Peer_Review", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review
                {
                    Key_Peer_Review = m.Spartan_BR_Peer_Review_Key_Peer_Review,
                    User_that_reviewed = m.Spartan_BR_Peer_Review_User_that_reviewed,
                    Acceptance_Criteria = m.Spartan_BR_Peer_Review_Acceptance_Criteria,
                    It_worked = m.Spartan_BR_Peer_Review_It_worked ?? false,
                    Rejection_reason = m.Spartan_BR_Peer_Review_Rejection_reason,
                    Comments = m.Spartan_BR_Peer_Review_Comments,
                    Evidence = m.Spartan_BR_Peer_Review_Evidence,
                    Business_Rule = m.Spartan_BR_Peer_Review_Business_Rule,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Peer_ReviewRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Peer_ReviewRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_ReviewPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Peer_Review>("sp_ListSelAll_Spartan_BR_Peer_Review", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Peer_ReviewPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Peer_ReviewPagingModel
                {
                    Spartan_BR_Peer_Reviews =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review
                {
                    Key_Peer_Review = m.Spartan_BR_Peer_Review_Key_Peer_Review
                    ,User_that_reviewed = m.Spartan_BR_Peer_Review_User_that_reviewed
                    ,User_that_reviewed_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_BR_Peer_Review_User_that_reviewed.GetValueOrDefault(), Name = m.Spartan_BR_Peer_Review_User_that_reviewed_Name }
                    ,Acceptance_Criteria = m.Spartan_BR_Peer_Review_Acceptance_Criteria
                    ,It_worked = m.Spartan_BR_Peer_Review_It_worked ?? false
                    ,Rejection_reason = m.Spartan_BR_Peer_Review_Rejection_reason
                    ,Rejection_reason_Spartan_BR_Rejection_Reason = new Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason() { Key_Rejection_Reason = m.Spartan_BR_Peer_Review_Rejection_reason.GetValueOrDefault(), Description = m.Spartan_BR_Peer_Review_Rejection_reason_Description }
                    ,Comments = m.Spartan_BR_Peer_Review_Comments
                    ,Evidence = m.Spartan_BR_Peer_Review_Evidence
                    ,Business_Rule = m.Spartan_BR_Peer_Review_Business_Rule

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Peer_ReviewRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Key_Peer_Review";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>("sp_GetSpartan_BR_Peer_Review", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Key_Peer_Review";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Peer_Review>("sp_DelSpartan_BR_Peer_Review", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review entity)
        {
            int rta;
            try
            {

		var padreKey_Peer_Review = _dataProvider.GetParameter();
                padreKey_Peer_Review.ParameterName = "Key_Peer_Review";
                padreKey_Peer_Review.DbType = DbType.Int32;
                padreKey_Peer_Review.Value = (object)entity.Key_Peer_Review ?? DBNull.Value;
                var padreUser_that_reviewed = _dataProvider.GetParameter();
                padreUser_that_reviewed.ParameterName = "User_that_reviewed";
                padreUser_that_reviewed.DbType = DbType.Int32;
                padreUser_that_reviewed.Value = (object)entity.User_that_reviewed ?? DBNull.Value;

                var padreAcceptance_Criteria = _dataProvider.GetParameter();
                padreAcceptance_Criteria.ParameterName = "Acceptance_Criteria";
                padreAcceptance_Criteria.DbType = DbType.String;
                padreAcceptance_Criteria.Value = (object)entity.Acceptance_Criteria ?? DBNull.Value;
                var padreIt_worked = _dataProvider.GetParameter();
                padreIt_worked.ParameterName = "It_worked";
                padreIt_worked.DbType = DbType.Boolean;
                padreIt_worked.Value = (object)entity.It_worked ?? DBNull.Value;
                var padreRejection_reason = _dataProvider.GetParameter();
                padreRejection_reason.ParameterName = "Rejection_reason";
                padreRejection_reason.DbType = DbType.Int32;
                padreRejection_reason.Value = (object)entity.Rejection_reason ?? DBNull.Value;

                var padreComments = _dataProvider.GetParameter();
                padreComments.ParameterName = "Comments";
                padreComments.DbType = DbType.String;
                padreComments.Value = (object)entity.Comments ?? DBNull.Value;
                var padreEvidence = _dataProvider.GetParameter();
                padreEvidence.ParameterName = "Evidence";
                padreEvidence.DbType = DbType.Int32;
                padreEvidence.Value = (object)entity.Evidence ?? DBNull.Value;

                var padreBusiness_Rule = _dataProvider.GetParameter();
                padreBusiness_Rule.ParameterName = "Business_Rule";
                padreBusiness_Rule.DbType = DbType.Int32;
                padreBusiness_Rule.Value = (object)entity.Business_Rule ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Peer_Review>("sp_InsSpartan_BR_Peer_Review" 
, padreUser_that_reviewed
, padreAcceptance_Criteria
, padreIt_worked
, padreRejection_reason
, padreComments
, padreEvidence
, padreBusiness_Rule
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Key_Peer_Review);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review entity)
        {
            int rta;
            try
            {

                var paramUpdKey_Peer_Review = _dataProvider.GetParameter();
                paramUpdKey_Peer_Review.ParameterName = "Key_Peer_Review";
                paramUpdKey_Peer_Review.DbType = DbType.Int32;
                paramUpdKey_Peer_Review.Value = (object)entity.Key_Peer_Review ?? DBNull.Value;
                var paramUpdUser_that_reviewed = _dataProvider.GetParameter();
                paramUpdUser_that_reviewed.ParameterName = "User_that_reviewed";
                paramUpdUser_that_reviewed.DbType = DbType.Int32;
                paramUpdUser_that_reviewed.Value = (object)entity.User_that_reviewed ?? DBNull.Value;

                var paramUpdAcceptance_Criteria = _dataProvider.GetParameter();
                paramUpdAcceptance_Criteria.ParameterName = "Acceptance_Criteria";
                paramUpdAcceptance_Criteria.DbType = DbType.String;
                paramUpdAcceptance_Criteria.Value = (object)entity.Acceptance_Criteria ?? DBNull.Value;
                var paramUpdIt_worked = _dataProvider.GetParameter();
                paramUpdIt_worked.ParameterName = "It_worked";
                paramUpdIt_worked.DbType = DbType.Boolean;
                paramUpdIt_worked.Value = (object)entity.It_worked ?? DBNull.Value;
                var paramUpdRejection_reason = _dataProvider.GetParameter();
                paramUpdRejection_reason.ParameterName = "Rejection_reason";
                paramUpdRejection_reason.DbType = DbType.Int32;
                paramUpdRejection_reason.Value = (object)entity.Rejection_reason ?? DBNull.Value;

                var paramUpdComments = _dataProvider.GetParameter();
                paramUpdComments.ParameterName = "Comments";
                paramUpdComments.DbType = DbType.String;
                paramUpdComments.Value = (object)entity.Comments ?? DBNull.Value;
                var paramUpdEvidence = _dataProvider.GetParameter();
                paramUpdEvidence.ParameterName = "Evidence";
                paramUpdEvidence.DbType = DbType.Int32;
                paramUpdEvidence.Value = (object)entity.Evidence ?? DBNull.Value;

                var paramUpdBusiness_Rule = _dataProvider.GetParameter();
                paramUpdBusiness_Rule.ParameterName = "Business_Rule";
                paramUpdBusiness_Rule.DbType = DbType.Int32;
                paramUpdBusiness_Rule.Value = (object)entity.Business_Rule ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Peer_Review>("sp_UpdSpartan_BR_Peer_Review" , paramUpdKey_Peer_Review , paramUpdUser_that_reviewed , paramUpdAcceptance_Criteria , paramUpdIt_worked , paramUpdRejection_reason , paramUpdComments , paramUpdEvidence , paramUpdBusiness_Rule ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Key_Peer_Review);
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

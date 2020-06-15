using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Business_Rule_Creation;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Business_Rule_Creation
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Business_Rule_CreationService : IBusiness_Rule_CreationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation> _Business_Rule_CreationRepository;
        #endregion

        #region Ctor
        public Business_Rule_CreationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation> Business_Rule_CreationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Business_Rule_CreationRepository = Business_Rule_CreationRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Business_Rule_CreationRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation>("sp_SelAllBusiness_Rule_Creation");
        }

        public IList<Core.Classes.Business_Rule_Creation.Business_Rule_Creation> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallBusiness_Rule_Creation_Complete>("sp_SelAllComplete_Business_Rule_Creation");
            return data.Select(m => new Core.Classes.Business_Rule_Creation.Business_Rule_Creation
            {
                Key_Business_Rule_Creation = m.Key_Business_Rule_Creation
                ,User_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.User.GetValueOrDefault(), Name = m.User_Name }
                ,Creation_Date = m.Creation_Date
                ,Creation_Hour = m.Creation_Hour
                ,Last_Updated_Date = m.Last_Updated_Date
                ,Last_Updated_Hour = m.Last_Updated_Hour
                ,Time_that_took = m.Time_that_took
                ,Name = m.Name
                ,Documentation = m.Documentation
                ,Status_Spartan_BR_Status = new Core.Classes.Spartan_BR_Status.Spartan_BR_Status() { StatusId = m.Status.GetValueOrDefault(), Description = m.Status_Description }
                ,Complexity_Spartan_BR_Complexity = new Core.Classes.Spartan_BR_Complexity.Spartan_BR_Complexity() { Key_Complexity = m.Complexity.GetValueOrDefault(), Description = m.Complexity_Description }

                ,
                Attribute = m.Attribute
                ,
                Object = m.Object
                ,
                AttributeGrid = m.AttributeGrid
                ,
                Implementation_Code = m.Implementation_Code

            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Business_Rule_Creation>("sp_ListSelCount_Business_Rule_Creation", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllBusiness_Rule_Creation>("sp_ListSelAll_Business_Rule_Creation", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation
                {
                    Key_Business_Rule_Creation = m.Business_Rule_Creation_Key_Business_Rule_Creation,
                    User = m.Business_Rule_Creation_User,
                    Creation_Date = m.Business_Rule_Creation_Creation_Date,
                    Creation_Hour = m.Business_Rule_Creation_Creation_Hour,
                    Last_Updated_Date = m.Business_Rule_Creation_Last_Updated_Date,
                    Last_Updated_Hour = m.Business_Rule_Creation_Last_Updated_Hour,
                    Time_that_took = m.Business_Rule_Creation_Time_that_took,
                    Name = m.Business_Rule_Creation_Name,
                    Documentation = m.Business_Rule_Creation_Documentation,
                    Status = m.Business_Rule_Creation_Status,
                    Complexity = m.Business_Rule_Creation_Complexity,
                    Attribute = m.Business_Rule_Creation_Attribute,
                    Object = m.Business_Rule_Creation_Object,
                    AttributeGrid = m.Business_Rule_Creation_AttributeGrid,
                    Implementation_Code = m.Business_Rule_Creation_Implementation_Code
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

        public IList<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Business_Rule_CreationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Business_Rule_CreationRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_CreationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllBusiness_Rule_Creation>("sp_ListSelAll_Business_Rule_Creation", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Business_Rule_CreationPagingModel result = null;

            if (data != null)
            {
                result = new Business_Rule_CreationPagingModel
                {
                    Business_Rule_Creations =
                        data.Select(m => new Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation
                {
                    Key_Business_Rule_Creation = m.Business_Rule_Creation_Key_Business_Rule_Creation
                    ,User = m.Business_Rule_Creation_User
                    ,User_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Business_Rule_Creation_User.GetValueOrDefault(), Name = m.Business_Rule_Creation_User_Name }
                    ,Creation_Date = m.Business_Rule_Creation_Creation_Date
                    ,Creation_Hour = m.Business_Rule_Creation_Creation_Hour
                    ,Last_Updated_Date = m.Business_Rule_Creation_Last_Updated_Date
                    ,Last_Updated_Hour = m.Business_Rule_Creation_Last_Updated_Hour
                    ,Time_that_took = m.Business_Rule_Creation_Time_that_took
                    ,Name = m.Business_Rule_Creation_Name
                    ,Documentation = m.Business_Rule_Creation_Documentation
                    ,Status = m.Business_Rule_Creation_Status
                    ,Status_Spartan_BR_Status = new Core.Classes.Spartan_BR_Status.Spartan_BR_Status() { StatusId = m.Business_Rule_Creation_Status.GetValueOrDefault(), Description = m.Business_Rule_Creation_Status_Description }
                    ,Complexity = m.Business_Rule_Creation_Complexity
                    ,Complexity_Spartan_BR_Complexity = new Core.Classes.Spartan_BR_Complexity.Spartan_BR_Complexity() { Key_Complexity = m.Business_Rule_Creation_Complexity.GetValueOrDefault(), Description = m.Business_Rule_Creation_Complexity_Description }
                    , Attribute = m.Business_Rule_Creation_Attribute
                    ,AttributeGrid = m.Business_Rule_Creation_AttributeGrid
                    ,
                    Object = m.Business_Rule_Creation_Object
                    ,
                    Implementation_Code = m.Business_Rule_Creation_Implementation_Code
                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Business_Rule_CreationRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Key_Business_Rule_Creation";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation>("sp_GetBusiness_Rule_Creation", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Key_Business_Rule_Creation";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelBusiness_Rule_Creation>("sp_DelBusiness_Rule_Creation", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation entity)
        {
            int rta;
            try
            {

		var padreKey_Business_Rule_Creation = _dataProvider.GetParameter();
                padreKey_Business_Rule_Creation.ParameterName = "Key_Business_Rule_Creation";
                padreKey_Business_Rule_Creation.DbType = DbType.Int32;
                padreKey_Business_Rule_Creation.Value = (object)entity.Key_Business_Rule_Creation ?? DBNull.Value;
                var padreUser = _dataProvider.GetParameter();
                padreUser.ParameterName = "User";
                padreUser.DbType = DbType.Int32;
                padreUser.Value = (object)entity.User ?? DBNull.Value;

                var padreCreation_Date = _dataProvider.GetParameter();
                padreCreation_Date.ParameterName = "Creation_Date";
                padreCreation_Date.DbType = DbType.DateTime;
                padreCreation_Date.Value = (object)entity.Creation_Date ?? DBNull.Value;

                var padreCreation_Hour = _dataProvider.GetParameter();
                padreCreation_Hour.ParameterName = "Creation_Hour";
                padreCreation_Hour.DbType = DbType.String;
                padreCreation_Hour.Value = (object)entity.Creation_Hour ?? DBNull.Value;
                var padreLast_Updated_Date = _dataProvider.GetParameter();
                padreLast_Updated_Date.ParameterName = "Last_Updated_Date";
                padreLast_Updated_Date.DbType = DbType.DateTime;
                padreLast_Updated_Date.Value = (object)entity.Last_Updated_Date ?? DBNull.Value;

                var padreLast_Updated_Hour = _dataProvider.GetParameter();
                padreLast_Updated_Hour.ParameterName = "Last_Updated_Hour";
                padreLast_Updated_Hour.DbType = DbType.String;
                padreLast_Updated_Hour.Value = (object)entity.Last_Updated_Hour ?? DBNull.Value;
                var padreTime_that_took = _dataProvider.GetParameter();
                padreTime_that_took.ParameterName = "Time_that_took";
                padreTime_that_took.DbType = DbType.Int32;
                padreTime_that_took.Value = (object)entity.Time_that_took ?? DBNull.Value;

                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = (object)entity.Name ?? DBNull.Value;
                var padreDocumentation = _dataProvider.GetParameter();
                padreDocumentation.ParameterName = "Documentation";
                padreDocumentation.DbType = DbType.Int32;
                padreDocumentation.Value = (object)entity.Documentation ?? DBNull.Value;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                padreStatus.Value = (object)entity.Status ?? DBNull.Value;

                var padreComplexity = _dataProvider.GetParameter();
                padreComplexity.ParameterName = "Complexity";
                padreComplexity.DbType = DbType.Int32;
                padreComplexity.Value = (object)entity.Complexity ?? DBNull.Value;

                var padreAttribute = _dataProvider.GetParameter();
                padreAttribute.ParameterName = "Attribute";
                padreAttribute.DbType = DbType.Int32;
                padreAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                padreObject.Value = (object)entity.Object ?? DBNull.Value;

                var padreAttributeGrid = _dataProvider.GetParameter();
                padreAttributeGrid.ParameterName = "AttributeGrid";
                padreAttributeGrid.DbType = DbType.Boolean;
                padreAttributeGrid.Value = (object)entity.AttributeGrid ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsBusiness_Rule_Creation>("sp_InsBusiness_Rule_Creation" 
, padreUser
, padreCreation_Date
, padreCreation_Hour
, padreLast_Updated_Date
, padreLast_Updated_Hour
, padreTime_that_took
, padreName
, padreDocumentation
, padreStatus
, padreComplexity
, padreObject
, padreAttribute
, padreAttributeGrid
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Key_Business_Rule_Creation);

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

        public int Update(Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation entity)
        {
            int rta;
            try
            {

                var paramUpdKey_Business_Rule_Creation = _dataProvider.GetParameter();
                paramUpdKey_Business_Rule_Creation.ParameterName = "Key_Business_Rule_Creation";
                paramUpdKey_Business_Rule_Creation.DbType = DbType.Int32;
                paramUpdKey_Business_Rule_Creation.Value = (object)entity.Key_Business_Rule_Creation ?? DBNull.Value;
                var paramUpdUser = _dataProvider.GetParameter();
                paramUpdUser.ParameterName = "User";
                paramUpdUser.DbType = DbType.Int32;
                paramUpdUser.Value = (object)entity.User ?? DBNull.Value;

                var paramUpdCreation_Date = _dataProvider.GetParameter();
                paramUpdCreation_Date.ParameterName = "Creation_Date";
                paramUpdCreation_Date.DbType = DbType.DateTime;
                paramUpdCreation_Date.Value = (object)entity.Creation_Date ?? DBNull.Value;

                var paramUpdCreation_Hour = _dataProvider.GetParameter();
                paramUpdCreation_Hour.ParameterName = "Creation_Hour";
                paramUpdCreation_Hour.DbType = DbType.String;
                paramUpdCreation_Hour.Value = (object)entity.Creation_Hour ?? DBNull.Value;
                var paramUpdLast_Updated_Date = _dataProvider.GetParameter();
                paramUpdLast_Updated_Date.ParameterName = "Last_Updated_Date";
                paramUpdLast_Updated_Date.DbType = DbType.DateTime;
                paramUpdLast_Updated_Date.Value = (object)entity.Last_Updated_Date ?? DBNull.Value;

                var paramUpdLast_Updated_Hour = _dataProvider.GetParameter();
                paramUpdLast_Updated_Hour.ParameterName = "Last_Updated_Hour";
                paramUpdLast_Updated_Hour.DbType = DbType.String;
                paramUpdLast_Updated_Hour.Value = (object)entity.Last_Updated_Hour ?? DBNull.Value;
                var paramUpdTime_that_took = _dataProvider.GetParameter();
                paramUpdTime_that_took.ParameterName = "Time_that_took";
                paramUpdTime_that_took.DbType = DbType.Int32;
                paramUpdTime_that_took.Value = (object)entity.Time_that_took ?? DBNull.Value;

                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)entity.Name ?? DBNull.Value;
                var paramUpdDocumentation = _dataProvider.GetParameter();
                paramUpdDocumentation.ParameterName = "Documentation";
                paramUpdDocumentation.DbType = DbType.Int32;
                paramUpdDocumentation.Value = (object)entity.Documentation ?? DBNull.Value;

                var paramUpdStatus = _dataProvider.GetParameter();
                paramUpdStatus.ParameterName = "Status";
                paramUpdStatus.DbType = DbType.Int16;
                paramUpdStatus.Value = (object)entity.Status ?? DBNull.Value;

                var paramUpdComplexity = _dataProvider.GetParameter();
                paramUpdComplexity.ParameterName = "Complexity";
                paramUpdComplexity.DbType = DbType.Int32;
                paramUpdComplexity.Value = (object)entity.Complexity ?? DBNull.Value;

                var padreAttribute = _dataProvider.GetParameter();
                padreAttribute.ParameterName = "Attribute";
                padreAttribute.DbType = DbType.Int32;
                padreAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                padreObject.Value = (object)entity.Object ?? DBNull.Value;

                var padreAttributeGrid = _dataProvider.GetParameter();
                padreAttributeGrid.ParameterName = "AttributeGrid";
                padreAttributeGrid.DbType = DbType.Boolean;
                padreAttributeGrid.Value = (object)entity.AttributeGrid ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdBusiness_Rule_Creation>("sp_UpdBusiness_Rule_Creation" , paramUpdKey_Business_Rule_Creation , paramUpdUser , paramUpdCreation_Date , paramUpdCreation_Hour , paramUpdLast_Updated_Date , paramUpdLast_Updated_Hour , paramUpdTime_that_took , paramUpdName , paramUpdDocumentation         , paramUpdStatus , paramUpdComplexity,
                    padreObject, padreAttribute, padreAttributeGrid).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Key_Business_Rule_Creation);
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

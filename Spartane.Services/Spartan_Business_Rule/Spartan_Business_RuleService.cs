using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Business_Rule;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Business_Rule
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Business_RuleService : ISpartan_Business_RuleService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> _Spartan_Business_RuleRepository;
        #endregion

        #region Ctor
        public Spartan_Business_RuleService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> Spartan_Business_RuleRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Business_RuleRepository = Spartan_Business_RuleRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Business_RuleRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule>("sp_SelAllSpartan_Business_Rule");
        }

        public IList<Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Business_Rule_Complete>("sp_SelAllComplete_Spartan_Business_Rule");
            return data.Select(m => new Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule
            {
                BusinessRuleId = m.BusinessRuleId
                ,Registration_Date = m.Registration_Date
                ,Registration_Hour = m.Registration_Hour
                ,User_who_registers = m.User_who_registers
                ,Description = m.Description
                ,Object = m.Object
                ,Attribute = m.Attribute
                ,Implementation_Code = m.Implementation_Code
                ,
                StatusId = m.StatusId
                ,
                AttributeGrid = m.AttributeGrid

            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Business_Rule>("sp_ListSelCount_Spartan_Business_Rule", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Business_Rule>("sp_ListSelAll_Spartan_Business_Rule", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule
                {
                    BusinessRuleId = m.Spartan_Business_Rule_BusinessRuleId,
                    Registration_Date = m.Spartan_Business_Rule_Registration_Date,
                    Registration_Hour = m.Spartan_Business_Rule_Registration_Hour,
                    User_who_registers = m.Spartan_Business_Rule_User_who_registers,
                    Description = m.Spartan_Business_Rule_Description,
                    Object = m.Spartan_Business_Rule_Object,
                    Attribute = m.Spartan_Business_Rule_Attribute,
                    Implementation_Code = m.Spartan_Business_Rule_Implementation_Code,
                    StatusId = m.Spartan_Business_Rule_StatusId,
                    AttributeGrid = m.Spartan_Business_Rule_AttributeGrid
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

        public IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Business_RuleRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Business_RuleRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_RulePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Business_Rule>("sp_ListSelAll_Spartan_Business_Rule", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Business_RulePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Business_RulePagingModel
                {
                    Spartan_Business_Rules =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule
                {
                    BusinessRuleId = m.Spartan_Business_Rule_BusinessRuleId
                    ,Registration_Date = m.Spartan_Business_Rule_Registration_Date
                    ,Registration_Hour = m.Spartan_Business_Rule_Registration_Hour
                    ,User_who_registers = m.Spartan_Business_Rule_User_who_registers
                    ,Description = m.Spartan_Business_Rule_Description
                    ,Object = m.Spartan_Business_Rule_Object
                    ,Attribute = m.Spartan_Business_Rule_Attribute
                    ,Implementation_Code = m.Spartan_Business_Rule_Implementation_Code
                    ,
                    StatusId = m.Spartan_Business_Rule_StatusId,
                    AttributeGrid = m.Spartan_Business_Rule_AttributeGrid
                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Business_RuleRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "BusinessRuleId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule>("sp_GetSpartan_Business_Rule", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "BusinessRuleId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Business_Rule>("sp_DelSpartan_Business_Rule", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule entity)
        {
            int rta;
            try
            {

		                var padreRegistration_Date = _dataProvider.GetParameter();
                padreRegistration_Date.ParameterName = "Registration_Date";
                padreRegistration_Date.DbType = DbType.DateTime;
                padreRegistration_Date.Value = (object)entity.Registration_Date ?? DBNull.Value;

                var padreRegistration_Hour = _dataProvider.GetParameter();
                padreRegistration_Hour.ParameterName = "Registration_Hour";
                padreRegistration_Hour.DbType = DbType.String;
                padreRegistration_Hour.Value = (object)entity.Registration_Hour ?? DBNull.Value;
                var padreUser_who_registers = _dataProvider.GetParameter();
                padreUser_who_registers.ParameterName = "User_who_registers";
                padreUser_who_registers.DbType = DbType.Int32;
                padreUser_who_registers.Value = (object)entity.User_who_registers ?? DBNull.Value;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                padreObject.Value = (object)entity.Object ?? DBNull.Value;

                var padreAttribute = _dataProvider.GetParameter();
                padreAttribute.ParameterName = "Attribute";
                padreAttribute.DbType = DbType.Int32;
                padreAttribute.Value = (object)entity.Attribute ?? DBNull.Value;

                var padreImplementation_Code = _dataProvider.GetParameter();
                padreImplementation_Code.ParameterName = "Implementation_Code";
                padreImplementation_Code.DbType = DbType.String;
                padreImplementation_Code.Value = (object)entity.Implementation_Code ?? DBNull.Value;

                var padreStatusId = _dataProvider.GetParameter();
                padreStatusId.ParameterName = "StatusId";
                padreStatusId.DbType = DbType.Int32;
                padreStatusId.Value = (object)entity.StatusId ?? DBNull.Value;

                var padreAttributeGrid = _dataProvider.GetParameter();
                padreAttributeGrid.ParameterName = "AttributeGrid";
                padreAttributeGrid.DbType = DbType.Boolean;
                padreAttributeGrid.Value = (object)entity.AttributeGrid ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Business_Rule>("sp_InsSpartan_Business_Rule" , padreRegistration_Date
, padreRegistration_Hour
, padreUser_who_registers
, padreDescription
, padreObject
, padreAttribute
, padreImplementation_Code
, padreStatusId
, padreAttributeGrid).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.BusinessRuleId);

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

        public int Update(Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule entity)
        {
            int rta;
            try
            {

                var paramUpdBusinessRuleId = _dataProvider.GetParameter();
                paramUpdBusinessRuleId.ParameterName = "BusinessRuleId";
                paramUpdBusinessRuleId.DbType = DbType.Int32;
                paramUpdBusinessRuleId.Value = entity.BusinessRuleId;
                var paramUpdRegistration_Date = _dataProvider.GetParameter();
                paramUpdRegistration_Date.ParameterName = "Registration_Date";
                paramUpdRegistration_Date.DbType = DbType.DateTime;
                if (entity.Registration_Date == null)
                    paramUpdRegistration_Date.Value = DBNull.Value;
                else
                    paramUpdRegistration_Date.Value = entity.Registration_Date;

                var paramUpdRegistration_Hour = _dataProvider.GetParameter();
                paramUpdRegistration_Hour.ParameterName = "Registration_Hour";
                paramUpdRegistration_Hour.DbType = DbType.String;
                paramUpdRegistration_Hour.Value = entity.Registration_Hour;
                var paramUpdUser_who_registers = _dataProvider.GetParameter();
                paramUpdUser_who_registers.ParameterName = "User_who_registers";
                paramUpdUser_who_registers.DbType = DbType.Int32;
                if (entity.User_who_registers == null)
                    paramUpdUser_who_registers.Value = DBNull.Value;
                else
                    paramUpdUser_who_registers.Value = entity.User_who_registers;

                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = entity.Description;
                var paramUpdObject = _dataProvider.GetParameter();
                paramUpdObject.ParameterName = "Object";
                paramUpdObject.DbType = DbType.Int32;
                if (entity.Object == null)
                    paramUpdObject.Value = DBNull.Value;
                else
                    paramUpdObject.Value = entity.Object;

                var paramUpdAttribute = _dataProvider.GetParameter();
                paramUpdAttribute.ParameterName = "Attribute";
                paramUpdAttribute.DbType = DbType.Int32;
                if (entity.Attribute == null)
                    paramUpdAttribute.Value = DBNull.Value;
                else
                    paramUpdAttribute.Value = entity.Attribute;

                var paramUpdImplementation_Code = _dataProvider.GetParameter();
                paramUpdImplementation_Code.ParameterName = "Implementation_Code";
                paramUpdImplementation_Code.DbType = DbType.String;
                paramUpdImplementation_Code.Value = entity.Implementation_Code;

                var paramUpdStatusId = _dataProvider.GetParameter();
                paramUpdStatusId.ParameterName = "StatusId";
                paramUpdStatusId.DbType = DbType.Int32;
                paramUpdStatusId.Value = (object)entity.StatusId ?? DBNull.Value;

                var paramUpdAttributeGrid = _dataProvider.GetParameter();
                paramUpdAttributeGrid.ParameterName = "AttributeGrid";
                paramUpdAttributeGrid.DbType = DbType.Boolean;
                paramUpdAttributeGrid.Value = (object)entity.AttributeGrid ?? DBNull.Value;

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Business_Rule>("sp_UpdSpartan_Business_Rule", paramUpdBusinessRuleId, paramUpdRegistration_Date, paramUpdRegistration_Hour, paramUpdUser_who_registers, paramUpdDescription, paramUpdObject, paramUpdAttribute, paramUpdImplementation_Code, paramUpdStatusId, paramUpdAttributeGrid).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.BusinessRuleId);
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


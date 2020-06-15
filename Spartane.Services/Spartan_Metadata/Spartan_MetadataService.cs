using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Metadata;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Metadata
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_MetadataService : ISpartan_MetadataService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> _Spartan_MetadataRepository;
        #endregion

        #region Ctor
        public Spartan_MetadataService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> Spartan_MetadataRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_MetadataRepository = Spartan_MetadataRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_MetadataRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata>("sp_SelAllSpartan_Metadata");
        }

        public IList<Core.Classes.Spartan_Metadata.Spartan_Metadata> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Metadata_Complete>("sp_SelAllComplete_Spartan_Metadata");
            return data.Select(m => new Core.Classes.Spartan_Metadata.Spartan_Metadata
            {
                AttributeId = m.AttributeId
                ,Class_Id = m.Class_Id
                ,Class_Name = m.Class_Name
                ,Object_Id = m.Object_Id
                ,Physical_Name = m.Physical_Name
                ,Logical_Name = m.Logical_Name
                ,Identifier_Type = m.Identifier_Type
                ,Attribute_Type = m.Attribute_Type
                ,Length = m.Length
                ,Decimals_Length = m.Decimals_Length
                ,Relation_Type = m.Relation_Type
                ,Related_Object_Id = m.Related_Object_Id
                ,Related_Class_Id = m.Related_Class_Id
                ,Related_Class_Name = m.Related_Class_Name
                ,Related_Class_Identifier = m.Related_Class_Identifier
                ,Related_Class_Description = m.Related_Class_Description
                ,Required = m.Required.GetValueOrDefault()
                ,DefaultValue = m.DefaultValue
                ,Visible = m.Visible.GetValueOrDefault()
                ,Help_Text = m.Help_Text
                ,Read_Only = m.Read_Only.GetValueOrDefault()
                ,ScreenOrder = m.ScreenOrder
                ,Control_Type = m.Control_Type
                ,Group_Name = m.Group_Name


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Metadata>("sp_ListSelCount_Spartan_Metadata", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Metadata>("sp_ListSelAll_Spartan_Metadata", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata
                {
                    AttributeId = m.Spartan_Metadata_AttributeId,
                    Class_Id = m.Spartan_Metadata_Class_Id,
                    Class_Name = m.Spartan_Metadata_Class_Name,
                    Object_Id = m.Spartan_Metadata_Object_Id,
                    Physical_Name = m.Spartan_Metadata_Physical_Name,
                    Logical_Name = m.Spartan_Metadata_Logical_Name,
                    Identifier_Type = m.Spartan_Metadata_Identifier_Type,
                    Attribute_Type = m.Spartan_Metadata_Attribute_Type,
                    Length = m.Spartan_Metadata_Length,
                    Decimals_Length = m.Spartan_Metadata_Decimals_Length,
                    Relation_Type = m.Spartan_Metadata_Relation_Type,
                    Related_Object_Id = m.Spartan_Metadata_Related_Object_Id,
                    Related_Class_Id = m.Spartan_Metadata_Related_Class_Id,
                    Related_Class_Name = m.Spartan_Metadata_Related_Class_Name,
                    Related_Class_Identifier = m.Spartan_Metadata_Related_Class_Identifier,
                    Related_Class_Description = m.Spartan_Metadata_Related_Class_Description,
                    Required = m.Spartan_Metadata_Required ?? false,
                    DefaultValue = m.Spartan_Metadata_DefaultValue,
                    Visible = m.Spartan_Metadata_Visible ?? false,
                    Help_Text = m.Spartan_Metadata_Help_Text,
                    Read_Only = m.Spartan_Metadata_Read_Only ?? false,
                    ScreenOrder = m.Spartan_Metadata_ScreenOrder,
                    Control_Type = m.Spartan_Metadata_Control_Type,
                    Group_Name = m.Spartan_Metadata_Group_Name,
                    Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object { Object_Id = Convert.ToInt32(m.Spartan_Metadata_Object_Id), Name = m.Spartan_Object_Name }
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

        public IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_MetadataRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_MetadataRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Metadata.Spartan_MetadataPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Metadata>("sp_ListSelAll_Spartan_Metadata", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_MetadataPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_MetadataPagingModel
                {
                    Spartan_Metadatas =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata
                {
                    AttributeId = m.Spartan_Metadata_AttributeId
                    ,Class_Id = m.Spartan_Metadata_Class_Id
                    ,Class_Name = m.Spartan_Metadata_Class_Name
                    ,Object_Id = m.Spartan_Metadata_Object_Id
                    ,Physical_Name = m.Spartan_Metadata_Physical_Name
                    ,Logical_Name = m.Spartan_Metadata_Logical_Name
                    ,Identifier_Type = m.Spartan_Metadata_Identifier_Type
                    ,Attribute_Type = m.Spartan_Metadata_Attribute_Type
                    ,Length = m.Spartan_Metadata_Length
                    ,Decimals_Length = m.Spartan_Metadata_Decimals_Length
                    ,Relation_Type = m.Spartan_Metadata_Relation_Type
                    ,Related_Object_Id = m.Spartan_Metadata_Related_Object_Id
                    ,Related_Class_Id = m.Spartan_Metadata_Related_Class_Id
                    ,Related_Class_Name = m.Spartan_Metadata_Related_Class_Name
                    ,Related_Class_Identifier = m.Spartan_Metadata_Related_Class_Identifier
                    ,Related_Class_Description = m.Spartan_Metadata_Related_Class_Description
                    ,Required = m.Spartan_Metadata_Required ?? false
                    ,DefaultValue = m.Spartan_Metadata_DefaultValue
                    ,Visible = m.Spartan_Metadata_Visible ?? false
                    ,Help_Text = m.Spartan_Metadata_Help_Text
                    ,Read_Only = m.Spartan_Metadata_Read_Only ?? false
                    ,ScreenOrder = m.Spartan_Metadata_ScreenOrder
                    ,Control_Type = m.Spartan_Metadata_Control_Type
                    ,Group_Name = m.Spartan_Metadata_Group_Name
                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_MetadataRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "AttributeId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata>("sp_GetSpartan_Metadata", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "AttributeId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Metadata>("sp_DelSpartan_Metadata", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata entity)
        {
            int rta;
            try
            {

		                var padreAttributeId = _dataProvider.GetParameter();
                padreAttributeId.ParameterName = "AttributeId";
                padreAttributeId.DbType = DbType.Int32;
                padreAttributeId.Value = entity.AttributeId;
                var padreClass_Id = _dataProvider.GetParameter();
                padreClass_Id.ParameterName = "Class_Id";
                padreClass_Id.DbType = DbType.Int32;
                padreClass_Id.Value = (object)entity.Class_Id ?? DBNull.Value;

                var padreClass_Name = _dataProvider.GetParameter();
                padreClass_Name.ParameterName = "Class_Name";
                padreClass_Name.DbType = DbType.String;
                padreClass_Name.Value = (object)entity.Class_Name ?? DBNull.Value;
                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                padreObject_Id.Value = (object)entity.Object_Id ?? DBNull.Value;

                var padrePhysical_Name = _dataProvider.GetParameter();
                padrePhysical_Name.ParameterName = "Physical_Name";
                padrePhysical_Name.DbType = DbType.String;
                padrePhysical_Name.Value = (object)entity.Physical_Name ?? DBNull.Value;
                var padreLogical_Name = _dataProvider.GetParameter();
                padreLogical_Name.ParameterName = "Logical_Name";
                padreLogical_Name.DbType = DbType.String;
                padreLogical_Name.Value = (object)entity.Logical_Name ?? DBNull.Value;
                var padreIdentifier_Type = _dataProvider.GetParameter();
                padreIdentifier_Type.ParameterName = "Identifier_Type";
                padreIdentifier_Type.DbType = DbType.Int16;
                padreIdentifier_Type.Value = (object)entity.Identifier_Type ?? DBNull.Value;

                var padreAttribute_Type = _dataProvider.GetParameter();
                padreAttribute_Type.ParameterName = "Attribute_Type";
                padreAttribute_Type.DbType = DbType.Int16;
                padreAttribute_Type.Value = (object)entity.Attribute_Type ?? DBNull.Value;

                var padreLength = _dataProvider.GetParameter();
                padreLength.ParameterName = "Length";
                padreLength.DbType = DbType.Int32;
                padreLength.Value = (object)entity.Length ?? DBNull.Value;

                var padreDecimals_Length = _dataProvider.GetParameter();
                padreDecimals_Length.ParameterName = "Decimals_Length";
                padreDecimals_Length.DbType = DbType.Int16;
                padreDecimals_Length.Value = (object)entity.Decimals_Length ?? DBNull.Value;

                var padreRelation_Type = _dataProvider.GetParameter();
                padreRelation_Type.ParameterName = "Relation_Type";
                padreRelation_Type.DbType = DbType.Int16;
                padreRelation_Type.Value = (object)entity.Relation_Type ?? DBNull.Value;

                var padreRelated_Object_Id = _dataProvider.GetParameter();
                padreRelated_Object_Id.ParameterName = "Related_Object_Id";
                padreRelated_Object_Id.DbType = DbType.Int32;
                padreRelated_Object_Id.Value = (object)entity.Related_Object_Id ?? DBNull.Value;

                var padreRelated_Class_Id = _dataProvider.GetParameter();
                padreRelated_Class_Id.ParameterName = "Related_Class_Id";
                padreRelated_Class_Id.DbType = DbType.Int32;
                padreRelated_Class_Id.Value = (object)entity.Related_Class_Id ?? DBNull.Value;

                var padreRelated_Class_Name = _dataProvider.GetParameter();
                padreRelated_Class_Name.ParameterName = "Related_Class_Name";
                padreRelated_Class_Name.DbType = DbType.String;
                padreRelated_Class_Name.Value = (object)entity.Related_Class_Name ?? DBNull.Value;
                var padreRelated_Class_Identifier = _dataProvider.GetParameter();
                padreRelated_Class_Identifier.ParameterName = "Related_Class_Identifier";
                padreRelated_Class_Identifier.DbType = DbType.Int32;
                padreRelated_Class_Identifier.Value = (object)entity.Related_Class_Identifier ?? DBNull.Value;

                var padreRelated_Class_Description = _dataProvider.GetParameter();
                padreRelated_Class_Description.ParameterName = "Related_Class_Description";
                padreRelated_Class_Description.DbType = DbType.String;
                padreRelated_Class_Description.Value = (object)entity.Related_Class_Description ?? DBNull.Value;
                var padreRequired = _dataProvider.GetParameter();
                padreRequired.ParameterName = "Required";
                padreRequired.DbType = DbType.Boolean;
                padreRequired.Value = (object)entity.Required ?? DBNull.Value;
                var padreDefaultValue = _dataProvider.GetParameter();
                padreDefaultValue.ParameterName = "DefaultValue";
                padreDefaultValue.DbType = DbType.String;
                padreDefaultValue.Value = (object)entity.DefaultValue ?? DBNull.Value;
                var padreVisible = _dataProvider.GetParameter();
                padreVisible.ParameterName = "Visible";
                padreVisible.DbType = DbType.Boolean;
                padreVisible.Value = (object)entity.Visible ?? DBNull.Value;
                var padreHelp_Text = _dataProvider.GetParameter();
                padreHelp_Text.ParameterName = "Help_Text";
                padreHelp_Text.DbType = DbType.String;
                padreHelp_Text.Value = (object)entity.Help_Text ?? DBNull.Value;
                var padreRead_Only = _dataProvider.GetParameter();
                padreRead_Only.ParameterName = "Read_Only";
                padreRead_Only.DbType = DbType.Boolean;
                padreRead_Only.Value = (object)entity.Read_Only ?? DBNull.Value;
                var padreScreenOrder = _dataProvider.GetParameter();
                padreScreenOrder.ParameterName = "ScreenOrder";
                padreScreenOrder.DbType = DbType.Int32;
                padreScreenOrder.Value = (object)entity.ScreenOrder ?? DBNull.Value;

                var padreControl_Type = _dataProvider.GetParameter();
                padreControl_Type.ParameterName = "Control_Type";
                padreControl_Type.DbType = DbType.Int32;
                padreControl_Type.Value = (object)entity.Control_Type ?? DBNull.Value;

                var padreGroup_Name = _dataProvider.GetParameter();
                padreGroup_Name.ParameterName = "Group_Name";
                padreGroup_Name.DbType = DbType.String;
                padreGroup_Name.Value = (object)entity.Group_Name ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Metadata>("sp_InsSpartan_Metadata" , padreAttributeId
, padreClass_Id
, padreClass_Name
, padreObject_Id
, padrePhysical_Name
, padreLogical_Name
, padreIdentifier_Type
, padreAttribute_Type
, padreLength
, padreDecimals_Length
, padreRelation_Type
, padreRelated_Object_Id
, padreRelated_Class_Id
, padreRelated_Class_Name
, padreRelated_Class_Identifier
, padreRelated_Class_Description
, padreRequired
, padreDefaultValue
, padreVisible
, padreHelp_Text
, padreRead_Only
, padreScreenOrder
, padreControl_Type
, padreGroup_Name
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.AttributeId);

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

        public int Update(Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata entity)
        {
            int rta;
            try
            {

                var paramUpdAttributeId = _dataProvider.GetParameter();
                paramUpdAttributeId.ParameterName = "AttributeId";
                paramUpdAttributeId.DbType = DbType.Int32;
                paramUpdAttributeId.Value = (object)entity.AttributeId ?? DBNull.Value;
                var paramUpdClass_Id = _dataProvider.GetParameter();
                paramUpdClass_Id.ParameterName = "Class_Id";
                paramUpdClass_Id.DbType = DbType.Int32;
                paramUpdClass_Id.Value = (object)entity.Class_Id ?? DBNull.Value;

                var paramUpdClass_Name = _dataProvider.GetParameter();
                paramUpdClass_Name.ParameterName = "Class_Name";
                paramUpdClass_Name.DbType = DbType.String;
                paramUpdClass_Name.Value = (object)entity.Class_Name ?? DBNull.Value;
                var paramUpdObject_Id = _dataProvider.GetParameter();
                paramUpdObject_Id.ParameterName = "Object_Id";
                paramUpdObject_Id.DbType = DbType.Int32;
                paramUpdObject_Id.Value = (object)entity.Object_Id ?? DBNull.Value;

                var paramUpdPhysical_Name = _dataProvider.GetParameter();
                paramUpdPhysical_Name.ParameterName = "Physical_Name";
                paramUpdPhysical_Name.DbType = DbType.String;
                paramUpdPhysical_Name.Value = (object)entity.Physical_Name ?? DBNull.Value;
                var paramUpdLogical_Name = _dataProvider.GetParameter();
                paramUpdLogical_Name.ParameterName = "Logical_Name";
                paramUpdLogical_Name.DbType = DbType.String;
                paramUpdLogical_Name.Value = (object)entity.Logical_Name ?? DBNull.Value;
                var paramUpdIdentifier_Type = _dataProvider.GetParameter();
                paramUpdIdentifier_Type.ParameterName = "Identifier_Type";
                paramUpdIdentifier_Type.DbType = DbType.Int16;
                paramUpdIdentifier_Type.Value = (object)entity.Identifier_Type ?? DBNull.Value;

                var paramUpdAttribute_Type = _dataProvider.GetParameter();
                paramUpdAttribute_Type.ParameterName = "Attribute_Type";
                paramUpdAttribute_Type.DbType = DbType.Int16;
                paramUpdAttribute_Type.Value = (object)entity.Attribute_Type ?? DBNull.Value;

                var paramUpdLength = _dataProvider.GetParameter();
                paramUpdLength.ParameterName = "Length";
                paramUpdLength.DbType = DbType.Int32;
                paramUpdLength.Value = (object)entity.Length ?? DBNull.Value;

                var paramUpdDecimals_Length = _dataProvider.GetParameter();
                paramUpdDecimals_Length.ParameterName = "Decimals_Length";
                paramUpdDecimals_Length.DbType = DbType.Int16;
                paramUpdDecimals_Length.Value = (object)entity.Decimals_Length ?? DBNull.Value;

                var paramUpdRelation_Type = _dataProvider.GetParameter();
                paramUpdRelation_Type.ParameterName = "Relation_Type";
                paramUpdRelation_Type.DbType = DbType.Int16;
                paramUpdRelation_Type.Value = (object)entity.Relation_Type ?? DBNull.Value;

                var paramUpdRelated_Object_Id = _dataProvider.GetParameter();
                paramUpdRelated_Object_Id.ParameterName = "Related_Object_Id";
                paramUpdRelated_Object_Id.DbType = DbType.Int32;
                paramUpdRelated_Object_Id.Value = (object)entity.Related_Object_Id ?? DBNull.Value;

                var paramUpdRelated_Class_Id = _dataProvider.GetParameter();
                paramUpdRelated_Class_Id.ParameterName = "Related_Class_Id";
                paramUpdRelated_Class_Id.DbType = DbType.Int32;
                paramUpdRelated_Class_Id.Value = (object)entity.Related_Class_Id ?? DBNull.Value;

                var paramUpdRelated_Class_Name = _dataProvider.GetParameter();
                paramUpdRelated_Class_Name.ParameterName = "Related_Class_Name";
                paramUpdRelated_Class_Name.DbType = DbType.String;
                paramUpdRelated_Class_Name.Value = (object)entity.Related_Class_Name ?? DBNull.Value;
                var paramUpdRelated_Class_Identifier = _dataProvider.GetParameter();
                paramUpdRelated_Class_Identifier.ParameterName = "Related_Class_Identifier";
                paramUpdRelated_Class_Identifier.DbType = DbType.Int32;
                paramUpdRelated_Class_Identifier.Value = (object)entity.Related_Class_Identifier ?? DBNull.Value;

                var paramUpdRelated_Class_Description = _dataProvider.GetParameter();
                paramUpdRelated_Class_Description.ParameterName = "Related_Class_Description";
                paramUpdRelated_Class_Description.DbType = DbType.String;
                paramUpdRelated_Class_Description.Value = (object)entity.Related_Class_Description ?? DBNull.Value;
                var paramUpdRequired = _dataProvider.GetParameter();
                paramUpdRequired.ParameterName = "Required";
                paramUpdRequired.DbType = DbType.Boolean;
                paramUpdRequired.Value = (object)entity.Required ?? DBNull.Value;
                var paramUpdDefaultValue = _dataProvider.GetParameter();
                paramUpdDefaultValue.ParameterName = "DefaultValue";
                paramUpdDefaultValue.DbType = DbType.String;
                paramUpdDefaultValue.Value = (object)entity.DefaultValue ?? DBNull.Value;
                var paramUpdVisible = _dataProvider.GetParameter();
                paramUpdVisible.ParameterName = "Visible";
                paramUpdVisible.DbType = DbType.Boolean;
                paramUpdVisible.Value = (object)entity.Visible ?? DBNull.Value;
                var paramUpdHelp_Text = _dataProvider.GetParameter();
                paramUpdHelp_Text.ParameterName = "Help_Text";
                paramUpdHelp_Text.DbType = DbType.String;
                paramUpdHelp_Text.Value = (object)entity.Help_Text ?? DBNull.Value;
                var paramUpdRead_Only = _dataProvider.GetParameter();
                paramUpdRead_Only.ParameterName = "Read_Only";
                paramUpdRead_Only.DbType = DbType.Boolean;
                paramUpdRead_Only.Value = (object)entity.Read_Only ?? DBNull.Value;
                var paramUpdScreenOrder = _dataProvider.GetParameter();
                paramUpdScreenOrder.ParameterName = "ScreenOrder";
                paramUpdScreenOrder.DbType = DbType.Int32;
                paramUpdScreenOrder.Value = (object)entity.ScreenOrder ?? DBNull.Value;

                var paramUpdControl_Type = _dataProvider.GetParameter();
                paramUpdControl_Type.ParameterName = "Control_Type";
                paramUpdControl_Type.DbType = DbType.Int32;
                paramUpdControl_Type.Value = (object)entity.Control_Type ?? DBNull.Value;

                var paramUpdGroup_Name = _dataProvider.GetParameter();
                paramUpdGroup_Name.ParameterName = "Group_Name";
                paramUpdGroup_Name.DbType = DbType.String;
                paramUpdGroup_Name.Value = (object)entity.Group_Name ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Metadata>("sp_UpdSpartan_Metadata" , paramUpdAttributeId , paramUpdClass_Id , paramUpdClass_Name , paramUpdObject_Id , paramUpdPhysical_Name , paramUpdLogical_Name , paramUpdIdentifier_Type , paramUpdAttribute_Type , paramUpdLength , paramUpdDecimals_Length , paramUpdRelation_Type , paramUpdRelated_Object_Id , paramUpdRelated_Class_Id , paramUpdRelated_Class_Name , paramUpdRelated_Class_Identifier , paramUpdRelated_Class_Description , paramUpdRequired , paramUpdDefaultValue , paramUpdVisible , paramUpdHelp_Text , paramUpdRead_Only , paramUpdScreenOrder , paramUpdControl_Type , paramUpdGroup_Name ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.AttributeId);
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

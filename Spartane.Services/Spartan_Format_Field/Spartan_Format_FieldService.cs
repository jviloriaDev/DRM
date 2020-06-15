using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Format_Field;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Format_Field
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Format_FieldService : ISpartan_Format_FieldService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> _Spartan_Format_FieldRepository;
        #endregion

        #region Ctor
        public Spartan_Format_FieldService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> Spartan_Format_FieldRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Format_FieldRepository = Spartan_Format_FieldRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Format_FieldRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field>("sp_SelAllSpartan_Format_Field");
        }

        public IList<Core.Classes.Spartan_Format_Field.Spartan_Format_Field> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Format_Field_Complete>("sp_SelAllComplete_Spartan_Format_Field");
            return data.Select(m => new Core.Classes.Spartan_Format_Field.Spartan_Format_Field
            {
                FormatFieldId = m.FormatFieldId
                ,Format_Spartan_Format = new Core.Classes.Spartan_Format.Spartan_Format() { FormatId = m.Format.GetValueOrDefault(), Format_Name = m.Format_Format_Name }
                ,Field_Path = m.Field_Path
                ,Physical_Field_Name = m.Physical_Field_Name
                ,Logical_Field_Name = m.Logical_Field_Name
                ,Creation_Date = m.Creation_Date
                ,Creation_Hour = m.Creation_Hour
                ,Creation_User = m.Creation_User
                ,Properties = m.Properties


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Format_Field>("sp_ListSelCount_Spartan_Format_Field", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format_Field>("sp_ListSelAll_Spartan_Format_Field", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field
                {
                    FormatFieldId = m.Spartan_Format_Field_FormatFieldId,
                    Format = m.Spartan_Format_Field_Format,
                    Field_Path = m.Spartan_Format_Field_Field_Path,
                    Physical_Field_Name = m.Spartan_Format_Field_Physical_Field_Name,
                    Logical_Field_Name = m.Spartan_Format_Field_Logical_Field_Name,
                    Creation_Date = m.Spartan_Format_Field_Creation_Date,
                    Creation_Hour = m.Spartan_Format_Field_Creation_Hour,
                    Creation_User = m.Spartan_Format_Field_Creation_User,
                    Properties = m.Spartan_Format_Field_Properties,
                    Type_Html = m.Spartan_Format_Field_Type_Html

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

        public IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Format_FieldRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Format_FieldRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_FieldPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format_Field>("sp_ListSelAll_Spartan_Format_Field", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Format_FieldPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Format_FieldPagingModel
                {
                    Spartan_Format_Fields =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field
                {
                    FormatFieldId = m.Spartan_Format_Field_FormatFieldId
                    ,Format = m.Spartan_Format_Field_Format
                    ,Format_Spartan_Format = new Core.Classes.Spartan_Format.Spartan_Format() { FormatId = m.Spartan_Format_Field_Format.GetValueOrDefault(), Format_Name = m.Spartan_Format_Field_Format_Format_Name }
                    ,Field_Path = m.Spartan_Format_Field_Field_Path
                    ,Physical_Field_Name = m.Spartan_Format_Field_Physical_Field_Name
                    ,Logical_Field_Name = m.Spartan_Format_Field_Logical_Field_Name
                    ,Creation_Date = m.Spartan_Format_Field_Creation_Date
                    ,Creation_Hour = m.Spartan_Format_Field_Creation_Hour
                    ,Creation_User = m.Spartan_Format_Field_Creation_User
                    ,Properties = m.Spartan_Format_Field_Properties

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Format_FieldRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "FormatFieldId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field>("sp_GetSpartan_Format_Field", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "FormatFieldId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Format_Field>("sp_DelSpartan_Format_Field", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field entity)
        {
            int rta;
            try
            {

		                var padreFormat = _dataProvider.GetParameter();
                padreFormat.ParameterName = "Format";
                padreFormat.DbType = DbType.Int32;
                padreFormat.Value = (object)entity.Format ?? DBNull.Value;

                var padreField_Path = _dataProvider.GetParameter();
                padreField_Path.ParameterName = "Field_Path";
                padreField_Path.DbType = DbType.String;
                padreField_Path.Value = (object)entity.Field_Path ?? DBNull.Value;
                var padrePhysical_Field_Name = _dataProvider.GetParameter();
                padrePhysical_Field_Name.ParameterName = "Physical_Field_Name";
                padrePhysical_Field_Name.DbType = DbType.String;
                padrePhysical_Field_Name.Value = (object)entity.Physical_Field_Name ?? DBNull.Value;
                var padreLogical_Field_Name = _dataProvider.GetParameter();
                padreLogical_Field_Name.ParameterName = "Logical_Field_Name";
                padreLogical_Field_Name.DbType = DbType.String;
                padreLogical_Field_Name.Value = (object)entity.Logical_Field_Name ?? DBNull.Value;
                var padreCreation_Date = _dataProvider.GetParameter();
                padreCreation_Date.ParameterName = "Creation_Date";
                padreCreation_Date.DbType = DbType.DateTime;
                padreCreation_Date.Value = (object)entity.Creation_Date ?? DBNull.Value;

                var padreCreation_Hour = _dataProvider.GetParameter();
                padreCreation_Hour.ParameterName = "Creation_Hour";
                padreCreation_Hour.DbType = DbType.String;
                padreCreation_Hour.Value = (object)entity.Creation_Hour ?? DBNull.Value;
                var padreCreation_User = _dataProvider.GetParameter();
                padreCreation_User.ParameterName = "Creation_User";
                padreCreation_User.DbType = DbType.Int32;
                padreCreation_User.Value = (object)entity.Creation_User ?? DBNull.Value;

                var padreProperties = _dataProvider.GetParameter();
                padreProperties.ParameterName = "Properties";
                padreProperties.DbType = DbType.String;
                padreProperties.Value = (object)entity.Properties ?? DBNull.Value;

                var padreTypeHtml = _dataProvider.GetParameter();
                padreTypeHtml.ParameterName = "Type_Html";
                padreTypeHtml.DbType = DbType.String;
                padreTypeHtml.Value = (object)entity.Type_Html ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Format_Field>("sp_InsSpartan_Format_Field" , padreFormat
, padreField_Path
, padrePhysical_Field_Name
, padreLogical_Field_Name
, padreCreation_Date
, padreCreation_Hour
, padreCreation_User
, padreProperties
, padreTypeHtml
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.FormatFieldId);

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

        public int Update(Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field entity)
        {
            int rta;
            try
            {

                var paramUpdFormatFieldId = _dataProvider.GetParameter();
                paramUpdFormatFieldId.ParameterName = "FormatFieldId";
                paramUpdFormatFieldId.DbType = DbType.Int32;
                paramUpdFormatFieldId.Value = (object)entity.FormatFieldId ?? DBNull.Value;
                var paramUpdFormat = _dataProvider.GetParameter();
                paramUpdFormat.ParameterName = "Format";
                paramUpdFormat.DbType = DbType.Int32;
                paramUpdFormat.Value = (object)entity.Format ?? DBNull.Value;

                var paramUpdField_Path = _dataProvider.GetParameter();
                paramUpdField_Path.ParameterName = "Field_Path";
                paramUpdField_Path.DbType = DbType.String;
                paramUpdField_Path.Value = (object)entity.Field_Path ?? DBNull.Value;
                var paramUpdPhysical_Field_Name = _dataProvider.GetParameter();
                paramUpdPhysical_Field_Name.ParameterName = "Physical_Field_Name";
                paramUpdPhysical_Field_Name.DbType = DbType.String;
                paramUpdPhysical_Field_Name.Value = (object)entity.Physical_Field_Name ?? DBNull.Value;
                var paramUpdLogical_Field_Name = _dataProvider.GetParameter();
                paramUpdLogical_Field_Name.ParameterName = "Logical_Field_Name";
                paramUpdLogical_Field_Name.DbType = DbType.String;
                paramUpdLogical_Field_Name.Value = (object)entity.Logical_Field_Name ?? DBNull.Value;
                var paramUpdCreation_Date = _dataProvider.GetParameter();
                paramUpdCreation_Date.ParameterName = "Creation_Date";
                paramUpdCreation_Date.DbType = DbType.DateTime;
                paramUpdCreation_Date.Value = (object)entity.Creation_Date ?? DBNull.Value;

                var paramUpdCreation_Hour = _dataProvider.GetParameter();
                paramUpdCreation_Hour.ParameterName = "Creation_Hour";
                paramUpdCreation_Hour.DbType = DbType.String;
                paramUpdCreation_Hour.Value = (object)entity.Creation_Hour ?? DBNull.Value;
                var paramUpdCreation_User = _dataProvider.GetParameter();
                paramUpdCreation_User.ParameterName = "Creation_User";
                paramUpdCreation_User.DbType = DbType.Int32;
                paramUpdCreation_User.Value = (object)entity.Creation_User ?? DBNull.Value;

                var paramUpdProperties = _dataProvider.GetParameter();
                paramUpdProperties.ParameterName = "Properties";
                paramUpdProperties.DbType = DbType.String;
                paramUpdProperties.Value = (object)entity.Properties ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Format_Field>("sp_UpdSpartan_Format_Field" , paramUpdFormatFieldId , paramUpdField_Path , paramUpdPhysical_Field_Name , paramUpdLogical_Field_Name , paramUpdCreation_Date , paramUpdCreation_Hour , paramUpdCreation_User , paramUpdProperties ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.FormatFieldId);
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

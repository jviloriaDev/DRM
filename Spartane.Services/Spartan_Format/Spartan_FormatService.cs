using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Format;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;
using Spartane.Services.Spartan_Format_Field;

namespace Spartane.Services.Spartan_Format
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_FormatService : ISpartan_FormatService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Format.Spartan_Format> _Spartan_FormatRepository;
        private ISpartan_Format_FieldService _ISpartan_Format_FieldService;
        #endregion

        #region Ctor
        public Spartan_FormatService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Format.Spartan_Format> Spartan_FormatRepository, ISpartan_Format_FieldService Spartan_Format_FieldService)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_FormatRepository = Spartan_FormatRepository;
            this._ISpartan_Format_FieldService = Spartan_Format_FieldService;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_FormatRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format.Spartan_Format>("sp_SelAllSpartan_Format");
        }

        public IList<Core.Classes.Spartan_Format.Spartan_Format> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Format_Complete>("sp_SelAllComplete_Spartan_Format");
            return data.Select(m => new Core.Classes.Spartan_Format.Spartan_Format
            {
                FormatId = m.FormatId
                ,Registration_Date = m.Registration_Date
                ,Registration_Hour = m.Registration_Hour
                ,Registration_User = m.Registration_User
                ,Format_Name = m.Format_Name
                ,Format_Type_Spartan_Format_Type = new Core.Classes.Spartan_Format_Type.Spartan_Format_Type() { FormatTypeId = m.Format_Type.GetValueOrDefault(), Description = m.Format_Type_Description }
                ,Search = m.Search
                ,Object = m.Object
                ,Header = m.Header
                ,Body = m.Body
                ,Footer = m.Footer
                ,Filter = m.Filter

            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Format>("sp_ListSelCount_Spartan_Format", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format>("sp_ListSelAll_Spartan_Format", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Format.Spartan_Format
                {
                    FormatId = m.Spartan_Format_FormatId,
                    Registration_Date = m.Spartan_Format_Registration_Date,
                    Registration_Hour = m.Spartan_Format_Registration_Hour,
                    Registration_User = m.Spartan_Format_Registration_User,
                    Format_Name = m.Spartan_Format_Format_Name,
                    Format_Type = m.Spartan_Format_Format_Type,
                    Search = m.Spartan_Format_Search,
                    Object = m.Spartan_Format_Object,
                    Header = m.Spartan_Format_Header,
                    Body = m.Spartan_Format_Body,
                    Footer = m.Spartan_Format_Footer,
                    Filter = m.Spartan_Format_Filter

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

        public IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_FormatRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_FormatRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format.Spartan_FormatPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format>("sp_ListSelAll_Spartan_Format", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_FormatPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_FormatPagingModel
                {
                    Spartan_Formats =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Format.Spartan_Format
                {
                    FormatId = m.Spartan_Format_FormatId
                    ,Registration_Date = m.Spartan_Format_Registration_Date
                    ,Registration_Hour = m.Spartan_Format_Registration_Hour
                    ,Registration_User = m.Spartan_Format_Registration_User
                    ,Format_Name = m.Spartan_Format_Format_Name
                    ,Format_Type = m.Spartan_Format_Format_Type
                    ,Format_Type_Spartan_Format_Type = new Core.Classes.Spartan_Format_Type.Spartan_Format_Type() { FormatTypeId = m.Spartan_Format_Format_Type.GetValueOrDefault(), Description = m.Spartan_Format_Format_Type_Description }
                    ,Search = m.Spartan_Format_Search
                    ,Object = m.Spartan_Format_Object
                    ,Spartan_Object_Spartan_Format_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Format_Object?? 0, Name = m.Spartan_Format_Object_Name }
                    ,User_Spartan_Format_User = new Core.Classes.Spartan_User.Spartan_User {  Id_User = Convert.ToInt32(m.Spartan_Format_Registration_User), Name = m.Spartan_Format_Registration_User_Name, Role = 0, Status =0}
                    ,Header = m.Spartan_Format_Header
                    ,Body = m.Spartan_Format_Body
                    ,Footer = m.Spartan_Format_Footer
                    ,Filter = m.Spartan_Format_Filter

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_FormatRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format.Spartan_Format GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "FormatId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format.Spartan_Format>("sp_GetSpartan_Format", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "FormatId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Format>("sp_DelSpartan_Format", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Format.Spartan_Format entity)
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
                var padreRegistration_User = _dataProvider.GetParameter();
                padreRegistration_User.ParameterName = "Registration_User";
                padreRegistration_User.DbType = DbType.Int32;
                padreRegistration_User.Value = (object)entity.Registration_User ?? DBNull.Value;

                var padreFormat_Name = _dataProvider.GetParameter();
                padreFormat_Name.ParameterName = "Format_Name";
                padreFormat_Name.DbType = DbType.String;
                padreFormat_Name.Value = (object)entity.Format_Name ?? DBNull.Value;
                var padreFormat_Type = _dataProvider.GetParameter();
                padreFormat_Type.ParameterName = "Format_Type";
                padreFormat_Type.DbType = DbType.Int16;
                padreFormat_Type.Value = (object)entity.Format_Type ?? DBNull.Value;

                var padreSearch = _dataProvider.GetParameter();
                padreSearch.ParameterName = "Search";
                padreSearch.DbType = DbType.String;
                padreSearch.Value = (object)entity.Search ?? DBNull.Value;
                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                padreObject.Value = (object)entity.Object ?? DBNull.Value;

                var padreHeader = _dataProvider.GetParameter();
                padreHeader.ParameterName = "Header";
                padreHeader.DbType = DbType.String;
                padreHeader.Value = (object)entity.Header ?? DBNull.Value;
                var padreBody = _dataProvider.GetParameter();
                padreBody.ParameterName = "Body";
                padreBody.DbType = DbType.String;
                padreBody.Value = (object)entity.Body ?? DBNull.Value;
                var padreFooter = _dataProvider.GetParameter();
                padreFooter.ParameterName = "Footer";
                padreFooter.DbType = DbType.String;
                padreFooter.Value = (object)entity.Footer ?? DBNull.Value;

                var padreFilter = _dataProvider.GetParameter();
                padreFilter.ParameterName = "Filter";
                padreFilter.DbType = DbType.String;
                padreFilter.Value = (object)entity.Filter ?? DBNull.Value;

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Format>("sp_InsSpartan_Format" , padreRegistration_Date
, padreRegistration_Hour
, padreRegistration_User
, padreFormat_Name
, padreFormat_Type
, padreSearch
, padreObject
, padreHeader
, padreBody
, padreFooter
, padreFilter
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.FormatId);

                foreach(var field in entity.Format_Field_Spartan_Format_Field)
                {
                    field.Format = rta;
                    _ISpartan_Format_FieldService.Insert(field);
                }

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

        public int Update(Spartane.Core.Classes.Spartan_Format.Spartan_Format entity)
        {
            int rta;
            try
            {
                var paramUpdFormatId = _dataProvider.GetParameter();
                paramUpdFormatId.ParameterName = "FormatId";
                paramUpdFormatId.DbType = DbType.Int32;
                paramUpdFormatId.Value = (object)entity.FormatId ?? DBNull.Value;
                var paramUpdRegistration_Date = _dataProvider.GetParameter();
                paramUpdRegistration_Date.ParameterName = "Registration_Date";
                paramUpdRegistration_Date.DbType = DbType.DateTime;
                paramUpdRegistration_Date.Value = (object)entity.Registration_Date ?? DBNull.Value;

                var paramUpdRegistration_Hour = _dataProvider.GetParameter();
                paramUpdRegistration_Hour.ParameterName = "Registration_Hour";
                paramUpdRegistration_Hour.DbType = DbType.String;
                paramUpdRegistration_Hour.Value = (object)entity.Registration_Hour ?? DBNull.Value;
                var paramUpdRegistration_User = _dataProvider.GetParameter();
                paramUpdRegistration_User.ParameterName = "Registration_User";
                paramUpdRegistration_User.DbType = DbType.Int32;
                paramUpdRegistration_User.Value = (object)entity.Registration_User ?? DBNull.Value;

                var paramUpdFormat_Name = _dataProvider.GetParameter();
                paramUpdFormat_Name.ParameterName = "Format_Name";
                paramUpdFormat_Name.DbType = DbType.String;
                paramUpdFormat_Name.Value = (object)entity.Format_Name ?? DBNull.Value;
                var paramUpdFormat_Type = _dataProvider.GetParameter();
                paramUpdFormat_Type.ParameterName = "Format_Type";
                paramUpdFormat_Type.DbType = DbType.Int16;
                paramUpdFormat_Type.Value = (object)entity.Format_Type ?? DBNull.Value;

                var paramUpdSearch = _dataProvider.GetParameter();
                paramUpdSearch.ParameterName = "Search";
                paramUpdSearch.DbType = DbType.String;
                paramUpdSearch.Value = (object)entity.Search ?? DBNull.Value;
                var paramUpdObject = _dataProvider.GetParameter();
                paramUpdObject.ParameterName = "Object";
                paramUpdObject.DbType = DbType.Int32;
                paramUpdObject.Value = (object)entity.Object ?? DBNull.Value;

                var paramUpdHeader = _dataProvider.GetParameter();
                paramUpdHeader.ParameterName = "Header";
                paramUpdHeader.DbType = DbType.String;
                paramUpdHeader.Value = (object)entity.Header ?? DBNull.Value;
                var paramUpdBody = _dataProvider.GetParameter();
                paramUpdBody.ParameterName = "Body";
                paramUpdBody.DbType = DbType.String;
                paramUpdBody.Value = (object)entity.Body ?? DBNull.Value;
                var paramUpdFooter = _dataProvider.GetParameter();
                paramUpdFooter.ParameterName = "Footer";
                paramUpdFooter.DbType = DbType.String;
                paramUpdFooter.Value = (object)entity.Footer ?? DBNull.Value;

                var paramUpdFilter = _dataProvider.GetParameter();
                paramUpdFilter.ParameterName = "Filter";
                paramUpdFilter.DbType = DbType.String;
                paramUpdFilter.Value = (object)entity.Filter ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Format>("sp_UpdSpartan_Format", paramUpdFormatId, paramUpdRegistration_Date, paramUpdRegistration_Hour, paramUpdRegistration_User, paramUpdFormat_Name, paramUpdFormat_Type, paramUpdSearch, paramUpdObject, paramUpdHeader, paramUpdBody, paramUpdFooter, paramUpdFilter).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.FormatId);

                var listFormatField= _ISpartan_Format_FieldService.SelAll(false, "Format=" + rta, string.Empty);

                //Borro todos los fields
                foreach (var field in listFormatField)
                {
                    _ISpartan_Format_FieldService.Delete(field.FormatFieldId);
                }
                //Los inserto nuevamente
                foreach (var field in entity.Format_Field_Spartan_Format_Field)
                {
                    field.Format = rta;
                    _ISpartan_Format_FieldService.Insert(field);
                }
               
                   
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

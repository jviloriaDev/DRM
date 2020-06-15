using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_System_Language;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_System_Language
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_System_LanguageService : ISpartan_System_LanguageService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> _Spartan_System_LanguageRepository;
        #endregion

        #region Ctor
        public Spartan_System_LanguageService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> Spartan_System_LanguageRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_System_LanguageRepository = Spartan_System_LanguageRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_System_LanguageRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language>("sp_SelAllSpartan_System_Language");
        }

        public IList<Core.Classes.Spartan_System_Language.Spartan_System_Language> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_System_Language_Complete>("sp_SelAllComplete_Spartan_System_Language");
            return data.Select(m => new Core.Classes.Spartan_System_Language.Spartan_System_Language
            {
                System_Language_Id = m.System_Language_Id
                ,Resource_File = m.Resource_File
                ,Language = m.Language
                ,Initial = m.Initial.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_System_Language>("sp_ListSelCount_Spartan_System_Language", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_System_Language>("sp_ListSelAll_Spartan_System_Language", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language
                {
                    System_Language_Id = m.Spartan_System_Language_System_Language_Id,
                    Resource_File = m.Spartan_System_Language_Resource_File,
                    Language = m.Spartan_System_Language_Language,
                    Initial = m.Spartan_System_Language_Initial ?? false,

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

        public IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_System_LanguageRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_System_LanguageRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_System_Language.Spartan_System_LanguagePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_System_Language>("sp_ListSelAll_Spartan_System_Language", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_System_LanguagePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_System_LanguagePagingModel
                {
                    Spartan_System_Languages =
                        data.Select(m => new Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language
                {
                    System_Language_Id = m.Spartan_System_Language_System_Language_Id
                    ,Resource_File = m.Spartan_System_Language_Resource_File
                    ,Language = m.Spartan_System_Language_Language
                    ,Initial = m.Spartan_System_Language_Initial ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_System_LanguageRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "System_Language_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language>("sp_GetSpartan_System_Language", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "System_Language_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_System_Language>("sp_DelSpartan_System_Language", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result == 1;
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

        public int Insert(Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language entity)
        {
            short rta;
            try
            {

		                var padreResource_File = _dataProvider.GetParameter();
                padreResource_File.ParameterName = "Resource_File";
                padreResource_File.DbType = DbType.String;
                padreResource_File.Value = entity.Resource_File;
                var padreLanguage = _dataProvider.GetParameter();
                padreLanguage.ParameterName = "Language";
                padreLanguage.DbType = DbType.String;
                padreLanguage.Value = entity.Language;
                var padreInitial = _dataProvider.GetParameter();
                padreInitial.ParameterName = "Initial";
                padreInitial.DbType = DbType.Boolean;
                padreInitial.Value = entity.Initial;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_System_Language>("sp_InsSpartan_System_Language" , padreResource_File 
, padreLanguage 
, padreInitial 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.System_Language_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language entity)
        {
            short rta;
            try
            {

                var padreSystem_Language_Id = _dataProvider.GetParameter();
                padreSystem_Language_Id.ParameterName = "System_Language_Id";
                padreSystem_Language_Id.DbType = DbType.Int16;
                padreSystem_Language_Id.Value = entity.System_Language_Id;
                var padreResource_File = _dataProvider.GetParameter();
                padreResource_File.ParameterName = "Resource_File";
                padreResource_File.DbType = DbType.String;
                padreResource_File.Value = entity.Resource_File;
                var padreLanguage = _dataProvider.GetParameter();
                padreLanguage.ParameterName = "Language";
                padreLanguage.DbType = DbType.String;
                padreLanguage.Value = entity.Language;
                var padreInitial = _dataProvider.GetParameter();
                padreInitial.ParameterName = "Initial";
                padreInitial.DbType = DbType.Boolean;
                padreInitial.Value = entity.Initial;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_System_Language>("sp_UpdSpartan_System_Language" , padreSystem_Language_Id  , padreResource_File  , padreLanguage  , padreInitial  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.System_Language_Id);
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


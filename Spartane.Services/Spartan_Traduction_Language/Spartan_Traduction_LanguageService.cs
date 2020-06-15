using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Traduction_Language;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Language
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_LanguageService : ISpartan_Traduction_LanguageService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> _Spartan_Traduction_LanguageRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_LanguageService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> Spartan_Traduction_LanguageRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_LanguageRepository = Spartan_Traduction_LanguageRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Traduction_LanguageRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language>("sp_SelAllSpartan_Traduction_Language");
        }

        public IList<Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Traduction_Language_Complete>("sp_SelAllComplete_Spartan_Traduction_Language");
            return data.Select(m => new Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language
            {
                IdLanguage = m.IdLanguage
                ,LanguageT = m.LanguageT


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Traduction_Language>("sp_ListSelCount_Spartan_Traduction_Language", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Language>("sp_ListSelAll_Spartan_Traduction_Language", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language
                {
                    IdLanguage = m.Spartan_Traduction_Language_IdLanguage,
                    LanguageT = m.Spartan_Traduction_Language_LanguageT,

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

        public IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_LanguagePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Language>("sp_ListSelAll_Spartan_Traduction_Language", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Traduction_LanguagePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Traduction_LanguagePagingModel
                {
                    Spartan_Traduction_Languages =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language
                {
                    IdLanguage = m.Spartan_Traduction_Language_IdLanguage
                    ,LanguageT = m.Spartan_Traduction_Language_LanguageT

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "IdLanguage";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language>("sp_GetSpartan_Traduction_Language", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "IdLanguage";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Traduction_Language>("sp_DelSpartan_Traduction_Language", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language entity)
        {
            int rta;
            try
            {

		                var padreLanguageT = _dataProvider.GetParameter();
                padreLanguageT.ParameterName = "LanguageT";
                padreLanguageT.DbType = DbType.String;
                padreLanguageT.Value = (object)entity.LanguageT ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Traduction_Language>("sp_InsSpartan_Traduction_Language" 
, padreLanguageT
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdLanguage);

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

        public int Update(Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language entity)
        {
            int rta;
            try
            {

                var paramUpdIdLanguage = _dataProvider.GetParameter();
                paramUpdIdLanguage.ParameterName = "IdLanguage";
                paramUpdIdLanguage.DbType = DbType.Int32;
                paramUpdIdLanguage.Value = (object)entity.IdLanguage ?? DBNull.Value;
                var paramUpdLanguageT = _dataProvider.GetParameter();
                paramUpdLanguageT.ParameterName = "LanguageT";
                paramUpdLanguageT.DbType = DbType.String;
                paramUpdLanguageT.Value = (object)entity.LanguageT ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Traduction_Language>("sp_UpdSpartan_Traduction_Language" , paramUpdIdLanguage , paramUpdLanguageT ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdLanguage);
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

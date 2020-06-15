using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Language_Text;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Language_Text
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Language_TextService : ISpartan_Language_TextService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> _Spartan_Language_TextRepository;
        #endregion

        #region Ctor
        public Spartan_Language_TextService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> Spartan_Language_TextRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Language_TextRepository = Spartan_Language_TextRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Language_TextRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text>("sp_SelAllSpartan_Language_Text");
        }

        public IList<Core.Classes.Spartan_Language_Text.Spartan_Language_Text> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Language_Text_Complete>("sp_SelAllComplete_Spartan_Language_Text");
            return data.Select(m => new Core.Classes.Spartan_Language_Text.Spartan_Language_Text
            {
                Language_Text_Id = m.Language_Text_Id
                ,System_Language_Id = m.System_Language_Id
                ,Text_Id = m.Text_Id
                ,Text = m.Text


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Language_Text>("sp_ListSelCount_Spartan_Language_Text", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Language_Text>("sp_ListSelAll_Spartan_Language_Text", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text
                {
                    System_Language_Id = m.Spartan_Language_Text_System_Language_Id,
                    Text_Id = m.Spartan_Language_Text_Text_Id,
                    Text = m.Spartan_Language_Text_Text,
                    Language_Text_Id = m.Spartan_Language_Text_Language_Text_Id,

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

        public IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Language_TextRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Language_TextRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_TextPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Language_Text>("sp_ListSelAll_Spartan_Language_Text", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Language_TextPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Language_TextPagingModel
                {
                    Spartan_Language_Texts =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text
                {
                    Language_Text_Id = m.Spartan_Language_Text_Language_Text_Id
                    ,System_Language_Id = m.Spartan_Language_Text_System_Language_Id
                    ,Text_Id = m.Spartan_Language_Text_Text_Id
                    ,Text = m.Spartan_Language_Text_Text

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Language_TextRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Language_Text_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text>("sp_GetSpartan_Language_Text", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Language_Text_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Language_Text>("sp_DelSpartan_Language_Text", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text entity)
        {
            int rta;
            try
            {

		                var padreSystem_Language_Id = _dataProvider.GetParameter();
                padreSystem_Language_Id.ParameterName = "System_Language_Id";
                padreSystem_Language_Id.DbType = DbType.Int16;
                if (entity.System_Language_Id == null)
                    padreSystem_Language_Id.Value = DBNull.Value;
                else
                    padreSystem_Language_Id.Value = entity.System_Language_Id;

                var padreText_Id = _dataProvider.GetParameter();
                padreText_Id.ParameterName = "Text_Id";
                padreText_Id.DbType = DbType.Int32;
                if (entity.Text_Id == null)
                    padreText_Id.Value = DBNull.Value;
                else
                    padreText_Id.Value = entity.Text_Id;

                var padreText = _dataProvider.GetParameter();
                padreText.ParameterName = "Text";
                padreText.DbType = DbType.String;
                padreText.Value = entity.Text;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Language_Text>("sp_InsSpartan_Language_Text" , padreSystem_Language_Id 
, padreText_Id 
, padreText 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Language_Text_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text entity)
        {
            int rta;
            try
            {

                var padreSystem_Language_Id = _dataProvider.GetParameter();
                padreSystem_Language_Id.ParameterName = "System_Language_Id";
                padreSystem_Language_Id.DbType = DbType.Int16;
                if (entity.System_Language_Id == null)
                    padreSystem_Language_Id.Value = DBNull.Value;
                else
                    padreSystem_Language_Id.Value = entity.System_Language_Id;

                var padreText_Id = _dataProvider.GetParameter();
                padreText_Id.ParameterName = "Text_Id";
                padreText_Id.DbType = DbType.Int32;
                if (entity.Text_Id == null)
                    padreText_Id.Value = DBNull.Value;
                else
                    padreText_Id.Value = entity.Text_Id;

                var padreText = _dataProvider.GetParameter();
                padreText.ParameterName = "Text";
                padreText.DbType = DbType.String;
                padreText.Value = entity.Text;
                var padreLanguage_Text_Id = _dataProvider.GetParameter();
                padreLanguage_Text_Id.ParameterName = "Language_Text_Id";
                padreLanguage_Text_Id.DbType = DbType.Int32;
                padreLanguage_Text_Id.Value = entity.Language_Text_Id;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Language_Text>("sp_UpdSpartan_Language_Text" , padreSystem_Language_Id  , padreText_Id  , padreText  , padreLanguage_Text_Id  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Language_Text_Id);
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


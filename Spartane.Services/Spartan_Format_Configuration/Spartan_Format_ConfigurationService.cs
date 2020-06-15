using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Format_Configuration;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Format_Configuration
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Format_ConfigurationService : ISpartan_Format_ConfigurationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> _Spartan_Format_ConfigurationRepository;
        #endregion

        #region Ctor
        public Spartan_Format_ConfigurationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> Spartan_Format_ConfigurationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Format_ConfigurationRepository = Spartan_Format_ConfigurationRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Format_ConfigurationRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration>("sp_SelAllSpartan_Format_Configuration");
        }

        public IList<Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Format_Configuration_Complete>("sp_SelAllComplete_Spartan_Format_Configuration");
            return data.Select(m => new Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration
            {
                Format = m.Format
                ,Query_To_Fill_Fields = m.Query_To_Fill_Fields
                ,Filter_to_Show = m.Filter_to_Show


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Format_Configuration>("sp_ListSelCount_Spartan_Format_Configuration", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format_Configuration>("sp_ListSelAll_Spartan_Format_Configuration", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration
                {
                    Format = m.Spartan_Format_Configuration_Format,
                    Query_To_Fill_Fields = m.Spartan_Format_Configuration_Query_To_Fill_Fields,
                    Filter_to_Show = m.Spartan_Format_Configuration_Filter_to_Show,

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

        public IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_ConfigurationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format_Configuration>("sp_ListSelAll_Spartan_Format_Configuration", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Format_ConfigurationPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Format_ConfigurationPagingModel
                {
                    Spartan_Format_Configurations =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration
                {
                    Format = m.Spartan_Format_Configuration_Format
                    ,Query_To_Fill_Fields = m.Spartan_Format_Configuration_Query_To_Fill_Fields
                    ,Filter_to_Show = m.Spartan_Format_Configuration_Filter_to_Show

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Format";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration>("sp_GetSpartan_Format_Configuration", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Format";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Format_Configuration>("sp_DelSpartan_Format_Configuration", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration entity)
        {
            int rta;
            try
            {

		                var padreFormat = _dataProvider.GetParameter();
                padreFormat.ParameterName = "Format";
                padreFormat.DbType = DbType.Int32;
                padreFormat.Value = entity.Format;
                var padreQuery_To_Fill_Fields = _dataProvider.GetParameter();
                padreQuery_To_Fill_Fields.ParameterName = "Query_To_Fill_Fields";
                padreQuery_To_Fill_Fields.DbType = DbType.String;
                padreQuery_To_Fill_Fields.Value = (object)entity.Query_To_Fill_Fields ?? DBNull.Value;
                var padreFilter_to_Show = _dataProvider.GetParameter();
                padreFilter_to_Show.ParameterName = "Filter_to_Show";
                padreFilter_to_Show.DbType = DbType.String;
                padreFilter_to_Show.Value = (object)entity.Filter_to_Show ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Format_Configuration>("sp_InsSpartan_Format_Configuration" , padreFormat
, padreQuery_To_Fill_Fields
, padreFilter_to_Show
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Format);

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

        public int Update(Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration entity)
        {
            int rta;
            try
            {

                var paramUpdFormat = _dataProvider.GetParameter();
                paramUpdFormat.ParameterName = "Format";
                paramUpdFormat.DbType = DbType.Int32;
                paramUpdFormat.Value = (object)entity.Format ?? DBNull.Value;
                var paramUpdQuery_To_Fill_Fields = _dataProvider.GetParameter();
                paramUpdQuery_To_Fill_Fields.ParameterName = "Query_To_Fill_Fields";
                paramUpdQuery_To_Fill_Fields.DbType = DbType.String;
                paramUpdQuery_To_Fill_Fields.Value = (object)entity.Query_To_Fill_Fields ?? DBNull.Value;
                var paramUpdFilter_to_Show = _dataProvider.GetParameter();
                paramUpdFilter_to_Show.ParameterName = "Filter_to_Show";
                paramUpdFilter_to_Show.DbType = DbType.String;
                paramUpdFilter_to_Show.Value = (object)entity.Filter_to_Show ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Format_Configuration>("sp_UpdSpartan_Format_Configuration" , paramUpdFormat , paramUpdQuery_To_Fill_Fields , paramUpdFilter_to_Show ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Format);
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

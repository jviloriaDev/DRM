using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Report_Format;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Format
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_FormatService : ISpartan_Report_FormatService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format> _Spartan_Report_FormatRepository;
        #endregion

        #region Ctor
        public Spartan_Report_FormatService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format> Spartan_Report_FormatRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_FormatRepository = Spartan_Report_FormatRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Report_FormatRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format>("sp_SelAllSpartan_Report_Format");
        }

        public IList<Core.Classes.Spartan_Report_Format.Spartan_Report_Format> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Report_Format_Complete>("sp_SelAllComplete_Spartan_Report_Format");
            return data.Select(m => new Core.Classes.Spartan_Report_Format.Spartan_Report_Format
            {
                FormatId = m.FormatId
                ,Description = m.Description
                ,Format_Mask = m.Format_Mask


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Report_Format>("sp_ListSelCount_Spartan_Report_Format", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Format>("sp_ListSelAll_Spartan_Report_Format", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format
                {
                    FormatId = m.Spartan_Report_Format_FormatId,
                    Description = m.Spartan_Report_Format_Description,
                    Format_Mask = m.Spartan_Report_Format_Format_Mask,

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

        public IList<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_FormatRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_FormatRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_FormatPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Format>("sp_ListSelAll_Spartan_Report_Format", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Report_FormatPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Report_FormatPagingModel
                {
                    Spartan_Report_Formats =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format
                {
                    FormatId = m.Spartan_Report_Format_FormatId
                    ,Description = m.Spartan_Report_Format_Description
                    ,Format_Mask = m.Spartan_Report_Format_Format_Mask

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_FormatRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "FormatId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format>("sp_GetSpartan_Report_Format", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Report_Format>("sp_DelSpartan_Report_Format", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
                var padreFormat_Mask = _dataProvider.GetParameter();
                padreFormat_Mask.ParameterName = "Format_Mask";
                padreFormat_Mask.DbType = DbType.String;
                padreFormat_Mask.Value = (object)entity.Format_Mask ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Report_Format>("sp_InsSpartan_Report_Format" 
, padreDescription
, padreFormat_Mask
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.FormatId);

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

        public int Update(Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format entity)
        {
            int rta;
            try
            {

                var paramUpdFormatId = _dataProvider.GetParameter();
                paramUpdFormatId.ParameterName = "FormatId";
                paramUpdFormatId.DbType = DbType.Int32;
                paramUpdFormatId.Value = (object)entity.FormatId ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;
                var paramUpdFormat_Mask = _dataProvider.GetParameter();
                paramUpdFormat_Mask.ParameterName = "Format_Mask";
                paramUpdFormat_Mask.DbType = DbType.String;
                paramUpdFormat_Mask.Value = (object)entity.Format_Mask ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Report_Format>("sp_UpdSpartan_Report_Format" , paramUpdFormatId , paramUpdDescription , paramUpdFormat_Mask ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.FormatId);
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

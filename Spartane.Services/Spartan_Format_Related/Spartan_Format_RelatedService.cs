using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Format_Related;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Format_Related
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Format_RelatedService : ISpartan_Format_RelatedService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> _Spartan_Format_RelatedRepository;
        #endregion

        #region Ctor
        public Spartan_Format_RelatedService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> Spartan_Format_RelatedRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Format_RelatedRepository = Spartan_Format_RelatedRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Format_RelatedRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related>("sp_SelAllSpartan_Format_Related");
        }

        public IList<Core.Classes.Spartan_Format_Related.Spartan_Format_Related> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Format_Related_Complete>("sp_SelAllComplete_Spartan_Format_Related");
            return data.Select(m => new Core.Classes.Spartan_Format_Related.Spartan_Format_Related
            {
                Clave = m.Clave
                ,FormatId_Spartan_Format = new Core.Classes.Spartan_Format.Spartan_Format() { FormatId = m.FormatId.GetValueOrDefault()}
                ,FormatId_Related_Spartan_Format = new Core.Classes.Spartan_Format.Spartan_Format() { FormatId = m.FormatId_Related.GetValueOrDefault()}
                ,Order = m.Order


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Format_Related>("sp_ListSelCount_Spartan_Format_Related", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format_Related>("sp_ListSelAll_Spartan_Format_Related", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related
                {
                    Clave = m.Spartan_Format_Related_Clave,
                    FormatId = m.Spartan_Format_Related_FormatId,
                    FormatId_Related = m.Spartan_Format_Related_FormatId_Related,
                    Order = m.Spartan_Format_Related_Order,

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

        public IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Format_RelatedRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Format_RelatedRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_RelatedPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format_Related>("sp_ListSelAll_Spartan_Format_Related", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Format_RelatedPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Format_RelatedPagingModel
                {
                    Spartan_Format_Relateds =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related
                {
                    Clave = m.Spartan_Format_Related_Clave
                    ,FormatId = m.Spartan_Format_Related_FormatId
                    ,FormatId_Spartan_Format = new Core.Classes.Spartan_Format.Spartan_Format() { FormatId = m.Spartan_Format_Related_FormatId.GetValueOrDefault()}
                    ,FormatId_Related = m.Spartan_Format_Related_FormatId_Related
                    ,FormatId_Related_Spartan_Format = new Core.Classes.Spartan_Format.Spartan_Format() { FormatId = m.Spartan_Format_Related_FormatId_Related.GetValueOrDefault()}
                    ,Order = m.Spartan_Format_Related_Order

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Format_RelatedRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related>("sp_GetSpartan_Format_Related", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Format_Related>("sp_DelSpartan_Format_Related", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related entity)
        {
            int rta;
            try
            {

		                var padreFormatId = _dataProvider.GetParameter();
                padreFormatId.ParameterName = "FormatId";
                padreFormatId.DbType = DbType.Int32;
                padreFormatId.Value = (object)entity.FormatId ?? DBNull.Value;

                var padreFormatId_Related = _dataProvider.GetParameter();
                padreFormatId_Related.ParameterName = "FormatId_Related";
                padreFormatId_Related.DbType = DbType.Int32;
                padreFormatId_Related.Value = (object)entity.FormatId_Related ?? DBNull.Value;

                var padreOrder = _dataProvider.GetParameter();
                padreOrder.ParameterName = "Order";
                padreOrder.DbType = DbType.Int16;
                padreOrder.Value = (object)entity.Order ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Format_Related>("sp_InsSpartan_Format_Related" 
, padreFormatId
, padreFormatId_Related
, padreOrder
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

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

        public int Update(Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdFormatId = _dataProvider.GetParameter();
                paramUpdFormatId.ParameterName = "FormatId";
                paramUpdFormatId.DbType = DbType.Int32;
                paramUpdFormatId.Value = (object)entity.FormatId ?? DBNull.Value;

                var paramUpdFormatId_Related = _dataProvider.GetParameter();
                paramUpdFormatId_Related.ParameterName = "FormatId_Related";
                paramUpdFormatId_Related.DbType = DbType.Int32;
                paramUpdFormatId_Related.Value = (object)entity.FormatId_Related ?? DBNull.Value;

                var paramUpdOrder = _dataProvider.GetParameter();
                paramUpdOrder.ParameterName = "Order";
                paramUpdOrder.DbType = DbType.Int16;
                paramUpdOrder.Value = (object)entity.Order ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Format_Related>("sp_UpdSpartan_Format_Related" , paramUpdClave , paramUpdFormatId , paramUpdFormatId_Related , paramUpdOrder ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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

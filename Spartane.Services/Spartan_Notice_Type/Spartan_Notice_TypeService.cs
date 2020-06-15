using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Notice_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Notice_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Notice_TypeService : ISpartan_Notice_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type> _Spartan_Notice_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Notice_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type> Spartan_Notice_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Notice_TypeRepository = Spartan_Notice_TypeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Notice_TypeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type>("sp_SelAllSpartan_Notice_Type");
        }

        public IList<Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Notice_Type_Complete>("sp_SelAllComplete_Spartan_Notice_Type");
            return data.Select(m => new Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type
            {
                Notice_Type_Id = m.Notice_Type_Id
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Notice_Type>("sp_ListSelCount_Spartan_Notice_Type", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Notice_Type>("sp_ListSelAll_Spartan_Notice_Type", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type
                {
                    Notice_Type_Id = m.Spartan_Notice_Type_Notice_Type_Id,
                    Description = m.Spartan_Notice_Type_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Notice_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Notice_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Notice_Type>("sp_ListSelAll_Spartan_Notice_Type", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Notice_TypePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Notice_TypePagingModel
                {
                    Spartan_Notice_Types =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type
                {
                    Notice_Type_Id = m.Spartan_Notice_Type_Notice_Type_Id
                    ,Description = m.Spartan_Notice_Type_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Notice_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Notice_Type_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type>("sp_GetSpartan_Notice_Type", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Notice_Type_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Notice_Type>("sp_DelSpartan_Notice_Type", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Notice_Type>("sp_InsSpartan_Notice_Type" , padreDescription 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Notice_Type_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type entity)
        {
            int rta;
            try
            {

                var padreNotice_Type_Id = _dataProvider.GetParameter();
                padreNotice_Type_Id.ParameterName = "Notice_Type_Id";
                padreNotice_Type_Id.DbType = DbType.Int32;
                padreNotice_Type_Id.Value = entity.Notice_Type_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Notice_Type>("sp_UpdSpartan_Notice_Type" , padreNotice_Type_Id  , padreDescription  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Notice_Type_Id);
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


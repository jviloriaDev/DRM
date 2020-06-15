using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Function_Type_Status;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Function_Type_Status
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Function_Type_StatusService : ISpartan_Function_Type_StatusService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> _Spartan_Function_Type_StatusRepository;
        #endregion

        #region Ctor
        public Spartan_Function_Type_StatusService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> Spartan_Function_Type_StatusRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Function_Type_StatusRepository = Spartan_Function_Type_StatusRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Function_Type_StatusRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status>("sp_SelAllSpartan_Function_Type_Status");
        }

        public IList<Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Function_Type_Status_Complete>("sp_SelAllComplete_Spartan_Function_Type_Status");
            return data.Select(m => new Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status
            {
                Function_Type_Status_Id = m.Function_Type_Status_Id
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Function_Type_Status>("sp_ListSelCount_Spartan_Function_Type_Status", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function_Type_Status>("sp_ListSelAll_Spartan_Function_Type_Status", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status
                {
                    Function_Type_Status_Id = m.Spartan_Function_Type_Status_Function_Type_Status_Id,
                    Description = m.Spartan_Function_Type_Status_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Function_Type_StatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Function_Type_StatusRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function_Type_Status>("sp_ListSelAll_Spartan_Function_Type_Status", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Function_Type_StatusPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Function_Type_StatusPagingModel
                {
                    Spartan_Function_Type_Statuss =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status
                {
                    Function_Type_Status_Id = m.Spartan_Function_Type_Status_Function_Type_Status_Id
                    ,Description = m.Spartan_Function_Type_Status_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Function_Type_StatusRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Function_Type_Status_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status>("sp_GetSpartan_Function_Type_Status", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Function_Type_Status_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Function_Type_Status>("sp_DelSpartan_Function_Type_Status", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Function_Type_Status>("sp_InsSpartan_Function_Type_Status" , padreDescription 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Type_Status_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status entity)
        {
            short rta;
            try
            {

                var padreFunction_Type_Status_Id = _dataProvider.GetParameter();
                padreFunction_Type_Status_Id.ParameterName = "Function_Type_Status_Id";
                padreFunction_Type_Status_Id.DbType = DbType.Int16;
                padreFunction_Type_Status_Id.Value = entity.Function_Type_Status_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Function_Type_Status>("sp_UpdSpartan_Function_Type_Status" , padreFunction_Type_Status_Id  , padreDescription  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Type_Status_Id);
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


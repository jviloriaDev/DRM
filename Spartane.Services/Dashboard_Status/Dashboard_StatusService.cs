using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Dashboard_Status;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Dashboard_Status
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Dashboard_StatusService : IDashboard_StatusService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> _Dashboard_StatusRepository;
        #endregion

        #region Ctor
        public Dashboard_StatusService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> Dashboard_StatusRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Dashboard_StatusRepository = Dashboard_StatusRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Dashboard_StatusRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status>("sp_SelAllDashboard_Status");
        }

        public IList<Core.Classes.Dashboard_Status.Dashboard_Status> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDashboard_Status_Complete>("sp_SelAllComplete_Dashboard_Status");
            return data.Select(m => new Core.Classes.Dashboard_Status.Dashboard_Status
            {
                Status_Id = m.Status_Id
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Dashboard_Status>("sp_ListSelCount_Dashboard_Status", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDashboard_Status>("sp_ListSelAll_Dashboard_Status", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Dashboard_Status.Dashboard_Status
                {
                    Status_Id = m.Dashboard_Status_Status_Id,
                    Description = m.Dashboard_Status_Description,

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

        public IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Dashboard_StatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dashboard_StatusRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Dashboard_Status.Dashboard_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDashboard_Status>("sp_ListSelAll_Dashboard_Status", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Dashboard_StatusPagingModel result = null;

            if (data != null)
            {
                result = new Dashboard_StatusPagingModel
                {
                    Dashboard_Statuss =
                        data.Select(m => new Spartane.Core.Classes.Dashboard_Status.Dashboard_Status
                {
                    Status_Id = m.Dashboard_Status_Status_Id
                    ,Description = m.Dashboard_Status_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Dashboard_StatusRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Dashboard_Status.Dashboard_Status GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Status_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status>("sp_GetDashboard_Status", padreKey).SingleOrDefault();
        }

        public bool Delete(short Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Status_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDashboard_Status>("sp_DelDashboard_Status", padreKey).FirstOrDefault();
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

        public short Insert(Spartane.Core.Classes.Dashboard_Status.Dashboard_Status entity)
        {
            short rta;
            try
            {

		var padreStatus_Id = _dataProvider.GetParameter();
                padreStatus_Id.ParameterName = "Status_Id";
                padreStatus_Id.DbType = DbType.Int16;
                padreStatus_Id.Value = (object)entity.Status_Id ?? DBNull.Value;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDashboard_Status>("sp_InsDashboard_Status" , padreDescription
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Status_Id);

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

        public short Update(Spartane.Core.Classes.Dashboard_Status.Dashboard_Status entity)
        {
            short rta;
            try
            {

                var paramUpdStatus_Id = _dataProvider.GetParameter();
                paramUpdStatus_Id.ParameterName = "Status_Id";
                paramUpdStatus_Id.DbType = DbType.Int16;
                paramUpdStatus_Id.Value = (object)entity.Status_Id ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDashboard_Status>("sp_UpdDashboard_Status" , paramUpdStatus_Id , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Status_Id);
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
		public short Update_Datos_Generales(Spartane.Core.Classes.Dashboard_Status.Dashboard_Status entity)
        {
            short rta;
            try
            {
                Spartane.Core.Classes.Dashboard_Status.Dashboard_Status Dashboard_StatusDB = GetByKey(entity.Status_Id, false);
                var paramUpdStatus_Id = _dataProvider.GetParameter();
                paramUpdStatus_Id.ParameterName = "Status_Id";
                paramUpdStatus_Id.DbType = DbType.Int16;
                paramUpdStatus_Id.Value = (object)entity.Status_Id ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDashboard_Status>("sp_UpdDashboard_Status" , paramUpdStatus_Id , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Status_Id);
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


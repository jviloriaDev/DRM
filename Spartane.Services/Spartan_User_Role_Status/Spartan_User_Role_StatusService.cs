using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User_Role_Status;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Role_Status
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_Role_StatusService : ISpartan_User_Role_StatusService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> _Spartan_User_Role_StatusRepository;
        #endregion

        #region Ctor
        public Spartan_User_Role_StatusService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> Spartan_User_Role_StatusRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_Role_StatusRepository = Spartan_User_Role_StatusRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_User_Role_StatusRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status>("sp_SelAllSpartan_User_Role_Status");
        }

        public IList<Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Role_Status_Complete>("sp_SelAllComplete_Spartan_User_Role_Status");
            return data.Select(m => new Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status
            {
                User_Role_Status_Id = m.User_Role_Status_Id
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User_Role_Status>("sp_ListSelCount_Spartan_User_Role_Status", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Role_Status>("sp_ListSelAll_Spartan_User_Role_Status", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status
                {
                    User_Role_Status_Id = m.Spartan_User_Role_Status_User_Role_Status_Id,
                    Description = m.Spartan_User_Role_Status_Description,

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

        public IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_Role_StatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Role_StatusRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Role_Status>("sp_ListSelAll_Spartan_User_Role_Status", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_User_Role_StatusPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_User_Role_StatusPagingModel
                {
                    Spartan_User_Role_Statuss =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status
                {
                    User_Role_Status_Id = m.Spartan_User_Role_Status_User_Role_Status_Id
                    ,Description = m.Spartan_User_Role_Status_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_Role_StatusRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "User_Role_Status_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status>("sp_GetSpartan_User_Role_Status", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "User_Role_Status_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User_Role_Status>("sp_DelSpartan_User_Role_Status", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User_Role_Status>("sp_InsSpartan_User_Role_Status" 
, padreDescription
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Role_Status_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status entity)
        {
            int rta;
            try
            {

                var paramUpdUser_Role_Status_Id = _dataProvider.GetParameter();
                paramUpdUser_Role_Status_Id.ParameterName = "User_Role_Status_Id";
                paramUpdUser_Role_Status_Id.DbType = DbType.Int32;
                paramUpdUser_Role_Status_Id.Value = (object)entity.User_Role_Status_Id ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User_Role_Status>("sp_UpdSpartan_User_Role_Status" , paramUpdUser_Role_Status_Id , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Role_Status_Id);
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

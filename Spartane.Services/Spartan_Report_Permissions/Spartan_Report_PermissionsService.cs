using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Report_Permissions;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Permissions
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_PermissionsService : ISpartan_Report_PermissionsService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> _Spartan_Report_PermissionsRepository;
        #endregion

        #region Ctor
        public Spartan_Report_PermissionsService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> Spartan_Report_PermissionsRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_PermissionsRepository = Spartan_Report_PermissionsRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Report_PermissionsRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions>("sp_SelAllSpartan_Report_Permissions");
        }

        public IList<Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Report_Permissions_Complete>("sp_SelAllComplete_Spartan_Report_Permissions");
            return data.Select(m => new Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions
            {
                ReportPermissionId = m.ReportPermissionId
                ,User_Role = m.User_Role
                ,Report_Spartan_Report = new Core.Classes.Spartan_Report.Spartan_Report() { ReportId = m.Report.GetValueOrDefault(), Report_Name = m.Report_Report_Name }
                ,Permission_Type_Spartan_Report_Permission_Type = new Core.Classes.Spartan_Report_Permission_Type.Spartan_Report_Permission_Type() { PermissionTypeId = m.Permission_Type.GetValueOrDefault(), Description = m.Permission_Type_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Report_Permissions>("sp_ListSelCount_Spartan_Report_Permissions", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Permissions>("sp_ListSelAll_Spartan_Report_Permissions", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions
                {
                    ReportPermissionId = m.Spartan_Report_Permissions_ReportPermissionId,
                    User_Role = m.Spartan_Report_Permissions_User_Role,
                    Report = m.Spartan_Report_Permissions_Report,
                    Permission_Type = m.Spartan_Report_Permissions_Permission_Type,

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

        public IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_PermissionsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_PermissionsRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_PermissionsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Permissions>("sp_ListSelAll_Spartan_Report_Permissions", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Report_PermissionsPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Report_PermissionsPagingModel
                {
                    Spartan_Report_Permissionss =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions
                {
                    ReportPermissionId = m.Spartan_Report_Permissions_ReportPermissionId
                    ,User_Role = m.Spartan_Report_Permissions_User_Role
                    ,Report = m.Spartan_Report_Permissions_Report
                    ,Report_Spartan_Report = new Core.Classes.Spartan_Report.Spartan_Report() { ReportId = m.Spartan_Report_Permissions_Report.GetValueOrDefault(), Report_Name = m.Spartan_Report_Permissions_Report_Report_Name }
                    ,Permission_Type = m.Spartan_Report_Permissions_Permission_Type
                    ,Permission_Type_Spartan_Report_Permission_Type = new Core.Classes.Spartan_Report_Permission_Type.Spartan_Report_Permission_Type() { PermissionTypeId = m.Spartan_Report_Permissions_Permission_Type.GetValueOrDefault(), Description = m.Spartan_Report_Permissions_Permission_Type_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_PermissionsRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ReportPermissionId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions>("sp_GetSpartan_Report_Permissions", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ReportPermissionId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Report_Permissions>("sp_DelSpartan_Report_Permissions", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions entity)
        {
            int rta;
            try
            {

		                var padreUser_Role = _dataProvider.GetParameter();
                padreUser_Role.ParameterName = "User_Role";
                padreUser_Role.DbType = DbType.Int32;
                padreUser_Role.Value = (object)entity.User_Role ?? DBNull.Value;

                var padreReport = _dataProvider.GetParameter();
                padreReport.ParameterName = "Report";
                padreReport.DbType = DbType.Int32;
                padreReport.Value = (object)entity.Report ?? DBNull.Value;

                var padrePermission_Type = _dataProvider.GetParameter();
                padrePermission_Type.ParameterName = "Permission_Type";
                padrePermission_Type.DbType = DbType.Int16;
                padrePermission_Type.Value = (object)entity.Permission_Type ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Report_Permissions>("sp_InsSpartan_Report_Permissions" , padreUser_Role
, padreReport
, padrePermission_Type
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ReportPermissionId);

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

        public int Update(Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions entity)
        {
            int rta;
            try
            {

                var paramUpdReportPermissionId = _dataProvider.GetParameter();
                paramUpdReportPermissionId.ParameterName = "ReportPermissionId";
                paramUpdReportPermissionId.DbType = DbType.Int32;
                paramUpdReportPermissionId.Value = (object)entity.ReportPermissionId ?? DBNull.Value;
                var paramUpdUser_Role = _dataProvider.GetParameter();
                paramUpdUser_Role.ParameterName = "User_Role";
                paramUpdUser_Role.DbType = DbType.Int32;
                paramUpdUser_Role.Value = (object)entity.User_Role ?? DBNull.Value;

                var paramUpdReport = _dataProvider.GetParameter();
                paramUpdReport.ParameterName = "Report";
                paramUpdReport.DbType = DbType.Int32;
                paramUpdReport.Value = (object)entity.Report ?? DBNull.Value;

                var paramUpdPermission_Type = _dataProvider.GetParameter();
                paramUpdPermission_Type.ParameterName = "Permission_Type";
                paramUpdPermission_Type.DbType = DbType.Int16;
                paramUpdPermission_Type.Value = (object)entity.Permission_Type ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Report_Permissions>("sp_UpdSpartan_Report_Permissions" , paramUpdReportPermissionId , paramUpdUser_Role , paramUpdPermission_Type ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.ReportPermissionId);
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

using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Format_Permissions;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Format_Permissions
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Format_PermissionsService : ISpartan_Format_PermissionsService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions> _Spartan_Format_PermissionsRepository;
        #endregion

        #region Ctor
        public Spartan_Format_PermissionsService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions> Spartan_Format_PermissionsRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Format_PermissionsRepository = Spartan_Format_PermissionsRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Format_PermissionsRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions>("sp_SelAllSpartan_Format_Permissions");
        }

        public IList<Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Format_Permissions_Complete>("sp_SelAllComplete_Spartan_Format_Permissions");
            return data.Select(m => new Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions
            {
                PermissionId = m.PermissionId
                ,Format_Spartan_Format = new Core.Classes.Spartan_Format.Spartan_Format() { FormatId = m.Format.GetValueOrDefault(), Format_Name = m.Format_Format_Name }
                ,Permission_Type_Spartan_Format_Permission_Type = new Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type() { PermissionTypeId = m.Permission_Type.GetValueOrDefault(), Description = m.Permission_Type_Description }
                ,Apply = m.Apply.GetValueOrDefault()
                ,Spartan_User_Role = m.Spartan_User_Role


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Format_Permissions>("sp_ListSelCount_Spartan_Format_Permissions", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format_Permissions>("sp_ListSelAll_Spartan_Format_Permissions", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions
                {
                    PermissionId = m.Spartan_Format_Permissions_PermissionId,
                    Format = m.Spartan_Format_Permissions_Format,
                    Permission_Type = m.Spartan_Format_Permissions_Permission_Type,
                    Apply = m.Spartan_Format_Permissions_Apply ?? false,
                    Spartan_User_Role = m.Spartan_Format_Permissions_Spartan_User_Role,

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

        public IList<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Format_PermissionsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Format_PermissionsRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_PermissionsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Format_Permissions>("sp_ListSelAll_Spartan_Format_Permissions", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Format_PermissionsPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Format_PermissionsPagingModel
                {
                    Spartan_Format_Permissionss =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions
                {
                    PermissionId = m.Spartan_Format_Permissions_PermissionId
                    ,Format = m.Spartan_Format_Permissions_Format
                    ,Format_Spartan_Format = new Core.Classes.Spartan_Format.Spartan_Format() { FormatId = m.Spartan_Format_Permissions_Format.GetValueOrDefault(), Format_Name = m.Spartan_Format_Permissions_Format_Format_Name }
                    ,Permission_Type = m.Spartan_Format_Permissions_Permission_Type
                    ,Permission_Type_Spartan_Format_Permission_Type = new Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type() { PermissionTypeId = m.Spartan_Format_Permissions_Permission_Type.GetValueOrDefault(), Description = m.Spartan_Format_Permissions_Permission_Type_Description }
                    ,Apply = m.Spartan_Format_Permissions_Apply ?? false
                    ,Spartan_User_Role = m.Spartan_Format_Permissions_Spartan_User_Role

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Format_PermissionsRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "PermissionId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions>("sp_GetSpartan_Format_Permissions", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "PermissionId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Format_Permissions>("sp_DelSpartan_Format_Permissions", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions entity)
        {
            int rta;
            try
            {

		                var padreFormat = _dataProvider.GetParameter();
                padreFormat.ParameterName = "Format";
                padreFormat.DbType = DbType.Int32;
                padreFormat.Value = (object)entity.Format ?? DBNull.Value;

                var padrePermission_Type = _dataProvider.GetParameter();
                padrePermission_Type.ParameterName = "Permission_Type";
                padrePermission_Type.DbType = DbType.Int16;
                padrePermission_Type.Value = (object)entity.Permission_Type ?? DBNull.Value;

                var padreApply = _dataProvider.GetParameter();
                padreApply.ParameterName = "Apply";
                padreApply.DbType = DbType.Boolean;
                padreApply.Value = (object)entity.Apply ?? DBNull.Value;
                var padreSpartan_User_Role = _dataProvider.GetParameter();
                padreSpartan_User_Role.ParameterName = "Spartan_User_Role";
                padreSpartan_User_Role.DbType = DbType.Int32;
                padreSpartan_User_Role.Value = (object)entity.Spartan_User_Role ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Format_Permissions>("sp_InsSpartan_Format_Permissions" , padreFormat
, padrePermission_Type
, padreApply
, padreSpartan_User_Role
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.PermissionId);

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

        public int Update(Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions entity)
        {
            int rta;
            try
            {

                var paramUpdPermissionId = _dataProvider.GetParameter();
                paramUpdPermissionId.ParameterName = "PermissionId";
                paramUpdPermissionId.DbType = DbType.Int32;
                paramUpdPermissionId.Value = (object)entity.PermissionId ?? DBNull.Value;
                var paramUpdFormat = _dataProvider.GetParameter();
                paramUpdFormat.ParameterName = "Format";
                paramUpdFormat.DbType = DbType.Int32;
                paramUpdFormat.Value = (object)entity.Format ?? DBNull.Value;

                var paramUpdPermission_Type = _dataProvider.GetParameter();
                paramUpdPermission_Type.ParameterName = "Permission_Type";
                paramUpdPermission_Type.DbType = DbType.Int16;
                paramUpdPermission_Type.Value = (object)entity.Permission_Type ?? DBNull.Value;

                var paramUpdApply = _dataProvider.GetParameter();
                paramUpdApply.ParameterName = "Apply";
                paramUpdApply.DbType = DbType.Boolean;
                paramUpdApply.Value = (object)entity.Apply ?? DBNull.Value;
                var paramUpdSpartan_User_Role = _dataProvider.GetParameter();
                paramUpdSpartan_User_Role.ParameterName = "Spartan_User_Role";
                paramUpdSpartan_User_Role.DbType = DbType.Int32;
                paramUpdSpartan_User_Role.Value = (object)entity.Spartan_User_Role ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Format_Permissions>("sp_UpdSpartan_Format_Permissions" , paramUpdPermissionId , paramUpdFormat , paramUpdPermission_Type , paramUpdApply , paramUpdSpartan_User_Role ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.PermissionId);
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

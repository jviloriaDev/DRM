using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User_Rule_Module;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Rule_Module
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_Rule_ModuleService : ISpartan_User_Rule_ModuleService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module> _Spartan_User_Rule_ModuleRepository;
        #endregion

        #region Ctor
        public Spartan_User_Rule_ModuleService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module> Spartan_User_Rule_ModuleRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_Rule_ModuleRepository = Spartan_User_Rule_ModuleRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_User_Rule_ModuleRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module>("sp_SelAllSpartan_User_Rule_Module");
        }

        public IList<Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Rule_Module_Complete>("sp_SelAllComplete_Spartan_User_Rule_Module");
            return data.Select(m => new Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module
            {
                User_Rule_Module_Id = m.User_Rule_Module_Id
                ,Module_Id_Spartan_Module = new Core.Classes.Spartan_Module.Spartan_Module() { Module_Id = m.Module_Id.GetValueOrDefault(), Name = m.Module_Id_Name }
                ,Order_Shown = m.Order_Shown
                ,Spartan_User_Role = m.Spartan_User_Role


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User_Rule_Module>("sp_ListSelCount_Spartan_User_Rule_Module", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Rule_Module>("sp_ListSelAll_Spartan_User_Rule_Module", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module
                {
                    User_Rule_Module_Id = m.Spartan_User_Rule_Module_User_Rule_Module_Id,
                    Module_Id = m.Spartan_User_Rule_Module_Module_Id,
                    Order_Shown = m.Spartan_User_Rule_Module_Order_Shown,
                    Spartan_User_Role = m.Spartan_User_Rule_Module_Spartan_User_Role,

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

        public IList<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_Rule_ModuleRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Rule_ModuleRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_ModulePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Rule_Module>("sp_ListSelAll_Spartan_User_Rule_Module", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_User_Rule_ModulePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_User_Rule_ModulePagingModel
                {
                    Spartan_User_Rule_Modules =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module
                {
                    User_Rule_Module_Id = m.Spartan_User_Rule_Module_User_Rule_Module_Id
                    ,Module_Id = m.Spartan_User_Rule_Module_Module_Id
                    ,Module_Id_Spartan_Module = new Core.Classes.Spartan_Module.Spartan_Module() { Module_Id = m.Spartan_User_Rule_Module_Module_Id.GetValueOrDefault(), Name = m.Spartan_User_Rule_Module_Module_Id_Name }
                    ,Order_Shown = m.Spartan_User_Rule_Module_Order_Shown
                    ,Spartan_User_Role = m.Spartan_User_Rule_Module_Spartan_User_Role

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_Rule_ModuleRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "User_Rule_Module_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module>("sp_GetSpartan_User_Rule_Module", padreKey).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="SpartaneUserRole">
        /// Added as required by Stored Procedure
        /// </param>
        /// <returns></returns>
        public bool Delete(short? Key, int SpartaneUserRole)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "User_Rule_Module_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                //Added parameter Spartan_User_Role
                var spartanUserRole = _dataProvider.GetParameter();
                spartanUserRole.ParameterName = "Spartan_User_Role";
                spartanUserRole.DbType = DbType.Int16;
                spartanUserRole.Value = SpartaneUserRole;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User_Rule_Module>("sp_DelSpartan_User_Rule_Module", padreKey, spartanUserRole).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module entity)
        {
            short rta;
            try
            {

		                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                if (entity.Module_Id == null)
                    padreModule_Id.Value = DBNull.Value;
                else
                    padreModule_Id.Value = entity.Module_Id;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

                var padreSpartan_User_Role = _dataProvider.GetParameter();
                padreSpartan_User_Role.ParameterName = "Spartan_User_Role";
                padreSpartan_User_Role.DbType = DbType.Int32;
                padreSpartan_User_Role.Value = entity.Spartan_User_Role;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User_Rule_Module>("sp_InsSpartan_User_Rule_Module" , padreModule_Id 
, padreOrder_Shown 
, padreSpartan_User_Role 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.User_Rule_Module_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module entity)
        {
            short rta;
            try
            {

                var padreUser_Rule_Module_Id = _dataProvider.GetParameter();
                padreUser_Rule_Module_Id.ParameterName = "User_Rule_Module_Id";
                padreUser_Rule_Module_Id.DbType = DbType.Int16;
                padreUser_Rule_Module_Id.Value = entity.User_Rule_Module_Id;
                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                if (entity.Module_Id == null)
                    padreModule_Id.Value = DBNull.Value;
                else
                    padreModule_Id.Value = entity.Module_Id;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

                var padreSpartan_User_Role = _dataProvider.GetParameter();
                padreSpartan_User_Role.ParameterName = "Spartan_User_Role";
                padreSpartan_User_Role.DbType = DbType.Int32;
                padreSpartan_User_Role.Value = entity.Spartan_User_Role;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User_Rule_Module>("sp_UpdSpartan_User_Rule_Module" , padreUser_Rule_Module_Id  , padreModule_Id  , padreOrder_Shown  , padreSpartan_User_Role  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.User_Rule_Module_Id);
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


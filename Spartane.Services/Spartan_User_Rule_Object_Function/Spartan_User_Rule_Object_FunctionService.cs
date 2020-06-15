using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User_Rule_Object_Function;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Rule_Object_Function
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_Rule_Object_FunctionService : ISpartan_User_Rule_Object_FunctionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> _Spartan_User_Rule_Object_FunctionRepository;
        #endregion

        #region Ctor
        public Spartan_User_Rule_Object_FunctionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> Spartan_User_Rule_Object_FunctionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_Rule_Object_FunctionRepository = Spartan_User_Rule_Object_FunctionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_User_Rule_Object_FunctionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function>("sp_SelAllSpartan_User_Rule_Object_Function");
        }

        public IList<Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Rule_Object_Function_Complete>("sp_SelAllComplete_Spartan_User_Rule_Object_Function");
            return data.Select(m => new Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function
            {
                User_Rule_Object_Function_Id = m.User_Rule_Object_Function_Id
                ,Module_Id_Spartan_Module = new Core.Classes.Spartan_Module.Spartan_Module() { Module_Id = m.Module_Id.GetValueOrDefault(), Name = m.Module_Id_Name }
                ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object_Id.GetValueOrDefault(), Name = m.Object_Id_Name }
                ,Fuction_Id_Spartan_Function = new Core.Classes.Spartan_Function.Spartan_Function() { Function_Id = m.Fuction_Id.GetValueOrDefault(), Description = m.Fuction_Id_Description }
                ,Spartan_User_Rule = m.Spartan_User_Rule


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User_Rule_Object_Function>("sp_ListSelCount_Spartan_User_Rule_Object_Function", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Rule_Object_Function>("sp_ListSelAll_Spartan_User_Rule_Object_Function", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function
                {
                    User_Rule_Object_Function_Id = m.Spartan_User_Rule_Object_Function_User_Rule_Object_Function_Id,
                    Module_Id = m.Spartan_User_Rule_Object_Function_Module_Id,
                    Object_Id = m.Spartan_User_Rule_Object_Function_Object_Id,
                    Fuction_Id = m.Spartan_User_Rule_Object_Function_Fuction_Id,
                    Spartan_User_Rule = m.Spartan_User_Rule_Object_Function_Spartan_User_Rule,

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

        public IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_Rule_Object_FunctionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Rule_Object_FunctionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_FunctionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Rule_Object_Function>("sp_ListSelAll_Spartan_User_Rule_Object_Function", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_User_Rule_Object_FunctionPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_User_Rule_Object_FunctionPagingModel
                {
                    Spartan_User_Rule_Object_Functions =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function
                {
                    User_Rule_Object_Function_Id = m.Spartan_User_Rule_Object_Function_User_Rule_Object_Function_Id
                    ,Module_Id = m.Spartan_User_Rule_Object_Function_Module_Id
                    ,Module_Id_Spartan_Module = new Core.Classes.Spartan_Module.Spartan_Module() { Module_Id = m.Spartan_User_Rule_Object_Function_Module_Id.GetValueOrDefault(), Name = m.Spartan_User_Rule_Object_Function_Module_Id_Name }
                    ,Object_Id = m.Spartan_User_Rule_Object_Function_Object_Id
                    ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_User_Rule_Object_Function_Object_Id.GetValueOrDefault(), Name = m.Spartan_User_Rule_Object_Function_Object_Id_Name }
                    ,Fuction_Id = m.Spartan_User_Rule_Object_Function_Fuction_Id
                    ,Fuction_Id_Spartan_Function = new Core.Classes.Spartan_Function.Spartan_Function() { Function_Id = m.Spartan_User_Rule_Object_Function_Fuction_Id.GetValueOrDefault(), Description = m.Spartan_User_Rule_Object_Function_Fuction_Id_Description }
                    ,Spartan_User_Rule = m.Spartan_User_Rule_Object_Function_Spartan_User_Rule

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_Rule_Object_FunctionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "User_Rule_Object_Function_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function>("sp_GetSpartan_User_Rule_Object_Function", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key,int spartanUserRule)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "User_Rule_Object_Function_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;


                // Added Parameter @Spartan_User_Rule
                var keyUserRule = _dataProvider.GetParameter();
                keyUserRule.ParameterName = "Spartan_User_Rule";
                keyUserRule.DbType = DbType.Int32;
                keyUserRule.Value = spartanUserRule;


                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User_Rule_Object_Function>("sp_DelSpartan_User_Rule_Object_Function", padreKey,keyUserRule).FirstOrDefault();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <remarks>
        /// Date(06/02/2016)
        /// Added missing parameter MethodID.
        /// </remarks>
        /// <returns></returns>
        public int Insert(Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function entity)
        {
            int rta;
            try
            {

		        var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                if (entity.Module_Id == null)
                    padreModule_Id.Value = DBNull.Value;
                else
                    padreModule_Id.Value = entity.Module_Id;

                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreFuction_Id = _dataProvider.GetParameter();
                padreFuction_Id.ParameterName = "Fuction_Id";
                padreFuction_Id.DbType = DbType.Int16;
                if (entity.Fuction_Id == null)
                    padreFuction_Id.Value = DBNull.Value;
                else
                    padreFuction_Id.Value = entity.Fuction_Id;


                //Added code  for Method ID
                var padreMethod_Id = _dataProvider.GetParameter();
                padreMethod_Id.ParameterName = "Method_Id";
                padreMethod_Id.DbType = DbType.Int16;
                padreMethod_Id.Value = DBNull.Value;


                var padreSpartan_User_Rule = _dataProvider.GetParameter();
                padreSpartan_User_Rule.ParameterName = "Spartan_User_Rule";
                padreSpartan_User_Rule.DbType = DbType.Int32;
                padreSpartan_User_Rule.Value = entity.Spartan_User_Rule;
 

                var empEntity =
                  _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User_Rule_Object_Function>("sp_InsSpartan_User_Rule_Object_Function" , padreModule_Id , padreObject_Id , padreMethod_Id, padreFuction_Id , padreSpartan_User_Rule).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Rule_Object_Function_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function entity)
        {
            int rta;
            try
            {

                var padreUser_Rule_Object_Function_Id = _dataProvider.GetParameter();
                padreUser_Rule_Object_Function_Id.ParameterName = "User_Rule_Object_Function_Id";
                padreUser_Rule_Object_Function_Id.DbType = DbType.Int32;
                padreUser_Rule_Object_Function_Id.Value = entity.User_Rule_Object_Function_Id;
                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                if (entity.Module_Id == null)
                    padreModule_Id.Value = DBNull.Value;
                else
                    padreModule_Id.Value = entity.Module_Id;

                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreFuction_Id = _dataProvider.GetParameter();
                padreFuction_Id.ParameterName = "Fuction_Id";
                padreFuction_Id.DbType = DbType.Int16;
                if (entity.Fuction_Id == null)
                    padreFuction_Id.Value = DBNull.Value;
                else
                    padreFuction_Id.Value = entity.Fuction_Id;

                var padreSpartan_User_Rule = _dataProvider.GetParameter();
                padreSpartan_User_Rule.ParameterName = "Spartan_User_Rule";
                padreSpartan_User_Rule.DbType = DbType.Int32;
                padreSpartan_User_Rule.Value = entity.Spartan_User_Rule;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User_Rule_Object_Function>("sp_UpdSpartan_User_Rule_Object_Function" , padreUser_Rule_Object_Function_Id  , padreModule_Id  , padreObject_Id  , padreFuction_Id  , padreSpartan_User_Rule  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Rule_Object_Function_Id);
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


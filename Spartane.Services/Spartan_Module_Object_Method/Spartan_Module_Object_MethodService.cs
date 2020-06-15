using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Module_Object_Method;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Module_Object_Method
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Module_Object_MethodService : ISpartan_Module_Object_MethodService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> _Spartan_Module_Object_MethodRepository;
        #endregion

        #region Ctor
        public Spartan_Module_Object_MethodService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> Spartan_Module_Object_MethodRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Module_Object_MethodRepository = Spartan_Module_Object_MethodRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Module_Object_MethodRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method>("sp_SelAllSpartan_Module_Object_Method");
        }

        public IList<Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Module_Object_Method_Complete>("sp_SelAllComplete_Spartan_Module_Object_Method");
            return data.Select(m => new Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method
            {
                Module_Object_Method_Id = m.Module_Object_Method_Id
                ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object_Id.GetValueOrDefault(), Name = m.Object_Id_Name }
                ,Order_Shown = m.Order_Shown
                ,Spartan_Module = m.Spartan_Module


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Module_Object_Method>("sp_ListSelCount_Spartan_Module_Object_Method", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module_Object_Method>("sp_ListSelAll_Spartan_Module_Object_Method", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method
                {
                    Module_Object_Method_Id = m.Spartan_Module_Object_Method_Module_Object_Method_Id,
                    Object_Id = m.Spartan_Module_Object_Method_Object_Id,
                    Order_Shown = m.Spartan_Module_Object_Method_Order_Shown,
                    Spartan_Module = m.Spartan_Module_Object_Method_Spartan_Module,

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

        public IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Module_Object_MethodRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Module_Object_MethodRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_MethodPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module_Object_Method>("sp_ListSelAll_Spartan_Module_Object_Method", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Module_Object_MethodPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Module_Object_MethodPagingModel
                {
                    Spartan_Module_Object_Methods =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method
                {
                    Module_Object_Method_Id = m.Spartan_Module_Object_Method_Module_Object_Method_Id
                    ,Object_Id = m.Spartan_Module_Object_Method_Object_Id
                    ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Module_Object_Method_Object_Id.GetValueOrDefault(), Name = m.Spartan_Module_Object_Method_Object_Id_Name }
                    ,Order_Shown = m.Spartan_Module_Object_Method_Order_Shown
                    ,Spartan_Module = m.Spartan_Module_Object_Method_Spartan_Module

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Module_Object_MethodRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Module_Object_Method_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method>("sp_GetSpartan_Module_Object_Method", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Module_Object_Method_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Module_Object_Method>("sp_DelSpartan_Module_Object_Method", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method entity)
        {
            short rta;
            try
            {

		                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

                var padreSpartan_Module = _dataProvider.GetParameter();
                padreSpartan_Module.ParameterName = "Spartan_Module";
                padreSpartan_Module.DbType = DbType.Int16;
                padreSpartan_Module.Value = entity.Spartan_Module;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Module_Object_Method>("sp_InsSpartan_Module_Object_Method" , padreObject_Id 
, padreOrder_Shown 
, padreSpartan_Module 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Module_Object_Method_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method entity)
        {
            short rta;
            try
            {

                var padreModule_Object_Method_Id = _dataProvider.GetParameter();
                padreModule_Object_Method_Id.ParameterName = "Module_Object_Method_Id";
                padreModule_Object_Method_Id.DbType = DbType.Int16;
                padreModule_Object_Method_Id.Value = entity.Module_Object_Method_Id;
                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

                var padreSpartan_Module = _dataProvider.GetParameter();
                padreSpartan_Module.ParameterName = "Spartan_Module";
                padreSpartan_Module.DbType = DbType.Int16;
                padreSpartan_Module.Value = entity.Spartan_Module;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Module_Object_Method>("sp_UpdSpartan_Module_Object_Method" , padreModule_Object_Method_Id  , padreObject_Id  , padreOrder_Shown  , padreSpartan_Module  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Module_Object_Method_Id);
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


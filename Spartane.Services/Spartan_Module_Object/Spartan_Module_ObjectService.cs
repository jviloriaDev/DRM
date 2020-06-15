using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Module_Object;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Module_Object
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Module_ObjectService : ISpartan_Module_ObjectService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object> _Spartan_Module_ObjectRepository;
        #endregion

        #region Ctor
        public Spartan_Module_ObjectService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object> Spartan_Module_ObjectRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Module_ObjectRepository = Spartan_Module_ObjectRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Module_ObjectRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object>("sp_SelAllSpartan_Module_Object");
        }

        public IList<Core.Classes.Spartan_Module_Object.Spartan_Module_Object> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Module_Object_Complete>("sp_SelAllComplete_Spartan_Module_Object");
            return data.Select(m => new Core.Classes.Spartan_Module_Object.Spartan_Module_Object
            {
                Module_Object_Id = m.Module_Object_Id
                ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object_Id.GetValueOrDefault(), Name = m.Object_Id_Name }
                ,Module_Id = m.Module_Id
                ,Name = m.Name
                ,Physical_Name = m.Physical_Name
                ,URL = m.URL
                ,Order_Shown = m.Order_Shown


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Module_Object>("sp_ListSelCount_Spartan_Module_Object", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module_Object>("sp_ListSelAll_Spartan_Module_Object", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object
                {
                    Module_Object_Id = m.Spartan_Module_Object_Module_Object_Id,
                    Object_Id = m.Spartan_Module_Object_Object_Id,
                    Module_Id = m.Spartan_Module_Object_Module_Id,
                    Name = m.Spartan_Module_Object_Name,
                    Physical_Name = m.Spartan_Module_Object_Physical_Name,
                    URL = m.Spartan_Module_Object_URL,
                    Order_Shown = m.Spartan_Module_Object_Order_Shown,

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

        public IList<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Module_ObjectRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Module_ObjectRepository.Table.Where(Where).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <remarks>
        /// Date: (06/03/2016)
        /// Added Object_Type value in Object_Id_Spartan_Object collection
        /// retrieved from stored procedure sp_ListSelAll_Spartan_Module_Object
        /// </remarks>
        /// <returns></returns>
        public Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module_Object>("sp_ListSelAll_Spartan_Module_Object", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Module_ObjectPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Module_ObjectPagingModel
                {
                    Spartan_Module_Objects =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object
                {
                    Module_Object_Id = m.Spartan_Module_Object_Module_Object_Id
                    ,Object_Id = m.Spartan_Module_Object_Object_Id
                    ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Module_Object_Object_Id.GetValueOrDefault(), Name = m.Spartan_Module_Object_Object_Id_Name , Object_Type = m.Spartan_Object_Object_Type}
                    ,Module_Id = m.Spartan_Module_Object_Module_Id
                    ,Name = m.Spartan_Module_Object_Name
                    ,Physical_Name = m.Spartan_Module_Object_Physical_Name
                    ,URL = m.Spartan_Module_Object_URL
                    ,Order_Shown = m.Spartan_Module_Object_Order_Shown
                    
                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Module_ObjectRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Module_Object_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object>("sp_GetSpartan_Module_Object", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Module_Object_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Module_Object>("sp_DelSpartan_Module_Object", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object entity)
        {
            int rta;
            try
            {

		                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                padreModule_Id.Value = entity.Module_Id;
                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = entity.Name;
                var padrePhysical_Name = _dataProvider.GetParameter();
                padrePhysical_Name.ParameterName = "Physical_Name";
                padrePhysical_Name.DbType = DbType.String;
                padrePhysical_Name.Value = entity.Physical_Name;
                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Module_Object>("sp_InsSpartan_Module_Object" , padreObject_Id 
, padreModule_Id 
, padreName 
, padrePhysical_Name 
, padreURL 
, padreOrder_Shown 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Module_Object_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object entity)
        {
            int rta;
            try
            {

                var padreModule_Object_Id = _dataProvider.GetParameter();
                padreModule_Object_Id.ParameterName = "Module_Object_Id";
                padreModule_Object_Id.DbType = DbType.Int32;
                padreModule_Object_Id.Value = entity.Module_Object_Id;
                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreModule_Id = _dataProvider.GetParameter();
                padreModule_Id.ParameterName = "Module_Id";
                padreModule_Id.DbType = DbType.Int16;
                padreModule_Id.Value = entity.Module_Id;
                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = entity.Name;
                var padrePhysical_Name = _dataProvider.GetParameter();
                padrePhysical_Name.ParameterName = "Physical_Name";
                padrePhysical_Name.DbType = DbType.String;
                padrePhysical_Name.Value = entity.Physical_Name;
                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Module_Object>("sp_UpdSpartan_Module_Object" , padreModule_Object_Id  , padreObject_Id  , padreModule_Id  , padreName  , padrePhysical_Name  , padreURL  , padreOrder_Shown  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Module_Object_Id);
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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Control_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Control_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Control_TypeService : ISpartan_Control_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type> _Spartan_Control_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Control_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type> Spartan_Control_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Control_TypeRepository = Spartan_Control_TypeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Control_TypeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type>("sp_SelAllSpartan_Control_Type");
        }

        public IList<Core.Classes.Spartan_Control_Type.Spartan_Control_Type> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Control_Type_Complete>("sp_SelAllComplete_Spartan_Control_Type");
            return data.Select(m => new Core.Classes.Spartan_Control_Type.Spartan_Control_Type
            {
                Control_Type_Id = m.Control_Type_Id
                ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.User_Id.GetValueOrDefault(), Name = m.User_Id_Name }
                ,Object_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object.GetValueOrDefault(), Name = m.Object_Name }
                ,Order_Shown = m.Order_Shown


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Control_Type>("sp_ListSelCount_Spartan_Control_Type", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Control_Type>("sp_ListSelAll_Spartan_Control_Type", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type
                {
                    Control_Type_Id = m.Spartan_Control_Type_Control_Type_Id,
                    User_Id = m.Spartan_Control_Type_User_Id,
                    Object = m.Spartan_Control_Type_Object,
                    Order_Shown = m.Spartan_Control_Type_Order_Shown,

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

        public IList<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Control_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Control_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Control_Type>("sp_ListSelAll_Spartan_Control_Type", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Control_TypePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Control_TypePagingModel
                {
                    Spartan_Control_Types =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type
                {
                    Control_Type_Id = m.Spartan_Control_Type_Control_Type_Id
                    ,User_Id = m.Spartan_Control_Type_User_Id
                    ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_Control_Type_User_Id.GetValueOrDefault(), Name = m.Spartan_Control_Type_User_Id_Name }
                    ,Object = m.Spartan_Control_Type_Object
                    ,Object_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Control_Type_Object.GetValueOrDefault(), Name = m.Spartan_Control_Type_Object_Name }
                    ,Order_Shown = m.Spartan_Control_Type_Order_Shown

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Control_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Control_Type_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type>("sp_GetSpartan_Control_Type", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Control_Type_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Control_Type>("sp_DelSpartan_Control_Type", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type entity)
        {
            int rta;
            try
            {

		                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                if (entity.Object == null)
                    padreObject.Value = DBNull.Value;
                else
                    padreObject.Value = entity.Object;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Control_Type>("sp_InsSpartan_Control_Type" , padreUser_Id 
, padreObject 
, padreOrder_Shown 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Control_Type_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type entity)
        {
            int rta;
            try
            {

                var padreControl_Type_Id = _dataProvider.GetParameter();
                padreControl_Type_Id.ParameterName = "Control_Type_Id";
                padreControl_Type_Id.DbType = DbType.Int32;
                padreControl_Type_Id.Value = entity.Control_Type_Id;
                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                if (entity.Object == null)
                    padreObject.Value = DBNull.Value;
                else
                    padreObject.Value = entity.Object;

                var padreOrder_Shown = _dataProvider.GetParameter();
                padreOrder_Shown.ParameterName = "Order_Shown";
                padreOrder_Shown.DbType = DbType.Int16;
                if (entity.Order_Shown == null)
                    padreOrder_Shown.Value = DBNull.Value;
                else
                    padreOrder_Shown.Value = entity.Order_Shown;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Control_Type>("sp_UpdSpartan_Control_Type" , padreControl_Type_Id  , padreUser_Id  , padreObject  , padreOrder_Shown  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Control_Type_Id);
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


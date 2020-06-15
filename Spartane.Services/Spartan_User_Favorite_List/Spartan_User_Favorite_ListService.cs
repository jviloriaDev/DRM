using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User_Favorite_List;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Favorite_List
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_Favorite_ListService : ISpartan_User_Favorite_ListService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> _Spartan_User_Favorite_ListRepository;
        #endregion

        #region Ctor
        public Spartan_User_Favorite_ListService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> Spartan_User_Favorite_ListRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_Favorite_ListRepository = Spartan_User_Favorite_ListRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_User_Favorite_ListRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List>("sp_SelAllSpartan_User_Favorite_List");
        }

        public IList<Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Favorite_List_Complete>("sp_SelAllComplete_Spartan_User_Favorite_List");
            return data.Select(m => new Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List
            {
                User_Favorite_List_Id = m.User_Favorite_List_Id
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User_Favorite_List>("sp_ListSelCount_Spartan_User_Favorite_List", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Favorite_List>("sp_ListSelAll_Spartan_User_Favorite_List", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List
                {
                    User_Favorite_List_Id = m.Spartan_User_Favorite_List_User_Favorite_List_Id,
                    User_Id = m.Spartan_User_Favorite_List_User_Id,
                    Object = m.Spartan_User_Favorite_List_Object,
                    Order_Shown = m.Spartan_User_Favorite_List_Order_Shown,

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

        public IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_Favorite_ListRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Favorite_ListRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_ListPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Favorite_List>("sp_ListSelAll_Spartan_User_Favorite_List", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_User_Favorite_ListPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_User_Favorite_ListPagingModel
                {
                    Spartan_User_Favorite_Lists =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List
                {
                    User_Favorite_List_Id = m.Spartan_User_Favorite_List_User_Favorite_List_Id
                    ,User_Id = m.Spartan_User_Favorite_List_User_Id
                    ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_User_Favorite_List_User_Id.GetValueOrDefault(), Name = m.Spartan_User_Favorite_List_User_Id_Name }
                    ,Object = m.Spartan_User_Favorite_List_Object
                    ,Object_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_User_Favorite_List_Object.GetValueOrDefault(), Name = m.Spartan_User_Favorite_List_Object_Name }
                    ,Order_Shown = m.Spartan_User_Favorite_List_Order_Shown

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_Favorite_ListRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "User_Favorite_List_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List>("sp_GetSpartan_User_Favorite_List", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "User_Favorite_List_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User_Favorite_List>("sp_DelSpartan_User_Favorite_List", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User_Favorite_List>("sp_InsSpartan_User_Favorite_List" , padreUser_Id 
, padreObject 
, padreOrder_Shown 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Favorite_List_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List entity)
        {
            int rta;
            try
            {

                var padreUser_Favorite_List_Id = _dataProvider.GetParameter();
                padreUser_Favorite_List_Id.ParameterName = "User_Favorite_List_Id";
                padreUser_Favorite_List_Id.DbType = DbType.Int32;
                padreUser_Favorite_List_Id.Value = entity.User_Favorite_List_Id;
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User_Favorite_List>("sp_UpdSpartan_User_Favorite_List" , padreUser_Favorite_List_Id  , padreUser_Id  , padreObject  , padreOrder_Shown  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Favorite_List_Id);
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


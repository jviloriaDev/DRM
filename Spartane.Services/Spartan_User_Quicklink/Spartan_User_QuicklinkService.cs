using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User_Quicklink;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Quicklink
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_QuicklinkService : ISpartan_User_QuicklinkService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> _Spartan_User_QuicklinkRepository;
        #endregion

        #region Ctor
        public Spartan_User_QuicklinkService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> Spartan_User_QuicklinkRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_QuicklinkRepository = Spartan_User_QuicklinkRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_User_QuicklinkRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink>("sp_SelAllSpartan_User_Quicklink");
        }

        public IList<Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Quicklink_Complete>("sp_SelAllComplete_Spartan_User_Quicklink");
            return data.Select(m => new Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink
            {
                User_Quicklink_Id = m.User_Quicklink_Id
                ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.User_Id.GetValueOrDefault(), Name = m.User_Id_Name }
                ,Object_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object.GetValueOrDefault(), Name = m.Object_Name }
                ,Order_Shown = m.Order_Shown
                ,Method_Type_Spartan_Method_Type = new Core.Classes.Spartan_Method_Type.Spartan_Method_Type() { Method_Type_Id = m.Method_Type.GetValueOrDefault(), Description = m.Method_Type_Description }
                ,Description = m.Description
                ,Atribute_Id = m.Atribute_Id
                ,Control_Type_Spartan_Control_Type = new Core.Classes.Spartan_Control_Type.Spartan_Control_Type() { Control_Type_Id = m.Control_Type.GetValueOrDefault(), User_Id = m.Control_Type_User_Id }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User_Quicklink>("sp_ListSelCount_Spartan_User_Quicklink", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Quicklink>("sp_ListSelAll_Spartan_User_Quicklink", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink
                {
                    User_Quicklink_Id = m.Spartan_User_Quicklink_User_Quicklink_Id,
                    User_Id = m.Spartan_User_Quicklink_User_Id,
                    Object = m.Spartan_User_Quicklink_Object,
                    Order_Shown = m.Spartan_User_Quicklink_Order_Shown,
                    Method_Type = m.Spartan_User_Quicklink_Method_Type,
                    Description = m.Spartan_User_Quicklink_Description,
                    Atribute_Id = m.Spartan_User_Quicklink_Atribute_Id,
                    Control_Type = m.Spartan_User_Quicklink_Control_Type,

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

        public IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_QuicklinkRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_QuicklinkRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_QuicklinkPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Quicklink>("sp_ListSelAll_Spartan_User_Quicklink", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_User_QuicklinkPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_User_QuicklinkPagingModel
                {
                    Spartan_User_Quicklinks =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink
                {
                    User_Quicklink_Id = m.Spartan_User_Quicklink_User_Quicklink_Id
                    ,User_Id = m.Spartan_User_Quicklink_User_Id
                    ,User_Id_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_User_Quicklink_User_Id.GetValueOrDefault(), Name = m.Spartan_User_Quicklink_User_Id_Name }
                    ,Object = m.Spartan_User_Quicklink_Object
                    ,Object_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_User_Quicklink_Object.GetValueOrDefault(), Name = m.Spartan_User_Quicklink_Object_Name }
                    ,Order_Shown = m.Spartan_User_Quicklink_Order_Shown
                    ,Method_Type = m.Spartan_User_Quicklink_Method_Type
                    ,Method_Type_Spartan_Method_Type = new Core.Classes.Spartan_Method_Type.Spartan_Method_Type() { Method_Type_Id = m.Spartan_User_Quicklink_Method_Type.GetValueOrDefault(), Description = m.Spartan_User_Quicklink_Method_Type_Description }
                    ,Description = m.Spartan_User_Quicklink_Description
                    ,Atribute_Id = m.Spartan_User_Quicklink_Atribute_Id
                    ,Control_Type = m.Spartan_User_Quicklink_Control_Type
                    ,Control_Type_Spartan_Control_Type = new Core.Classes.Spartan_Control_Type.Spartan_Control_Type() { Control_Type_Id = m.Spartan_User_Quicklink_Control_Type.GetValueOrDefault(), User_Id = m.Spartan_User_Quicklink_Control_Type_User_Id }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_QuicklinkRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "User_Quicklink_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink>("sp_GetSpartan_User_Quicklink", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "User_Quicklink_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User_Quicklink>("sp_DelSpartan_User_Quicklink", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink entity)
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

                var padreMethod_Type = _dataProvider.GetParameter();
                padreMethod_Type.ParameterName = "Method_Type";
                padreMethod_Type.DbType = DbType.Int16;
                if (entity.Method_Type == null)
                    padreMethod_Type.Value = DBNull.Value;
                else
                    padreMethod_Type.Value = entity.Method_Type;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreAtribute_Id = _dataProvider.GetParameter();
                padreAtribute_Id.ParameterName = "Atribute_Id";
                padreAtribute_Id.DbType = DbType.Int32;
                if (entity.Atribute_Id == null)
                    padreAtribute_Id.Value = DBNull.Value;
                else
                    padreAtribute_Id.Value = entity.Atribute_Id;

                var padreControl_Type = _dataProvider.GetParameter();
                padreControl_Type.ParameterName = "Control_Type";
                padreControl_Type.DbType = DbType.Int32;
                if (entity.Control_Type == null)
                    padreControl_Type.Value = DBNull.Value;
                else
                    padreControl_Type.Value = entity.Control_Type;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User_Quicklink>("sp_InsSpartan_User_Quicklink" , padreUser_Id 
, padreObject 
, padreOrder_Shown 
, padreMethod_Type 
, padreDescription 
, padreAtribute_Id 
, padreControl_Type 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Quicklink_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink entity)
        {
            int rta;
            try
            {

                var padreUser_Quicklink_Id = _dataProvider.GetParameter();
                padreUser_Quicklink_Id.ParameterName = "User_Quicklink_Id";
                padreUser_Quicklink_Id.DbType = DbType.Int32;
                padreUser_Quicklink_Id.Value = entity.User_Quicklink_Id;
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

                var padreMethod_Type = _dataProvider.GetParameter();
                padreMethod_Type.ParameterName = "Method_Type";
                padreMethod_Type.DbType = DbType.Int16;
                if (entity.Method_Type == null)
                    padreMethod_Type.Value = DBNull.Value;
                else
                    padreMethod_Type.Value = entity.Method_Type;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreAtribute_Id = _dataProvider.GetParameter();
                padreAtribute_Id.ParameterName = "Atribute_Id";
                padreAtribute_Id.DbType = DbType.Int32;
                if (entity.Atribute_Id == null)
                    padreAtribute_Id.Value = DBNull.Value;
                else
                    padreAtribute_Id.Value = entity.Atribute_Id;

                var padreControl_Type = _dataProvider.GetParameter();
                padreControl_Type.ParameterName = "Control_Type";
                padreControl_Type.DbType = DbType.Int32;
                if (entity.Control_Type == null)
                    padreControl_Type.Value = DBNull.Value;
                else
                    padreControl_Type.Value = entity.Control_Type;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User_Quicklink>("sp_UpdSpartan_User_Quicklink" , padreUser_Quicklink_Id  , padreUser_Id  , padreObject  , padreOrder_Shown  , padreMethod_Type  , padreDescription  , padreAtribute_Id  , padreControl_Type  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.User_Quicklink_Id);
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


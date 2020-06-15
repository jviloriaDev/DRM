using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Object_Path;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Object_Path
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Object_PathService : ISpartan_Object_PathService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> _Spartan_Object_PathRepository;
        #endregion

        #region Ctor
        public Spartan_Object_PathService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> Spartan_Object_PathRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Object_PathRepository = Spartan_Object_PathRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Object_PathRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path>("sp_SelAllSpartan_Object_Path");
        }

        public IList<Core.Classes.Spartan_Object_Path.Spartan_Object_Path> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Object_Path_Complete>("sp_SelAllComplete_Spartan_Object_Path");
            return data.Select(m => new Core.Classes.Spartan_Object_Path.Spartan_Object_Path
            {
                Object_Path_Id = m.Object_Path_Id
                ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object_Id.GetValueOrDefault(), Name = m.Object_Id_Name }
                ,Description = m.Description
                ,URL = m.URL
                ,Token_Type_Spartan_Token_Type = new Core.Classes.Spartan_Token_Type.Spartan_Token_Type() { Token_Type_Id = m.Token_Type.GetValueOrDefault(), Description = m.Token_Type_Description }
                ,Order = m.Order


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Object_Path>("sp_ListSelCount_Spartan_Object_Path", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object_Path>("sp_ListSelAll_Spartan_Object_Path", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path
                {
                    Object_Path_Id = m.Spartan_Object_Path_Object_Path_Id,
                    Object_Id = m.Spartan_Object_Path_Object_Id,
                    Description = m.Spartan_Object_Path_Description,
                    URL = m.Spartan_Object_Path_URL,
                    Token_Type = m.Spartan_Object_Path_Token_Type,
                    Order = m.Spartan_Object_Path_Order,

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

        public IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Object_PathRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Object_PathRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_PathPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object_Path>("sp_ListSelAll_Spartan_Object_Path", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Object_PathPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Object_PathPagingModel
                {
                    Spartan_Object_Paths =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path
                {
                    Object_Path_Id = m.Spartan_Object_Path_Object_Path_Id
                    ,Object_Id = m.Spartan_Object_Path_Object_Id
                    ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Object_Path_Object_Id.GetValueOrDefault(), Name = m.Spartan_Object_Path_Object_Id_Name }
                    ,Description = m.Spartan_Object_Path_Description
                    ,URL = m.Spartan_Object_Path_URL
                    ,Token_Type = m.Spartan_Object_Path_Token_Type
                    ,Token_Type_Spartan_Token_Type = new Core.Classes.Spartan_Token_Type.Spartan_Token_Type() { Token_Type_Id = m.Spartan_Object_Path_Token_Type.GetValueOrDefault(), Description = m.Spartan_Object_Path_Token_Type_Description }
                    ,Order = m.Spartan_Object_Path_Order

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Object_PathRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Object_Path_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path>("sp_GetSpartan_Object_Path", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Object_Path_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Object_Path>("sp_DelSpartan_Object_Path", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path entity)
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

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreToken_Type = _dataProvider.GetParameter();
                padreToken_Type.ParameterName = "Token_Type";
                padreToken_Type.DbType = DbType.Int16;
                if (entity.Token_Type == null)
                    padreToken_Type.Value = DBNull.Value;
                else
                    padreToken_Type.Value = entity.Token_Type;

                var padreOrder = _dataProvider.GetParameter();
                padreOrder.ParameterName = "Order";
                padreOrder.DbType = DbType.Int16;
                if (entity.Order == null)
                    padreOrder.Value = DBNull.Value;
                else
                    padreOrder.Value = entity.Order;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Object_Path>("sp_InsSpartan_Object_Path" , padreObject_Id 
, padreDescription 
, padreURL 
, padreToken_Type 
, padreOrder 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Path_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path entity)
        {
            int rta;
            try
            {

                var padreObject_Path_Id = _dataProvider.GetParameter();
                padreObject_Path_Id.ParameterName = "Object_Path_Id";
                padreObject_Path_Id.DbType = DbType.Int32;
                padreObject_Path_Id.Value = entity.Object_Path_Id;
                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreURL = _dataProvider.GetParameter();
                padreURL.ParameterName = "URL";
                padreURL.DbType = DbType.String;
                padreURL.Value = entity.URL;
                var padreToken_Type = _dataProvider.GetParameter();
                padreToken_Type.ParameterName = "Token_Type";
                padreToken_Type.DbType = DbType.Int16;
                if (entity.Token_Type == null)
                    padreToken_Type.Value = DBNull.Value;
                else
                    padreToken_Type.Value = entity.Token_Type;

                var padreOrder = _dataProvider.GetParameter();
                padreOrder.ParameterName = "Order";
                padreOrder.DbType = DbType.Int16;
                if (entity.Order == null)
                    padreOrder.Value = DBNull.Value;
                else
                    padreOrder.Value = entity.Order;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Object_Path>("sp_UpdSpartan_Object_Path" , padreObject_Path_Id  , padreObject_Id  , padreDescription  , padreURL  , padreToken_Type  , padreOrder  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Path_Id);
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


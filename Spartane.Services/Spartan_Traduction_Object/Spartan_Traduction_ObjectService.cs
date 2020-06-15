using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Traduction_Object;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Object
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_ObjectService : ISpartan_Traduction_ObjectService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object> _Spartan_Traduction_ObjectRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_ObjectService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object> Spartan_Traduction_ObjectRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_ObjectRepository = Spartan_Traduction_ObjectRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Traduction_ObjectRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object>("sp_SelAllSpartan_Traduction_Object");
        }

        public IList<Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Traduction_Object_Complete>("sp_SelAllComplete_Spartan_Traduction_Object");
            return data.Select(m => new Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object
            {
                IdObject = m.IdObject
                ,Object_Description = m.Object_Description
                ,Object_Type_Spartan_Traduction_Object_Type = new Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type() { IdType = m.Object_Type.GetValueOrDefault(), Object_Type_Description = m.Object_Type_Object_Type_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Traduction_Object>("sp_ListSelCount_Spartan_Traduction_Object", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Object>("sp_ListSelAll_Spartan_Traduction_Object", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object
                {
                    IdObject = m.Spartan_Traduction_Object_IdObject,
                    Object_Description = m.Spartan_Traduction_Object_Object_Description,
                    Object_Type = m.Spartan_Traduction_Object_Object_Type,

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

        public IList<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Object>("sp_ListSelAll_Spartan_Traduction_Object", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Traduction_ObjectPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Traduction_ObjectPagingModel
                {
                    Spartan_Traduction_Objects =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object
                {
                    IdObject = m.Spartan_Traduction_Object_IdObject
                    ,Object_Description = m.Spartan_Traduction_Object_Object_Description
                    ,Object_Type = m.Spartan_Traduction_Object_Object_Type
                    ,Object_Type_Spartan_Traduction_Object_Type = new Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type() { IdType = m.Spartan_Traduction_Object_Object_Type.GetValueOrDefault(), Object_Type_Description = m.Spartan_Traduction_Object_Object_Type_Object_Type_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "IdObject";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object>("sp_GetSpartan_Traduction_Object", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "IdObject";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Traduction_Object>("sp_DelSpartan_Traduction_Object", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object entity)
        {
            int rta;
            try
            {

		                var padreObject_Description = _dataProvider.GetParameter();
                padreObject_Description.ParameterName = "Object_Description";
                padreObject_Description.DbType = DbType.String;
                padreObject_Description.Value = (object)entity.Object_Description ?? DBNull.Value;
                var padreObject_Type = _dataProvider.GetParameter();
                padreObject_Type.ParameterName = "Object_Type";
                padreObject_Type.DbType = DbType.Int32;
                padreObject_Type.Value = (object)entity.Object_Type ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Traduction_Object>("sp_InsSpartan_Traduction_Object" 
, padreObject_Description
, padreObject_Type
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdObject);

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

        public int Update(Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object entity)
        {
            int rta;
            try
            {

                var paramUpdIdObject = _dataProvider.GetParameter();
                paramUpdIdObject.ParameterName = "IdObject";
                paramUpdIdObject.DbType = DbType.Int32;
                paramUpdIdObject.Value = (object)entity.IdObject ?? DBNull.Value;
                var paramUpdObject_Description = _dataProvider.GetParameter();
                paramUpdObject_Description.ParameterName = "Object_Description";
                paramUpdObject_Description.DbType = DbType.String;
                paramUpdObject_Description.Value = (object)entity.Object_Description ?? DBNull.Value;
                var paramUpdObject_Type = _dataProvider.GetParameter();
                paramUpdObject_Type.ParameterName = "Object_Type";
                paramUpdObject_Type.DbType = DbType.Int32;
                paramUpdObject_Type.Value = (object)entity.Object_Type ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Traduction_Object>("sp_UpdSpartan_Traduction_Object" , paramUpdIdObject , paramUpdObject_Description , paramUpdObject_Type ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdObject);
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

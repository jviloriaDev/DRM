using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Method_Type_Function;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Method_Type_Function
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Method_Type_FunctionService : ISpartan_Method_Type_FunctionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> _Spartan_Method_Type_FunctionRepository;
        #endregion

        #region Ctor
        public Spartan_Method_Type_FunctionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> Spartan_Method_Type_FunctionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Method_Type_FunctionRepository = Spartan_Method_Type_FunctionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Method_Type_FunctionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function>("sp_SelAllSpartan_Method_Type_Function");
        }

        public IList<Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Method_Type_Function_Complete>("sp_SelAllComplete_Spartan_Method_Type_Function");
            return data.Select(m => new Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function
            {
                Method_Type_Function_Id = m.Method_Type_Function_Id
                ,Function_Id_Spartan_Function = new Core.Classes.Spartan_Function.Spartan_Function() { Function_Id = m.Function_Id.GetValueOrDefault(), Description = m.Function_Id_Description }
                ,Spartan_Method_Type = m.Spartan_Method_Type


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Method_Type_Function>("sp_ListSelCount_Spartan_Method_Type_Function", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Method_Type_Function>("sp_ListSelAll_Spartan_Method_Type_Function", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function
                {
                    Method_Type_Function_Id = m.Spartan_Method_Type_Function_Method_Type_Function_Id,
                    Function_Id = m.Spartan_Method_Type_Function_Function_Id,
                    Spartan_Method_Type = m.Spartan_Method_Type_Function_Spartan_Method_Type,

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

        public IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Method_Type_FunctionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Method_Type_FunctionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_FunctionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Method_Type_Function>("sp_ListSelAll_Spartan_Method_Type_Function", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Method_Type_FunctionPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Method_Type_FunctionPagingModel
                {
                    Spartan_Method_Type_Functions =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function
                {
                    Method_Type_Function_Id = m.Spartan_Method_Type_Function_Method_Type_Function_Id
                    ,Function_Id = m.Spartan_Method_Type_Function_Function_Id
                    ,Function_Id_Spartan_Function = new Core.Classes.Spartan_Function.Spartan_Function() { Function_Id = m.Spartan_Method_Type_Function_Function_Id.GetValueOrDefault(), Description = m.Spartan_Method_Type_Function_Function_Id_Description }
                    ,Spartan_Method_Type = m.Spartan_Method_Type_Function_Spartan_Method_Type

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Method_Type_FunctionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Method_Type_Function_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function>("sp_GetSpartan_Method_Type_Function", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Method_Type_Function_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Method_Type_Function>("sp_DelSpartan_Method_Type_Function", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function entity)
        {
            short rta;
            try
            {

		                var padreFunction_Id = _dataProvider.GetParameter();
                padreFunction_Id.ParameterName = "Function_Id";
                padreFunction_Id.DbType = DbType.Int16;
                if (entity.Function_Id == null)
                    padreFunction_Id.Value = DBNull.Value;
                else
                    padreFunction_Id.Value = entity.Function_Id;

                var padreSpartan_Method_Type = _dataProvider.GetParameter();
                padreSpartan_Method_Type.ParameterName = "Spartan_Method_Type";
                padreSpartan_Method_Type.DbType = DbType.Int16;
                padreSpartan_Method_Type.Value = entity.Spartan_Method_Type;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Method_Type_Function>("sp_InsSpartan_Method_Type_Function" , padreFunction_Id 
, padreSpartan_Method_Type 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Method_Type_Function_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function entity)
        {
            short rta;
            try
            {

                var padreMethod_Type_Function_Id = _dataProvider.GetParameter();
                padreMethod_Type_Function_Id.ParameterName = "Method_Type_Function_Id";
                padreMethod_Type_Function_Id.DbType = DbType.Int16;
                padreMethod_Type_Function_Id.Value = entity.Method_Type_Function_Id;
                var padreFunction_Id = _dataProvider.GetParameter();
                padreFunction_Id.ParameterName = "Function_Id";
                padreFunction_Id.DbType = DbType.Int16;
                if (entity.Function_Id == null)
                    padreFunction_Id.Value = DBNull.Value;
                else
                    padreFunction_Id.Value = entity.Function_Id;

                var padreSpartan_Method_Type = _dataProvider.GetParameter();
                padreSpartan_Method_Type.ParameterName = "Spartan_Method_Type";
                padreSpartan_Method_Type.DbType = DbType.Int16;
                padreSpartan_Method_Type.Value = entity.Spartan_Method_Type;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Method_Type_Function>("sp_UpdSpartan_Method_Type_Function" , padreMethod_Type_Function_Id  , padreFunction_Id  , padreSpartan_Method_Type  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Method_Type_Function_Id);
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


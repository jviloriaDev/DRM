using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Traduction_Object_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Object_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_Object_TypeService : ISpartan_Traduction_Object_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> _Spartan_Traduction_Object_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_Object_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> Spartan_Traduction_Object_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_Object_TypeRepository = Spartan_Traduction_Object_TypeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type>("sp_SelAllSpartan_Traduction_Object_Type");
        }

        public IList<Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Traduction_Object_Type_Complete>("sp_SelAllComplete_Spartan_Traduction_Object_Type");
            return data.Select(m => new Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type
            {
                IdType = m.IdType
                ,Object_Type_Description = m.Object_Type_Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Traduction_Object_Type>("sp_ListSelCount_Spartan_Traduction_Object_Type", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Object_Type>("sp_ListSelAll_Spartan_Traduction_Object_Type", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type
                {
                    IdType = m.Spartan_Traduction_Object_Type_IdType,
                    Object_Type_Description = m.Spartan_Traduction_Object_Type_Object_Type_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Object_Type>("sp_ListSelAll_Spartan_Traduction_Object_Type", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Traduction_Object_TypePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Traduction_Object_TypePagingModel
                {
                    Spartan_Traduction_Object_Types =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type
                {
                    IdType = m.Spartan_Traduction_Object_Type_IdType
                    ,Object_Type_Description = m.Spartan_Traduction_Object_Type_Object_Type_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "IdType";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type>("sp_GetSpartan_Traduction_Object_Type", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "IdType";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Traduction_Object_Type>("sp_DelSpartan_Traduction_Object_Type", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type entity)
        {
            int rta;
            try
            {

		                var padreObject_Type_Description = _dataProvider.GetParameter();
                padreObject_Type_Description.ParameterName = "Object_Type_Description";
                padreObject_Type_Description.DbType = DbType.String;
                padreObject_Type_Description.Value = (object)entity.Object_Type_Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Traduction_Object_Type>("sp_InsSpartan_Traduction_Object_Type" 
, padreObject_Type_Description
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdType);

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

        public int Update(Spartane.Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type entity)
        {
            int rta;
            try
            {

                var paramUpdIdType = _dataProvider.GetParameter();
                paramUpdIdType.ParameterName = "IdType";
                paramUpdIdType.DbType = DbType.Int32;
                paramUpdIdType.Value = (object)entity.IdType ?? DBNull.Value;
                var paramUpdObject_Type_Description = _dataProvider.GetParameter();
                paramUpdObject_Type_Description.ParameterName = "Object_Type_Description";
                paramUpdObject_Type_Description.DbType = DbType.String;
                paramUpdObject_Type_Description.Value = (object)entity.Object_Type_Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Traduction_Object_Type>("sp_UpdSpartan_Traduction_Object_Type" , paramUpdIdType , paramUpdObject_Type_Description ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdType);
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

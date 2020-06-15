using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.SpartanObject;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.SpartanObject
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class SpartanObjectService : ISpartanObjectService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.SpartanObject.SpartanObject> _SpartanObjectRepository;
        #endregion

        #region Ctor
        public SpartanObjectService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.SpartanObject.SpartanObject> SpartanObjectRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._SpartanObjectRepository = SpartanObjectRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._SpartanObjectRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.SpartanObject.SpartanObject> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.SpartanObject.SpartanObject>("sp_SelAllSpartanObject");
        }

        public IList<Core.Classes.SpartanObject.SpartanObject> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartanObject_Complete>("sp_SelAllComplete_SpartanObject");
            return data.Select(m => new Core.Classes.SpartanObject.SpartanObject
            {
                Object_Id = m.Object_Id
                ,Name = m.Name


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_SpartanObject>("sp_ListSelCount_SpartanObject", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.SpartanObject.SpartanObject> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartanObject>("sp_ListSelAll_SpartanObject", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.SpartanObject.SpartanObject
                {
                    Object_Id = m.SpartanObject_Object_Id,
                    Name = m.SpartanObject_Name,

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

        public IList<Spartane.Core.Classes.SpartanObject.SpartanObject> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._SpartanObjectRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.SpartanObject.SpartanObject> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SpartanObjectRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.SpartanObject.SpartanObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartanObject>("sp_ListSelAll_SpartanObject", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            SpartanObjectPagingModel result = null;

            if (data != null)
            {
                result = new SpartanObjectPagingModel
                {
                    SpartanObjects =
                        data.Select(m => new Spartane.Core.Classes.SpartanObject.SpartanObject
                {
                    Object_Id = m.SpartanObject_Object_Id
                    ,Name = m.SpartanObject_Name

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.SpartanObject.SpartanObject> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._SpartanObjectRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.SpartanObject.SpartanObject GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Object_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.SpartanObject.SpartanObject>("sp_GetSpartanObject", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Object_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartanObject>("sp_DelSpartanObject", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.SpartanObject.SpartanObject entity)
        {
            int rta;
            try
            {

		                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                padreObject_Id.Value = entity.Object_Id;
                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = (object)entity.Name ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartanObject>("sp_InsSpartanObject" , padreObject_Id
, padreName
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Id);

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

        public int Update(Spartane.Core.Classes.SpartanObject.SpartanObject entity)
        {
            int rta;
            try
            {

                var paramUpdObject_Id = _dataProvider.GetParameter();
                paramUpdObject_Id.ParameterName = "Object_Id";
                paramUpdObject_Id.DbType = DbType.Int32;
                paramUpdObject_Id.Value = (object)entity.Object_Id ?? DBNull.Value;
                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)entity.Name ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartanObject>("sp_UpdSpartanObject" , paramUpdObject_Id , paramUpdName ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Id);
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

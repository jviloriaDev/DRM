using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Type_Flow_Control
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Type_Flow_ControlService : ISpartan_WorkFlow_Type_Flow_ControlService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> _Spartan_WorkFlow_Type_Flow_ControlRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Type_Flow_ControlService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> Spartan_WorkFlow_Type_Flow_ControlRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Type_Flow_ControlRepository = Spartan_WorkFlow_Type_Flow_ControlRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>("sp_SelAllSpartan_WorkFlow_Type_Flow_Control");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Type_Flow_Control_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Type_Flow_Control");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control
            {
                Type_Flow_ControlId = m.Type_Flow_ControlId
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Type_Flow_Control>("sp_ListSelCount_Spartan_WorkFlow_Type_Flow_Control", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Type_Flow_Control>("sp_ListSelAll_Spartan_WorkFlow_Type_Flow_Control", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control
                {
                    Type_Flow_ControlId = m.Spartan_WorkFlow_Type_Flow_Control_Type_Flow_ControlId,
                    Description = m.Spartan_WorkFlow_Type_Flow_Control_Description,

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

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Type_Flow_Control>("sp_ListSelAll_Spartan_WorkFlow_Type_Flow_Control", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_Type_Flow_ControlPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_Type_Flow_ControlPagingModel
                {
                    Spartan_WorkFlow_Type_Flow_Controls =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control
                {
                    Type_Flow_ControlId = m.Spartan_WorkFlow_Type_Flow_Control_Type_Flow_ControlId
                    ,Description = m.Spartan_WorkFlow_Type_Flow_Control_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Type_Flow_ControlId";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>("sp_GetSpartan_WorkFlow_Type_Flow_Control", padreKey).SingleOrDefault();
        }

        public bool Delete(short Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Type_Flow_ControlId";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Type_Flow_Control>("sp_DelSpartan_WorkFlow_Type_Flow_Control", padreKey).FirstOrDefault();
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

        public short Insert(Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Type_Flow_Control>("sp_InsSpartan_WorkFlow_Type_Flow_Control" 
, padreDescription
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Type_Flow_ControlId);

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

        public short Update(Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity)
        {
            short rta;
            try
            {

                var paramUpdType_Flow_ControlId = _dataProvider.GetParameter();
                paramUpdType_Flow_ControlId.ParameterName = "Type_Flow_ControlId";
                paramUpdType_Flow_ControlId.DbType = DbType.Int16;
                paramUpdType_Flow_ControlId.Value = (object)entity.Type_Flow_ControlId ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Type_Flow_Control>("sp_UpdSpartan_WorkFlow_Type_Flow_Control" , paramUpdType_Flow_ControlId , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Type_Flow_ControlId);
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

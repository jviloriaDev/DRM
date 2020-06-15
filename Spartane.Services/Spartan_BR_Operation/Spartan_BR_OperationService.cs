using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Operation;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Operation
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_OperationService : ISpartan_BR_OperationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> _Spartan_BR_OperationRepository;
        #endregion

        #region Ctor
        public Spartan_BR_OperationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> Spartan_BR_OperationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_OperationRepository = Spartan_BR_OperationRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_OperationRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation>("sp_SelAllSpartan_BR_Operation");
        }

        public IList<Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Operation_Complete>("sp_SelAllComplete_Spartan_BR_Operation");
            return data.Select(m => new Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation
            {
                OperationId = m.OperationId
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Operation>("sp_ListSelCount_Spartan_BR_Operation", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Operation>("sp_ListSelAll_Spartan_BR_Operation", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation
                {
                    OperationId = m.Spartan_BR_Operation_OperationId,
                    Description = m.Spartan_BR_Operation_Description,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_OperationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_OperationRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_OperationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Operation>("sp_ListSelAll_Spartan_BR_Operation", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_OperationPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_OperationPagingModel
                {
                    Spartan_BR_Operations =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation
                {
                    OperationId = m.Spartan_BR_Operation_OperationId
                    ,Description = m.Spartan_BR_Operation_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_OperationRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "OperationId";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation>("sp_GetSpartan_BR_Operation", padreKey).SingleOrDefault();
        }

        public bool Delete(short Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "OperationId";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Operation>("sp_DelSpartan_BR_Operation", padreKey).FirstOrDefault();
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

        public short Insert(Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Operation>("sp_InsSpartan_BR_Operation" , padreDescription
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.OperationId);

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

        public short Update(Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation entity)
        {
            short rta;
            try
            {

                var paramUpdOperationId = _dataProvider.GetParameter();
                paramUpdOperationId.ParameterName = "OperationId";
                paramUpdOperationId.DbType = DbType.Int16;
                paramUpdOperationId.Value = entity.OperationId;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Operation>("sp_UpdSpartan_BR_Operation" , paramUpdOperationId , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.OperationId);
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


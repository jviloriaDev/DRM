using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Traduction_Concept_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Concept_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_Concept_TypeService : ISpartan_Traduction_Concept_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type> _Spartan_Traduction_Concept_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_Concept_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type> Spartan_Traduction_Concept_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_Concept_TypeRepository = Spartan_Traduction_Concept_TypeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Traduction_Concept_TypeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type>("sp_SelAllSpartan_Traduction_Concept_Type");
        }

        public IList<Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Traduction_Concept_Type_Complete>("sp_SelAllComplete_Spartan_Traduction_Concept_Type");
            return data.Select(m => new Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type
            {
                IdConcept = m.IdConcept
                ,Concept_Description = m.Concept_Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Traduction_Concept_Type>("sp_ListSelCount_Spartan_Traduction_Concept_Type", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Concept_Type>("sp_ListSelAll_Spartan_Traduction_Concept_Type", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type
                {
                    IdConcept = m.Spartan_Traduction_Concept_Type_IdConcept,
                    Concept_Description = m.Spartan_Traduction_Concept_Type_Concept_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_Concept_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_Concept_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Concept_Type>("sp_ListSelAll_Spartan_Traduction_Concept_Type", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Traduction_Concept_TypePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Traduction_Concept_TypePagingModel
                {
                    Spartan_Traduction_Concept_Types =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type
                {
                    IdConcept = m.Spartan_Traduction_Concept_Type_IdConcept
                    ,Concept_Description = m.Spartan_Traduction_Concept_Type_Concept_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_Concept_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "IdConcept";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type>("sp_GetSpartan_Traduction_Concept_Type", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "IdConcept";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Traduction_Concept_Type>("sp_DelSpartan_Traduction_Concept_Type", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type entity)
        {
            int rta;
            try
            {

		                var padreConcept_Description = _dataProvider.GetParameter();
                padreConcept_Description.ParameterName = "Concept_Description";
                padreConcept_Description.DbType = DbType.String;
                padreConcept_Description.Value = (object)entity.Concept_Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Traduction_Concept_Type>("sp_InsSpartan_Traduction_Concept_Type" 
, padreConcept_Description
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdConcept);

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

        public int Update(Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type entity)
        {
            int rta;
            try
            {

                var paramUpdIdConcept = _dataProvider.GetParameter();
                paramUpdIdConcept.ParameterName = "IdConcept";
                paramUpdIdConcept.DbType = DbType.Int32;
                paramUpdIdConcept.Value = (object)entity.IdConcept ?? DBNull.Value;
                var paramUpdConcept_Description = _dataProvider.GetParameter();
                paramUpdConcept_Description.ParameterName = "Concept_Description";
                paramUpdConcept_Description.DbType = DbType.String;
                paramUpdConcept_Description.Value = (object)entity.Concept_Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Traduction_Concept_Type>("sp_UpdSpartan_Traduction_Concept_Type" , paramUpdIdConcept , paramUpdConcept_Description ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdConcept);
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

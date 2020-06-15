using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Traduction_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_DetailService : ISpartan_Traduction_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail> _Spartan_Traduction_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail> Spartan_Traduction_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_DetailRepository = Spartan_Traduction_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Traduction_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail>("sp_SelAllSpartan_Traduction_Detail");
        }

        public IList<Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Traduction_Detail_Complete>("sp_SelAllComplete_Spartan_Traduction_Detail");
            return data.Select(m => new Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail
            {
                IdTraductionDetail = m.IdTraductionDetail
                ,Spartan_Traduction_Process = m.Spartan_Traduction_Process
                ,Concept_Spartan_Traduction_Concept_Type = new Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type() { IdConcept = m.Concept.GetValueOrDefault(), Concept_Description = m.Concept_Concept_Description }
                ,IdConcept = m.IdConcept
                ,Original_Text = m.Original_Text
                ,Translated_Text = m.Translated_Text


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Traduction_Detail>("sp_ListSelCount_Spartan_Traduction_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Detail>("sp_ListSelAll_Spartan_Traduction_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail
                {
                    IdTraductionDetail = m.Spartan_Traduction_Detail_IdTraductionDetail,
                    Spartan_Traduction_Process = m.Spartan_Traduction_Detail_Spartan_Traduction_Process,
                    Concept = m.Spartan_Traduction_Detail_Concept,
                    IdConcept = m.Spartan_Traduction_Detail_IdConcept,
                    Original_Text = m.Spartan_Traduction_Detail_Original_Text,
                    Translated_Text = m.Spartan_Traduction_Detail_Translated_Text,

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

        public IList<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Detail>("sp_ListSelAll_Spartan_Traduction_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Traduction_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Traduction_DetailPagingModel
                {
                    Spartan_Traduction_Details =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail
                {
                    IdTraductionDetail = m.Spartan_Traduction_Detail_IdTraductionDetail
                    ,Spartan_Traduction_Process = m.Spartan_Traduction_Detail_Spartan_Traduction_Process
                    ,Concept = m.Spartan_Traduction_Detail_Concept
                    ,Concept_Spartan_Traduction_Concept_Type = new Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type() { IdConcept = m.Spartan_Traduction_Detail_Concept.GetValueOrDefault(), Concept_Description = m.Spartan_Traduction_Detail_Concept_Concept_Description }
                    ,IdConcept = m.Spartan_Traduction_Detail_IdConcept
                    ,Original_Text = m.Spartan_Traduction_Detail_Original_Text
                    ,Translated_Text = m.Spartan_Traduction_Detail_Translated_Text

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "IdTraductionDetail";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail>("sp_GetSpartan_Traduction_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "IdTraductionDetail";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Traduction_Detail>("sp_DelSpartan_Traduction_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail entity)
        {
            int rta;
            try
            {

		                var padreSpartan_Traduction_Process = _dataProvider.GetParameter();
                padreSpartan_Traduction_Process.ParameterName = "Spartan_Traduction_Process";
                padreSpartan_Traduction_Process.DbType = DbType.Int32;
                padreSpartan_Traduction_Process.Value = (object)entity.Spartan_Traduction_Process ?? DBNull.Value;
                var padreConcept = _dataProvider.GetParameter();
                padreConcept.ParameterName = "Concept";
                padreConcept.DbType = DbType.Int32;
                padreConcept.Value = (object)entity.Concept ?? DBNull.Value;

                var padreIdConcept = _dataProvider.GetParameter();
                padreIdConcept.ParameterName = "IdConcept";
                padreIdConcept.DbType = DbType.Int32;
                padreIdConcept.Value = (object)entity.IdConcept ?? DBNull.Value;

                var padreOriginal_Text = _dataProvider.GetParameter();
                padreOriginal_Text.ParameterName = "Original_Text";
                padreOriginal_Text.DbType = DbType.String;
                padreOriginal_Text.Value = (object)entity.Original_Text ?? DBNull.Value;
                var padreTranslated_Text = _dataProvider.GetParameter();
                padreTranslated_Text.ParameterName = "Translated_Text";
                padreTranslated_Text.DbType = DbType.String;
                padreTranslated_Text.Value = (object)entity.Translated_Text ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Traduction_Detail>("sp_InsSpartan_Traduction_Detail" 
, padreSpartan_Traduction_Process
, padreConcept
, padreIdConcept
, padreOriginal_Text
, padreTranslated_Text
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdTraductionDetail);

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

        public int Update(Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdIdTraductionDetail = _dataProvider.GetParameter();
                paramUpdIdTraductionDetail.ParameterName = "IdTraductionDetail";
                paramUpdIdTraductionDetail.DbType = DbType.Int32;
                paramUpdIdTraductionDetail.Value = (object)entity.IdTraductionDetail ?? DBNull.Value;
                var paramUpdSpartan_Traduction_Process = _dataProvider.GetParameter();
                paramUpdSpartan_Traduction_Process.ParameterName = "Spartan_Traduction_Process";
                paramUpdSpartan_Traduction_Process.DbType = DbType.Int32;
                paramUpdSpartan_Traduction_Process.Value = (object)entity.Spartan_Traduction_Process ?? DBNull.Value;
                var paramUpdConcept = _dataProvider.GetParameter();
                paramUpdConcept.ParameterName = "Concept";
                paramUpdConcept.DbType = DbType.Int32;
                paramUpdConcept.Value = (object)entity.Concept ?? DBNull.Value;

                var paramUpdIdConcept = _dataProvider.GetParameter();
                paramUpdIdConcept.ParameterName = "IdConcept";
                paramUpdIdConcept.DbType = DbType.Int32;
                paramUpdIdConcept.Value = (object)entity.IdConcept ?? DBNull.Value;

                var paramUpdOriginal_Text = _dataProvider.GetParameter();
                paramUpdOriginal_Text.ParameterName = "Original_Text";
                paramUpdOriginal_Text.DbType = DbType.String;
                paramUpdOriginal_Text.Value = (object)entity.Original_Text ?? DBNull.Value;
                var paramUpdTranslated_Text = _dataProvider.GetParameter();
                paramUpdTranslated_Text.ParameterName = "Translated_Text";
                paramUpdTranslated_Text.DbType = DbType.String;
                paramUpdTranslated_Text.Value = (object)entity.Translated_Text ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Traduction_Detail>("sp_UpdSpartan_Traduction_Detail" , paramUpdIdTraductionDetail , paramUpdSpartan_Traduction_Process , paramUpdConcept , paramUpdIdConcept , paramUpdOriginal_Text , paramUpdTranslated_Text ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdTraductionDetail);
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

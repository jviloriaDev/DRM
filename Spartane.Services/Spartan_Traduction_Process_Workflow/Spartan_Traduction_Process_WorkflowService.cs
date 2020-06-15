using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Traduction_Process_Workflow;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Process_Workflow
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_Process_WorkflowService : ISpartan_Traduction_Process_WorkflowService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> _Spartan_Traduction_Process_WorkflowRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_Process_WorkflowService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> Spartan_Traduction_Process_WorkflowRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_Process_WorkflowRepository = Spartan_Traduction_Process_WorkflowRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Traduction_Process_WorkflowRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow>("sp_SelAllSpartan_Traduction_Process_Workflow");
        }

        public IList<Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Traduction_Process_Workflow_Complete>("sp_SelAllComplete_Spartan_Traduction_Process_Workflow");
            return data.Select(m => new Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow
            {
                Clave = m.Clave
                ,Concept_Spartan_Traduction_Concept_Type = new Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type() { IdConcept = m.Concept.GetValueOrDefault(), Concept_Description = m.Concept_Concept_Description }
                ,ID_of_Step = m.ID_of_Step
                ,Original_Text = m.Original_Text
                ,Translated_Text = m.Translated_Text
                ,Process = m.Process


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Traduction_Process_Workflow>("sp_ListSelCount_Spartan_Traduction_Process_Workflow", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Process_Workflow>("sp_ListSelAll_Spartan_Traduction_Process_Workflow", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow
                {
                    Clave = m.Spartan_Traduction_Process_Workflow_Clave,
                    Concept = m.Spartan_Traduction_Process_Workflow_Concept,
                    ID_of_Step = m.Spartan_Traduction_Process_Workflow_ID_of_Step,
                    Original_Text = m.Spartan_Traduction_Process_Workflow_Original_Text,
                    Translated_Text = m.Spartan_Traduction_Process_Workflow_Translated_Text,
                    Process = m.Spartan_Traduction_Process_Workflow_Process,

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

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_Process_WorkflowRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_Process_WorkflowRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_WorkflowPagingModel ListaSelAll(int object_id, int process)
        {
            var padObject = _dataProvider.GetParameter();
            padObject.ParameterName = "objectId";
            padObject.DbType = DbType.Int32;
            padObject.Value = object_id;

            var padProcess = _dataProvider.GetParameter();
            padProcess.ParameterName = "process";
            padProcess.DbType = DbType.Int32;
            padProcess.Value = process;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Process_Workflow>("sp_ListSelAll_Spartan_Traduction_Process_Workflow", padObject, padProcess);

            Spartan_Traduction_Process_WorkflowPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Traduction_Process_WorkflowPagingModel
                {
                    Spartan_Traduction_Process_Workflows =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow
                {
                    Clave = m.Spartan_Traduction_Process_Workflow_Clave
                    ,Concept = m.Spartan_Traduction_Process_Workflow_Concept
                    ,Concept_Spartan_Traduction_Concept_Type = new Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type() { IdConcept = m.Spartan_Traduction_Process_Workflow_Concept.GetValueOrDefault(), Concept_Description = m.Spartan_Traduction_Process_Workflow_Concept_Concept_Description }
                    ,ID_of_Step = m.Spartan_Traduction_Process_Workflow_ID_of_Step
                    ,Original_Text = m.Spartan_Traduction_Process_Workflow_Original_Text
                    ,Translated_Text = m.Spartan_Traduction_Process_Workflow_Translated_Text
                    ,Process = m.Spartan_Traduction_Process_Workflow_Process

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_Process_WorkflowRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow>("sp_GetSpartan_Traduction_Process_Workflow", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Traduction_Process_Workflow>("sp_DelSpartan_Traduction_Process_Workflow", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreConcept = _dataProvider.GetParameter();
                padreConcept.ParameterName = "Concept";
                padreConcept.DbType = DbType.Int32;
                padreConcept.Value = (object)entity.Concept ?? DBNull.Value;

                var padreID_of_Step = _dataProvider.GetParameter();
                padreID_of_Step.ParameterName = "ID_of_Step";
                padreID_of_Step.DbType = DbType.Int32;
                padreID_of_Step.Value = (object)entity.ID_of_Step ?? DBNull.Value;

                var padreOriginal_Text = _dataProvider.GetParameter();
                padreOriginal_Text.ParameterName = "Original_Text";
                padreOriginal_Text.DbType = DbType.String;
                padreOriginal_Text.Value = (object)entity.Original_Text ?? DBNull.Value;
                var padreTranslated_Text = _dataProvider.GetParameter();
                padreTranslated_Text.ParameterName = "Translated_Text";
                padreTranslated_Text.DbType = DbType.String;
                padreTranslated_Text.Value = (object)entity.Translated_Text ?? DBNull.Value;
                var padreProcess = _dataProvider.GetParameter();
                padreProcess.ParameterName = "Process";
                padreProcess.DbType = DbType.Int32;
                padreProcess.Value = (object)entity.Process ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Traduction_Process_Workflow>("sp_InsSpartan_Traduction_Process_Workflow" 
, padreConcept
, padreID_of_Step
, padreOriginal_Text
, padreTranslated_Text
, padreProcess
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

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

        public int Update(Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdConcept = _dataProvider.GetParameter();
                paramUpdConcept.ParameterName = "Concept";
                paramUpdConcept.DbType = DbType.Int32;
                paramUpdConcept.Value = (object)entity.Concept ?? DBNull.Value;

                var paramUpdID_of_Step = _dataProvider.GetParameter();
                paramUpdID_of_Step.ParameterName = "ID_of_Step";
                paramUpdID_of_Step.DbType = DbType.Int32;
                paramUpdID_of_Step.Value = (object)entity.ID_of_Step ?? DBNull.Value;

                var paramUpdOriginal_Text = _dataProvider.GetParameter();
                paramUpdOriginal_Text.ParameterName = "Original_Text";
                paramUpdOriginal_Text.DbType = DbType.String;
                paramUpdOriginal_Text.Value = (object)entity.Original_Text ?? DBNull.Value;
                var paramUpdTranslated_Text = _dataProvider.GetParameter();
                paramUpdTranslated_Text.ParameterName = "Translated_Text";
                paramUpdTranslated_Text.DbType = DbType.String;
                paramUpdTranslated_Text.Value = (object)entity.Translated_Text ?? DBNull.Value;
                var paramUpdProcess = _dataProvider.GetParameter();
                paramUpdProcess.ParameterName = "Process";
                paramUpdProcess.DbType = DbType.Int32;
                paramUpdProcess.Value = (object)entity.Process ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Traduction_Process_Workflow>("sp_UpdSpartan_Traduction_Process_Workflow" , paramUpdClave , paramUpdConcept , paramUpdID_of_Step , paramUpdOriginal_Text , paramUpdTranslated_Text , paramUpdProcess ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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

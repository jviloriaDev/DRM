using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Traduction_Process_Data;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Process_Data
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_Process_DataService : ISpartan_Traduction_Process_DataService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> _Spartan_Traduction_Process_DataRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_Process_DataService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> Spartan_Traduction_Process_DataRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_Process_DataRepository = Spartan_Traduction_Process_DataRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Traduction_Process_DataRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>("sp_SelAllSpartan_Traduction_Process_Data");
        }

        public IList<Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Traduction_Process_Data_Complete>("sp_SelAllComplete_Spartan_Traduction_Process_Data");
            return data.Select(m => new Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data
            {
                Clave = m.Clave
                ,Concept_Spartan_Traduction_Concept_Type = new Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type() { IdConcept = m.Concept.GetValueOrDefault(), Concept_Description = m.Concept_Concept_Description }
                ,Name_of_Control = m.Name_of_Control
                ,Original_Text = m.Original_Text
                ,Translated_Text = m.Translated_Text
                ,Spartan_Traduction_Process = m.Spartan_Traduction_Process


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Traduction_Process_Data>("sp_ListSelCount_Spartan_Traduction_Process_Data", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Process_Data>("sp_ListSelAll_Spartan_Traduction_Process_Data", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data
                {
                    Clave = m.Spartan_Traduction_Process_Data_Clave,
                    Concept = m.Spartan_Traduction_Process_Data_Concept,
                    Name_of_Control = m.Spartan_Traduction_Process_Data_Name_of_Control,
                    Original_Text = m.Spartan_Traduction_Process_Data_Original_Text,
                    Translated_Text = m.Spartan_Traduction_Process_Data_Translated_Text,
                    Spartan_Traduction_Process = m.Spartan_Traduction_Process_Data_Spartan_Traduction_Process,

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

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_Process_DataRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_Process_DataRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel ListaSelAll(int object_id, int process)
        {
            var padObject = _dataProvider.GetParameter();
            padObject.ParameterName = "objectId";
            padObject.DbType = DbType.Int32;
            padObject.Value = object_id;

            var padProcess = _dataProvider.GetParameter();
            padProcess.ParameterName = "process";
            padProcess.DbType = DbType.Int32;
            padProcess.Value = process;


            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Process_Data>("sp_ListSelAll_Spartan_Traduction_Process_Data", padObject, padProcess);

            Spartan_Traduction_Process_DataPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Traduction_Process_DataPagingModel
                {
                    Spartan_Traduction_Process_Datas =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data
                {
                    Clave = m.Spartan_Traduction_Process_Data_Clave
                    ,Concept = m.Spartan_Traduction_Process_Data_Concept
                    ,Concept_Spartan_Traduction_Concept_Type = new Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type() { IdConcept = m.Spartan_Traduction_Process_Data_Concept.GetValueOrDefault(), Concept_Description = m.Spartan_Traduction_Process_Data_Concept_Concept_Description }
                    ,Name_of_Control = m.Spartan_Traduction_Process_Data_Name_of_Control
                    ,Original_Text = m.Spartan_Traduction_Process_Data_Original_Text
                    ,Translated_Text = m.Spartan_Traduction_Process_Data_Translated_Text
                    ,Spartan_Traduction_Process = m.Spartan_Traduction_Process_Data_Spartan_Traduction_Process

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_Process_DataRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>("sp_GetSpartan_Traduction_Process_Data", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Traduction_Process_Data>("sp_DelSpartan_Traduction_Process_Data", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data entity)
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

                var padreName_of_Control = _dataProvider.GetParameter();
                padreName_of_Control.ParameterName = "Name_of_Control";
                padreName_of_Control.DbType = DbType.String;
                padreName_of_Control.Value = (object)entity.Name_of_Control ?? DBNull.Value;
                var padreOriginal_Text = _dataProvider.GetParameter();
                padreOriginal_Text.ParameterName = "Original_Text";
                padreOriginal_Text.DbType = DbType.String;
                padreOriginal_Text.Value = (object)entity.Original_Text ?? DBNull.Value;
                var padreTranslated_Text = _dataProvider.GetParameter();
                padreTranslated_Text.ParameterName = "Translated_Text";
                padreTranslated_Text.DbType = DbType.String;
                padreTranslated_Text.Value = (object)entity.Translated_Text ?? DBNull.Value;
                var padreSpartan_Traduction_Process = _dataProvider.GetParameter();
                padreSpartan_Traduction_Process.ParameterName = "Spartan_Traduction_Process";
                padreSpartan_Traduction_Process.DbType = DbType.Int32;
                padreSpartan_Traduction_Process.Value = (object)entity.Spartan_Traduction_Process ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Traduction_Process_Data>("sp_InsSpartan_Traduction_Process_Data" 
, padreConcept
, padreName_of_Control
, padreOriginal_Text
, padreTranslated_Text
, padreSpartan_Traduction_Process
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

        public int Update(Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data entity)
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

                var paramUpdName_of_Control = _dataProvider.GetParameter();
                paramUpdName_of_Control.ParameterName = "Name_of_Control";
                paramUpdName_of_Control.DbType = DbType.String;
                paramUpdName_of_Control.Value = (object)entity.Name_of_Control ?? DBNull.Value;
                var paramUpdOriginal_Text = _dataProvider.GetParameter();
                paramUpdOriginal_Text.ParameterName = "Original_Text";
                paramUpdOriginal_Text.DbType = DbType.String;
                paramUpdOriginal_Text.Value = (object)entity.Original_Text ?? DBNull.Value;
                var paramUpdTranslated_Text = _dataProvider.GetParameter();
                paramUpdTranslated_Text.ParameterName = "Translated_Text";
                paramUpdTranslated_Text.DbType = DbType.String;
                paramUpdTranslated_Text.Value = (object)entity.Translated_Text ?? DBNull.Value;
                var paramUpdSpartan_Traduction_Process = _dataProvider.GetParameter();
                paramUpdSpartan_Traduction_Process.ParameterName = "Spartan_Traduction_Process";
                paramUpdSpartan_Traduction_Process.DbType = DbType.Int32;
                paramUpdSpartan_Traduction_Process.Value = (object)entity.Spartan_Traduction_Process ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Traduction_Process_Data>("sp_UpdSpartan_Traduction_Process_Data" , paramUpdClave , paramUpdConcept , paramUpdName_of_Control , paramUpdOriginal_Text , paramUpdTranslated_Text , paramUpdSpartan_Traduction_Process ).FirstOrDefault();

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

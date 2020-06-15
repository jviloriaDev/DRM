using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Traduction_Process;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Process
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_ProcessService : ISpartan_Traduction_ProcessService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> _Spartan_Traduction_ProcessRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_ProcessService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> Spartan_Traduction_ProcessRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_ProcessRepository = Spartan_Traduction_ProcessRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Traduction_ProcessRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process>("sp_SelAllSpartan_Traduction_Process");
        }

        public IList<Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Traduction_Process_Complete>("sp_SelAllComplete_Spartan_Traduction_Process");
            return data.Select(m => new Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process
            {
                IdTraduction = m.IdTraduction
                ,LanguageT_Spartan_Traduction_Language = new Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language() { IdLanguage = m.LanguageT.GetValueOrDefault(), LanguageT = m.LanguageT_LanguageT }
                ,Object_Type_Spartan_Traduction_Object_Type = new Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type() { IdType = m.Object_Type.GetValueOrDefault(), Object_Type_Description = m.Object_Type_Object_Type_Description }
                ,ObjectT_SpartanObject = new Core.Classes.SpartanObject.SpartanObject() { Object_Id = m.ObjectT.GetValueOrDefault(), Name = m.ObjectT_Name }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Traduction_Process>("sp_ListSelCount_Spartan_Traduction_Process", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Process>("sp_ListSelAll_Spartan_Traduction_Process", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process
                {
                    IdTraduction = m.Spartan_Traduction_Process_IdTraduction,
                    LanguageT = m.Spartan_Traduction_Process_LanguageT,
                    Object_Type = m.Spartan_Traduction_Process_Object_Type,
                    ObjectT = m.Spartan_Traduction_Process_ObjectT,

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

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_ProcessRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_ProcessRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_ProcessPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Traduction_Process>("sp_ListSelAll_Spartan_Traduction_Process", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Traduction_ProcessPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Traduction_ProcessPagingModel
                {
                    Spartan_Traduction_Processs =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process
                {
                    IdTraduction = m.Spartan_Traduction_Process_IdTraduction
                    ,LanguageT = m.Spartan_Traduction_Process_LanguageT
                    ,LanguageT_Spartan_Traduction_Language = new Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language() { IdLanguage = m.Spartan_Traduction_Process_LanguageT.GetValueOrDefault(), LanguageT = m.Spartan_Traduction_Process_LanguageT_LanguageT }
                    ,Object_Type = m.Spartan_Traduction_Process_Object_Type
                    ,Object_Type_Spartan_Traduction_Object_Type = new Core.Classes.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type() { IdType = m.Spartan_Traduction_Process_Object_Type.GetValueOrDefault(), Object_Type_Description = m.Spartan_Traduction_Process_Object_Type_Object_Type_Description }
                    ,ObjectT = m.Spartan_Traduction_Process_ObjectT
                    ,ObjectT_SpartanObject = new Core.Classes.SpartanObject.SpartanObject() { Object_Id = m.Spartan_Traduction_Process_ObjectT.GetValueOrDefault(), Name = m.Spartan_Traduction_Process_ObjectT_Name }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_ProcessRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "IdTraduction";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process>("sp_GetSpartan_Traduction_Process", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "IdTraduction";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Traduction_Process>("sp_DelSpartan_Traduction_Process", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process entity)
        {
            int rta;
            try
            {

		var padreIdTraduction = _dataProvider.GetParameter();
                padreIdTraduction.ParameterName = "IdTraduction";
                padreIdTraduction.DbType = DbType.Int32;
                padreIdTraduction.Value = (object)entity.IdTraduction ?? DBNull.Value;
                var padreLanguageT = _dataProvider.GetParameter();
                padreLanguageT.ParameterName = "LanguageT";
                padreLanguageT.DbType = DbType.Int32;
                padreLanguageT.Value = (object)entity.LanguageT ?? DBNull.Value;

                var padreObject_Type = _dataProvider.GetParameter();
                padreObject_Type.ParameterName = "Object_Type";
                padreObject_Type.DbType = DbType.Int32;
                padreObject_Type.Value = (object)entity.Object_Type ?? DBNull.Value;

                var padreObjectT = _dataProvider.GetParameter();
                padreObjectT.ParameterName = "ObjectT";
                padreObjectT.DbType = DbType.Int32;
                padreObjectT.Value = (object)entity.ObjectT ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Traduction_Process>("sp_InsSpartan_Traduction_Process" 

, padreLanguageT
, padreObject_Type
, padreObjectT


).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdTraduction);

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

        public int Update(Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process entity)
        {
            int rta;
            try
            {

                var paramUpdIdTraduction = _dataProvider.GetParameter();
                paramUpdIdTraduction.ParameterName = "IdTraduction";
                paramUpdIdTraduction.DbType = DbType.Int32;
                paramUpdIdTraduction.Value = (object)entity.IdTraduction ?? DBNull.Value;
                var paramUpdLanguageT = _dataProvider.GetParameter();
                paramUpdLanguageT.ParameterName = "LanguageT";
                paramUpdLanguageT.DbType = DbType.Int32;
                paramUpdLanguageT.Value = (object)entity.LanguageT ?? DBNull.Value;

                var paramUpdObject_Type = _dataProvider.GetParameter();
                paramUpdObject_Type.ParameterName = "Object_Type";
                paramUpdObject_Type.DbType = DbType.Int32;
                paramUpdObject_Type.Value = (object)entity.Object_Type ?? DBNull.Value;

                var paramUpdObjectT = _dataProvider.GetParameter();
                paramUpdObjectT.ParameterName = "ObjectT";
                paramUpdObjectT.DbType = DbType.Int32;
                paramUpdObjectT.Value = (object)entity.ObjectT ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Traduction_Process>("sp_UpdSpartan_Traduction_Process" , paramUpdIdTraduction  , paramUpdLanguageT , paramUpdObject_Type , paramUpdObjectT   ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.IdTraduction);
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

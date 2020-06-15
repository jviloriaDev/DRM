using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Function_Event;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Function_Event
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Function_EventService : ISpartan_Function_EventService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> _Spartan_Function_EventRepository;
        #endregion

        #region Ctor
        public Spartan_Function_EventService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> Spartan_Function_EventRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Function_EventRepository = Spartan_Function_EventRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Function_EventRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event>("sp_SelAllSpartan_Function_Event");
        }

        public IList<Core.Classes.Spartan_Function_Event.Spartan_Function_Event> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Function_Event_Complete>("sp_SelAllComplete_Spartan_Function_Event");
            return data.Select(m => new Core.Classes.Spartan_Function_Event.Spartan_Function_Event
            {
                Function_Event_Id = m.Function_Event_Id
                ,Event_Type_Id_Spartan_Event_Type = new Core.Classes.Spartan_Event_Type.Spartan_Event_Type() { Event_Type_Id = m.Event_Type_Id.GetValueOrDefault(), Description = m.Event_Type_Id_Description }
                ,Spartan_Function = m.Spartan_Function


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Function_Event>("sp_ListSelCount_Spartan_Function_Event", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function_Event>("sp_ListSelAll_Spartan_Function_Event", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event
                {
                    Function_Event_Id = m.Spartan_Function_Event_Function_Event_Id,
                    Event_Type_Id = m.Spartan_Function_Event_Event_Type_Id,
                    Spartan_Function = m.Spartan_Function_Event_Spartan_Function,

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

        public IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Function_EventRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Function_EventRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_EventPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function_Event>("sp_ListSelAll_Spartan_Function_Event", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Function_EventPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Function_EventPagingModel
                {
                    Spartan_Function_Events =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event
                {
                    Function_Event_Id = m.Spartan_Function_Event_Function_Event_Id
                    ,Event_Type_Id = m.Spartan_Function_Event_Event_Type_Id
                    ,Event_Type_Id_Spartan_Event_Type = new Core.Classes.Spartan_Event_Type.Spartan_Event_Type() { Event_Type_Id = m.Spartan_Function_Event_Event_Type_Id.GetValueOrDefault(), Description = m.Spartan_Function_Event_Event_Type_Id_Description }
                    ,Spartan_Function = m.Spartan_Function_Event_Spartan_Function

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Function_EventRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Function_Event_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event>("sp_GetSpartan_Function_Event", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Function_Event_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Function_Event>("sp_DelSpartan_Function_Event", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event entity)
        {
            short rta;
            try
            {

		                var padreEvent_Type_Id = _dataProvider.GetParameter();
                padreEvent_Type_Id.ParameterName = "Event_Type_Id";
                padreEvent_Type_Id.DbType = DbType.Int16;
                if (entity.Event_Type_Id == null)
                    padreEvent_Type_Id.Value = DBNull.Value;
                else
                    padreEvent_Type_Id.Value = entity.Event_Type_Id;

                var padreSpartan_Function = _dataProvider.GetParameter();
                padreSpartan_Function.ParameterName = "Spartan_Function";
                padreSpartan_Function.DbType = DbType.Int16;
                padreSpartan_Function.Value = entity.Spartan_Function;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Function_Event>("sp_InsSpartan_Function_Event" , padreEvent_Type_Id 
, padreSpartan_Function 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Event_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event entity)
        {
            short rta;
            try
            {

                var padreFunction_Event_Id = _dataProvider.GetParameter();
                padreFunction_Event_Id.ParameterName = "Function_Event_Id";
                padreFunction_Event_Id.DbType = DbType.Int16;
                padreFunction_Event_Id.Value = entity.Function_Event_Id;
                var padreEvent_Type_Id = _dataProvider.GetParameter();
                padreEvent_Type_Id.ParameterName = "Event_Type_Id";
                padreEvent_Type_Id.DbType = DbType.Int16;
                if (entity.Event_Type_Id == null)
                    padreEvent_Type_Id.Value = DBNull.Value;
                else
                    padreEvent_Type_Id.Value = entity.Event_Type_Id;

                var padreSpartan_Function = _dataProvider.GetParameter();
                padreSpartan_Function.ParameterName = "Spartan_Function";
                padreSpartan_Function.DbType = DbType.Int16;
                padreSpartan_Function.Value = entity.Spartan_Function;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Function_Event>("sp_UpdSpartan_Function_Event" , padreFunction_Event_Id  , padreEvent_Type_Id  , padreSpartan_Function  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Event_Id);
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


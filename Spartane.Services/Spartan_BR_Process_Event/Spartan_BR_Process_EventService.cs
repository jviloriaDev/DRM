using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Process_Event;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Process_Event
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Process_EventService : ISpartan_BR_Process_EventService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> _Spartan_BR_Process_EventRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Process_EventService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> Spartan_BR_Process_EventRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Process_EventRepository = Spartan_BR_Process_EventRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Process_EventRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event>("sp_SelAllSpartan_BR_Process_Event");
        }

        public IList<Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Process_Event_Complete>("sp_SelAllComplete_Spartan_BR_Process_Event");
            return data.Select(m => new Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event
            {
                ProcessEventId = m.ProcessEventId
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Process_Event>("sp_ListSelCount_Spartan_BR_Process_Event", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Process_Event>("sp_ListSelAll_Spartan_BR_Process_Event", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event
                {
                    ProcessEventId = m.Spartan_BR_Process_Event_ProcessEventId,
                    Description = m.Spartan_BR_Process_Event_Description,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Process_EventRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Process_EventRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_EventPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Process_Event>("sp_ListSelAll_Spartan_BR_Process_Event", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Process_EventPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Process_EventPagingModel
                {
                    Spartan_BR_Process_Events =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event
                {
                    ProcessEventId = m.Spartan_BR_Process_Event_ProcessEventId
                    ,Description = m.Spartan_BR_Process_Event_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Process_EventRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ProcessEventId";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event>("sp_GetSpartan_BR_Process_Event", padreKey).SingleOrDefault();
        }

        public bool Delete(short Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ProcessEventId";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Process_Event>("sp_DelSpartan_BR_Process_Event", padreKey).FirstOrDefault();
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

        public short Insert(Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Process_Event>("sp_InsSpartan_BR_Process_Event" , padreDescription
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.ProcessEventId);

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

        public short Update(Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event entity)
        {
            short rta;
            try
            {

                var paramUpdProcessEventId = _dataProvider.GetParameter();
                paramUpdProcessEventId.ParameterName = "ProcessEventId";
                paramUpdProcessEventId.DbType = DbType.Int16;
                paramUpdProcessEventId.Value = entity.ProcessEventId;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Process_Event>("sp_UpdSpartan_BR_Process_Event" , paramUpdProcessEventId , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.ProcessEventId);
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


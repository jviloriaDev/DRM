using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Notice;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Notice
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_NoticeService : ISpartan_NoticeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> _Spartan_NoticeRepository;
        #endregion

        #region Ctor
        public Spartan_NoticeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> Spartan_NoticeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_NoticeRepository = Spartan_NoticeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_NoticeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice>("sp_SelAllSpartan_Notice");
        }

        public IList<Core.Classes.Spartan_Notice.Spartan_Notice> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Notice_Complete>("sp_SelAllComplete_Spartan_Notice");
            return data.Select(m => new Core.Classes.Spartan_Notice.Spartan_Notice
            {
                Notice_Id = m.Notice_Id
                ,Description = m.Description
                ,Notice_Type_Spartan_Notice_Type = new Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type() { Notice_Type_Id = m.Notice_Type.GetValueOrDefault(), Description = m.Notice_Type_Description }
                ,Start_Date = m.Start_Date
                ,End_Date = m.End_Date
                ,Status_Spartan_Notice_Status = new Core.Classes.Spartan_Notice_Status.Spartan_Notice_Status() { Notice_Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Notice>("sp_ListSelCount_Spartan_Notice", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Notice>("sp_ListSelAll_Spartan_Notice", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Notice.Spartan_Notice
                {
                    Notice_Id = m.Spartan_Notice_Notice_Id,
                    Description = m.Spartan_Notice_Description,
                    Notice_Type = m.Spartan_Notice_Notice_Type,
                    Start_Date = m.Spartan_Notice_Start_Date,
                    End_Date = m.Spartan_Notice_End_Date,
                    Status = m.Spartan_Notice_Status,

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

        public IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_NoticeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_NoticeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Notice.Spartan_NoticePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Notice>("sp_ListSelAll_Spartan_Notice", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_NoticePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_NoticePagingModel
                {
                    Spartan_Notices =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Notice.Spartan_Notice
                {
                    Notice_Id = m.Spartan_Notice_Notice_Id
                    ,Description = m.Spartan_Notice_Description
                    ,Notice_Type = m.Spartan_Notice_Notice_Type
                    ,Notice_Type_Spartan_Notice_Type = new Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type() { Notice_Type_Id = m.Spartan_Notice_Notice_Type.GetValueOrDefault(), Description = m.Spartan_Notice_Notice_Type_Description }
                    ,Start_Date = m.Spartan_Notice_Start_Date
                    ,End_Date = m.Spartan_Notice_End_Date
                    ,Status = m.Spartan_Notice_Status
                    ,Status_Spartan_Notice_Status = new Core.Classes.Spartan_Notice_Status.Spartan_Notice_Status() { Notice_Status_Id = m.Spartan_Notice_Status.GetValueOrDefault(), Description = m.Spartan_Notice_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_NoticeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Notice.Spartan_Notice GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Notice_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice>("sp_GetSpartan_Notice", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Notice_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Notice>("sp_DelSpartan_Notice", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Notice.Spartan_Notice entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreNotice_Type = _dataProvider.GetParameter();
                padreNotice_Type.ParameterName = "Notice_Type";
                padreNotice_Type.DbType = DbType.Int32;
                if (entity.Notice_Type == null)
                    padreNotice_Type.Value = DBNull.Value;
                else
                    padreNotice_Type.Value = entity.Notice_Type;

                var padreStart_Date = _dataProvider.GetParameter();
                padreStart_Date.ParameterName = "Start_Date";
                padreStart_Date.DbType = DbType.DateTime;
                if (entity.Start_Date == null)
                    padreStart_Date.Value = DBNull.Value;
                else
                    padreStart_Date.Value = entity.Start_Date;

                var padreEnd_Date = _dataProvider.GetParameter();
                padreEnd_Date.ParameterName = "End_Date";
                padreEnd_Date.DbType = DbType.DateTime;
                if (entity.End_Date == null)
                    padreEnd_Date.Value = DBNull.Value;
                else
                    padreEnd_Date.Value = entity.End_Date;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Notice>("sp_InsSpartan_Notice" , padreDescription 
, padreNotice_Type 
, padreStart_Date 
, padreEnd_Date 
, padreStatus 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Notice_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Notice.Spartan_Notice entity)
        {
            int rta;
            try
            {

                var padreNotice_Id = _dataProvider.GetParameter();
                padreNotice_Id.ParameterName = "Notice_Id";
                padreNotice_Id.DbType = DbType.Int32;
                padreNotice_Id.Value = entity.Notice_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreNotice_Type = _dataProvider.GetParameter();
                padreNotice_Type.ParameterName = "Notice_Type";
                padreNotice_Type.DbType = DbType.Int32;
                if (entity.Notice_Type == null)
                    padreNotice_Type.Value = DBNull.Value;
                else
                    padreNotice_Type.Value = entity.Notice_Type;

                var padreStart_Date = _dataProvider.GetParameter();
                padreStart_Date.ParameterName = "Start_Date";
                padreStart_Date.DbType = DbType.DateTime;
                if (entity.Start_Date == null)
                    padreStart_Date.Value = DBNull.Value;
                else
                    padreStart_Date.Value = entity.Start_Date;

                var padreEnd_Date = _dataProvider.GetParameter();
                padreEnd_Date.ParameterName = "End_Date";
                padreEnd_Date.DbType = DbType.DateTime;
                if (entity.End_Date == null)
                    padreEnd_Date.Value = DBNull.Value;
                else
                    padreEnd_Date.Value = entity.End_Date;

                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                if (entity.Status == null)
                    padreStatus.Value = DBNull.Value;
                else
                    padreStatus.Value = entity.Status;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Notice>("sp_UpdSpartan_Notice" , padreNotice_Id  , padreDescription  , padreNotice_Type  , padreStart_Date  , padreEnd_Date  , padreStatus  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Notice_Id);
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


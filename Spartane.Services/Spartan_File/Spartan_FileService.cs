using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartane_File;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_File
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_FileService : ISpartan_FileService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartane_File.Spartane_File> _Spartan_FileRepository;
        #endregion

        #region Ctor
        public Spartan_FileService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartane_File.Spartane_File> Spartan_FileRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_FileRepository = Spartan_FileRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_FileRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartane_File.Spartane_File> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartane_File.Spartane_File>("sp_SelAllSpartan_File");
        }

        public IList<Core.Classes.Spartane_File.Spartane_File> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_File_Complete>("sp_SelAllComplete_Spartan_File");
            return data.Select(m => new Core.Classes.Spartane_File.Spartane_File
            {
                File_Id = m.File_Id
                ,Description = m.Description
                ,File1_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.File1.GetValueOrDefault(), Nombre = m.File1_Nombre }
                ,File_Size = m.File_Size
                ,Object = m.Object
                ,User_Id = m.User_Id
                ,Date_Time = m.Date_Time


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_File>("sp_ListSelCount_Spartan_File", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartane_File.Spartane_File> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_File>("sp_ListSelAll_Spartan_File", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartane_File.Spartane_File
                {
                    File_Id = m.Spartan_File_File_Id,
                    Description = m.Spartan_File_Description,
                    File1 = m.Spartan_File_File1,
                    File_Size = m.Spartan_File_File_Size,
                    Object = m.Spartan_File_Object,
                    User_Id = m.Spartan_File_User_Id,
                    Date_Time = m.Spartan_File_Date_Time,

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

        public IList<Spartane.Core.Classes.Spartane_File.Spartane_File> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_FileRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartane_File.Spartane_File> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_FileRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartane_File.Spartane_FilePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_File>("sp_ListSelAll_Spartan_File", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartane_FilePagingModel result = null;

            if (data != null)
            {
                result = new Spartane_FilePagingModel
                {
                    Spartane_Files =
                        data.Select(m => new Spartane.Core.Classes.Spartane_File.Spartane_File
                {
                    File_Id = m.Spartan_File_File_Id
                    ,Description = m.Spartan_File_Description
                    ,File1 = m.Spartan_File_File1
                    ,File1_TTArchivos = new Core.Classes.TTArchivos.TTArchivos() { Folio = m.Spartan_File_File1.GetValueOrDefault(), Nombre = m.Spartan_File_File1_Nombre }
                    ,File_Size = m.Spartan_File_File_Size
                    ,Object = m.Spartan_File_Object
                    ,User_Id = m.Spartan_File_User_Id
                    ,Date_Time = m.Spartan_File_Date_Time

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartane_File.Spartane_File> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_FileRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartane_File.Spartane_File GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "File_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartane_File.Spartane_File>("sp_GetSpartan_File", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "File_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_File>("sp_DelSpartan_File", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartane_File.Spartane_File entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreFile1 = _dataProvider.GetParameter();
                padreFile1.ParameterName = "File1";
                padreFile1.DbType = DbType.Int32;
                if (entity.File1 == null)
                    padreFile1.Value = DBNull.Value;
                else
                    padreFile1.Value = entity.File1;

                var padreFile_Size = _dataProvider.GetParameter();
                padreFile_Size.ParameterName = "File_Size";
                padreFile_Size.DbType = DbType.Int32;
                if (entity.File_Size == null)
                    padreFile_Size.Value = DBNull.Value;
                else
                    padreFile_Size.Value = entity.File_Size;

                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                if (entity.Object == null)
                    padreObject.Value = DBNull.Value;
                else
                    padreObject.Value = entity.Object;

                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreDate_Time = _dataProvider.GetParameter();
                padreDate_Time.ParameterName = "Date_Time";
                padreDate_Time.DbType = DbType.DateTime;
                if (entity.Date_Time == null)
                    padreDate_Time.Value = DBNull.Value;
                else
                    padreDate_Time.Value = entity.Date_Time;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_File>("sp_InsSpartan_File" , padreDescription 
, padreFile1 
, padreFile_Size 
, padreObject 
, padreUser_Id 
, padreDate_Time 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.File_Id);

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

        public int Update(Spartane.Core.Classes.Spartane_File.Spartane_File entity)
        {
            int rta;
            try
            {

                var padreFile_Id = _dataProvider.GetParameter();
                padreFile_Id.ParameterName = "File_Id";
                padreFile_Id.DbType = DbType.Int32;
                padreFile_Id.Value = entity.File_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreFile1 = _dataProvider.GetParameter();
                padreFile1.ParameterName = "File1";
                padreFile1.DbType = DbType.Int32;
                if (entity.File1 == null)
                    padreFile1.Value = DBNull.Value;
                else
                    padreFile1.Value = entity.File1;

                var padreFile_Size = _dataProvider.GetParameter();
                padreFile_Size.ParameterName = "File_Size";
                padreFile_Size.DbType = DbType.Int32;
                if (entity.File_Size == null)
                    padreFile_Size.Value = DBNull.Value;
                else
                    padreFile_Size.Value = entity.File_Size;

                var padreObject = _dataProvider.GetParameter();
                padreObject.ParameterName = "Object";
                padreObject.DbType = DbType.Int32;
                if (entity.Object == null)
                    padreObject.Value = DBNull.Value;
                else
                    padreObject.Value = entity.Object;

                var padreUser_Id = _dataProvider.GetParameter();
                padreUser_Id.ParameterName = "User_Id";
                padreUser_Id.DbType = DbType.Int32;
                if (entity.User_Id == null)
                    padreUser_Id.Value = DBNull.Value;
                else
                    padreUser_Id.Value = entity.User_Id;

                var padreDate_Time = _dataProvider.GetParameter();
                padreDate_Time.ParameterName = "Date_Time";
                padreDate_Time.DbType = DbType.DateTime;
                if (entity.Date_Time == null)
                    padreDate_Time.Value = DBNull.Value;
                else
                    padreDate_Time.Value = entity.Date_Time;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_File>("sp_UpdSpartan_File" , padreFile_Id  , padreDescription  , padreFile1  , padreFile_Size  , padreObject  , padreUser_Id  , padreDate_Time  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.File_Id);
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


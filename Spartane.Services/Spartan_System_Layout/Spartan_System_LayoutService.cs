using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_System_Layout;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_System_Layout
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_System_LayoutService : ISpartan_System_LayoutService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> _Spartan_System_LayoutRepository;
        #endregion

        #region Ctor
        public Spartan_System_LayoutService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> Spartan_System_LayoutRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_System_LayoutRepository = Spartan_System_LayoutRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_System_LayoutRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout>("sp_SelAllSpartan_System_Layout");
        }

        public IList<Core.Classes.Spartan_System_Layout.Spartan_System_Layout> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_System_Layout_Complete>("sp_SelAllComplete_Spartan_System_Layout");
            return data.Select(m => new Core.Classes.Spartan_System_Layout.Spartan_System_Layout
            {
                System_Layout_Id = m.System_Layout_Id
                ,System_Id_Spartan_System = new Core.Classes.Spartan_System.Spartan_System() { System_Id = m.System_Id.GetValueOrDefault(), Version = m.System_Id_Version }
                ,Menu_Style_Id_Spartan_Menu_Style = new Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style() { Menu_Style_Id = m.Menu_Style_Id.GetValueOrDefault(), Description = m.Menu_Style_Id_Description }
                ,Description = m.Description
                ,Layout_URL = m.Layout_URL
                ,Class_URL = m.Class_URL
                ,Orientation_Spartan_Menu_Orientation = new Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation() { System_Menu_Orientation_Id = m.Orientation.GetValueOrDefault(), Description = m.Orientation_Description }
                ,Layout_Status_Spartan_Layout_Status = new Core.Classes.Spartan_Layout_Status.Spartan_Layout_Status() { Layout_Status_Id = m.Layout_Status.GetValueOrDefault(), Description = m.Layout_Status_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_System_Layout>("sp_ListSelCount_Spartan_System_Layout", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_System_Layout>("sp_ListSelAll_Spartan_System_Layout", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout
                {
                    System_Layout_Id = m.Spartan_System_Layout_System_Layout_Id,
                    System_Id = m.Spartan_System_Layout_System_Id,
                    Menu_Style_Id = m.Spartan_System_Layout_Menu_Style_Id,
                    Description = m.Spartan_System_Layout_Description,
                    Layout_URL = m.Spartan_System_Layout_Layout_URL,
                    Class_URL = m.Spartan_System_Layout_Class_URL,
                    Orientation = m.Spartan_System_Layout_Orientation,
                    Layout_Status = m.Spartan_System_Layout_Layout_Status,

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

        public IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_System_LayoutRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_System_LayoutRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_LayoutPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_System_Layout>("sp_ListSelAll_Spartan_System_Layout", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_System_LayoutPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_System_LayoutPagingModel
                {
                    Spartan_System_Layouts =
                        data.Select(m => new Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout
                {
                    System_Layout_Id = m.Spartan_System_Layout_System_Layout_Id
                    ,System_Id = m.Spartan_System_Layout_System_Id
                    ,System_Id_Spartan_System = new Core.Classes.Spartan_System.Spartan_System() { System_Id = m.Spartan_System_Layout_System_Id.GetValueOrDefault(), Version = m.Spartan_System_Layout_System_Id_Version }
                    ,Menu_Style_Id = m.Spartan_System_Layout_Menu_Style_Id
                    ,Menu_Style_Id_Spartan_Menu_Style = new Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style() { Menu_Style_Id = m.Spartan_System_Layout_Menu_Style_Id.GetValueOrDefault(), Description = m.Spartan_System_Layout_Menu_Style_Id_Description }
                    ,Description = m.Spartan_System_Layout_Description
                    ,Layout_URL = m.Spartan_System_Layout_Layout_URL
                    ,Class_URL = m.Spartan_System_Layout_Class_URL
                    ,Orientation = m.Spartan_System_Layout_Orientation
                    ,Orientation_Spartan_Menu_Orientation = new Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation() { System_Menu_Orientation_Id = m.Spartan_System_Layout_Orientation.GetValueOrDefault(), Description = m.Spartan_System_Layout_Orientation_Description }
                    ,Layout_Status = m.Spartan_System_Layout_Layout_Status
                    ,Layout_Status_Spartan_Layout_Status = new Core.Classes.Spartan_Layout_Status.Spartan_Layout_Status() { Layout_Status_Id = m.Spartan_System_Layout_Layout_Status.GetValueOrDefault(), Description = m.Spartan_System_Layout_Layout_Status_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_System_LayoutRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "System_Layout_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout>("sp_GetSpartan_System_Layout", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "System_Layout_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_System_Layout>("sp_DelSpartan_System_Layout", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout entity)
        {
            int rta;
            try
            {

		                var padreSystem_Id = _dataProvider.GetParameter();
                padreSystem_Id.ParameterName = "System_Id";
                padreSystem_Id.DbType = DbType.Int16;
                if (entity.System_Id == null)
                    padreSystem_Id.Value = DBNull.Value;
                else
                    padreSystem_Id.Value = entity.System_Id;

                var padreMenu_Style_Id = _dataProvider.GetParameter();
                padreMenu_Style_Id.ParameterName = "Menu_Style_Id";
                padreMenu_Style_Id.DbType = DbType.Int16;
                if (entity.Menu_Style_Id == null)
                    padreMenu_Style_Id.Value = DBNull.Value;
                else
                    padreMenu_Style_Id.Value = entity.Menu_Style_Id;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreLayout_URL = _dataProvider.GetParameter();
                padreLayout_URL.ParameterName = "Layout_URL";
                padreLayout_URL.DbType = DbType.String;
                padreLayout_URL.Value = entity.Layout_URL;
                var padreClass_URL = _dataProvider.GetParameter();
                padreClass_URL.ParameterName = "Class_URL";
                padreClass_URL.DbType = DbType.String;
                padreClass_URL.Value = entity.Class_URL;
                var padreOrientation = _dataProvider.GetParameter();
                padreOrientation.ParameterName = "Orientation";
                padreOrientation.DbType = DbType.Int16;
                if (entity.Orientation == null)
                    padreOrientation.Value = DBNull.Value;
                else
                    padreOrientation.Value = entity.Orientation;

                var padreLayout_Status = _dataProvider.GetParameter();
                padreLayout_Status.ParameterName = "Layout_Status";
                padreLayout_Status.DbType = DbType.Int16;
                if (entity.Layout_Status == null)
                    padreLayout_Status.Value = DBNull.Value;
                else
                    padreLayout_Status.Value = entity.Layout_Status;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_System_Layout>("sp_InsSpartan_System_Layout" , padreSystem_Id 
, padreMenu_Style_Id 
, padreDescription 
, padreLayout_URL 
, padreClass_URL 
, padreOrientation 
, padreLayout_Status 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.System_Layout_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout entity)
        {
            int rta;
            try
            {

                var padreSystem_Layout_Id = _dataProvider.GetParameter();
                padreSystem_Layout_Id.ParameterName = "System_Layout_Id";
                padreSystem_Layout_Id.DbType = DbType.Int32;
                padreSystem_Layout_Id.Value = entity.System_Layout_Id;
                var padreSystem_Id = _dataProvider.GetParameter();
                padreSystem_Id.ParameterName = "System_Id";
                padreSystem_Id.DbType = DbType.Int16;
                if (entity.System_Id == null)
                    padreSystem_Id.Value = DBNull.Value;
                else
                    padreSystem_Id.Value = entity.System_Id;

                var padreMenu_Style_Id = _dataProvider.GetParameter();
                padreMenu_Style_Id.ParameterName = "Menu_Style_Id";
                padreMenu_Style_Id.DbType = DbType.Int16;
                if (entity.Menu_Style_Id == null)
                    padreMenu_Style_Id.Value = DBNull.Value;
                else
                    padreMenu_Style_Id.Value = entity.Menu_Style_Id;

                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreLayout_URL = _dataProvider.GetParameter();
                padreLayout_URL.ParameterName = "Layout_URL";
                padreLayout_URL.DbType = DbType.String;
                padreLayout_URL.Value = entity.Layout_URL;
                var padreClass_URL = _dataProvider.GetParameter();
                padreClass_URL.ParameterName = "Class_URL";
                padreClass_URL.DbType = DbType.String;
                padreClass_URL.Value = entity.Class_URL;
                var padreOrientation = _dataProvider.GetParameter();
                padreOrientation.ParameterName = "Orientation";
                padreOrientation.DbType = DbType.Int16;
                if (entity.Orientation == null)
                    padreOrientation.Value = DBNull.Value;
                else
                    padreOrientation.Value = entity.Orientation;

                var padreLayout_Status = _dataProvider.GetParameter();
                padreLayout_Status.ParameterName = "Layout_Status";
                padreLayout_Status.DbType = DbType.Int16;
                if (entity.Layout_Status == null)
                    padreLayout_Status.Value = DBNull.Value;
                else
                    padreLayout_Status.Value = entity.Layout_Status;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_System_Layout>("sp_UpdSpartan_System_Layout" , padreSystem_Layout_Id  , padreSystem_Id  , padreMenu_Style_Id  , padreDescription  , padreLayout_URL  , padreClass_URL  , padreOrientation  , padreLayout_Status  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.System_Layout_Id);
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


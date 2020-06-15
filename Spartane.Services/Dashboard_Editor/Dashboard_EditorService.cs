using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Dashboard_Editor;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Dashboard_Editor
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Dashboard_EditorService : IDashboard_EditorService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> _Dashboard_EditorRepository;
        #endregion

        #region Ctor
        public Dashboard_EditorService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> Dashboard_EditorRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Dashboard_EditorRepository = Dashboard_EditorRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Dashboard_EditorRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor>("sp_SelAllDashboard_Editor");
        }

        public IList<Core.Classes.Dashboard_Editor.Dashboard_Editor> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDashboard_Editor_Complete>("sp_SelAllComplete_Dashboard_Editor");
            return data.Select(m => new Core.Classes.Dashboard_Editor.Dashboard_Editor
            {
                Dashboard_Id = m.Dashboard_Id
                ,Registration_Date = m.Registration_Date
                ,Registration_User_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Registration_User.GetValueOrDefault(), Name = m.Registration_User_Name }
                ,Name = m.Name
                ,Dashboard_Template_Template_Dashboard_Editor = new Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor() { Template_Id = m.Dashboard_Template.GetValueOrDefault(), Description = m.Dashboard_Template_Description }
                ,Show_in_Home = m.Show_in_Home.GetValueOrDefault()
                ,Status_Dashboard_Status = new Core.Classes.Dashboard_Status.Dashboard_Status() { Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }
                ,Spartan_Object = m.Spartan_Object


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Dashboard_Editor>("sp_ListSelCount_Dashboard_Editor", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDashboard_Editor>("sp_ListSelAll_Dashboard_Editor", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor
                {
                    Dashboard_Id = m.Dashboard_Editor_Dashboard_Id,
                    Registration_Date = m.Dashboard_Editor_Registration_Date,
                    Registration_User = m.Dashboard_Editor_Registration_User,
                    Name = m.Dashboard_Editor_Name,
                    Dashboard_Template = m.Dashboard_Editor_Dashboard_Template,
                    Show_in_Home = m.Dashboard_Editor_Show_in_Home ?? false,
                    Status = m.Dashboard_Editor_Status,
                    Spartan_Object = m.Dashboard_Editor_Spartan_Object,

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

        public IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Dashboard_EditorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dashboard_EditorRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Dashboard_Editor.Dashboard_EditorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDashboard_Editor>("sp_ListSelAll_Dashboard_Editor", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Dashboard_EditorPagingModel result = null;

            if (data != null)
            {
                result = new Dashboard_EditorPagingModel
                {
                    Dashboard_Editors =
                        data.Select(m => new Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor
                {
                    Dashboard_Id = m.Dashboard_Editor_Dashboard_Id
                    ,Registration_Date = m.Dashboard_Editor_Registration_Date
                    ,Registration_User = m.Dashboard_Editor_Registration_User
                    ,Registration_User_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Dashboard_Editor_Registration_User.GetValueOrDefault(), Name = m.Dashboard_Editor_Registration_User_Name }
                    ,Name = m.Dashboard_Editor_Name
                    ,Dashboard_Template = m.Dashboard_Editor_Dashboard_Template
                    ,Dashboard_Template_Template_Dashboard_Editor = new Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor() { Template_Id = m.Dashboard_Editor_Dashboard_Template.GetValueOrDefault(), Description = m.Dashboard_Editor_Dashboard_Template_Description }
                    ,Show_in_Home = m.Dashboard_Editor_Show_in_Home ?? false
                    ,Status = m.Dashboard_Editor_Status
                    ,Status_Dashboard_Status = new Core.Classes.Dashboard_Status.Dashboard_Status() { Status_Id = m.Dashboard_Editor_Status.GetValueOrDefault(), Description = m.Dashboard_Editor_Status_Description }
                    ,Spartan_Object = m.Dashboard_Editor_Spartan_Object

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Dashboard_EditorRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Dashboard_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor>("sp_GetDashboard_Editor", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Dashboard_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDashboard_Editor>("sp_DelDashboard_Editor", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor entity)
        {
            int rta;
            try
            {

		var padreDashboard_Id = _dataProvider.GetParameter();
                padreDashboard_Id.ParameterName = "Dashboard_Id";
                padreDashboard_Id.DbType = DbType.Int32;
                padreDashboard_Id.Value = (object)entity.Dashboard_Id ?? DBNull.Value;
                var padreRegistration_Date = _dataProvider.GetParameter();
                padreRegistration_Date.ParameterName = "Registration_Date";
                padreRegistration_Date.DbType = DbType.DateTime;
                padreRegistration_Date.Value = (object)entity.Registration_Date ?? DBNull.Value;

                var padreRegistration_User = _dataProvider.GetParameter();
                padreRegistration_User.ParameterName = "Registration_User";
                padreRegistration_User.DbType = DbType.Int32;
                padreRegistration_User.Value = (object)entity.Registration_User ?? DBNull.Value;

                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = (object)entity.Name ?? DBNull.Value;
                var padreDashboard_Template = _dataProvider.GetParameter();
                padreDashboard_Template.ParameterName = "Dashboard_Template";
                padreDashboard_Template.DbType = DbType.Int32;
                padreDashboard_Template.Value = (object)entity.Dashboard_Template ?? DBNull.Value;

                var padreShow_in_Home = _dataProvider.GetParameter();
                padreShow_in_Home.ParameterName = "Show_in_Home";
                padreShow_in_Home.DbType = DbType.Boolean;
                padreShow_in_Home.Value = (object)entity.Show_in_Home ?? DBNull.Value;
                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int16;
                padreStatus.Value = (object)entity.Status ?? DBNull.Value;

                var padreSpartan_Object = _dataProvider.GetParameter();
                padreSpartan_Object.ParameterName = "Spartan_Object";
                padreSpartan_Object.DbType = DbType.Int32;
                padreSpartan_Object.Value = (object)entity.Spartan_Object ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDashboard_Editor>("sp_InsDashboard_Editor" , padreRegistration_Date
, padreRegistration_User
, padreName
, padreDashboard_Template
, padreShow_in_Home
, padreStatus
, padreSpartan_Object
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Dashboard_Id);

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

        public int Update(Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor entity)
        {
            int rta;
            try
            {

                var paramUpdDashboard_Id = _dataProvider.GetParameter();
                paramUpdDashboard_Id.ParameterName = "Dashboard_Id";
                paramUpdDashboard_Id.DbType = DbType.Int32;
                paramUpdDashboard_Id.Value = (object)entity.Dashboard_Id ?? DBNull.Value;
                var paramUpdRegistration_Date = _dataProvider.GetParameter();
                paramUpdRegistration_Date.ParameterName = "Registration_Date";
                paramUpdRegistration_Date.DbType = DbType.DateTime;
                paramUpdRegistration_Date.Value = (object)entity.Registration_Date ?? DBNull.Value;

                var paramUpdRegistration_User = _dataProvider.GetParameter();
                paramUpdRegistration_User.ParameterName = "Registration_User";
                paramUpdRegistration_User.DbType = DbType.Int32;
                paramUpdRegistration_User.Value = (object)entity.Registration_User ?? DBNull.Value;

                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)entity.Name ?? DBNull.Value;
                var paramUpdDashboard_Template = _dataProvider.GetParameter();
                paramUpdDashboard_Template.ParameterName = "Dashboard_Template";
                paramUpdDashboard_Template.DbType = DbType.Int32;
                paramUpdDashboard_Template.Value = (object)entity.Dashboard_Template ?? DBNull.Value;

                var paramUpdShow_in_Home = _dataProvider.GetParameter();
                paramUpdShow_in_Home.ParameterName = "Show_in_Home";
                paramUpdShow_in_Home.DbType = DbType.Boolean;
                paramUpdShow_in_Home.Value = (object)entity.Show_in_Home ?? DBNull.Value;
                var paramUpdStatus = _dataProvider.GetParameter();
                paramUpdStatus.ParameterName = "Status";
                paramUpdStatus.DbType = DbType.Int16;
                paramUpdStatus.Value = (object)entity.Status ?? DBNull.Value;

                var paramUpdSpartan_Object = _dataProvider.GetParameter();
                paramUpdSpartan_Object.ParameterName = "Spartan_Object";
                paramUpdSpartan_Object.DbType = DbType.Int32;
                paramUpdSpartan_Object.Value = (object)entity.Spartan_Object ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDashboard_Editor>("sp_UpdDashboard_Editor" , paramUpdDashboard_Id , paramUpdRegistration_Date , paramUpdRegistration_User , paramUpdName , paramUpdDashboard_Template , paramUpdShow_in_Home , paramUpdStatus , paramUpdSpartan_Object ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Dashboard_Id);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor Dashboard_EditorDB = GetByKey(entity.Dashboard_Id, false);
                var paramUpdDashboard_Id = _dataProvider.GetParameter();
                paramUpdDashboard_Id.ParameterName = "Dashboard_Id";
                paramUpdDashboard_Id.DbType = DbType.Int32;
                paramUpdDashboard_Id.Value = (object)entity.Dashboard_Id ?? DBNull.Value;
                var paramUpdRegistration_Date = _dataProvider.GetParameter();
                paramUpdRegistration_Date.ParameterName = "Registration_Date";
                paramUpdRegistration_Date.DbType = DbType.DateTime;
                paramUpdRegistration_Date.Value = (object)entity.Registration_Date ?? DBNull.Value;
		var paramUpdRegistration_User = _dataProvider.GetParameter();
                paramUpdRegistration_User.ParameterName = "Registration_User";
                paramUpdRegistration_User.DbType = DbType.Int32;
                paramUpdRegistration_User.Value = (object)entity.Registration_User ?? DBNull.Value;
                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)entity.Name ?? DBNull.Value;
		var paramUpdDashboard_Template = _dataProvider.GetParameter();
                paramUpdDashboard_Template.ParameterName = "Dashboard_Template";
                paramUpdDashboard_Template.DbType = DbType.Int32;
                paramUpdDashboard_Template.Value = (object)entity.Dashboard_Template ?? DBNull.Value;
                var paramUpdShow_in_Home = _dataProvider.GetParameter();
                paramUpdShow_in_Home.ParameterName = "Show_in_Home";
                paramUpdShow_in_Home.DbType = DbType.Boolean;
                paramUpdShow_in_Home.Value = (object)entity.Show_in_Home ?? DBNull.Value;
		var paramUpdStatus = _dataProvider.GetParameter();
                paramUpdStatus.ParameterName = "Status";
                paramUpdStatus.DbType = DbType.Int16;
                paramUpdStatus.Value = (object)entity.Status ?? DBNull.Value;
                var paramUpdSpartan_Object = _dataProvider.GetParameter();
                paramUpdSpartan_Object.ParameterName = "Spartan_Object";
                paramUpdSpartan_Object.DbType = DbType.Int32;
                paramUpdSpartan_Object.Value = (object)entity.Spartan_Object ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDashboard_Editor>("sp_UpdDashboard_Editor" , paramUpdDashboard_Id , paramUpdRegistration_Date , paramUpdRegistration_User , paramUpdName , paramUpdDashboard_Template , paramUpdShow_in_Home , paramUpdStatus , paramUpdSpartan_Object ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Dashboard_Id);
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

		public int Update_Configuracion(Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor Dashboard_EditorDB = GetByKey(entity.Dashboard_Id, false);
                var paramUpdDashboard_Id = _dataProvider.GetParameter();
                paramUpdDashboard_Id.ParameterName = "Dashboard_Id";
                paramUpdDashboard_Id.DbType = DbType.Int32;
                paramUpdDashboard_Id.Value = (object)Dashboard_EditorDB.Dashboard_Id ?? DBNull.Value;
                var paramUpdRegistration_Date = _dataProvider.GetParameter();
                paramUpdRegistration_Date.ParameterName = "Registration_Date";
                paramUpdRegistration_Date.DbType = DbType.DateTime;
                paramUpdRegistration_Date.Value = (object)Dashboard_EditorDB.Registration_Date ?? DBNull.Value;
		var paramUpdRegistration_User = _dataProvider.GetParameter();
                paramUpdRegistration_User.ParameterName = "Registration_User";
                paramUpdRegistration_User.DbType = DbType.Int32;
                paramUpdRegistration_User.Value = (object)Dashboard_EditorDB.Registration_User ?? DBNull.Value;
                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)Dashboard_EditorDB.Name ?? DBNull.Value;
		var paramUpdDashboard_Template = _dataProvider.GetParameter();
                paramUpdDashboard_Template.ParameterName = "Dashboard_Template";
                paramUpdDashboard_Template.DbType = DbType.Int32;
                paramUpdDashboard_Template.Value = (object)Dashboard_EditorDB.Dashboard_Template ?? DBNull.Value;
                var paramUpdShow_in_Home = _dataProvider.GetParameter();
                paramUpdShow_in_Home.ParameterName = "Show_in_Home";
                paramUpdShow_in_Home.DbType = DbType.Boolean;
                paramUpdShow_in_Home.Value = (object)Dashboard_EditorDB.Show_in_Home ?? DBNull.Value;
		var paramUpdStatus = _dataProvider.GetParameter();
                paramUpdStatus.ParameterName = "Status";
                paramUpdStatus.DbType = DbType.Int16;
                paramUpdStatus.Value = (object)Dashboard_EditorDB.Status ?? DBNull.Value;
                var paramUpdSpartan_Object = _dataProvider.GetParameter();
                paramUpdSpartan_Object.ParameterName = "Spartan_Object";
                paramUpdSpartan_Object.DbType = DbType.Int32;
                paramUpdSpartan_Object.Value = (object)Dashboard_EditorDB.Spartan_Object ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDashboard_Editor>("sp_UpdDashboard_Editor" , paramUpdDashboard_Id , paramUpdRegistration_Date , paramUpdRegistration_User , paramUpdName , paramUpdDashboard_Template , paramUpdShow_in_Home , paramUpdStatus , paramUpdSpartan_Object ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Dashboard_Id);
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


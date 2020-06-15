using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Report_Presentation_View;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Presentation_View
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_Presentation_ViewService : ISpartan_Report_Presentation_ViewService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> _Spartan_Report_Presentation_ViewRepository;
        #endregion

        #region Ctor
        public Spartan_Report_Presentation_ViewService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> Spartan_Report_Presentation_ViewRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_Presentation_ViewRepository = Spartan_Report_Presentation_ViewRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>("sp_SelAllSpartan_Report_Presentation_View");
        }

        public IList<Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Report_Presentation_View_Complete>("sp_SelAllComplete_Spartan_Report_Presentation_View");
            return data.Select(m => new Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View
            {
                PresentationViewId = m.PresentationViewId
                ,Description = m.Description
                ,Presentation_Type_Spartan_Report_Presentation_Type = new Core.Classes.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type() { PresentationTypeId = m.Presentation_Type.GetValueOrDefault(), Description = m.Presentation_Type_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Report_Presentation_View>("sp_ListSelCount_Spartan_Report_Presentation_View", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Presentation_View>("sp_ListSelAll_Spartan_Report_Presentation_View", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View
                {
                    PresentationViewId = m.Spartan_Report_Presentation_View_PresentationViewId,
                    Description = m.Spartan_Report_Presentation_View_Description,
                    Presentation_Type = m.Spartan_Report_Presentation_View_Presentation_Type,

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

        public IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Report_Presentation_View>("sp_ListSelAll_Spartan_Report_Presentation_View", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Report_Presentation_ViewPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Report_Presentation_ViewPagingModel
                {
                    Spartan_Report_Presentation_Views =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View
                {
                    PresentationViewId = m.Spartan_Report_Presentation_View_PresentationViewId
                    ,Description = m.Spartan_Report_Presentation_View_Description
                    ,Presentation_Type = m.Spartan_Report_Presentation_View_Presentation_Type
                    ,Presentation_Type_Spartan_Report_Presentation_Type = new Core.Classes.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type() { PresentationTypeId = m.Spartan_Report_Presentation_View_Presentation_Type.GetValueOrDefault(), Description = m.Spartan_Report_Presentation_View_Presentation_Type_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "PresentationViewId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>("sp_GetSpartan_Report_Presentation_View", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "PresentationViewId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Report_Presentation_View>("sp_DelSpartan_Report_Presentation_View", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
                var padrePresentation_Type = _dataProvider.GetParameter();
                padrePresentation_Type.ParameterName = "Presentation_Type";
                padrePresentation_Type.DbType = DbType.Int32;
                padrePresentation_Type.Value = (object)entity.Presentation_Type ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Report_Presentation_View>("sp_InsSpartan_Report_Presentation_View" , padreDescription
, padrePresentation_Type
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.PresentationViewId);

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

        public int Update(Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity)
        {
            int rta;
            try
            {

                var paramUpdPresentationViewId = _dataProvider.GetParameter();
                paramUpdPresentationViewId.ParameterName = "PresentationViewId";
                paramUpdPresentationViewId.DbType = DbType.Int32;
                paramUpdPresentationViewId.Value = (object)entity.PresentationViewId ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;
                var paramUpdPresentation_Type = _dataProvider.GetParameter();
                paramUpdPresentation_Type.ParameterName = "Presentation_Type";
                paramUpdPresentation_Type.DbType = DbType.Int32;
                paramUpdPresentation_Type.Value = (object)entity.Presentation_Type ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Report_Presentation_View>("sp_UpdSpartan_Report_Presentation_View" , paramUpdPresentationViewId , paramUpdDescription , paramUpdPresentation_Type ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.PresentationViewId);
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

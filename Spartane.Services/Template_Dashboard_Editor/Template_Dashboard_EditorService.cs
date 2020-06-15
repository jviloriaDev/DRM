using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Template_Dashboard_Editor;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Template_Dashboard_Editor
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Template_Dashboard_EditorService : ITemplate_Dashboard_EditorService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> _Template_Dashboard_EditorRepository;
        #endregion

        #region Ctor
        public Template_Dashboard_EditorService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> Template_Dashboard_EditorRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Template_Dashboard_EditorRepository = Template_Dashboard_EditorRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Template_Dashboard_EditorRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor>("sp_SelAllTemplate_Dashboard_Editor");
        }

        public IList<Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTemplate_Dashboard_Editor_Complete>("sp_SelAllComplete_Template_Dashboard_Editor");
            return data.Select(m => new Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor
            {
                Template_Id = m.Template_Id
                ,Description = m.Description
                ,Template_Image_Thumbnail = m.Template_Image_Thumbnail


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Template_Dashboard_Editor>("sp_ListSelCount_Template_Dashboard_Editor", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTemplate_Dashboard_Editor>("sp_ListSelAll_Template_Dashboard_Editor", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor
                {
                    Template_Id = m.Template_Dashboard_Editor_Template_Id,
                    Description = m.Template_Dashboard_Editor_Description,
                    Template_Image_Thumbnail = m.Template_Dashboard_Editor_Template_Image_Thumbnail,

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

        public IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Template_Dashboard_EditorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Template_Dashboard_EditorRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_EditorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTemplate_Dashboard_Editor>("sp_ListSelAll_Template_Dashboard_Editor", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Template_Dashboard_EditorPagingModel result = null;

            if (data != null)
            {
                result = new Template_Dashboard_EditorPagingModel
                {
                    Template_Dashboard_Editors =
                        data.Select(m => new Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor
                {
                    Template_Id = m.Template_Dashboard_Editor_Template_Id
                    ,Description = m.Template_Dashboard_Editor_Description
                    ,Template_Image_Thumbnail = m.Template_Dashboard_Editor_Template_Image_Thumbnail

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Template_Dashboard_EditorRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Template_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor>("sp_GetTemplate_Dashboard_Editor", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Template_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTemplate_Dashboard_Editor>("sp_DelTemplate_Dashboard_Editor", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor entity)
        {
            int rta;
            try
            {

		var padreTemplate_Id = _dataProvider.GetParameter();
                padreTemplate_Id.ParameterName = "Template_Id";
                padreTemplate_Id.DbType = DbType.Int32;
                padreTemplate_Id.Value = (object)entity.Template_Id ?? DBNull.Value;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
                var padreTemplate_Image_Thumbnail = _dataProvider.GetParameter();
                padreTemplate_Image_Thumbnail.ParameterName = "Template_Image_Thumbnail";
                padreTemplate_Image_Thumbnail.DbType = DbType.Int32;
                padreTemplate_Image_Thumbnail.Value = (object)entity.Template_Image_Thumbnail ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTemplate_Dashboard_Editor>("sp_InsTemplate_Dashboard_Editor" , padreDescription
, padreTemplate_Image_Thumbnail
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Template_Id);

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

        public int Update(Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor entity)
        {
            int rta;
            try
            {

                var paramUpdTemplate_Id = _dataProvider.GetParameter();
                paramUpdTemplate_Id.ParameterName = "Template_Id";
                paramUpdTemplate_Id.DbType = DbType.Int32;
                paramUpdTemplate_Id.Value = (object)entity.Template_Id ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;
                var paramUpdTemplate_Image_Thumbnail = _dataProvider.GetParameter();
                paramUpdTemplate_Image_Thumbnail.ParameterName = "Template_Image_Thumbnail";
                paramUpdTemplate_Image_Thumbnail.DbType = DbType.Int32;
                paramUpdTemplate_Image_Thumbnail.Value = (object)entity.Template_Image_Thumbnail ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTemplate_Dashboard_Editor>("sp_UpdTemplate_Dashboard_Editor" , paramUpdTemplate_Id , paramUpdDescription , paramUpdTemplate_Image_Thumbnail ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Template_Id);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor Template_Dashboard_EditorDB = GetByKey(entity.Template_Id, false);
                var paramUpdTemplate_Id = _dataProvider.GetParameter();
                paramUpdTemplate_Id.ParameterName = "Template_Id";
                paramUpdTemplate_Id.DbType = DbType.Int32;
                paramUpdTemplate_Id.Value = (object)entity.Template_Id ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;
                var paramUpdTemplate_Image_Thumbnail = _dataProvider.GetParameter();
                paramUpdTemplate_Image_Thumbnail.ParameterName = "Template_Image_Thumbnail";
                paramUpdTemplate_Image_Thumbnail.DbType = DbType.Int32;
                paramUpdTemplate_Image_Thumbnail.Value = (object)entity.Template_Image_Thumbnail ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTemplate_Dashboard_Editor>("sp_UpdTemplate_Dashboard_Editor" , paramUpdTemplate_Id , paramUpdDescription , paramUpdTemplate_Image_Thumbnail ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Template_Id);
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


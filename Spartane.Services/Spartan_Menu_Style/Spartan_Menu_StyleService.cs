using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Menu_Style;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Menu_Style
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Menu_StyleService : ISpartan_Menu_StyleService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> _Spartan_Menu_StyleRepository;
        #endregion

        #region Ctor
        public Spartan_Menu_StyleService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> Spartan_Menu_StyleRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Menu_StyleRepository = Spartan_Menu_StyleRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Menu_StyleRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style>("sp_SelAllSpartan_Menu_Style");
        }

        public IList<Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Menu_Style_Complete>("sp_SelAllComplete_Spartan_Menu_Style");
            return data.Select(m => new Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style
            {
                Menu_Style_Id = m.Menu_Style_Id
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Menu_Style>("sp_ListSelCount_Spartan_Menu_Style", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Menu_Style>("sp_ListSelAll_Spartan_Menu_Style", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style
                {
                    Menu_Style_Id = m.Spartan_Menu_Style_Menu_Style_Id,
                    Description = m.Spartan_Menu_Style_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Menu_StyleRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Menu_StyleRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_StylePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Menu_Style>("sp_ListSelAll_Spartan_Menu_Style", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Menu_StylePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Menu_StylePagingModel
                {
                    Spartan_Menu_Styles =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style
                {
                    Menu_Style_Id = m.Spartan_Menu_Style_Menu_Style_Id
                    ,Description = m.Spartan_Menu_Style_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Menu_StyleRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Menu_Style_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style>("sp_GetSpartan_Menu_Style", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Menu_Style_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Menu_Style>("sp_DelSpartan_Menu_Style", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Menu_Style>("sp_InsSpartan_Menu_Style" , padreDescription 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Menu_Style_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style entity)
        {
            short rta;
            try
            {

                var padreMenu_Style_Id = _dataProvider.GetParameter();
                padreMenu_Style_Id.ParameterName = "Menu_Style_Id";
                padreMenu_Style_Id.DbType = DbType.Int16;
                padreMenu_Style_Id.Value = entity.Menu_Style_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Menu_Style>("sp_UpdSpartan_Menu_Style" , padreMenu_Style_Id  , padreDescription  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Menu_Style_Id);
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


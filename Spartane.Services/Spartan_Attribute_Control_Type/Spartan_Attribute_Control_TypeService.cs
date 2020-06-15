using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Attribute_Control_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Attribute_Control_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Attribute_Control_TypeService : ISpartan_Attribute_Control_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> _Spartan_Attribute_Control_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Attribute_Control_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> Spartan_Attribute_Control_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Attribute_Control_TypeRepository = Spartan_Attribute_Control_TypeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>("sp_SelAllSpartan_Attribute_Control_Type");
        }

        public IList<Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Attribute_Control_Type_Complete>("sp_SelAllComplete_Spartan_Attribute_Control_Type");
            return data.Select(m => new Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type
            {
                ControlTypeId = m.ControlTypeId
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Attribute_Control_Type>("sp_ListSelCount_Spartan_Attribute_Control_Type", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Attribute_Control_Type>("sp_ListSelAll_Spartan_Attribute_Control_Type", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type
                {
                    ControlTypeId = m.Spartan_Attribute_Control_Type_ControlTypeId,
                    Description = m.Spartan_Attribute_Control_Type_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Attribute_Control_Type>("sp_ListSelAll_Spartan_Attribute_Control_Type", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Attribute_Control_TypePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Attribute_Control_TypePagingModel
                {
                    Spartan_Attribute_Control_Types =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type
                {
                    ControlTypeId = m.Spartan_Attribute_Control_Type_ControlTypeId
                    ,Description = m.Spartan_Attribute_Control_Type_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "ControlTypeId";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>("sp_GetSpartan_Attribute_Control_Type", padreKey).SingleOrDefault();
        }

        public bool Delete(short Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "ControlTypeId";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Attribute_Control_Type>("sp_DelSpartan_Attribute_Control_Type", padreKey).FirstOrDefault();
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

        public short Insert(Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Attribute_Control_Type>("sp_InsSpartan_Attribute_Control_Type" , padreDescription
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.ControlTypeId);

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

        public short Update(Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type entity)
        {
            short rta;
            try
            {

                var paramUpdControlTypeId = _dataProvider.GetParameter();
                paramUpdControlTypeId.ParameterName = "ControlTypeId";
                paramUpdControlTypeId.DbType = DbType.Int16;
                paramUpdControlTypeId.Value = entity.ControlTypeId;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Attribute_Control_Type>("sp_UpdSpartan_Attribute_Control_Type" , paramUpdControlTypeId , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.ControlTypeId);
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


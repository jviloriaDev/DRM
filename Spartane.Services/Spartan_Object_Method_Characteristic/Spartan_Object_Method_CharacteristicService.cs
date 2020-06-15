using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Object_Method_Characteristic;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Object_Method_Characteristic
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Object_Method_CharacteristicService : ISpartan_Object_Method_CharacteristicService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> _Spartan_Object_Method_CharacteristicRepository;
        #endregion

        #region Ctor
        public Spartan_Object_Method_CharacteristicService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> Spartan_Object_Method_CharacteristicRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Object_Method_CharacteristicRepository = Spartan_Object_Method_CharacteristicRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Object_Method_CharacteristicRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic>("sp_SelAllSpartan_Object_Method_Characteristic");
        }

        public IList<Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Object_Method_Characteristic_Complete>("sp_SelAllComplete_Spartan_Object_Method_Characteristic");
            return data.Select(m => new Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic
            {
                Object_Method_Characteristic_Id = m.Object_Method_Characteristic_Id
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Object_Method_Characteristic>("sp_ListSelCount_Spartan_Object_Method_Characteristic", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object_Method_Characteristic>("sp_ListSelAll_Spartan_Object_Method_Characteristic", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic
                {
                    Object_Method_Characteristic_Id = m.Spartan_Object_Method_Characteristic_Object_Method_Characteristic_Id,
                    Description = m.Spartan_Object_Method_Characteristic_Description,

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

        public IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Object_Method_CharacteristicRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Object_Method_CharacteristicRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_CharacteristicPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Object_Method_Characteristic>("sp_ListSelAll_Spartan_Object_Method_Characteristic", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Object_Method_CharacteristicPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Object_Method_CharacteristicPagingModel
                {
                    Spartan_Object_Method_Characteristics =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic
                {
                    Object_Method_Characteristic_Id = m.Spartan_Object_Method_Characteristic_Object_Method_Characteristic_Id
                    ,Description = m.Spartan_Object_Method_Characteristic_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Object_Method_CharacteristicRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Object_Method_Characteristic_Id";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic>("sp_GetSpartan_Object_Method_Characteristic", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Object_Method_Characteristic_Id";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Object_Method_Characteristic>("sp_DelSpartan_Object_Method_Characteristic", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic entity)
        {
            int rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Object_Method_Characteristic>("sp_InsSpartan_Object_Method_Characteristic" , padreDescription 
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Method_Characteristic_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic entity)
        {
            int rta;
            try
            {

                var padreObject_Method_Characteristic_Id = _dataProvider.GetParameter();
                padreObject_Method_Characteristic_Id.ParameterName = "Object_Method_Characteristic_Id";
                padreObject_Method_Characteristic_Id.DbType = DbType.Int32;
                padreObject_Method_Characteristic_Id.Value = entity.Object_Method_Characteristic_Id;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Object_Method_Characteristic>("sp_UpdSpartan_Object_Method_Characteristic" , padreObject_Method_Characteristic_Id  , padreDescription  ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Object_Method_Characteristic_Id);
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


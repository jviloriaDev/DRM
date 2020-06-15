using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Module_Object_Characteristic;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Module_Object_Characteristic
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Module_Object_CharacteristicService : ISpartan_Module_Object_CharacteristicService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic> _Spartan_Module_Object_CharacteristicRepository;
        #endregion

        #region Ctor
        public Spartan_Module_Object_CharacteristicService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic> Spartan_Module_Object_CharacteristicRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Module_Object_CharacteristicRepository = Spartan_Module_Object_CharacteristicRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Module_Object_CharacteristicRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic>("sp_SelAllSpartan_Module_Object_Characteristic");
        }

        public IList<Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Module_Object_Characteristic_Complete>("sp_SelAllComplete_Spartan_Module_Object_Characteristic");
            return data.Select(m => new Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic
            {
                Module_Object_Characteristic_Id = m.Module_Object_Characteristic_Id
                ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Object_Id.GetValueOrDefault(), Name = m.Object_Id_Name }
                ,Characteristic_Spartan_Object_Characteristic = new Core.Classes.Spartan_Object_Characteristic.Spartan_Object_Characteristic() { Object_Characteristc_Id = m.Characteristic.GetValueOrDefault(), Description = m.Characteristic_Description }
                ,Numeric_Value = m.Numeric_Value
                ,Text_Value = m.Text_Value
                ,Spartan_Module = m.Spartan_Module


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Module_Object_Characteristic>("sp_ListSelCount_Spartan_Module_Object_Characteristic", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module_Object_Characteristic>("sp_ListSelAll_Spartan_Module_Object_Characteristic", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic
                {
                    Module_Object_Characteristic_Id = m.Spartan_Module_Object_Characteristic_Module_Object_Characteristic_Id,
                    Object_Id = m.Spartan_Module_Object_Characteristic_Object_Id,
                    Characteristic = m.Spartan_Module_Object_Characteristic_Characteristic,
                    Numeric_Value = m.Spartan_Module_Object_Characteristic_Numeric_Value,
                    Text_Value = m.Spartan_Module_Object_Characteristic_Text_Value,
                    Spartan_Module = m.Spartan_Module_Object_Characteristic_Spartan_Module,

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

        public IList<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Module_Object_CharacteristicRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Module_Object_CharacteristicRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_CharacteristicPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Module_Object_Characteristic>("sp_ListSelAll_Spartan_Module_Object_Characteristic", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Module_Object_CharacteristicPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Module_Object_CharacteristicPagingModel
                {
                    Spartan_Module_Object_Characteristics =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic
                {
                    Module_Object_Characteristic_Id = m.Spartan_Module_Object_Characteristic_Module_Object_Characteristic_Id
                    ,Object_Id = m.Spartan_Module_Object_Characteristic_Object_Id
                    ,Object_Id_Spartan_Object = new Core.Classes.Spartan_Object.Spartan_Object() { Object_Id = m.Spartan_Module_Object_Characteristic_Object_Id.GetValueOrDefault(), Name = m.Spartan_Module_Object_Characteristic_Object_Id_Name }
                    ,Characteristic = m.Spartan_Module_Object_Characteristic_Characteristic
                    ,Characteristic_Spartan_Object_Characteristic = new Core.Classes.Spartan_Object_Characteristic.Spartan_Object_Characteristic() { Object_Characteristc_Id = m.Spartan_Module_Object_Characteristic_Characteristic.GetValueOrDefault(), Description = m.Spartan_Module_Object_Characteristic_Characteristic_Description }
                    ,Numeric_Value = m.Spartan_Module_Object_Characteristic_Numeric_Value
                    ,Text_Value = m.Spartan_Module_Object_Characteristic_Text_Value
                    ,Spartan_Module = m.Spartan_Module_Object_Characteristic_Spartan_Module

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Module_Object_CharacteristicRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Module_Object_Characteristic_Id";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic>("sp_GetSpartan_Module_Object_Characteristic", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Module_Object_Characteristic_Id";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Module_Object_Characteristic>("sp_DelSpartan_Module_Object_Characteristic", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic entity)
        {
            short rta;
            try
            {

		                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreCharacteristic = _dataProvider.GetParameter();
                padreCharacteristic.ParameterName = "Characteristic";
                padreCharacteristic.DbType = DbType.Int16;
                if (entity.Characteristic == null)
                    padreCharacteristic.Value = DBNull.Value;
                else
                    padreCharacteristic.Value = entity.Characteristic;

                var padreNumeric_Value = _dataProvider.GetParameter();
                padreNumeric_Value.ParameterName = "Numeric_Value";
                padreNumeric_Value.DbType = DbType.Int32;
                if (entity.Numeric_Value == null)
                    padreNumeric_Value.Value = DBNull.Value;
                else
                    padreNumeric_Value.Value = entity.Numeric_Value;

                var padreText_Value = _dataProvider.GetParameter();
                padreText_Value.ParameterName = "Text_Value";
                padreText_Value.DbType = DbType.String;
                padreText_Value.Value = entity.Text_Value;
                var padreSpartan_Module = _dataProvider.GetParameter();
                padreSpartan_Module.ParameterName = "Spartan_Module";
                padreSpartan_Module.DbType = DbType.Int16;
                padreSpartan_Module.Value = entity.Spartan_Module;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Module_Object_Characteristic>("sp_InsSpartan_Module_Object_Characteristic" , padreObject_Id 
, padreCharacteristic 
, padreNumeric_Value 
, padreText_Value 
, padreSpartan_Module 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Module_Object_Characteristic_Id);

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

        public int Update(Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic entity)
        {
            short rta;
            try
            {

                var padreModule_Object_Characteristic_Id = _dataProvider.GetParameter();
                padreModule_Object_Characteristic_Id.ParameterName = "Module_Object_Characteristic_Id";
                padreModule_Object_Characteristic_Id.DbType = DbType.Int16;
                padreModule_Object_Characteristic_Id.Value = entity.Module_Object_Characteristic_Id;
                var padreObject_Id = _dataProvider.GetParameter();
                padreObject_Id.ParameterName = "Object_Id";
                padreObject_Id.DbType = DbType.Int32;
                if (entity.Object_Id == null)
                    padreObject_Id.Value = DBNull.Value;
                else
                    padreObject_Id.Value = entity.Object_Id;

                var padreCharacteristic = _dataProvider.GetParameter();
                padreCharacteristic.ParameterName = "Characteristic";
                padreCharacteristic.DbType = DbType.Int16;
                if (entity.Characteristic == null)
                    padreCharacteristic.Value = DBNull.Value;
                else
                    padreCharacteristic.Value = entity.Characteristic;

                var padreNumeric_Value = _dataProvider.GetParameter();
                padreNumeric_Value.ParameterName = "Numeric_Value";
                padreNumeric_Value.DbType = DbType.Int32;
                if (entity.Numeric_Value == null)
                    padreNumeric_Value.Value = DBNull.Value;
                else
                    padreNumeric_Value.Value = entity.Numeric_Value;

                var padreText_Value = _dataProvider.GetParameter();
                padreText_Value.ParameterName = "Text_Value";
                padreText_Value.DbType = DbType.String;
                padreText_Value.Value = entity.Text_Value;
                var padreSpartan_Module = _dataProvider.GetParameter();
                padreSpartan_Module.ParameterName = "Spartan_Module";
                padreSpartan_Module.DbType = DbType.Int16;
                padreSpartan_Module.Value = entity.Spartan_Module;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Module_Object_Characteristic>("sp_UpdSpartan_Module_Object_Characteristic" , padreModule_Object_Characteristic_Id  , padreObject_Id  , padreCharacteristic  , padreNumeric_Value  , padreText_Value  , padreSpartan_Module  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Module_Object_Characteristic_Id);
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


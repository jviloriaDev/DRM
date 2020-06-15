using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_Function_Characteristic;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Function_Characteristic
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Function_CharacteristicService : ISpartan_Function_CharacteristicService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> _Spartan_Function_CharacteristicRepository;
        #endregion

        #region Ctor
        public Spartan_Function_CharacteristicService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> Spartan_Function_CharacteristicRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Function_CharacteristicRepository = Spartan_Function_CharacteristicRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_Function_CharacteristicRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic>("sp_SelAllSpartan_Function_Characteristic");
        }

        public IList<Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_Function_Characteristic_Complete>("sp_SelAllComplete_Spartan_Function_Characteristic");
            return data.Select(m => new Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic
            {
                Function_Characteristic = m.Function_Characteristic
                ,Description = m.Description
                ,Attribute_Type_Spartan_Attribute_Type = new Core.Classes.Spartan_Attribute_Type.Spartan_Attribute_Type() { Attribute_Type_Id = m.Attribute_Type.GetValueOrDefault(), Description = m.Attribute_Type_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_Function_Characteristic>("sp_ListSelCount_Spartan_Function_Characteristic", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function_Characteristic>("sp_ListSelAll_Spartan_Function_Characteristic", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic
                {
                    Function_Characteristic = m.Spartan_Function_Characteristic_Function_Characteristic,
                    Description = m.Spartan_Function_Characteristic_Description,
                    Attribute_Type = m.Spartan_Function_Characteristic_Attribute_Type,

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

        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Function_CharacteristicRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Function_CharacteristicRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_CharacteristicPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_Function_Characteristic>("sp_ListSelAll_Spartan_Function_Characteristic", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_Function_CharacteristicPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_Function_CharacteristicPagingModel
                {
                    Spartan_Function_Characteristics =
                        data.Select(m => new Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic
                {
                    Function_Characteristic = m.Spartan_Function_Characteristic_Function_Characteristic
                    ,Description = m.Spartan_Function_Characteristic_Description
                    ,Attribute_Type = m.Spartan_Function_Characteristic_Attribute_Type
                    ,Attribute_Type_Spartan_Attribute_Type = new Core.Classes.Spartan_Attribute_Type.Spartan_Attribute_Type() { Attribute_Type_Id = m.Spartan_Function_Characteristic_Attribute_Type.GetValueOrDefault(), Description = m.Spartan_Function_Characteristic_Attribute_Type_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Function_CharacteristicRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic GetByKey(short? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Function_Characteristic";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic>("sp_GetSpartan_Function_Characteristic", padreKey).SingleOrDefault();
        }

        public bool Delete(short? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Function_Characteristic";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_Function_Characteristic>("sp_DelSpartan_Function_Characteristic", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreAttribute_Type = _dataProvider.GetParameter();
                padreAttribute_Type.ParameterName = "Attribute_Type";
                padreAttribute_Type.DbType = DbType.Int32;
                if (entity.Attribute_Type == null)
                    padreAttribute_Type.Value = DBNull.Value;
                else
                    padreAttribute_Type.Value = entity.Attribute_Type;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_Function_Characteristic>("sp_InsSpartan_Function_Characteristic" , padreDescription 
, padreAttribute_Type 
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Characteristic);

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

        public int Update(Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic entity)
        {
            short rta;
            try
            {

                var padreFunction_Characteristic = _dataProvider.GetParameter();
                padreFunction_Characteristic.ParameterName = "Function_Characteristic";
                padreFunction_Characteristic.DbType = DbType.Int16;
                padreFunction_Characteristic.Value = entity.Function_Characteristic;
                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = entity.Description;
                var padreAttribute_Type = _dataProvider.GetParameter();
                padreAttribute_Type.ParameterName = "Attribute_Type";
                padreAttribute_Type.DbType = DbType.Int32;
                if (entity.Attribute_Type == null)
                    padreAttribute_Type.Value = DBNull.Value;
                else
                    padreAttribute_Type.Value = entity.Attribute_Type;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_Function_Characteristic>("sp_UpdSpartan_Function_Characteristic" , padreFunction_Characteristic  , padreDescription  , padreAttribute_Type  ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Function_Characteristic);
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


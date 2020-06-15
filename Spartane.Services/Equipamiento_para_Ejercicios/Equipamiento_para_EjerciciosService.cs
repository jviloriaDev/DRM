using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Equipamiento_para_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Equipamiento_para_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Equipamiento_para_EjerciciosService : IEquipamiento_para_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> _Equipamiento_para_EjerciciosRepository;
        #endregion

        #region Ctor
        public Equipamiento_para_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> Equipamiento_para_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Equipamiento_para_EjerciciosRepository = Equipamiento_para_EjerciciosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Equipamiento_para_EjerciciosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>("sp_SelAllEquipamiento_para_Ejercicios");
        }

        public IList<Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEquipamiento_para_Ejercicios_Complete>("sp_SelAllComplete_Equipamiento_para_Ejercicios");
            return data.Select(m => new Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios
            {
                Folio = m.Folio
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Equipamiento_para_Ejercicios>("sp_ListSelCount_Equipamiento_para_Ejercicios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEquipamiento_para_Ejercicios>("sp_ListSelAll_Equipamiento_para_Ejercicios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios
                {
                    Folio = m.Equipamiento_para_Ejercicios_Folio,
                    Descripcion = m.Equipamiento_para_Ejercicios_Descripcion,

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

        public IList<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Equipamiento_para_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Equipamiento_para_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEquipamiento_para_Ejercicios>("sp_ListSelAll_Equipamiento_para_Ejercicios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Equipamiento_para_EjerciciosPagingModel result = null;

            if (data != null)
            {
                result = new Equipamiento_para_EjerciciosPagingModel
                {
                    Equipamiento_para_Ejercicioss =
                        data.Select(m => new Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios
                {
                    Folio = m.Equipamiento_para_Ejercicios_Folio
                    ,Descripcion = m.Equipamiento_para_Ejercicios_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Equipamiento_para_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>("sp_GetEquipamiento_para_Ejercicios", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEquipamiento_para_Ejercicios>("sp_DelEquipamiento_para_Ejercicios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEquipamiento_para_Ejercicios>("sp_InsEquipamiento_para_Ejercicios" , padreDescripcion
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

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

        public int Update(Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEquipamiento_para_Ejercicios>("sp_UpdEquipamiento_para_Ejercicios" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios Equipamiento_para_EjerciciosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEquipamiento_para_Ejercicios>("sp_UpdEquipamiento_para_Ejercicios" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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


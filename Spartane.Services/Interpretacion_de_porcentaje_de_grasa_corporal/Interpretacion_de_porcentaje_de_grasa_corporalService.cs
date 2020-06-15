using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Interpretacion_de_porcentaje_de_grasa_corporal
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Interpretacion_de_porcentaje_de_grasa_corporalService : IInterpretacion_de_porcentaje_de_grasa_corporalService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> _Interpretacion_de_porcentaje_de_grasa_corporalRepository;
        #endregion

        #region Ctor
        public Interpretacion_de_porcentaje_de_grasa_corporalService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> Interpretacion_de_porcentaje_de_grasa_corporalRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Interpretacion_de_porcentaje_de_grasa_corporalRepository = Interpretacion_de_porcentaje_de_grasa_corporalRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>("sp_SelAllInterpretacion_de_porcentaje_de_grasa_corporal");
        }

        public IList<Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallInterpretacion_de_porcentaje_de_grasa_corporal_Complete>("sp_SelAllComplete_Interpretacion_de_porcentaje_de_grasa_corporal");
            return data.Select(m => new Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Interpretacion_de_porcentaje_de_grasa_corporal>("sp_ListSelCount_Interpretacion_de_porcentaje_de_grasa_corporal", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllInterpretacion_de_porcentaje_de_grasa_corporal>("sp_ListSelAll_Interpretacion_de_porcentaje_de_grasa_corporal", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal
                {
                    Folio = m.Interpretacion_de_porcentaje_de_grasa_corporal_Folio,
                    Descripcion = m.Interpretacion_de_porcentaje_de_grasa_corporal_Descripcion,

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

        public IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllInterpretacion_de_porcentaje_de_grasa_corporal>("sp_ListSelAll_Interpretacion_de_porcentaje_de_grasa_corporal", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Interpretacion_de_porcentaje_de_grasa_corporalPagingModel result = null;

            if (data != null)
            {
                result = new Interpretacion_de_porcentaje_de_grasa_corporalPagingModel
                {
                    Interpretacion_de_porcentaje_de_grasa_corporals =
                        data.Select(m => new Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal
                {
                    Folio = m.Interpretacion_de_porcentaje_de_grasa_corporal_Folio
                    ,Descripcion = m.Interpretacion_de_porcentaje_de_grasa_corporal_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal>("sp_GetInterpretacion_de_porcentaje_de_grasa_corporal", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelInterpretacion_de_porcentaje_de_grasa_corporal>("sp_DelInterpretacion_de_porcentaje_de_grasa_corporal", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsInterpretacion_de_porcentaje_de_grasa_corporal>("sp_InsInterpretacion_de_porcentaje_de_grasa_corporal" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdInterpretacion_de_porcentaje_de_grasa_corporal>("sp_UpdInterpretacion_de_porcentaje_de_grasa_corporal" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal Interpretacion_de_porcentaje_de_grasa_corporalDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdInterpretacion_de_porcentaje_de_grasa_corporal>("sp_UpdInterpretacion_de_porcentaje_de_grasa_corporal" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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


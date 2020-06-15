using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Interpretacion_indice_cintura__cadera;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Interpretacion_indice_cintura__cadera
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Interpretacion_indice_cintura__caderaService : IInterpretacion_indice_cintura__caderaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> _Interpretacion_indice_cintura__caderaRepository;
        #endregion

        #region Ctor
        public Interpretacion_indice_cintura__caderaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> Interpretacion_indice_cintura__caderaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Interpretacion_indice_cintura__caderaRepository = Interpretacion_indice_cintura__caderaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>("sp_SelAllInterpretacion_indice_cintura__cadera");
        }

        public IList<Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallInterpretacion_indice_cintura__cadera_Complete>("sp_SelAllComplete_Interpretacion_indice_cintura__cadera");
            return data.Select(m => new Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Interpretacion_indice_cintura__cadera>("sp_ListSelCount_Interpretacion_indice_cintura__cadera", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllInterpretacion_indice_cintura__cadera>("sp_ListSelAll_Interpretacion_indice_cintura__cadera", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera
                {
                    Folio = m.Interpretacion_indice_cintura__cadera_Folio,
                    Descripcion = m.Interpretacion_indice_cintura__cadera_Descripcion,

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

        public IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllInterpretacion_indice_cintura__cadera>("sp_ListSelAll_Interpretacion_indice_cintura__cadera", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Interpretacion_indice_cintura__caderaPagingModel result = null;

            if (data != null)
            {
                result = new Interpretacion_indice_cintura__caderaPagingModel
                {
                    Interpretacion_indice_cintura__caderas =
                        data.Select(m => new Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera
                {
                    Folio = m.Interpretacion_indice_cintura__cadera_Folio
                    ,Descripcion = m.Interpretacion_indice_cintura__cadera_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>("sp_GetInterpretacion_indice_cintura__cadera", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelInterpretacion_indice_cintura__cadera>("sp_DelInterpretacion_indice_cintura__cadera", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsInterpretacion_indice_cintura__cadera>("sp_InsInterpretacion_indice_cintura__cadera" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdInterpretacion_indice_cintura__cadera>("sp_UpdInterpretacion_indice_cintura__cadera" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera Interpretacion_indice_cintura__caderaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdInterpretacion_indice_cintura__cadera>("sp_UpdInterpretacion_indice_cintura__cadera" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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


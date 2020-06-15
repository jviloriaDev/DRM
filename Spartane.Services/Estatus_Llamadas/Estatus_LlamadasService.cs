using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_Llamadas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Llamadas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_LlamadasService : IEstatus_LlamadasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> _Estatus_LlamadasRepository;
        #endregion

        #region Ctor
        public Estatus_LlamadasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> Estatus_LlamadasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_LlamadasRepository = Estatus_LlamadasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_LlamadasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas>("sp_SelAllEstatus_Llamadas");
        }

        public IList<Core.Classes.Estatus_Llamadas.Estatus_Llamadas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_Llamadas_Complete>("sp_SelAllComplete_Estatus_Llamadas");
            return data.Select(m => new Core.Classes.Estatus_Llamadas.Estatus_Llamadas
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_Llamadas>("sp_ListSelCount_Estatus_Llamadas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Llamadas>("sp_ListSelAll_Estatus_Llamadas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas
                {
                    Clave = m.Estatus_Llamadas_Clave,
                    Descripcion = m.Estatus_Llamadas_Descripcion,

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

        public IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_LlamadasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_LlamadasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Llamadas.Estatus_LlamadasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Llamadas>("sp_ListSelAll_Estatus_Llamadas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_LlamadasPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_LlamadasPagingModel
                {
                    Estatus_Llamadass =
                        data.Select(m => new Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas
                {
                    Clave = m.Estatus_Llamadas_Clave
                    ,Descripcion = m.Estatus_Llamadas_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_LlamadasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas>("sp_GetEstatus_Llamadas", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_Llamadas>("sp_DelEstatus_Llamadas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_Llamadas>("sp_InsEstatus_Llamadas" , padreDescripcion
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

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

        public int Update(Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Llamadas>("sp_UpdEstatus_Llamadas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas Estatus_LlamadasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Llamadas>("sp_UpdEstatus_Llamadas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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


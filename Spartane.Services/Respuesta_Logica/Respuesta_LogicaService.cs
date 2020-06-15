using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Respuesta_Logica;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Respuesta_Logica
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Respuesta_LogicaService : IRespuesta_LogicaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> _Respuesta_LogicaRepository;
        #endregion

        #region Ctor
        public Respuesta_LogicaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> Respuesta_LogicaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Respuesta_LogicaRepository = Respuesta_LogicaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Respuesta_LogicaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica>("sp_SelAllRespuesta_Logica");
        }

        public IList<Core.Classes.Respuesta_Logica.Respuesta_Logica> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRespuesta_Logica_Complete>("sp_SelAllComplete_Respuesta_Logica");
            return data.Select(m => new Core.Classes.Respuesta_Logica.Respuesta_Logica
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Respuesta_Logica>("sp_ListSelCount_Respuesta_Logica", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRespuesta_Logica>("sp_ListSelAll_Respuesta_Logica", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica
                {
                    Clave = m.Respuesta_Logica_Clave,
                    Descripcion = m.Respuesta_Logica_Descripcion,

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

        public IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Respuesta_LogicaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Respuesta_LogicaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Respuesta_Logica.Respuesta_LogicaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRespuesta_Logica>("sp_ListSelAll_Respuesta_Logica", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Respuesta_LogicaPagingModel result = null;

            if (data != null)
            {
                result = new Respuesta_LogicaPagingModel
                {
                    Respuesta_Logicas =
                        data.Select(m => new Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica
                {
                    Clave = m.Respuesta_Logica_Clave
                    ,Descripcion = m.Respuesta_Logica_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Respuesta_LogicaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica>("sp_GetRespuesta_Logica", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRespuesta_Logica>("sp_DelRespuesta_Logica", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRespuesta_Logica>("sp_InsRespuesta_Logica" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRespuesta_Logica>("sp_UpdRespuesta_Logica" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica Respuesta_LogicaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRespuesta_Logica>("sp_UpdRespuesta_Logica" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


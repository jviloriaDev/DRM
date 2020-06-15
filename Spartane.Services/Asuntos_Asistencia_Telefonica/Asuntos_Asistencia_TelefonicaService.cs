using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Asuntos_Asistencia_Telefonica;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Asuntos_Asistencia_Telefonica
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Asuntos_Asistencia_TelefonicaService : IAsuntos_Asistencia_TelefonicaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> _Asuntos_Asistencia_TelefonicaRepository;
        #endregion

        #region Ctor
        public Asuntos_Asistencia_TelefonicaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> Asuntos_Asistencia_TelefonicaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Asuntos_Asistencia_TelefonicaRepository = Asuntos_Asistencia_TelefonicaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>("sp_SelAllAsuntos_Asistencia_Telefonica");
        }

        public IList<Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallAsuntos_Asistencia_Telefonica_Complete>("sp_SelAllComplete_Asuntos_Asistencia_Telefonica");
            return data.Select(m => new Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Asuntos_Asistencia_Telefonica>("sp_ListSelCount_Asuntos_Asistencia_Telefonica", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllAsuntos_Asistencia_Telefonica>("sp_ListSelAll_Asuntos_Asistencia_Telefonica", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica
                {
                    Clave = m.Asuntos_Asistencia_Telefonica_Clave,
                    Descripcion = m.Asuntos_Asistencia_Telefonica_Descripcion,

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

        public IList<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_TelefonicaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllAsuntos_Asistencia_Telefonica>("sp_ListSelAll_Asuntos_Asistencia_Telefonica", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Asuntos_Asistencia_TelefonicaPagingModel result = null;

            if (data != null)
            {
                result = new Asuntos_Asistencia_TelefonicaPagingModel
                {
                    Asuntos_Asistencia_Telefonicas =
                        data.Select(m => new Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica
                {
                    Clave = m.Asuntos_Asistencia_Telefonica_Clave
                    ,Descripcion = m.Asuntos_Asistencia_Telefonica_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>("sp_GetAsuntos_Asistencia_Telefonica", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelAsuntos_Asistencia_Telefonica>("sp_DelAsuntos_Asistencia_Telefonica", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsAsuntos_Asistencia_Telefonica>("sp_InsAsuntos_Asistencia_Telefonica" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdAsuntos_Asistencia_Telefonica>("sp_UpdAsuntos_Asistencia_Telefonica" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica Asuntos_Asistencia_TelefonicaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdAsuntos_Asistencia_Telefonica>("sp_UpdAsuntos_Asistencia_Telefonica" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


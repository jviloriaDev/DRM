using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipos_de_Contrato;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipos_de_Contrato
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipos_de_ContratoService : ITipos_de_ContratoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> _Tipos_de_ContratoRepository;
        #endregion

        #region Ctor
        public Tipos_de_ContratoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> Tipos_de_ContratoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipos_de_ContratoRepository = Tipos_de_ContratoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipos_de_ContratoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato>("sp_SelAllTipos_de_Contrato");
        }

        public IList<Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipos_de_Contrato_Complete>("sp_SelAllComplete_Tipos_de_Contrato");
            return data.Select(m => new Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipos_de_Contrato>("sp_ListSelCount_Tipos_de_Contrato", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipos_de_Contrato>("sp_ListSelAll_Tipos_de_Contrato", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato
                {
                    Clave = m.Tipos_de_Contrato_Clave,
                    Descripcion = m.Tipos_de_Contrato_Descripcion,

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

        public IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipos_de_ContratoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipos_de_ContratoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_ContratoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipos_de_Contrato>("sp_ListSelAll_Tipos_de_Contrato", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipos_de_ContratoPagingModel result = null;

            if (data != null)
            {
                result = new Tipos_de_ContratoPagingModel
                {
                    Tipos_de_Contratos =
                        data.Select(m => new Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato
                {
                    Clave = m.Tipos_de_Contrato_Clave
                    ,Descripcion = m.Tipos_de_Contrato_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipos_de_ContratoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato>("sp_GetTipos_de_Contrato", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipos_de_Contrato>("sp_DelTipos_de_Contrato", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipos_de_Contrato>("sp_InsTipos_de_Contrato" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipos_de_Contrato>("sp_UpdTipos_de_Contrato" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato Tipos_de_ContratoDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipos_de_Contrato>("sp_UpdTipos_de_Contrato" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


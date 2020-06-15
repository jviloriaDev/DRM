using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Antecedentes_No_Patologicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Antecedentes_No_PatologicosService : IDetalle_Antecedentes_No_PatologicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> _Detalle_Antecedentes_No_PatologicosRepository;
        #endregion

        #region Ctor
        public Detalle_Antecedentes_No_PatologicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> Detalle_Antecedentes_No_PatologicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Antecedentes_No_PatologicosRepository = Detalle_Antecedentes_No_PatologicosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos>("sp_SelAllDetalle_Antecedentes_No_Patologicos");
        }

        public IList<Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Antecedentes_No_Patologicos_Complete>("sp_SelAllComplete_Detalle_Antecedentes_No_Patologicos");
            return data.Select(m => new Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Sustancia_Sustancias = new Core.Classes.Sustancias.Sustancias() { Clave = m.Sustancia.GetValueOrDefault(), Descripcion = m.Sustancia_Descripcion }
                ,Frecuencia_Frecuencia_Sustancias = new Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias() { Clave = m.Frecuencia.GetValueOrDefault(), Descripcion = m.Frecuencia_Descripcion }
                ,Cantidad = m.Cantidad


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Antecedentes_No_Patologicos>("sp_ListSelCount_Detalle_Antecedentes_No_Patologicos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Antecedentes_No_Patologicos>("sp_ListSelAll_Detalle_Antecedentes_No_Patologicos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos
                {
                    Folio = m.Detalle_Antecedentes_No_Patologicos_Folio,
                    Folio_Pacientes = m.Detalle_Antecedentes_No_Patologicos_Folio_Pacientes,
                    Sustancia = m.Detalle_Antecedentes_No_Patologicos_Sustancia,
                    Frecuencia = m.Detalle_Antecedentes_No_Patologicos_Frecuencia,
                    Cantidad = m.Detalle_Antecedentes_No_Patologicos_Cantidad,

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

        public IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_PatologicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Antecedentes_No_Patologicos>("sp_ListSelAll_Detalle_Antecedentes_No_Patologicos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Antecedentes_No_PatologicosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Antecedentes_No_PatologicosPagingModel
                {
                    Detalle_Antecedentes_No_Patologicoss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos
                {
                    Folio = m.Detalle_Antecedentes_No_Patologicos_Folio
                    ,Folio_Pacientes = m.Detalle_Antecedentes_No_Patologicos_Folio_Pacientes
                    ,Sustancia = m.Detalle_Antecedentes_No_Patologicos_Sustancia
                    ,Sustancia_Sustancias = new Core.Classes.Sustancias.Sustancias() { Clave = m.Detalle_Antecedentes_No_Patologicos_Sustancia.GetValueOrDefault(), Descripcion = m.Detalle_Antecedentes_No_Patologicos_Sustancia_Descripcion }
                    ,Frecuencia = m.Detalle_Antecedentes_No_Patologicos_Frecuencia
                    ,Frecuencia_Frecuencia_Sustancias = new Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias() { Clave = m.Detalle_Antecedentes_No_Patologicos_Frecuencia.GetValueOrDefault(), Descripcion = m.Detalle_Antecedentes_No_Patologicos_Frecuencia_Descripcion }
                    ,Cantidad = m.Detalle_Antecedentes_No_Patologicos_Cantidad

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos>("sp_GetDetalle_Antecedentes_No_Patologicos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Antecedentes_No_Patologicos>("sp_DelDetalle_Antecedentes_No_Patologicos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Pacientes = _dataProvider.GetParameter();
                padreFolio_Pacientes.ParameterName = "Folio_Pacientes";
                padreFolio_Pacientes.DbType = DbType.Int32;
                padreFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var padreSustancia = _dataProvider.GetParameter();
                padreSustancia.ParameterName = "Sustancia";
                padreSustancia.DbType = DbType.Int32;
                padreSustancia.Value = (object)entity.Sustancia ?? DBNull.Value;

                var padreFrecuencia = _dataProvider.GetParameter();
                padreFrecuencia.ParameterName = "Frecuencia";
                padreFrecuencia.DbType = DbType.Int32;
                padreFrecuencia.Value = (object)entity.Frecuencia ?? DBNull.Value;

                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.Int32;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Antecedentes_No_Patologicos>("sp_InsDetalle_Antecedentes_No_Patologicos" , padreFolio_Pacientes
, padreSustancia
, padreFrecuencia
, padreCantidad
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

        public int Update(Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var paramUpdSustancia = _dataProvider.GetParameter();
                paramUpdSustancia.ParameterName = "Sustancia";
                paramUpdSustancia.DbType = DbType.Int32;
                paramUpdSustancia.Value = (object)entity.Sustancia ?? DBNull.Value;

                var paramUpdFrecuencia = _dataProvider.GetParameter();
                paramUpdFrecuencia.ParameterName = "Frecuencia";
                paramUpdFrecuencia.DbType = DbType.Int32;
                paramUpdFrecuencia.Value = (object)entity.Frecuencia ?? DBNull.Value;

                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Antecedentes_No_Patologicos>("sp_UpdDetalle_Antecedentes_No_Patologicos" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdSustancia , paramUpdFrecuencia , paramUpdCantidad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos Detalle_Antecedentes_No_PatologicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
		var paramUpdSustancia = _dataProvider.GetParameter();
                paramUpdSustancia.ParameterName = "Sustancia";
                paramUpdSustancia.DbType = DbType.Int32;
                paramUpdSustancia.Value = (object)entity.Sustancia ?? DBNull.Value;
		var paramUpdFrecuencia = _dataProvider.GetParameter();
                paramUpdFrecuencia.ParameterName = "Frecuencia";
                paramUpdFrecuencia.DbType = DbType.Int32;
                paramUpdFrecuencia.Value = (object)entity.Frecuencia ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Antecedentes_No_Patologicos>("sp_UpdDetalle_Antecedentes_No_Patologicos" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdSustancia , paramUpdFrecuencia , paramUpdCantidad ).FirstOrDefault();

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


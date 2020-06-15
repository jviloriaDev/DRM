using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Examenes_Laboratorio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Examenes_Laboratorio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Examenes_LaboratorioService : IDetalle_Examenes_LaboratorioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> _Detalle_Examenes_LaboratorioRepository;
        #endregion

        #region Ctor
        public Detalle_Examenes_LaboratorioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> Detalle_Examenes_LaboratorioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Examenes_LaboratorioRepository = Detalle_Examenes_LaboratorioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio>("sp_SelAllDetalle_Examenes_Laboratorio");
        }

        public IList<Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Examenes_Laboratorio_Complete>("sp_SelAllComplete_Detalle_Examenes_Laboratorio");
            return data.Select(m => new Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Indicador_Indicadores_Laboratorio = new Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio() { Folio = m.Indicador.GetValueOrDefault(), Indicador = m.Indicador_Indicador }
                ,Resultado = m.Resultado
                ,Unidad = m.Unidad
                ,Intervalo_de_Referencia = m.Intervalo_de_Referencia
                ,Fecha_de_Resultado = m.Fecha_de_Resultado
                ,Estatus_Indicador = m.Estatus_Indicador


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Examenes_Laboratorio>("sp_ListSelCount_Detalle_Examenes_Laboratorio", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Examenes_Laboratorio>("sp_ListSelAll_Detalle_Examenes_Laboratorio", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio
                {
                    Folio = m.Detalle_Examenes_Laboratorio_Folio,
                    Folio_Pacientes = m.Detalle_Examenes_Laboratorio_Folio_Pacientes,
                    Indicador = m.Detalle_Examenes_Laboratorio_Indicador,
                    Resultado = m.Detalle_Examenes_Laboratorio_Resultado,
                    Unidad = m.Detalle_Examenes_Laboratorio_Unidad,
                    Intervalo_de_Referencia = m.Detalle_Examenes_Laboratorio_Intervalo_de_Referencia,
                    Fecha_de_Resultado = m.Detalle_Examenes_Laboratorio_Fecha_de_Resultado,
                    Estatus_Indicador = m.Detalle_Examenes_Laboratorio_Estatus_Indicador,

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

        public IList<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_LaboratorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Examenes_Laboratorio>("sp_ListSelAll_Detalle_Examenes_Laboratorio", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Examenes_LaboratorioPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Examenes_LaboratorioPagingModel
                {
                    Detalle_Examenes_Laboratorios =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio
                {
                    Folio = m.Detalle_Examenes_Laboratorio_Folio
                    ,Folio_Pacientes = m.Detalle_Examenes_Laboratorio_Folio_Pacientes
                    ,Indicador = m.Detalle_Examenes_Laboratorio_Indicador
                    ,Indicador_Indicadores_Laboratorio = new Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio() { Folio = m.Detalle_Examenes_Laboratorio_Indicador.GetValueOrDefault(), Indicador = m.Detalle_Examenes_Laboratorio_Indicador_Indicador }
                    ,Resultado = m.Detalle_Examenes_Laboratorio_Resultado
                    ,Unidad = m.Detalle_Examenes_Laboratorio_Unidad
                    ,Intervalo_de_Referencia = m.Detalle_Examenes_Laboratorio_Intervalo_de_Referencia
                    ,Fecha_de_Resultado = m.Detalle_Examenes_Laboratorio_Fecha_de_Resultado
                    ,Estatus_Indicador = m.Detalle_Examenes_Laboratorio_Estatus_Indicador

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio>("sp_GetDetalle_Examenes_Laboratorio", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Examenes_Laboratorio>("sp_DelDetalle_Examenes_Laboratorio", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio entity)
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
                var padreIndicador = _dataProvider.GetParameter();
                padreIndicador.ParameterName = "Indicador";
                padreIndicador.DbType = DbType.Int32;
                padreIndicador.Value = (object)entity.Indicador ?? DBNull.Value;

                var padreResultado = _dataProvider.GetParameter();
                padreResultado.ParameterName = "Resultado";
                padreResultado.DbType = DbType.Int32;
                padreResultado.Value = (object)entity.Resultado ?? DBNull.Value;

                var padreUnidad = _dataProvider.GetParameter();
                padreUnidad.ParameterName = "Unidad";
                padreUnidad.DbType = DbType.String;
                padreUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var padreIntervalo_de_Referencia = _dataProvider.GetParameter();
                padreIntervalo_de_Referencia.ParameterName = "Intervalo_de_Referencia";
                padreIntervalo_de_Referencia.DbType = DbType.String;
                padreIntervalo_de_Referencia.Value = (object)entity.Intervalo_de_Referencia ?? DBNull.Value;
                var padreFecha_de_Resultado = _dataProvider.GetParameter();
                padreFecha_de_Resultado.ParameterName = "Fecha_de_Resultado";
                padreFecha_de_Resultado.DbType = DbType.DateTime;
                padreFecha_de_Resultado.Value = (object)entity.Fecha_de_Resultado ?? DBNull.Value;

                var padreEstatus_Indicador = _dataProvider.GetParameter();
                padreEstatus_Indicador.ParameterName = "Estatus_Indicador";
                padreEstatus_Indicador.DbType = DbType.String;
                padreEstatus_Indicador.Value = (object)entity.Estatus_Indicador ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Examenes_Laboratorio>("sp_InsDetalle_Examenes_Laboratorio" , padreFolio_Pacientes
, padreIndicador
, padreResultado
, padreUnidad
, padreIntervalo_de_Referencia
, padreFecha_de_Resultado
, padreEstatus_Indicador
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

        public int Update(Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio entity)
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
                var paramUpdIndicador = _dataProvider.GetParameter();
                paramUpdIndicador.ParameterName = "Indicador";
                paramUpdIndicador.DbType = DbType.Int32;
                paramUpdIndicador.Value = (object)entity.Indicador ?? DBNull.Value;

                var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)entity.Resultado ?? DBNull.Value;

                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.String;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdIntervalo_de_Referencia = _dataProvider.GetParameter();
                paramUpdIntervalo_de_Referencia.ParameterName = "Intervalo_de_Referencia";
                paramUpdIntervalo_de_Referencia.DbType = DbType.String;
                paramUpdIntervalo_de_Referencia.Value = (object)entity.Intervalo_de_Referencia ?? DBNull.Value;
                var paramUpdFecha_de_Resultado = _dataProvider.GetParameter();
                paramUpdFecha_de_Resultado.ParameterName = "Fecha_de_Resultado";
                paramUpdFecha_de_Resultado.DbType = DbType.DateTime;
                paramUpdFecha_de_Resultado.Value = (object)entity.Fecha_de_Resultado ?? DBNull.Value;

                var paramUpdEstatus_Indicador = _dataProvider.GetParameter();
                paramUpdEstatus_Indicador.ParameterName = "Estatus_Indicador";
                paramUpdEstatus_Indicador.DbType = DbType.String;
                paramUpdEstatus_Indicador.Value = (object)entity.Estatus_Indicador ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Examenes_Laboratorio>("sp_UpdDetalle_Examenes_Laboratorio" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdIndicador , paramUpdResultado , paramUpdUnidad , paramUpdIntervalo_de_Referencia , paramUpdFecha_de_Resultado , paramUpdEstatus_Indicador ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio Detalle_Examenes_LaboratorioDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
		var paramUpdIndicador = _dataProvider.GetParameter();
                paramUpdIndicador.ParameterName = "Indicador";
                paramUpdIndicador.DbType = DbType.Int32;
                paramUpdIndicador.Value = (object)entity.Indicador ?? DBNull.Value;
                var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)entity.Resultado ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.String;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdIntervalo_de_Referencia = _dataProvider.GetParameter();
                paramUpdIntervalo_de_Referencia.ParameterName = "Intervalo_de_Referencia";
                paramUpdIntervalo_de_Referencia.DbType = DbType.String;
                paramUpdIntervalo_de_Referencia.Value = (object)entity.Intervalo_de_Referencia ?? DBNull.Value;
                var paramUpdFecha_de_Resultado = _dataProvider.GetParameter();
                paramUpdFecha_de_Resultado.ParameterName = "Fecha_de_Resultado";
                paramUpdFecha_de_Resultado.DbType = DbType.DateTime;
                paramUpdFecha_de_Resultado.Value = (object)entity.Fecha_de_Resultado ?? DBNull.Value;
                var paramUpdEstatus_Indicador = _dataProvider.GetParameter();
                paramUpdEstatus_Indicador.ParameterName = "Estatus_Indicador";
                paramUpdEstatus_Indicador.DbType = DbType.String;
                paramUpdEstatus_Indicador.Value = (object)entity.Estatus_Indicador ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Examenes_Laboratorio>("sp_UpdDetalle_Examenes_Laboratorio" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdIndicador , paramUpdResultado , paramUpdUnidad , paramUpdIntervalo_de_Referencia , paramUpdFecha_de_Resultado , paramUpdEstatus_Indicador ).FirstOrDefault();

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


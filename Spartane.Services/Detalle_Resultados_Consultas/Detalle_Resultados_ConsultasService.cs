using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Resultados_Consultas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Resultados_Consultas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Resultados_ConsultasService : IDetalle_Resultados_ConsultasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> _Detalle_Resultados_ConsultasRepository;
        #endregion

        #region Ctor
        public Detalle_Resultados_ConsultasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> Detalle_Resultados_ConsultasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Resultados_ConsultasRepository = Detalle_Resultados_ConsultasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas>("sp_SelAllDetalle_Resultados_Consultas");
        }

        public IList<Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Resultados_Consultas_Complete>("sp_SelAllComplete_Detalle_Resultados_Consultas");
            return data.Select(m => new Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas
            {
                Folio = m.Folio
                ,Folio_Consultas = m.Folio_Consultas
                ,Folio_Pacientes_Pacientes = new Core.Classes.Pacientes.Pacientes() { Folio = m.Folio_Pacientes.GetValueOrDefault(), Nombre_Completo = m.Folio_Pacientes_Nombre_Completo }
                ,Fecha_de_Consulta = m.Fecha_de_Consulta
                ,Indicador_Indicadores_Consultas = new Core.Classes.Indicadores_Consultas.Indicadores_Consultas() { Clave = m.Indicador.GetValueOrDefault(), Nombre = m.Indicador_Nombre }
                ,Resultado = m.Resultado
                ,Interpretacion = m.Interpretacion
                ,IMC = m.IMC
                ,IMC_Pediatria = m.IMC_Pediatria


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Resultados_Consultas>("sp_ListSelCount_Detalle_Resultados_Consultas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Resultados_Consultas>("sp_ListSelAll_Detalle_Resultados_Consultas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas
                {
                    Folio = m.Detalle_Resultados_Consultas_Folio,
                    Folio_Consultas = m.Detalle_Resultados_Consultas_Folio_Consultas,
                    Folio_Pacientes = m.Detalle_Resultados_Consultas_Folio_Pacientes,
                    Fecha_de_Consulta = m.Detalle_Resultados_Consultas_Fecha_de_Consulta,
                    Indicador = m.Detalle_Resultados_Consultas_Indicador,
                    Resultado = m.Detalle_Resultados_Consultas_Resultado,
                    Interpretacion = m.Detalle_Resultados_Consultas_Interpretacion,
                    IMC = m.Detalle_Resultados_Consultas_IMC,
                    IMC_Pediatria = m.Detalle_Resultados_Consultas_IMC_Pediatria,

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

        public IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Resultados_Consultas>("sp_ListSelAll_Detalle_Resultados_Consultas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Resultados_ConsultasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Resultados_ConsultasPagingModel
                {
                    Detalle_Resultados_Consultass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas
                {
                    Folio = m.Detalle_Resultados_Consultas_Folio
                    ,Folio_Consultas = m.Detalle_Resultados_Consultas_Folio_Consultas
                    ,Folio_Pacientes = m.Detalle_Resultados_Consultas_Folio_Pacientes
                    ,Folio_Pacientes_Pacientes = new Core.Classes.Pacientes.Pacientes() { Folio = m.Detalle_Resultados_Consultas_Folio_Pacientes.GetValueOrDefault(), Nombre_Completo = m.Detalle_Resultados_Consultas_Folio_Pacientes_Nombre_Completo }
                    ,Fecha_de_Consulta = m.Detalle_Resultados_Consultas_Fecha_de_Consulta
                    ,Indicador = m.Detalle_Resultados_Consultas_Indicador
                    ,Indicador_Indicadores_Consultas = new Core.Classes.Indicadores_Consultas.Indicadores_Consultas() { Clave = m.Detalle_Resultados_Consultas_Indicador.GetValueOrDefault(), Nombre = m.Detalle_Resultados_Consultas_Indicador_Nombre }
                    ,Resultado = m.Detalle_Resultados_Consultas_Resultado
                    ,Interpretacion = m.Detalle_Resultados_Consultas_Interpretacion
                    ,IMC = m.Detalle_Resultados_Consultas_IMC
                    ,IMC_Pediatria = m.Detalle_Resultados_Consultas_IMC_Pediatria

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas>("sp_GetDetalle_Resultados_Consultas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Resultados_Consultas>("sp_DelDetalle_Resultados_Consultas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Consultas = _dataProvider.GetParameter();
                padreFolio_Consultas.ParameterName = "Folio_Consultas";
                padreFolio_Consultas.DbType = DbType.Int32;
                padreFolio_Consultas.Value = (object)entity.Folio_Consultas ?? DBNull.Value;
                var padreFolio_Pacientes = _dataProvider.GetParameter();
                padreFolio_Pacientes.ParameterName = "Folio_Pacientes";
                padreFolio_Pacientes.DbType = DbType.Int32;
                padreFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;

                var padreFecha_de_Consulta = _dataProvider.GetParameter();
                padreFecha_de_Consulta.ParameterName = "Fecha_de_Consulta";
                padreFecha_de_Consulta.DbType = DbType.DateTime;
                padreFecha_de_Consulta.Value = (object)entity.Fecha_de_Consulta ?? DBNull.Value;

                var padreIndicador = _dataProvider.GetParameter();
                padreIndicador.ParameterName = "Indicador";
                padreIndicador.DbType = DbType.Int32;
                padreIndicador.Value = (object)entity.Indicador ?? DBNull.Value;

                var padreResultado = _dataProvider.GetParameter();
                padreResultado.ParameterName = "Resultado";
                padreResultado.DbType = DbType.Int32;
                padreResultado.Value = (object)entity.Resultado ?? DBNull.Value;

                var padreInterpretacion = _dataProvider.GetParameter();
                padreInterpretacion.ParameterName = "Interpretacion";
                padreInterpretacion.DbType = DbType.String;
                padreInterpretacion.Value = (object)entity.Interpretacion ?? DBNull.Value;
                var padreIMC = _dataProvider.GetParameter();
                padreIMC.ParameterName = "IMC";
                padreIMC.DbType = DbType.Int32;
                padreIMC.Value = (object)entity.IMC ?? DBNull.Value;

                var padreIMC_Pediatria = _dataProvider.GetParameter();
                padreIMC_Pediatria.ParameterName = "IMC_Pediatria";
                padreIMC_Pediatria.DbType = DbType.Int32;
                padreIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Resultados_Consultas>("sp_InsDetalle_Resultados_Consultas" , padreFolio_Consultas
, padreFolio_Pacientes
, padreFecha_de_Consulta
, padreIndicador
, padreResultado
, padreInterpretacion
, padreIMC
, padreIMC_Pediatria
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

        public int Update(Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Consultas = _dataProvider.GetParameter();
                paramUpdFolio_Consultas.ParameterName = "Folio_Consultas";
                paramUpdFolio_Consultas.DbType = DbType.Int32;
                paramUpdFolio_Consultas.Value = (object)entity.Folio_Consultas ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;

                var paramUpdFecha_de_Consulta = _dataProvider.GetParameter();
                paramUpdFecha_de_Consulta.ParameterName = "Fecha_de_Consulta";
                paramUpdFecha_de_Consulta.DbType = DbType.DateTime;
                paramUpdFecha_de_Consulta.Value = (object)entity.Fecha_de_Consulta ?? DBNull.Value;

                var paramUpdIndicador = _dataProvider.GetParameter();
                paramUpdIndicador.ParameterName = "Indicador";
                paramUpdIndicador.DbType = DbType.Int32;
                paramUpdIndicador.Value = (object)entity.Indicador ?? DBNull.Value;

                var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)entity.Resultado ?? DBNull.Value;

                var paramUpdInterpretacion = _dataProvider.GetParameter();
                paramUpdInterpretacion.ParameterName = "Interpretacion";
                paramUpdInterpretacion.DbType = DbType.String;
                paramUpdInterpretacion.Value = (object)entity.Interpretacion ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)entity.IMC ?? DBNull.Value;

                var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Resultados_Consultas>("sp_UpdDetalle_Resultados_Consultas" , paramUpdFolio , paramUpdFolio_Consultas , paramUpdFolio_Pacientes , paramUpdFecha_de_Consulta , paramUpdIndicador , paramUpdResultado , paramUpdInterpretacion , paramUpdIMC , paramUpdIMC_Pediatria ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas Detalle_Resultados_ConsultasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Consultas = _dataProvider.GetParameter();
                paramUpdFolio_Consultas.ParameterName = "Folio_Consultas";
                paramUpdFolio_Consultas.DbType = DbType.Int32;
                paramUpdFolio_Consultas.Value = (object)entity.Folio_Consultas ?? DBNull.Value;
		var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var paramUpdFecha_de_Consulta = _dataProvider.GetParameter();
                paramUpdFecha_de_Consulta.ParameterName = "Fecha_de_Consulta";
                paramUpdFecha_de_Consulta.DbType = DbType.DateTime;
                paramUpdFecha_de_Consulta.Value = (object)entity.Fecha_de_Consulta ?? DBNull.Value;
		var paramUpdIndicador = _dataProvider.GetParameter();
                paramUpdIndicador.ParameterName = "Indicador";
                paramUpdIndicador.DbType = DbType.Int32;
                paramUpdIndicador.Value = (object)entity.Indicador ?? DBNull.Value;
                var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)entity.Resultado ?? DBNull.Value;
                var paramUpdInterpretacion = _dataProvider.GetParameter();
                paramUpdInterpretacion.ParameterName = "Interpretacion";
                paramUpdInterpretacion.DbType = DbType.String;
                paramUpdInterpretacion.Value = (object)entity.Interpretacion ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)entity.IMC ?? DBNull.Value;
                var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Resultados_Consultas>("sp_UpdDetalle_Resultados_Consultas" , paramUpdFolio , paramUpdFolio_Consultas , paramUpdFolio_Pacientes , paramUpdFecha_de_Consulta , paramUpdIndicador , paramUpdResultado , paramUpdInterpretacion , paramUpdIMC , paramUpdIMC_Pediatria ).FirstOrDefault();

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


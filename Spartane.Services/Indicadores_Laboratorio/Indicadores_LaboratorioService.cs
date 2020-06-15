using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Indicadores_Laboratorio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Indicadores_Laboratorio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Indicadores_LaboratorioService : IIndicadores_LaboratorioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> _Indicadores_LaboratorioRepository;
        #endregion

        #region Ctor
        public Indicadores_LaboratorioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> Indicadores_LaboratorioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Indicadores_LaboratorioRepository = Indicadores_LaboratorioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Indicadores_LaboratorioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio>("sp_SelAllIndicadores_Laboratorio");
        }

        public IList<Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallIndicadores_Laboratorio_Complete>("sp_SelAllComplete_Indicadores_Laboratorio");
            return data.Select(m => new Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio
            {
                Folio = m.Folio
                ,Indicador = m.Indicador
                ,Unidad_de_Medida = m.Unidad_de_Medida
                ,Limite_inferior = m.Limite_inferior
                ,Limite_superior = m.Limite_superior


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Indicadores_Laboratorio>("sp_ListSelCount_Indicadores_Laboratorio", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllIndicadores_Laboratorio>("sp_ListSelAll_Indicadores_Laboratorio", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio
                {
                    Folio = m.Indicadores_Laboratorio_Folio,
                    Indicador = m.Indicadores_Laboratorio_Indicador,
                    Unidad_de_Medida = m.Indicadores_Laboratorio_Unidad_de_Medida,
                    Limite_inferior = m.Indicadores_Laboratorio_Limite_inferior,
                    Limite_superior = m.Indicadores_Laboratorio_Limite_superior,

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

        public IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Indicadores_LaboratorioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Indicadores_LaboratorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_LaboratorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllIndicadores_Laboratorio>("sp_ListSelAll_Indicadores_Laboratorio", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Indicadores_LaboratorioPagingModel result = null;

            if (data != null)
            {
                result = new Indicadores_LaboratorioPagingModel
                {
                    Indicadores_Laboratorios =
                        data.Select(m => new Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio
                {
                    Folio = m.Indicadores_Laboratorio_Folio
                    ,Indicador = m.Indicadores_Laboratorio_Indicador
                    ,Unidad_de_Medida = m.Indicadores_Laboratorio_Unidad_de_Medida
                    ,Limite_inferior = m.Indicadores_Laboratorio_Limite_inferior
                    ,Limite_superior = m.Indicadores_Laboratorio_Limite_superior

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Indicadores_LaboratorioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio>("sp_GetIndicadores_Laboratorio", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelIndicadores_Laboratorio>("sp_DelIndicadores_Laboratorio", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreIndicador = _dataProvider.GetParameter();
                padreIndicador.ParameterName = "Indicador";
                padreIndicador.DbType = DbType.String;
                padreIndicador.Value = (object)entity.Indicador ?? DBNull.Value;
                var padreUnidad_de_Medida = _dataProvider.GetParameter();
                padreUnidad_de_Medida.ParameterName = "Unidad_de_Medida";
                padreUnidad_de_Medida.DbType = DbType.String;
                padreUnidad_de_Medida.Value = (object)entity.Unidad_de_Medida ?? DBNull.Value;
                var padreLimite_inferior = _dataProvider.GetParameter();
                padreLimite_inferior.ParameterName = "Limite_inferior";
                padreLimite_inferior.DbType = DbType.Int32;
                padreLimite_inferior.Value = (object)entity.Limite_inferior ?? DBNull.Value;

                var padreLimite_superior = _dataProvider.GetParameter();
                padreLimite_superior.ParameterName = "Limite_superior";
                padreLimite_superior.DbType = DbType.Int32;
                padreLimite_superior.Value = (object)entity.Limite_superior ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsIndicadores_Laboratorio>("sp_InsIndicadores_Laboratorio" , padreIndicador
, padreUnidad_de_Medida
, padreLimite_inferior
, padreLimite_superior
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

        public int Update(Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdIndicador = _dataProvider.GetParameter();
                paramUpdIndicador.ParameterName = "Indicador";
                paramUpdIndicador.DbType = DbType.String;
                paramUpdIndicador.Value = (object)entity.Indicador ?? DBNull.Value;
                var paramUpdUnidad_de_Medida = _dataProvider.GetParameter();
                paramUpdUnidad_de_Medida.ParameterName = "Unidad_de_Medida";
                paramUpdUnidad_de_Medida.DbType = DbType.String;
                paramUpdUnidad_de_Medida.Value = (object)entity.Unidad_de_Medida ?? DBNull.Value;
                var paramUpdLimite_inferior = _dataProvider.GetParameter();
                paramUpdLimite_inferior.ParameterName = "Limite_inferior";
                paramUpdLimite_inferior.DbType = DbType.Int32;
                paramUpdLimite_inferior.Value = (object)entity.Limite_inferior ?? DBNull.Value;

                var paramUpdLimite_superior = _dataProvider.GetParameter();
                paramUpdLimite_superior.ParameterName = "Limite_superior";
                paramUpdLimite_superior.DbType = DbType.Int32;
                paramUpdLimite_superior.Value = (object)entity.Limite_superior ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdIndicadores_Laboratorio>("sp_UpdIndicadores_Laboratorio" , paramUpdFolio , paramUpdIndicador , paramUpdUnidad_de_Medida , paramUpdLimite_inferior , paramUpdLimite_superior ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio Indicadores_LaboratorioDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdIndicador = _dataProvider.GetParameter();
                paramUpdIndicador.ParameterName = "Indicador";
                paramUpdIndicador.DbType = DbType.String;
                paramUpdIndicador.Value = (object)entity.Indicador ?? DBNull.Value;
                var paramUpdUnidad_de_Medida = _dataProvider.GetParameter();
                paramUpdUnidad_de_Medida.ParameterName = "Unidad_de_Medida";
                paramUpdUnidad_de_Medida.DbType = DbType.String;
                paramUpdUnidad_de_Medida.Value = (object)entity.Unidad_de_Medida ?? DBNull.Value;
                var paramUpdLimite_inferior = _dataProvider.GetParameter();
                paramUpdLimite_inferior.ParameterName = "Limite_inferior";
                paramUpdLimite_inferior.DbType = DbType.Int32;
                paramUpdLimite_inferior.Value = (object)entity.Limite_inferior ?? DBNull.Value;
                var paramUpdLimite_superior = _dataProvider.GetParameter();
                paramUpdLimite_superior.ParameterName = "Limite_superior";
                paramUpdLimite_superior.DbType = DbType.Int32;
                paramUpdLimite_superior.Value = (object)entity.Limite_superior ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdIndicadores_Laboratorio>("sp_UpdIndicadores_Laboratorio" , paramUpdFolio , paramUpdIndicador , paramUpdUnidad_de_Medida , paramUpdLimite_inferior , paramUpdLimite_superior ).FirstOrDefault();

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


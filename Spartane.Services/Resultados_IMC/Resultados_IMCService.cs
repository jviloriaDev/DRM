using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Resultados_IMC;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Resultados_IMC
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Resultados_IMCService : IResultados_IMCService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC> _Resultados_IMCRepository;
        #endregion

        #region Ctor
        public Resultados_IMCService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC> Resultados_IMCRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Resultados_IMCRepository = Resultados_IMCRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Resultados_IMCRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC>("sp_SelAllResultados_IMC");
        }

        public IList<Core.Classes.Resultados_IMC.Resultados_IMC> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallResultados_IMC_Complete>("sp_SelAllComplete_Resultados_IMC");
            return data.Select(m => new Core.Classes.Resultados_IMC.Resultados_IMC
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Fecha = m.Fecha
                ,IMC = m.IMC
                ,Estatus = m.Estatus


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Resultados_IMC>("sp_ListSelCount_Resultados_IMC", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllResultados_IMC>("sp_ListSelAll_Resultados_IMC", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Resultados_IMC.Resultados_IMC
                {
                    Folio = m.Resultados_IMC_Folio,
                    Folio_Pacientes = m.Resultados_IMC_Folio_Pacientes,
                    Fecha = m.Resultados_IMC_Fecha,
                    IMC = m.Resultados_IMC_IMC,
                    Estatus = m.Resultados_IMC_Estatus,

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

        public IList<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Resultados_IMCRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Resultados_IMCRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Resultados_IMC.Resultados_IMCPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllResultados_IMC>("sp_ListSelAll_Resultados_IMC", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Resultados_IMCPagingModel result = null;

            if (data != null)
            {
                result = new Resultados_IMCPagingModel
                {
                    Resultados_IMCs =
                        data.Select(m => new Spartane.Core.Classes.Resultados_IMC.Resultados_IMC
                {
                    Folio = m.Resultados_IMC_Folio
                    ,Folio_Pacientes = m.Resultados_IMC_Folio_Pacientes
                    ,Fecha = m.Resultados_IMC_Fecha
                    ,IMC = m.Resultados_IMC_IMC
                    ,Estatus = m.Resultados_IMC_Estatus

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Resultados_IMCRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Resultados_IMC.Resultados_IMC GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC>("sp_GetResultados_IMC", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelResultados_IMC>("sp_DelResultados_IMC", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Resultados_IMC.Resultados_IMC entity)
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
                var padreFecha = _dataProvider.GetParameter();
                padreFecha.ParameterName = "Fecha";
                padreFecha.DbType = DbType.DateTime;
                padreFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var padreIMC = _dataProvider.GetParameter();
                padreIMC.ParameterName = "IMC";
                padreIMC.DbType = DbType.Int32;
                padreIMC.Value = (object)entity.IMC ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.String;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsResultados_IMC>("sp_InsResultados_IMC" , padreFolio_Pacientes
, padreFecha
, padreIMC
, padreEstatus
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

        public int Update(Spartane.Core.Classes.Resultados_IMC.Resultados_IMC entity)
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
                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)entity.IMC ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.String;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdResultados_IMC>("sp_UpdResultados_IMC" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdFecha , paramUpdIMC , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Resultados_IMC.Resultados_IMC entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Resultados_IMC.Resultados_IMC Resultados_IMCDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)entity.IMC ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.String;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdResultados_IMC>("sp_UpdResultados_IMC" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdFecha , paramUpdIMC , paramUpdEstatus ).FirstOrDefault();

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


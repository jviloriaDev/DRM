using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Exclusion_Ingredientes_Paciente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Exclusion_Ingredientes_PacienteService : IMS_Exclusion_Ingredientes_PacienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> _MS_Exclusion_Ingredientes_PacienteRepository;
        #endregion

        #region Ctor
        public MS_Exclusion_Ingredientes_PacienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> MS_Exclusion_Ingredientes_PacienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Exclusion_Ingredientes_PacienteRepository = MS_Exclusion_Ingredientes_PacienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>("sp_SelAllMS_Exclusion_Ingredientes_Paciente");
        }

        public IList<Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Exclusion_Ingredientes_Paciente_Complete>("sp_SelAllComplete_MS_Exclusion_Ingredientes_Paciente");
            return data.Select(m => new Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.Ingrediente_Nombre_Ingrediente }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Exclusion_Ingredientes_Paciente>("sp_ListSelCount_MS_Exclusion_Ingredientes_Paciente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Exclusion_Ingredientes_Paciente>("sp_ListSelAll_MS_Exclusion_Ingredientes_Paciente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente
                {
                    Folio = m.MS_Exclusion_Ingredientes_Paciente_Folio,
                    Folio_Pacientes = m.MS_Exclusion_Ingredientes_Paciente_Folio_Pacientes,
                    Ingrediente = m.MS_Exclusion_Ingredientes_Paciente_Ingrediente,

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

        public IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Exclusion_Ingredientes_Paciente>("sp_ListSelAll_MS_Exclusion_Ingredientes_Paciente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Exclusion_Ingredientes_PacientePagingModel result = null;

            if (data != null)
            {
                result = new MS_Exclusion_Ingredientes_PacientePagingModel
                {
                    MS_Exclusion_Ingredientes_Pacientes =
                        data.Select(m => new Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente
                {
                    Folio = m.MS_Exclusion_Ingredientes_Paciente_Folio
                    ,Folio_Pacientes = m.MS_Exclusion_Ingredientes_Paciente_Folio_Pacientes
                    ,Ingrediente = m.MS_Exclusion_Ingredientes_Paciente_Ingrediente
                    ,Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.MS_Exclusion_Ingredientes_Paciente_Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.MS_Exclusion_Ingredientes_Paciente_Ingrediente_Nombre_Ingrediente }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>("sp_GetMS_Exclusion_Ingredientes_Paciente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Exclusion_Ingredientes_Paciente>("sp_DelMS_Exclusion_Ingredientes_Paciente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity)
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
                var padreIngrediente = _dataProvider.GetParameter();
                padreIngrediente.ParameterName = "Ingrediente";
                padreIngrediente.DbType = DbType.Int32;
                padreIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Exclusion_Ingredientes_Paciente>("sp_InsMS_Exclusion_Ingredientes_Paciente" , padreFolio_Pacientes
, padreIngrediente
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

        public int Update(Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity)
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
                var paramUpdIngrediente = _dataProvider.GetParameter();
                paramUpdIngrediente.ParameterName = "Ingrediente";
                paramUpdIngrediente.DbType = DbType.Int32;
                paramUpdIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Exclusion_Ingredientes_Paciente>("sp_UpdMS_Exclusion_Ingredientes_Paciente" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdIngrediente ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente MS_Exclusion_Ingredientes_PacienteDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
		var paramUpdIngrediente = _dataProvider.GetParameter();
                paramUpdIngrediente.ParameterName = "Ingrediente";
                paramUpdIngrediente.DbType = DbType.Int32;
                paramUpdIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Exclusion_Ingredientes_Paciente>("sp_UpdMS_Exclusion_Ingredientes_Paciente" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdIngrediente ).FirstOrDefault();

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


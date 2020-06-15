using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_Paciente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Paciente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_PacienteService : IEstatus_PacienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente> _Estatus_PacienteRepository;
        #endregion

        #region Ctor
        public Estatus_PacienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente> Estatus_PacienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_PacienteRepository = Estatus_PacienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_PacienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente>("sp_SelAllEstatus_Paciente");
        }

        public IList<Core.Classes.Estatus_Paciente.Estatus_Paciente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_Paciente_Complete>("sp_SelAllComplete_Estatus_Paciente");
            return data.Select(m => new Core.Classes.Estatus_Paciente.Estatus_Paciente
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_Paciente>("sp_ListSelCount_Estatus_Paciente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Paciente>("sp_ListSelAll_Estatus_Paciente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente
                {
                    Clave = m.Estatus_Paciente_Clave,
                    Descripcion = m.Estatus_Paciente_Descripcion,

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

        public IList<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Paciente.Estatus_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Paciente>("sp_ListSelAll_Estatus_Paciente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_PacientePagingModel result = null;

            if (data != null)
            {
                result = new Estatus_PacientePagingModel
                {
                    Estatus_Pacientes =
                        data.Select(m => new Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente
                {
                    Clave = m.Estatus_Paciente_Clave
                    ,Descripcion = m.Estatus_Paciente_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente>("sp_GetEstatus_Paciente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_Paciente>("sp_DelEstatus_Paciente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_Paciente>("sp_InsEstatus_Paciente" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Paciente>("sp_UpdEstatus_Paciente" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente Estatus_PacienteDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Paciente>("sp_UpdEstatus_Paciente" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


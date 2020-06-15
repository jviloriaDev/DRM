using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipo_Paciente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_Paciente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_PacienteService : ITipo_PacienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente> _Tipo_PacienteRepository;
        #endregion

        #region Ctor
        public Tipo_PacienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente> Tipo_PacienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_PacienteRepository = Tipo_PacienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipo_PacienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente>("sp_SelAllTipo_Paciente");
        }

        public IList<Core.Classes.Tipo_Paciente.Tipo_Paciente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipo_Paciente_Complete>("sp_SelAllComplete_Tipo_Paciente");
            return data.Select(m => new Core.Classes.Tipo_Paciente.Tipo_Paciente
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion
                ,Clave_Rol = m.Clave_Rol


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipo_Paciente>("sp_ListSelCount_Tipo_Paciente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_Paciente>("sp_ListSelAll_Tipo_Paciente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente
                {
                    Clave = m.Tipo_Paciente_Clave,
                    Descripcion = m.Tipo_Paciente_Descripcion,
                    Clave_Rol = m.Tipo_Paciente_Clave_Rol,

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

        public IList<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_Paciente.Tipo_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_Paciente>("sp_ListSelAll_Tipo_Paciente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipo_PacientePagingModel result = null;

            if (data != null)
            {
                result = new Tipo_PacientePagingModel
                {
                    Tipo_Pacientes =
                        data.Select(m => new Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente
                {
                    Clave = m.Tipo_Paciente_Clave
                    ,Descripcion = m.Tipo_Paciente_Descripcion
                    ,Clave_Rol = m.Tipo_Paciente_Clave_Rol

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente>("sp_GetTipo_Paciente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipo_Paciente>("sp_DelTipo_Paciente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente entity)
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
                var padreClave_Rol = _dataProvider.GetParameter();
                padreClave_Rol.ParameterName = "Clave_Rol";
                padreClave_Rol.DbType = DbType.Int32;
                padreClave_Rol.Value = (object)entity.Clave_Rol ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipo_Paciente>("sp_InsTipo_Paciente" , padreDescripcion
, padreClave_Rol
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

        public int Update(Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente entity)
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
                var paramUpdClave_Rol = _dataProvider.GetParameter();
                paramUpdClave_Rol.ParameterName = "Clave_Rol";
                paramUpdClave_Rol.DbType = DbType.Int32;
                paramUpdClave_Rol.Value = (object)entity.Clave_Rol ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_Paciente>("sp_UpdTipo_Paciente" , paramUpdClave , paramUpdDescripcion , paramUpdClave_Rol ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente Tipo_PacienteDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdClave_Rol = _dataProvider.GetParameter();
                paramUpdClave_Rol.ParameterName = "Clave_Rol";
                paramUpdClave_Rol.DbType = DbType.Int32;
                paramUpdClave_Rol.Value = (object)entity.Clave_Rol ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_Paciente>("sp_UpdTipo_Paciente" , paramUpdClave , paramUpdDescripcion , paramUpdClave_Rol ).FirstOrDefault();

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


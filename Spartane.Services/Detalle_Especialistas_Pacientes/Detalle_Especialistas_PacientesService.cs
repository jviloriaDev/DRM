using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Especialistas_Pacientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Especialistas_Pacientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Especialistas_PacientesService : IDetalle_Especialistas_PacientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> _Detalle_Especialistas_PacientesRepository;
        #endregion

        #region Ctor
        public Detalle_Especialistas_PacientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> Detalle_Especialistas_PacientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Especialistas_PacientesRepository = Detalle_Especialistas_PacientesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>("sp_SelAllDetalle_Especialistas_Pacientes");
        }

        public IList<Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Especialistas_Pacientes_Complete>("sp_SelAllComplete_Detalle_Especialistas_Pacientes");
            return data.Select(m => new Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Especialista_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Especialista.GetValueOrDefault(), Name = m.Especialista_Name }
                ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Especialidad.GetValueOrDefault(), Especialidad = m.Especialidad_Especialidad }
                ,Fecha_inicio = m.Fecha_inicio
                ,Fecha_fin = m.Fecha_fin
                ,Cantidad_consultas = m.Cantidad_consultas
                ,Principal = m.Principal.GetValueOrDefault()
                ,Estatus_Estatus_Paciente = new Core.Classes.Estatus_Paciente.Estatus_Paciente() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Especialistas_Pacientes>("sp_ListSelCount_Detalle_Especialistas_Pacientes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Especialistas_Pacientes>("sp_ListSelAll_Detalle_Especialistas_Pacientes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes
                {
                    Folio = m.Detalle_Especialistas_Pacientes_Folio,
                    Folio_Pacientes = m.Detalle_Especialistas_Pacientes_Folio_Pacientes,
                    Especialista = m.Detalle_Especialistas_Pacientes_Especialista,
                    Especialidad = m.Detalle_Especialistas_Pacientes_Especialidad,
                    Fecha_inicio = m.Detalle_Especialistas_Pacientes_Fecha_inicio,
                    Fecha_fin = m.Detalle_Especialistas_Pacientes_Fecha_fin,
                    Cantidad_consultas = m.Detalle_Especialistas_Pacientes_Cantidad_consultas,
                    Principal = m.Detalle_Especialistas_Pacientes_Principal ?? false,
                    Estatus = m.Detalle_Especialistas_Pacientes_Estatus,

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

        public IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Especialistas_Pacientes>("sp_ListSelAll_Detalle_Especialistas_Pacientes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Especialistas_PacientesPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Especialistas_PacientesPagingModel
                {
                    Detalle_Especialistas_Pacientess =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes
                {
                    Folio = m.Detalle_Especialistas_Pacientes_Folio
                    ,Folio_Pacientes = m.Detalle_Especialistas_Pacientes_Folio_Pacientes
                    ,Especialista = m.Detalle_Especialistas_Pacientes_Especialista
                    ,Especialista_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Detalle_Especialistas_Pacientes_Especialista.GetValueOrDefault(), Name = m.Detalle_Especialistas_Pacientes_Especialista_Name }
                    ,Especialidad = m.Detalle_Especialistas_Pacientes_Especialidad
                    ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Detalle_Especialistas_Pacientes_Especialidad.GetValueOrDefault(), Especialidad = m.Detalle_Especialistas_Pacientes_Especialidad_Especialidad }
                    ,Fecha_inicio = m.Detalle_Especialistas_Pacientes_Fecha_inicio
                    ,Fecha_fin = m.Detalle_Especialistas_Pacientes_Fecha_fin
                    ,Cantidad_consultas = m.Detalle_Especialistas_Pacientes_Cantidad_consultas
                    ,Principal = m.Detalle_Especialistas_Pacientes_Principal ?? false
                    ,Estatus = m.Detalle_Especialistas_Pacientes_Estatus
                    ,Estatus_Estatus_Paciente = new Core.Classes.Estatus_Paciente.Estatus_Paciente() { Clave = m.Detalle_Especialistas_Pacientes_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Especialistas_Pacientes_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>("sp_GetDetalle_Especialistas_Pacientes", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Especialistas_Pacientes>("sp_DelDetalle_Especialistas_Pacientes", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity)
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
                var padreEspecialista = _dataProvider.GetParameter();
                padreEspecialista.ParameterName = "Especialista";
                padreEspecialista.DbType = DbType.Int32;
                padreEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;

                var padreEspecialidad = _dataProvider.GetParameter();
                padreEspecialidad.ParameterName = "Especialidad";
                padreEspecialidad.DbType = DbType.Int32;
                padreEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var padreFecha_inicio = _dataProvider.GetParameter();
                padreFecha_inicio.ParameterName = "Fecha_inicio";
                padreFecha_inicio.DbType = DbType.DateTime;
                padreFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;

                var padreFecha_fin = _dataProvider.GetParameter();
                padreFecha_fin.ParameterName = "Fecha_fin";
                padreFecha_fin.DbType = DbType.DateTime;
                padreFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;

                var padreCantidad_consultas = _dataProvider.GetParameter();
                padreCantidad_consultas.ParameterName = "Cantidad_consultas";
                padreCantidad_consultas.DbType = DbType.Int32;
                padreCantidad_consultas.Value = (object)entity.Cantidad_consultas ?? DBNull.Value;

                var padrePrincipal = _dataProvider.GetParameter();
                padrePrincipal.ParameterName = "Principal";
                padrePrincipal.DbType = DbType.Boolean;
                padrePrincipal.Value = (object)entity.Principal ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Especialistas_Pacientes>("sp_InsDetalle_Especialistas_Pacientes" , padreFolio_Pacientes
, padreEspecialista
, padreEspecialidad
, padreFecha_inicio
, padreFecha_fin
, padreCantidad_consultas
, padrePrincipal
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

        public int Update(Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity)
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
                var paramUpdEspecialista = _dataProvider.GetParameter();
                paramUpdEspecialista.ParameterName = "Especialista";
                paramUpdEspecialista.DbType = DbType.Int32;
                paramUpdEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;

                var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var paramUpdFecha_inicio = _dataProvider.GetParameter();
                paramUpdFecha_inicio.ParameterName = "Fecha_inicio";
                paramUpdFecha_inicio.DbType = DbType.DateTime;
                paramUpdFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;

                var paramUpdFecha_fin = _dataProvider.GetParameter();
                paramUpdFecha_fin.ParameterName = "Fecha_fin";
                paramUpdFecha_fin.DbType = DbType.DateTime;
                paramUpdFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;

                var paramUpdCantidad_consultas = _dataProvider.GetParameter();
                paramUpdCantidad_consultas.ParameterName = "Cantidad_consultas";
                paramUpdCantidad_consultas.DbType = DbType.Int32;
                paramUpdCantidad_consultas.Value = (object)entity.Cantidad_consultas ?? DBNull.Value;

                var paramUpdPrincipal = _dataProvider.GetParameter();
                paramUpdPrincipal.ParameterName = "Principal";
                paramUpdPrincipal.DbType = DbType.Boolean;
                paramUpdPrincipal.Value = (object)entity.Principal ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Especialistas_Pacientes>("sp_UpdDetalle_Especialistas_Pacientes" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdEspecialista , paramUpdEspecialidad , paramUpdFecha_inicio , paramUpdFecha_fin , paramUpdCantidad_consultas , paramUpdPrincipal , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes Detalle_Especialistas_PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
		var paramUpdEspecialista = _dataProvider.GetParameter();
                paramUpdEspecialista.ParameterName = "Especialista";
                paramUpdEspecialista.DbType = DbType.Int32;
                paramUpdEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
                var paramUpdFecha_inicio = _dataProvider.GetParameter();
                paramUpdFecha_inicio.ParameterName = "Fecha_inicio";
                paramUpdFecha_inicio.DbType = DbType.DateTime;
                paramUpdFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;
                var paramUpdFecha_fin = _dataProvider.GetParameter();
                paramUpdFecha_fin.ParameterName = "Fecha_fin";
                paramUpdFecha_fin.DbType = DbType.DateTime;
                paramUpdFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;
                var paramUpdCantidad_consultas = _dataProvider.GetParameter();
                paramUpdCantidad_consultas.ParameterName = "Cantidad_consultas";
                paramUpdCantidad_consultas.DbType = DbType.Int32;
                paramUpdCantidad_consultas.Value = (object)entity.Cantidad_consultas ?? DBNull.Value;
                var paramUpdPrincipal = _dataProvider.GetParameter();
                paramUpdPrincipal.ParameterName = "Principal";
                paramUpdPrincipal.DbType = DbType.Boolean;
                paramUpdPrincipal.Value = (object)entity.Principal ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Especialistas_Pacientes>("sp_UpdDetalle_Especialistas_Pacientes" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdEspecialista , paramUpdEspecialidad , paramUpdFecha_inicio , paramUpdFecha_fin , paramUpdCantidad_consultas , paramUpdPrincipal , paramUpdEstatus ).FirstOrDefault();

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


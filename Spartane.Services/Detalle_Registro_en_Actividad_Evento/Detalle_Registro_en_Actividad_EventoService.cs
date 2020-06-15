using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Registro_en_Actividad_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Registro_en_Actividad_EventoService : IDetalle_Registro_en_Actividad_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> _Detalle_Registro_en_Actividad_EventoRepository;
        #endregion

        #region Ctor
        public Detalle_Registro_en_Actividad_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> Detalle_Registro_en_Actividad_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Registro_en_Actividad_EventoRepository = Detalle_Registro_en_Actividad_EventoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>("sp_SelAllDetalle_Registro_en_Actividad_Evento");
        }

        public IList<Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Registro_en_Actividad_Evento_Complete>("sp_SelAllComplete_Detalle_Registro_en_Actividad_Evento");
            return data.Select(m => new Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento
            {
                Folio = m.Folio
                ,Folio_Registro_Evento = m.Folio_Registro_Evento
                ,Actividad_Detalle_Actividades_Evento = new Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento() { Folio = m.Actividad.GetValueOrDefault(), Nombre_de_la_Actividad = m.Actividad_Nombre_de_la_Actividad }
                ,Fecha = m.Fecha
                ,Horario = m.Horario
                ,Es_para_un_familiar = m.Es_para_un_familiar.GetValueOrDefault()
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Parentesco_Parentescos_Empleados = new Core.Classes.Parentescos_Empleados.Parentescos_Empleados() { Folio = m.Parentesco.GetValueOrDefault(), Descripcion = m.Parentesco_Descripcion }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Fecha_de_nacimiento = m.Fecha_de_nacimiento
                ,Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad = new Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad() { Folio = m.Estatus_de_la_Reservacion.GetValueOrDefault(), Descripcion = m.Estatus_de_la_Reservacion_Descripcion }
                ,Codigo_Reservacion = m.Codigo_Reservacion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Registro_en_Actividad_Evento>("sp_ListSelCount_Detalle_Registro_en_Actividad_Evento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Registro_en_Actividad_Evento>("sp_ListSelAll_Detalle_Registro_en_Actividad_Evento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento
                {
                    Folio = m.Detalle_Registro_en_Actividad_Evento_Folio,
                    Folio_Registro_Evento = m.Detalle_Registro_en_Actividad_Evento_Folio_Registro_Evento,
                    Actividad = m.Detalle_Registro_en_Actividad_Evento_Actividad,
                    Fecha = m.Detalle_Registro_en_Actividad_Evento_Fecha,
                    Horario = m.Detalle_Registro_en_Actividad_Evento_Horario,
                    Es_para_un_familiar = m.Detalle_Registro_en_Actividad_Evento_Es_para_un_familiar ?? false,
                    Numero_de_Empleado = m.Detalle_Registro_en_Actividad_Evento_Numero_de_Empleado,
                    Nombres = m.Detalle_Registro_en_Actividad_Evento_Nombres,
                    Apellido_Paterno = m.Detalle_Registro_en_Actividad_Evento_Apellido_Paterno,
                    Apellido_Materno = m.Detalle_Registro_en_Actividad_Evento_Apellido_Materno,
                    Nombre_Completo = m.Detalle_Registro_en_Actividad_Evento_Nombre_Completo,
                    Parentesco = m.Detalle_Registro_en_Actividad_Evento_Parentesco,
                    Sexo = m.Detalle_Registro_en_Actividad_Evento_Sexo,
                    Fecha_de_nacimiento = m.Detalle_Registro_en_Actividad_Evento_Fecha_de_nacimiento,
                    Estatus_de_la_Reservacion = m.Detalle_Registro_en_Actividad_Evento_Estatus_de_la_Reservacion,
                    Codigo_Reservacion = m.Detalle_Registro_en_Actividad_Evento_Codigo_Reservacion,

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

        public IList<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Registro_en_Actividad_Evento>("sp_ListSelAll_Detalle_Registro_en_Actividad_Evento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Registro_en_Actividad_EventoPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Registro_en_Actividad_EventoPagingModel
                {
                    Detalle_Registro_en_Actividad_Eventos =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento
                {
                    Folio = m.Detalle_Registro_en_Actividad_Evento_Folio
                    ,Folio_Registro_Evento = m.Detalle_Registro_en_Actividad_Evento_Folio_Registro_Evento
                    ,Actividad = m.Detalle_Registro_en_Actividad_Evento_Actividad
                    ,Actividad_Detalle_Actividades_Evento = new Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento() { Folio = m.Detalle_Registro_en_Actividad_Evento_Actividad.GetValueOrDefault(), Nombre_de_la_Actividad = m.Detalle_Registro_en_Actividad_Evento_Actividad_Nombre_de_la_Actividad }
                    ,Fecha = m.Detalle_Registro_en_Actividad_Evento_Fecha
                    ,Horario = m.Detalle_Registro_en_Actividad_Evento_Horario
                    ,Es_para_un_familiar = m.Detalle_Registro_en_Actividad_Evento_Es_para_un_familiar ?? false
                    ,Numero_de_Empleado = m.Detalle_Registro_en_Actividad_Evento_Numero_de_Empleado
                    ,Nombres = m.Detalle_Registro_en_Actividad_Evento_Nombres
                    ,Apellido_Paterno = m.Detalle_Registro_en_Actividad_Evento_Apellido_Paterno
                    ,Apellido_Materno = m.Detalle_Registro_en_Actividad_Evento_Apellido_Materno
                    ,Nombre_Completo = m.Detalle_Registro_en_Actividad_Evento_Nombre_Completo
                    ,Parentesco = m.Detalle_Registro_en_Actividad_Evento_Parentesco
                    ,Parentesco_Parentescos_Empleados = new Core.Classes.Parentescos_Empleados.Parentescos_Empleados() { Folio = m.Detalle_Registro_en_Actividad_Evento_Parentesco.GetValueOrDefault(), Descripcion = m.Detalle_Registro_en_Actividad_Evento_Parentesco_Descripcion }
                    ,Sexo = m.Detalle_Registro_en_Actividad_Evento_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Detalle_Registro_en_Actividad_Evento_Sexo.GetValueOrDefault(), Descripcion = m.Detalle_Registro_en_Actividad_Evento_Sexo_Descripcion }
                    ,Fecha_de_nacimiento = m.Detalle_Registro_en_Actividad_Evento_Fecha_de_nacimiento
                    ,Estatus_de_la_Reservacion = m.Detalle_Registro_en_Actividad_Evento_Estatus_de_la_Reservacion
                    ,Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad = new Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad() { Folio = m.Detalle_Registro_en_Actividad_Evento_Estatus_de_la_Reservacion.GetValueOrDefault(), Descripcion = m.Detalle_Registro_en_Actividad_Evento_Estatus_de_la_Reservacion_Descripcion }
                    ,Codigo_Reservacion = m.Detalle_Registro_en_Actividad_Evento_Codigo_Reservacion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>("sp_GetDetalle_Registro_en_Actividad_Evento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Registro_en_Actividad_Evento>("sp_DelDetalle_Registro_en_Actividad_Evento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Registro_Evento = _dataProvider.GetParameter();
                padreFolio_Registro_Evento.ParameterName = "Folio_Registro_Evento";
                padreFolio_Registro_Evento.DbType = DbType.Int32;
                padreFolio_Registro_Evento.Value = (object)entity.Folio_Registro_Evento ?? DBNull.Value;
                var padreActividad = _dataProvider.GetParameter();
                padreActividad.ParameterName = "Actividad";
                padreActividad.DbType = DbType.Int32;
                padreActividad.Value = (object)entity.Actividad ?? DBNull.Value;

                var padreFecha = _dataProvider.GetParameter();
                padreFecha.ParameterName = "Fecha";
                padreFecha.DbType = DbType.DateTime;
                padreFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var padreHorario = _dataProvider.GetParameter();
                padreHorario.ParameterName = "Horario";
                padreHorario.DbType = DbType.String;
                padreHorario.Value = (object)entity.Horario ?? DBNull.Value;
                var padreEs_para_un_familiar = _dataProvider.GetParameter();
                padreEs_para_un_familiar.ParameterName = "Es_para_un_familiar";
                padreEs_para_un_familiar.DbType = DbType.Boolean;
                padreEs_para_un_familiar.Value = (object)entity.Es_para_un_familiar ?? DBNull.Value;
                var padreNumero_de_Empleado = _dataProvider.GetParameter();
                padreNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                padreNumero_de_Empleado.DbType = DbType.String;
                padreNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var padreNombres = _dataProvider.GetParameter();
                padreNombres.ParameterName = "Nombres";
                padreNombres.DbType = DbType.String;
                padreNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var padreApellido_Paterno = _dataProvider.GetParameter();
                padreApellido_Paterno.ParameterName = "Apellido_Paterno";
                padreApellido_Paterno.DbType = DbType.String;
                padreApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var padreApellido_Materno = _dataProvider.GetParameter();
                padreApellido_Materno.ParameterName = "Apellido_Materno";
                padreApellido_Materno.DbType = DbType.String;
                padreApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreParentesco = _dataProvider.GetParameter();
                padreParentesco.ParameterName = "Parentesco";
                padreParentesco.DbType = DbType.Int32;
                padreParentesco.Value = (object)entity.Parentesco ?? DBNull.Value;

                var padreSexo = _dataProvider.GetParameter();
                padreSexo.ParameterName = "Sexo";
                padreSexo.DbType = DbType.Int32;
                padreSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var padreFecha_de_nacimiento = _dataProvider.GetParameter();
                padreFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                padreFecha_de_nacimiento.DbType = DbType.DateTime;
                padreFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;

                var padreEstatus_de_la_Reservacion = _dataProvider.GetParameter();
                padreEstatus_de_la_Reservacion.ParameterName = "Estatus_de_la_Reservacion";
                padreEstatus_de_la_Reservacion.DbType = DbType.Int32;
                padreEstatus_de_la_Reservacion.Value = (object)entity.Estatus_de_la_Reservacion ?? DBNull.Value;

                var padreCodigo_Reservacion = _dataProvider.GetParameter();
                padreCodigo_Reservacion.ParameterName = "Codigo_Reservacion";
                padreCodigo_Reservacion.DbType = DbType.String;
                padreCodigo_Reservacion.Value = (object)entity.Codigo_Reservacion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Registro_en_Actividad_Evento>("sp_InsDetalle_Registro_en_Actividad_Evento" , padreFolio_Registro_Evento
, padreActividad
, padreFecha
, padreHorario
, padreEs_para_un_familiar
, padreNumero_de_Empleado
, padreNombres
, padreApellido_Paterno
, padreApellido_Materno
, padreNombre_Completo
, padreParentesco
, padreSexo
, padreFecha_de_nacimiento
, padreEstatus_de_la_Reservacion
, padreCodigo_Reservacion
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

        public int Update(Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Registro_Evento = _dataProvider.GetParameter();
                paramUpdFolio_Registro_Evento.ParameterName = "Folio_Registro_Evento";
                paramUpdFolio_Registro_Evento.DbType = DbType.Int32;
                paramUpdFolio_Registro_Evento.Value = (object)entity.Folio_Registro_Evento ?? DBNull.Value;
                var paramUpdActividad = _dataProvider.GetParameter();
                paramUpdActividad.ParameterName = "Actividad";
                paramUpdActividad.DbType = DbType.Int32;
                paramUpdActividad.Value = (object)entity.Actividad ?? DBNull.Value;

                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var paramUpdHorario = _dataProvider.GetParameter();
                paramUpdHorario.ParameterName = "Horario";
                paramUpdHorario.DbType = DbType.String;
                paramUpdHorario.Value = (object)entity.Horario ?? DBNull.Value;
                var paramUpdEs_para_un_familiar = _dataProvider.GetParameter();
                paramUpdEs_para_un_familiar.ParameterName = "Es_para_un_familiar";
                paramUpdEs_para_un_familiar.DbType = DbType.Boolean;
                paramUpdEs_para_un_familiar.Value = (object)entity.Es_para_un_familiar ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdParentesco = _dataProvider.GetParameter();
                paramUpdParentesco.ParameterName = "Parentesco";
                paramUpdParentesco.DbType = DbType.Int32;
                paramUpdParentesco.Value = (object)entity.Parentesco ?? DBNull.Value;

                var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;

                var paramUpdEstatus_de_la_Reservacion = _dataProvider.GetParameter();
                paramUpdEstatus_de_la_Reservacion.ParameterName = "Estatus_de_la_Reservacion";
                paramUpdEstatus_de_la_Reservacion.DbType = DbType.Int32;
                paramUpdEstatus_de_la_Reservacion.Value = (object)entity.Estatus_de_la_Reservacion ?? DBNull.Value;

                var paramUpdCodigo_Reservacion = _dataProvider.GetParameter();
                paramUpdCodigo_Reservacion.ParameterName = "Codigo_Reservacion";
                paramUpdCodigo_Reservacion.DbType = DbType.String;
                paramUpdCodigo_Reservacion.Value = (object)entity.Codigo_Reservacion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Registro_en_Actividad_Evento>("sp_UpdDetalle_Registro_en_Actividad_Evento" , paramUpdFolio , paramUpdFolio_Registro_Evento , paramUpdActividad , paramUpdFecha , paramUpdHorario , paramUpdEs_para_un_familiar , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdParentesco , paramUpdSexo , paramUpdFecha_de_nacimiento , paramUpdEstatus_de_la_Reservacion , paramUpdCodigo_Reservacion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento Detalle_Registro_en_Actividad_EventoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Registro_Evento = _dataProvider.GetParameter();
                paramUpdFolio_Registro_Evento.ParameterName = "Folio_Registro_Evento";
                paramUpdFolio_Registro_Evento.DbType = DbType.Int32;
                paramUpdFolio_Registro_Evento.Value = (object)entity.Folio_Registro_Evento ?? DBNull.Value;
		var paramUpdActividad = _dataProvider.GetParameter();
                paramUpdActividad.ParameterName = "Actividad";
                paramUpdActividad.DbType = DbType.Int32;
                paramUpdActividad.Value = (object)entity.Actividad ?? DBNull.Value;
                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;
                var paramUpdHorario = _dataProvider.GetParameter();
                paramUpdHorario.ParameterName = "Horario";
                paramUpdHorario.DbType = DbType.String;
                paramUpdHorario.Value = (object)entity.Horario ?? DBNull.Value;
                var paramUpdEs_para_un_familiar = _dataProvider.GetParameter();
                paramUpdEs_para_un_familiar.ParameterName = "Es_para_un_familiar";
                paramUpdEs_para_un_familiar.DbType = DbType.Boolean;
                paramUpdEs_para_un_familiar.Value = (object)entity.Es_para_un_familiar ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
		var paramUpdParentesco = _dataProvider.GetParameter();
                paramUpdParentesco.ParameterName = "Parentesco";
                paramUpdParentesco.DbType = DbType.Int32;
                paramUpdParentesco.Value = (object)entity.Parentesco ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdEstatus_de_la_Reservacion = _dataProvider.GetParameter();
                paramUpdEstatus_de_la_Reservacion.ParameterName = "Estatus_de_la_Reservacion";
                paramUpdEstatus_de_la_Reservacion.DbType = DbType.Int32;
                paramUpdEstatus_de_la_Reservacion.Value = (object)entity.Estatus_de_la_Reservacion ?? DBNull.Value;
                var paramUpdCodigo_Reservacion = _dataProvider.GetParameter();
                paramUpdCodigo_Reservacion.ParameterName = "Codigo_Reservacion";
                paramUpdCodigo_Reservacion.DbType = DbType.String;
                paramUpdCodigo_Reservacion.Value = (object)entity.Codigo_Reservacion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Registro_en_Actividad_Evento>("sp_UpdDetalle_Registro_en_Actividad_Evento" , paramUpdFolio , paramUpdFolio_Registro_Evento , paramUpdActividad , paramUpdFecha , paramUpdHorario , paramUpdEs_para_un_familiar , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdParentesco , paramUpdSexo , paramUpdFecha_de_nacimiento , paramUpdEstatus_de_la_Reservacion , paramUpdCodigo_Reservacion ).FirstOrDefault();

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


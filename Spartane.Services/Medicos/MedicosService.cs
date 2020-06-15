using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Medicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Medicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MedicosService : IMedicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Medicos.Medicos> _MedicosRepository;
        #endregion

        #region Ctor
        public MedicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Medicos.Medicos> MedicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MedicosRepository = MedicosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MedicosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Medicos.Medicos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Medicos.Medicos>("sp_SelAllMedicos");
        }

        public IList<Core.Classes.Medicos.Medicos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMedicos_Complete>("sp_SelAllComplete_Medicos");
            return data.Select(m => new Core.Classes.Medicos.Medicos
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Titulo_Personal_Titulos_Personales = new Core.Classes.Titulos_Personales.Titulos_Personales() { Clave = m.Titulo_Personal.GetValueOrDefault(), Descripcion = m.Titulo_Personal_Descripcion }
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Tipo_de_Especialista_Tipos_de_Especialistas = new Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas() { Clave = m.Tipo_de_Especialista.GetValueOrDefault(), Descripcion = m.Tipo_de_Especialista_Descripcion }
                ,Foto = m.Foto
                ,Nombre_de_usuario = m.Nombre_de_usuario
                ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_Registrado.GetValueOrDefault(), Name = m.Usuario_Registrado_Name }
                ,Email = m.Email
                ,Celular = m.Celular
                ,Fecha_de_nacimiento = m.Fecha_de_nacimiento
                ,Pais_de_nacimiento_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais_de_nacimiento.GetValueOrDefault(), Nombre_del_Pais = m.Pais_de_nacimiento_Nombre_del_Pais }
                ,Entidad_de_nacimiento_Estado = new Core.Classes.Estado.Estado() { Clave = m.Entidad_de_nacimiento.GetValueOrDefault(), Nombre_del_Estado = m.Entidad_de_nacimiento_Nombre_del_Estado }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Email_institucional = m.Email_institucional
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Email_ppal_publico_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Email_ppal_publico.GetValueOrDefault(), Descripcion = m.Email_ppal_publico_Descripcion }
                ,Email_de_contacto = m.Email_de_contacto
                ,Calle = m.Calle
                ,Numero_exterior = m.Numero_exterior
                ,Numero_interior = m.Numero_interior
                ,Colonia = m.Colonia
                ,CP = m.CP
                ,Ciudad = m.Ciudad
                ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Estado.GetValueOrDefault(), Nombre_del_Estado = m.Estado_Nombre_del_Estado }
                ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais.GetValueOrDefault(), Nombre_del_Pais = m.Pais_Nombre_del_Pais }
                ,Telefonos = m.Telefonos
                ,En_Hospital_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.En_Hospital.GetValueOrDefault(), Descripcion = m.En_Hospital_Descripcion }
                ,Nombre_del_Hospital = m.Nombre_del_Hospital
                ,Piso_hospital = m.Piso_hospital
                ,Numero_de_consultorio = m.Numero_de_consultorio
                ,Se_ajusta_tabulador_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Se_ajusta_tabulador.GetValueOrDefault(), Descripcion = m.Se_ajusta_tabulador_Descripcion }
                ,Profesion_Profesiones = new Core.Classes.Profesiones.Profesiones() { Clave = m.Profesion.GetValueOrDefault(), Descripcion = m.Profesion_Descripcion }
                ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Especialidad.GetValueOrDefault(), Especialidad = m.Especialidad_Especialidad }
                ,Resumen_Profesional = m.Resumen_Profesional
                ,Regimen_Fiscal_Regimenes_Fiscales = new Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales() { Clave = m.Regimen_Fiscal.GetValueOrDefault(), Descripcion = m.Regimen_Fiscal_Descripcion }
                ,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
                ,RFC = m.RFC
                ,Calle_Fiscal = m.Calle_Fiscal
                ,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
                ,Numero_interior_Fiscal = m.Numero_interior_Fiscal
                ,Colonia_Fiscal = m.Colonia_Fiscal
                ,CP_Fiscal = m.CP_Fiscal
                ,Ciudad_Fiscal = m.Ciudad_Fiscal
                ,Estado_Fiscal_Estado = new Core.Classes.Estado.Estado() { Clave = m.Estado_Fiscal.GetValueOrDefault(), Nombre_del_Estado = m.Estado_Fiscal_Nombre_del_Estado }
                ,Pais_Fiscal_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais_Fiscal.GetValueOrDefault(), Nombre_del_Pais = m.Pais_Fiscal_Nombre_del_Pais }
                ,Telefono = m.Telefono
                ,Fax = m.Fax
                ,Cedula_Fiscal_Documento = m.Cedula_Fiscal_Documento
                ,Comprobante_de_Domicilio = m.Comprobante_de_Domicilio
                ,Calificacion_Red_de_Medicos = m.Calificacion_Red_de_Medicos
                ,Banco_Bancos = new Core.Classes.Bancos.Bancos() { Clave = m.Banco.GetValueOrDefault(), Nombre = m.Banco_Nombre }
                ,CLABE_Interbancaria = m.CLABE_Interbancaria
                ,Numero_de_Cuenta = m.Numero_de_Cuenta
                ,Nombre_del_Titular = m.Nombre_del_Titular


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Medicos>("sp_ListSelCount_Medicos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Medicos.Medicos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMedicos>("sp_ListSelAll_Medicos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Medicos.Medicos
                {
                    Folio = m.Medicos_Folio,
                    Fecha_de_Registro = m.Medicos_Fecha_de_Registro,
                    Hora_de_Registro = m.Medicos_Hora_de_Registro,
                    Usuario_que_Registra = m.Medicos_Usuario_que_Registra,
                    Titulo_Personal = m.Medicos_Titulo_Personal,
                    Nombres = m.Medicos_Nombres,
                    Apellido_Paterno = m.Medicos_Apellido_Paterno,
                    Apellido_Materno = m.Medicos_Apellido_Materno,
                    Nombre_Completo = m.Medicos_Nombre_Completo,
                    Tipo_de_Especialista = m.Medicos_Tipo_de_Especialista,
                    Foto = m.Medicos_Foto,
                    Nombre_de_usuario = m.Medicos_Nombre_de_usuario,
                    Usuario_Registrado = m.Medicos_Usuario_Registrado,
                    Email = m.Medicos_Email,
                    Celular = m.Medicos_Celular,
                    Fecha_de_nacimiento = m.Medicos_Fecha_de_nacimiento,
                    Pais_de_nacimiento = m.Medicos_Pais_de_nacimiento,
                    Entidad_de_nacimiento = m.Medicos_Entidad_de_nacimiento,
                    Sexo = m.Medicos_Sexo,
                    Email_institucional = m.Medicos_Email_institucional,
                    Estatus = m.Medicos_Estatus,
                    Email_ppal_publico = m.Medicos_Email_ppal_publico,
                    Email_de_contacto = m.Medicos_Email_de_contacto,
                    Calle = m.Medicos_Calle,
                    Numero_exterior = m.Medicos_Numero_exterior,
                    Numero_interior = m.Medicos_Numero_interior,
                    Colonia = m.Medicos_Colonia,
                    CP = m.Medicos_CP,
                    Ciudad = m.Medicos_Ciudad,
                    Estado = m.Medicos_Estado,
                    Pais = m.Medicos_Pais,
                    Telefonos = m.Medicos_Telefonos,
                    En_Hospital = m.Medicos_En_Hospital,
                    Nombre_del_Hospital = m.Medicos_Nombre_del_Hospital,
                    Piso_hospital = m.Medicos_Piso_hospital,
                    Numero_de_consultorio = m.Medicos_Numero_de_consultorio,
                    Se_ajusta_tabulador = m.Medicos_Se_ajusta_tabulador,
                    Profesion = m.Medicos_Profesion,
                    Especialidad = m.Medicos_Especialidad,
                    Resumen_Profesional = m.Medicos_Resumen_Profesional,
                    Regimen_Fiscal = m.Medicos_Regimen_Fiscal,
                    Nombre_o_Razon_Social = m.Medicos_Nombre_o_Razon_Social,
                    RFC = m.Medicos_RFC,
                    Calle_Fiscal = m.Medicos_Calle_Fiscal,
                    Numero_exterior_Fiscal = m.Medicos_Numero_exterior_Fiscal,
                    Numero_interior_Fiscal = m.Medicos_Numero_interior_Fiscal,
                    Colonia_Fiscal = m.Medicos_Colonia_Fiscal,
                    CP_Fiscal = m.Medicos_CP_Fiscal,
                    Ciudad_Fiscal = m.Medicos_Ciudad_Fiscal,
                    Estado_Fiscal = m.Medicos_Estado_Fiscal,
                    Pais_Fiscal = m.Medicos_Pais_Fiscal,
                    Telefono = m.Medicos_Telefono,
                    Fax = m.Medicos_Fax,
                    Cedula_Fiscal_Documento = m.Medicos_Cedula_Fiscal_Documento,
                    Comprobante_de_Domicilio = m.Medicos_Comprobante_de_Domicilio,
                    Calificacion_Red_de_Medicos = m.Medicos_Calificacion_Red_de_Medicos,
                    Banco = m.Medicos_Banco,
                    CLABE_Interbancaria = m.Medicos_CLABE_Interbancaria,
                    Numero_de_Cuenta = m.Medicos_Numero_de_Cuenta,
                    Nombre_del_Titular = m.Medicos_Nombre_del_Titular,

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

        public IList<Spartane.Core.Classes.Medicos.Medicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MedicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Medicos.Medicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MedicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Medicos.MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMedicos>("sp_ListSelAll_Medicos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MedicosPagingModel result = null;

            if (data != null)
            {
                result = new MedicosPagingModel
                {
                    Medicoss =
                        data.Select(m => new Spartane.Core.Classes.Medicos.Medicos
                {
                    Folio = m.Medicos_Folio
                    ,Fecha_de_Registro = m.Medicos_Fecha_de_Registro
                    ,Hora_de_Registro = m.Medicos_Hora_de_Registro
                    ,Usuario_que_Registra = m.Medicos_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Medicos_Usuario_que_Registra.GetValueOrDefault(), Name = m.Medicos_Usuario_que_Registra_Name }
                    ,Titulo_Personal = m.Medicos_Titulo_Personal
                    ,Titulo_Personal_Titulos_Personales = new Core.Classes.Titulos_Personales.Titulos_Personales() { Clave = m.Medicos_Titulo_Personal.GetValueOrDefault(), Descripcion = m.Medicos_Titulo_Personal_Descripcion }
                    ,Nombres = m.Medicos_Nombres
                    ,Apellido_Paterno = m.Medicos_Apellido_Paterno
                    ,Apellido_Materno = m.Medicos_Apellido_Materno
                    ,Nombre_Completo = m.Medicos_Nombre_Completo
                    ,Tipo_de_Especialista = m.Medicos_Tipo_de_Especialista
                    ,Tipo_de_Especialista_Tipos_de_Especialistas = new Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas() { Clave = m.Medicos_Tipo_de_Especialista.GetValueOrDefault(), Descripcion = m.Medicos_Tipo_de_Especialista_Descripcion }
                    ,Foto = m.Medicos_Foto
                    ,Nombre_de_usuario = m.Medicos_Nombre_de_usuario
                    ,Usuario_Registrado = m.Medicos_Usuario_Registrado
                    ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Medicos_Usuario_Registrado.GetValueOrDefault(), Name = m.Medicos_Usuario_Registrado_Name }
                    ,Email = m.Medicos_Email
                    ,Celular = m.Medicos_Celular
                    ,Fecha_de_nacimiento = m.Medicos_Fecha_de_nacimiento
                    ,Pais_de_nacimiento = m.Medicos_Pais_de_nacimiento
                    ,Pais_de_nacimiento_Pais = new Core.Classes.Pais.Pais() { Clave = m.Medicos_Pais_de_nacimiento.GetValueOrDefault(), Nombre_del_Pais = m.Medicos_Pais_de_nacimiento_Nombre_del_Pais }
                    ,Entidad_de_nacimiento = m.Medicos_Entidad_de_nacimiento
                    ,Entidad_de_nacimiento_Estado = new Core.Classes.Estado.Estado() { Clave = m.Medicos_Entidad_de_nacimiento.GetValueOrDefault(), Nombre_del_Estado = m.Medicos_Entidad_de_nacimiento_Nombre_del_Estado }
                    ,Sexo = m.Medicos_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Medicos_Sexo.GetValueOrDefault(), Descripcion = m.Medicos_Sexo_Descripcion }
                    ,Email_institucional = m.Medicos_Email_institucional
                    ,Estatus = m.Medicos_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Medicos_Estatus.GetValueOrDefault(), Descripcion = m.Medicos_Estatus_Descripcion }
                    ,Email_ppal_publico = m.Medicos_Email_ppal_publico
                    ,Email_ppal_publico_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Medicos_Email_ppal_publico.GetValueOrDefault(), Descripcion = m.Medicos_Email_ppal_publico_Descripcion }
                    ,Email_de_contacto = m.Medicos_Email_de_contacto
                    ,Calle = m.Medicos_Calle
                    ,Numero_exterior = m.Medicos_Numero_exterior
                    ,Numero_interior = m.Medicos_Numero_interior
                    ,Colonia = m.Medicos_Colonia
                    ,CP = m.Medicos_CP
                    ,Ciudad = m.Medicos_Ciudad
                    ,Estado = m.Medicos_Estado
                    ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Medicos_Estado.GetValueOrDefault(), Nombre_del_Estado = m.Medicos_Estado_Nombre_del_Estado }
                    ,Pais = m.Medicos_Pais
                    ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Medicos_Pais.GetValueOrDefault(), Nombre_del_Pais = m.Medicos_Pais_Nombre_del_Pais }
                    ,Telefonos = m.Medicos_Telefonos
                    ,En_Hospital = m.Medicos_En_Hospital
                    ,En_Hospital_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Medicos_En_Hospital.GetValueOrDefault(), Descripcion = m.Medicos_En_Hospital_Descripcion }
                    ,Nombre_del_Hospital = m.Medicos_Nombre_del_Hospital
                    ,Piso_hospital = m.Medicos_Piso_hospital
                    ,Numero_de_consultorio = m.Medicos_Numero_de_consultorio
                    ,Se_ajusta_tabulador = m.Medicos_Se_ajusta_tabulador
                    ,Se_ajusta_tabulador_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Medicos_Se_ajusta_tabulador.GetValueOrDefault(), Descripcion = m.Medicos_Se_ajusta_tabulador_Descripcion }
                    ,Profesion = m.Medicos_Profesion
                    ,Profesion_Profesiones = new Core.Classes.Profesiones.Profesiones() { Clave = m.Medicos_Profesion.GetValueOrDefault(), Descripcion = m.Medicos_Profesion_Descripcion }
                    ,Especialidad = m.Medicos_Especialidad
                    ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Medicos_Especialidad.GetValueOrDefault(), Especialidad = m.Medicos_Especialidad_Especialidad }
                    ,Resumen_Profesional = m.Medicos_Resumen_Profesional
                    ,Regimen_Fiscal = m.Medicos_Regimen_Fiscal
                    ,Regimen_Fiscal_Regimenes_Fiscales = new Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales() { Clave = m.Medicos_Regimen_Fiscal.GetValueOrDefault(), Descripcion = m.Medicos_Regimen_Fiscal_Descripcion }
                    ,Nombre_o_Razon_Social = m.Medicos_Nombre_o_Razon_Social
                    ,RFC = m.Medicos_RFC
                    ,Calle_Fiscal = m.Medicos_Calle_Fiscal
                    ,Numero_exterior_Fiscal = m.Medicos_Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = m.Medicos_Numero_interior_Fiscal
                    ,Colonia_Fiscal = m.Medicos_Colonia_Fiscal
                    ,CP_Fiscal = m.Medicos_CP_Fiscal
                    ,Ciudad_Fiscal = m.Medicos_Ciudad_Fiscal
                    ,Estado_Fiscal = m.Medicos_Estado_Fiscal
                    ,Estado_Fiscal_Estado = new Core.Classes.Estado.Estado() { Clave = m.Medicos_Estado_Fiscal.GetValueOrDefault(), Nombre_del_Estado = m.Medicos_Estado_Fiscal_Nombre_del_Estado }
                    ,Pais_Fiscal = m.Medicos_Pais_Fiscal
                    ,Pais_Fiscal_Pais = new Core.Classes.Pais.Pais() { Clave = m.Medicos_Pais_Fiscal.GetValueOrDefault(), Nombre_del_Pais = m.Medicos_Pais_Fiscal_Nombre_del_Pais }
                    ,Telefono = m.Medicos_Telefono
                    ,Fax = m.Medicos_Fax
                    ,Cedula_Fiscal_Documento = m.Medicos_Cedula_Fiscal_Documento
                    ,Comprobante_de_Domicilio = m.Medicos_Comprobante_de_Domicilio
                    ,Calificacion_Red_de_Medicos = m.Medicos_Calificacion_Red_de_Medicos
                    ,Banco = m.Medicos_Banco
                    ,Banco_Bancos = new Core.Classes.Bancos.Bancos() { Clave = m.Medicos_Banco.GetValueOrDefault(), Nombre = m.Medicos_Banco_Nombre }
                    ,CLABE_Interbancaria = m.Medicos_CLABE_Interbancaria
                    ,Numero_de_Cuenta = m.Medicos_Numero_de_Cuenta
                    ,Nombre_del_Titular = m.Medicos_Nombre_del_Titular

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Medicos.Medicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MedicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Medicos.Medicos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Medicos.Medicos>("sp_GetMedicos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMedicos>("sp_DelMedicos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreTitulo_Personal = _dataProvider.GetParameter();
                padreTitulo_Personal.ParameterName = "Titulo_Personal";
                padreTitulo_Personal.DbType = DbType.Int32;
                padreTitulo_Personal.Value = (object)entity.Titulo_Personal ?? DBNull.Value;

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
                var padreTipo_de_Especialista = _dataProvider.GetParameter();
                padreTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                padreTipo_de_Especialista.DbType = DbType.Int32;
                padreTipo_de_Especialista.Value = (object)entity.Tipo_de_Especialista ?? DBNull.Value;

                var padreFoto = _dataProvider.GetParameter();
                padreFoto.ParameterName = "Foto";
                padreFoto.DbType = DbType.Int32;
                padreFoto.Value = (object)entity.Foto ?? DBNull.Value;

                var padreNombre_de_usuario = _dataProvider.GetParameter();
                padreNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                padreNombre_de_usuario.DbType = DbType.String;
                padreNombre_de_usuario.Value = (object)entity.Nombre_de_usuario ?? DBNull.Value;
                var padreUsuario_Registrado = _dataProvider.GetParameter();
                padreUsuario_Registrado.ParameterName = "Usuario_Registrado";
                padreUsuario_Registrado.DbType = DbType.Int32;
                padreUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;

                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
                var padreCelular = _dataProvider.GetParameter();
                padreCelular.ParameterName = "Celular";
                padreCelular.DbType = DbType.String;
                padreCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var padreFecha_de_nacimiento = _dataProvider.GetParameter();
                padreFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                padreFecha_de_nacimiento.DbType = DbType.DateTime;
                padreFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;

                var padrePais_de_nacimiento = _dataProvider.GetParameter();
                padrePais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                padrePais_de_nacimiento.DbType = DbType.Int32;
                padrePais_de_nacimiento.Value = (object)entity.Pais_de_nacimiento ?? DBNull.Value;

                var padreEntidad_de_nacimiento = _dataProvider.GetParameter();
                padreEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                padreEntidad_de_nacimiento.DbType = DbType.Int32;
                padreEntidad_de_nacimiento.Value = (object)entity.Entidad_de_nacimiento ?? DBNull.Value;

                var padreSexo = _dataProvider.GetParameter();
                padreSexo.ParameterName = "Sexo";
                padreSexo.DbType = DbType.Int32;
                padreSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var padreEmail_institucional = _dataProvider.GetParameter();
                padreEmail_institucional.ParameterName = "Email_institucional";
                padreEmail_institucional.DbType = DbType.String;
                padreEmail_institucional.Value = (object)entity.Email_institucional ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreEmail_ppal_publico = _dataProvider.GetParameter();
                padreEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                padreEmail_ppal_publico.DbType = DbType.Int32;
                padreEmail_ppal_publico.Value = (object)entity.Email_ppal_publico ?? DBNull.Value;

                var padreEmail_de_contacto = _dataProvider.GetParameter();
                padreEmail_de_contacto.ParameterName = "Email_de_contacto";
                padreEmail_de_contacto.DbType = DbType.String;
                padreEmail_de_contacto.Value = (object)entity.Email_de_contacto ?? DBNull.Value;
                var padreCalle = _dataProvider.GetParameter();
                padreCalle.ParameterName = "Calle";
                padreCalle.DbType = DbType.String;
                padreCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var padreNumero_exterior = _dataProvider.GetParameter();
                padreNumero_exterior.ParameterName = "Numero_exterior";
                padreNumero_exterior.DbType = DbType.String;
                padreNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var padreNumero_interior = _dataProvider.GetParameter();
                padreNumero_interior.ParameterName = "Numero_interior";
                padreNumero_interior.DbType = DbType.String;
                padreNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var padreColonia = _dataProvider.GetParameter();
                padreColonia.ParameterName = "Colonia";
                padreColonia.DbType = DbType.String;
                padreColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var padreCP = _dataProvider.GetParameter();
                padreCP.ParameterName = "CP";
                padreCP.DbType = DbType.Int32;
                padreCP.Value = (object)entity.CP ?? DBNull.Value;

                var padreCiudad = _dataProvider.GetParameter();
                padreCiudad.ParameterName = "Ciudad";
                padreCiudad.DbType = DbType.String;
                padreCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var padreEstado = _dataProvider.GetParameter();
                padreEstado.ParameterName = "Estado";
                padreEstado.DbType = DbType.Int32;
                padreEstado.Value = (object)entity.Estado ?? DBNull.Value;

                var padrePais = _dataProvider.GetParameter();
                padrePais.ParameterName = "Pais";
                padrePais.DbType = DbType.Int32;
                padrePais.Value = (object)entity.Pais ?? DBNull.Value;

                var padreTelefonos = _dataProvider.GetParameter();
                padreTelefonos.ParameterName = "Telefonos";
                padreTelefonos.DbType = DbType.String;
                padreTelefonos.Value = (object)entity.Telefonos ?? DBNull.Value;
                var padreEn_Hospital = _dataProvider.GetParameter();
                padreEn_Hospital.ParameterName = "En_Hospital";
                padreEn_Hospital.DbType = DbType.Int32;
                padreEn_Hospital.Value = (object)entity.En_Hospital ?? DBNull.Value;

                var padreNombre_del_Hospital = _dataProvider.GetParameter();
                padreNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                padreNombre_del_Hospital.DbType = DbType.String;
                padreNombre_del_Hospital.Value = (object)entity.Nombre_del_Hospital ?? DBNull.Value;
                var padrePiso_hospital = _dataProvider.GetParameter();
                padrePiso_hospital.ParameterName = "Piso_hospital";
                padrePiso_hospital.DbType = DbType.String;
                padrePiso_hospital.Value = (object)entity.Piso_hospital ?? DBNull.Value;
                var padreNumero_de_consultorio = _dataProvider.GetParameter();
                padreNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                padreNumero_de_consultorio.DbType = DbType.String;
                padreNumero_de_consultorio.Value = (object)entity.Numero_de_consultorio ?? DBNull.Value;
                var padreSe_ajusta_tabulador = _dataProvider.GetParameter();
                padreSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                padreSe_ajusta_tabulador.DbType = DbType.Int32;
                padreSe_ajusta_tabulador.Value = (object)entity.Se_ajusta_tabulador ?? DBNull.Value;

                var padreProfesion = _dataProvider.GetParameter();
                padreProfesion.ParameterName = "Profesion";
                padreProfesion.DbType = DbType.Int32;
                padreProfesion.Value = (object)entity.Profesion ?? DBNull.Value;

                var padreEspecialidad = _dataProvider.GetParameter();
                padreEspecialidad.ParameterName = "Especialidad";
                padreEspecialidad.DbType = DbType.Int32;
                padreEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var padreResumen_Profesional = _dataProvider.GetParameter();
                padreResumen_Profesional.ParameterName = "Resumen_Profesional";
                padreResumen_Profesional.DbType = DbType.String;
                padreResumen_Profesional.Value = (object)entity.Resumen_Profesional ?? DBNull.Value;
                var padreRegimen_Fiscal = _dataProvider.GetParameter();
                padreRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                padreRegimen_Fiscal.DbType = DbType.Int32;
                padreRegimen_Fiscal.Value = (object)entity.Regimen_Fiscal ?? DBNull.Value;

                var padreNombre_o_Razon_Social = _dataProvider.GetParameter();
                padreNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                padreNombre_o_Razon_Social.DbType = DbType.String;
                padreNombre_o_Razon_Social.Value = (object)entity.Nombre_o_Razon_Social ?? DBNull.Value;
                var padreRFC = _dataProvider.GetParameter();
                padreRFC.ParameterName = "RFC";
                padreRFC.DbType = DbType.String;
                padreRFC.Value = (object)entity.RFC ?? DBNull.Value;
                var padreCalle_Fiscal = _dataProvider.GetParameter();
                padreCalle_Fiscal.ParameterName = "Calle_Fiscal";
                padreCalle_Fiscal.DbType = DbType.String;
                padreCalle_Fiscal.Value = (object)entity.Calle_Fiscal ?? DBNull.Value;
                var padreNumero_exterior_Fiscal = _dataProvider.GetParameter();
                padreNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                padreNumero_exterior_Fiscal.DbType = DbType.String;
                padreNumero_exterior_Fiscal.Value = (object)entity.Numero_exterior_Fiscal ?? DBNull.Value;
                var padreNumero_interior_Fiscal = _dataProvider.GetParameter();
                padreNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                padreNumero_interior_Fiscal.DbType = DbType.String;
                padreNumero_interior_Fiscal.Value = (object)entity.Numero_interior_Fiscal ?? DBNull.Value;
                var padreColonia_Fiscal = _dataProvider.GetParameter();
                padreColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                padreColonia_Fiscal.DbType = DbType.String;
                padreColonia_Fiscal.Value = (object)entity.Colonia_Fiscal ?? DBNull.Value;
                var padreCP_Fiscal = _dataProvider.GetParameter();
                padreCP_Fiscal.ParameterName = "CP_Fiscal";
                padreCP_Fiscal.DbType = DbType.Int32;
                padreCP_Fiscal.Value = (object)entity.CP_Fiscal ?? DBNull.Value;

                var padreCiudad_Fiscal = _dataProvider.GetParameter();
                padreCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                padreCiudad_Fiscal.DbType = DbType.String;
                padreCiudad_Fiscal.Value = (object)entity.Ciudad_Fiscal ?? DBNull.Value;
                var padreEstado_Fiscal = _dataProvider.GetParameter();
                padreEstado_Fiscal.ParameterName = "Estado_Fiscal";
                padreEstado_Fiscal.DbType = DbType.Int32;
                padreEstado_Fiscal.Value = (object)entity.Estado_Fiscal ?? DBNull.Value;

                var padrePais_Fiscal = _dataProvider.GetParameter();
                padrePais_Fiscal.ParameterName = "Pais_Fiscal";
                padrePais_Fiscal.DbType = DbType.Int32;
                padrePais_Fiscal.Value = (object)entity.Pais_Fiscal ?? DBNull.Value;

                var padreTelefono = _dataProvider.GetParameter();
                padreTelefono.ParameterName = "Telefono";
                padreTelefono.DbType = DbType.String;
                padreTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var padreFax = _dataProvider.GetParameter();
                padreFax.ParameterName = "Fax";
                padreFax.DbType = DbType.String;
                padreFax.Value = (object)entity.Fax ?? DBNull.Value;
                var padreCedula_Fiscal_Documento = _dataProvider.GetParameter();
                padreCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                padreCedula_Fiscal_Documento.DbType = DbType.Int32;
                padreCedula_Fiscal_Documento.Value = (object)entity.Cedula_Fiscal_Documento ?? DBNull.Value;

                var padreComprobante_de_Domicilio = _dataProvider.GetParameter();
                padreComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                padreComprobante_de_Domicilio.DbType = DbType.Int32;
                padreComprobante_de_Domicilio.Value = (object)entity.Comprobante_de_Domicilio ?? DBNull.Value;

                var padreCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                padreCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                padreCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                padreCalificacion_Red_de_Medicos.Value = (object)entity.Calificacion_Red_de_Medicos ?? DBNull.Value;

                var padreBanco = _dataProvider.GetParameter();
                padreBanco.ParameterName = "Banco";
                padreBanco.DbType = DbType.Int32;
                padreBanco.Value = (object)entity.Banco ?? DBNull.Value;

                var padreCLABE_Interbancaria = _dataProvider.GetParameter();
                padreCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                padreCLABE_Interbancaria.DbType = DbType.String;
                padreCLABE_Interbancaria.Value = (object)entity.CLABE_Interbancaria ?? DBNull.Value;
                var padreNumero_de_Cuenta = _dataProvider.GetParameter();
                padreNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                padreNumero_de_Cuenta.DbType = DbType.String;
                padreNumero_de_Cuenta.Value = (object)entity.Numero_de_Cuenta ?? DBNull.Value;
                var padreNombre_del_Titular = _dataProvider.GetParameter();
                padreNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                padreNombre_del_Titular.DbType = DbType.String;
                padreNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMedicos>("sp_InsMedicos" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreTitulo_Personal
, padreNombres
, padreApellido_Paterno
, padreApellido_Materno
, padreNombre_Completo
, padreTipo_de_Especialista
, padreFoto
, padreNombre_de_usuario
, padreUsuario_Registrado
, padreEmail
, padreCelular
, padreFecha_de_nacimiento
, padrePais_de_nacimiento
, padreEntidad_de_nacimiento
, padreSexo
, padreEmail_institucional
, padreEstatus
, padreEmail_ppal_publico
, padreEmail_de_contacto
, padreCalle
, padreNumero_exterior
, padreNumero_interior
, padreColonia
, padreCP
, padreCiudad
, padreEstado
, padrePais
, padreTelefonos
, padreEn_Hospital
, padreNombre_del_Hospital
, padrePiso_hospital
, padreNumero_de_consultorio
, padreSe_ajusta_tabulador
, padreProfesion
, padreEspecialidad
, padreResumen_Profesional
, padreRegimen_Fiscal
, padreNombre_o_Razon_Social
, padreRFC
, padreCalle_Fiscal
, padreNumero_exterior_Fiscal
, padreNumero_interior_Fiscal
, padreColonia_Fiscal
, padreCP_Fiscal
, padreCiudad_Fiscal
, padreEstado_Fiscal
, padrePais_Fiscal
, padreTelefono
, padreFax
, padreCedula_Fiscal_Documento
, padreComprobante_de_Domicilio
, padreCalificacion_Red_de_Medicos
, padreBanco
, padreCLABE_Interbancaria
, padreNumero_de_Cuenta
, padreNombre_del_Titular
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

        public int Update(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)entity.Titulo_Personal ?? DBNull.Value;

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
                var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)entity.Tipo_de_Especialista ?? DBNull.Value;

                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)entity.Foto ?? DBNull.Value;

                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)entity.Nombre_de_usuario ?? DBNull.Value;
                var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;

                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;

                var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)entity.Pais_de_nacimiento ?? DBNull.Value;

                var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)entity.Entidad_de_nacimiento ?? DBNull.Value;

                var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)entity.Email_institucional ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)entity.Email_ppal_publico ?? DBNull.Value;

                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)entity.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)entity.CP ?? DBNull.Value;

                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;

                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;

                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)entity.Telefonos ?? DBNull.Value;
                var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)entity.En_Hospital ?? DBNull.Value;

                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)entity.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)entity.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)entity.Numero_de_consultorio ?? DBNull.Value;
                var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)entity.Se_ajusta_tabulador ?? DBNull.Value;

                var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)entity.Profesion ?? DBNull.Value;

                var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)entity.Resumen_Profesional ?? DBNull.Value;
                var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)entity.Regimen_Fiscal ?? DBNull.Value;

                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)entity.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)entity.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)entity.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)entity.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)entity.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)entity.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)entity.CP_Fiscal ?? DBNull.Value;

                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)entity.Ciudad_Fiscal ?? DBNull.Value;
                var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)entity.Estado_Fiscal ?? DBNull.Value;

                var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)entity.Pais_Fiscal ?? DBNull.Value;

                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)entity.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)entity.Cedula_Fiscal_Documento ?? DBNull.Value;

                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)entity.Comprobante_de_Domicilio ?? DBNull.Value;

                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)entity.Calificacion_Red_de_Medicos ?? DBNull.Value;

                var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)entity.Banco ?? DBNull.Value;

                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)entity.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)entity.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)entity.Titulo_Personal ?? DBNull.Value;
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
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)entity.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)entity.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)entity.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)entity.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)entity.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)entity.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)MedicosDB.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)MedicosDB.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)MedicosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)MedicosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)MedicosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)MedicosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)MedicosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)MedicosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)MedicosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)MedicosDB.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)MedicosDB.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)MedicosDB.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)MedicosDB.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)MedicosDB.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)MedicosDB.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)MedicosDB.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)MedicosDB.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)MedicosDB.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)MedicosDB.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)MedicosDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)MedicosDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)MedicosDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)MedicosDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)MedicosDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)MedicosDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)MedicosDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)MedicosDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)MedicosDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)MedicosDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)MedicosDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)MedicosDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)MedicosDB.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)MedicosDB.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)MedicosDB.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)MedicosDB.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)MedicosDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)MedicosDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)MedicosDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)MedicosDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Datos_de_Contacto(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)MedicosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)MedicosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)MedicosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)MedicosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)MedicosDB.Titulo_Personal ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)MedicosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)MedicosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)MedicosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)MedicosDB.Nombre_Completo ?? DBNull.Value;
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)MedicosDB.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)MedicosDB.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)MedicosDB.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)MedicosDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)MedicosDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)MedicosDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)MedicosDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)MedicosDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)MedicosDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)MedicosDB.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)MedicosDB.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)MedicosDB.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)entity.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)entity.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)entity.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)entity.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)entity.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)entity.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)entity.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)entity.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)entity.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)MedicosDB.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)MedicosDB.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)MedicosDB.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)MedicosDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)MedicosDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)MedicosDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)MedicosDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)MedicosDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)MedicosDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)MedicosDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)MedicosDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)MedicosDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)MedicosDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)MedicosDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)MedicosDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)MedicosDB.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)MedicosDB.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)MedicosDB.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)MedicosDB.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)MedicosDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)MedicosDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)MedicosDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)MedicosDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Datos_Profesionales(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)MedicosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)MedicosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)MedicosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)MedicosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)MedicosDB.Titulo_Personal ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)MedicosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)MedicosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)MedicosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)MedicosDB.Nombre_Completo ?? DBNull.Value;
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)MedicosDB.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)MedicosDB.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)MedicosDB.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)MedicosDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)MedicosDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)MedicosDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)MedicosDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)MedicosDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)MedicosDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)MedicosDB.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)MedicosDB.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)MedicosDB.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)MedicosDB.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)MedicosDB.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)MedicosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)MedicosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)MedicosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)MedicosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)MedicosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)MedicosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)MedicosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)MedicosDB.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)MedicosDB.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)MedicosDB.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)MedicosDB.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)MedicosDB.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)MedicosDB.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)MedicosDB.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)entity.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)entity.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)MedicosDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)MedicosDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)MedicosDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)MedicosDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)MedicosDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)MedicosDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)MedicosDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)MedicosDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)MedicosDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)MedicosDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)MedicosDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)MedicosDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)MedicosDB.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)MedicosDB.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)MedicosDB.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)MedicosDB.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)MedicosDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)MedicosDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)MedicosDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)MedicosDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Datos_Fiscales(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)MedicosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)MedicosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)MedicosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)MedicosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)MedicosDB.Titulo_Personal ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)MedicosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)MedicosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)MedicosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)MedicosDB.Nombre_Completo ?? DBNull.Value;
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)MedicosDB.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)MedicosDB.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)MedicosDB.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)MedicosDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)MedicosDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)MedicosDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)MedicosDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)MedicosDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)MedicosDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)MedicosDB.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)MedicosDB.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)MedicosDB.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)MedicosDB.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)MedicosDB.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)MedicosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)MedicosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)MedicosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)MedicosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)MedicosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)MedicosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)MedicosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)MedicosDB.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)MedicosDB.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)MedicosDB.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)MedicosDB.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)MedicosDB.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)MedicosDB.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)MedicosDB.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)MedicosDB.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)MedicosDB.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)MedicosDB.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)entity.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)entity.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)entity.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)entity.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)entity.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)entity.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)entity.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)entity.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)entity.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)entity.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)entity.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)entity.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)MedicosDB.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)MedicosDB.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)MedicosDB.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)MedicosDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)MedicosDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)MedicosDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)MedicosDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Documentacion(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)MedicosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)MedicosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)MedicosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)MedicosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)MedicosDB.Titulo_Personal ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)MedicosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)MedicosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)MedicosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)MedicosDB.Nombre_Completo ?? DBNull.Value;
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)MedicosDB.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)MedicosDB.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)MedicosDB.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)MedicosDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)MedicosDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)MedicosDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)MedicosDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)MedicosDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)MedicosDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)MedicosDB.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)MedicosDB.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)MedicosDB.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)MedicosDB.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)MedicosDB.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)MedicosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)MedicosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)MedicosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)MedicosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)MedicosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)MedicosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)MedicosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)MedicosDB.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)MedicosDB.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)MedicosDB.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)MedicosDB.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)MedicosDB.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)MedicosDB.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)MedicosDB.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)MedicosDB.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)MedicosDB.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)MedicosDB.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)MedicosDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)MedicosDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)MedicosDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)MedicosDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)MedicosDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)MedicosDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)MedicosDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)MedicosDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)MedicosDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)MedicosDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)MedicosDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)MedicosDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)MedicosDB.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)entity.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)entity.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)MedicosDB.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)MedicosDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)MedicosDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)MedicosDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)MedicosDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Codigos_de_Referencia(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)MedicosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)MedicosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)MedicosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)MedicosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)MedicosDB.Titulo_Personal ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)MedicosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)MedicosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)MedicosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)MedicosDB.Nombre_Completo ?? DBNull.Value;
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)MedicosDB.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)MedicosDB.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)MedicosDB.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)MedicosDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)MedicosDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)MedicosDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)MedicosDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)MedicosDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)MedicosDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)MedicosDB.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)MedicosDB.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)MedicosDB.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)MedicosDB.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)MedicosDB.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)MedicosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)MedicosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)MedicosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)MedicosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)MedicosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)MedicosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)MedicosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)MedicosDB.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)MedicosDB.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)MedicosDB.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)MedicosDB.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)MedicosDB.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)MedicosDB.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)MedicosDB.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)MedicosDB.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)MedicosDB.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)MedicosDB.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)MedicosDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)MedicosDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)MedicosDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)MedicosDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)MedicosDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)MedicosDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)MedicosDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)MedicosDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)MedicosDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)MedicosDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)MedicosDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)MedicosDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)MedicosDB.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)MedicosDB.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)MedicosDB.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)MedicosDB.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)MedicosDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)MedicosDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)MedicosDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)MedicosDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Suscripcion_Red_de_Especialistas(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)MedicosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)MedicosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)MedicosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)MedicosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)MedicosDB.Titulo_Personal ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)MedicosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)MedicosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)MedicosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)MedicosDB.Nombre_Completo ?? DBNull.Value;
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)MedicosDB.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)MedicosDB.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)MedicosDB.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)MedicosDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)MedicosDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)MedicosDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)MedicosDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)MedicosDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)MedicosDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)MedicosDB.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)MedicosDB.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)MedicosDB.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)MedicosDB.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)MedicosDB.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)MedicosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)MedicosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)MedicosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)MedicosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)MedicosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)MedicosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)MedicosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)MedicosDB.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)MedicosDB.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)MedicosDB.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)MedicosDB.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)MedicosDB.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)MedicosDB.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)MedicosDB.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)MedicosDB.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)MedicosDB.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)MedicosDB.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)MedicosDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)MedicosDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)MedicosDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)MedicosDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)MedicosDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)MedicosDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)MedicosDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)MedicosDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)MedicosDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)MedicosDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)MedicosDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)MedicosDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)MedicosDB.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)MedicosDB.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)MedicosDB.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)entity.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)MedicosDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)MedicosDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)MedicosDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)MedicosDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Datos_Bancarios(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)MedicosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)MedicosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)MedicosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)MedicosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)MedicosDB.Titulo_Personal ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)MedicosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)MedicosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)MedicosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)MedicosDB.Nombre_Completo ?? DBNull.Value;
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)MedicosDB.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)MedicosDB.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)MedicosDB.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)MedicosDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)MedicosDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)MedicosDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)MedicosDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)MedicosDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)MedicosDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)MedicosDB.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)MedicosDB.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)MedicosDB.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)MedicosDB.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)MedicosDB.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)MedicosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)MedicosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)MedicosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)MedicosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)MedicosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)MedicosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)MedicosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)MedicosDB.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)MedicosDB.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)MedicosDB.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)MedicosDB.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)MedicosDB.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)MedicosDB.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)MedicosDB.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)MedicosDB.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)MedicosDB.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)MedicosDB.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)MedicosDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)MedicosDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)MedicosDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)MedicosDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)MedicosDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)MedicosDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)MedicosDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)MedicosDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)MedicosDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)MedicosDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)MedicosDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)MedicosDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)MedicosDB.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)MedicosDB.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)MedicosDB.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)MedicosDB.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)entity.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)entity.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)entity.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Facturacion(Spartane.Core.Classes.Medicos.Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medicos.Medicos MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)MedicosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)MedicosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)MedicosDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)MedicosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdTitulo_Personal = _dataProvider.GetParameter();
                paramUpdTitulo_Personal.ParameterName = "Titulo_Personal";
                paramUpdTitulo_Personal.DbType = DbType.Int32;
                paramUpdTitulo_Personal.Value = (object)MedicosDB.Titulo_Personal ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)MedicosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)MedicosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)MedicosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)MedicosDB.Nombre_Completo ?? DBNull.Value;
		var paramUpdTipo_de_Especialista = _dataProvider.GetParameter();
                paramUpdTipo_de_Especialista.ParameterName = "Tipo_de_Especialista";
                paramUpdTipo_de_Especialista.DbType = DbType.Int32;
                paramUpdTipo_de_Especialista.Value = (object)MedicosDB.Tipo_de_Especialista ?? DBNull.Value;
                var paramUpdFoto = _dataProvider.GetParameter();
                paramUpdFoto.ParameterName = "Foto";
                paramUpdFoto.DbType = DbType.Int32;
                paramUpdFoto.Value = (object)MedicosDB.Foto ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)MedicosDB.Nombre_de_usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)MedicosDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)MedicosDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)MedicosDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)MedicosDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)MedicosDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)MedicosDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)MedicosDB.Sexo ?? DBNull.Value;
                var paramUpdEmail_institucional = _dataProvider.GetParameter();
                paramUpdEmail_institucional.ParameterName = "Email_institucional";
                paramUpdEmail_institucional.DbType = DbType.String;
                paramUpdEmail_institucional.Value = (object)MedicosDB.Email_institucional ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)MedicosDB.Estatus ?? DBNull.Value;
		var paramUpdEmail_ppal_publico = _dataProvider.GetParameter();
                paramUpdEmail_ppal_publico.ParameterName = "Email_ppal_publico";
                paramUpdEmail_ppal_publico.DbType = DbType.Int32;
                paramUpdEmail_ppal_publico.Value = (object)MedicosDB.Email_ppal_publico ?? DBNull.Value;
                var paramUpdEmail_de_contacto = _dataProvider.GetParameter();
                paramUpdEmail_de_contacto.ParameterName = "Email_de_contacto";
                paramUpdEmail_de_contacto.DbType = DbType.String;
                paramUpdEmail_de_contacto.Value = (object)MedicosDB.Email_de_contacto ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)MedicosDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)MedicosDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)MedicosDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)MedicosDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)MedicosDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)MedicosDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)MedicosDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)MedicosDB.Pais ?? DBNull.Value;
                var paramUpdTelefonos = _dataProvider.GetParameter();
                paramUpdTelefonos.ParameterName = "Telefonos";
                paramUpdTelefonos.DbType = DbType.String;
                paramUpdTelefonos.Value = (object)MedicosDB.Telefonos ?? DBNull.Value;
		var paramUpdEn_Hospital = _dataProvider.GetParameter();
                paramUpdEn_Hospital.ParameterName = "En_Hospital";
                paramUpdEn_Hospital.DbType = DbType.Int32;
                paramUpdEn_Hospital.Value = (object)MedicosDB.En_Hospital ?? DBNull.Value;
                var paramUpdNombre_del_Hospital = _dataProvider.GetParameter();
                paramUpdNombre_del_Hospital.ParameterName = "Nombre_del_Hospital";
                paramUpdNombre_del_Hospital.DbType = DbType.String;
                paramUpdNombre_del_Hospital.Value = (object)MedicosDB.Nombre_del_Hospital ?? DBNull.Value;
                var paramUpdPiso_hospital = _dataProvider.GetParameter();
                paramUpdPiso_hospital.ParameterName = "Piso_hospital";
                paramUpdPiso_hospital.DbType = DbType.String;
                paramUpdPiso_hospital.Value = (object)MedicosDB.Piso_hospital ?? DBNull.Value;
                var paramUpdNumero_de_consultorio = _dataProvider.GetParameter();
                paramUpdNumero_de_consultorio.ParameterName = "Numero_de_consultorio";
                paramUpdNumero_de_consultorio.DbType = DbType.String;
                paramUpdNumero_de_consultorio.Value = (object)MedicosDB.Numero_de_consultorio ?? DBNull.Value;
		var paramUpdSe_ajusta_tabulador = _dataProvider.GetParameter();
                paramUpdSe_ajusta_tabulador.ParameterName = "Se_ajusta_tabulador";
                paramUpdSe_ajusta_tabulador.DbType = DbType.Int32;
                paramUpdSe_ajusta_tabulador.Value = (object)MedicosDB.Se_ajusta_tabulador ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)MedicosDB.Profesion ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)MedicosDB.Especialidad ?? DBNull.Value;
                var paramUpdResumen_Profesional = _dataProvider.GetParameter();
                paramUpdResumen_Profesional.ParameterName = "Resumen_Profesional";
                paramUpdResumen_Profesional.DbType = DbType.String;
                paramUpdResumen_Profesional.Value = (object)MedicosDB.Resumen_Profesional ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)MedicosDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)MedicosDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)MedicosDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)MedicosDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)MedicosDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)MedicosDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)MedicosDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)MedicosDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)MedicosDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)MedicosDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)MedicosDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)MedicosDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)MedicosDB.Fax ?? DBNull.Value;
                var paramUpdCedula_Fiscal_Documento = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal_Documento.ParameterName = "Cedula_Fiscal_Documento";
                paramUpdCedula_Fiscal_Documento.DbType = DbType.Int32;
                paramUpdCedula_Fiscal_Documento.Value = (object)MedicosDB.Cedula_Fiscal_Documento ?? DBNull.Value;
                var paramUpdComprobante_de_Domicilio = _dataProvider.GetParameter();
                paramUpdComprobante_de_Domicilio.ParameterName = "Comprobante_de_Domicilio";
                paramUpdComprobante_de_Domicilio.DbType = DbType.Int32;
                paramUpdComprobante_de_Domicilio.Value = (object)MedicosDB.Comprobante_de_Domicilio ?? DBNull.Value;
                var paramUpdCalificacion_Red_de_Medicos = _dataProvider.GetParameter();
                paramUpdCalificacion_Red_de_Medicos.ParameterName = "Calificacion_Red_de_Medicos";
                paramUpdCalificacion_Red_de_Medicos.DbType = DbType.Int32;
                paramUpdCalificacion_Red_de_Medicos.Value = (object)MedicosDB.Calificacion_Red_de_Medicos ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)MedicosDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)MedicosDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)MedicosDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)MedicosDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedicos>("sp_UpdMedicos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTitulo_Personal , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdTipo_de_Especialista , paramUpdFoto , paramUpdNombre_de_usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEmail_institucional , paramUpdEstatus , paramUpdEmail_ppal_publico , paramUpdEmail_de_contacto , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdTelefonos , paramUpdEn_Hospital , paramUpdNombre_del_Hospital , paramUpdPiso_hospital , paramUpdNumero_de_consultorio , paramUpdSe_ajusta_tabulador , paramUpdProfesion , paramUpdEspecialidad , paramUpdResumen_Profesional , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax , paramUpdCedula_Fiscal_Documento , paramUpdComprobante_de_Domicilio , paramUpdCalificacion_Red_de_Medicos , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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


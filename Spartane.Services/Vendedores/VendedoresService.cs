using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Vendedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Vendedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class VendedoresService : IVendedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Vendedores.Vendedores> _VendedoresRepository;
        #endregion

        #region Ctor
        public VendedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Vendedores.Vendedores> VendedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._VendedoresRepository = VendedoresRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._VendedoresRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Vendedores.Vendedores> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Vendedores.Vendedores>("sp_SelAllVendedores");
        }

        public IList<Core.Classes.Vendedores.Vendedores> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallVendedores_Complete>("sp_SelAllComplete_Vendedores");
            return data.Select(m => new Core.Classes.Vendedores.Vendedores
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Nombre_de_Usuario = m.Nombre_de_Usuario
                ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_Registrado.GetValueOrDefault(), Name = m.Usuario_Registrado_Name }
                ,Email = m.Email
                ,Celular = m.Celular
                ,Fecha_de_nacimiento = m.Fecha_de_nacimiento
                ,Pais_de_nacimiento_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais_de_nacimiento.GetValueOrDefault(), Nombre_del_Pais = m.Pais_de_nacimiento_Nombre_del_Pais }
                ,Entidad_de_nacimiento_Estado = new Core.Classes.Estado.Estado() { Clave = m.Entidad_de_nacimiento.GetValueOrDefault(), Nombre_del_Estado = m.Entidad_de_nacimiento_Nombre_del_Estado }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Vendedores>("sp_ListSelCount_Vendedores", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Vendedores.Vendedores> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllVendedores>("sp_ListSelAll_Vendedores", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Vendedores.Vendedores
                {
                    Folio = m.Vendedores_Folio,
                    Fecha_de_Registro = m.Vendedores_Fecha_de_Registro,
                    Hora_de_Registro = m.Vendedores_Hora_de_Registro,
                    Usuario_que_Registra = m.Vendedores_Usuario_que_Registra,
                    Nombres = m.Vendedores_Nombres,
                    Apellido_Paterno = m.Vendedores_Apellido_Paterno,
                    Apellido_Materno = m.Vendedores_Apellido_Materno,
                    Nombre_Completo = m.Vendedores_Nombre_Completo,
                    Nombre_de_Usuario = m.Vendedores_Nombre_de_Usuario,
                    Usuario_Registrado = m.Vendedores_Usuario_Registrado,
                    Email = m.Vendedores_Email,
                    Celular = m.Vendedores_Celular,
                    Fecha_de_nacimiento = m.Vendedores_Fecha_de_nacimiento,
                    Pais_de_nacimiento = m.Vendedores_Pais_de_nacimiento,
                    Entidad_de_nacimiento = m.Vendedores_Entidad_de_nacimiento,
                    Sexo = m.Vendedores_Sexo,
                    Estatus = m.Vendedores_Estatus,
                    Banco = m.Vendedores_Banco,
                    CLABE_Interbancaria = m.Vendedores_CLABE_Interbancaria,
                    Numero_de_Cuenta = m.Vendedores_Numero_de_Cuenta,
                    Nombre_del_Titular = m.Vendedores_Nombre_del_Titular,

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

        public IList<Spartane.Core.Classes.Vendedores.Vendedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._VendedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Vendedores.Vendedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._VendedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Vendedores.VendedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllVendedores>("sp_ListSelAll_Vendedores", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            VendedoresPagingModel result = null;

            if (data != null)
            {
                result = new VendedoresPagingModel
                {
                    Vendedoress =
                        data.Select(m => new Spartane.Core.Classes.Vendedores.Vendedores
                {
                    Folio = m.Vendedores_Folio
                    ,Fecha_de_Registro = m.Vendedores_Fecha_de_Registro
                    ,Hora_de_Registro = m.Vendedores_Hora_de_Registro
                    ,Usuario_que_Registra = m.Vendedores_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Vendedores_Usuario_que_Registra.GetValueOrDefault(), Name = m.Vendedores_Usuario_que_Registra_Name }
                    ,Nombres = m.Vendedores_Nombres
                    ,Apellido_Paterno = m.Vendedores_Apellido_Paterno
                    ,Apellido_Materno = m.Vendedores_Apellido_Materno
                    ,Nombre_Completo = m.Vendedores_Nombre_Completo
                    ,Nombre_de_Usuario = m.Vendedores_Nombre_de_Usuario
                    ,Usuario_Registrado = m.Vendedores_Usuario_Registrado
                    ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Vendedores_Usuario_Registrado.GetValueOrDefault(), Name = m.Vendedores_Usuario_Registrado_Name }
                    ,Email = m.Vendedores_Email
                    ,Celular = m.Vendedores_Celular
                    ,Fecha_de_nacimiento = m.Vendedores_Fecha_de_nacimiento
                    ,Pais_de_nacimiento = m.Vendedores_Pais_de_nacimiento
                    ,Pais_de_nacimiento_Pais = new Core.Classes.Pais.Pais() { Clave = m.Vendedores_Pais_de_nacimiento.GetValueOrDefault(), Nombre_del_Pais = m.Vendedores_Pais_de_nacimiento_Nombre_del_Pais }
                    ,Entidad_de_nacimiento = m.Vendedores_Entidad_de_nacimiento
                    ,Entidad_de_nacimiento_Estado = new Core.Classes.Estado.Estado() { Clave = m.Vendedores_Entidad_de_nacimiento.GetValueOrDefault(), Nombre_del_Estado = m.Vendedores_Entidad_de_nacimiento_Nombre_del_Estado }
                    ,Sexo = m.Vendedores_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Vendedores_Sexo.GetValueOrDefault(), Descripcion = m.Vendedores_Sexo_Descripcion }
                    ,Estatus = m.Vendedores_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Vendedores_Estatus.GetValueOrDefault(), Descripcion = m.Vendedores_Estatus_Descripcion }
                    ,Banco = m.Vendedores_Banco
                    ,Banco_Bancos = new Core.Classes.Bancos.Bancos() { Clave = m.Vendedores_Banco.GetValueOrDefault(), Nombre = m.Vendedores_Banco_Nombre }
                    ,CLABE_Interbancaria = m.Vendedores_CLABE_Interbancaria
                    ,Numero_de_Cuenta = m.Vendedores_Numero_de_Cuenta
                    ,Nombre_del_Titular = m.Vendedores_Nombre_del_Titular

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Vendedores.Vendedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._VendedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Vendedores.Vendedores GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Vendedores.Vendedores>("sp_GetVendedores", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelVendedores>("sp_DelVendedores", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Vendedores.Vendedores entity)
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
                var padreNombre_de_Usuario = _dataProvider.GetParameter();
                padreNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                padreNombre_de_Usuario.DbType = DbType.String;
                padreNombre_de_Usuario.Value = (object)entity.Nombre_de_Usuario ?? DBNull.Value;
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

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsVendedores>("sp_InsVendedores" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombres
, padreApellido_Paterno
, padreApellido_Materno
, padreNombre_Completo
, padreNombre_de_Usuario
, padreUsuario_Registrado
, padreEmail
, padreCelular
, padreFecha_de_nacimiento
, padrePais_de_nacimiento
, padreEntidad_de_nacimiento
, padreSexo
, padreEstatus
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

        public int Update(Spartane.Core.Classes.Vendedores.Vendedores entity)
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
                var paramUpdNombre_de_Usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                paramUpdNombre_de_Usuario.DbType = DbType.String;
                paramUpdNombre_de_Usuario.Value = (object)entity.Nombre_de_Usuario ?? DBNull.Value;
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

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdVendedores>("sp_UpdVendedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEstatus , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Vendedores.Vendedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Vendedores.Vendedores VendedoresDB = GetByKey(entity.Folio, false);
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
                var paramUpdNombre_de_Usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                paramUpdNombre_de_Usuario.DbType = DbType.String;
                paramUpdNombre_de_Usuario.Value = (object)entity.Nombre_de_Usuario ?? DBNull.Value;
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
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)VendedoresDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)VendedoresDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)VendedoresDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)VendedoresDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdVendedores>("sp_UpdVendedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEstatus , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Codigos_de_Referencia(Spartane.Core.Classes.Vendedores.Vendedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Vendedores.Vendedores VendedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)VendedoresDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)VendedoresDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)VendedoresDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)VendedoresDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)VendedoresDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)VendedoresDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)VendedoresDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)VendedoresDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdNombre_de_Usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                paramUpdNombre_de_Usuario.DbType = DbType.String;
                paramUpdNombre_de_Usuario.Value = (object)VendedoresDB.Nombre_de_Usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)VendedoresDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)VendedoresDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)VendedoresDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)VendedoresDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)VendedoresDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)VendedoresDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)VendedoresDB.Sexo ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)VendedoresDB.Estatus ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)VendedoresDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)VendedoresDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)VendedoresDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)VendedoresDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdVendedores>("sp_UpdVendedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEstatus , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Datos_Bancarios(Spartane.Core.Classes.Vendedores.Vendedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Vendedores.Vendedores VendedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)VendedoresDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)VendedoresDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)VendedoresDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)VendedoresDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)VendedoresDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)VendedoresDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)VendedoresDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)VendedoresDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdNombre_de_Usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                paramUpdNombre_de_Usuario.DbType = DbType.String;
                paramUpdNombre_de_Usuario.Value = (object)VendedoresDB.Nombre_de_Usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)VendedoresDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)VendedoresDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)VendedoresDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)VendedoresDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)VendedoresDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)VendedoresDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)VendedoresDB.Sexo ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)VendedoresDB.Estatus ?? DBNull.Value;
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdVendedores>("sp_UpdVendedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEstatus , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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

		public int Update_Facturacion(Spartane.Core.Classes.Vendedores.Vendedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Vendedores.Vendedores VendedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)VendedoresDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)VendedoresDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)VendedoresDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)VendedoresDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)VendedoresDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)VendedoresDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)VendedoresDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)VendedoresDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdNombre_de_Usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                paramUpdNombre_de_Usuario.DbType = DbType.String;
                paramUpdNombre_de_Usuario.Value = (object)VendedoresDB.Nombre_de_Usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)VendedoresDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)VendedoresDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)VendedoresDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)VendedoresDB.Fecha_de_nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)VendedoresDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)VendedoresDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)VendedoresDB.Sexo ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)VendedoresDB.Estatus ?? DBNull.Value;
		var paramUpdBanco = _dataProvider.GetParameter();
                paramUpdBanco.ParameterName = "Banco";
                paramUpdBanco.DbType = DbType.Int32;
                paramUpdBanco.Value = (object)VendedoresDB.Banco ?? DBNull.Value;
                var paramUpdCLABE_Interbancaria = _dataProvider.GetParameter();
                paramUpdCLABE_Interbancaria.ParameterName = "CLABE_Interbancaria";
                paramUpdCLABE_Interbancaria.DbType = DbType.String;
                paramUpdCLABE_Interbancaria.Value = (object)VendedoresDB.CLABE_Interbancaria ?? DBNull.Value;
                var paramUpdNumero_de_Cuenta = _dataProvider.GetParameter();
                paramUpdNumero_de_Cuenta.ParameterName = "Numero_de_Cuenta";
                paramUpdNumero_de_Cuenta.DbType = DbType.String;
                paramUpdNumero_de_Cuenta.Value = (object)VendedoresDB.Numero_de_Cuenta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)VendedoresDB.Nombre_del_Titular ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdVendedores>("sp_UpdVendedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdEstatus , paramUpdBanco , paramUpdCLABE_Interbancaria , paramUpdNumero_de_Cuenta , paramUpdNombre_del_Titular ).FirstOrDefault();

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


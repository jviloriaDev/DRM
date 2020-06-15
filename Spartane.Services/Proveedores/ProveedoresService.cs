using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Proveedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Proveedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ProveedoresService : IProveedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Proveedores.Proveedores> _ProveedoresRepository;
        #endregion

        #region Ctor
        public ProveedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Proveedores.Proveedores> ProveedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ProveedoresRepository = ProveedoresRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._ProveedoresRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Proveedores.Proveedores> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Proveedores.Proveedores>("sp_SelAllProveedores");
        }

        public IList<Core.Classes.Proveedores.Proveedores> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallProveedores_Complete>("sp_SelAllComplete_Proveedores");
            return data.Select(m => new Core.Classes.Proveedores.Proveedores
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombre_del_Proveedor = m.Nombre_del_Proveedor
                ,Tipo_de_Proveedor_Tipo_de_proveedor = new Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor() { Clave = m.Tipo_de_Proveedor.GetValueOrDefault(), Descripcion = m.Tipo_de_Proveedor_Descripcion }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Nombre_de_Usuario = m.Nombre_de_Usuario
                ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_Registrado.GetValueOrDefault(), Name = m.Usuario_Registrado_Name }
                ,Email = m.Email
                ,Celular = m.Celular
                ,Fecha_de_Nacimiento = m.Fecha_de_Nacimiento
                ,Pais_de_nacimiento_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais_de_nacimiento.GetValueOrDefault(), Nombre_del_Pais = m.Pais_de_nacimiento_Nombre_del_Pais }
                ,Entidad_de_nacimiento_Estado = new Core.Classes.Estado.Estado() { Clave = m.Entidad_de_nacimiento.GetValueOrDefault(), Nombre_del_Estado = m.Entidad_de_nacimiento_Nombre_del_Estado }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Regimen_Fiscal_Regimenes_Fiscales = new Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales() { Clave = m.Regimen_Fiscal.GetValueOrDefault(), Descripcion = m.Regimen_Fiscal_Descripcion }
                ,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
                ,RFC = m.RFC
                ,Calle_Fiscal = m.Calle_Fiscal
                ,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
                ,Numero_interior_Fiscal = m.Numero_interior_Fiscal
                ,Colonia_Fiscal = m.Colonia_Fiscal
                ,C_P__Fiscal = m.C_P__Fiscal
                ,Ciudad_Fiscal = m.Ciudad_Fiscal
                ,Estado_Fiscal_Estado = new Core.Classes.Estado.Estado() { Clave = m.Estado_Fiscal.GetValueOrDefault(), Nombre_del_Estado = m.Estado_Fiscal_Nombre_del_Estado }
                ,Pais_Fiscal_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais_Fiscal.GetValueOrDefault(), Nombre_del_Pais = m.Pais_Fiscal_Nombre_del_Pais }
                ,Telefono = m.Telefono
                ,Fax = m.Fax


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Proveedores>("sp_ListSelCount_Proveedores", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Proveedores.Proveedores> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllProveedores>("sp_ListSelAll_Proveedores", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Proveedores.Proveedores
                {
                    Folio = m.Proveedores_Folio,
                    Fecha_de_Registro = m.Proveedores_Fecha_de_Registro,
                    Hora_de_Registro = m.Proveedores_Hora_de_Registro,
                    Usuario_que_Registra = m.Proveedores_Usuario_que_Registra,
                    Nombre_del_Proveedor = m.Proveedores_Nombre_del_Proveedor,
                    Tipo_de_Proveedor = m.Proveedores_Tipo_de_Proveedor,
                    Estatus = m.Proveedores_Estatus,
                    Nombres = m.Proveedores_Nombres,
                    Apellido_Paterno = m.Proveedores_Apellido_Paterno,
                    Apellido_Materno = m.Proveedores_Apellido_Materno,
                    Nombre_Completo = m.Proveedores_Nombre_Completo,
                    Nombre_de_Usuario = m.Proveedores_Nombre_de_Usuario,
                    Usuario_Registrado = m.Proveedores_Usuario_Registrado,
                    Email = m.Proveedores_Email,
                    Celular = m.Proveedores_Celular,
                    Fecha_de_Nacimiento = m.Proveedores_Fecha_de_Nacimiento,
                    Pais_de_nacimiento = m.Proveedores_Pais_de_nacimiento,
                    Entidad_de_nacimiento = m.Proveedores_Entidad_de_nacimiento,
                    Sexo = m.Proveedores_Sexo,
                    Regimen_Fiscal = m.Proveedores_Regimen_Fiscal,
                    Nombre_o_Razon_Social = m.Proveedores_Nombre_o_Razon_Social,
                    RFC = m.Proveedores_RFC,
                    Calle_Fiscal = m.Proveedores_Calle_Fiscal,
                    Numero_exterior_Fiscal = m.Proveedores_Numero_exterior_Fiscal,
                    Numero_interior_Fiscal = m.Proveedores_Numero_interior_Fiscal,
                    Colonia_Fiscal = m.Proveedores_Colonia_Fiscal,
                    C_P__Fiscal = m.Proveedores_C_P__Fiscal,
                    Ciudad_Fiscal = m.Proveedores_Ciudad_Fiscal,
                    Estado_Fiscal = m.Proveedores_Estado_Fiscal,
                    Pais_Fiscal = m.Proveedores_Pais_Fiscal,
                    Telefono = m.Proveedores_Telefono,
                    Fax = m.Proveedores_Fax,

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

        public IList<Spartane.Core.Classes.Proveedores.Proveedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Proveedores.Proveedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ProveedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Proveedores.ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllProveedores>("sp_ListSelAll_Proveedores", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            ProveedoresPagingModel result = null;

            if (data != null)
            {
                result = new ProveedoresPagingModel
                {
                    Proveedoress =
                        data.Select(m => new Spartane.Core.Classes.Proveedores.Proveedores
                {
                    Folio = m.Proveedores_Folio
                    ,Fecha_de_Registro = m.Proveedores_Fecha_de_Registro
                    ,Hora_de_Registro = m.Proveedores_Hora_de_Registro
                    ,Usuario_que_Registra = m.Proveedores_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Proveedores_Usuario_que_Registra.GetValueOrDefault(), Name = m.Proveedores_Usuario_que_Registra_Name }
                    ,Nombre_del_Proveedor = m.Proveedores_Nombre_del_Proveedor
                    ,Tipo_de_Proveedor = m.Proveedores_Tipo_de_Proveedor
                    ,Tipo_de_Proveedor_Tipo_de_proveedor = new Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor() { Clave = m.Proveedores_Tipo_de_Proveedor.GetValueOrDefault(), Descripcion = m.Proveedores_Tipo_de_Proveedor_Descripcion }
                    ,Estatus = m.Proveedores_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Proveedores_Estatus.GetValueOrDefault(), Descripcion = m.Proveedores_Estatus_Descripcion }
                    ,Nombres = m.Proveedores_Nombres
                    ,Apellido_Paterno = m.Proveedores_Apellido_Paterno
                    ,Apellido_Materno = m.Proveedores_Apellido_Materno
                    ,Nombre_Completo = m.Proveedores_Nombre_Completo
                    ,Nombre_de_Usuario = m.Proveedores_Nombre_de_Usuario
                    ,Usuario_Registrado = m.Proveedores_Usuario_Registrado
                    ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Proveedores_Usuario_Registrado.GetValueOrDefault(), Name = m.Proveedores_Usuario_Registrado_Name }
                    ,Email = m.Proveedores_Email
                    ,Celular = m.Proveedores_Celular
                    ,Fecha_de_Nacimiento = m.Proveedores_Fecha_de_Nacimiento
                    ,Pais_de_nacimiento = m.Proveedores_Pais_de_nacimiento
                    ,Pais_de_nacimiento_Pais = new Core.Classes.Pais.Pais() { Clave = m.Proveedores_Pais_de_nacimiento.GetValueOrDefault(), Nombre_del_Pais = m.Proveedores_Pais_de_nacimiento_Nombre_del_Pais }
                    ,Entidad_de_nacimiento = m.Proveedores_Entidad_de_nacimiento
                    ,Entidad_de_nacimiento_Estado = new Core.Classes.Estado.Estado() { Clave = m.Proveedores_Entidad_de_nacimiento.GetValueOrDefault(), Nombre_del_Estado = m.Proveedores_Entidad_de_nacimiento_Nombre_del_Estado }
                    ,Sexo = m.Proveedores_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Proveedores_Sexo.GetValueOrDefault(), Descripcion = m.Proveedores_Sexo_Descripcion }
                    ,Regimen_Fiscal = m.Proveedores_Regimen_Fiscal
                    ,Regimen_Fiscal_Regimenes_Fiscales = new Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales() { Clave = m.Proveedores_Regimen_Fiscal.GetValueOrDefault(), Descripcion = m.Proveedores_Regimen_Fiscal_Descripcion }
                    ,Nombre_o_Razon_Social = m.Proveedores_Nombre_o_Razon_Social
                    ,RFC = m.Proveedores_RFC
                    ,Calle_Fiscal = m.Proveedores_Calle_Fiscal
                    ,Numero_exterior_Fiscal = m.Proveedores_Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = m.Proveedores_Numero_interior_Fiscal
                    ,Colonia_Fiscal = m.Proveedores_Colonia_Fiscal
                    ,C_P__Fiscal = m.Proveedores_C_P__Fiscal
                    ,Ciudad_Fiscal = m.Proveedores_Ciudad_Fiscal
                    ,Estado_Fiscal = m.Proveedores_Estado_Fiscal
                    ,Estado_Fiscal_Estado = new Core.Classes.Estado.Estado() { Clave = m.Proveedores_Estado_Fiscal.GetValueOrDefault(), Nombre_del_Estado = m.Proveedores_Estado_Fiscal_Nombre_del_Estado }
                    ,Pais_Fiscal = m.Proveedores_Pais_Fiscal
                    ,Pais_Fiscal_Pais = new Core.Classes.Pais.Pais() { Clave = m.Proveedores_Pais_Fiscal.GetValueOrDefault(), Nombre_del_Pais = m.Proveedores_Pais_Fiscal_Nombre_del_Pais }
                    ,Telefono = m.Proveedores_Telefono
                    ,Fax = m.Proveedores_Fax

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Proveedores.Proveedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ProveedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Proveedores.Proveedores GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Proveedores.Proveedores>("sp_GetProveedores", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelProveedores>("sp_DelProveedores", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Proveedores.Proveedores entity)
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

                var padreNombre_del_Proveedor = _dataProvider.GetParameter();
                padreNombre_del_Proveedor.ParameterName = "Nombre_del_Proveedor";
                padreNombre_del_Proveedor.DbType = DbType.String;
                padreNombre_del_Proveedor.Value = (object)entity.Nombre_del_Proveedor ?? DBNull.Value;
                var padreTipo_de_Proveedor = _dataProvider.GetParameter();
                padreTipo_de_Proveedor.ParameterName = "Tipo_de_Proveedor";
                padreTipo_de_Proveedor.DbType = DbType.Int32;
                padreTipo_de_Proveedor.Value = (object)entity.Tipo_de_Proveedor ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

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
                var padreFecha_de_Nacimiento = _dataProvider.GetParameter();
                padreFecha_de_Nacimiento.ParameterName = "Fecha_de_Nacimiento";
                padreFecha_de_Nacimiento.DbType = DbType.DateTime;
                padreFecha_de_Nacimiento.Value = (object)entity.Fecha_de_Nacimiento ?? DBNull.Value;

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
                padreNumero_exterior_Fiscal.DbType = DbType.Int32;
                padreNumero_exterior_Fiscal.Value = (object)entity.Numero_exterior_Fiscal ?? DBNull.Value;

                var padreNumero_interior_Fiscal = _dataProvider.GetParameter();
                padreNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                padreNumero_interior_Fiscal.DbType = DbType.Int32;
                padreNumero_interior_Fiscal.Value = (object)entity.Numero_interior_Fiscal ?? DBNull.Value;

                var padreColonia_Fiscal = _dataProvider.GetParameter();
                padreColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                padreColonia_Fiscal.DbType = DbType.String;
                padreColonia_Fiscal.Value = (object)entity.Colonia_Fiscal ?? DBNull.Value;
                var padreC_P__Fiscal = _dataProvider.GetParameter();
                padreC_P__Fiscal.ParameterName = "C_P__Fiscal";
                padreC_P__Fiscal.DbType = DbType.Int32;
                padreC_P__Fiscal.Value = (object)entity.C_P__Fiscal ?? DBNull.Value;

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
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsProveedores>("sp_InsProveedores" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombre_del_Proveedor
, padreTipo_de_Proveedor
, padreEstatus
, padreNombres
, padreApellido_Paterno
, padreApellido_Materno
, padreNombre_Completo
, padreNombre_de_Usuario
, padreUsuario_Registrado
, padreEmail
, padreCelular
, padreFecha_de_Nacimiento
, padrePais_de_nacimiento
, padreEntidad_de_nacimiento
, padreSexo
, padreRegimen_Fiscal
, padreNombre_o_Razon_Social
, padreRFC
, padreCalle_Fiscal
, padreNumero_exterior_Fiscal
, padreNumero_interior_Fiscal
, padreColonia_Fiscal
, padreC_P__Fiscal
, padreCiudad_Fiscal
, padreEstado_Fiscal
, padrePais_Fiscal
, padreTelefono
, padreFax
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

        public int Update(Spartane.Core.Classes.Proveedores.Proveedores entity)
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

                var paramUpdNombre_del_Proveedor = _dataProvider.GetParameter();
                paramUpdNombre_del_Proveedor.ParameterName = "Nombre_del_Proveedor";
                paramUpdNombre_del_Proveedor.DbType = DbType.String;
                paramUpdNombre_del_Proveedor.Value = (object)entity.Nombre_del_Proveedor ?? DBNull.Value;
                var paramUpdTipo_de_Proveedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Proveedor.ParameterName = "Tipo_de_Proveedor";
                paramUpdTipo_de_Proveedor.DbType = DbType.Int32;
                paramUpdTipo_de_Proveedor.Value = (object)entity.Tipo_de_Proveedor ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

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
                var paramUpdFecha_de_Nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_Nacimiento.ParameterName = "Fecha_de_Nacimiento";
                paramUpdFecha_de_Nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_Nacimiento.Value = (object)entity.Fecha_de_Nacimiento ?? DBNull.Value;

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
                paramUpdNumero_exterior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_exterior_Fiscal.Value = (object)entity.Numero_exterior_Fiscal ?? DBNull.Value;

                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_interior_Fiscal.Value = (object)entity.Numero_interior_Fiscal ?? DBNull.Value;

                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)entity.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdC_P__Fiscal = _dataProvider.GetParameter();
                paramUpdC_P__Fiscal.ParameterName = "C_P__Fiscal";
                paramUpdC_P__Fiscal.DbType = DbType.Int32;
                paramUpdC_P__Fiscal.Value = (object)entity.C_P__Fiscal ?? DBNull.Value;

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


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdProveedores>("sp_UpdProveedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_del_Proveedor , paramUpdTipo_de_Proveedor , paramUpdEstatus , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_Nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdC_P__Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Proveedores.Proveedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Proveedores.Proveedores ProveedoresDB = GetByKey(entity.Folio, false);
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
                var paramUpdNombre_del_Proveedor = _dataProvider.GetParameter();
                paramUpdNombre_del_Proveedor.ParameterName = "Nombre_del_Proveedor";
                paramUpdNombre_del_Proveedor.DbType = DbType.String;
                paramUpdNombre_del_Proveedor.Value = (object)entity.Nombre_del_Proveedor ?? DBNull.Value;
		var paramUpdTipo_de_Proveedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Proveedor.ParameterName = "Tipo_de_Proveedor";
                paramUpdTipo_de_Proveedor.DbType = DbType.Int32;
                paramUpdTipo_de_Proveedor.Value = (object)entity.Tipo_de_Proveedor ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)ProveedoresDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)ProveedoresDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)ProveedoresDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)ProveedoresDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdNombre_de_Usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                paramUpdNombre_de_Usuario.DbType = DbType.String;
                paramUpdNombre_de_Usuario.Value = (object)ProveedoresDB.Nombre_de_Usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)ProveedoresDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)ProveedoresDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)ProveedoresDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_Nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_Nacimiento.ParameterName = "Fecha_de_Nacimiento";
                paramUpdFecha_de_Nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_Nacimiento.Value = (object)ProveedoresDB.Fecha_de_Nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)ProveedoresDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)ProveedoresDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)ProveedoresDB.Sexo ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)ProveedoresDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)ProveedoresDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)ProveedoresDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)ProveedoresDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_exterior_Fiscal.Value = (object)ProveedoresDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_interior_Fiscal.Value = (object)ProveedoresDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)ProveedoresDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdC_P__Fiscal = _dataProvider.GetParameter();
                paramUpdC_P__Fiscal.ParameterName = "C_P__Fiscal";
                paramUpdC_P__Fiscal.DbType = DbType.Int32;
                paramUpdC_P__Fiscal.Value = (object)ProveedoresDB.C_P__Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)ProveedoresDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)ProveedoresDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)ProveedoresDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)ProveedoresDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)ProveedoresDB.Fax ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdProveedores>("sp_UpdProveedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_del_Proveedor , paramUpdTipo_de_Proveedor , paramUpdEstatus , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_Nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdC_P__Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax ).FirstOrDefault();

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

		public int Update_Datos_de_Contacto(Spartane.Core.Classes.Proveedores.Proveedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Proveedores.Proveedores ProveedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)ProveedoresDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)ProveedoresDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)ProveedoresDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)ProveedoresDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre_del_Proveedor = _dataProvider.GetParameter();
                paramUpdNombre_del_Proveedor.ParameterName = "Nombre_del_Proveedor";
                paramUpdNombre_del_Proveedor.DbType = DbType.String;
                paramUpdNombre_del_Proveedor.Value = (object)ProveedoresDB.Nombre_del_Proveedor ?? DBNull.Value;
		var paramUpdTipo_de_Proveedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Proveedor.ParameterName = "Tipo_de_Proveedor";
                paramUpdTipo_de_Proveedor.DbType = DbType.Int32;
                paramUpdTipo_de_Proveedor.Value = (object)ProveedoresDB.Tipo_de_Proveedor ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)ProveedoresDB.Estatus ?? DBNull.Value;
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
                var paramUpdFecha_de_Nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_Nacimiento.ParameterName = "Fecha_de_Nacimiento";
                paramUpdFecha_de_Nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_Nacimiento.Value = (object)entity.Fecha_de_Nacimiento ?? DBNull.Value;
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
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)ProveedoresDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)ProveedoresDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)ProveedoresDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)ProveedoresDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_exterior_Fiscal.Value = (object)ProveedoresDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_interior_Fiscal.Value = (object)ProveedoresDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)ProveedoresDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdC_P__Fiscal = _dataProvider.GetParameter();
                paramUpdC_P__Fiscal.ParameterName = "C_P__Fiscal";
                paramUpdC_P__Fiscal.DbType = DbType.Int32;
                paramUpdC_P__Fiscal.Value = (object)ProveedoresDB.C_P__Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)ProveedoresDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)ProveedoresDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)ProveedoresDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)ProveedoresDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)ProveedoresDB.Fax ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdProveedores>("sp_UpdProveedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_del_Proveedor , paramUpdTipo_de_Proveedor , paramUpdEstatus , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_Nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdC_P__Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax ).FirstOrDefault();

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

		public int Update_Red_de_Proveedores(Spartane.Core.Classes.Proveedores.Proveedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Proveedores.Proveedores ProveedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)ProveedoresDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)ProveedoresDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)ProveedoresDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)ProveedoresDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre_del_Proveedor = _dataProvider.GetParameter();
                paramUpdNombre_del_Proveedor.ParameterName = "Nombre_del_Proveedor";
                paramUpdNombre_del_Proveedor.DbType = DbType.String;
                paramUpdNombre_del_Proveedor.Value = (object)ProveedoresDB.Nombre_del_Proveedor ?? DBNull.Value;
		var paramUpdTipo_de_Proveedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Proveedor.ParameterName = "Tipo_de_Proveedor";
                paramUpdTipo_de_Proveedor.DbType = DbType.Int32;
                paramUpdTipo_de_Proveedor.Value = (object)ProveedoresDB.Tipo_de_Proveedor ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)ProveedoresDB.Estatus ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)ProveedoresDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)ProveedoresDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)ProveedoresDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)ProveedoresDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdNombre_de_Usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                paramUpdNombre_de_Usuario.DbType = DbType.String;
                paramUpdNombre_de_Usuario.Value = (object)ProveedoresDB.Nombre_de_Usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)ProveedoresDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)ProveedoresDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)ProveedoresDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_Nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_Nacimiento.ParameterName = "Fecha_de_Nacimiento";
                paramUpdFecha_de_Nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_Nacimiento.Value = (object)ProveedoresDB.Fecha_de_Nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)ProveedoresDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)ProveedoresDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)ProveedoresDB.Sexo ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)ProveedoresDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)ProveedoresDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)ProveedoresDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)ProveedoresDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_exterior_Fiscal.Value = (object)ProveedoresDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_interior_Fiscal.Value = (object)ProveedoresDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)ProveedoresDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdC_P__Fiscal = _dataProvider.GetParameter();
                paramUpdC_P__Fiscal.ParameterName = "C_P__Fiscal";
                paramUpdC_P__Fiscal.DbType = DbType.Int32;
                paramUpdC_P__Fiscal.Value = (object)ProveedoresDB.C_P__Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)ProveedoresDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)ProveedoresDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)ProveedoresDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)ProveedoresDB.Telefono ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)ProveedoresDB.Fax ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdProveedores>("sp_UpdProveedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_del_Proveedor , paramUpdTipo_de_Proveedor , paramUpdEstatus , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_Nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdC_P__Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax ).FirstOrDefault();

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

		public int Update_Datos_Fiscales(Spartane.Core.Classes.Proveedores.Proveedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Proveedores.Proveedores ProveedoresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)ProveedoresDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)ProveedoresDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)ProveedoresDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)ProveedoresDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre_del_Proveedor = _dataProvider.GetParameter();
                paramUpdNombre_del_Proveedor.ParameterName = "Nombre_del_Proveedor";
                paramUpdNombre_del_Proveedor.DbType = DbType.String;
                paramUpdNombre_del_Proveedor.Value = (object)ProveedoresDB.Nombre_del_Proveedor ?? DBNull.Value;
		var paramUpdTipo_de_Proveedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Proveedor.ParameterName = "Tipo_de_Proveedor";
                paramUpdTipo_de_Proveedor.DbType = DbType.Int32;
                paramUpdTipo_de_Proveedor.Value = (object)ProveedoresDB.Tipo_de_Proveedor ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)ProveedoresDB.Estatus ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)ProveedoresDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)ProveedoresDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)ProveedoresDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)ProveedoresDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdNombre_de_Usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_Usuario.ParameterName = "Nombre_de_Usuario";
                paramUpdNombre_de_Usuario.DbType = DbType.String;
                paramUpdNombre_de_Usuario.Value = (object)ProveedoresDB.Nombre_de_Usuario ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)ProveedoresDB.Usuario_Registrado ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)ProveedoresDB.Email ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)ProveedoresDB.Celular ?? DBNull.Value;
                var paramUpdFecha_de_Nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_Nacimiento.ParameterName = "Fecha_de_Nacimiento";
                paramUpdFecha_de_Nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_Nacimiento.Value = (object)ProveedoresDB.Fecha_de_Nacimiento ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)ProveedoresDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdEntidad_de_nacimiento = _dataProvider.GetParameter();
                paramUpdEntidad_de_nacimiento.ParameterName = "Entidad_de_nacimiento";
                paramUpdEntidad_de_nacimiento.DbType = DbType.Int32;
                paramUpdEntidad_de_nacimiento.Value = (object)ProveedoresDB.Entidad_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)ProveedoresDB.Sexo ?? DBNull.Value;
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
                paramUpdNumero_exterior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_exterior_Fiscal.Value = (object)entity.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.Int32;
                paramUpdNumero_interior_Fiscal.Value = (object)entity.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)entity.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdC_P__Fiscal = _dataProvider.GetParameter();
                paramUpdC_P__Fiscal.ParameterName = "C_P__Fiscal";
                paramUpdC_P__Fiscal.DbType = DbType.Int32;
                paramUpdC_P__Fiscal.Value = (object)entity.C_P__Fiscal ?? DBNull.Value;
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


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdProveedores>("sp_UpdProveedores" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_del_Proveedor , paramUpdTipo_de_Proveedor , paramUpdEstatus , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdNombre_de_Usuario , paramUpdUsuario_Registrado , paramUpdEmail , paramUpdCelular , paramUpdFecha_de_Nacimiento , paramUpdPais_de_nacimiento , paramUpdEntidad_de_nacimiento , paramUpdSexo , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdC_P__Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono , paramUpdFax ).FirstOrDefault();

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


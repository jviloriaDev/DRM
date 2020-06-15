using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Empresas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Empresas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EmpresasService : IEmpresasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Empresas.Empresas> _EmpresasRepository;
        #endregion

        #region Ctor
        public EmpresasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Empresas.Empresas> EmpresasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EmpresasRepository = EmpresasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._EmpresasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Empresas.Empresas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Empresas.Empresas>("sp_SelAllEmpresas");
        }

        public IList<Core.Classes.Empresas.Empresas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEmpresas_Complete>("sp_SelAllComplete_Empresas");
            return data.Select(m => new Core.Classes.Empresas.Empresas
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombre_de_la_Empresa = m.Nombre_de_la_Empresa
                ,Tipo_de_Empresa_Tipos_de_Empresa = new Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa() { Clave = m.Tipo_de_Empresa.GetValueOrDefault(), Descripcion = m.Tipo_de_Empresa_Descripcion }
                ,Email = m.Email
                ,Telefono = m.Telefono
                ,Calle = m.Calle
                ,Numero_exterior = m.Numero_exterior
                ,Numero_interior = m.Numero_interior
                ,Colonia = m.Colonia
                ,CP = m.CP
                ,Ciudad = m.Ciudad
                ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Estado.GetValueOrDefault(), Nombre_del_Estado = m.Estado_Nombre_del_Estado }
                ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais.GetValueOrDefault(), Nombre_del_Pais = m.Pais_Nombre_del_Pais }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
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
                ,Telefono_Fiscal = m.Telefono_Fiscal
                ,Fax = m.Fax
                ,Nombres_del_Representante_Legal = m.Nombres_del_Representante_Legal
                ,Apellido_Paterno_del_Representante_Legal = m.Apellido_Paterno_del_Representante_Legal
                ,Apellido_Materno_del_Representante_Legal = m.Apellido_Materno_del_Representante_Legal
                ,Nombre_Completo_del_Representante_Legal = m.Nombre_Completo_del_Representante_Legal
                ,Cedula_Fiscal = m.Cedula_Fiscal


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Empresas>("sp_ListSelCount_Empresas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Empresas.Empresas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEmpresas>("sp_ListSelAll_Empresas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Empresas.Empresas
                {
                    Folio = m.Empresas_Folio,
                    Fecha_de_Registro = m.Empresas_Fecha_de_Registro,
                    Hora_de_Registro = m.Empresas_Hora_de_Registro,
                    Usuario_que_Registra = m.Empresas_Usuario_que_Registra,
                    Nombre_de_la_Empresa = m.Empresas_Nombre_de_la_Empresa,
                    Tipo_de_Empresa = m.Empresas_Tipo_de_Empresa,
                    Email = m.Empresas_Email,
                    Telefono = m.Empresas_Telefono,
                    Calle = m.Empresas_Calle,
                    Numero_exterior = m.Empresas_Numero_exterior,
                    Numero_interior = m.Empresas_Numero_interior,
                    Colonia = m.Empresas_Colonia,
                    CP = m.Empresas_CP,
                    Ciudad = m.Empresas_Ciudad,
                    Estado = m.Empresas_Estado,
                    Pais = m.Empresas_Pais,
                    Estatus = m.Empresas_Estatus,
                    Regimen_Fiscal = m.Empresas_Regimen_Fiscal,
                    Nombre_o_Razon_Social = m.Empresas_Nombre_o_Razon_Social,
                    RFC = m.Empresas_RFC,
                    Calle_Fiscal = m.Empresas_Calle_Fiscal,
                    Numero_exterior_Fiscal = m.Empresas_Numero_exterior_Fiscal,
                    Numero_interior_Fiscal = m.Empresas_Numero_interior_Fiscal,
                    Colonia_Fiscal = m.Empresas_Colonia_Fiscal,
                    CP_Fiscal = m.Empresas_CP_Fiscal,
                    Ciudad_Fiscal = m.Empresas_Ciudad_Fiscal,
                    Estado_Fiscal = m.Empresas_Estado_Fiscal,
                    Pais_Fiscal = m.Empresas_Pais_Fiscal,
                    Telefono_Fiscal = m.Empresas_Telefono_Fiscal,
                    Fax = m.Empresas_Fax,
                    Nombres_del_Representante_Legal = m.Empresas_Nombres_del_Representante_Legal,
                    Apellido_Paterno_del_Representante_Legal = m.Empresas_Apellido_Paterno_del_Representante_Legal,
                    Apellido_Materno_del_Representante_Legal = m.Empresas_Apellido_Materno_del_Representante_Legal,
                    Nombre_Completo_del_Representante_Legal = m.Empresas_Nombre_Completo_del_Representante_Legal,
                    Cedula_Fiscal = m.Empresas_Cedula_Fiscal,

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

        public IList<Spartane.Core.Classes.Empresas.Empresas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EmpresasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Empresas.Empresas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EmpresasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Empresas.EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEmpresas>("sp_ListSelAll_Empresas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            EmpresasPagingModel result = null;

            if (data != null)
            {
                result = new EmpresasPagingModel
                {
                    Empresass =
                        data.Select(m => new Spartane.Core.Classes.Empresas.Empresas
                {
                    Folio = m.Empresas_Folio
                    ,Fecha_de_Registro = m.Empresas_Fecha_de_Registro
                    ,Hora_de_Registro = m.Empresas_Hora_de_Registro
                    ,Usuario_que_Registra = m.Empresas_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Empresas_Usuario_que_Registra.GetValueOrDefault(), Name = m.Empresas_Usuario_que_Registra_Name }
                    ,Nombre_de_la_Empresa = m.Empresas_Nombre_de_la_Empresa
                    ,Tipo_de_Empresa = m.Empresas_Tipo_de_Empresa
                    ,Tipo_de_Empresa_Tipos_de_Empresa = new Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa() { Clave = m.Empresas_Tipo_de_Empresa.GetValueOrDefault(), Descripcion = m.Empresas_Tipo_de_Empresa_Descripcion }
                    ,Email = m.Empresas_Email
                    ,Telefono = m.Empresas_Telefono
                    ,Calle = m.Empresas_Calle
                    ,Numero_exterior = m.Empresas_Numero_exterior
                    ,Numero_interior = m.Empresas_Numero_interior
                    ,Colonia = m.Empresas_Colonia
                    ,CP = m.Empresas_CP
                    ,Ciudad = m.Empresas_Ciudad
                    ,Estado = m.Empresas_Estado
                    ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Empresas_Estado.GetValueOrDefault(), Nombre_del_Estado = m.Empresas_Estado_Nombre_del_Estado }
                    ,Pais = m.Empresas_Pais
                    ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Empresas_Pais.GetValueOrDefault(), Nombre_del_Pais = m.Empresas_Pais_Nombre_del_Pais }
                    ,Estatus = m.Empresas_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Empresas_Estatus.GetValueOrDefault(), Descripcion = m.Empresas_Estatus_Descripcion }
                    ,Regimen_Fiscal = m.Empresas_Regimen_Fiscal
                    ,Regimen_Fiscal_Regimenes_Fiscales = new Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales() { Clave = m.Empresas_Regimen_Fiscal.GetValueOrDefault(), Descripcion = m.Empresas_Regimen_Fiscal_Descripcion }
                    ,Nombre_o_Razon_Social = m.Empresas_Nombre_o_Razon_Social
                    ,RFC = m.Empresas_RFC
                    ,Calle_Fiscal = m.Empresas_Calle_Fiscal
                    ,Numero_exterior_Fiscal = m.Empresas_Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = m.Empresas_Numero_interior_Fiscal
                    ,Colonia_Fiscal = m.Empresas_Colonia_Fiscal
                    ,CP_Fiscal = m.Empresas_CP_Fiscal
                    ,Ciudad_Fiscal = m.Empresas_Ciudad_Fiscal
                    ,Estado_Fiscal = m.Empresas_Estado_Fiscal
                    ,Estado_Fiscal_Estado = new Core.Classes.Estado.Estado() { Clave = m.Empresas_Estado_Fiscal.GetValueOrDefault(), Nombre_del_Estado = m.Empresas_Estado_Fiscal_Nombre_del_Estado }
                    ,Pais_Fiscal = m.Empresas_Pais_Fiscal
                    ,Pais_Fiscal_Pais = new Core.Classes.Pais.Pais() { Clave = m.Empresas_Pais_Fiscal.GetValueOrDefault(), Nombre_del_Pais = m.Empresas_Pais_Fiscal_Nombre_del_Pais }
                    ,Telefono_Fiscal = m.Empresas_Telefono_Fiscal
                    ,Fax = m.Empresas_Fax
                    ,Nombres_del_Representante_Legal = m.Empresas_Nombres_del_Representante_Legal
                    ,Apellido_Paterno_del_Representante_Legal = m.Empresas_Apellido_Paterno_del_Representante_Legal
                    ,Apellido_Materno_del_Representante_Legal = m.Empresas_Apellido_Materno_del_Representante_Legal
                    ,Nombre_Completo_del_Representante_Legal = m.Empresas_Nombre_Completo_del_Representante_Legal
                    ,Cedula_Fiscal = m.Empresas_Cedula_Fiscal

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Empresas.Empresas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EmpresasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Empresas.Empresas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Empresas.Empresas>("sp_GetEmpresas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEmpresas>("sp_DelEmpresas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Empresas.Empresas entity)
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

                var padreNombre_de_la_Empresa = _dataProvider.GetParameter();
                padreNombre_de_la_Empresa.ParameterName = "Nombre_de_la_Empresa";
                padreNombre_de_la_Empresa.DbType = DbType.String;
                padreNombre_de_la_Empresa.Value = (object)entity.Nombre_de_la_Empresa ?? DBNull.Value;
                var padreTipo_de_Empresa = _dataProvider.GetParameter();
                padreTipo_de_Empresa.ParameterName = "Tipo_de_Empresa";
                padreTipo_de_Empresa.DbType = DbType.Int32;
                padreTipo_de_Empresa.Value = (object)entity.Tipo_de_Empresa ?? DBNull.Value;

                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
                var padreTelefono = _dataProvider.GetParameter();
                padreTelefono.ParameterName = "Telefono";
                padreTelefono.DbType = DbType.String;
                padreTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
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

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

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

                var padreTelefono_Fiscal = _dataProvider.GetParameter();
                padreTelefono_Fiscal.ParameterName = "Telefono_Fiscal";
                padreTelefono_Fiscal.DbType = DbType.String;
                padreTelefono_Fiscal.Value = (object)entity.Telefono_Fiscal ?? DBNull.Value;
                var padreFax = _dataProvider.GetParameter();
                padreFax.ParameterName = "Fax";
                padreFax.DbType = DbType.String;
                padreFax.Value = (object)entity.Fax ?? DBNull.Value;
                var padreNombres_del_Representante_Legal = _dataProvider.GetParameter();
                padreNombres_del_Representante_Legal.ParameterName = "Nombres_del_Representante_Legal";
                padreNombres_del_Representante_Legal.DbType = DbType.String;
                padreNombres_del_Representante_Legal.Value = (object)entity.Nombres_del_Representante_Legal ?? DBNull.Value;
                var padreApellido_Paterno_del_Representante_Legal = _dataProvider.GetParameter();
                padreApellido_Paterno_del_Representante_Legal.ParameterName = "Apellido_Paterno_del_Representante_Legal";
                padreApellido_Paterno_del_Representante_Legal.DbType = DbType.String;
                padreApellido_Paterno_del_Representante_Legal.Value = (object)entity.Apellido_Paterno_del_Representante_Legal ?? DBNull.Value;
                var padreApellido_Materno_del_Representante_Legal = _dataProvider.GetParameter();
                padreApellido_Materno_del_Representante_Legal.ParameterName = "Apellido_Materno_del_Representante_Legal";
                padreApellido_Materno_del_Representante_Legal.DbType = DbType.String;
                padreApellido_Materno_del_Representante_Legal.Value = (object)entity.Apellido_Materno_del_Representante_Legal ?? DBNull.Value;
                var padreNombre_Completo_del_Representante_Legal = _dataProvider.GetParameter();
                padreNombre_Completo_del_Representante_Legal.ParameterName = "Nombre_Completo_del_Representante_Legal";
                padreNombre_Completo_del_Representante_Legal.DbType = DbType.String;
                padreNombre_Completo_del_Representante_Legal.Value = (object)entity.Nombre_Completo_del_Representante_Legal ?? DBNull.Value;
                var padreCedula_Fiscal = _dataProvider.GetParameter();
                padreCedula_Fiscal.ParameterName = "Cedula_Fiscal";
                padreCedula_Fiscal.DbType = DbType.Int32;
                padreCedula_Fiscal.Value = (object)entity.Cedula_Fiscal ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEmpresas>("sp_InsEmpresas" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombre_de_la_Empresa
, padreTipo_de_Empresa
, padreEmail
, padreTelefono
, padreCalle
, padreNumero_exterior
, padreNumero_interior
, padreColonia
, padreCP
, padreCiudad
, padreEstado
, padrePais
, padreEstatus
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
, padreTelefono_Fiscal
, padreFax
, padreNombres_del_Representante_Legal
, padreApellido_Paterno_del_Representante_Legal
, padreApellido_Materno_del_Representante_Legal
, padreNombre_Completo_del_Representante_Legal
, padreCedula_Fiscal
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

        public int Update(Spartane.Core.Classes.Empresas.Empresas entity)
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

                var paramUpdNombre_de_la_Empresa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Empresa.ParameterName = "Nombre_de_la_Empresa";
                paramUpdNombre_de_la_Empresa.DbType = DbType.String;
                paramUpdNombre_de_la_Empresa.Value = (object)entity.Nombre_de_la_Empresa ?? DBNull.Value;
                var paramUpdTipo_de_Empresa = _dataProvider.GetParameter();
                paramUpdTipo_de_Empresa.ParameterName = "Tipo_de_Empresa";
                paramUpdTipo_de_Empresa.DbType = DbType.Int32;
                paramUpdTipo_de_Empresa.Value = (object)entity.Tipo_de_Empresa ?? DBNull.Value;

                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
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

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

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

                var paramUpdTelefono_Fiscal = _dataProvider.GetParameter();
                paramUpdTelefono_Fiscal.ParameterName = "Telefono_Fiscal";
                paramUpdTelefono_Fiscal.DbType = DbType.String;
                paramUpdTelefono_Fiscal.Value = (object)entity.Telefono_Fiscal ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)entity.Fax ?? DBNull.Value;
                var paramUpdNombres_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombres_del_Representante_Legal.ParameterName = "Nombres_del_Representante_Legal";
                paramUpdNombres_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombres_del_Representante_Legal.Value = (object)entity.Nombres_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Paterno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Paterno_del_Representante_Legal.ParameterName = "Apellido_Paterno_del_Representante_Legal";
                paramUpdApellido_Paterno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Paterno_del_Representante_Legal.Value = (object)entity.Apellido_Paterno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Materno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Materno_del_Representante_Legal.ParameterName = "Apellido_Materno_del_Representante_Legal";
                paramUpdApellido_Materno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Materno_del_Representante_Legal.Value = (object)entity.Apellido_Materno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdNombre_Completo_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombre_Completo_del_Representante_Legal.ParameterName = "Nombre_Completo_del_Representante_Legal";
                paramUpdNombre_Completo_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombre_Completo_del_Representante_Legal.Value = (object)entity.Nombre_Completo_del_Representante_Legal ?? DBNull.Value;
                var paramUpdCedula_Fiscal = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal.ParameterName = "Cedula_Fiscal";
                paramUpdCedula_Fiscal.DbType = DbType.Int32;
                paramUpdCedula_Fiscal.Value = (object)entity.Cedula_Fiscal ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEmpresas>("sp_UpdEmpresas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_la_Empresa , paramUpdTipo_de_Empresa , paramUpdEmail , paramUpdTelefono , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdEstatus , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono_Fiscal , paramUpdFax , paramUpdNombres_del_Representante_Legal , paramUpdApellido_Paterno_del_Representante_Legal , paramUpdApellido_Materno_del_Representante_Legal , paramUpdNombre_Completo_del_Representante_Legal , paramUpdCedula_Fiscal ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Empresas.Empresas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Empresas.Empresas EmpresasDB = GetByKey(entity.Folio, false);
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
                var paramUpdNombre_de_la_Empresa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Empresa.ParameterName = "Nombre_de_la_Empresa";
                paramUpdNombre_de_la_Empresa.DbType = DbType.String;
                paramUpdNombre_de_la_Empresa.Value = (object)entity.Nombre_de_la_Empresa ?? DBNull.Value;
		var paramUpdTipo_de_Empresa = _dataProvider.GetParameter();
                paramUpdTipo_de_Empresa.ParameterName = "Tipo_de_Empresa";
                paramUpdTipo_de_Empresa.DbType = DbType.Int32;
                paramUpdTipo_de_Empresa.Value = (object)entity.Tipo_de_Empresa ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
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
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)EmpresasDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)EmpresasDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)EmpresasDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)EmpresasDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)EmpresasDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)EmpresasDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)EmpresasDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)EmpresasDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)EmpresasDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)EmpresasDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)EmpresasDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono_Fiscal = _dataProvider.GetParameter();
                paramUpdTelefono_Fiscal.ParameterName = "Telefono_Fiscal";
                paramUpdTelefono_Fiscal.DbType = DbType.String;
                paramUpdTelefono_Fiscal.Value = (object)EmpresasDB.Telefono_Fiscal ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)EmpresasDB.Fax ?? DBNull.Value;
                var paramUpdNombres_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombres_del_Representante_Legal.ParameterName = "Nombres_del_Representante_Legal";
                paramUpdNombres_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombres_del_Representante_Legal.Value = (object)EmpresasDB.Nombres_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Paterno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Paterno_del_Representante_Legal.ParameterName = "Apellido_Paterno_del_Representante_Legal";
                paramUpdApellido_Paterno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Paterno_del_Representante_Legal.Value = (object)EmpresasDB.Apellido_Paterno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Materno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Materno_del_Representante_Legal.ParameterName = "Apellido_Materno_del_Representante_Legal";
                paramUpdApellido_Materno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Materno_del_Representante_Legal.Value = (object)EmpresasDB.Apellido_Materno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdNombre_Completo_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombre_Completo_del_Representante_Legal.ParameterName = "Nombre_Completo_del_Representante_Legal";
                paramUpdNombre_Completo_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombre_Completo_del_Representante_Legal.Value = (object)EmpresasDB.Nombre_Completo_del_Representante_Legal ?? DBNull.Value;
                var paramUpdCedula_Fiscal = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal.ParameterName = "Cedula_Fiscal";
                paramUpdCedula_Fiscal.DbType = DbType.Int32;
                paramUpdCedula_Fiscal.Value = (object)EmpresasDB.Cedula_Fiscal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEmpresas>("sp_UpdEmpresas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_la_Empresa , paramUpdTipo_de_Empresa , paramUpdEmail , paramUpdTelefono , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdEstatus , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono_Fiscal , paramUpdFax , paramUpdNombres_del_Representante_Legal , paramUpdApellido_Paterno_del_Representante_Legal , paramUpdApellido_Materno_del_Representante_Legal , paramUpdNombre_Completo_del_Representante_Legal , paramUpdCedula_Fiscal ).FirstOrDefault();

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

		public int Update_Datos_de_Contacto(Spartane.Core.Classes.Empresas.Empresas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Empresas.Empresas EmpresasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)EmpresasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)EmpresasDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)EmpresasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)EmpresasDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre_de_la_Empresa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Empresa.ParameterName = "Nombre_de_la_Empresa";
                paramUpdNombre_de_la_Empresa.DbType = DbType.String;
                paramUpdNombre_de_la_Empresa.Value = (object)EmpresasDB.Nombre_de_la_Empresa ?? DBNull.Value;
		var paramUpdTipo_de_Empresa = _dataProvider.GetParameter();
                paramUpdTipo_de_Empresa.ParameterName = "Tipo_de_Empresa";
                paramUpdTipo_de_Empresa.DbType = DbType.Int32;
                paramUpdTipo_de_Empresa.Value = (object)EmpresasDB.Tipo_de_Empresa ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)EmpresasDB.Email ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)EmpresasDB.Telefono ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)EmpresasDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)EmpresasDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)EmpresasDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)EmpresasDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)EmpresasDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)EmpresasDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)EmpresasDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)EmpresasDB.Pais ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)EmpresasDB.Estatus ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)EmpresasDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)EmpresasDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)EmpresasDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)EmpresasDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)EmpresasDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)EmpresasDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)EmpresasDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)EmpresasDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)EmpresasDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)EmpresasDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)EmpresasDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono_Fiscal = _dataProvider.GetParameter();
                paramUpdTelefono_Fiscal.ParameterName = "Telefono_Fiscal";
                paramUpdTelefono_Fiscal.DbType = DbType.String;
                paramUpdTelefono_Fiscal.Value = (object)EmpresasDB.Telefono_Fiscal ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)EmpresasDB.Fax ?? DBNull.Value;
                var paramUpdNombres_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombres_del_Representante_Legal.ParameterName = "Nombres_del_Representante_Legal";
                paramUpdNombres_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombres_del_Representante_Legal.Value = (object)EmpresasDB.Nombres_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Paterno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Paterno_del_Representante_Legal.ParameterName = "Apellido_Paterno_del_Representante_Legal";
                paramUpdApellido_Paterno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Paterno_del_Representante_Legal.Value = (object)EmpresasDB.Apellido_Paterno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Materno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Materno_del_Representante_Legal.ParameterName = "Apellido_Materno_del_Representante_Legal";
                paramUpdApellido_Materno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Materno_del_Representante_Legal.Value = (object)EmpresasDB.Apellido_Materno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdNombre_Completo_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombre_Completo_del_Representante_Legal.ParameterName = "Nombre_Completo_del_Representante_Legal";
                paramUpdNombre_Completo_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombre_Completo_del_Representante_Legal.Value = (object)EmpresasDB.Nombre_Completo_del_Representante_Legal ?? DBNull.Value;
                var paramUpdCedula_Fiscal = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal.ParameterName = "Cedula_Fiscal";
                paramUpdCedula_Fiscal.DbType = DbType.Int32;
                paramUpdCedula_Fiscal.Value = (object)EmpresasDB.Cedula_Fiscal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEmpresas>("sp_UpdEmpresas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_la_Empresa , paramUpdTipo_de_Empresa , paramUpdEmail , paramUpdTelefono , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdEstatus , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono_Fiscal , paramUpdFax , paramUpdNombres_del_Representante_Legal , paramUpdApellido_Paterno_del_Representante_Legal , paramUpdApellido_Materno_del_Representante_Legal , paramUpdNombre_Completo_del_Representante_Legal , paramUpdCedula_Fiscal ).FirstOrDefault();

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

		public int Update_Datos_Fiscales(Spartane.Core.Classes.Empresas.Empresas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Empresas.Empresas EmpresasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)EmpresasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)EmpresasDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)EmpresasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)EmpresasDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre_de_la_Empresa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Empresa.ParameterName = "Nombre_de_la_Empresa";
                paramUpdNombre_de_la_Empresa.DbType = DbType.String;
                paramUpdNombre_de_la_Empresa.Value = (object)EmpresasDB.Nombre_de_la_Empresa ?? DBNull.Value;
		var paramUpdTipo_de_Empresa = _dataProvider.GetParameter();
                paramUpdTipo_de_Empresa.ParameterName = "Tipo_de_Empresa";
                paramUpdTipo_de_Empresa.DbType = DbType.Int32;
                paramUpdTipo_de_Empresa.Value = (object)EmpresasDB.Tipo_de_Empresa ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)EmpresasDB.Email ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)EmpresasDB.Telefono ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)EmpresasDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)EmpresasDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)EmpresasDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)EmpresasDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)EmpresasDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)EmpresasDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)EmpresasDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)EmpresasDB.Pais ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)EmpresasDB.Estatus ?? DBNull.Value;
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
                var paramUpdTelefono_Fiscal = _dataProvider.GetParameter();
                paramUpdTelefono_Fiscal.ParameterName = "Telefono_Fiscal";
                paramUpdTelefono_Fiscal.DbType = DbType.String;
                paramUpdTelefono_Fiscal.Value = (object)entity.Telefono_Fiscal ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)entity.Fax ?? DBNull.Value;
                var paramUpdNombres_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombres_del_Representante_Legal.ParameterName = "Nombres_del_Representante_Legal";
                paramUpdNombres_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombres_del_Representante_Legal.Value = (object)entity.Nombres_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Paterno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Paterno_del_Representante_Legal.ParameterName = "Apellido_Paterno_del_Representante_Legal";
                paramUpdApellido_Paterno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Paterno_del_Representante_Legal.Value = (object)entity.Apellido_Paterno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Materno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Materno_del_Representante_Legal.ParameterName = "Apellido_Materno_del_Representante_Legal";
                paramUpdApellido_Materno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Materno_del_Representante_Legal.Value = (object)entity.Apellido_Materno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdNombre_Completo_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombre_Completo_del_Representante_Legal.ParameterName = "Nombre_Completo_del_Representante_Legal";
                paramUpdNombre_Completo_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombre_Completo_del_Representante_Legal.Value = (object)entity.Nombre_Completo_del_Representante_Legal ?? DBNull.Value;
                var paramUpdCedula_Fiscal = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal.ParameterName = "Cedula_Fiscal";
                paramUpdCedula_Fiscal.DbType = DbType.Int32;
                paramUpdCedula_Fiscal.Value = (object)EmpresasDB.Cedula_Fiscal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEmpresas>("sp_UpdEmpresas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_la_Empresa , paramUpdTipo_de_Empresa , paramUpdEmail , paramUpdTelefono , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdEstatus , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono_Fiscal , paramUpdFax , paramUpdNombres_del_Representante_Legal , paramUpdApellido_Paterno_del_Representante_Legal , paramUpdApellido_Materno_del_Representante_Legal , paramUpdNombre_Completo_del_Representante_Legal , paramUpdCedula_Fiscal ).FirstOrDefault();

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

		public int Update_Suscripcion(Spartane.Core.Classes.Empresas.Empresas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Empresas.Empresas EmpresasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)EmpresasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)EmpresasDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)EmpresasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)EmpresasDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre_de_la_Empresa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Empresa.ParameterName = "Nombre_de_la_Empresa";
                paramUpdNombre_de_la_Empresa.DbType = DbType.String;
                paramUpdNombre_de_la_Empresa.Value = (object)EmpresasDB.Nombre_de_la_Empresa ?? DBNull.Value;
		var paramUpdTipo_de_Empresa = _dataProvider.GetParameter();
                paramUpdTipo_de_Empresa.ParameterName = "Tipo_de_Empresa";
                paramUpdTipo_de_Empresa.DbType = DbType.Int32;
                paramUpdTipo_de_Empresa.Value = (object)EmpresasDB.Tipo_de_Empresa ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)EmpresasDB.Email ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)EmpresasDB.Telefono ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)EmpresasDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)EmpresasDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)EmpresasDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)EmpresasDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)EmpresasDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)EmpresasDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)EmpresasDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)EmpresasDB.Pais ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)EmpresasDB.Estatus ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)EmpresasDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)EmpresasDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)EmpresasDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)EmpresasDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)EmpresasDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)EmpresasDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)EmpresasDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)EmpresasDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)EmpresasDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)EmpresasDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)EmpresasDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono_Fiscal = _dataProvider.GetParameter();
                paramUpdTelefono_Fiscal.ParameterName = "Telefono_Fiscal";
                paramUpdTelefono_Fiscal.DbType = DbType.String;
                paramUpdTelefono_Fiscal.Value = (object)EmpresasDB.Telefono_Fiscal ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)EmpresasDB.Fax ?? DBNull.Value;
                var paramUpdNombres_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombres_del_Representante_Legal.ParameterName = "Nombres_del_Representante_Legal";
                paramUpdNombres_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombres_del_Representante_Legal.Value = (object)EmpresasDB.Nombres_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Paterno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Paterno_del_Representante_Legal.ParameterName = "Apellido_Paterno_del_Representante_Legal";
                paramUpdApellido_Paterno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Paterno_del_Representante_Legal.Value = (object)EmpresasDB.Apellido_Paterno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Materno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Materno_del_Representante_Legal.ParameterName = "Apellido_Materno_del_Representante_Legal";
                paramUpdApellido_Materno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Materno_del_Representante_Legal.Value = (object)EmpresasDB.Apellido_Materno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdNombre_Completo_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombre_Completo_del_Representante_Legal.ParameterName = "Nombre_Completo_del_Representante_Legal";
                paramUpdNombre_Completo_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombre_Completo_del_Representante_Legal.Value = (object)EmpresasDB.Nombre_Completo_del_Representante_Legal ?? DBNull.Value;
                var paramUpdCedula_Fiscal = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal.ParameterName = "Cedula_Fiscal";
                paramUpdCedula_Fiscal.DbType = DbType.Int32;
                paramUpdCedula_Fiscal.Value = (object)EmpresasDB.Cedula_Fiscal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEmpresas>("sp_UpdEmpresas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_la_Empresa , paramUpdTipo_de_Empresa , paramUpdEmail , paramUpdTelefono , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdEstatus , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono_Fiscal , paramUpdFax , paramUpdNombres_del_Representante_Legal , paramUpdApellido_Paterno_del_Representante_Legal , paramUpdApellido_Materno_del_Representante_Legal , paramUpdNombre_Completo_del_Representante_Legal , paramUpdCedula_Fiscal ).FirstOrDefault();

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

		public int Update_Documentacion(Spartane.Core.Classes.Empresas.Empresas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Empresas.Empresas EmpresasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)EmpresasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)EmpresasDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)EmpresasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)EmpresasDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre_de_la_Empresa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Empresa.ParameterName = "Nombre_de_la_Empresa";
                paramUpdNombre_de_la_Empresa.DbType = DbType.String;
                paramUpdNombre_de_la_Empresa.Value = (object)EmpresasDB.Nombre_de_la_Empresa ?? DBNull.Value;
		var paramUpdTipo_de_Empresa = _dataProvider.GetParameter();
                paramUpdTipo_de_Empresa.ParameterName = "Tipo_de_Empresa";
                paramUpdTipo_de_Empresa.DbType = DbType.Int32;
                paramUpdTipo_de_Empresa.Value = (object)EmpresasDB.Tipo_de_Empresa ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)EmpresasDB.Email ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)EmpresasDB.Telefono ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)EmpresasDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)EmpresasDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)EmpresasDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)EmpresasDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)EmpresasDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)EmpresasDB.Ciudad ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)EmpresasDB.Estado ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)EmpresasDB.Pais ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)EmpresasDB.Estatus ?? DBNull.Value;
		var paramUpdRegimen_Fiscal = _dataProvider.GetParameter();
                paramUpdRegimen_Fiscal.ParameterName = "Regimen_Fiscal";
                paramUpdRegimen_Fiscal.DbType = DbType.Int32;
                paramUpdRegimen_Fiscal.Value = (object)EmpresasDB.Regimen_Fiscal ?? DBNull.Value;
                var paramUpdNombre_o_Razon_Social = _dataProvider.GetParameter();
                paramUpdNombre_o_Razon_Social.ParameterName = "Nombre_o_Razon_Social";
                paramUpdNombre_o_Razon_Social.DbType = DbType.String;
                paramUpdNombre_o_Razon_Social.Value = (object)EmpresasDB.Nombre_o_Razon_Social ?? DBNull.Value;
                var paramUpdRFC = _dataProvider.GetParameter();
                paramUpdRFC.ParameterName = "RFC";
                paramUpdRFC.DbType = DbType.String;
                paramUpdRFC.Value = (object)EmpresasDB.RFC ?? DBNull.Value;
                var paramUpdCalle_Fiscal = _dataProvider.GetParameter();
                paramUpdCalle_Fiscal.ParameterName = "Calle_Fiscal";
                paramUpdCalle_Fiscal.DbType = DbType.String;
                paramUpdCalle_Fiscal.Value = (object)EmpresasDB.Calle_Fiscal ?? DBNull.Value;
                var paramUpdNumero_exterior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_exterior_Fiscal.ParameterName = "Numero_exterior_Fiscal";
                paramUpdNumero_exterior_Fiscal.DbType = DbType.String;
                paramUpdNumero_exterior_Fiscal.Value = (object)EmpresasDB.Numero_exterior_Fiscal ?? DBNull.Value;
                var paramUpdNumero_interior_Fiscal = _dataProvider.GetParameter();
                paramUpdNumero_interior_Fiscal.ParameterName = "Numero_interior_Fiscal";
                paramUpdNumero_interior_Fiscal.DbType = DbType.String;
                paramUpdNumero_interior_Fiscal.Value = (object)EmpresasDB.Numero_interior_Fiscal ?? DBNull.Value;
                var paramUpdColonia_Fiscal = _dataProvider.GetParameter();
                paramUpdColonia_Fiscal.ParameterName = "Colonia_Fiscal";
                paramUpdColonia_Fiscal.DbType = DbType.String;
                paramUpdColonia_Fiscal.Value = (object)EmpresasDB.Colonia_Fiscal ?? DBNull.Value;
                var paramUpdCP_Fiscal = _dataProvider.GetParameter();
                paramUpdCP_Fiscal.ParameterName = "CP_Fiscal";
                paramUpdCP_Fiscal.DbType = DbType.Int32;
                paramUpdCP_Fiscal.Value = (object)EmpresasDB.CP_Fiscal ?? DBNull.Value;
                var paramUpdCiudad_Fiscal = _dataProvider.GetParameter();
                paramUpdCiudad_Fiscal.ParameterName = "Ciudad_Fiscal";
                paramUpdCiudad_Fiscal.DbType = DbType.String;
                paramUpdCiudad_Fiscal.Value = (object)EmpresasDB.Ciudad_Fiscal ?? DBNull.Value;
		var paramUpdEstado_Fiscal = _dataProvider.GetParameter();
                paramUpdEstado_Fiscal.ParameterName = "Estado_Fiscal";
                paramUpdEstado_Fiscal.DbType = DbType.Int32;
                paramUpdEstado_Fiscal.Value = (object)EmpresasDB.Estado_Fiscal ?? DBNull.Value;
		var paramUpdPais_Fiscal = _dataProvider.GetParameter();
                paramUpdPais_Fiscal.ParameterName = "Pais_Fiscal";
                paramUpdPais_Fiscal.DbType = DbType.Int32;
                paramUpdPais_Fiscal.Value = (object)EmpresasDB.Pais_Fiscal ?? DBNull.Value;
                var paramUpdTelefono_Fiscal = _dataProvider.GetParameter();
                paramUpdTelefono_Fiscal.ParameterName = "Telefono_Fiscal";
                paramUpdTelefono_Fiscal.DbType = DbType.String;
                paramUpdTelefono_Fiscal.Value = (object)EmpresasDB.Telefono_Fiscal ?? DBNull.Value;
                var paramUpdFax = _dataProvider.GetParameter();
                paramUpdFax.ParameterName = "Fax";
                paramUpdFax.DbType = DbType.String;
                paramUpdFax.Value = (object)EmpresasDB.Fax ?? DBNull.Value;
                var paramUpdNombres_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombres_del_Representante_Legal.ParameterName = "Nombres_del_Representante_Legal";
                paramUpdNombres_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombres_del_Representante_Legal.Value = (object)EmpresasDB.Nombres_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Paterno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Paterno_del_Representante_Legal.ParameterName = "Apellido_Paterno_del_Representante_Legal";
                paramUpdApellido_Paterno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Paterno_del_Representante_Legal.Value = (object)EmpresasDB.Apellido_Paterno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdApellido_Materno_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdApellido_Materno_del_Representante_Legal.ParameterName = "Apellido_Materno_del_Representante_Legal";
                paramUpdApellido_Materno_del_Representante_Legal.DbType = DbType.String;
                paramUpdApellido_Materno_del_Representante_Legal.Value = (object)EmpresasDB.Apellido_Materno_del_Representante_Legal ?? DBNull.Value;
                var paramUpdNombre_Completo_del_Representante_Legal = _dataProvider.GetParameter();
                paramUpdNombre_Completo_del_Representante_Legal.ParameterName = "Nombre_Completo_del_Representante_Legal";
                paramUpdNombre_Completo_del_Representante_Legal.DbType = DbType.String;
                paramUpdNombre_Completo_del_Representante_Legal.Value = (object)EmpresasDB.Nombre_Completo_del_Representante_Legal ?? DBNull.Value;
                var paramUpdCedula_Fiscal = _dataProvider.GetParameter();
                paramUpdCedula_Fiscal.ParameterName = "Cedula_Fiscal";
                paramUpdCedula_Fiscal.DbType = DbType.Int32;
                paramUpdCedula_Fiscal.Value = (object)entity.Cedula_Fiscal ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEmpresas>("sp_UpdEmpresas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_la_Empresa , paramUpdTipo_de_Empresa , paramUpdEmail , paramUpdTelefono , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdEstado , paramUpdPais , paramUpdEstatus , paramUpdRegimen_Fiscal , paramUpdNombre_o_Razon_Social , paramUpdRFC , paramUpdCalle_Fiscal , paramUpdNumero_exterior_Fiscal , paramUpdNumero_interior_Fiscal , paramUpdColonia_Fiscal , paramUpdCP_Fiscal , paramUpdCiudad_Fiscal , paramUpdEstado_Fiscal , paramUpdPais_Fiscal , paramUpdTelefono_Fiscal , paramUpdFax , paramUpdNombres_del_Representante_Legal , paramUpdApellido_Paterno_del_Representante_Legal , paramUpdApellido_Materno_del_Representante_Legal , paramUpdNombre_Completo_del_Representante_Legal , paramUpdCedula_Fiscal ).FirstOrDefault();

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


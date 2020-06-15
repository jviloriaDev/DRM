using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Contactos_Empresa;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Contactos_Empresa
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Contactos_EmpresaService : IDetalle_Contactos_EmpresaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> _Detalle_Contactos_EmpresaRepository;
        #endregion

        #region Ctor
        public Detalle_Contactos_EmpresaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> Detalle_Contactos_EmpresaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Contactos_EmpresaRepository = Detalle_Contactos_EmpresaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Contactos_EmpresaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa>("sp_SelAllDetalle_Contactos_Empresa");
        }

        public IList<Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Contactos_Empresa_Complete>("sp_SelAllComplete_Detalle_Contactos_Empresa");
            return data.Select(m => new Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa
            {
                Folio = m.Folio
                ,Folio_Empresas = m.Folio_Empresas
                ,Nombre_completo = m.Nombre_completo
                ,Correo = m.Correo
                ,Telefono = m.Telefono
                ,Contacto_Principal = m.Contacto_Principal.GetValueOrDefault()
                ,Area_areas_Empresas = new Core.Classes.areas_Empresas.areas_Empresas() { Clave = m.Area.GetValueOrDefault(), Nombre = m.Area_Nombre }
                ,Acceso_al_Sistema = m.Acceso_al_Sistema.GetValueOrDefault()
                ,Nombre_de_usuario = m.Nombre_de_usuario
                ,Recibe_Alertas = m.Recibe_Alertas.GetValueOrDefault()
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Contactos_Empresa>("sp_ListSelCount_Detalle_Contactos_Empresa", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Contactos_Empresa>("sp_ListSelAll_Detalle_Contactos_Empresa", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa
                {
                    Folio = m.Detalle_Contactos_Empresa_Folio,
                    Folio_Empresas = m.Detalle_Contactos_Empresa_Folio_Empresas,
                    Nombre_completo = m.Detalle_Contactos_Empresa_Nombre_completo,
                    Correo = m.Detalle_Contactos_Empresa_Correo,
                    Telefono = m.Detalle_Contactos_Empresa_Telefono,
                    Contacto_Principal = m.Detalle_Contactos_Empresa_Contacto_Principal ?? false,
                    Area = m.Detalle_Contactos_Empresa_Area,
                    Acceso_al_Sistema = m.Detalle_Contactos_Empresa_Acceso_al_Sistema ?? false,
                    Nombre_de_usuario = m.Detalle_Contactos_Empresa_Nombre_de_usuario,
                    Recibe_Alertas = m.Detalle_Contactos_Empresa_Recibe_Alertas ?? false,
                    Estatus = m.Detalle_Contactos_Empresa_Estatus,

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

        public IList<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Contactos_EmpresaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Contactos_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Contactos_Empresa>("sp_ListSelAll_Detalle_Contactos_Empresa", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Contactos_EmpresaPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Contactos_EmpresaPagingModel
                {
                    Detalle_Contactos_Empresas =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa
                {
                    Folio = m.Detalle_Contactos_Empresa_Folio
                    ,Folio_Empresas = m.Detalle_Contactos_Empresa_Folio_Empresas
                    ,Nombre_completo = m.Detalle_Contactos_Empresa_Nombre_completo
                    ,Correo = m.Detalle_Contactos_Empresa_Correo
                    ,Telefono = m.Detalle_Contactos_Empresa_Telefono
                    ,Contacto_Principal = m.Detalle_Contactos_Empresa_Contacto_Principal ?? false
                    ,Area = m.Detalle_Contactos_Empresa_Area
                    ,Area_areas_Empresas = new Core.Classes.areas_Empresas.areas_Empresas() { Clave = m.Detalle_Contactos_Empresa_Area.GetValueOrDefault(), Nombre = m.Detalle_Contactos_Empresa_Area_Nombre }
                    ,Acceso_al_Sistema = m.Detalle_Contactos_Empresa_Acceso_al_Sistema ?? false
                    ,Nombre_de_usuario = m.Detalle_Contactos_Empresa_Nombre_de_usuario
                    ,Recibe_Alertas = m.Detalle_Contactos_Empresa_Recibe_Alertas ?? false
                    ,Estatus = m.Detalle_Contactos_Empresa_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Detalle_Contactos_Empresa_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Contactos_Empresa_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Contactos_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa>("sp_GetDetalle_Contactos_Empresa", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Contactos_Empresa>("sp_DelDetalle_Contactos_Empresa", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Empresas = _dataProvider.GetParameter();
                padreFolio_Empresas.ParameterName = "Folio_Empresas";
                padreFolio_Empresas.DbType = DbType.Int32;
                padreFolio_Empresas.Value = (object)entity.Folio_Empresas ?? DBNull.Value;
                var padreNombre_completo = _dataProvider.GetParameter();
                padreNombre_completo.ParameterName = "Nombre_completo";
                padreNombre_completo.DbType = DbType.String;
                padreNombre_completo.Value = (object)entity.Nombre_completo ?? DBNull.Value;
                var padreCorreo = _dataProvider.GetParameter();
                padreCorreo.ParameterName = "Correo";
                padreCorreo.DbType = DbType.String;
                padreCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var padreTelefono = _dataProvider.GetParameter();
                padreTelefono.ParameterName = "Telefono";
                padreTelefono.DbType = DbType.String;
                padreTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var padreContacto_Principal = _dataProvider.GetParameter();
                padreContacto_Principal.ParameterName = "Contacto_Principal";
                padreContacto_Principal.DbType = DbType.Boolean;
                padreContacto_Principal.Value = (object)entity.Contacto_Principal ?? DBNull.Value;
                var padreArea = _dataProvider.GetParameter();
                padreArea.ParameterName = "Area";
                padreArea.DbType = DbType.Int32;
                padreArea.Value = (object)entity.Area ?? DBNull.Value;

                var padreAcceso_al_Sistema = _dataProvider.GetParameter();
                padreAcceso_al_Sistema.ParameterName = "Acceso_al_Sistema";
                padreAcceso_al_Sistema.DbType = DbType.Boolean;
                padreAcceso_al_Sistema.Value = (object)entity.Acceso_al_Sistema ?? DBNull.Value;
                var padreNombre_de_usuario = _dataProvider.GetParameter();
                padreNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                padreNombre_de_usuario.DbType = DbType.String;
                padreNombre_de_usuario.Value = (object)entity.Nombre_de_usuario ?? DBNull.Value;
                var padreRecibe_Alertas = _dataProvider.GetParameter();
                padreRecibe_Alertas.ParameterName = "Recibe_Alertas";
                padreRecibe_Alertas.DbType = DbType.Boolean;
                padreRecibe_Alertas.Value = (object)entity.Recibe_Alertas ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Contactos_Empresa>("sp_InsDetalle_Contactos_Empresa" , padreFolio_Empresas
, padreNombre_completo
, padreCorreo
, padreTelefono
, padreContacto_Principal
, padreArea
, padreAcceso_al_Sistema
, padreNombre_de_usuario
, padreRecibe_Alertas
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

        public int Update(Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Empresas = _dataProvider.GetParameter();
                paramUpdFolio_Empresas.ParameterName = "Folio_Empresas";
                paramUpdFolio_Empresas.DbType = DbType.Int32;
                paramUpdFolio_Empresas.Value = (object)entity.Folio_Empresas ?? DBNull.Value;
                var paramUpdNombre_completo = _dataProvider.GetParameter();
                paramUpdNombre_completo.ParameterName = "Nombre_completo";
                paramUpdNombre_completo.DbType = DbType.String;
                paramUpdNombre_completo.Value = (object)entity.Nombre_completo ?? DBNull.Value;
                var paramUpdCorreo = _dataProvider.GetParameter();
                paramUpdCorreo.ParameterName = "Correo";
                paramUpdCorreo.DbType = DbType.String;
                paramUpdCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdContacto_Principal = _dataProvider.GetParameter();
                paramUpdContacto_Principal.ParameterName = "Contacto_Principal";
                paramUpdContacto_Principal.DbType = DbType.Boolean;
                paramUpdContacto_Principal.Value = (object)entity.Contacto_Principal ?? DBNull.Value;
                var paramUpdArea = _dataProvider.GetParameter();
                paramUpdArea.ParameterName = "Area";
                paramUpdArea.DbType = DbType.Int32;
                paramUpdArea.Value = (object)entity.Area ?? DBNull.Value;

                var paramUpdAcceso_al_Sistema = _dataProvider.GetParameter();
                paramUpdAcceso_al_Sistema.ParameterName = "Acceso_al_Sistema";
                paramUpdAcceso_al_Sistema.DbType = DbType.Boolean;
                paramUpdAcceso_al_Sistema.Value = (object)entity.Acceso_al_Sistema ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)entity.Nombre_de_usuario ?? DBNull.Value;
                var paramUpdRecibe_Alertas = _dataProvider.GetParameter();
                paramUpdRecibe_Alertas.ParameterName = "Recibe_Alertas";
                paramUpdRecibe_Alertas.DbType = DbType.Boolean;
                paramUpdRecibe_Alertas.Value = (object)entity.Recibe_Alertas ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Contactos_Empresa>("sp_UpdDetalle_Contactos_Empresa" , paramUpdFolio , paramUpdFolio_Empresas , paramUpdNombre_completo , paramUpdCorreo , paramUpdTelefono , paramUpdContacto_Principal , paramUpdArea , paramUpdAcceso_al_Sistema , paramUpdNombre_de_usuario , paramUpdRecibe_Alertas , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa Detalle_Contactos_EmpresaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Empresas = _dataProvider.GetParameter();
                paramUpdFolio_Empresas.ParameterName = "Folio_Empresas";
                paramUpdFolio_Empresas.DbType = DbType.Int32;
                paramUpdFolio_Empresas.Value = (object)entity.Folio_Empresas ?? DBNull.Value;
                var paramUpdNombre_completo = _dataProvider.GetParameter();
                paramUpdNombre_completo.ParameterName = "Nombre_completo";
                paramUpdNombre_completo.DbType = DbType.String;
                paramUpdNombre_completo.Value = (object)entity.Nombre_completo ?? DBNull.Value;
                var paramUpdCorreo = _dataProvider.GetParameter();
                paramUpdCorreo.ParameterName = "Correo";
                paramUpdCorreo.DbType = DbType.String;
                paramUpdCorreo.Value = (object)entity.Correo ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdContacto_Principal = _dataProvider.GetParameter();
                paramUpdContacto_Principal.ParameterName = "Contacto_Principal";
                paramUpdContacto_Principal.DbType = DbType.Boolean;
                paramUpdContacto_Principal.Value = (object)entity.Contacto_Principal ?? DBNull.Value;
		var paramUpdArea = _dataProvider.GetParameter();
                paramUpdArea.ParameterName = "Area";
                paramUpdArea.DbType = DbType.Int32;
                paramUpdArea.Value = (object)entity.Area ?? DBNull.Value;
                var paramUpdAcceso_al_Sistema = _dataProvider.GetParameter();
                paramUpdAcceso_al_Sistema.ParameterName = "Acceso_al_Sistema";
                paramUpdAcceso_al_Sistema.DbType = DbType.Boolean;
                paramUpdAcceso_al_Sistema.Value = (object)entity.Acceso_al_Sistema ?? DBNull.Value;
                var paramUpdNombre_de_usuario = _dataProvider.GetParameter();
                paramUpdNombre_de_usuario.ParameterName = "Nombre_de_usuario";
                paramUpdNombre_de_usuario.DbType = DbType.String;
                paramUpdNombre_de_usuario.Value = (object)entity.Nombre_de_usuario ?? DBNull.Value;
                var paramUpdRecibe_Alertas = _dataProvider.GetParameter();
                paramUpdRecibe_Alertas.ParameterName = "Recibe_Alertas";
                paramUpdRecibe_Alertas.DbType = DbType.Boolean;
                paramUpdRecibe_Alertas.Value = (object)entity.Recibe_Alertas ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Contactos_Empresa>("sp_UpdDetalle_Contactos_Empresa" , paramUpdFolio , paramUpdFolio_Empresas , paramUpdNombre_completo , paramUpdCorreo , paramUpdTelefono , paramUpdContacto_Principal , paramUpdArea , paramUpdAcceso_al_Sistema , paramUpdNombre_de_usuario , paramUpdRecibe_Alertas , paramUpdEstatus ).FirstOrDefault();

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


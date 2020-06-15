using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tips_y_Promociones;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tips_y_Promociones
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tips_y_PromocionesService : ITips_y_PromocionesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> _Tips_y_PromocionesRepository;
        #endregion

        #region Ctor
        public Tips_y_PromocionesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> Tips_y_PromocionesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tips_y_PromocionesRepository = Tips_y_PromocionesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tips_y_PromocionesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones>("sp_SelAllTips_y_Promociones");
        }

        public IList<Core.Classes.Tips_y_Promociones.Tips_y_Promociones> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTips_y_Promociones_Complete>("sp_SelAllComplete_Tips_y_Promociones");
            return data.Select(m => new Core.Classes.Tips_y_Promociones.Tips_y_Promociones
            {
                Folio = m.Folio
                ,Fecha_de_registro = m.Fecha_de_registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombre = m.Nombre
                ,Descripcion_Corta = m.Descripcion_Corta
                ,Descripcion_Larga = m.Descripcion_Larga
                ,Imagen = m.Imagen
                ,Fecha_inicio_de_Vigencia = m.Fecha_inicio_de_Vigencia
                ,Fecha_fin_de_Vigencia = m.Fecha_fin_de_Vigencia
                ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Especialidad.GetValueOrDefault(), Especialidad = m.Especialidad_Especialidad }
                ,Especialista_Medicos = new Core.Classes.Medicos.Medicos() { Folio = m.Especialista.GetValueOrDefault(), Nombre_Completo = m.Especialista_Nombre_Completo }
                ,Vendedor_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Vendedor.GetValueOrDefault(), Name = m.Vendedor_Name }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tips_y_Promociones>("sp_ListSelCount_Tips_y_Promociones", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTips_y_Promociones>("sp_ListSelAll_Tips_y_Promociones", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones
                {
                    Folio = m.Tips_y_Promociones_Folio,
                    Fecha_de_registro = m.Tips_y_Promociones_Fecha_de_registro,
                    Hora_de_Registro = m.Tips_y_Promociones_Hora_de_Registro,
                    Usuario_que_Registra = m.Tips_y_Promociones_Usuario_que_Registra,
                    Nombre = m.Tips_y_Promociones_Nombre,
                    Descripcion_Corta = m.Tips_y_Promociones_Descripcion_Corta,
                    Descripcion_Larga = m.Tips_y_Promociones_Descripcion_Larga,
                    Imagen = m.Tips_y_Promociones_Imagen,
                    Fecha_inicio_de_Vigencia = m.Tips_y_Promociones_Fecha_inicio_de_Vigencia,
                    Fecha_fin_de_Vigencia = m.Tips_y_Promociones_Fecha_fin_de_Vigencia,
                    Especialidad = m.Tips_y_Promociones_Especialidad,
                    Especialista = m.Tips_y_Promociones_Especialista,
                    Vendedor = m.Tips_y_Promociones_Vendedor,
                    Estatus = m.Tips_y_Promociones_Estatus,

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

        public IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tips_y_PromocionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tips_y_PromocionesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tips_y_Promociones.Tips_y_PromocionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTips_y_Promociones>("sp_ListSelAll_Tips_y_Promociones", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tips_y_PromocionesPagingModel result = null;

            if (data != null)
            {
                result = new Tips_y_PromocionesPagingModel
                {
                    Tips_y_Promocioness =
                        data.Select(m => new Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones
                {
                    Folio = m.Tips_y_Promociones_Folio
                    ,Fecha_de_registro = m.Tips_y_Promociones_Fecha_de_registro
                    ,Hora_de_Registro = m.Tips_y_Promociones_Hora_de_Registro
                    ,Usuario_que_Registra = m.Tips_y_Promociones_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Tips_y_Promociones_Usuario_que_Registra.GetValueOrDefault(), Name = m.Tips_y_Promociones_Usuario_que_Registra_Name }
                    ,Nombre = m.Tips_y_Promociones_Nombre
                    ,Descripcion_Corta = m.Tips_y_Promociones_Descripcion_Corta
                    ,Descripcion_Larga = m.Tips_y_Promociones_Descripcion_Larga
                    ,Imagen = m.Tips_y_Promociones_Imagen
                    ,Fecha_inicio_de_Vigencia = m.Tips_y_Promociones_Fecha_inicio_de_Vigencia
                    ,Fecha_fin_de_Vigencia = m.Tips_y_Promociones_Fecha_fin_de_Vigencia
                    ,Especialidad = m.Tips_y_Promociones_Especialidad
                    ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Tips_y_Promociones_Especialidad.GetValueOrDefault(), Especialidad = m.Tips_y_Promociones_Especialidad_Especialidad }
                    ,Especialista = m.Tips_y_Promociones_Especialista
                    ,Especialista_Medicos = new Core.Classes.Medicos.Medicos() { Folio = m.Tips_y_Promociones_Especialista.GetValueOrDefault(), Nombre_Completo = m.Tips_y_Promociones_Especialista_Nombre_Completo }
                    ,Vendedor = m.Tips_y_Promociones_Vendedor
                    ,Vendedor_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Tips_y_Promociones_Vendedor.GetValueOrDefault(), Name = m.Tips_y_Promociones_Vendedor_Name }
                    ,Estatus = m.Tips_y_Promociones_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Tips_y_Promociones_Estatus.GetValueOrDefault(), Descripcion = m.Tips_y_Promociones_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tips_y_PromocionesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones>("sp_GetTips_y_Promociones", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTips_y_Promociones>("sp_DelTips_y_Promociones", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_registro = _dataProvider.GetParameter();
                padreFecha_de_registro.ParameterName = "Fecha_de_registro";
                padreFecha_de_registro.DbType = DbType.DateTime;
                padreFecha_de_registro.Value = (object)entity.Fecha_de_registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreDescripcion_Corta = _dataProvider.GetParameter();
                padreDescripcion_Corta.ParameterName = "Descripcion_Corta";
                padreDescripcion_Corta.DbType = DbType.String;
                padreDescripcion_Corta.Value = (object)entity.Descripcion_Corta ?? DBNull.Value;
                var padreDescripcion_Larga = _dataProvider.GetParameter();
                padreDescripcion_Larga.ParameterName = "Descripcion_Larga";
                padreDescripcion_Larga.DbType = DbType.String;
                padreDescripcion_Larga.Value = (object)entity.Descripcion_Larga ?? DBNull.Value;
                var padreImagen = _dataProvider.GetParameter();
                padreImagen.ParameterName = "Imagen";
                padreImagen.DbType = DbType.Int32;
                padreImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var padreFecha_inicio_de_Vigencia = _dataProvider.GetParameter();
                padreFecha_inicio_de_Vigencia.ParameterName = "Fecha_inicio_de_Vigencia";
                padreFecha_inicio_de_Vigencia.DbType = DbType.DateTime;
                padreFecha_inicio_de_Vigencia.Value = (object)entity.Fecha_inicio_de_Vigencia ?? DBNull.Value;

                var padreFecha_fin_de_Vigencia = _dataProvider.GetParameter();
                padreFecha_fin_de_Vigencia.ParameterName = "Fecha_fin_de_Vigencia";
                padreFecha_fin_de_Vigencia.DbType = DbType.DateTime;
                padreFecha_fin_de_Vigencia.Value = (object)entity.Fecha_fin_de_Vigencia ?? DBNull.Value;

                var padreEspecialidad = _dataProvider.GetParameter();
                padreEspecialidad.ParameterName = "Especialidad";
                padreEspecialidad.DbType = DbType.Int32;
                padreEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var padreEspecialista = _dataProvider.GetParameter();
                padreEspecialista.ParameterName = "Especialista";
                padreEspecialista.DbType = DbType.Int32;
                padreEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;

                var padreVendedor = _dataProvider.GetParameter();
                padreVendedor.ParameterName = "Vendedor";
                padreVendedor.DbType = DbType.Int32;
                padreVendedor.Value = (object)entity.Vendedor ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTips_y_Promociones>("sp_InsTips_y_Promociones" , padreFecha_de_registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombre
, padreDescripcion_Corta
, padreDescripcion_Larga
, padreImagen
, padreFecha_inicio_de_Vigencia
, padreFecha_fin_de_Vigencia
, padreEspecialidad
, padreEspecialista
, padreVendedor
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

        public int Update(Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_registro = _dataProvider.GetParameter();
                paramUpdFecha_de_registro.ParameterName = "Fecha_de_registro";
                paramUpdFecha_de_registro.DbType = DbType.DateTime;
                paramUpdFecha_de_registro.Value = (object)entity.Fecha_de_registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdDescripcion_Corta = _dataProvider.GetParameter();
                paramUpdDescripcion_Corta.ParameterName = "Descripcion_Corta";
                paramUpdDescripcion_Corta.DbType = DbType.String;
                paramUpdDescripcion_Corta.Value = (object)entity.Descripcion_Corta ?? DBNull.Value;
                var paramUpdDescripcion_Larga = _dataProvider.GetParameter();
                paramUpdDescripcion_Larga.ParameterName = "Descripcion_Larga";
                paramUpdDescripcion_Larga.DbType = DbType.String;
                paramUpdDescripcion_Larga.Value = (object)entity.Descripcion_Larga ?? DBNull.Value;
                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var paramUpdFecha_inicio_de_Vigencia = _dataProvider.GetParameter();
                paramUpdFecha_inicio_de_Vigencia.ParameterName = "Fecha_inicio_de_Vigencia";
                paramUpdFecha_inicio_de_Vigencia.DbType = DbType.DateTime;
                paramUpdFecha_inicio_de_Vigencia.Value = (object)entity.Fecha_inicio_de_Vigencia ?? DBNull.Value;

                var paramUpdFecha_fin_de_Vigencia = _dataProvider.GetParameter();
                paramUpdFecha_fin_de_Vigencia.ParameterName = "Fecha_fin_de_Vigencia";
                paramUpdFecha_fin_de_Vigencia.DbType = DbType.DateTime;
                paramUpdFecha_fin_de_Vigencia.Value = (object)entity.Fecha_fin_de_Vigencia ?? DBNull.Value;

                var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var paramUpdEspecialista = _dataProvider.GetParameter();
                paramUpdEspecialista.ParameterName = "Especialista";
                paramUpdEspecialista.DbType = DbType.Int32;
                paramUpdEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;

                var paramUpdVendedor = _dataProvider.GetParameter();
                paramUpdVendedor.ParameterName = "Vendedor";
                paramUpdVendedor.DbType = DbType.Int32;
                paramUpdVendedor.Value = (object)entity.Vendedor ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTips_y_Promociones>("sp_UpdTips_y_Promociones" , paramUpdFolio , paramUpdFecha_de_registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre , paramUpdDescripcion_Corta , paramUpdDescripcion_Larga , paramUpdImagen , paramUpdFecha_inicio_de_Vigencia , paramUpdFecha_fin_de_Vigencia , paramUpdEspecialidad , paramUpdEspecialista , paramUpdVendedor , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones Tips_y_PromocionesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_registro = _dataProvider.GetParameter();
                paramUpdFecha_de_registro.ParameterName = "Fecha_de_registro";
                paramUpdFecha_de_registro.DbType = DbType.DateTime;
                paramUpdFecha_de_registro.Value = (object)entity.Fecha_de_registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdDescripcion_Corta = _dataProvider.GetParameter();
                paramUpdDescripcion_Corta.ParameterName = "Descripcion_Corta";
                paramUpdDescripcion_Corta.DbType = DbType.String;
                paramUpdDescripcion_Corta.Value = (object)entity.Descripcion_Corta ?? DBNull.Value;
                var paramUpdDescripcion_Larga = _dataProvider.GetParameter();
                paramUpdDescripcion_Larga.ParameterName = "Descripcion_Larga";
                paramUpdDescripcion_Larga.DbType = DbType.String;
                paramUpdDescripcion_Larga.Value = (object)entity.Descripcion_Larga ?? DBNull.Value;
                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;
                var paramUpdFecha_inicio_de_Vigencia = _dataProvider.GetParameter();
                paramUpdFecha_inicio_de_Vigencia.ParameterName = "Fecha_inicio_de_Vigencia";
                paramUpdFecha_inicio_de_Vigencia.DbType = DbType.DateTime;
                paramUpdFecha_inicio_de_Vigencia.Value = (object)entity.Fecha_inicio_de_Vigencia ?? DBNull.Value;
                var paramUpdFecha_fin_de_Vigencia = _dataProvider.GetParameter();
                paramUpdFecha_fin_de_Vigencia.ParameterName = "Fecha_fin_de_Vigencia";
                paramUpdFecha_fin_de_Vigencia.DbType = DbType.DateTime;
                paramUpdFecha_fin_de_Vigencia.Value = (object)entity.Fecha_fin_de_Vigencia ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
		var paramUpdEspecialista = _dataProvider.GetParameter();
                paramUpdEspecialista.ParameterName = "Especialista";
                paramUpdEspecialista.DbType = DbType.Int32;
                paramUpdEspecialista.Value = (object)entity.Especialista ?? DBNull.Value;
		var paramUpdVendedor = _dataProvider.GetParameter();
                paramUpdVendedor.ParameterName = "Vendedor";
                paramUpdVendedor.DbType = DbType.Int32;
                paramUpdVendedor.Value = (object)entity.Vendedor ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTips_y_Promociones>("sp_UpdTips_y_Promociones" , paramUpdFolio , paramUpdFecha_de_registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre , paramUpdDescripcion_Corta , paramUpdDescripcion_Larga , paramUpdImagen , paramUpdFecha_inicio_de_Vigencia , paramUpdFecha_fin_de_Vigencia , paramUpdEspecialidad , paramUpdEspecialista , paramUpdVendedor , paramUpdEstatus ).FirstOrDefault();

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


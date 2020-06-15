using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class PlatillosService : IPlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Platillos.Platillos> _PlatillosRepository;
        #endregion

        #region Ctor
        public PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Platillos.Platillos> PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._PlatillosRepository = PlatillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._PlatillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Platillos.Platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Platillos.Platillos>("sp_SelAllPlatillos");
        }

        public IList<Core.Classes.Platillos.Platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPlatillos_Complete>("sp_SelAllComplete_Platillos");
            return data.Select(m => new Core.Classes.Platillos.Platillos
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombre_de_Platillo = m.Nombre_de_Platillo
                ,Imagen = m.Imagen
                ,Calorias_Calorias = new Core.Classes.Calorias.Calorias() { Clave = m.Calorias.GetValueOrDefault(), Cantidad = m.Calorias_Cantidad }
                ,Dificultad_Dificultad_de_platillos = new Core.Classes.Dificultad_de_platillos.Dificultad_de_platillos() { Clave = m.Dificultad.GetValueOrDefault(), Categoria = m.Dificultad_Categoria }
                ,Categoria_del_Platillo_Categorias_de_platillos = new Core.Classes.Categorias_de_platillos.Categorias_de_platillos() { Clave = m.Categoria_del_Platillo.GetValueOrDefault(), Categoria = m.Categoria_del_Platillo_Categoria }
                ,Tiempo_de_comida_Tiempos_de_Comida = new Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida() { Clave = m.Tiempo_de_comida.GetValueOrDefault(), Comida = m.Tiempo_de_comida_Comida }
                ,Tipo_de_comida_Tipo_de_comida_platillos = new Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos() { Folio = m.Tipo_de_comida.GetValueOrDefault(), Tipo_de_comida = m.Tipo_de_comida_Tipo_de_comida }
                ,Caracteristicas_Caracteristicas_platillo = new Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo() { Folio = m.Caracteristicas.GetValueOrDefault(), Caracteristicas = m.Caracteristicas_Caracteristicas }
                ,Calificacion = m.Calificacion
                ,Modo_de_Preparacion = m.Modo_de_Preparacion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Platillos>("sp_ListSelCount_Platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Platillos.Platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlatillos>("sp_ListSelAll_Platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Platillos.Platillos
                {
                    Folio = m.Platillos_Folio,
                    Fecha_de_Registro = m.Platillos_Fecha_de_Registro,
                    Hora_de_Registro = m.Platillos_Hora_de_Registro,
                    Usuario_que_Registra = m.Platillos_Usuario_que_Registra,
                    Nombre_de_Platillo = m.Platillos_Nombre_de_Platillo,
                    Imagen = m.Platillos_Imagen,
                    Calorias = m.Platillos_Calorias,
                    Dificultad = m.Platillos_Dificultad,
                    Categoria_del_Platillo = m.Platillos_Categoria_del_Platillo,
                    Tiempo_de_comida = m.Platillos_Tiempo_de_comida,
                    Tipo_de_comida = m.Platillos_Tipo_de_comida,
                    Caracteristicas = m.Platillos_Caracteristicas,
                    Calificacion = m.Platillos_Calificacion,
                    Modo_de_Preparacion = m.Platillos_Modo_de_Preparacion,

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

        public IList<Spartane.Core.Classes.Platillos.Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Platillos.Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Platillos.PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlatillos>("sp_ListSelAll_Platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            PlatillosPagingModel result = null;

            if (data != null)
            {
                result = new PlatillosPagingModel
                {
                    Platilloss =
                        data.Select(m => new Spartane.Core.Classes.Platillos.Platillos
                {
                    Folio = m.Platillos_Folio
                    ,Fecha_de_Registro = m.Platillos_Fecha_de_Registro
                    ,Hora_de_Registro = m.Platillos_Hora_de_Registro
                    ,Usuario_que_Registra = m.Platillos_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Platillos_Usuario_que_Registra.GetValueOrDefault(), Name = m.Platillos_Usuario_que_Registra_Name }
                    ,Nombre_de_Platillo = m.Platillos_Nombre_de_Platillo
                    ,Imagen = m.Platillos_Imagen
                    ,Calorias = m.Platillos_Calorias
                    ,Calorias_Calorias = new Core.Classes.Calorias.Calorias() { Clave = m.Platillos_Calorias.GetValueOrDefault(), Cantidad = m.Platillos_Calorias_Cantidad }
                    ,Dificultad = m.Platillos_Dificultad
                    ,Dificultad_Dificultad_de_platillos = new Core.Classes.Dificultad_de_platillos.Dificultad_de_platillos() { Clave = m.Platillos_Dificultad.GetValueOrDefault(), Categoria = m.Platillos_Dificultad_Categoria }
                    ,Categoria_del_Platillo = m.Platillos_Categoria_del_Platillo
                    ,Categoria_del_Platillo_Categorias_de_platillos = new Core.Classes.Categorias_de_platillos.Categorias_de_platillos() { Clave = m.Platillos_Categoria_del_Platillo.GetValueOrDefault(), Categoria = m.Platillos_Categoria_del_Platillo_Categoria }
                    ,Tiempo_de_comida = m.Platillos_Tiempo_de_comida
                    ,Tiempo_de_comida_Tiempos_de_Comida = new Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida() { Clave = m.Platillos_Tiempo_de_comida.GetValueOrDefault(), Comida = m.Platillos_Tiempo_de_comida_Comida }
                    ,Tipo_de_comida = m.Platillos_Tipo_de_comida
                    ,Tipo_de_comida_Tipo_de_comida_platillos = new Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos() { Folio = m.Platillos_Tipo_de_comida.GetValueOrDefault(), Tipo_de_comida = m.Platillos_Tipo_de_comida_Tipo_de_comida }
                    ,Caracteristicas = m.Platillos_Caracteristicas
                    ,Caracteristicas_Caracteristicas_platillo = new Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo() { Folio = m.Platillos_Caracteristicas.GetValueOrDefault(), Caracteristicas = m.Platillos_Caracteristicas_Caracteristicas }
                    ,Calificacion = m.Platillos_Calificacion
                    ,Modo_de_Preparacion = m.Platillos_Modo_de_Preparacion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Platillos.Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Platillos.Platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Platillos.Platillos>("sp_GetPlatillos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPlatillos>("sp_DelPlatillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Platillos.Platillos entity)
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

                var padreNombre_de_Platillo = _dataProvider.GetParameter();
                padreNombre_de_Platillo.ParameterName = "Nombre_de_Platillo";
                padreNombre_de_Platillo.DbType = DbType.String;
                padreNombre_de_Platillo.Value = (object)entity.Nombre_de_Platillo ?? DBNull.Value;
                var padreImagen = _dataProvider.GetParameter();
                padreImagen.ParameterName = "Imagen";
                padreImagen.DbType = DbType.Int32;
                padreImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var padreCalorias = _dataProvider.GetParameter();
                padreCalorias.ParameterName = "Calorias";
                padreCalorias.DbType = DbType.Int32;
                padreCalorias.Value = (object)entity.Calorias ?? DBNull.Value;

                var padreDificultad = _dataProvider.GetParameter();
                padreDificultad.ParameterName = "Dificultad";
                padreDificultad.DbType = DbType.Int32;
                padreDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;

                var padreCategoria_del_Platillo = _dataProvider.GetParameter();
                padreCategoria_del_Platillo.ParameterName = "Categoria_del_Platillo";
                padreCategoria_del_Platillo.DbType = DbType.Int32;
                padreCategoria_del_Platillo.Value = (object)entity.Categoria_del_Platillo ?? DBNull.Value;

                var padreTiempo_de_comida = _dataProvider.GetParameter();
                padreTiempo_de_comida.ParameterName = "Tiempo_de_comida";
                padreTiempo_de_comida.DbType = DbType.Int32;
                padreTiempo_de_comida.Value = (object)entity.Tiempo_de_comida ?? DBNull.Value;

                var padreTipo_de_comida = _dataProvider.GetParameter();
                padreTipo_de_comida.ParameterName = "Tipo_de_comida";
                padreTipo_de_comida.DbType = DbType.Int32;
                padreTipo_de_comida.Value = (object)entity.Tipo_de_comida ?? DBNull.Value;

                var padreCaracteristicas = _dataProvider.GetParameter();
                padreCaracteristicas.ParameterName = "Caracteristicas";
                padreCaracteristicas.DbType = DbType.Int32;
                padreCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;

                var padreCalificacion = _dataProvider.GetParameter();
                padreCalificacion.ParameterName = "Calificacion";
                padreCalificacion.DbType = DbType.String;
                padreCalificacion.Value = (object)entity.Calificacion ?? DBNull.Value;
                var padreModo_de_Preparacion = _dataProvider.GetParameter();
                padreModo_de_Preparacion.ParameterName = "Modo_de_Preparacion";
                padreModo_de_Preparacion.DbType = DbType.String;
                padreModo_de_Preparacion.Value = (object)entity.Modo_de_Preparacion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPlatillos>("sp_InsPlatillos" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombre_de_Platillo
, padreImagen
, padreCalorias
, padreDificultad
, padreCategoria_del_Platillo
, padreTiempo_de_comida
, padreTipo_de_comida
, padreCaracteristicas
, padreCalificacion
, padreModo_de_Preparacion
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

        public int Update(Spartane.Core.Classes.Platillos.Platillos entity)
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

                var paramUpdNombre_de_Platillo = _dataProvider.GetParameter();
                paramUpdNombre_de_Platillo.ParameterName = "Nombre_de_Platillo";
                paramUpdNombre_de_Platillo.DbType = DbType.String;
                paramUpdNombre_de_Platillo.Value = (object)entity.Nombre_de_Platillo ?? DBNull.Value;
                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)entity.Calorias ?? DBNull.Value;

                var paramUpdDificultad = _dataProvider.GetParameter();
                paramUpdDificultad.ParameterName = "Dificultad";
                paramUpdDificultad.DbType = DbType.Int32;
                paramUpdDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;

                var paramUpdCategoria_del_Platillo = _dataProvider.GetParameter();
                paramUpdCategoria_del_Platillo.ParameterName = "Categoria_del_Platillo";
                paramUpdCategoria_del_Platillo.DbType = DbType.Int32;
                paramUpdCategoria_del_Platillo.Value = (object)entity.Categoria_del_Platillo ?? DBNull.Value;

                var paramUpdTiempo_de_comida = _dataProvider.GetParameter();
                paramUpdTiempo_de_comida.ParameterName = "Tiempo_de_comida";
                paramUpdTiempo_de_comida.DbType = DbType.Int32;
                paramUpdTiempo_de_comida.Value = (object)entity.Tiempo_de_comida ?? DBNull.Value;

                var paramUpdTipo_de_comida = _dataProvider.GetParameter();
                paramUpdTipo_de_comida.ParameterName = "Tipo_de_comida";
                paramUpdTipo_de_comida.DbType = DbType.Int32;
                paramUpdTipo_de_comida.Value = (object)entity.Tipo_de_comida ?? DBNull.Value;

                var paramUpdCaracteristicas = _dataProvider.GetParameter();
                paramUpdCaracteristicas.ParameterName = "Caracteristicas";
                paramUpdCaracteristicas.DbType = DbType.Int32;
                paramUpdCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;

                var paramUpdCalificacion = _dataProvider.GetParameter();
                paramUpdCalificacion.ParameterName = "Calificacion";
                paramUpdCalificacion.DbType = DbType.String;
                paramUpdCalificacion.Value = (object)entity.Calificacion ?? DBNull.Value;
                var paramUpdModo_de_Preparacion = _dataProvider.GetParameter();
                paramUpdModo_de_Preparacion.ParameterName = "Modo_de_Preparacion";
                paramUpdModo_de_Preparacion.DbType = DbType.String;
                paramUpdModo_de_Preparacion.Value = (object)entity.Modo_de_Preparacion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlatillos>("sp_UpdPlatillos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_Platillo , paramUpdImagen , paramUpdCalorias , paramUpdDificultad , paramUpdCategoria_del_Platillo , paramUpdTiempo_de_comida , paramUpdTipo_de_comida , paramUpdCaracteristicas , paramUpdCalificacion , paramUpdModo_de_Preparacion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Platillos.Platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Platillos.Platillos PlatillosDB = GetByKey(entity.Folio, false);
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
                var paramUpdNombre_de_Platillo = _dataProvider.GetParameter();
                paramUpdNombre_de_Platillo.ParameterName = "Nombre_de_Platillo";
                paramUpdNombre_de_Platillo.DbType = DbType.String;
                paramUpdNombre_de_Platillo.Value = (object)entity.Nombre_de_Platillo ?? DBNull.Value;
                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;
		var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)entity.Calorias ?? DBNull.Value;
		var paramUpdDificultad = _dataProvider.GetParameter();
                paramUpdDificultad.ParameterName = "Dificultad";
                paramUpdDificultad.DbType = DbType.Int32;
                paramUpdDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;
		var paramUpdCategoria_del_Platillo = _dataProvider.GetParameter();
                paramUpdCategoria_del_Platillo.ParameterName = "Categoria_del_Platillo";
                paramUpdCategoria_del_Platillo.DbType = DbType.Int32;
                paramUpdCategoria_del_Platillo.Value = (object)entity.Categoria_del_Platillo ?? DBNull.Value;
		var paramUpdTiempo_de_comida = _dataProvider.GetParameter();
                paramUpdTiempo_de_comida.ParameterName = "Tiempo_de_comida";
                paramUpdTiempo_de_comida.DbType = DbType.Int32;
                paramUpdTiempo_de_comida.Value = (object)entity.Tiempo_de_comida ?? DBNull.Value;
		var paramUpdTipo_de_comida = _dataProvider.GetParameter();
                paramUpdTipo_de_comida.ParameterName = "Tipo_de_comida";
                paramUpdTipo_de_comida.DbType = DbType.Int32;
                paramUpdTipo_de_comida.Value = (object)entity.Tipo_de_comida ?? DBNull.Value;
		var paramUpdCaracteristicas = _dataProvider.GetParameter();
                paramUpdCaracteristicas.ParameterName = "Caracteristicas";
                paramUpdCaracteristicas.DbType = DbType.Int32;
                paramUpdCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;
                var paramUpdCalificacion = _dataProvider.GetParameter();
                paramUpdCalificacion.ParameterName = "Calificacion";
                paramUpdCalificacion.DbType = DbType.String;
                paramUpdCalificacion.Value = (object)entity.Calificacion ?? DBNull.Value;
                var paramUpdModo_de_Preparacion = _dataProvider.GetParameter();
                paramUpdModo_de_Preparacion.ParameterName = "Modo_de_Preparacion";
                paramUpdModo_de_Preparacion.DbType = DbType.String;
                paramUpdModo_de_Preparacion.Value = (object)entity.Modo_de_Preparacion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlatillos>("sp_UpdPlatillos" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_Platillo , paramUpdImagen , paramUpdCalorias , paramUpdDificultad , paramUpdCategoria_del_Platillo , paramUpdTiempo_de_comida , paramUpdTipo_de_comida , paramUpdCaracteristicas , paramUpdCalificacion , paramUpdModo_de_Preparacion ).FirstOrDefault();

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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EjerciciosService : IEjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Ejercicios.Ejercicios> _EjerciciosRepository;
        #endregion

        #region Ctor
        public EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Ejercicios.Ejercicios> EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EjerciciosRepository = EjerciciosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._EjerciciosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Ejercicios.Ejercicios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Ejercicios.Ejercicios>("sp_SelAllEjercicios");
        }

        public IList<Core.Classes.Ejercicios.Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEjercicios_Complete>("sp_SelAllComplete_Ejercicios");
            return data.Select(m => new Core.Classes.Ejercicios.Ejercicios
            {
                Clave = m.Clave
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombre_del_Ejercicio = m.Nombre_del_Ejercicio
                ,Descripcion_del_Ejercicio = m.Descripcion_del_Ejercicio
                ,Tipo_de_Ejercicio_Tipo_Ejercicio = new Core.Classes.Tipo_Ejercicio.Tipo_Ejercicio() { Clave = m.Tipo_de_Ejercicio.GetValueOrDefault(), Descripcion = m.Tipo_de_Ejercicio_Descripcion }
                ,Nivel_de_dificultad_Nivel_de_dificultad = new Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad() { Folio = m.Nivel_de_dificultad.GetValueOrDefault(), Dificultad = m.Nivel_de_dificultad_Dificultad }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Musculos_trabajados = m.Musculos_trabajados
                ,Imagen = m.Imagen
                ,Video = m.Video
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Ejercicios>("sp_ListSelCount_Ejercicios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Ejercicios.Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEjercicios>("sp_ListSelAll_Ejercicios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Ejercicios.Ejercicios
                {
                    Clave = m.Ejercicios_Clave,
                    Fecha_de_Registro = m.Ejercicios_Fecha_de_Registro,
                    Hora_de_Registro = m.Ejercicios_Hora_de_Registro,
                    Usuario_que_Registra = m.Ejercicios_Usuario_que_Registra,
                    Nombre_del_Ejercicio = m.Ejercicios_Nombre_del_Ejercicio,
                    Descripcion_del_Ejercicio = m.Ejercicios_Descripcion_del_Ejercicio,
                    Tipo_de_Ejercicio = m.Ejercicios_Tipo_de_Ejercicio,
                    Nivel_de_dificultad = m.Ejercicios_Nivel_de_dificultad,
                    Sexo = m.Ejercicios_Sexo,
                    Musculos_trabajados = m.Ejercicios_Musculos_trabajados,
                    Imagen = m.Ejercicios_Imagen,
                    Video = m.Ejercicios_Video,
                    Estatus = m.Ejercicios_Estatus,

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

        public IList<Spartane.Core.Classes.Ejercicios.Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Ejercicios.Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Ejercicios.EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEjercicios>("sp_ListSelAll_Ejercicios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            EjerciciosPagingModel result = null;

            if (data != null)
            {
                result = new EjerciciosPagingModel
                {
                    Ejercicioss =
                        data.Select(m => new Spartane.Core.Classes.Ejercicios.Ejercicios
                {
                    Clave = m.Ejercicios_Clave
                    ,Fecha_de_Registro = m.Ejercicios_Fecha_de_Registro
                    ,Hora_de_Registro = m.Ejercicios_Hora_de_Registro
                    ,Usuario_que_Registra = m.Ejercicios_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Ejercicios_Usuario_que_Registra.GetValueOrDefault(), Name = m.Ejercicios_Usuario_que_Registra_Name }
                    ,Nombre_del_Ejercicio = m.Ejercicios_Nombre_del_Ejercicio
                    ,Descripcion_del_Ejercicio = m.Ejercicios_Descripcion_del_Ejercicio
                    ,Tipo_de_Ejercicio = m.Ejercicios_Tipo_de_Ejercicio
                    ,Tipo_de_Ejercicio_Tipo_Ejercicio = new Core.Classes.Tipo_Ejercicio.Tipo_Ejercicio() { Clave = m.Ejercicios_Tipo_de_Ejercicio.GetValueOrDefault(), Descripcion = m.Ejercicios_Tipo_de_Ejercicio_Descripcion }
                    ,Nivel_de_dificultad = m.Ejercicios_Nivel_de_dificultad
                    ,Nivel_de_dificultad_Nivel_de_dificultad = new Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad() { Folio = m.Ejercicios_Nivel_de_dificultad.GetValueOrDefault(), Dificultad = m.Ejercicios_Nivel_de_dificultad_Dificultad }
                    ,Sexo = m.Ejercicios_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Ejercicios_Sexo.GetValueOrDefault(), Descripcion = m.Ejercicios_Sexo_Descripcion }
                    ,Musculos_trabajados = m.Ejercicios_Musculos_trabajados
                    ,Imagen = m.Ejercicios_Imagen
                    ,Video = m.Ejercicios_Video
                    ,Estatus = m.Ejercicios_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Ejercicios_Estatus.GetValueOrDefault(), Descripcion = m.Ejercicios_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Ejercicios.Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Ejercicios.Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Ejercicios.Ejercicios>("sp_GetEjercicios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEjercicios>("sp_DelEjercicios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Ejercicios.Ejercicios entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
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

                var padreNombre_del_Ejercicio = _dataProvider.GetParameter();
                padreNombre_del_Ejercicio.ParameterName = "Nombre_del_Ejercicio";
                padreNombre_del_Ejercicio.DbType = DbType.String;
                padreNombre_del_Ejercicio.Value = (object)entity.Nombre_del_Ejercicio ?? DBNull.Value;
                var padreDescripcion_del_Ejercicio = _dataProvider.GetParameter();
                padreDescripcion_del_Ejercicio.ParameterName = "Descripcion_del_Ejercicio";
                padreDescripcion_del_Ejercicio.DbType = DbType.String;
                padreDescripcion_del_Ejercicio.Value = (object)entity.Descripcion_del_Ejercicio ?? DBNull.Value;
                var padreTipo_de_Ejercicio = _dataProvider.GetParameter();
                padreTipo_de_Ejercicio.ParameterName = "Tipo_de_Ejercicio";
                padreTipo_de_Ejercicio.DbType = DbType.Int32;
                padreTipo_de_Ejercicio.Value = (object)entity.Tipo_de_Ejercicio ?? DBNull.Value;

                var padreNivel_de_dificultad = _dataProvider.GetParameter();
                padreNivel_de_dificultad.ParameterName = "Nivel_de_dificultad";
                padreNivel_de_dificultad.DbType = DbType.Int32;
                padreNivel_de_dificultad.Value = (object)entity.Nivel_de_dificultad ?? DBNull.Value;

                var padreSexo = _dataProvider.GetParameter();
                padreSexo.ParameterName = "Sexo";
                padreSexo.DbType = DbType.Int32;
                padreSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var padreMusculos_trabajados = _dataProvider.GetParameter();
                padreMusculos_trabajados.ParameterName = "Musculos_trabajados";
                padreMusculos_trabajados.DbType = DbType.Int32;
                padreMusculos_trabajados.Value = (object)entity.Musculos_trabajados ?? DBNull.Value;

                var padreImagen = _dataProvider.GetParameter();
                padreImagen.ParameterName = "Imagen";
                padreImagen.DbType = DbType.Int32;
                padreImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var padreVideo = _dataProvider.GetParameter();
                padreVideo.ParameterName = "Video";
                padreVideo.DbType = DbType.Int32;
                padreVideo.Value = (object)entity.Video ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEjercicios>("sp_InsEjercicios" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombre_del_Ejercicio
, padreDescripcion_del_Ejercicio
, padreTipo_de_Ejercicio
, padreNivel_de_dificultad
, padreSexo
, padreMusculos_trabajados
, padreImagen
, padreVideo
, padreEstatus
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

        public int Update(Spartane.Core.Classes.Ejercicios.Ejercicios entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
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

                var paramUpdNombre_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdNombre_del_Ejercicio.ParameterName = "Nombre_del_Ejercicio";
                paramUpdNombre_del_Ejercicio.DbType = DbType.String;
                paramUpdNombre_del_Ejercicio.Value = (object)entity.Nombre_del_Ejercicio ?? DBNull.Value;
                var paramUpdDescripcion_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdDescripcion_del_Ejercicio.ParameterName = "Descripcion_del_Ejercicio";
                paramUpdDescripcion_del_Ejercicio.DbType = DbType.String;
                paramUpdDescripcion_del_Ejercicio.Value = (object)entity.Descripcion_del_Ejercicio ?? DBNull.Value;
                var paramUpdTipo_de_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_de_Ejercicio.ParameterName = "Tipo_de_Ejercicio";
                paramUpdTipo_de_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_de_Ejercicio.Value = (object)entity.Tipo_de_Ejercicio ?? DBNull.Value;

                var paramUpdNivel_de_dificultad = _dataProvider.GetParameter();
                paramUpdNivel_de_dificultad.ParameterName = "Nivel_de_dificultad";
                paramUpdNivel_de_dificultad.DbType = DbType.Int32;
                paramUpdNivel_de_dificultad.Value = (object)entity.Nivel_de_dificultad ?? DBNull.Value;

                var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var paramUpdMusculos_trabajados = _dataProvider.GetParameter();
                paramUpdMusculos_trabajados.ParameterName = "Musculos_trabajados";
                paramUpdMusculos_trabajados.DbType = DbType.Int32;
                paramUpdMusculos_trabajados.Value = (object)entity.Musculos_trabajados ?? DBNull.Value;

                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var paramUpdVideo = _dataProvider.GetParameter();
                paramUpdVideo.ParameterName = "Video";
                paramUpdVideo.DbType = DbType.Int32;
                paramUpdVideo.Value = (object)entity.Video ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEjercicios>("sp_UpdEjercicios" , paramUpdClave , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_del_Ejercicio , paramUpdDescripcion_del_Ejercicio , paramUpdTipo_de_Ejercicio , paramUpdNivel_de_dificultad , paramUpdSexo , paramUpdMusculos_trabajados , paramUpdImagen , paramUpdVideo , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Ejercicios.Ejercicios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Ejercicios.Ejercicios EjerciciosDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
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
                var paramUpdNombre_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdNombre_del_Ejercicio.ParameterName = "Nombre_del_Ejercicio";
                paramUpdNombre_del_Ejercicio.DbType = DbType.String;
                paramUpdNombre_del_Ejercicio.Value = (object)entity.Nombre_del_Ejercicio ?? DBNull.Value;
                var paramUpdDescripcion_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdDescripcion_del_Ejercicio.ParameterName = "Descripcion_del_Ejercicio";
                paramUpdDescripcion_del_Ejercicio.DbType = DbType.String;
                paramUpdDescripcion_del_Ejercicio.Value = (object)entity.Descripcion_del_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_de_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_de_Ejercicio.ParameterName = "Tipo_de_Ejercicio";
                paramUpdTipo_de_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_de_Ejercicio.Value = (object)entity.Tipo_de_Ejercicio ?? DBNull.Value;
		var paramUpdNivel_de_dificultad = _dataProvider.GetParameter();
                paramUpdNivel_de_dificultad.ParameterName = "Nivel_de_dificultad";
                paramUpdNivel_de_dificultad.DbType = DbType.Int32;
                paramUpdNivel_de_dificultad.Value = (object)entity.Nivel_de_dificultad ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;
                var paramUpdMusculos_trabajados = _dataProvider.GetParameter();
                paramUpdMusculos_trabajados.ParameterName = "Musculos_trabajados";
                paramUpdMusculos_trabajados.DbType = DbType.Int32;
                paramUpdMusculos_trabajados.Value = (object)entity.Musculos_trabajados ?? DBNull.Value;
                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;
                var paramUpdVideo = _dataProvider.GetParameter();
                paramUpdVideo.ParameterName = "Video";
                paramUpdVideo.DbType = DbType.Int32;
                paramUpdVideo.Value = (object)entity.Video ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEjercicios>("sp_UpdEjercicios" , paramUpdClave , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_del_Ejercicio , paramUpdDescripcion_del_Ejercicio , paramUpdTipo_de_Ejercicio , paramUpdNivel_de_dificultad , paramUpdSexo , paramUpdMusculos_trabajados , paramUpdImagen , paramUpdVideo , paramUpdEstatus ).FirstOrDefault();

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


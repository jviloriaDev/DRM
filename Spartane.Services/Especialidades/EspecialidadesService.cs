using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Especialidades;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Especialidades
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EspecialidadesService : IEspecialidadesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Especialidades.Especialidades> _EspecialidadesRepository;
        #endregion

        #region Ctor
        public EspecialidadesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Especialidades.Especialidades> EspecialidadesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EspecialidadesRepository = EspecialidadesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._EspecialidadesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Especialidades.Especialidades> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Especialidades.Especialidades>("sp_SelAllEspecialidades");
        }

        public IList<Core.Classes.Especialidades.Especialidades> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEspecialidades_Complete>("sp_SelAllComplete_Especialidades");
            return data.Select(m => new Core.Classes.Especialidades.Especialidades
            {
                Clave = m.Clave
                ,Especialidad = m.Especialidad
                ,Profesion_Profesiones = new Core.Classes.Profesiones.Profesiones() { Clave = m.Profesion.GetValueOrDefault(), Descripcion = m.Profesion_Descripcion }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Imagen = m.Imagen


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Especialidades>("sp_ListSelCount_Especialidades", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Especialidades.Especialidades> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEspecialidades>("sp_ListSelAll_Especialidades", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Especialidades.Especialidades
                {
                    Clave = m.Especialidades_Clave,
                    Especialidad = m.Especialidades_Especialidad,
                    Profesion = m.Especialidades_Profesion,
                    Estatus = m.Especialidades_Estatus,
                    Imagen = m.Especialidades_Imagen,

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

        public IList<Spartane.Core.Classes.Especialidades.Especialidades> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EspecialidadesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Especialidades.Especialidades> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EspecialidadesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Especialidades.EspecialidadesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEspecialidades>("sp_ListSelAll_Especialidades", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            EspecialidadesPagingModel result = null;

            if (data != null)
            {
                result = new EspecialidadesPagingModel
                {
                    Especialidadess =
                        data.Select(m => new Spartane.Core.Classes.Especialidades.Especialidades
                {
                    Clave = m.Especialidades_Clave
                    ,Especialidad = m.Especialidades_Especialidad
                    ,Profesion = m.Especialidades_Profesion
                    ,Profesion_Profesiones = new Core.Classes.Profesiones.Profesiones() { Clave = m.Especialidades_Profesion.GetValueOrDefault(), Descripcion = m.Especialidades_Profesion_Descripcion }
                    ,Estatus = m.Especialidades_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Especialidades_Estatus.GetValueOrDefault(), Descripcion = m.Especialidades_Estatus_Descripcion }
                    ,Imagen = m.Especialidades_Imagen

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Especialidades.Especialidades> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EspecialidadesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Especialidades.Especialidades GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Especialidades.Especialidades>("sp_GetEspecialidades", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEspecialidades>("sp_DelEspecialidades", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Especialidades.Especialidades entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreEspecialidad = _dataProvider.GetParameter();
                padreEspecialidad.ParameterName = "Especialidad";
                padreEspecialidad.DbType = DbType.String;
                padreEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
                var padreProfesion = _dataProvider.GetParameter();
                padreProfesion.ParameterName = "Profesion";
                padreProfesion.DbType = DbType.Int32;
                padreProfesion.Value = (object)entity.Profesion ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreImagen = _dataProvider.GetParameter();
                padreImagen.ParameterName = "Imagen";
                padreImagen.DbType = DbType.Int32;
                padreImagen.Value = (object)entity.Imagen ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEspecialidades>("sp_InsEspecialidades" , padreEspecialidad
, padreProfesion
, padreEstatus
, padreImagen
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

        public int Update(Spartane.Core.Classes.Especialidades.Especialidades entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.String;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
                var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)entity.Profesion ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEspecialidades>("sp_UpdEspecialidades" , paramUpdClave , paramUpdEspecialidad , paramUpdProfesion , paramUpdEstatus , paramUpdImagen ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Especialidades.Especialidades entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Especialidades.Especialidades EspecialidadesDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.String;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
		var paramUpdProfesion = _dataProvider.GetParameter();
                paramUpdProfesion.ParameterName = "Profesion";
                paramUpdProfesion.DbType = DbType.Int32;
                paramUpdProfesion.Value = (object)entity.Profesion ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEspecialidades>("sp_UpdEspecialidades" , paramUpdClave , paramUpdEspecialidad , paramUpdProfesion , paramUpdEstatus , paramUpdImagen ).FirstOrDefault();

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


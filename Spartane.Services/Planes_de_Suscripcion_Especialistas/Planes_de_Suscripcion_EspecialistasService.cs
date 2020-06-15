using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Planes_de_Suscripcion_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Planes_de_Suscripcion_EspecialistasService : IPlanes_de_Suscripcion_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> _Planes_de_Suscripcion_EspecialistasRepository;
        #endregion

        #region Ctor
        public Planes_de_Suscripcion_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> Planes_de_Suscripcion_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Planes_de_Suscripcion_EspecialistasRepository = Planes_de_Suscripcion_EspecialistasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas>("sp_SelAllPlanes_de_Suscripcion_Especialistas");
        }

        public IList<Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPlanes_de_Suscripcion_Especialistas_Complete>("sp_SelAllComplete_Planes_de_Suscripcion_Especialistas");
            return data.Select(m => new Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas
            {
                Folio = m.Folio
                ,Nombre = m.Nombre
                ,Costo = m.Costo
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Planes_de_Suscripcion_Especialistas>("sp_ListSelCount_Planes_de_Suscripcion_Especialistas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlanes_de_Suscripcion_Especialistas>("sp_ListSelAll_Planes_de_Suscripcion_Especialistas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas
                {
                    Folio = m.Planes_de_Suscripcion_Especialistas_Folio,
                    Nombre = m.Planes_de_Suscripcion_Especialistas_Nombre,
                    Costo = m.Planes_de_Suscripcion_Especialistas_Costo,
                    Estatus = m.Planes_de_Suscripcion_Especialistas_Estatus,

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

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlanes_de_Suscripcion_Especialistas>("sp_ListSelAll_Planes_de_Suscripcion_Especialistas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Planes_de_Suscripcion_EspecialistasPagingModel result = null;

            if (data != null)
            {
                result = new Planes_de_Suscripcion_EspecialistasPagingModel
                {
                    Planes_de_Suscripcion_Especialistass =
                        data.Select(m => new Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas
                {
                    Folio = m.Planes_de_Suscripcion_Especialistas_Folio
                    ,Nombre = m.Planes_de_Suscripcion_Especialistas_Nombre
                    ,Costo = m.Planes_de_Suscripcion_Especialistas_Costo
                    ,Estatus = m.Planes_de_Suscripcion_Especialistas_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Planes_de_Suscripcion_Especialistas_Estatus.GetValueOrDefault(), Descripcion = m.Planes_de_Suscripcion_Especialistas_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas>("sp_GetPlanes_de_Suscripcion_Especialistas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPlanes_de_Suscripcion_Especialistas>("sp_DelPlanes_de_Suscripcion_Especialistas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreCosto = _dataProvider.GetParameter();
                padreCosto.ParameterName = "Costo";
                padreCosto.DbType = DbType.Int32;
                padreCosto.Value = (object)entity.Costo ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPlanes_de_Suscripcion_Especialistas>("sp_InsPlanes_de_Suscripcion_Especialistas" , padreNombre
, padreCosto
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

        public int Update(Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdCosto = _dataProvider.GetParameter();
                paramUpdCosto.ParameterName = "Costo";
                paramUpdCosto.DbType = DbType.Int32;
                paramUpdCosto.Value = (object)entity.Costo ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlanes_de_Suscripcion_Especialistas>("sp_UpdPlanes_de_Suscripcion_Especialistas" , paramUpdFolio , paramUpdNombre , paramUpdCosto , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas Planes_de_Suscripcion_EspecialistasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdCosto = _dataProvider.GetParameter();
                paramUpdCosto.ParameterName = "Costo";
                paramUpdCosto.DbType = DbType.Int32;
                paramUpdCosto.Value = (object)entity.Costo ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlanes_de_Suscripcion_Especialistas>("sp_UpdPlanes_de_Suscripcion_Especialistas" , paramUpdFolio , paramUpdNombre , paramUpdCosto , paramUpdEstatus ).FirstOrDefault();

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


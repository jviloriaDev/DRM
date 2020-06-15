using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Planes_de_Suscripcion_Proveedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Planes_de_Suscripcion_ProveedoresService : IPlanes_de_Suscripcion_ProveedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> _Planes_de_Suscripcion_ProveedoresRepository;
        #endregion

        #region Ctor
        public Planes_de_Suscripcion_ProveedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> Planes_de_Suscripcion_ProveedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Planes_de_Suscripcion_ProveedoresRepository = Planes_de_Suscripcion_ProveedoresRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>("sp_SelAllPlanes_de_Suscripcion_Proveedores");
        }

        public IList<Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPlanes_de_Suscripcion_Proveedores_Complete>("sp_SelAllComplete_Planes_de_Suscripcion_Proveedores");
            return data.Select(m => new Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Planes_de_Suscripcion_Proveedores>("sp_ListSelCount_Planes_de_Suscripcion_Proveedores", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlanes_de_Suscripcion_Proveedores>("sp_ListSelAll_Planes_de_Suscripcion_Proveedores", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores
                {
                    Clave = m.Planes_de_Suscripcion_Proveedores_Clave,
                    Descripcion = m.Planes_de_Suscripcion_Proveedores_Descripcion,

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

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlanes_de_Suscripcion_Proveedores>("sp_ListSelAll_Planes_de_Suscripcion_Proveedores", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Planes_de_Suscripcion_ProveedoresPagingModel result = null;

            if (data != null)
            {
                result = new Planes_de_Suscripcion_ProveedoresPagingModel
                {
                    Planes_de_Suscripcion_Proveedoress =
                        data.Select(m => new Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores
                {
                    Clave = m.Planes_de_Suscripcion_Proveedores_Clave
                    ,Descripcion = m.Planes_de_Suscripcion_Proveedores_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>("sp_GetPlanes_de_Suscripcion_Proveedores", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPlanes_de_Suscripcion_Proveedores>("sp_DelPlanes_de_Suscripcion_Proveedores", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPlanes_de_Suscripcion_Proveedores>("sp_InsPlanes_de_Suscripcion_Proveedores" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlanes_de_Suscripcion_Proveedores>("sp_UpdPlanes_de_Suscripcion_Proveedores" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores Planes_de_Suscripcion_ProveedoresDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlanes_de_Suscripcion_Proveedores>("sp_UpdPlanes_de_Suscripcion_Proveedores" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


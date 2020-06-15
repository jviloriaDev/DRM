using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_de_Ingredientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Ingredientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_IngredientesService : IDetalle_de_IngredientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> _Detalle_de_IngredientesRepository;
        #endregion

        #region Ctor
        public Detalle_de_IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> Detalle_de_IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_IngredientesRepository = Detalle_de_IngredientesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_de_IngredientesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes>("sp_SelAllDetalle_de_Ingredientes");
        }

        public IList<Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_de_Ingredientes_Complete>("sp_SelAllComplete_Detalle_de_Ingredientes");
            return data.Select(m => new Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes
            {
                Clave = m.Clave
                ,Cantidad = m.Cantidad
                ,Unidad_Unidades_de_Medida = new Core.Classes.Unidades_de_Medida.Unidades_de_Medida() { Clave = m.Unidad.GetValueOrDefault(), Unidad = m.Unidad_Unidad }
                ,Nombre_del_Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.Nombre_del_Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.Nombre_del_Ingrediente_Nombre_Ingrediente }
                ,Nombre_de_presentacion_Presentacion = new Core.Classes.Presentacion.Presentacion() { Clave = m.Nombre_de_presentacion.GetValueOrDefault(), Descripcion = m.Nombre_de_presentacion_Descripcion }
                ,Nombre_de_Marca_Marca = new Core.Classes.Marca.Marca() { Clave = m.Nombre_de_Marca.GetValueOrDefault(), Descripcion = m.Nombre_de_Marca_Descripcion }
                ,Platillos = m.Platillos


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_de_Ingredientes>("sp_ListSelCount_Detalle_de_Ingredientes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Ingredientes>("sp_ListSelAll_Detalle_de_Ingredientes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes
                {
                    Clave = m.Detalle_de_Ingredientes_Clave,
                    Cantidad = m.Detalle_de_Ingredientes_Cantidad,
                    Unidad = m.Detalle_de_Ingredientes_Unidad,
                    Nombre_del_Ingrediente = m.Detalle_de_Ingredientes_Nombre_del_Ingrediente,
                    Nombre_de_presentacion = m.Detalle_de_Ingredientes_Nombre_de_presentacion,
                    Nombre_de_Marca = m.Detalle_de_Ingredientes_Nombre_de_Marca,
                    Platillos = m.Detalle_de_Ingredientes_Platillos,

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

        public IList<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_IngredientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_de_Ingredientes>("sp_ListSelAll_Detalle_de_Ingredientes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_de_IngredientesPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_de_IngredientesPagingModel
                {
                    Detalle_de_Ingredientess =
                        data.Select(m => new Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes
                {
                    Clave = m.Detalle_de_Ingredientes_Clave
                    ,Cantidad = m.Detalle_de_Ingredientes_Cantidad
                    ,Unidad = m.Detalle_de_Ingredientes_Unidad
                    ,Unidad_Unidades_de_Medida = new Core.Classes.Unidades_de_Medida.Unidades_de_Medida() { Clave = m.Detalle_de_Ingredientes_Unidad.GetValueOrDefault(), Unidad = m.Detalle_de_Ingredientes_Unidad_Unidad }
                    ,Nombre_del_Ingrediente = m.Detalle_de_Ingredientes_Nombre_del_Ingrediente
                    ,Nombre_del_Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.Detalle_de_Ingredientes_Nombre_del_Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.Detalle_de_Ingredientes_Nombre_del_Ingrediente_Nombre_Ingrediente }
                    ,Nombre_de_presentacion = m.Detalle_de_Ingredientes_Nombre_de_presentacion
                    ,Nombre_de_presentacion_Presentacion = new Core.Classes.Presentacion.Presentacion() { Clave = m.Detalle_de_Ingredientes_Nombre_de_presentacion.GetValueOrDefault(), Descripcion = m.Detalle_de_Ingredientes_Nombre_de_presentacion_Descripcion }
                    ,Nombre_de_Marca = m.Detalle_de_Ingredientes_Nombre_de_Marca
                    ,Nombre_de_Marca_Marca = new Core.Classes.Marca.Marca() { Clave = m.Detalle_de_Ingredientes_Nombre_de_Marca.GetValueOrDefault(), Descripcion = m.Detalle_de_Ingredientes_Nombre_de_Marca_Descripcion }
                    ,Platillos = m.Detalle_de_Ingredientes_Platillos

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_IngredientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes>("sp_GetDetalle_de_Ingredientes", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_de_Ingredientes>("sp_DelDetalle_de_Ingredientes", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.String;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var padreUnidad = _dataProvider.GetParameter();
                padreUnidad.ParameterName = "Unidad";
                padreUnidad.DbType = DbType.Int32;
                padreUnidad.Value = (object)entity.Unidad ?? DBNull.Value;

                var padreNombre_del_Ingrediente = _dataProvider.GetParameter();
                padreNombre_del_Ingrediente.ParameterName = "Nombre_del_Ingrediente";
                padreNombre_del_Ingrediente.DbType = DbType.Int32;
                padreNombre_del_Ingrediente.Value = (object)entity.Nombre_del_Ingrediente ?? DBNull.Value;

                var padreNombre_de_presentacion = _dataProvider.GetParameter();
                padreNombre_de_presentacion.ParameterName = "Nombre_de_presentacion";
                padreNombre_de_presentacion.DbType = DbType.Int32;
                padreNombre_de_presentacion.Value = (object)entity.Nombre_de_presentacion ?? DBNull.Value;

                var padreNombre_de_Marca = _dataProvider.GetParameter();
                padreNombre_de_Marca.ParameterName = "Nombre_de_Marca";
                padreNombre_de_Marca.DbType = DbType.Int32;
                padreNombre_de_Marca.Value = (object)entity.Nombre_de_Marca ?? DBNull.Value;

                var padrePlatillos = _dataProvider.GetParameter();
                padrePlatillos.ParameterName = "Platillos";
                padrePlatillos.DbType = DbType.Int32;
                padrePlatillos.Value = (object)entity.Platillos ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_de_Ingredientes>("sp_InsDetalle_de_Ingredientes" , padreCantidad
, padreUnidad
, padreNombre_del_Ingrediente
, padreNombre_de_presentacion
, padreNombre_de_Marca
, padrePlatillos
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

        public int Update(Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.Int32;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;

                var paramUpdNombre_del_Ingrediente = _dataProvider.GetParameter();
                paramUpdNombre_del_Ingrediente.ParameterName = "Nombre_del_Ingrediente";
                paramUpdNombre_del_Ingrediente.DbType = DbType.Int32;
                paramUpdNombre_del_Ingrediente.Value = (object)entity.Nombre_del_Ingrediente ?? DBNull.Value;

                var paramUpdNombre_de_presentacion = _dataProvider.GetParameter();
                paramUpdNombre_de_presentacion.ParameterName = "Nombre_de_presentacion";
                paramUpdNombre_de_presentacion.DbType = DbType.Int32;
                paramUpdNombre_de_presentacion.Value = (object)entity.Nombre_de_presentacion ?? DBNull.Value;

                var paramUpdNombre_de_Marca = _dataProvider.GetParameter();
                paramUpdNombre_de_Marca.ParameterName = "Nombre_de_Marca";
                paramUpdNombre_de_Marca.DbType = DbType.Int32;
                paramUpdNombre_de_Marca.Value = (object)entity.Nombre_de_Marca ?? DBNull.Value;

                var paramUpdPlatillos = _dataProvider.GetParameter();
                paramUpdPlatillos.ParameterName = "Platillos";
                paramUpdPlatillos.DbType = DbType.Int32;
                paramUpdPlatillos.Value = (object)entity.Platillos ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Ingredientes>("sp_UpdDetalle_de_Ingredientes" , paramUpdClave , paramUpdCantidad , paramUpdUnidad , paramUpdNombre_del_Ingrediente , paramUpdNombre_de_presentacion , paramUpdNombre_de_Marca , paramUpdPlatillos ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes Detalle_de_IngredientesDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
		var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.Int32;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
		var paramUpdNombre_del_Ingrediente = _dataProvider.GetParameter();
                paramUpdNombre_del_Ingrediente.ParameterName = "Nombre_del_Ingrediente";
                paramUpdNombre_del_Ingrediente.DbType = DbType.Int32;
                paramUpdNombre_del_Ingrediente.Value = (object)entity.Nombre_del_Ingrediente ?? DBNull.Value;
		var paramUpdNombre_de_presentacion = _dataProvider.GetParameter();
                paramUpdNombre_de_presentacion.ParameterName = "Nombre_de_presentacion";
                paramUpdNombre_de_presentacion.DbType = DbType.Int32;
                paramUpdNombre_de_presentacion.Value = (object)entity.Nombre_de_presentacion ?? DBNull.Value;
		var paramUpdNombre_de_Marca = _dataProvider.GetParameter();
                paramUpdNombre_de_Marca.ParameterName = "Nombre_de_Marca";
                paramUpdNombre_de_Marca.DbType = DbType.Int32;
                paramUpdNombre_de_Marca.Value = (object)entity.Nombre_de_Marca ?? DBNull.Value;
                var paramUpdPlatillos = _dataProvider.GetParameter();
                paramUpdPlatillos.ParameterName = "Platillos";
                paramUpdPlatillos.DbType = DbType.Int32;
                paramUpdPlatillos.Value = (object)entity.Platillos ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_de_Ingredientes>("sp_UpdDetalle_de_Ingredientes" , paramUpdClave , paramUpdCantidad , paramUpdUnidad , paramUpdNombre_del_Ingrediente , paramUpdNombre_de_presentacion , paramUpdNombre_de_Marca , paramUpdPlatillos ).FirstOrDefault();

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


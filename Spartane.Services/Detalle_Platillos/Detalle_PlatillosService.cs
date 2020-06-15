using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_PlatillosService : IDetalle_PlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> _Detalle_PlatillosRepository;
        #endregion

        #region Ctor
        public Detalle_PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> Detalle_PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_PlatillosRepository = Detalle_PlatillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_PlatillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos>("sp_SelAllDetalle_Platillos");
        }

        public IList<Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Platillos_Complete>("sp_SelAllComplete_Detalle_Platillos");
            return data.Select(m => new Core.Classes.Detalle_Platillos.Detalle_Platillos
            {
                Folio = m.Folio
                ,Folio_Platillos = m.Folio_Platillos
                ,Lleva_fracciones = m.Lleva_fracciones.GetValueOrDefault()
                ,Cantidad = m.Cantidad
                ,Cantidad_fraccion_Cantidad_fraccion_platillos = new Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos() { Folio = m.Cantidad_fraccion.GetValueOrDefault(), Cantidad = m.Cantidad_fraccion_Cantidad }
                ,Unidad = m.Unidad
                ,Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.Ingrediente_Nombre_Ingrediente }
                ,Caracteristica = m.Caracteristica
                ,Unidad_SMAE = m.Unidad_SMAE
                ,Equivalente_Unidad_SMAE = m.Equivalente_Unidad_SMAE
                ,Porciones = m.Porciones
                ,Detalle = m.Detalle
                ,Detalle_Super = m.Detalle_Super


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Platillos>("sp_ListSelCount_Detalle_Platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Platillos>("sp_ListSelAll_Detalle_Platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos
                {
                    Folio = m.Detalle_Platillos_Folio,
                    Folio_Platillos = m.Detalle_Platillos_Folio_Platillos,
                    Lleva_fracciones = m.Detalle_Platillos_Lleva_fracciones ?? false,
                    Cantidad = m.Detalle_Platillos_Cantidad,
                    Cantidad_fraccion = m.Detalle_Platillos_Cantidad_fraccion,
                    Unidad = m.Detalle_Platillos_Unidad,
                    Ingrediente = m.Detalle_Platillos_Ingrediente,
                    Caracteristica = m.Detalle_Platillos_Caracteristica,
                    Unidad_SMAE = m.Detalle_Platillos_Unidad_SMAE,
                    Equivalente_Unidad_SMAE = m.Detalle_Platillos_Equivalente_Unidad_SMAE,
                    Porciones = m.Detalle_Platillos_Porciones,
                    Detalle = m.Detalle_Platillos_Detalle,
                    Detalle_Super = m.Detalle_Platillos_Detalle_Super,

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

        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Platillos.Detalle_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Platillos>("sp_ListSelAll_Detalle_Platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_PlatillosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_PlatillosPagingModel
                {
                    Detalle_Platilloss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos
                {
                    Folio = m.Detalle_Platillos_Folio
                    ,Folio_Platillos = m.Detalle_Platillos_Folio_Platillos
                    ,Lleva_fracciones = m.Detalle_Platillos_Lleva_fracciones ?? false
                    ,Cantidad = m.Detalle_Platillos_Cantidad
                    ,Cantidad_fraccion = m.Detalle_Platillos_Cantidad_fraccion
                    ,Cantidad_fraccion_Cantidad_fraccion_platillos = new Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos() { Folio = m.Detalle_Platillos_Cantidad_fraccion.GetValueOrDefault(), Cantidad = m.Detalle_Platillos_Cantidad_fraccion_Cantidad }
                    ,Unidad = m.Detalle_Platillos_Unidad
                    ,Ingrediente = m.Detalle_Platillos_Ingrediente
                    ,Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.Detalle_Platillos_Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.Detalle_Platillos_Ingrediente_Nombre_Ingrediente }
                    ,Caracteristica = m.Detalle_Platillos_Caracteristica
                    ,Unidad_SMAE = m.Detalle_Platillos_Unidad_SMAE
                    ,Equivalente_Unidad_SMAE = m.Detalle_Platillos_Equivalente_Unidad_SMAE
                    ,Porciones = m.Detalle_Platillos_Porciones
                    ,Detalle = m.Detalle_Platillos_Detalle
                    ,Detalle_Super = m.Detalle_Platillos_Detalle_Super

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos>("sp_GetDetalle_Platillos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Platillos>("sp_DelDetalle_Platillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Platillos = _dataProvider.GetParameter();
                padreFolio_Platillos.ParameterName = "Folio_Platillos";
                padreFolio_Platillos.DbType = DbType.Int32;
                padreFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
                var padreLleva_fracciones = _dataProvider.GetParameter();
                padreLleva_fracciones.ParameterName = "Lleva_fracciones";
                padreLleva_fracciones.DbType = DbType.Boolean;
                padreLleva_fracciones.Value = (object)entity.Lleva_fracciones ?? DBNull.Value;
                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.Int32;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;

                var padreCantidad_fraccion = _dataProvider.GetParameter();
                padreCantidad_fraccion.ParameterName = "Cantidad_fraccion";
                padreCantidad_fraccion.DbType = DbType.Int32;
                padreCantidad_fraccion.Value = (object)entity.Cantidad_fraccion ?? DBNull.Value;

                var padreUnidad = _dataProvider.GetParameter();
                padreUnidad.ParameterName = "Unidad";
                padreUnidad.DbType = DbType.Int32;
                padreUnidad.Value = (object)entity.Unidad ?? DBNull.Value;

                var padreIngrediente = _dataProvider.GetParameter();
                padreIngrediente.ParameterName = "Ingrediente";
                padreIngrediente.DbType = DbType.Int32;
                padreIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;

                var padreCaracteristica = _dataProvider.GetParameter();
                padreCaracteristica.ParameterName = "Caracteristica";
                padreCaracteristica.DbType = DbType.String;
                padreCaracteristica.Value = (object)entity.Caracteristica ?? DBNull.Value;
                var padreUnidad_SMAE = _dataProvider.GetParameter();
                padreUnidad_SMAE.ParameterName = "Unidad_SMAE";
                padreUnidad_SMAE.DbType = DbType.Int32;
                padreUnidad_SMAE.Value = (object)entity.Unidad_SMAE ?? DBNull.Value;

                var padreEquivalente_Unidad_SMAE = _dataProvider.GetParameter();
                padreEquivalente_Unidad_SMAE.ParameterName = "Equivalente_Unidad_SMAE";
                padreEquivalente_Unidad_SMAE.DbType = DbType.Int32;
                padreEquivalente_Unidad_SMAE.Value = (object)entity.Equivalente_Unidad_SMAE ?? DBNull.Value;

                var padrePorciones = _dataProvider.GetParameter();
                padrePorciones.ParameterName = "Porciones";
                padrePorciones.DbType = DbType.Int32;
                padrePorciones.Value = (object)entity.Porciones ?? DBNull.Value;

                var padreDetalle = _dataProvider.GetParameter();
                padreDetalle.ParameterName = "Detalle";
                padreDetalle.DbType = DbType.String;
                padreDetalle.Value = (object)entity.Detalle ?? DBNull.Value;
                var padreDetalle_Super = _dataProvider.GetParameter();
                padreDetalle_Super.ParameterName = "Detalle_Super";
                padreDetalle_Super.DbType = DbType.String;
                padreDetalle_Super.Value = (object)entity.Detalle_Super ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Platillos>("sp_InsDetalle_Platillos" , padreFolio_Platillos
, padreLleva_fracciones
, padreCantidad
, padreCantidad_fraccion
, padreUnidad
, padreIngrediente
, padreCaracteristica
, padreUnidad_SMAE
, padreEquivalente_Unidad_SMAE
, padrePorciones
, padreDetalle
, padreDetalle_Super
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

        public int Update(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
                var paramUpdLleva_fracciones = _dataProvider.GetParameter();
                paramUpdLleva_fracciones.ParameterName = "Lleva_fracciones";
                paramUpdLleva_fracciones.DbType = DbType.Boolean;
                paramUpdLleva_fracciones.Value = (object)entity.Lleva_fracciones ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;

                var paramUpdCantidad_fraccion = _dataProvider.GetParameter();
                paramUpdCantidad_fraccion.ParameterName = "Cantidad_fraccion";
                paramUpdCantidad_fraccion.DbType = DbType.Int32;
                paramUpdCantidad_fraccion.Value = (object)entity.Cantidad_fraccion ?? DBNull.Value;

                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.Int32;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;

                var paramUpdIngrediente = _dataProvider.GetParameter();
                paramUpdIngrediente.ParameterName = "Ingrediente";
                paramUpdIngrediente.DbType = DbType.Int32;
                paramUpdIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;

                var paramUpdCaracteristica = _dataProvider.GetParameter();
                paramUpdCaracteristica.ParameterName = "Caracteristica";
                paramUpdCaracteristica.DbType = DbType.String;
                paramUpdCaracteristica.Value = (object)entity.Caracteristica ?? DBNull.Value;
                var paramUpdUnidad_SMAE = _dataProvider.GetParameter();
                paramUpdUnidad_SMAE.ParameterName = "Unidad_SMAE";
                paramUpdUnidad_SMAE.DbType = DbType.Int32;
                paramUpdUnidad_SMAE.Value = (object)entity.Unidad_SMAE ?? DBNull.Value;

                var paramUpdEquivalente_Unidad_SMAE = _dataProvider.GetParameter();
                paramUpdEquivalente_Unidad_SMAE.ParameterName = "Equivalente_Unidad_SMAE";
                paramUpdEquivalente_Unidad_SMAE.DbType = DbType.Int32;
                paramUpdEquivalente_Unidad_SMAE.Value = (object)entity.Equivalente_Unidad_SMAE ?? DBNull.Value;

                var paramUpdPorciones = _dataProvider.GetParameter();
                paramUpdPorciones.ParameterName = "Porciones";
                paramUpdPorciones.DbType = DbType.Int32;
                paramUpdPorciones.Value = (object)entity.Porciones ?? DBNull.Value;

                var paramUpdDetalle = _dataProvider.GetParameter();
                paramUpdDetalle.ParameterName = "Detalle";
                paramUpdDetalle.DbType = DbType.String;
                paramUpdDetalle.Value = (object)entity.Detalle ?? DBNull.Value;
                var paramUpdDetalle_Super = _dataProvider.GetParameter();
                paramUpdDetalle_Super.ParameterName = "Detalle_Super";
                paramUpdDetalle_Super.DbType = DbType.String;
                paramUpdDetalle_Super.Value = (object)entity.Detalle_Super ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Platillos>("sp_UpdDetalle_Platillos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdLleva_fracciones , paramUpdCantidad , paramUpdCantidad_fraccion , paramUpdUnidad , paramUpdIngrediente , paramUpdCaracteristica , paramUpdUnidad_SMAE , paramUpdEquivalente_Unidad_SMAE , paramUpdPorciones , paramUpdDetalle , paramUpdDetalle_Super ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos Detalle_PlatillosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
                var paramUpdLleva_fracciones = _dataProvider.GetParameter();
                paramUpdLleva_fracciones.ParameterName = "Lleva_fracciones";
                paramUpdLleva_fracciones.DbType = DbType.Boolean;
                paramUpdLleva_fracciones.Value = (object)entity.Lleva_fracciones ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var paramUpdCantidad_fraccion = _dataProvider.GetParameter();
                paramUpdCantidad_fraccion.ParameterName = "Cantidad_fraccion";
                paramUpdCantidad_fraccion.DbType = DbType.Int32;
                paramUpdCantidad_fraccion.Value = (object)entity.Cantidad_fraccion ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.Int32;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
		var paramUpdIngrediente = _dataProvider.GetParameter();
                paramUpdIngrediente.ParameterName = "Ingrediente";
                paramUpdIngrediente.DbType = DbType.Int32;
                paramUpdIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;
                var paramUpdCaracteristica = _dataProvider.GetParameter();
                paramUpdCaracteristica.ParameterName = "Caracteristica";
                paramUpdCaracteristica.DbType = DbType.String;
                paramUpdCaracteristica.Value = (object)entity.Caracteristica ?? DBNull.Value;
                var paramUpdUnidad_SMAE = _dataProvider.GetParameter();
                paramUpdUnidad_SMAE.ParameterName = "Unidad_SMAE";
                paramUpdUnidad_SMAE.DbType = DbType.Int32;
                paramUpdUnidad_SMAE.Value = (object)entity.Unidad_SMAE ?? DBNull.Value;
                var paramUpdEquivalente_Unidad_SMAE = _dataProvider.GetParameter();
                paramUpdEquivalente_Unidad_SMAE.ParameterName = "Equivalente_Unidad_SMAE";
                paramUpdEquivalente_Unidad_SMAE.DbType = DbType.Int32;
                paramUpdEquivalente_Unidad_SMAE.Value = (object)entity.Equivalente_Unidad_SMAE ?? DBNull.Value;
                var paramUpdPorciones = _dataProvider.GetParameter();
                paramUpdPorciones.ParameterName = "Porciones";
                paramUpdPorciones.DbType = DbType.Int32;
                paramUpdPorciones.Value = (object)entity.Porciones ?? DBNull.Value;
                var paramUpdDetalle = _dataProvider.GetParameter();
                paramUpdDetalle.ParameterName = "Detalle";
                paramUpdDetalle.DbType = DbType.String;
                paramUpdDetalle.Value = (object)entity.Detalle ?? DBNull.Value;
                var paramUpdDetalle_Super = _dataProvider.GetParameter();
                paramUpdDetalle_Super.ParameterName = "Detalle_Super";
                paramUpdDetalle_Super.DbType = DbType.String;
                paramUpdDetalle_Super.Value = (object)entity.Detalle_Super ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Platillos>("sp_UpdDetalle_Platillos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdLleva_fracciones , paramUpdCantidad , paramUpdCantidad_fraccion , paramUpdUnidad , paramUpdIngrediente , paramUpdCaracteristica , paramUpdUnidad_SMAE , paramUpdEquivalente_Unidad_SMAE , paramUpdPorciones , paramUpdDetalle , paramUpdDetalle_Super ).FirstOrDefault();

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


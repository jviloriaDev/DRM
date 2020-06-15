using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Ingredientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Ingredientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class IngredientesService : IIngredientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Ingredientes.Ingredientes> _IngredientesRepository;
        #endregion

        #region Ctor
        public IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Ingredientes.Ingredientes> IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._IngredientesRepository = IngredientesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._IngredientesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Ingredientes.Ingredientes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Ingredientes.Ingredientes>("sp_SelAllIngredientes");
        }

        public IList<Core.Classes.Ingredientes.Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallIngredientes_Complete>("sp_SelAllComplete_Ingredientes");
            return data.Select(m => new Core.Classes.Ingredientes.Ingredientes
            {
                Clave = m.Clave
                ,Nombre_Ingrediente = m.Nombre_Ingrediente
                ,Clasificacion_Clasificacion_Ingredientes = new Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes() { Clave = m.Clasificacion.GetValueOrDefault(), Descripcion = m.Clasificacion_Descripcion }
                ,Imagen = m.Imagen
                ,Subgrupo = m.Subgrupo
                ,Cantidad_sugerida = m.Cantidad_sugerida
                ,Unidad = m.Unidad
                ,Peso_bruto_redondeado_g = m.Peso_bruto_redondeado_g
                ,Peso_neto_g = m.Peso_neto_g
                ,Nombre_sistema_anterior = m.Nombre_sistema_anterior


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Ingredientes>("sp_ListSelCount_Ingredientes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Ingredientes.Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllIngredientes>("sp_ListSelAll_Ingredientes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Ingredientes.Ingredientes
                {
                    Clave = m.Ingredientes_Clave,
                    Nombre_Ingrediente = m.Ingredientes_Nombre_Ingrediente,
                    Clasificacion = m.Ingredientes_Clasificacion,
                    Imagen = m.Ingredientes_Imagen,
                    Subgrupo = m.Ingredientes_Subgrupo,
                    Cantidad_sugerida = m.Ingredientes_Cantidad_sugerida,
                    Unidad = m.Ingredientes_Unidad,
                    Peso_bruto_redondeado_g = m.Ingredientes_Peso_bruto_redondeado_g,
                    Peso_neto_g = m.Ingredientes_Peso_neto_g,
                    Nombre_sistema_anterior = m.Ingredientes_Nombre_sistema_anterior,

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

        public IList<Spartane.Core.Classes.Ingredientes.Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Ingredientes.Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._IngredientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Ingredientes.IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllIngredientes>("sp_ListSelAll_Ingredientes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            IngredientesPagingModel result = null;

            if (data != null)
            {
                result = new IngredientesPagingModel
                {
                    Ingredientess =
                        data.Select(m => new Spartane.Core.Classes.Ingredientes.Ingredientes
                {
                    Clave = m.Ingredientes_Clave
                    ,Nombre_Ingrediente = m.Ingredientes_Nombre_Ingrediente
                    ,Clasificacion = m.Ingredientes_Clasificacion
                    ,Clasificacion_Clasificacion_Ingredientes = new Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes() { Clave = m.Ingredientes_Clasificacion.GetValueOrDefault(), Descripcion = m.Ingredientes_Clasificacion_Descripcion }
                    ,Imagen = m.Ingredientes_Imagen
                    ,Subgrupo = m.Ingredientes_Subgrupo
                    ,Cantidad_sugerida = m.Ingredientes_Cantidad_sugerida
                    ,Unidad = m.Ingredientes_Unidad
                    ,Peso_bruto_redondeado_g = m.Ingredientes_Peso_bruto_redondeado_g
                    ,Peso_neto_g = m.Ingredientes_Peso_neto_g
                    ,Nombre_sistema_anterior = m.Ingredientes_Nombre_sistema_anterior

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Ingredientes.Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._IngredientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Ingredientes.Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Ingredientes.Ingredientes>("sp_GetIngredientes", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelIngredientes>("sp_DelIngredientes", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Ingredientes.Ingredientes entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreNombre_Ingrediente = _dataProvider.GetParameter();
                padreNombre_Ingrediente.ParameterName = "Nombre_Ingrediente";
                padreNombre_Ingrediente.DbType = DbType.String;
                padreNombre_Ingrediente.Value = (object)entity.Nombre_Ingrediente ?? DBNull.Value;
                var padreClasificacion = _dataProvider.GetParameter();
                padreClasificacion.ParameterName = "Clasificacion";
                padreClasificacion.DbType = DbType.Int32;
                padreClasificacion.Value = (object)entity.Clasificacion ?? DBNull.Value;

                var padreImagen = _dataProvider.GetParameter();
                padreImagen.ParameterName = "Imagen";
                padreImagen.DbType = DbType.Int32;
                padreImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var padreSubgrupo = _dataProvider.GetParameter();
                padreSubgrupo.ParameterName = "Subgrupo";
                padreSubgrupo.DbType = DbType.String;
                padreSubgrupo.Value = (object)entity.Subgrupo ?? DBNull.Value;
                var padreCantidad_sugerida = _dataProvider.GetParameter();
                padreCantidad_sugerida.ParameterName = "Cantidad_sugerida";
                padreCantidad_sugerida.DbType = DbType.Decimal;
                padreCantidad_sugerida.Value = (object)entity.Cantidad_sugerida ?? DBNull.Value;

                var padreUnidad = _dataProvider.GetParameter();
                padreUnidad.ParameterName = "Unidad";
                padreUnidad.DbType = DbType.String;
                padreUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var padrePeso_bruto_redondeado_g = _dataProvider.GetParameter();
                padrePeso_bruto_redondeado_g.ParameterName = "Peso_bruto_redondeado_g";
                padrePeso_bruto_redondeado_g.DbType = DbType.Decimal;
                padrePeso_bruto_redondeado_g.Value = (object)entity.Peso_bruto_redondeado_g ?? DBNull.Value;

                var padrePeso_neto_g = _dataProvider.GetParameter();
                padrePeso_neto_g.ParameterName = "Peso_neto_g";
                padrePeso_neto_g.DbType = DbType.Decimal;
                padrePeso_neto_g.Value = (object)entity.Peso_neto_g ?? DBNull.Value;

                var padreNombre_sistema_anterior = _dataProvider.GetParameter();
                padreNombre_sistema_anterior.ParameterName = "Nombre_sistema_anterior";
                padreNombre_sistema_anterior.DbType = DbType.String;
                padreNombre_sistema_anterior.Value = (object)entity.Nombre_sistema_anterior ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsIngredientes>("sp_InsIngredientes" , padreNombre_Ingrediente
, padreClasificacion
, padreImagen
, padreSubgrupo
, padreCantidad_sugerida
, padreUnidad
, padrePeso_bruto_redondeado_g
, padrePeso_neto_g
, padreNombre_sistema_anterior
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

        public int Update(Spartane.Core.Classes.Ingredientes.Ingredientes entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_Ingrediente = _dataProvider.GetParameter();
                paramUpdNombre_Ingrediente.ParameterName = "Nombre_Ingrediente";
                paramUpdNombre_Ingrediente.DbType = DbType.String;
                paramUpdNombre_Ingrediente.Value = (object)entity.Nombre_Ingrediente ?? DBNull.Value;
                var paramUpdClasificacion = _dataProvider.GetParameter();
                paramUpdClasificacion.ParameterName = "Clasificacion";
                paramUpdClasificacion.DbType = DbType.Int32;
                paramUpdClasificacion.Value = (object)entity.Clasificacion ?? DBNull.Value;

                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;

                var paramUpdSubgrupo = _dataProvider.GetParameter();
                paramUpdSubgrupo.ParameterName = "Subgrupo";
                paramUpdSubgrupo.DbType = DbType.String;
                paramUpdSubgrupo.Value = (object)entity.Subgrupo ?? DBNull.Value;
                var paramUpdCantidad_sugerida = _dataProvider.GetParameter();
                paramUpdCantidad_sugerida.ParameterName = "Cantidad_sugerida";
                paramUpdCantidad_sugerida.DbType = DbType.Decimal;
                paramUpdCantidad_sugerida.Value = (object)entity.Cantidad_sugerida ?? DBNull.Value;

                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.String;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdPeso_bruto_redondeado_g = _dataProvider.GetParameter();
                paramUpdPeso_bruto_redondeado_g.ParameterName = "Peso_bruto_redondeado_g";
                paramUpdPeso_bruto_redondeado_g.DbType = DbType.Decimal;
                paramUpdPeso_bruto_redondeado_g.Value = (object)entity.Peso_bruto_redondeado_g ?? DBNull.Value;

                var paramUpdPeso_neto_g = _dataProvider.GetParameter();
                paramUpdPeso_neto_g.ParameterName = "Peso_neto_g";
                paramUpdPeso_neto_g.DbType = DbType.Decimal;
                paramUpdPeso_neto_g.Value = (object)entity.Peso_neto_g ?? DBNull.Value;

                var paramUpdNombre_sistema_anterior = _dataProvider.GetParameter();
                paramUpdNombre_sistema_anterior.ParameterName = "Nombre_sistema_anterior";
                paramUpdNombre_sistema_anterior.DbType = DbType.String;
                paramUpdNombre_sistema_anterior.Value = (object)entity.Nombre_sistema_anterior ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdIngredientes>("sp_UpdIngredientes" , paramUpdClave , paramUpdNombre_Ingrediente , paramUpdClasificacion , paramUpdImagen , paramUpdSubgrupo , paramUpdCantidad_sugerida , paramUpdUnidad , paramUpdPeso_bruto_redondeado_g , paramUpdPeso_neto_g , paramUpdNombre_sistema_anterior ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Ingredientes.Ingredientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Ingredientes.Ingredientes IngredientesDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_Ingrediente = _dataProvider.GetParameter();
                paramUpdNombre_Ingrediente.ParameterName = "Nombre_Ingrediente";
                paramUpdNombre_Ingrediente.DbType = DbType.String;
                paramUpdNombre_Ingrediente.Value = (object)entity.Nombre_Ingrediente ?? DBNull.Value;
                var paramUpdClasificacion = _dataProvider.GetParameter();
                paramUpdClasificacion.ParameterName = "Clasificacion";
                paramUpdClasificacion.DbType = DbType.Int32;
                paramUpdClasificacion.Value = (object)entity.Clasificacion ?? DBNull.Value;
                var paramUpdImagen = _dataProvider.GetParameter();
                paramUpdImagen.ParameterName = "Imagen";
                paramUpdImagen.DbType = DbType.Int32;
                paramUpdImagen.Value = (object)entity.Imagen ?? DBNull.Value;
                var paramUpdSubgrupo = _dataProvider.GetParameter();
                paramUpdSubgrupo.ParameterName = "Subgrupo";
                paramUpdSubgrupo.DbType = DbType.String;
                paramUpdSubgrupo.Value = (object)entity.Subgrupo ?? DBNull.Value;
                var paramUpdCantidad_sugerida = _dataProvider.GetParameter();
                paramUpdCantidad_sugerida.ParameterName = "Cantidad_sugerida";
                paramUpdCantidad_sugerida.DbType = DbType.Decimal;
                paramUpdCantidad_sugerida.Value = (object)entity.Cantidad_sugerida ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.String;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdPeso_bruto_redondeado_g = _dataProvider.GetParameter();
                paramUpdPeso_bruto_redondeado_g.ParameterName = "Peso_bruto_redondeado_g";
                paramUpdPeso_bruto_redondeado_g.DbType = DbType.Decimal;
                paramUpdPeso_bruto_redondeado_g.Value = (object)entity.Peso_bruto_redondeado_g ?? DBNull.Value;
                var paramUpdPeso_neto_g = _dataProvider.GetParameter();
                paramUpdPeso_neto_g.ParameterName = "Peso_neto_g";
                paramUpdPeso_neto_g.DbType = DbType.Decimal;
                paramUpdPeso_neto_g.Value = (object)entity.Peso_neto_g ?? DBNull.Value;
                var paramUpdNombre_sistema_anterior = _dataProvider.GetParameter();
                paramUpdNombre_sistema_anterior.ParameterName = "Nombre_sistema_anterior";
                paramUpdNombre_sistema_anterior.DbType = DbType.String;
                paramUpdNombre_sistema_anterior.Value = (object)entity.Nombre_sistema_anterior ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdIngredientes>("sp_UpdIngredientes" , paramUpdClave , paramUpdNombre_Ingrediente , paramUpdClasificacion , paramUpdImagen , paramUpdSubgrupo , paramUpdCantidad_sugerida , paramUpdUnidad , paramUpdPeso_bruto_redondeado_g , paramUpdPeso_neto_g , paramUpdNombre_sistema_anterior ).FirstOrDefault();

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


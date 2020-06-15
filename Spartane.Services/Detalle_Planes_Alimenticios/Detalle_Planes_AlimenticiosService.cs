using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Planes_Alimenticios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Planes_Alimenticios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Planes_AlimenticiosService : IDetalle_Planes_AlimenticiosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> _Detalle_Planes_AlimenticiosRepository;
        #endregion

        #region Ctor
        public Detalle_Planes_AlimenticiosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> Detalle_Planes_AlimenticiosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Planes_AlimenticiosRepository = Detalle_Planes_AlimenticiosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Planes_AlimenticiosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios>("sp_SelAllDetalle_Planes_Alimenticios");
        }

        public IList<Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Planes_Alimenticios_Complete>("sp_SelAllComplete_Detalle_Planes_Alimenticios");
            return data.Select(m => new Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios
            {
                Folio = m.Folio
                ,Folio_Planes_Alimenticios = m.Folio_Planes_Alimenticios
                ,Tiempo_de_Comida_Tiempos_de_Comida = new Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida() { Clave = m.Tiempo_de_Comida.GetValueOrDefault(), Comida = m.Tiempo_de_Comida_Comida }
                ,Numero_de_Dia_Dias_de_la_semana = new Core.Classes.Dias_de_la_semana.Dias_de_la_semana() { Clave = m.Numero_de_Dia.GetValueOrDefault(), Dia = m.Numero_de_Dia_Dia }
                ,Fecha = m.Fecha
                ,Platillo_Platillos = new Core.Classes.Platillos.Platillos() { Folio = m.Platillo.GetValueOrDefault(), Nombre_de_Platillo = m.Platillo_Nombre_de_Platillo }
                ,Modificado = m.Modificado.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Planes_Alimenticios>("sp_ListSelCount_Detalle_Planes_Alimenticios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Planes_Alimenticios>("sp_ListSelAll_Detalle_Planes_Alimenticios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios
                {
                    Folio = m.Detalle_Planes_Alimenticios_Folio,
                    Folio_Planes_Alimenticios = m.Detalle_Planes_Alimenticios_Folio_Planes_Alimenticios,
                    Tiempo_de_Comida = m.Detalle_Planes_Alimenticios_Tiempo_de_Comida,
                    Numero_de_Dia = m.Detalle_Planes_Alimenticios_Numero_de_Dia,
                    Fecha = m.Detalle_Planes_Alimenticios_Fecha,
                    Platillo = m.Detalle_Planes_Alimenticios_Platillo,
                    Modificado = m.Detalle_Planes_Alimenticios_Modificado ?? false,

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

        public IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Planes_AlimenticiosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Planes_AlimenticiosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_AlimenticiosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Planes_Alimenticios>("sp_ListSelAll_Detalle_Planes_Alimenticios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Planes_AlimenticiosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Planes_AlimenticiosPagingModel
                {
                    Detalle_Planes_Alimenticioss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios
                {
                    Folio = m.Detalle_Planes_Alimenticios_Folio
                    ,Folio_Planes_Alimenticios = m.Detalle_Planes_Alimenticios_Folio_Planes_Alimenticios
                    ,Tiempo_de_Comida = m.Detalle_Planes_Alimenticios_Tiempo_de_Comida
                    ,Tiempo_de_Comida_Tiempos_de_Comida = new Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida() { Clave = m.Detalle_Planes_Alimenticios_Tiempo_de_Comida.GetValueOrDefault(), Comida = m.Detalle_Planes_Alimenticios_Tiempo_de_Comida_Comida }
                    ,Numero_de_Dia = m.Detalle_Planes_Alimenticios_Numero_de_Dia
                    ,Numero_de_Dia_Dias_de_la_semana = new Core.Classes.Dias_de_la_semana.Dias_de_la_semana() { Clave = m.Detalle_Planes_Alimenticios_Numero_de_Dia.GetValueOrDefault(), Dia = m.Detalle_Planes_Alimenticios_Numero_de_Dia_Dia }
                    ,Fecha = m.Detalle_Planes_Alimenticios_Fecha
                    ,Platillo = m.Detalle_Planes_Alimenticios_Platillo
                    ,Platillo_Platillos = new Core.Classes.Platillos.Platillos() { Folio = m.Detalle_Planes_Alimenticios_Platillo.GetValueOrDefault(), Nombre_de_Platillo = m.Detalle_Planes_Alimenticios_Platillo_Nombre_de_Platillo }
                    ,Modificado = m.Detalle_Planes_Alimenticios_Modificado ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Planes_AlimenticiosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios>("sp_GetDetalle_Planes_Alimenticios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Planes_Alimenticios>("sp_DelDetalle_Planes_Alimenticios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Planes_Alimenticios = _dataProvider.GetParameter();
                padreFolio_Planes_Alimenticios.ParameterName = "Folio_Planes_Alimenticios";
                padreFolio_Planes_Alimenticios.DbType = DbType.Int32;
                padreFolio_Planes_Alimenticios.Value = (object)entity.Folio_Planes_Alimenticios ?? DBNull.Value;
                var padreTiempo_de_Comida = _dataProvider.GetParameter();
                padreTiempo_de_Comida.ParameterName = "Tiempo_de_Comida";
                padreTiempo_de_Comida.DbType = DbType.Int32;
                padreTiempo_de_Comida.Value = (object)entity.Tiempo_de_Comida ?? DBNull.Value;

                var padreNumero_de_Dia = _dataProvider.GetParameter();
                padreNumero_de_Dia.ParameterName = "Numero_de_Dia";
                padreNumero_de_Dia.DbType = DbType.Int32;
                padreNumero_de_Dia.Value = (object)entity.Numero_de_Dia ?? DBNull.Value;

                var padreFecha = _dataProvider.GetParameter();
                padreFecha.ParameterName = "Fecha";
                padreFecha.DbType = DbType.DateTime;
                padreFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var padrePlatillo = _dataProvider.GetParameter();
                padrePlatillo.ParameterName = "Platillo";
                padrePlatillo.DbType = DbType.Int32;
                padrePlatillo.Value = (object)entity.Platillo ?? DBNull.Value;

                var padreModificado = _dataProvider.GetParameter();
                padreModificado.ParameterName = "Modificado";
                padreModificado.DbType = DbType.Boolean;
                padreModificado.Value = (object)entity.Modificado ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Planes_Alimenticios>("sp_InsDetalle_Planes_Alimenticios" , padreFolio_Planes_Alimenticios
, padreTiempo_de_Comida
, padreNumero_de_Dia
, padreFecha
, padrePlatillo
, padreModificado
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

        public int Update(Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Planes_Alimenticios = _dataProvider.GetParameter();
                paramUpdFolio_Planes_Alimenticios.ParameterName = "Folio_Planes_Alimenticios";
                paramUpdFolio_Planes_Alimenticios.DbType = DbType.Int32;
                paramUpdFolio_Planes_Alimenticios.Value = (object)entity.Folio_Planes_Alimenticios ?? DBNull.Value;
                var paramUpdTiempo_de_Comida = _dataProvider.GetParameter();
                paramUpdTiempo_de_Comida.ParameterName = "Tiempo_de_Comida";
                paramUpdTiempo_de_Comida.DbType = DbType.Int32;
                paramUpdTiempo_de_Comida.Value = (object)entity.Tiempo_de_Comida ?? DBNull.Value;

                var paramUpdNumero_de_Dia = _dataProvider.GetParameter();
                paramUpdNumero_de_Dia.ParameterName = "Numero_de_Dia";
                paramUpdNumero_de_Dia.DbType = DbType.Int32;
                paramUpdNumero_de_Dia.Value = (object)entity.Numero_de_Dia ?? DBNull.Value;

                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var paramUpdPlatillo = _dataProvider.GetParameter();
                paramUpdPlatillo.ParameterName = "Platillo";
                paramUpdPlatillo.DbType = DbType.Int32;
                paramUpdPlatillo.Value = (object)entity.Platillo ?? DBNull.Value;

                var paramUpdModificado = _dataProvider.GetParameter();
                paramUpdModificado.ParameterName = "Modificado";
                paramUpdModificado.DbType = DbType.Boolean;
                paramUpdModificado.Value = (object)entity.Modificado ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Planes_Alimenticios>("sp_UpdDetalle_Planes_Alimenticios" , paramUpdFolio , paramUpdFolio_Planes_Alimenticios , paramUpdTiempo_de_Comida , paramUpdNumero_de_Dia , paramUpdFecha , paramUpdPlatillo , paramUpdModificado ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios Detalle_Planes_AlimenticiosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Planes_Alimenticios = _dataProvider.GetParameter();
                paramUpdFolio_Planes_Alimenticios.ParameterName = "Folio_Planes_Alimenticios";
                paramUpdFolio_Planes_Alimenticios.DbType = DbType.Int32;
                paramUpdFolio_Planes_Alimenticios.Value = (object)entity.Folio_Planes_Alimenticios ?? DBNull.Value;
		var paramUpdTiempo_de_Comida = _dataProvider.GetParameter();
                paramUpdTiempo_de_Comida.ParameterName = "Tiempo_de_Comida";
                paramUpdTiempo_de_Comida.DbType = DbType.Int32;
                paramUpdTiempo_de_Comida.Value = (object)entity.Tiempo_de_Comida ?? DBNull.Value;
		var paramUpdNumero_de_Dia = _dataProvider.GetParameter();
                paramUpdNumero_de_Dia.ParameterName = "Numero_de_Dia";
                paramUpdNumero_de_Dia.DbType = DbType.Int32;
                paramUpdNumero_de_Dia.Value = (object)entity.Numero_de_Dia ?? DBNull.Value;
                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;
		var paramUpdPlatillo = _dataProvider.GetParameter();
                paramUpdPlatillo.ParameterName = "Platillo";
                paramUpdPlatillo.DbType = DbType.Int32;
                paramUpdPlatillo.Value = (object)entity.Platillo ?? DBNull.Value;
                var paramUpdModificado = _dataProvider.GetParameter();
                paramUpdModificado.ParameterName = "Modificado";
                paramUpdModificado.DbType = DbType.Boolean;
                paramUpdModificado.Value = (object)entity.Modificado ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Planes_Alimenticios>("sp_UpdDetalle_Planes_Alimenticios" , paramUpdFolio , paramUpdFolio_Planes_Alimenticios , paramUpdTiempo_de_Comida , paramUpdNumero_de_Dia , paramUpdFecha , paramUpdPlatillo , paramUpdModificado ).FirstOrDefault();

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


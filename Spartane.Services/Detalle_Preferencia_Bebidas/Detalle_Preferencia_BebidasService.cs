using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Preferencia_Bebidas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Preferencia_Bebidas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Preferencia_BebidasService : IDetalle_Preferencia_BebidasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> _Detalle_Preferencia_BebidasRepository;
        #endregion

        #region Ctor
        public Detalle_Preferencia_BebidasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> Detalle_Preferencia_BebidasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Preferencia_BebidasRepository = Detalle_Preferencia_BebidasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas>("sp_SelAllDetalle_Preferencia_Bebidas");
        }

        public IList<Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Preferencia_Bebidas_Complete>("sp_SelAllComplete_Detalle_Preferencia_Bebidas");
            return data.Select(m => new Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Bebida_Bebidas = new Core.Classes.Bebidas.Bebidas() { Clave = m.Bebida.GetValueOrDefault(), Descripcion = m.Bebida_Descripcion }
                ,Cantidad_Rango_Consumo_Bebidas = new Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas() { Clave = m.Cantidad.GetValueOrDefault(), Descripcion = m.Cantidad_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Preferencia_Bebidas>("sp_ListSelCount_Detalle_Preferencia_Bebidas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Preferencia_Bebidas>("sp_ListSelAll_Detalle_Preferencia_Bebidas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas
                {
                    Folio = m.Detalle_Preferencia_Bebidas_Folio,
                    Folio_Pacientes = m.Detalle_Preferencia_Bebidas_Folio_Pacientes,
                    Bebida = m.Detalle_Preferencia_Bebidas_Bebida,
                    Cantidad = m.Detalle_Preferencia_Bebidas_Cantidad,

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

        public IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Preferencia_Bebidas>("sp_ListSelAll_Detalle_Preferencia_Bebidas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Preferencia_BebidasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Preferencia_BebidasPagingModel
                {
                    Detalle_Preferencia_Bebidass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas
                {
                    Folio = m.Detalle_Preferencia_Bebidas_Folio
                    ,Folio_Pacientes = m.Detalle_Preferencia_Bebidas_Folio_Pacientes
                    ,Bebida = m.Detalle_Preferencia_Bebidas_Bebida
                    ,Bebida_Bebidas = new Core.Classes.Bebidas.Bebidas() { Clave = m.Detalle_Preferencia_Bebidas_Bebida.GetValueOrDefault(), Descripcion = m.Detalle_Preferencia_Bebidas_Bebida_Descripcion }
                    ,Cantidad = m.Detalle_Preferencia_Bebidas_Cantidad
                    ,Cantidad_Rango_Consumo_Bebidas = new Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas() { Clave = m.Detalle_Preferencia_Bebidas_Cantidad.GetValueOrDefault(), Descripcion = m.Detalle_Preferencia_Bebidas_Cantidad_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas>("sp_GetDetalle_Preferencia_Bebidas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Preferencia_Bebidas>("sp_DelDetalle_Preferencia_Bebidas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Pacientes = _dataProvider.GetParameter();
                padreFolio_Pacientes.ParameterName = "Folio_Pacientes";
                padreFolio_Pacientes.DbType = DbType.Int32;
                padreFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var padreBebida = _dataProvider.GetParameter();
                padreBebida.ParameterName = "Bebida";
                padreBebida.DbType = DbType.Int32;
                padreBebida.Value = (object)entity.Bebida ?? DBNull.Value;

                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.Int32;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Preferencia_Bebidas>("sp_InsDetalle_Preferencia_Bebidas" , padreFolio_Pacientes
, padreBebida
, padreCantidad
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

        public int Update(Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var paramUpdBebida = _dataProvider.GetParameter();
                paramUpdBebida.ParameterName = "Bebida";
                paramUpdBebida.DbType = DbType.Int32;
                paramUpdBebida.Value = (object)entity.Bebida ?? DBNull.Value;

                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Preferencia_Bebidas>("sp_UpdDetalle_Preferencia_Bebidas" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdBebida , paramUpdCantidad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas Detalle_Preferencia_BebidasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
		var paramUpdBebida = _dataProvider.GetParameter();
                paramUpdBebida.ParameterName = "Bebida";
                paramUpdBebida.DbType = DbType.Int32;
                paramUpdBebida.Value = (object)entity.Bebida ?? DBNull.Value;
		var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Preferencia_Bebidas>("sp_UpdDetalle_Preferencia_Bebidas" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdBebida , paramUpdCantidad ).FirstOrDefault();

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


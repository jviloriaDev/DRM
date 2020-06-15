using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Unidades_de_Medida;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Unidades_de_Medida
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Unidades_de_MedidaService : IUnidades_de_MedidaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> _Unidades_de_MedidaRepository;
        #endregion

        #region Ctor
        public Unidades_de_MedidaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> Unidades_de_MedidaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Unidades_de_MedidaRepository = Unidades_de_MedidaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Unidades_de_MedidaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida>("sp_SelAllUnidades_de_Medida");
        }

        public IList<Core.Classes.Unidades_de_Medida.Unidades_de_Medida> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallUnidades_de_Medida_Complete>("sp_SelAllComplete_Unidades_de_Medida");
            return data.Select(m => new Core.Classes.Unidades_de_Medida.Unidades_de_Medida
            {
                Clave = m.Clave
                ,Unidad = m.Unidad
                ,Abreviacion = m.Abreviacion
                ,Texto_Singular = m.Texto_Singular
                ,Texto_Plural = m.Texto_Plural


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Unidades_de_Medida>("sp_ListSelCount_Unidades_de_Medida", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllUnidades_de_Medida>("sp_ListSelAll_Unidades_de_Medida", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida
                {
                    Clave = m.Unidades_de_Medida_Clave,
                    Unidad = m.Unidades_de_Medida_Unidad,
                    Abreviacion = m.Unidades_de_Medida_Abreviacion,
                    Texto_Singular = m.Unidades_de_Medida_Texto_Singular,
                    Texto_Plural = m.Unidades_de_Medida_Texto_Plural,

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

        public IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Unidades_de_MedidaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Unidades_de_MedidaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_MedidaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllUnidades_de_Medida>("sp_ListSelAll_Unidades_de_Medida", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Unidades_de_MedidaPagingModel result = null;

            if (data != null)
            {
                result = new Unidades_de_MedidaPagingModel
                {
                    Unidades_de_Medidas =
                        data.Select(m => new Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida
                {
                    Clave = m.Unidades_de_Medida_Clave
                    ,Unidad = m.Unidades_de_Medida_Unidad
                    ,Abreviacion = m.Unidades_de_Medida_Abreviacion
                    ,Texto_Singular = m.Unidades_de_Medida_Texto_Singular
                    ,Texto_Plural = m.Unidades_de_Medida_Texto_Plural

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Unidades_de_MedidaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida>("sp_GetUnidades_de_Medida", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelUnidades_de_Medida>("sp_DelUnidades_de_Medida", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreUnidad = _dataProvider.GetParameter();
                padreUnidad.ParameterName = "Unidad";
                padreUnidad.DbType = DbType.String;
                padreUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var padreAbreviacion = _dataProvider.GetParameter();
                padreAbreviacion.ParameterName = "Abreviacion";
                padreAbreviacion.DbType = DbType.String;
                padreAbreviacion.Value = (object)entity.Abreviacion ?? DBNull.Value;
                var padreTexto_Singular = _dataProvider.GetParameter();
                padreTexto_Singular.ParameterName = "Texto_Singular";
                padreTexto_Singular.DbType = DbType.String;
                padreTexto_Singular.Value = (object)entity.Texto_Singular ?? DBNull.Value;
                var padreTexto_Plural = _dataProvider.GetParameter();
                padreTexto_Plural.ParameterName = "Texto_Plural";
                padreTexto_Plural.DbType = DbType.String;
                padreTexto_Plural.Value = (object)entity.Texto_Plural ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsUnidades_de_Medida>("sp_InsUnidades_de_Medida" , padreUnidad
, padreAbreviacion
, padreTexto_Singular
, padreTexto_Plural
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

        public int Update(Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.String;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdAbreviacion = _dataProvider.GetParameter();
                paramUpdAbreviacion.ParameterName = "Abreviacion";
                paramUpdAbreviacion.DbType = DbType.String;
                paramUpdAbreviacion.Value = (object)entity.Abreviacion ?? DBNull.Value;
                var paramUpdTexto_Singular = _dataProvider.GetParameter();
                paramUpdTexto_Singular.ParameterName = "Texto_Singular";
                paramUpdTexto_Singular.DbType = DbType.String;
                paramUpdTexto_Singular.Value = (object)entity.Texto_Singular ?? DBNull.Value;
                var paramUpdTexto_Plural = _dataProvider.GetParameter();
                paramUpdTexto_Plural.ParameterName = "Texto_Plural";
                paramUpdTexto_Plural.DbType = DbType.String;
                paramUpdTexto_Plural.Value = (object)entity.Texto_Plural ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdUnidades_de_Medida>("sp_UpdUnidades_de_Medida" , paramUpdClave , paramUpdUnidad , paramUpdAbreviacion , paramUpdTexto_Singular , paramUpdTexto_Plural ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida Unidades_de_MedidaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.String;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdAbreviacion = _dataProvider.GetParameter();
                paramUpdAbreviacion.ParameterName = "Abreviacion";
                paramUpdAbreviacion.DbType = DbType.String;
                paramUpdAbreviacion.Value = (object)entity.Abreviacion ?? DBNull.Value;
                var paramUpdTexto_Singular = _dataProvider.GetParameter();
                paramUpdTexto_Singular.ParameterName = "Texto_Singular";
                paramUpdTexto_Singular.DbType = DbType.String;
                paramUpdTexto_Singular.Value = (object)entity.Texto_Singular ?? DBNull.Value;
                var paramUpdTexto_Plural = _dataProvider.GetParameter();
                paramUpdTexto_Plural.ParameterName = "Texto_Plural";
                paramUpdTexto_Plural.DbType = DbType.String;
                paramUpdTexto_Plural.Value = (object)entity.Texto_Plural ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdUnidades_de_Medida>("sp_UpdUnidades_de_Medida" , paramUpdClave , paramUpdUnidad , paramUpdAbreviacion , paramUpdTexto_Singular , paramUpdTexto_Plural ).FirstOrDefault();

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


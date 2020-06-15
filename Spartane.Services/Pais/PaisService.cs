using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Pais;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Pais
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class PaisService : IPaisService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Pais.Pais> _PaisRepository;
        #endregion

        #region Ctor
        public PaisService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Pais.Pais> PaisRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._PaisRepository = PaisRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._PaisRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Pais.Pais> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Pais.Pais>("sp_SelAllPais");
        }

        public IList<Core.Classes.Pais.Pais> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPais_Complete>("sp_SelAllComplete_Pais");
            return data.Select(m => new Core.Classes.Pais.Pais
            {
                Clave = m.Clave
                ,Nombre_del_Pais = m.Nombre_del_Pais
                ,Abreviatura = m.Abreviatura
                ,Codigo = m.Codigo


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Pais>("sp_ListSelCount_Pais", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Pais.Pais> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPais>("sp_ListSelAll_Pais", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Pais.Pais
                {
                    Clave = m.Pais_Clave,
                    Nombre_del_Pais = m.Pais_Nombre_del_Pais,
                    Abreviatura = m.Pais_Abreviatura,
                    Codigo = m.Pais_Codigo,

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

        public IList<Spartane.Core.Classes.Pais.Pais> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._PaisRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Pais.Pais> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PaisRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Pais.PaisPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPais>("sp_ListSelAll_Pais", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            PaisPagingModel result = null;

            if (data != null)
            {
                result = new PaisPagingModel
                {
                    Paiss =
                        data.Select(m => new Spartane.Core.Classes.Pais.Pais
                {
                    Clave = m.Pais_Clave
                    ,Nombre_del_Pais = m.Pais_Nombre_del_Pais
                    ,Abreviatura = m.Pais_Abreviatura
                    ,Codigo = m.Pais_Codigo

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Pais.Pais> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._PaisRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Pais.Pais GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Pais.Pais>("sp_GetPais", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPais>("sp_DelPais", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Pais.Pais entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreNombre_del_Pais = _dataProvider.GetParameter();
                padreNombre_del_Pais.ParameterName = "Nombre_del_Pais";
                padreNombre_del_Pais.DbType = DbType.String;
                padreNombre_del_Pais.Value = (object)entity.Nombre_del_Pais ?? DBNull.Value;
                var padreAbreviatura = _dataProvider.GetParameter();
                padreAbreviatura.ParameterName = "Abreviatura";
                padreAbreviatura.DbType = DbType.String;
                padreAbreviatura.Value = (object)entity.Abreviatura ?? DBNull.Value;
                var padreCodigo = _dataProvider.GetParameter();
                padreCodigo.ParameterName = "Codigo";
                padreCodigo.DbType = DbType.String;
                padreCodigo.Value = (object)entity.Codigo ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPais>("sp_InsPais" , padreNombre_del_Pais
, padreAbreviatura
, padreCodigo
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

        public int Update(Spartane.Core.Classes.Pais.Pais entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_del_Pais = _dataProvider.GetParameter();
                paramUpdNombre_del_Pais.ParameterName = "Nombre_del_Pais";
                paramUpdNombre_del_Pais.DbType = DbType.String;
                paramUpdNombre_del_Pais.Value = (object)entity.Nombre_del_Pais ?? DBNull.Value;
                var paramUpdAbreviatura = _dataProvider.GetParameter();
                paramUpdAbreviatura.ParameterName = "Abreviatura";
                paramUpdAbreviatura.DbType = DbType.String;
                paramUpdAbreviatura.Value = (object)entity.Abreviatura ?? DBNull.Value;
                var paramUpdCodigo = _dataProvider.GetParameter();
                paramUpdCodigo.ParameterName = "Codigo";
                paramUpdCodigo.DbType = DbType.String;
                paramUpdCodigo.Value = (object)entity.Codigo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPais>("sp_UpdPais" , paramUpdClave , paramUpdNombre_del_Pais , paramUpdAbreviatura , paramUpdCodigo ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Pais.Pais entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pais.Pais PaisDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_del_Pais = _dataProvider.GetParameter();
                paramUpdNombre_del_Pais.ParameterName = "Nombre_del_Pais";
                paramUpdNombre_del_Pais.DbType = DbType.String;
                paramUpdNombre_del_Pais.Value = (object)entity.Nombre_del_Pais ?? DBNull.Value;
                var paramUpdAbreviatura = _dataProvider.GetParameter();
                paramUpdAbreviatura.ParameterName = "Abreviatura";
                paramUpdAbreviatura.DbType = DbType.String;
                paramUpdAbreviatura.Value = (object)entity.Abreviatura ?? DBNull.Value;
                var paramUpdCodigo = _dataProvider.GetParameter();
                paramUpdCodigo.ParameterName = "Codigo";
                paramUpdCodigo.DbType = DbType.String;
                paramUpdCodigo.Value = (object)entity.Codigo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPais>("sp_UpdPais" , paramUpdClave , paramUpdNombre_del_Pais , paramUpdAbreviatura , paramUpdCodigo ).FirstOrDefault();

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


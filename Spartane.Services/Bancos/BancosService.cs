using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Bancos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Bancos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class BancosService : IBancosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Bancos.Bancos> _BancosRepository;
        #endregion

        #region Ctor
        public BancosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Bancos.Bancos> BancosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._BancosRepository = BancosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._BancosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Bancos.Bancos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Bancos.Bancos>("sp_SelAllBancos");
        }

        public IList<Core.Classes.Bancos.Bancos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallBancos_Complete>("sp_SelAllComplete_Bancos");
            return data.Select(m => new Core.Classes.Bancos.Bancos
            {
                Clave = m.Clave
                ,Nombre = m.Nombre
                ,Nombre_Completo = m.Nombre_Completo
                ,Codigo = m.Codigo


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Bancos>("sp_ListSelCount_Bancos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Bancos.Bancos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllBancos>("sp_ListSelAll_Bancos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Bancos.Bancos
                {
                    Clave = m.Bancos_Clave,
                    Nombre = m.Bancos_Nombre,
                    Nombre_Completo = m.Bancos_Nombre_Completo,
                    Codigo = m.Bancos_Codigo,

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

        public IList<Spartane.Core.Classes.Bancos.Bancos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._BancosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Bancos.Bancos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._BancosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Bancos.BancosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllBancos>("sp_ListSelAll_Bancos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            BancosPagingModel result = null;

            if (data != null)
            {
                result = new BancosPagingModel
                {
                    Bancoss =
                        data.Select(m => new Spartane.Core.Classes.Bancos.Bancos
                {
                    Clave = m.Bancos_Clave
                    ,Nombre = m.Bancos_Nombre
                    ,Nombre_Completo = m.Bancos_Nombre_Completo
                    ,Codigo = m.Bancos_Codigo

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Bancos.Bancos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._BancosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Bancos.Bancos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Bancos.Bancos>("sp_GetBancos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelBancos>("sp_DelBancos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Bancos.Bancos entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreCodigo = _dataProvider.GetParameter();
                padreCodigo.ParameterName = "Codigo";
                padreCodigo.DbType = DbType.String;
                padreCodigo.Value = (object)entity.Codigo ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsBancos>("sp_InsBancos" , padreNombre
, padreNombre_Completo
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

        public int Update(Spartane.Core.Classes.Bancos.Bancos entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdCodigo = _dataProvider.GetParameter();
                paramUpdCodigo.ParameterName = "Codigo";
                paramUpdCodigo.DbType = DbType.String;
                paramUpdCodigo.Value = (object)entity.Codigo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdBancos>("sp_UpdBancos" , paramUpdClave , paramUpdNombre , paramUpdNombre_Completo , paramUpdCodigo ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Bancos.Bancos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Bancos.Bancos BancosDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdCodigo = _dataProvider.GetParameter();
                paramUpdCodigo.ParameterName = "Codigo";
                paramUpdCodigo.DbType = DbType.String;
                paramUpdCodigo.Value = (object)entity.Codigo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdBancos>("sp_UpdBancos" , paramUpdClave , paramUpdNombre , paramUpdNombre_Completo , paramUpdCodigo ).FirstOrDefault();

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


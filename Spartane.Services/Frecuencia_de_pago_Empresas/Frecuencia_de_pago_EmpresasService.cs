using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Frecuencia_de_pago_Empresas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Frecuencia_de_pago_Empresas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Frecuencia_de_pago_EmpresasService : IFrecuencia_de_pago_EmpresasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> _Frecuencia_de_pago_EmpresasRepository;
        #endregion

        #region Ctor
        public Frecuencia_de_pago_EmpresasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> Frecuencia_de_pago_EmpresasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Frecuencia_de_pago_EmpresasRepository = Frecuencia_de_pago_EmpresasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>("sp_SelAllFrecuencia_de_pago_Empresas");
        }

        public IList<Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallFrecuencia_de_pago_Empresas_Complete>("sp_SelAllComplete_Frecuencia_de_pago_Empresas");
            return data.Select(m => new Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas
            {
                Clave = m.Clave
                ,Nombre = m.Nombre


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Frecuencia_de_pago_Empresas>("sp_ListSelCount_Frecuencia_de_pago_Empresas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFrecuencia_de_pago_Empresas>("sp_ListSelAll_Frecuencia_de_pago_Empresas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas
                {
                    Clave = m.Frecuencia_de_pago_Empresas_Clave,
                    Nombre = m.Frecuencia_de_pago_Empresas_Nombre,

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

        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFrecuencia_de_pago_Empresas>("sp_ListSelAll_Frecuencia_de_pago_Empresas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Frecuencia_de_pago_EmpresasPagingModel result = null;

            if (data != null)
            {
                result = new Frecuencia_de_pago_EmpresasPagingModel
                {
                    Frecuencia_de_pago_Empresass =
                        data.Select(m => new Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas
                {
                    Clave = m.Frecuencia_de_pago_Empresas_Clave
                    ,Nombre = m.Frecuencia_de_pago_Empresas_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>("sp_GetFrecuencia_de_pago_Empresas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelFrecuencia_de_pago_Empresas>("sp_DelFrecuencia_de_pago_Empresas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity)
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
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsFrecuencia_de_pago_Empresas>("sp_InsFrecuencia_de_pago_Empresas" , padreNombre
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

        public int Update(Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity)
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


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFrecuencia_de_pago_Empresas>("sp_UpdFrecuencia_de_pago_Empresas" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas Frecuencia_de_pago_EmpresasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFrecuencia_de_pago_Empresas>("sp_UpdFrecuencia_de_pago_Empresas" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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


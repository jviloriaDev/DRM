using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Preferencias_Sal;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Preferencias_Sal
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Preferencias_SalService : IPreferencias_SalService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> _Preferencias_SalRepository;
        #endregion

        #region Ctor
        public Preferencias_SalService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> Preferencias_SalRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Preferencias_SalRepository = Preferencias_SalRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Preferencias_SalRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal>("sp_SelAllPreferencias_Sal");
        }

        public IList<Core.Classes.Preferencias_Sal.Preferencias_Sal> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPreferencias_Sal_Complete>("sp_SelAllComplete_Preferencias_Sal");
            return data.Select(m => new Core.Classes.Preferencias_Sal.Preferencias_Sal
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Preferencias_Sal>("sp_ListSelCount_Preferencias_Sal", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPreferencias_Sal>("sp_ListSelAll_Preferencias_Sal", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal
                {
                    Clave = m.Preferencias_Sal_Clave,
                    Descripcion = m.Preferencias_Sal_Descripcion,

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

        public IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Preferencias_SalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_SalRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Preferencias_Sal.Preferencias_SalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPreferencias_Sal>("sp_ListSelAll_Preferencias_Sal", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Preferencias_SalPagingModel result = null;

            if (data != null)
            {
                result = new Preferencias_SalPagingModel
                {
                    Preferencias_Sals =
                        data.Select(m => new Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal
                {
                    Clave = m.Preferencias_Sal_Clave
                    ,Descripcion = m.Preferencias_Sal_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Preferencias_SalRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal>("sp_GetPreferencias_Sal", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPreferencias_Sal>("sp_DelPreferencias_Sal", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPreferencias_Sal>("sp_InsPreferencias_Sal" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPreferencias_Sal>("sp_UpdPreferencias_Sal" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal Preferencias_SalDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPreferencias_Sal>("sp_UpdPreferencias_Sal" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


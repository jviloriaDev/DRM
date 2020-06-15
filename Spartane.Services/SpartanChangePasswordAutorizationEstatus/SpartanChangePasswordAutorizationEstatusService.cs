using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.SpartanChangePasswordAutorizationEstatus
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class SpartanChangePasswordAutorizationEstatusService : ISpartanChangePasswordAutorizationEstatusService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> _SpartanChangePasswordAutorizationEstatusRepository;
        #endregion

        #region Ctor
        public SpartanChangePasswordAutorizationEstatusService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SpartanChangePasswordAutorizationEstatusRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._SpartanChangePasswordAutorizationEstatusRepository = SpartanChangePasswordAutorizationEstatusRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>("sp_SelAllSpartanChangePasswordAutorizationEstatus");
        }

        public IList<Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartanChangePasswordAutorizationEstatus_Complete>("sp_SelAllComplete_SpartanChangePasswordAutorizationEstatus");
            return data.Select(m => new Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_SpartanChangePasswordAutorizationEstatus>("sp_ListSelCount_SpartanChangePasswordAutorizationEstatus", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartanChangePasswordAutorizationEstatus>("sp_ListSelAll_SpartanChangePasswordAutorizationEstatus", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus
                {
                    Clave = m.SpartanChangePasswordAutorizationEstatus_Clave,
                    Descripcion = m.SpartanChangePasswordAutorizationEstatus_Descripcion,

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

        public IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartanChangePasswordAutorizationEstatus>("sp_ListSelAll_SpartanChangePasswordAutorizationEstatus", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            SpartanChangePasswordAutorizationEstatusPagingModel result = null;

            if (data != null)
            {
                result = new SpartanChangePasswordAutorizationEstatusPagingModel
                {
                    SpartanChangePasswordAutorizationEstatuss =
                        data.Select(m => new Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus
                {
                    Clave = m.SpartanChangePasswordAutorizationEstatus_Clave
                    ,Descripcion = m.SpartanChangePasswordAutorizationEstatus_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>("sp_GetSpartanChangePasswordAutorizationEstatus", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartanChangePasswordAutorizationEstatus>("sp_DelSpartanChangePasswordAutorizationEstatus", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity)
        {
            int rta;
            try
            {

		                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartanChangePasswordAutorizationEstatus>("sp_InsSpartanChangePasswordAutorizationEstatus" 
, padreDescripcion
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

        public int Update(Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartanChangePasswordAutorizationEstatus>("sp_UpdSpartanChangePasswordAutorizationEstatus" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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

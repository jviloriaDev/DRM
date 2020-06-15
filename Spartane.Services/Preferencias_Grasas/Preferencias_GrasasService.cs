using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Preferencias_Grasas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Preferencias_Grasas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Preferencias_GrasasService : IPreferencias_GrasasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> _Preferencias_GrasasRepository;
        #endregion

        #region Ctor
        public Preferencias_GrasasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> Preferencias_GrasasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Preferencias_GrasasRepository = Preferencias_GrasasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Preferencias_GrasasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas>("sp_SelAllPreferencias_Grasas");
        }

        public IList<Core.Classes.Preferencias_Grasas.Preferencias_Grasas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPreferencias_Grasas_Complete>("sp_SelAllComplete_Preferencias_Grasas");
            return data.Select(m => new Core.Classes.Preferencias_Grasas.Preferencias_Grasas
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Preferencias_Grasas>("sp_ListSelCount_Preferencias_Grasas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPreferencias_Grasas>("sp_ListSelAll_Preferencias_Grasas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas
                {
                    Clave = m.Preferencias_Grasas_Clave,
                    Descripcion = m.Preferencias_Grasas_Descripcion,

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

        public IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Preferencias_GrasasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_GrasasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Preferencias_Grasas.Preferencias_GrasasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPreferencias_Grasas>("sp_ListSelAll_Preferencias_Grasas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Preferencias_GrasasPagingModel result = null;

            if (data != null)
            {
                result = new Preferencias_GrasasPagingModel
                {
                    Preferencias_Grasass =
                        data.Select(m => new Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas
                {
                    Clave = m.Preferencias_Grasas_Clave
                    ,Descripcion = m.Preferencias_Grasas_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Preferencias_GrasasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas>("sp_GetPreferencias_Grasas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPreferencias_Grasas>("sp_DelPreferencias_Grasas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPreferencias_Grasas>("sp_InsPreferencias_Grasas" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPreferencias_Grasas>("sp_UpdPreferencias_Grasas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas Preferencias_GrasasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPreferencias_Grasas>("sp_UpdPreferencias_Grasas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


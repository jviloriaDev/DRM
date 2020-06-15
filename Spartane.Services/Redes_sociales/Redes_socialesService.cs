using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Redes_sociales;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Redes_sociales
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Redes_socialesService : IRedes_socialesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Redes_sociales.Redes_sociales> _Redes_socialesRepository;
        #endregion

        #region Ctor
        public Redes_socialesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Redes_sociales.Redes_sociales> Redes_socialesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Redes_socialesRepository = Redes_socialesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Redes_socialesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Redes_sociales.Redes_sociales>("sp_SelAllRedes_sociales");
        }

        public IList<Core.Classes.Redes_sociales.Redes_sociales> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRedes_sociales_Complete>("sp_SelAllComplete_Redes_sociales");
            return data.Select(m => new Core.Classes.Redes_sociales.Redes_sociales
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion
                ,Direccion_URL = m.Direccion_URL


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Redes_sociales>("sp_ListSelCount_Redes_sociales", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRedes_sociales>("sp_ListSelAll_Redes_sociales", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Redes_sociales.Redes_sociales
                {
                    Clave = m.Redes_sociales_Clave,
                    Descripcion = m.Redes_sociales_Descripcion,
                    Direccion_URL = m.Redes_sociales_Direccion_URL,

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

        public IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Redes_socialesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Redes_socialesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Redes_sociales.Redes_socialesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRedes_sociales>("sp_ListSelAll_Redes_sociales", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Redes_socialesPagingModel result = null;

            if (data != null)
            {
                result = new Redes_socialesPagingModel
                {
                    Redes_socialess =
                        data.Select(m => new Spartane.Core.Classes.Redes_sociales.Redes_sociales
                {
                    Clave = m.Redes_sociales_Clave
                    ,Descripcion = m.Redes_sociales_Descripcion
                    ,Direccion_URL = m.Redes_sociales_Direccion_URL

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Redes_socialesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Redes_sociales.Redes_sociales GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Redes_sociales.Redes_sociales>("sp_GetRedes_sociales", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRedes_sociales>("sp_DelRedes_sociales", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Redes_sociales.Redes_sociales entity)
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
                var padreDireccion_URL = _dataProvider.GetParameter();
                padreDireccion_URL.ParameterName = "Direccion_URL";
                padreDireccion_URL.DbType = DbType.String;
                padreDireccion_URL.Value = (object)entity.Direccion_URL ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRedes_sociales>("sp_InsRedes_sociales" , padreDescripcion
, padreDireccion_URL
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

        public int Update(Spartane.Core.Classes.Redes_sociales.Redes_sociales entity)
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
                var paramUpdDireccion_URL = _dataProvider.GetParameter();
                paramUpdDireccion_URL.ParameterName = "Direccion_URL";
                paramUpdDireccion_URL.DbType = DbType.String;
                paramUpdDireccion_URL.Value = (object)entity.Direccion_URL ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRedes_sociales>("sp_UpdRedes_sociales" , paramUpdClave , paramUpdDescripcion , paramUpdDireccion_URL ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Redes_sociales.Redes_sociales entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Redes_sociales.Redes_sociales Redes_socialesDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdDireccion_URL = _dataProvider.GetParameter();
                paramUpdDireccion_URL.ParameterName = "Direccion_URL";
                paramUpdDireccion_URL.DbType = DbType.String;
                paramUpdDireccion_URL.Value = (object)entity.Direccion_URL ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRedes_sociales>("sp_UpdRedes_sociales" , paramUpdClave , paramUpdDescripcion , paramUpdDireccion_URL ).FirstOrDefault();

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


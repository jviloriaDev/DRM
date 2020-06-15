using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Identificaciones_Oficiales;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Identificaciones_Oficiales
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Identificaciones_OficialesService : IIdentificaciones_OficialesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> _Identificaciones_OficialesRepository;
        #endregion

        #region Ctor
        public Identificaciones_OficialesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> Identificaciones_OficialesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Identificaciones_OficialesRepository = Identificaciones_OficialesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Identificaciones_OficialesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales>("sp_SelAllIdentificaciones_Oficiales");
        }

        public IList<Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallIdentificaciones_Oficiales_Complete>("sp_SelAllComplete_Identificaciones_Oficiales");
            return data.Select(m => new Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Identificaciones_Oficiales>("sp_ListSelCount_Identificaciones_Oficiales", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllIdentificaciones_Oficiales>("sp_ListSelAll_Identificaciones_Oficiales", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales
                {
                    Clave = m.Identificaciones_Oficiales_Clave,
                    Descripcion = m.Identificaciones_Oficiales_Descripcion,

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

        public IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Identificaciones_OficialesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Identificaciones_OficialesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_OficialesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllIdentificaciones_Oficiales>("sp_ListSelAll_Identificaciones_Oficiales", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Identificaciones_OficialesPagingModel result = null;

            if (data != null)
            {
                result = new Identificaciones_OficialesPagingModel
                {
                    Identificaciones_Oficialess =
                        data.Select(m => new Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales
                {
                    Clave = m.Identificaciones_Oficiales_Clave
                    ,Descripcion = m.Identificaciones_Oficiales_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Identificaciones_OficialesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales>("sp_GetIdentificaciones_Oficiales", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelIdentificaciones_Oficiales>("sp_DelIdentificaciones_Oficiales", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsIdentificaciones_Oficiales>("sp_InsIdentificaciones_Oficiales" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdIdentificaciones_Oficiales>("sp_UpdIdentificaciones_Oficiales" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales Identificaciones_OficialesDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdIdentificaciones_Oficiales>("sp_UpdIdentificaciones_Oficiales" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


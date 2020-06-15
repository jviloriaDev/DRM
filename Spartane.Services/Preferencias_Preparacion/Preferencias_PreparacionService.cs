using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Preferencias_Preparacion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Preferencias_Preparacion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Preferencias_PreparacionService : IPreferencias_PreparacionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> _Preferencias_PreparacionRepository;
        #endregion

        #region Ctor
        public Preferencias_PreparacionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> Preferencias_PreparacionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Preferencias_PreparacionRepository = Preferencias_PreparacionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Preferencias_PreparacionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion>("sp_SelAllPreferencias_Preparacion");
        }

        public IList<Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPreferencias_Preparacion_Complete>("sp_SelAllComplete_Preferencias_Preparacion");
            return data.Select(m => new Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Preferencias_Preparacion>("sp_ListSelCount_Preferencias_Preparacion", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPreferencias_Preparacion>("sp_ListSelAll_Preferencias_Preparacion", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion
                {
                    Clave = m.Preferencias_Preparacion_Clave,
                    Descripcion = m.Preferencias_Preparacion_Descripcion,

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

        public IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Preferencias_PreparacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_PreparacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_PreparacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPreferencias_Preparacion>("sp_ListSelAll_Preferencias_Preparacion", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Preferencias_PreparacionPagingModel result = null;

            if (data != null)
            {
                result = new Preferencias_PreparacionPagingModel
                {
                    Preferencias_Preparacions =
                        data.Select(m => new Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion
                {
                    Clave = m.Preferencias_Preparacion_Clave
                    ,Descripcion = m.Preferencias_Preparacion_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Preferencias_PreparacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion>("sp_GetPreferencias_Preparacion", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPreferencias_Preparacion>("sp_DelPreferencias_Preparacion", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPreferencias_Preparacion>("sp_InsPreferencias_Preparacion" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPreferencias_Preparacion>("sp_UpdPreferencias_Preparacion" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion Preferencias_PreparacionDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPreferencias_Preparacion>("sp_UpdPreferencias_Preparacion" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


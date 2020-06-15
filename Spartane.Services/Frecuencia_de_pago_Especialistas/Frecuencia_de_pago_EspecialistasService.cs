using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Frecuencia_de_pago_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Frecuencia_de_pago_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Frecuencia_de_pago_EspecialistasService : IFrecuencia_de_pago_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> _Frecuencia_de_pago_EspecialistasRepository;
        #endregion

        #region Ctor
        public Frecuencia_de_pago_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> Frecuencia_de_pago_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Frecuencia_de_pago_EspecialistasRepository = Frecuencia_de_pago_EspecialistasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Frecuencia_de_pago_EspecialistasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>("sp_SelAllFrecuencia_de_pago_Especialistas");
        }

        public IList<Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallFrecuencia_de_pago_Especialistas_Complete>("sp_SelAllComplete_Frecuencia_de_pago_Especialistas");
            return data.Select(m => new Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Frecuencia_de_pago_Especialistas>("sp_ListSelCount_Frecuencia_de_pago_Especialistas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFrecuencia_de_pago_Especialistas>("sp_ListSelAll_Frecuencia_de_pago_Especialistas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas
                {
                    Clave = m.Frecuencia_de_pago_Especialistas_Clave,
                    Nombre = m.Frecuencia_de_pago_Especialistas_Nombre,

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

        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Frecuencia_de_pago_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_de_pago_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFrecuencia_de_pago_Especialistas>("sp_ListSelAll_Frecuencia_de_pago_Especialistas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Frecuencia_de_pago_EspecialistasPagingModel result = null;

            if (data != null)
            {
                result = new Frecuencia_de_pago_EspecialistasPagingModel
                {
                    Frecuencia_de_pago_Especialistass =
                        data.Select(m => new Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas
                {
                    Clave = m.Frecuencia_de_pago_Especialistas_Clave
                    ,Nombre = m.Frecuencia_de_pago_Especialistas_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Frecuencia_de_pago_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>("sp_GetFrecuencia_de_pago_Especialistas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelFrecuencia_de_pago_Especialistas>("sp_DelFrecuencia_de_pago_Especialistas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsFrecuencia_de_pago_Especialistas>("sp_InsFrecuencia_de_pago_Especialistas" , padreNombre
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

        public int Update(Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFrecuencia_de_pago_Especialistas>("sp_UpdFrecuencia_de_pago_Especialistas" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas Frecuencia_de_pago_EspecialistasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFrecuencia_de_pago_Especialistas>("sp_UpdFrecuencia_de_pago_Especialistas" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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


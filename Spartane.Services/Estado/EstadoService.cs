using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estado;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estado
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EstadoService : IEstadoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estado.Estado> _EstadoRepository;
        #endregion

        #region Ctor
        public EstadoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estado.Estado> EstadoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EstadoRepository = EstadoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._EstadoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estado.Estado> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estado.Estado>("sp_SelAllEstado");
        }

        public IList<Core.Classes.Estado.Estado> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstado_Complete>("sp_SelAllComplete_Estado");
            return data.Select(m => new Core.Classes.Estado.Estado
            {
                Clave = m.Clave
                ,Nombre_del_Estado = m.Nombre_del_Estado
                ,Folio_Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Folio_Pais.GetValueOrDefault(), Nombre_del_Pais = m.Folio_Pais_Nombre_del_Pais }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estado>("sp_ListSelCount_Estado", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estado.Estado> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstado>("sp_ListSelAll_Estado", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estado.Estado
                {
                    Clave = m.Estado_Clave,
                    Nombre_del_Estado = m.Estado_Nombre_del_Estado,
                    Folio_Pais = m.Estado_Folio_Pais,

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

        public IList<Spartane.Core.Classes.Estado.Estado> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EstadoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estado.Estado> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EstadoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estado.EstadoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstado>("sp_ListSelAll_Estado", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            EstadoPagingModel result = null;

            if (data != null)
            {
                result = new EstadoPagingModel
                {
                    Estados =
                        data.Select(m => new Spartane.Core.Classes.Estado.Estado
                {
                    Clave = m.Estado_Clave
                    ,Nombre_del_Estado = m.Estado_Nombre_del_Estado
                    ,Folio_Pais = m.Estado_Folio_Pais
                    ,Folio_Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Estado_Folio_Pais.GetValueOrDefault(), Nombre_del_Pais = m.Estado_Folio_Pais_Nombre_del_Pais }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estado.Estado> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EstadoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estado.Estado GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estado.Estado>("sp_GetEstado", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstado>("sp_DelEstado", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estado.Estado entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreNombre_del_Estado = _dataProvider.GetParameter();
                padreNombre_del_Estado.ParameterName = "Nombre_del_Estado";
                padreNombre_del_Estado.DbType = DbType.String;
                padreNombre_del_Estado.Value = (object)entity.Nombre_del_Estado ?? DBNull.Value;
                var padreFolio_Pais = _dataProvider.GetParameter();
                padreFolio_Pais.ParameterName = "Folio_Pais";
                padreFolio_Pais.DbType = DbType.Int32;
                padreFolio_Pais.Value = (object)entity.Folio_Pais ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstado>("sp_InsEstado" , padreNombre_del_Estado
, padreFolio_Pais
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

        public int Update(Spartane.Core.Classes.Estado.Estado entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_del_Estado = _dataProvider.GetParameter();
                paramUpdNombre_del_Estado.ParameterName = "Nombre_del_Estado";
                paramUpdNombre_del_Estado.DbType = DbType.String;
                paramUpdNombre_del_Estado.Value = (object)entity.Nombre_del_Estado ?? DBNull.Value;
                var paramUpdFolio_Pais = _dataProvider.GetParameter();
                paramUpdFolio_Pais.ParameterName = "Folio_Pais";
                paramUpdFolio_Pais.DbType = DbType.Int32;
                paramUpdFolio_Pais.Value = (object)entity.Folio_Pais ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstado>("sp_UpdEstado" , paramUpdClave , paramUpdNombre_del_Estado , paramUpdFolio_Pais ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estado.Estado entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estado.Estado EstadoDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_del_Estado = _dataProvider.GetParameter();
                paramUpdNombre_del_Estado.ParameterName = "Nombre_del_Estado";
                paramUpdNombre_del_Estado.DbType = DbType.String;
                paramUpdNombre_del_Estado.Value = (object)entity.Nombre_del_Estado ?? DBNull.Value;
		var paramUpdFolio_Pais = _dataProvider.GetParameter();
                paramUpdFolio_Pais.ParameterName = "Folio_Pais";
                paramUpdFolio_Pais.DbType = DbType.Int32;
                paramUpdFolio_Pais.Value = (object)entity.Folio_Pais ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstado>("sp_UpdEstado" , paramUpdClave , paramUpdNombre_del_Estado , paramUpdFolio_Pais ).FirstOrDefault();

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


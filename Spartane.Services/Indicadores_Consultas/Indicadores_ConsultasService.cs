using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Indicadores_Consultas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Indicadores_Consultas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Indicadores_ConsultasService : IIndicadores_ConsultasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> _Indicadores_ConsultasRepository;
        #endregion

        #region Ctor
        public Indicadores_ConsultasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> Indicadores_ConsultasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Indicadores_ConsultasRepository = Indicadores_ConsultasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Indicadores_ConsultasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas>("sp_SelAllIndicadores_Consultas");
        }

        public IList<Core.Classes.Indicadores_Consultas.Indicadores_Consultas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallIndicadores_Consultas_Complete>("sp_SelAllComplete_Indicadores_Consultas");
            return data.Select(m => new Core.Classes.Indicadores_Consultas.Indicadores_Consultas
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Indicadores_Consultas>("sp_ListSelCount_Indicadores_Consultas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllIndicadores_Consultas>("sp_ListSelAll_Indicadores_Consultas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas
                {
                    Clave = m.Indicadores_Consultas_Clave,
                    Nombre = m.Indicadores_Consultas_Nombre,

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

        public IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Indicadores_ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Indicadores_ConsultasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Indicadores_Consultas.Indicadores_ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllIndicadores_Consultas>("sp_ListSelAll_Indicadores_Consultas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Indicadores_ConsultasPagingModel result = null;

            if (data != null)
            {
                result = new Indicadores_ConsultasPagingModel
                {
                    Indicadores_Consultass =
                        data.Select(m => new Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas
                {
                    Clave = m.Indicadores_Consultas_Clave
                    ,Nombre = m.Indicadores_Consultas_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Indicadores_ConsultasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas>("sp_GetIndicadores_Consultas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelIndicadores_Consultas>("sp_DelIndicadores_Consultas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsIndicadores_Consultas>("sp_InsIndicadores_Consultas" , padreNombre
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

        public int Update(Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdIndicadores_Consultas>("sp_UpdIndicadores_Consultas" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas Indicadores_ConsultasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdIndicadores_Consultas>("sp_UpdIndicadores_Consultas" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Periodo_del_dia;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Periodo_del_dia
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Periodo_del_diaService : IPeriodo_del_diaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> _Periodo_del_diaRepository;
        #endregion

        #region Ctor
        public Periodo_del_diaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> Periodo_del_diaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Periodo_del_diaRepository = Periodo_del_diaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Periodo_del_diaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia>("sp_SelAllPeriodo_del_dia");
        }

        public IList<Core.Classes.Periodo_del_dia.Periodo_del_dia> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPeriodo_del_dia_Complete>("sp_SelAllComplete_Periodo_del_dia");
            return data.Select(m => new Core.Classes.Periodo_del_dia.Periodo_del_dia
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Periodo_del_dia>("sp_ListSelCount_Periodo_del_dia", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPeriodo_del_dia>("sp_ListSelAll_Periodo_del_dia", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia
                {
                    Clave = m.Periodo_del_dia_Clave,
                    Descripcion = m.Periodo_del_dia_Descripcion,

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

        public IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Periodo_del_diaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Periodo_del_diaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Periodo_del_dia.Periodo_del_diaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPeriodo_del_dia>("sp_ListSelAll_Periodo_del_dia", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Periodo_del_diaPagingModel result = null;

            if (data != null)
            {
                result = new Periodo_del_diaPagingModel
                {
                    Periodo_del_dias =
                        data.Select(m => new Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia
                {
                    Clave = m.Periodo_del_dia_Clave
                    ,Descripcion = m.Periodo_del_dia_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Periodo_del_diaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia>("sp_GetPeriodo_del_dia", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPeriodo_del_dia>("sp_DelPeriodo_del_dia", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPeriodo_del_dia>("sp_InsPeriodo_del_dia" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPeriodo_del_dia>("sp_UpdPeriodo_del_dia" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia Periodo_del_diaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPeriodo_del_dia>("sp_UpdPeriodo_del_dia" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


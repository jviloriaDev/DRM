using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Dias_de_la_semana;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Dias_de_la_semana
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Dias_de_la_semanaService : IDias_de_la_semanaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> _Dias_de_la_semanaRepository;
        #endregion

        #region Ctor
        public Dias_de_la_semanaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> Dias_de_la_semanaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Dias_de_la_semanaRepository = Dias_de_la_semanaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Dias_de_la_semanaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana>("sp_SelAllDias_de_la_semana");
        }

        public IList<Core.Classes.Dias_de_la_semana.Dias_de_la_semana> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDias_de_la_semana_Complete>("sp_SelAllComplete_Dias_de_la_semana");
            return data.Select(m => new Core.Classes.Dias_de_la_semana.Dias_de_la_semana
            {
                Clave = m.Clave
                ,Texto = m.Texto
                ,Dia = m.Dia


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Dias_de_la_semana>("sp_ListSelCount_Dias_de_la_semana", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDias_de_la_semana>("sp_ListSelAll_Dias_de_la_semana", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana
                {
                    Clave = m.Dias_de_la_semana_Clave,
                    Texto = m.Dias_de_la_semana_Texto,
                    Dia = m.Dias_de_la_semana_Dia,

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

        public IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Dias_de_la_semanaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dias_de_la_semanaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semanaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDias_de_la_semana>("sp_ListSelAll_Dias_de_la_semana", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Dias_de_la_semanaPagingModel result = null;

            if (data != null)
            {
                result = new Dias_de_la_semanaPagingModel
                {
                    Dias_de_la_semanas =
                        data.Select(m => new Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana
                {
                    Clave = m.Dias_de_la_semana_Clave
                    ,Texto = m.Dias_de_la_semana_Texto
                    ,Dia = m.Dias_de_la_semana_Dia

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Dias_de_la_semanaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana>("sp_GetDias_de_la_semana", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDias_de_la_semana>("sp_DelDias_de_la_semana", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreTexto = _dataProvider.GetParameter();
                padreTexto.ParameterName = "Texto";
                padreTexto.DbType = DbType.String;
                padreTexto.Value = (object)entity.Texto ?? DBNull.Value;
                var padreDia = _dataProvider.GetParameter();
                padreDia.ParameterName = "Dia";
                padreDia.DbType = DbType.String;
                padreDia.Value = (object)entity.Dia ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDias_de_la_semana>("sp_InsDias_de_la_semana" , padreTexto
, padreDia
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

        public int Update(Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdTexto = _dataProvider.GetParameter();
                paramUpdTexto.ParameterName = "Texto";
                paramUpdTexto.DbType = DbType.String;
                paramUpdTexto.Value = (object)entity.Texto ?? DBNull.Value;
                var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.String;
                paramUpdDia.Value = (object)entity.Dia ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDias_de_la_semana>("sp_UpdDias_de_la_semana" , paramUpdClave , paramUpdTexto , paramUpdDia ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana Dias_de_la_semanaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdTexto = _dataProvider.GetParameter();
                paramUpdTexto.ParameterName = "Texto";
                paramUpdTexto.DbType = DbType.String;
                paramUpdTexto.Value = (object)entity.Texto ?? DBNull.Value;
                var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.String;
                paramUpdDia.Value = (object)entity.Dia ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDias_de_la_semana>("sp_UpdDias_de_la_semana" , paramUpdClave , paramUpdTexto , paramUpdDia ).FirstOrDefault();

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


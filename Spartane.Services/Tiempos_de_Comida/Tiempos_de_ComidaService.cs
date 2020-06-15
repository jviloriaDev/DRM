using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tiempos_de_Comida;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tiempos_de_Comida
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tiempos_de_ComidaService : ITiempos_de_ComidaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> _Tiempos_de_ComidaRepository;
        #endregion

        #region Ctor
        public Tiempos_de_ComidaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> Tiempos_de_ComidaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tiempos_de_ComidaRepository = Tiempos_de_ComidaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tiempos_de_ComidaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida>("sp_SelAllTiempos_de_Comida");
        }

        public IList<Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTiempos_de_Comida_Complete>("sp_SelAllComplete_Tiempos_de_Comida");
            return data.Select(m => new Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida
            {
                Clave = m.Clave
                ,Comida = m.Comida
                ,Hora_min = m.Hora_min
                ,Hora_max = m.Hora_max
                ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais.GetValueOrDefault(), Nombre_del_Pais = m.Pais_Nombre_del_Pais }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tiempos_de_Comida>("sp_ListSelCount_Tiempos_de_Comida", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTiempos_de_Comida>("sp_ListSelAll_Tiempos_de_Comida", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida
                {
                    Clave = m.Tiempos_de_Comida_Clave,
                    Comida = m.Tiempos_de_Comida_Comida,
                    Hora_min = m.Tiempos_de_Comida_Hora_min,
                    Hora_max = m.Tiempos_de_Comida_Hora_max,
                    Pais = m.Tiempos_de_Comida_Pais,

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

        public IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tiempos_de_ComidaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tiempos_de_ComidaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_ComidaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTiempos_de_Comida>("sp_ListSelAll_Tiempos_de_Comida", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tiempos_de_ComidaPagingModel result = null;

            if (data != null)
            {
                result = new Tiempos_de_ComidaPagingModel
                {
                    Tiempos_de_Comidas =
                        data.Select(m => new Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida
                {
                    Clave = m.Tiempos_de_Comida_Clave
                    ,Comida = m.Tiempos_de_Comida_Comida
                    ,Hora_min = m.Tiempos_de_Comida_Hora_min
                    ,Hora_max = m.Tiempos_de_Comida_Hora_max
                    ,Pais = m.Tiempos_de_Comida_Pais
                    ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Tiempos_de_Comida_Pais.GetValueOrDefault(), Nombre_del_Pais = m.Tiempos_de_Comida_Pais_Nombre_del_Pais }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tiempos_de_ComidaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida>("sp_GetTiempos_de_Comida", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTiempos_de_Comida>("sp_DelTiempos_de_Comida", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreComida = _dataProvider.GetParameter();
                padreComida.ParameterName = "Comida";
                padreComida.DbType = DbType.String;
                padreComida.Value = (object)entity.Comida ?? DBNull.Value;
                var padreHora_min = _dataProvider.GetParameter();
                padreHora_min.ParameterName = "Hora_min";
                padreHora_min.DbType = DbType.String;
                padreHora_min.Value = (object)entity.Hora_min ?? DBNull.Value;
                var padreHora_max = _dataProvider.GetParameter();
                padreHora_max.ParameterName = "Hora_max";
                padreHora_max.DbType = DbType.String;
                padreHora_max.Value = (object)entity.Hora_max ?? DBNull.Value;
                var padrePais = _dataProvider.GetParameter();
                padrePais.ParameterName = "Pais";
                padrePais.DbType = DbType.Int32;
                padrePais.Value = (object)entity.Pais ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTiempos_de_Comida>("sp_InsTiempos_de_Comida" , padreComida
, padreHora_min
, padreHora_max
, padrePais
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

        public int Update(Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdComida = _dataProvider.GetParameter();
                paramUpdComida.ParameterName = "Comida";
                paramUpdComida.DbType = DbType.String;
                paramUpdComida.Value = (object)entity.Comida ?? DBNull.Value;
                var paramUpdHora_min = _dataProvider.GetParameter();
                paramUpdHora_min.ParameterName = "Hora_min";
                paramUpdHora_min.DbType = DbType.String;
                paramUpdHora_min.Value = (object)entity.Hora_min ?? DBNull.Value;
                var paramUpdHora_max = _dataProvider.GetParameter();
                paramUpdHora_max.ParameterName = "Hora_max";
                paramUpdHora_max.DbType = DbType.String;
                paramUpdHora_max.Value = (object)entity.Hora_max ?? DBNull.Value;
                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTiempos_de_Comida>("sp_UpdTiempos_de_Comida" , paramUpdClave , paramUpdComida , paramUpdHora_min , paramUpdHora_max , paramUpdPais ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida Tiempos_de_ComidaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdComida = _dataProvider.GetParameter();
                paramUpdComida.ParameterName = "Comida";
                paramUpdComida.DbType = DbType.String;
                paramUpdComida.Value = (object)entity.Comida ?? DBNull.Value;
                var paramUpdHora_min = _dataProvider.GetParameter();
                paramUpdHora_min.ParameterName = "Hora_min";
                paramUpdHora_min.DbType = DbType.String;
                paramUpdHora_min.Value = (object)entity.Hora_min ?? DBNull.Value;
                var paramUpdHora_max = _dataProvider.GetParameter();
                paramUpdHora_max.ParameterName = "Hora_max";
                paramUpdHora_max.DbType = DbType.String;
                paramUpdHora_max.Value = (object)entity.Hora_max ?? DBNull.Value;
                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTiempos_de_Comida>("sp_UpdTiempos_de_Comida" , paramUpdClave , paramUpdComida , paramUpdHora_min , paramUpdHora_max , paramUpdPais ).FirstOrDefault();

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


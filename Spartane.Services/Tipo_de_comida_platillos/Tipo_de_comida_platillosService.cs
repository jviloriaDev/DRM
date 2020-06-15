using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipo_de_comida_platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_de_comida_platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_de_comida_platillosService : ITipo_de_comida_platillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> _Tipo_de_comida_platillosRepository;
        #endregion

        #region Ctor
        public Tipo_de_comida_platillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> Tipo_de_comida_platillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_de_comida_platillosRepository = Tipo_de_comida_platillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipo_de_comida_platillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos>("sp_SelAllTipo_de_comida_platillos");
        }

        public IList<Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipo_de_comida_platillos_Complete>("sp_SelAllComplete_Tipo_de_comida_platillos");
            return data.Select(m => new Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos
            {
                Folio = m.Folio
                ,Tipo_de_comida = m.Tipo_de_comida


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipo_de_comida_platillos>("sp_ListSelCount_Tipo_de_comida_platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_comida_platillos>("sp_ListSelAll_Tipo_de_comida_platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos
                {
                    Folio = m.Tipo_de_comida_platillos_Folio,
                    Tipo_de_comida = m.Tipo_de_comida_platillos_Tipo_de_comida,

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

        public IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_de_comida_platillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_comida_platillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_comida_platillos>("sp_ListSelAll_Tipo_de_comida_platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipo_de_comida_platillosPagingModel result = null;

            if (data != null)
            {
                result = new Tipo_de_comida_platillosPagingModel
                {
                    Tipo_de_comida_platilloss =
                        data.Select(m => new Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos
                {
                    Folio = m.Tipo_de_comida_platillos_Folio
                    ,Tipo_de_comida = m.Tipo_de_comida_platillos_Tipo_de_comida

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_de_comida_platillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos>("sp_GetTipo_de_comida_platillos", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipo_de_comida_platillos>("sp_DelTipo_de_comida_platillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreTipo_de_comida = _dataProvider.GetParameter();
                padreTipo_de_comida.ParameterName = "Tipo_de_comida";
                padreTipo_de_comida.DbType = DbType.String;
                padreTipo_de_comida.Value = (object)entity.Tipo_de_comida ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipo_de_comida_platillos>("sp_InsTipo_de_comida_platillos" , padreTipo_de_comida
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

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

        public int Update(Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdTipo_de_comida = _dataProvider.GetParameter();
                paramUpdTipo_de_comida.ParameterName = "Tipo_de_comida";
                paramUpdTipo_de_comida.DbType = DbType.String;
                paramUpdTipo_de_comida.Value = (object)entity.Tipo_de_comida ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_comida_platillos>("sp_UpdTipo_de_comida_platillos" , paramUpdFolio , paramUpdTipo_de_comida ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos Tipo_de_comida_platillosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdTipo_de_comida = _dataProvider.GetParameter();
                paramUpdTipo_de_comida.ParameterName = "Tipo_de_comida";
                paramUpdTipo_de_comida.DbType = DbType.String;
                paramUpdTipo_de_comida.Value = (object)entity.Tipo_de_comida ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_comida_platillos>("sp_UpdTipo_de_comida_platillos" , paramUpdFolio , paramUpdTipo_de_comida ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Categorias_de_platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Categorias_de_platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Categorias_de_platillosService : ICategorias_de_platillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> _Categorias_de_platillosRepository;
        #endregion

        #region Ctor
        public Categorias_de_platillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> Categorias_de_platillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Categorias_de_platillosRepository = Categorias_de_platillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Categorias_de_platillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos>("sp_SelAllCategorias_de_platillos");
        }

        public IList<Core.Classes.Categorias_de_platillos.Categorias_de_platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCategorias_de_platillos_Complete>("sp_SelAllComplete_Categorias_de_platillos");
            return data.Select(m => new Core.Classes.Categorias_de_platillos.Categorias_de_platillos
            {
                Clave = m.Clave
                ,Categoria = m.Categoria


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Categorias_de_platillos>("sp_ListSelCount_Categorias_de_platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCategorias_de_platillos>("sp_ListSelAll_Categorias_de_platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos
                {
                    Clave = m.Categorias_de_platillos_Clave,
                    Categoria = m.Categorias_de_platillos_Categoria,

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

        public IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Categorias_de_platillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Categorias_de_platillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCategorias_de_platillos>("sp_ListSelAll_Categorias_de_platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Categorias_de_platillosPagingModel result = null;

            if (data != null)
            {
                result = new Categorias_de_platillosPagingModel
                {
                    Categorias_de_platilloss =
                        data.Select(m => new Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos
                {
                    Clave = m.Categorias_de_platillos_Clave
                    ,Categoria = m.Categorias_de_platillos_Categoria

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Categorias_de_platillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos>("sp_GetCategorias_de_platillos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCategorias_de_platillos>("sp_DelCategorias_de_platillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreCategoria = _dataProvider.GetParameter();
                padreCategoria.ParameterName = "Categoria";
                padreCategoria.DbType = DbType.String;
                padreCategoria.Value = (object)entity.Categoria ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCategorias_de_platillos>("sp_InsCategorias_de_platillos" , padreCategoria
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

        public int Update(Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdCategoria = _dataProvider.GetParameter();
                paramUpdCategoria.ParameterName = "Categoria";
                paramUpdCategoria.DbType = DbType.String;
                paramUpdCategoria.Value = (object)entity.Categoria ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCategorias_de_platillos>("sp_UpdCategorias_de_platillos" , paramUpdClave , paramUpdCategoria ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos Categorias_de_platillosDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdCategoria = _dataProvider.GetParameter();
                paramUpdCategoria.ParameterName = "Categoria";
                paramUpdCategoria.DbType = DbType.String;
                paramUpdCategoria.Value = (object)entity.Categoria ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCategorias_de_platillos>("sp_UpdCategorias_de_platillos" , paramUpdClave , paramUpdCategoria ).FirstOrDefault();

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


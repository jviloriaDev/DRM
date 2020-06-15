using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Parentescos_Empleados;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Parentescos_Empleados
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Parentescos_EmpleadosService : IParentescos_EmpleadosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados> _Parentescos_EmpleadosRepository;
        #endregion

        #region Ctor
        public Parentescos_EmpleadosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados> Parentescos_EmpleadosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Parentescos_EmpleadosRepository = Parentescos_EmpleadosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Parentescos_EmpleadosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados>("sp_SelAllParentescos_Empleados");
        }

        public IList<Core.Classes.Parentescos_Empleados.Parentescos_Empleados> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallParentescos_Empleados_Complete>("sp_SelAllComplete_Parentescos_Empleados");
            return data.Select(m => new Core.Classes.Parentescos_Empleados.Parentescos_Empleados
            {
                Folio = m.Folio
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Parentescos_Empleados>("sp_ListSelCount_Parentescos_Empleados", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllParentescos_Empleados>("sp_ListSelAll_Parentescos_Empleados", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados
                {
                    Folio = m.Parentescos_Empleados_Folio,
                    Descripcion = m.Parentescos_Empleados_Descripcion,

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

        public IList<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Parentescos_EmpleadosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Parentescos_EmpleadosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Parentescos_Empleados.Parentescos_EmpleadosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllParentescos_Empleados>("sp_ListSelAll_Parentescos_Empleados", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Parentescos_EmpleadosPagingModel result = null;

            if (data != null)
            {
                result = new Parentescos_EmpleadosPagingModel
                {
                    Parentescos_Empleadoss =
                        data.Select(m => new Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados
                {
                    Folio = m.Parentescos_Empleados_Folio
                    ,Descripcion = m.Parentescos_Empleados_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Parentescos_EmpleadosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados>("sp_GetParentescos_Empleados", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelParentescos_Empleados>("sp_DelParentescos_Empleados", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsParentescos_Empleados>("sp_InsParentescos_Empleados" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdParentescos_Empleados>("sp_UpdParentescos_Empleados" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados Parentescos_EmpleadosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdParentescos_Empleados>("sp_UpdParentescos_Empleados" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estado_de_Animo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estado_de_Animo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estado_de_AnimoService : IEstado_de_AnimoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> _Estado_de_AnimoRepository;
        #endregion

        #region Ctor
        public Estado_de_AnimoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> Estado_de_AnimoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estado_de_AnimoRepository = Estado_de_AnimoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estado_de_AnimoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo>("sp_SelAllEstado_de_Animo");
        }

        public IList<Core.Classes.Estado_de_Animo.Estado_de_Animo> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstado_de_Animo_Complete>("sp_SelAllComplete_Estado_de_Animo");
            return data.Select(m => new Core.Classes.Estado_de_Animo.Estado_de_Animo
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estado_de_Animo>("sp_ListSelCount_Estado_de_Animo", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstado_de_Animo>("sp_ListSelAll_Estado_de_Animo", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo
                {
                    Clave = m.Estado_de_Animo_Clave,
                    Descripcion = m.Estado_de_Animo_Descripcion,

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

        public IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estado_de_AnimoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estado_de_AnimoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estado_de_Animo.Estado_de_AnimoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstado_de_Animo>("sp_ListSelAll_Estado_de_Animo", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estado_de_AnimoPagingModel result = null;

            if (data != null)
            {
                result = new Estado_de_AnimoPagingModel
                {
                    Estado_de_Animos =
                        data.Select(m => new Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo
                {
                    Clave = m.Estado_de_Animo_Clave
                    ,Descripcion = m.Estado_de_Animo_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estado_de_AnimoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo>("sp_GetEstado_de_Animo", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstado_de_Animo>("sp_DelEstado_de_Animo", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstado_de_Animo>("sp_InsEstado_de_Animo" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstado_de_Animo>("sp_UpdEstado_de_Animo" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo Estado_de_AnimoDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstado_de_Animo>("sp_UpdEstado_de_Animo" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


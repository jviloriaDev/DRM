using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Rango_de_Horas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rango_de_Horas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Rango_de_HorasService : IRango_de_HorasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> _Rango_de_HorasRepository;
        #endregion

        #region Ctor
        public Rango_de_HorasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> Rango_de_HorasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Rango_de_HorasRepository = Rango_de_HorasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Rango_de_HorasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas>("sp_SelAllRango_de_Horas");
        }

        public IList<Core.Classes.Rango_de_Horas.Rango_de_Horas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRango_de_Horas_Complete>("sp_SelAllComplete_Rango_de_Horas");
            return data.Select(m => new Core.Classes.Rango_de_Horas.Rango_de_Horas
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Rango_de_Horas>("sp_ListSelCount_Rango_de_Horas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRango_de_Horas>("sp_ListSelAll_Rango_de_Horas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas
                {
                    Clave = m.Rango_de_Horas_Clave,
                    Descripcion = m.Rango_de_Horas_Descripcion,

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

        public IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Rango_de_HorasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rango_de_HorasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rango_de_Horas.Rango_de_HorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRango_de_Horas>("sp_ListSelAll_Rango_de_Horas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Rango_de_HorasPagingModel result = null;

            if (data != null)
            {
                result = new Rango_de_HorasPagingModel
                {
                    Rango_de_Horass =
                        data.Select(m => new Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas
                {
                    Clave = m.Rango_de_Horas_Clave
                    ,Descripcion = m.Rango_de_Horas_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Rango_de_HorasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas>("sp_GetRango_de_Horas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRango_de_Horas>("sp_DelRango_de_Horas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRango_de_Horas>("sp_InsRango_de_Horas" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRango_de_Horas>("sp_UpdRango_de_Horas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas Rango_de_HorasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRango_de_Horas>("sp_UpdRango_de_Horas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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


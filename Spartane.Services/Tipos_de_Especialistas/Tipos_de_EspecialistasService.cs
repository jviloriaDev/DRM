using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipos_de_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipos_de_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipos_de_EspecialistasService : ITipos_de_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> _Tipos_de_EspecialistasRepository;
        #endregion

        #region Ctor
        public Tipos_de_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> Tipos_de_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipos_de_EspecialistasRepository = Tipos_de_EspecialistasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipos_de_EspecialistasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas>("sp_SelAllTipos_de_Especialistas");
        }

        public IList<Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipos_de_Especialistas_Complete>("sp_SelAllComplete_Tipos_de_Especialistas");
            return data.Select(m => new Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion
                ,Clave_Rol = m.Clave_Rol


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipos_de_Especialistas>("sp_ListSelCount_Tipos_de_Especialistas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipos_de_Especialistas>("sp_ListSelAll_Tipos_de_Especialistas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas
                {
                    Clave = m.Tipos_de_Especialistas_Clave,
                    Descripcion = m.Tipos_de_Especialistas_Descripcion,
                    Clave_Rol = m.Tipos_de_Especialistas_Clave_Rol,

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

        public IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipos_de_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipos_de_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipos_de_Especialistas>("sp_ListSelAll_Tipos_de_Especialistas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipos_de_EspecialistasPagingModel result = null;

            if (data != null)
            {
                result = new Tipos_de_EspecialistasPagingModel
                {
                    Tipos_de_Especialistass =
                        data.Select(m => new Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas
                {
                    Clave = m.Tipos_de_Especialistas_Clave
                    ,Descripcion = m.Tipos_de_Especialistas_Descripcion
                    ,Clave_Rol = m.Tipos_de_Especialistas_Clave_Rol

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipos_de_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas>("sp_GetTipos_de_Especialistas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipos_de_Especialistas>("sp_DelTipos_de_Especialistas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas entity)
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
                var padreClave_Rol = _dataProvider.GetParameter();
                padreClave_Rol.ParameterName = "Clave_Rol";
                padreClave_Rol.DbType = DbType.Int16;
                padreClave_Rol.Value = (object)entity.Clave_Rol ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipos_de_Especialistas>("sp_InsTipos_de_Especialistas" , padreDescripcion
, padreClave_Rol
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

        public int Update(Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas entity)
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
                var paramUpdClave_Rol = _dataProvider.GetParameter();
                paramUpdClave_Rol.ParameterName = "Clave_Rol";
                paramUpdClave_Rol.DbType = DbType.Int16;
                paramUpdClave_Rol.Value = (object)entity.Clave_Rol ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipos_de_Especialistas>("sp_UpdTipos_de_Especialistas" , paramUpdClave , paramUpdDescripcion , paramUpdClave_Rol ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas Tipos_de_EspecialistasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdClave_Rol = _dataProvider.GetParameter();
                paramUpdClave_Rol.ParameterName = "Clave_Rol";
                paramUpdClave_Rol.DbType = DbType.Int16;
                paramUpdClave_Rol.Value = (object)entity.Clave_Rol ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipos_de_Especialistas>("sp_UpdTipos_de_Especialistas" , paramUpdClave , paramUpdDescripcion , paramUpdClave_Rol ).FirstOrDefault();

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


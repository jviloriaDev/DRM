using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Identificacion_Oficial_Medicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Identificacion_Oficial_MedicosService : IDetalle_Identificacion_Oficial_MedicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> _Detalle_Identificacion_Oficial_MedicosRepository;
        #endregion

        #region Ctor
        public Detalle_Identificacion_Oficial_MedicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> Detalle_Identificacion_Oficial_MedicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Identificacion_Oficial_MedicosRepository = Detalle_Identificacion_Oficial_MedicosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos>("sp_SelAllDetalle_Identificacion_Oficial_Medicos");
        }

        public IList<Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Identificacion_Oficial_Medicos_Complete>("sp_SelAllComplete_Detalle_Identificacion_Oficial_Medicos");
            return data.Select(m => new Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos
            {
                Folio = m.Folio
                ,Folio_Medico = m.Folio_Medico
                ,Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales = new Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales() { Clave = m.Tipo_de_Identificacion_Oficial.GetValueOrDefault(), Descripcion = m.Tipo_de_Identificacion_Oficial_Descripcion }
                ,Documento = m.Documento


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Identificacion_Oficial_Medicos>("sp_ListSelCount_Detalle_Identificacion_Oficial_Medicos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Identificacion_Oficial_Medicos>("sp_ListSelAll_Detalle_Identificacion_Oficial_Medicos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos
                {
                    Folio = m.Detalle_Identificacion_Oficial_Medicos_Folio,
                    Folio_Medico = m.Detalle_Identificacion_Oficial_Medicos_Folio_Medico,
                    Tipo_de_Identificacion_Oficial = m.Detalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial,
                    Documento = m.Detalle_Identificacion_Oficial_Medicos_Documento,

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

        public IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Identificacion_Oficial_Medicos>("sp_ListSelAll_Detalle_Identificacion_Oficial_Medicos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Identificacion_Oficial_MedicosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Identificacion_Oficial_MedicosPagingModel
                {
                    Detalle_Identificacion_Oficial_Medicoss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos
                {
                    Folio = m.Detalle_Identificacion_Oficial_Medicos_Folio
                    ,Folio_Medico = m.Detalle_Identificacion_Oficial_Medicos_Folio_Medico
                    ,Tipo_de_Identificacion_Oficial = m.Detalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial
                    ,Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales = new Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales() { Clave = m.Detalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial.GetValueOrDefault(), Descripcion = m.Detalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial_Descripcion }
                    ,Documento = m.Detalle_Identificacion_Oficial_Medicos_Documento

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos>("sp_GetDetalle_Identificacion_Oficial_Medicos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Identificacion_Oficial_Medicos>("sp_DelDetalle_Identificacion_Oficial_Medicos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Medico = _dataProvider.GetParameter();
                padreFolio_Medico.ParameterName = "Folio_Medico";
                padreFolio_Medico.DbType = DbType.Int32;
                padreFolio_Medico.Value = (object)entity.Folio_Medico ?? DBNull.Value;
                var padreTipo_de_Identificacion_Oficial = _dataProvider.GetParameter();
                padreTipo_de_Identificacion_Oficial.ParameterName = "Tipo_de_Identificacion_Oficial";
                padreTipo_de_Identificacion_Oficial.DbType = DbType.Int32;
                padreTipo_de_Identificacion_Oficial.Value = (object)entity.Tipo_de_Identificacion_Oficial ?? DBNull.Value;

                var padreDocumento = _dataProvider.GetParameter();
                padreDocumento.ParameterName = "Documento";
                padreDocumento.DbType = DbType.Int32;
                padreDocumento.Value = (object)entity.Documento ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Identificacion_Oficial_Medicos>("sp_InsDetalle_Identificacion_Oficial_Medicos" , padreFolio_Medico
, padreTipo_de_Identificacion_Oficial
, padreDocumento
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

        public int Update(Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Medico = _dataProvider.GetParameter();
                paramUpdFolio_Medico.ParameterName = "Folio_Medico";
                paramUpdFolio_Medico.DbType = DbType.Int32;
                paramUpdFolio_Medico.Value = (object)entity.Folio_Medico ?? DBNull.Value;
                var paramUpdTipo_de_Identificacion_Oficial = _dataProvider.GetParameter();
                paramUpdTipo_de_Identificacion_Oficial.ParameterName = "Tipo_de_Identificacion_Oficial";
                paramUpdTipo_de_Identificacion_Oficial.DbType = DbType.Int32;
                paramUpdTipo_de_Identificacion_Oficial.Value = (object)entity.Tipo_de_Identificacion_Oficial ?? DBNull.Value;

                var paramUpdDocumento = _dataProvider.GetParameter();
                paramUpdDocumento.ParameterName = "Documento";
                paramUpdDocumento.DbType = DbType.Int32;
                paramUpdDocumento.Value = (object)entity.Documento ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Identificacion_Oficial_Medicos>("sp_UpdDetalle_Identificacion_Oficial_Medicos" , paramUpdFolio , paramUpdFolio_Medico , paramUpdTipo_de_Identificacion_Oficial , paramUpdDocumento ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos Detalle_Identificacion_Oficial_MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Medico = _dataProvider.GetParameter();
                paramUpdFolio_Medico.ParameterName = "Folio_Medico";
                paramUpdFolio_Medico.DbType = DbType.Int32;
                paramUpdFolio_Medico.Value = (object)entity.Folio_Medico ?? DBNull.Value;
                var paramUpdTipo_de_Identificacion_Oficial = _dataProvider.GetParameter();
                paramUpdTipo_de_Identificacion_Oficial.ParameterName = "Tipo_de_Identificacion_Oficial";
                paramUpdTipo_de_Identificacion_Oficial.DbType = DbType.Int32;
                paramUpdTipo_de_Identificacion_Oficial.Value = (object)entity.Tipo_de_Identificacion_Oficial ?? DBNull.Value;
                var paramUpdDocumento = _dataProvider.GetParameter();
                paramUpdDocumento.ParameterName = "Documento";
                paramUpdDocumento.DbType = DbType.Int32;
                paramUpdDocumento.Value = (object)entity.Documento ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Identificacion_Oficial_Medicos>("sp_UpdDetalle_Identificacion_Oficial_Medicos" , paramUpdFolio , paramUpdFolio_Medico , paramUpdTipo_de_Identificacion_Oficial , paramUpdDocumento ).FirstOrDefault();

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


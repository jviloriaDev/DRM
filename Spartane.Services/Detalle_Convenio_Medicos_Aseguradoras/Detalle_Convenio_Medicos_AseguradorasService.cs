using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Convenio_Medicos_Aseguradoras
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Convenio_Medicos_AseguradorasService : IDetalle_Convenio_Medicos_AseguradorasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> _Detalle_Convenio_Medicos_AseguradorasRepository;
        #endregion

        #region Ctor
        public Detalle_Convenio_Medicos_AseguradorasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> Detalle_Convenio_Medicos_AseguradorasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Convenio_Medicos_AseguradorasRepository = Detalle_Convenio_Medicos_AseguradorasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>("sp_SelAllDetalle_Convenio_Medicos_Aseguradoras");
        }

        public IList<Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Convenio_Medicos_Aseguradoras_Complete>("sp_SelAllComplete_Detalle_Convenio_Medicos_Aseguradoras");
            return data.Select(m => new Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras
            {
                Folio = m.Folio
                ,Folio_Medicos = m.Folio_Medicos
                ,Aseguradora_medico_Aseguradoras = new Core.Classes.Aseguradoras.Aseguradoras() { Folio = m.Aseguradora_medico.GetValueOrDefault(), Nombre = m.Aseguradora_medico_Nombre }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Convenio_Medicos_Aseguradoras>("sp_ListSelCount_Detalle_Convenio_Medicos_Aseguradoras", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Convenio_Medicos_Aseguradoras>("sp_ListSelAll_Detalle_Convenio_Medicos_Aseguradoras", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras
                {
                    Folio = m.Detalle_Convenio_Medicos_Aseguradoras_Folio,
                    Folio_Medicos = m.Detalle_Convenio_Medicos_Aseguradoras_Folio_Medicos,
                    Aseguradora_medico = m.Detalle_Convenio_Medicos_Aseguradoras_Aseguradora_medico,

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

        public IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Convenio_Medicos_Aseguradoras>("sp_ListSelAll_Detalle_Convenio_Medicos_Aseguradoras", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Convenio_Medicos_AseguradorasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Convenio_Medicos_AseguradorasPagingModel
                {
                    Detalle_Convenio_Medicos_Aseguradorass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras
                {
                    Folio = m.Detalle_Convenio_Medicos_Aseguradoras_Folio
                    ,Folio_Medicos = m.Detalle_Convenio_Medicos_Aseguradoras_Folio_Medicos
                    ,Aseguradora_medico = m.Detalle_Convenio_Medicos_Aseguradoras_Aseguradora_medico
                    ,Aseguradora_medico_Aseguradoras = new Core.Classes.Aseguradoras.Aseguradoras() { Folio = m.Detalle_Convenio_Medicos_Aseguradoras_Aseguradora_medico.GetValueOrDefault(), Nombre = m.Detalle_Convenio_Medicos_Aseguradoras_Aseguradora_medico_Nombre }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>("sp_GetDetalle_Convenio_Medicos_Aseguradoras", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Convenio_Medicos_Aseguradoras>("sp_DelDetalle_Convenio_Medicos_Aseguradoras", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Medicos = _dataProvider.GetParameter();
                padreFolio_Medicos.ParameterName = "Folio_Medicos";
                padreFolio_Medicos.DbType = DbType.Int32;
                padreFolio_Medicos.Value = (object)entity.Folio_Medicos ?? DBNull.Value;
                var padreAseguradora_medico = _dataProvider.GetParameter();
                padreAseguradora_medico.ParameterName = "Aseguradora_medico";
                padreAseguradora_medico.DbType = DbType.Int32;
                padreAseguradora_medico.Value = (object)entity.Aseguradora_medico ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Convenio_Medicos_Aseguradoras>("sp_InsDetalle_Convenio_Medicos_Aseguradoras" , padreFolio_Medicos
, padreAseguradora_medico
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

        public int Update(Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Medicos = _dataProvider.GetParameter();
                paramUpdFolio_Medicos.ParameterName = "Folio_Medicos";
                paramUpdFolio_Medicos.DbType = DbType.Int32;
                paramUpdFolio_Medicos.Value = (object)entity.Folio_Medicos ?? DBNull.Value;
                var paramUpdAseguradora_medico = _dataProvider.GetParameter();
                paramUpdAseguradora_medico.ParameterName = "Aseguradora_medico";
                paramUpdAseguradora_medico.DbType = DbType.Int32;
                paramUpdAseguradora_medico.Value = (object)entity.Aseguradora_medico ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Convenio_Medicos_Aseguradoras>("sp_UpdDetalle_Convenio_Medicos_Aseguradoras" , paramUpdFolio , paramUpdFolio_Medicos , paramUpdAseguradora_medico ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras Detalle_Convenio_Medicos_AseguradorasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Medicos = _dataProvider.GetParameter();
                paramUpdFolio_Medicos.ParameterName = "Folio_Medicos";
                paramUpdFolio_Medicos.DbType = DbType.Int32;
                paramUpdFolio_Medicos.Value = (object)entity.Folio_Medicos ?? DBNull.Value;
		var paramUpdAseguradora_medico = _dataProvider.GetParameter();
                paramUpdAseguradora_medico.ParameterName = "Aseguradora_medico";
                paramUpdAseguradora_medico.DbType = DbType.Int32;
                paramUpdAseguradora_medico.Value = (object)entity.Aseguradora_medico ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Convenio_Medicos_Aseguradoras>("sp_UpdDetalle_Convenio_Medicos_Aseguradoras" , paramUpdFolio , paramUpdFolio_Medicos , paramUpdAseguradora_medico ).FirstOrDefault();

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


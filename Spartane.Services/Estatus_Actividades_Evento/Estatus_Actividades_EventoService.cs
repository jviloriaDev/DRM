using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_Actividades_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Actividades_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_Actividades_EventoService : IEstatus_Actividades_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> _Estatus_Actividades_EventoRepository;
        #endregion

        #region Ctor
        public Estatus_Actividades_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> Estatus_Actividades_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_Actividades_EventoRepository = Estatus_Actividades_EventoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_Actividades_EventoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento>("sp_SelAllEstatus_Actividades_Evento");
        }

        public IList<Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_Actividades_Evento_Complete>("sp_SelAllComplete_Estatus_Actividades_Evento");
            return data.Select(m => new Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_Actividades_Evento>("sp_ListSelCount_Estatus_Actividades_Evento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Actividades_Evento>("sp_ListSelAll_Estatus_Actividades_Evento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento
                {
                    Folio = m.Estatus_Actividades_Evento_Folio,
                    Descripcion = m.Estatus_Actividades_Evento_Descripcion,

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

        public IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_Actividades_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Actividades_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Actividades_Evento>("sp_ListSelAll_Estatus_Actividades_Evento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_Actividades_EventoPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_Actividades_EventoPagingModel
                {
                    Estatus_Actividades_Eventos =
                        data.Select(m => new Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento
                {
                    Folio = m.Estatus_Actividades_Evento_Folio
                    ,Descripcion = m.Estatus_Actividades_Evento_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_Actividades_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento>("sp_GetEstatus_Actividades_Evento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_Actividades_Evento>("sp_DelEstatus_Actividades_Evento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_Actividades_Evento>("sp_InsEstatus_Actividades_Evento" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Actividades_Evento>("sp_UpdEstatus_Actividades_Evento" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento Estatus_Actividades_EventoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Actividades_Evento>("sp_UpdEstatus_Actividades_Evento" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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


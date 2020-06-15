using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Titulos_Medicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Titulos_Medicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Titulos_MedicosService : IDetalle_Titulos_MedicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> _Detalle_Titulos_MedicosRepository;
        #endregion

        #region Ctor
        public Detalle_Titulos_MedicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> Detalle_Titulos_MedicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Titulos_MedicosRepository = Detalle_Titulos_MedicosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Titulos_MedicosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos>("sp_SelAllDetalle_Titulos_Medicos");
        }

        public IList<Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Titulos_Medicos_Complete>("sp_SelAllComplete_Detalle_Titulos_Medicos");
            return data.Select(m => new Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos
            {
                Folio = m.Folio
                ,Folio_Medicos = m.Folio_Medicos
                ,Nombre_del_Titulo = m.Nombre_del_Titulo
                ,Institucion_Facultad = m.Institucion_Facultad
                ,Fecha_de_Titulacion = m.Fecha_de_Titulacion
                ,Titulo = m.Titulo
                ,Numero_de_Cedula = m.Numero_de_Cedula
                ,Fecha_de_Expedicion = m.Fecha_de_Expedicion
                ,Cedula_Frente = m.Cedula_Frente
                ,Cedula_Reverso = m.Cedula_Reverso


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Titulos_Medicos>("sp_ListSelCount_Detalle_Titulos_Medicos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Titulos_Medicos>("sp_ListSelAll_Detalle_Titulos_Medicos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos
                {
                    Folio = m.Detalle_Titulos_Medicos_Folio,
                    Folio_Medicos = m.Detalle_Titulos_Medicos_Folio_Medicos,
                    Nombre_del_Titulo = m.Detalle_Titulos_Medicos_Nombre_del_Titulo,
                    Institucion_Facultad = m.Detalle_Titulos_Medicos_Institucion_Facultad,
                    Fecha_de_Titulacion = m.Detalle_Titulos_Medicos_Fecha_de_Titulacion,
                    Titulo = m.Detalle_Titulos_Medicos_Titulo,
                    Numero_de_Cedula = m.Detalle_Titulos_Medicos_Numero_de_Cedula,
                    Fecha_de_Expedicion = m.Detalle_Titulos_Medicos_Fecha_de_Expedicion,
                    Cedula_Frente = m.Detalle_Titulos_Medicos_Cedula_Frente,
                    Cedula_Reverso = m.Detalle_Titulos_Medicos_Cedula_Reverso,

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

        public IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Titulos_MedicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Titulos_MedicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Titulos_Medicos>("sp_ListSelAll_Detalle_Titulos_Medicos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Titulos_MedicosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Titulos_MedicosPagingModel
                {
                    Detalle_Titulos_Medicoss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos
                {
                    Folio = m.Detalle_Titulos_Medicos_Folio
                    ,Folio_Medicos = m.Detalle_Titulos_Medicos_Folio_Medicos
                    ,Nombre_del_Titulo = m.Detalle_Titulos_Medicos_Nombre_del_Titulo
                    ,Institucion_Facultad = m.Detalle_Titulos_Medicos_Institucion_Facultad
                    ,Fecha_de_Titulacion = m.Detalle_Titulos_Medicos_Fecha_de_Titulacion
                    ,Titulo = m.Detalle_Titulos_Medicos_Titulo
                    ,Numero_de_Cedula = m.Detalle_Titulos_Medicos_Numero_de_Cedula
                    ,Fecha_de_Expedicion = m.Detalle_Titulos_Medicos_Fecha_de_Expedicion
                    ,Cedula_Frente = m.Detalle_Titulos_Medicos_Cedula_Frente
                    ,Cedula_Reverso = m.Detalle_Titulos_Medicos_Cedula_Reverso

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Titulos_MedicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos>("sp_GetDetalle_Titulos_Medicos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Titulos_Medicos>("sp_DelDetalle_Titulos_Medicos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos entity)
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
                var padreNombre_del_Titulo = _dataProvider.GetParameter();
                padreNombre_del_Titulo.ParameterName = "Nombre_del_Titulo";
                padreNombre_del_Titulo.DbType = DbType.String;
                padreNombre_del_Titulo.Value = (object)entity.Nombre_del_Titulo ?? DBNull.Value;
                var padreInstitucion_Facultad = _dataProvider.GetParameter();
                padreInstitucion_Facultad.ParameterName = "Institucion_Facultad";
                padreInstitucion_Facultad.DbType = DbType.String;
                padreInstitucion_Facultad.Value = (object)entity.Institucion_Facultad ?? DBNull.Value;
                var padreFecha_de_Titulacion = _dataProvider.GetParameter();
                padreFecha_de_Titulacion.ParameterName = "Fecha_de_Titulacion";
                padreFecha_de_Titulacion.DbType = DbType.DateTime;
                padreFecha_de_Titulacion.Value = (object)entity.Fecha_de_Titulacion ?? DBNull.Value;

                var padreTitulo = _dataProvider.GetParameter();
                padreTitulo.ParameterName = "Titulo";
                padreTitulo.DbType = DbType.Int32;
                padreTitulo.Value = (object)entity.Titulo ?? DBNull.Value;

                var padreNumero_de_Cedula = _dataProvider.GetParameter();
                padreNumero_de_Cedula.ParameterName = "Numero_de_Cedula";
                padreNumero_de_Cedula.DbType = DbType.String;
                padreNumero_de_Cedula.Value = (object)entity.Numero_de_Cedula ?? DBNull.Value;
                var padreFecha_de_Expedicion = _dataProvider.GetParameter();
                padreFecha_de_Expedicion.ParameterName = "Fecha_de_Expedicion";
                padreFecha_de_Expedicion.DbType = DbType.DateTime;
                padreFecha_de_Expedicion.Value = (object)entity.Fecha_de_Expedicion ?? DBNull.Value;

                var padreCedula_Frente = _dataProvider.GetParameter();
                padreCedula_Frente.ParameterName = "Cedula_Frente";
                padreCedula_Frente.DbType = DbType.Int32;
                padreCedula_Frente.Value = (object)entity.Cedula_Frente ?? DBNull.Value;

                var padreCedula_Reverso = _dataProvider.GetParameter();
                padreCedula_Reverso.ParameterName = "Cedula_Reverso";
                padreCedula_Reverso.DbType = DbType.Int32;
                padreCedula_Reverso.Value = (object)entity.Cedula_Reverso ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Titulos_Medicos>("sp_InsDetalle_Titulos_Medicos" , padreFolio_Medicos
, padreNombre_del_Titulo
, padreInstitucion_Facultad
, padreFecha_de_Titulacion
, padreTitulo
, padreNumero_de_Cedula
, padreFecha_de_Expedicion
, padreCedula_Frente
, padreCedula_Reverso
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

        public int Update(Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos entity)
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
                var paramUpdNombre_del_Titulo = _dataProvider.GetParameter();
                paramUpdNombre_del_Titulo.ParameterName = "Nombre_del_Titulo";
                paramUpdNombre_del_Titulo.DbType = DbType.String;
                paramUpdNombre_del_Titulo.Value = (object)entity.Nombre_del_Titulo ?? DBNull.Value;
                var paramUpdInstitucion_Facultad = _dataProvider.GetParameter();
                paramUpdInstitucion_Facultad.ParameterName = "Institucion_Facultad";
                paramUpdInstitucion_Facultad.DbType = DbType.String;
                paramUpdInstitucion_Facultad.Value = (object)entity.Institucion_Facultad ?? DBNull.Value;
                var paramUpdFecha_de_Titulacion = _dataProvider.GetParameter();
                paramUpdFecha_de_Titulacion.ParameterName = "Fecha_de_Titulacion";
                paramUpdFecha_de_Titulacion.DbType = DbType.DateTime;
                paramUpdFecha_de_Titulacion.Value = (object)entity.Fecha_de_Titulacion ?? DBNull.Value;

                var paramUpdTitulo = _dataProvider.GetParameter();
                paramUpdTitulo.ParameterName = "Titulo";
                paramUpdTitulo.DbType = DbType.Int32;
                paramUpdTitulo.Value = (object)entity.Titulo ?? DBNull.Value;

                var paramUpdNumero_de_Cedula = _dataProvider.GetParameter();
                paramUpdNumero_de_Cedula.ParameterName = "Numero_de_Cedula";
                paramUpdNumero_de_Cedula.DbType = DbType.String;
                paramUpdNumero_de_Cedula.Value = (object)entity.Numero_de_Cedula ?? DBNull.Value;
                var paramUpdFecha_de_Expedicion = _dataProvider.GetParameter();
                paramUpdFecha_de_Expedicion.ParameterName = "Fecha_de_Expedicion";
                paramUpdFecha_de_Expedicion.DbType = DbType.DateTime;
                paramUpdFecha_de_Expedicion.Value = (object)entity.Fecha_de_Expedicion ?? DBNull.Value;

                var paramUpdCedula_Frente = _dataProvider.GetParameter();
                paramUpdCedula_Frente.ParameterName = "Cedula_Frente";
                paramUpdCedula_Frente.DbType = DbType.Int32;
                paramUpdCedula_Frente.Value = (object)entity.Cedula_Frente ?? DBNull.Value;

                var paramUpdCedula_Reverso = _dataProvider.GetParameter();
                paramUpdCedula_Reverso.ParameterName = "Cedula_Reverso";
                paramUpdCedula_Reverso.DbType = DbType.Int32;
                paramUpdCedula_Reverso.Value = (object)entity.Cedula_Reverso ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Titulos_Medicos>("sp_UpdDetalle_Titulos_Medicos" , paramUpdFolio , paramUpdFolio_Medicos , paramUpdNombre_del_Titulo , paramUpdInstitucion_Facultad , paramUpdFecha_de_Titulacion , paramUpdTitulo , paramUpdNumero_de_Cedula , paramUpdFecha_de_Expedicion , paramUpdCedula_Frente , paramUpdCedula_Reverso ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos Detalle_Titulos_MedicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Medicos = _dataProvider.GetParameter();
                paramUpdFolio_Medicos.ParameterName = "Folio_Medicos";
                paramUpdFolio_Medicos.DbType = DbType.Int32;
                paramUpdFolio_Medicos.Value = (object)entity.Folio_Medicos ?? DBNull.Value;
                var paramUpdNombre_del_Titulo = _dataProvider.GetParameter();
                paramUpdNombre_del_Titulo.ParameterName = "Nombre_del_Titulo";
                paramUpdNombre_del_Titulo.DbType = DbType.String;
                paramUpdNombre_del_Titulo.Value = (object)entity.Nombre_del_Titulo ?? DBNull.Value;
                var paramUpdInstitucion_Facultad = _dataProvider.GetParameter();
                paramUpdInstitucion_Facultad.ParameterName = "Institucion_Facultad";
                paramUpdInstitucion_Facultad.DbType = DbType.String;
                paramUpdInstitucion_Facultad.Value = (object)entity.Institucion_Facultad ?? DBNull.Value;
                var paramUpdFecha_de_Titulacion = _dataProvider.GetParameter();
                paramUpdFecha_de_Titulacion.ParameterName = "Fecha_de_Titulacion";
                paramUpdFecha_de_Titulacion.DbType = DbType.DateTime;
                paramUpdFecha_de_Titulacion.Value = (object)entity.Fecha_de_Titulacion ?? DBNull.Value;
                var paramUpdTitulo = _dataProvider.GetParameter();
                paramUpdTitulo.ParameterName = "Titulo";
                paramUpdTitulo.DbType = DbType.Int32;
                paramUpdTitulo.Value = (object)entity.Titulo ?? DBNull.Value;
                var paramUpdNumero_de_Cedula = _dataProvider.GetParameter();
                paramUpdNumero_de_Cedula.ParameterName = "Numero_de_Cedula";
                paramUpdNumero_de_Cedula.DbType = DbType.String;
                paramUpdNumero_de_Cedula.Value = (object)entity.Numero_de_Cedula ?? DBNull.Value;
                var paramUpdFecha_de_Expedicion = _dataProvider.GetParameter();
                paramUpdFecha_de_Expedicion.ParameterName = "Fecha_de_Expedicion";
                paramUpdFecha_de_Expedicion.DbType = DbType.DateTime;
                paramUpdFecha_de_Expedicion.Value = (object)entity.Fecha_de_Expedicion ?? DBNull.Value;
                var paramUpdCedula_Frente = _dataProvider.GetParameter();
                paramUpdCedula_Frente.ParameterName = "Cedula_Frente";
                paramUpdCedula_Frente.DbType = DbType.Int32;
                paramUpdCedula_Frente.Value = (object)entity.Cedula_Frente ?? DBNull.Value;
                var paramUpdCedula_Reverso = _dataProvider.GetParameter();
                paramUpdCedula_Reverso.ParameterName = "Cedula_Reverso";
                paramUpdCedula_Reverso.DbType = DbType.Int32;
                paramUpdCedula_Reverso.Value = (object)entity.Cedula_Reverso ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Titulos_Medicos>("sp_UpdDetalle_Titulos_Medicos" , paramUpdFolio , paramUpdFolio_Medicos , paramUpdNombre_del_Titulo , paramUpdInstitucion_Facultad , paramUpdFecha_de_Titulacion , paramUpdTitulo , paramUpdNumero_de_Cedula , paramUpdFecha_de_Expedicion , paramUpdCedula_Frente , paramUpdCedula_Reverso ).FirstOrDefault();

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


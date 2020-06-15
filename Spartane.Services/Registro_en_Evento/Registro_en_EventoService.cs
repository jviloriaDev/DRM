using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Registro_en_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro_en_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Registro_en_EventoService : IRegistro_en_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento> _Registro_en_EventoRepository;
        #endregion

        #region Ctor
        public Registro_en_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento> Registro_en_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_en_EventoRepository = Registro_en_EventoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Registro_en_EventoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento>("sp_SelAllRegistro_en_Evento");
        }

        public IList<Core.Classes.Registro_en_Evento.Registro_en_Evento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRegistro_en_Evento_Complete>("sp_SelAllComplete_Registro_en_Evento");
            return data.Select(m => new Core.Classes.Registro_en_Evento.Registro_en_Evento
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Evento_Eventos = new Core.Classes.Eventos.Eventos() { Folio = m.Evento.GetValueOrDefault(), Nombre_del_Evento = m.Evento_Nombre_del_Evento }
                ,Descripcion = m.Descripcion
                ,Fecha_inicio_del_Evento = m.Fecha_inicio_del_Evento
                ,Fecha_fin_del_Evento = m.Fecha_fin_del_Evento
                ,Lugar = m.Lugar


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Registro_en_Evento>("sp_ListSelCount_Registro_en_Evento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_en_Evento>("sp_ListSelAll_Registro_en_Evento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento
                {
                    Folio = m.Registro_en_Evento_Folio,
                    Fecha_de_Registro = m.Registro_en_Evento_Fecha_de_Registro,
                    Hora_de_Registro = m.Registro_en_Evento_Hora_de_Registro,
                    Usuario_que_Registra = m.Registro_en_Evento_Usuario_que_Registra,
                    Evento = m.Registro_en_Evento_Evento,
                    Descripcion = m.Registro_en_Evento_Descripcion,
                    Fecha_inicio_del_Evento = m.Registro_en_Evento_Fecha_inicio_del_Evento,
                    Fecha_fin_del_Evento = m.Registro_en_Evento_Fecha_fin_del_Evento,
                    Lugar = m.Registro_en_Evento_Lugar,

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

        public IList<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_en_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_en_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_en_Evento.Registro_en_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_en_Evento>("sp_ListSelAll_Registro_en_Evento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Registro_en_EventoPagingModel result = null;

            if (data != null)
            {
                result = new Registro_en_EventoPagingModel
                {
                    Registro_en_Eventos =
                        data.Select(m => new Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento
                {
                    Folio = m.Registro_en_Evento_Folio
                    ,Fecha_de_Registro = m.Registro_en_Evento_Fecha_de_Registro
                    ,Hora_de_Registro = m.Registro_en_Evento_Hora_de_Registro
                    ,Usuario_que_Registra = m.Registro_en_Evento_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Registro_en_Evento_Usuario_que_Registra.GetValueOrDefault(), Name = m.Registro_en_Evento_Usuario_que_Registra_Name }
                    ,Evento = m.Registro_en_Evento_Evento
                    ,Evento_Eventos = new Core.Classes.Eventos.Eventos() { Folio = m.Registro_en_Evento_Evento.GetValueOrDefault(), Nombre_del_Evento = m.Registro_en_Evento_Evento_Nombre_del_Evento }
                    ,Descripcion = m.Registro_en_Evento_Descripcion
                    ,Fecha_inicio_del_Evento = m.Registro_en_Evento_Fecha_inicio_del_Evento
                    ,Fecha_fin_del_Evento = m.Registro_en_Evento_Fecha_fin_del_Evento
                    ,Lugar = m.Registro_en_Evento_Lugar

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_en_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento>("sp_GetRegistro_en_Evento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRegistro_en_Evento>("sp_DelRegistro_en_Evento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreEvento = _dataProvider.GetParameter();
                padreEvento.ParameterName = "Evento";
                padreEvento.DbType = DbType.Int32;
                padreEvento.Value = (object)entity.Evento ?? DBNull.Value;

                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreFecha_inicio_del_Evento = _dataProvider.GetParameter();
                padreFecha_inicio_del_Evento.ParameterName = "Fecha_inicio_del_Evento";
                padreFecha_inicio_del_Evento.DbType = DbType.DateTime;
                padreFecha_inicio_del_Evento.Value = (object)entity.Fecha_inicio_del_Evento ?? DBNull.Value;

                var padreFecha_fin_del_Evento = _dataProvider.GetParameter();
                padreFecha_fin_del_Evento.ParameterName = "Fecha_fin_del_Evento";
                padreFecha_fin_del_Evento.DbType = DbType.DateTime;
                padreFecha_fin_del_Evento.Value = (object)entity.Fecha_fin_del_Evento ?? DBNull.Value;

                var padreLugar = _dataProvider.GetParameter();
                padreLugar.ParameterName = "Lugar";
                padreLugar.DbType = DbType.String;
                padreLugar.Value = (object)entity.Lugar ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRegistro_en_Evento>("sp_InsRegistro_en_Evento" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreEvento
, padreDescripcion
, padreFecha_inicio_del_Evento
, padreFecha_fin_del_Evento
, padreLugar
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

        public int Update(Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdEvento = _dataProvider.GetParameter();
                paramUpdEvento.ParameterName = "Evento";
                paramUpdEvento.DbType = DbType.Int32;
                paramUpdEvento.Value = (object)entity.Evento ?? DBNull.Value;

                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdFecha_inicio_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_Evento.ParameterName = "Fecha_inicio_del_Evento";
                paramUpdFecha_inicio_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_Evento.Value = (object)entity.Fecha_inicio_del_Evento ?? DBNull.Value;

                var paramUpdFecha_fin_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_Evento.ParameterName = "Fecha_fin_del_Evento";
                paramUpdFecha_fin_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_Evento.Value = (object)entity.Fecha_fin_del_Evento ?? DBNull.Value;

                var paramUpdLugar = _dataProvider.GetParameter();
                paramUpdLugar.ParameterName = "Lugar";
                paramUpdLugar.DbType = DbType.String;
                paramUpdLugar.Value = (object)entity.Lugar ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_en_Evento>("sp_UpdRegistro_en_Evento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdEvento , paramUpdDescripcion , paramUpdFecha_inicio_del_Evento , paramUpdFecha_fin_del_Evento , paramUpdLugar ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento Registro_en_EventoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdEvento = _dataProvider.GetParameter();
                paramUpdEvento.ParameterName = "Evento";
                paramUpdEvento.DbType = DbType.Int32;
                paramUpdEvento.Value = (object)entity.Evento ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdFecha_inicio_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_Evento.ParameterName = "Fecha_inicio_del_Evento";
                paramUpdFecha_inicio_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_Evento.Value = (object)entity.Fecha_inicio_del_Evento ?? DBNull.Value;
                var paramUpdFecha_fin_del_Evento = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_Evento.ParameterName = "Fecha_fin_del_Evento";
                paramUpdFecha_fin_del_Evento.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_Evento.Value = (object)entity.Fecha_fin_del_Evento ?? DBNull.Value;
                var paramUpdLugar = _dataProvider.GetParameter();
                paramUpdLugar.ParameterName = "Lugar";
                paramUpdLugar.DbType = DbType.String;
                paramUpdLugar.Value = (object)entity.Lugar ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_en_Evento>("sp_UpdRegistro_en_Evento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdEvento , paramUpdDescripcion , paramUpdFecha_inicio_del_Evento , paramUpdFecha_fin_del_Evento , paramUpdLugar ).FirstOrDefault();

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


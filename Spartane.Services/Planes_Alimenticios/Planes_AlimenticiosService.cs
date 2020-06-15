using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Planes_Alimenticios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Planes_Alimenticios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Planes_AlimenticiosService : IPlanes_AlimenticiosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> _Planes_AlimenticiosRepository;
        #endregion

        #region Ctor
        public Planes_AlimenticiosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> Planes_AlimenticiosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Planes_AlimenticiosRepository = Planes_AlimenticiosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Planes_AlimenticiosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios>("sp_SelAllPlanes_Alimenticios");
        }

        public IList<Core.Classes.Planes_Alimenticios.Planes_Alimenticios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPlanes_Alimenticios_Complete>("sp_SelAllComplete_Planes_Alimenticios");
            return data.Select(m => new Core.Classes.Planes_Alimenticios.Planes_Alimenticios
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Fecha_inicio_del_Plan = m.Fecha_inicio_del_Plan
                ,Fecha_fin_del_Plan = m.Fecha_fin_del_Plan
                ,Semana = m.Semana
                ,Paciente_Pacientes = new Core.Classes.Pacientes.Pacientes() { Folio = m.Paciente.GetValueOrDefault(), Nombre_Completo = m.Paciente_Nombre_Completo }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Planes_Alimenticios>("sp_ListSelCount_Planes_Alimenticios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlanes_Alimenticios>("sp_ListSelAll_Planes_Alimenticios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios
                {
                    Folio = m.Planes_Alimenticios_Folio,
                    Fecha_de_Registro = m.Planes_Alimenticios_Fecha_de_Registro,
                    Hora_de_Registro = m.Planes_Alimenticios_Hora_de_Registro,
                    Usuario_que_Registra = m.Planes_Alimenticios_Usuario_que_Registra,
                    Fecha_inicio_del_Plan = m.Planes_Alimenticios_Fecha_inicio_del_Plan,
                    Fecha_fin_del_Plan = m.Planes_Alimenticios_Fecha_fin_del_Plan,
                    Semana = m.Planes_Alimenticios_Semana,
                    Paciente = m.Planes_Alimenticios_Paciente,
                    Estatus = m.Planes_Alimenticios_Estatus,

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

        public IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Planes_AlimenticiosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_AlimenticiosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Planes_Alimenticios.Planes_AlimenticiosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPlanes_Alimenticios>("sp_ListSelAll_Planes_Alimenticios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Planes_AlimenticiosPagingModel result = null;

            if (data != null)
            {
                result = new Planes_AlimenticiosPagingModel
                {
                    Planes_Alimenticioss =
                        data.Select(m => new Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios
                {
                    Folio = m.Planes_Alimenticios_Folio
                    ,Fecha_de_Registro = m.Planes_Alimenticios_Fecha_de_Registro
                    ,Hora_de_Registro = m.Planes_Alimenticios_Hora_de_Registro
                    ,Usuario_que_Registra = m.Planes_Alimenticios_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Planes_Alimenticios_Usuario_que_Registra.GetValueOrDefault(), Name = m.Planes_Alimenticios_Usuario_que_Registra_Name }
                    ,Fecha_inicio_del_Plan = m.Planes_Alimenticios_Fecha_inicio_del_Plan
                    ,Fecha_fin_del_Plan = m.Planes_Alimenticios_Fecha_fin_del_Plan
                    ,Semana = m.Planes_Alimenticios_Semana
                    ,Paciente = m.Planes_Alimenticios_Paciente
                    ,Paciente_Pacientes = new Core.Classes.Pacientes.Pacientes() { Folio = m.Planes_Alimenticios_Paciente.GetValueOrDefault(), Nombre_Completo = m.Planes_Alimenticios_Paciente_Nombre_Completo }
                    ,Estatus = m.Planes_Alimenticios_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Planes_Alimenticios_Estatus.GetValueOrDefault(), Descripcion = m.Planes_Alimenticios_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Planes_AlimenticiosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios>("sp_GetPlanes_Alimenticios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPlanes_Alimenticios>("sp_DelPlanes_Alimenticios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios entity)
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

                var padreFecha_inicio_del_Plan = _dataProvider.GetParameter();
                padreFecha_inicio_del_Plan.ParameterName = "Fecha_inicio_del_Plan";
                padreFecha_inicio_del_Plan.DbType = DbType.DateTime;
                padreFecha_inicio_del_Plan.Value = (object)entity.Fecha_inicio_del_Plan ?? DBNull.Value;

                var padreFecha_fin_del_Plan = _dataProvider.GetParameter();
                padreFecha_fin_del_Plan.ParameterName = "Fecha_fin_del_Plan";
                padreFecha_fin_del_Plan.DbType = DbType.DateTime;
                padreFecha_fin_del_Plan.Value = (object)entity.Fecha_fin_del_Plan ?? DBNull.Value;

                var padreSemana = _dataProvider.GetParameter();
                padreSemana.ParameterName = "Semana";
                padreSemana.DbType = DbType.Int32;
                padreSemana.Value = (object)entity.Semana ?? DBNull.Value;

                var padrePaciente = _dataProvider.GetParameter();
                padrePaciente.ParameterName = "Paciente";
                padrePaciente.DbType = DbType.Int32;
                padrePaciente.Value = (object)entity.Paciente ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPlanes_Alimenticios>("sp_InsPlanes_Alimenticios" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreFecha_inicio_del_Plan
, padreFecha_fin_del_Plan
, padreSemana
, padrePaciente
, padreEstatus
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

        public int Update(Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios entity)
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

                var paramUpdFecha_inicio_del_Plan = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_Plan.ParameterName = "Fecha_inicio_del_Plan";
                paramUpdFecha_inicio_del_Plan.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_Plan.Value = (object)entity.Fecha_inicio_del_Plan ?? DBNull.Value;

                var paramUpdFecha_fin_del_Plan = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_Plan.ParameterName = "Fecha_fin_del_Plan";
                paramUpdFecha_fin_del_Plan.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_Plan.Value = (object)entity.Fecha_fin_del_Plan ?? DBNull.Value;

                var paramUpdSemana = _dataProvider.GetParameter();
                paramUpdSemana.ParameterName = "Semana";
                paramUpdSemana.DbType = DbType.Int32;
                paramUpdSemana.Value = (object)entity.Semana ?? DBNull.Value;

                var paramUpdPaciente = _dataProvider.GetParameter();
                paramUpdPaciente.ParameterName = "Paciente";
                paramUpdPaciente.DbType = DbType.Int32;
                paramUpdPaciente.Value = (object)entity.Paciente ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlanes_Alimenticios>("sp_UpdPlanes_Alimenticios" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdFecha_inicio_del_Plan , paramUpdFecha_fin_del_Plan , paramUpdSemana , paramUpdPaciente , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios Planes_AlimenticiosDB = GetByKey(entity.Folio, false);
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
                var paramUpdFecha_inicio_del_Plan = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_Plan.ParameterName = "Fecha_inicio_del_Plan";
                paramUpdFecha_inicio_del_Plan.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_Plan.Value = (object)entity.Fecha_inicio_del_Plan ?? DBNull.Value;
                var paramUpdFecha_fin_del_Plan = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_Plan.ParameterName = "Fecha_fin_del_Plan";
                paramUpdFecha_fin_del_Plan.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_Plan.Value = (object)entity.Fecha_fin_del_Plan ?? DBNull.Value;
                var paramUpdSemana = _dataProvider.GetParameter();
                paramUpdSemana.ParameterName = "Semana";
                paramUpdSemana.DbType = DbType.Int32;
                paramUpdSemana.Value = (object)entity.Semana ?? DBNull.Value;
		var paramUpdPaciente = _dataProvider.GetParameter();
                paramUpdPaciente.ParameterName = "Paciente";
                paramUpdPaciente.DbType = DbType.Int32;
                paramUpdPaciente.Value = (object)entity.Paciente ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPlanes_Alimenticios>("sp_UpdPlanes_Alimenticios" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdFecha_inicio_del_Plan , paramUpdFecha_fin_del_Plan , paramUpdSemana , paramUpdPaciente , paramUpdEstatus ).FirstOrDefault();

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


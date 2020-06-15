using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Ubicaciones_Eventos_Empresa;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Ubicaciones_Eventos_Empresa
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Ubicaciones_Eventos_EmpresaService : IUbicaciones_Eventos_EmpresaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> _Ubicaciones_Eventos_EmpresaRepository;
        #endregion

        #region Ctor
        public Ubicaciones_Eventos_EmpresaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> Ubicaciones_Eventos_EmpresaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Ubicaciones_Eventos_EmpresaRepository = Ubicaciones_Eventos_EmpresaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Ubicaciones_Eventos_EmpresaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>("sp_SelAllUbicaciones_Eventos_Empresa");
        }

        public IList<Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallUbicaciones_Eventos_Empresa_Complete>("sp_SelAllComplete_Ubicaciones_Eventos_Empresa");
            return data.Select(m => new Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombre = m.Nombre
                ,Descripcion = m.Descripcion
                ,Cupo = m.Cupo
                ,Ubicacion_externa_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Ubicacion_externa.GetValueOrDefault(), Descripcion = m.Ubicacion_externa_Descripcion }
                ,Nombre_del_Lugar = m.Nombre_del_Lugar
                ,Empresa_Empresas = new Core.Classes.Empresas.Empresas() { Folio = m.Empresa.GetValueOrDefault(), Nombre_de_la_Empresa = m.Empresa_Nombre_de_la_Empresa }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Ubicaciones_Eventos_Empresa>("sp_ListSelCount_Ubicaciones_Eventos_Empresa", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllUbicaciones_Eventos_Empresa>("sp_ListSelAll_Ubicaciones_Eventos_Empresa", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa
                {
                    Folio = m.Ubicaciones_Eventos_Empresa_Folio,
                    Fecha_de_Registro = m.Ubicaciones_Eventos_Empresa_Fecha_de_Registro,
                    Hora_de_Registro = m.Ubicaciones_Eventos_Empresa_Hora_de_Registro,
                    Usuario_que_Registra = m.Ubicaciones_Eventos_Empresa_Usuario_que_Registra,
                    Nombre = m.Ubicaciones_Eventos_Empresa_Nombre,
                    Descripcion = m.Ubicaciones_Eventos_Empresa_Descripcion,
                    Cupo = m.Ubicaciones_Eventos_Empresa_Cupo,
                    Ubicacion_externa = m.Ubicaciones_Eventos_Empresa_Ubicacion_externa,
                    Nombre_del_Lugar = m.Ubicaciones_Eventos_Empresa_Nombre_del_Lugar,
                    Empresa = m.Ubicaciones_Eventos_Empresa_Empresa,
                    Estatus = m.Ubicaciones_Eventos_Empresa_Estatus,

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

        public IList<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Ubicaciones_Eventos_EmpresaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Ubicaciones_Eventos_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllUbicaciones_Eventos_Empresa>("sp_ListSelAll_Ubicaciones_Eventos_Empresa", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Ubicaciones_Eventos_EmpresaPagingModel result = null;

            if (data != null)
            {
                result = new Ubicaciones_Eventos_EmpresaPagingModel
                {
                    Ubicaciones_Eventos_Empresas =
                        data.Select(m => new Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa
                {
                    Folio = m.Ubicaciones_Eventos_Empresa_Folio
                    ,Fecha_de_Registro = m.Ubicaciones_Eventos_Empresa_Fecha_de_Registro
                    ,Hora_de_Registro = m.Ubicaciones_Eventos_Empresa_Hora_de_Registro
                    ,Usuario_que_Registra = m.Ubicaciones_Eventos_Empresa_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Ubicaciones_Eventos_Empresa_Usuario_que_Registra.GetValueOrDefault(), Name = m.Ubicaciones_Eventos_Empresa_Usuario_que_Registra_Name }
                    ,Nombre = m.Ubicaciones_Eventos_Empresa_Nombre
                    ,Descripcion = m.Ubicaciones_Eventos_Empresa_Descripcion
                    ,Cupo = m.Ubicaciones_Eventos_Empresa_Cupo
                    ,Ubicacion_externa = m.Ubicaciones_Eventos_Empresa_Ubicacion_externa
                    ,Ubicacion_externa_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Ubicaciones_Eventos_Empresa_Ubicacion_externa.GetValueOrDefault(), Descripcion = m.Ubicaciones_Eventos_Empresa_Ubicacion_externa_Descripcion }
                    ,Nombre_del_Lugar = m.Ubicaciones_Eventos_Empresa_Nombre_del_Lugar
                    ,Empresa = m.Ubicaciones_Eventos_Empresa_Empresa
                    ,Empresa_Empresas = new Core.Classes.Empresas.Empresas() { Folio = m.Ubicaciones_Eventos_Empresa_Empresa.GetValueOrDefault(), Nombre_de_la_Empresa = m.Ubicaciones_Eventos_Empresa_Empresa_Nombre_de_la_Empresa }
                    ,Estatus = m.Ubicaciones_Eventos_Empresa_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Ubicaciones_Eventos_Empresa_Estatus.GetValueOrDefault(), Descripcion = m.Ubicaciones_Eventos_Empresa_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Ubicaciones_Eventos_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>("sp_GetUbicaciones_Eventos_Empresa", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelUbicaciones_Eventos_Empresa>("sp_DelUbicaciones_Eventos_Empresa", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa entity)
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

                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreCupo = _dataProvider.GetParameter();
                padreCupo.ParameterName = "Cupo";
                padreCupo.DbType = DbType.Int32;
                padreCupo.Value = (object)entity.Cupo ?? DBNull.Value;

                var padreUbicacion_externa = _dataProvider.GetParameter();
                padreUbicacion_externa.ParameterName = "Ubicacion_externa";
                padreUbicacion_externa.DbType = DbType.Int32;
                padreUbicacion_externa.Value = (object)entity.Ubicacion_externa ?? DBNull.Value;

                var padreNombre_del_Lugar = _dataProvider.GetParameter();
                padreNombre_del_Lugar.ParameterName = "Nombre_del_Lugar";
                padreNombre_del_Lugar.DbType = DbType.String;
                padreNombre_del_Lugar.Value = (object)entity.Nombre_del_Lugar ?? DBNull.Value;
                var padreEmpresa = _dataProvider.GetParameter();
                padreEmpresa.ParameterName = "Empresa";
                padreEmpresa.DbType = DbType.Int32;
                padreEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsUbicaciones_Eventos_Empresa>("sp_InsUbicaciones_Eventos_Empresa" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombre
, padreDescripcion
, padreCupo
, padreUbicacion_externa
, padreNombre_del_Lugar
, padreEmpresa
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

        public int Update(Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa entity)
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

                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdCupo = _dataProvider.GetParameter();
                paramUpdCupo.ParameterName = "Cupo";
                paramUpdCupo.DbType = DbType.Int32;
                paramUpdCupo.Value = (object)entity.Cupo ?? DBNull.Value;

                var paramUpdUbicacion_externa = _dataProvider.GetParameter();
                paramUpdUbicacion_externa.ParameterName = "Ubicacion_externa";
                paramUpdUbicacion_externa.DbType = DbType.Int32;
                paramUpdUbicacion_externa.Value = (object)entity.Ubicacion_externa ?? DBNull.Value;

                var paramUpdNombre_del_Lugar = _dataProvider.GetParameter();
                paramUpdNombre_del_Lugar.ParameterName = "Nombre_del_Lugar";
                paramUpdNombre_del_Lugar.DbType = DbType.String;
                paramUpdNombre_del_Lugar.Value = (object)entity.Nombre_del_Lugar ?? DBNull.Value;
                var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdUbicaciones_Eventos_Empresa>("sp_UpdUbicaciones_Eventos_Empresa" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre , paramUpdDescripcion , paramUpdCupo , paramUpdUbicacion_externa , paramUpdNombre_del_Lugar , paramUpdEmpresa , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa Ubicaciones_Eventos_EmpresaDB = GetByKey(entity.Folio, false);
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
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdCupo = _dataProvider.GetParameter();
                paramUpdCupo.ParameterName = "Cupo";
                paramUpdCupo.DbType = DbType.Int32;
                paramUpdCupo.Value = (object)entity.Cupo ?? DBNull.Value;
		var paramUpdUbicacion_externa = _dataProvider.GetParameter();
                paramUpdUbicacion_externa.ParameterName = "Ubicacion_externa";
                paramUpdUbicacion_externa.DbType = DbType.Int32;
                paramUpdUbicacion_externa.Value = (object)entity.Ubicacion_externa ?? DBNull.Value;
                var paramUpdNombre_del_Lugar = _dataProvider.GetParameter();
                paramUpdNombre_del_Lugar.ParameterName = "Nombre_del_Lugar";
                paramUpdNombre_del_Lugar.DbType = DbType.String;
                paramUpdNombre_del_Lugar.Value = (object)entity.Nombre_del_Lugar ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdUbicaciones_Eventos_Empresa>("sp_UpdUbicaciones_Eventos_Empresa" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre , paramUpdDescripcion , paramUpdCupo , paramUpdUbicacion_externa , paramUpdNombre_del_Lugar , paramUpdEmpresa , paramUpdEstatus ).FirstOrDefault();

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


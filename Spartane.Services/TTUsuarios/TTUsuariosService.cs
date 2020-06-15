using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.TTUsuarios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.TTUsuarios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class TTUsuariosService : ITTUsuariosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.TTUsuarios.TTUsuarios> _TTUsuariosRepository;
        #endregion

        #region Ctor
        public TTUsuariosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.TTUsuarios.TTUsuarios> TTUsuariosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._TTUsuariosRepository = TTUsuariosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._TTUsuariosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.TTUsuarios.TTUsuarios>("sp_SelAllTTUsuarios");
        }

        public IList<Core.Classes.TTUsuarios.TTUsuarios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTTUsuarios_Complete>("sp_SelAllComplete_TTUsuarios");
            return data.Select(m => new Core.Classes.TTUsuarios.TTUsuarios
            {
                IdUsuario = Convert.ToInt32(m.idUsuario)
                ,Nombre = m.Nombre
                ,Clave_de_Acceso = m.Clave_de_Acceso
                ,Contrasena = m.Contrasena
                ,Activo = m.Activo
                ,idGrupoUsuarios = Convert.ToInt32(m.idGrupoUsuarios)
            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_TTUsuarios>("sp_ListSelCount_TTUsuarios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                Order = Order.Substring(1, Order.Length - 2);
                Where = Where.Substring(1, Where.Length - 2);

                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTTUsuarios>("sp_ListSelAll_TTUsuarios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.TTUsuarios.TTUsuarios
                {
                    IdUsuario =Convert.ToInt32( m.TTUsuarios_idUsuario),
                    Nombre = m.TTUsuarios_Nombre,
                    Clave_de_Acceso = m.TTUsuarios_Clave_de_Acceso,
                    Contrasena = m.TTUsuarios_Contrasena,
                    Activo = m.TTUsuarios_Activo ?? false,
                    idGrupoUsuarios = Convert.ToInt32(m.TTUsuarios_idGrupoUsuarios),

                    Id = m.Id,
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

        public IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._TTUsuariosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._TTUsuariosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.TTUsuarios.TTUsuariosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTTUsuarios>("sp_ListSelAll_TTUsuarios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            TTUsuariosPagingModel result = null;

            if (data != null)
            {
                result = new TTUsuariosPagingModel
                {
                    TTUsuarioss =
                        data.Select(m => new Spartane.Core.Classes.TTUsuarios.TTUsuarios
                {
                    IdUsuario = Convert.ToInt32(m.TTUsuarios_idUsuario)
                    ,Nombre = m.TTUsuarios_Nombre
                    ,Clave_de_Acceso = m.TTUsuarios_Clave_de_Acceso
                    ,Contrasena = m.TTUsuarios_Contrasena
                    ,Activo = m.TTUsuarios_Activo ?? false
                    ,idGrupoUsuarios = Convert.ToInt32(m.TTUsuarios_idGrupoUsuarios)

                    ,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._TTUsuariosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.TTUsuarios.TTUsuarios GetByKey(int? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "idUsuario";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.TTUsuarios.TTUsuarios>("sp_GetTTUsuarios", padreKey).SingleOrDefault();
        }

        public bool Delete(int? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "idUsuario";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTTUsuarios>("sp_DelTTUsuarios", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result == 1;
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

        public int Insert(Spartane.Core.Classes.TTUsuarios.TTUsuarios entity)
        {
            int rta;
            try
            {

		                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = entity.Nombre;
                var padreClave_de_Acceso = _dataProvider.GetParameter();
                padreClave_de_Acceso.ParameterName = "Clave_de_Acceso";
                padreClave_de_Acceso.DbType = DbType.String;
                padreClave_de_Acceso.Value = entity.Clave_de_Acceso;
                var padreContrasena = _dataProvider.GetParameter();
                padreContrasena.ParameterName = "Contrasena";
                padreContrasena.DbType = DbType.String;
                padreContrasena.Value = entity.Contrasena;
                var padreActivo = _dataProvider.GetParameter();
                padreActivo.ParameterName = "Activo";
                padreActivo.DbType = DbType.Boolean;
                padreActivo.Value = entity.Activo;
                var padreidGrupoUsuarios = _dataProvider.GetParameter();
                padreidGrupoUsuarios.ParameterName = "idGrupoUsuarios";
                padreidGrupoUsuarios.DbType = DbType.Int32;
                padreidGrupoUsuarios.Value = entity.idGrupoUsuarios;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTTUsuarios>("sp_InsTTUsuarios" , padreNombre
, padreClave_de_Acceso
, padreContrasena
, padreActivo
, padreidGrupoUsuarios
).FirstOrDefault();

                rta = empEntity.idUsuario;

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

        public int Update(Spartane.Core.Classes.TTUsuarios.TTUsuarios entity)
        {
            int rta;
            try
            {

                var padreidUsuario = _dataProvider.GetParameter();
                padreidUsuario.ParameterName = "idUsuario";
                padreidUsuario.DbType = DbType.Int32;
                padreidUsuario.Value = entity.IdUsuario;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = entity.Nombre;
                var padreClave_de_Acceso = _dataProvider.GetParameter();
                padreClave_de_Acceso.ParameterName = "Clave_de_Acceso";
                padreClave_de_Acceso.DbType = DbType.String;
                padreClave_de_Acceso.Value = entity.Clave_de_Acceso;
                var padreContrasena = _dataProvider.GetParameter();
                padreContrasena.ParameterName = "Contrasena";
                padreContrasena.DbType = DbType.String;
                padreContrasena.Value = entity.Contrasena;
                var padreActivo = _dataProvider.GetParameter();
                padreActivo.ParameterName = "Activo";
                padreActivo.DbType = DbType.Boolean;
                padreActivo.Value = entity.Activo;
                var padreidGrupoUsuarios = _dataProvider.GetParameter();
                padreidGrupoUsuarios.ParameterName = "idGrupoUsuarios";
                padreidGrupoUsuarios.DbType = DbType.Int32;
                padreidGrupoUsuarios.Value = entity.idGrupoUsuarios;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTTUsuarios>("sp_UpdTTUsuarios" , padreidUsuario , padreNombre , padreClave_de_Acceso , padreContrasena , padreActivo , padreidGrupoUsuarios ).FirstOrDefault();

                rta = empEntity.idUsuario;
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


using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_ChangePasswordAutorization;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_ChangePasswordAutorization
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_ChangePasswordAutorizationService : ISpartan_ChangePasswordAutorizationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> _Spartan_ChangePasswordAutorizationRepository;
        #endregion

        #region Ctor
        public Spartan_ChangePasswordAutorizationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> Spartan_ChangePasswordAutorizationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_ChangePasswordAutorizationRepository = Spartan_ChangePasswordAutorizationRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>("sp_SelAllSpartan_ChangePasswordAutorization");
        }

        public IList<Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_ChangePasswordAutorization_Complete>("sp_SelAllComplete_Spartan_ChangePasswordAutorization");
            return data.Select(m => new Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization
            {
                Clave = m.Clave
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario.GetValueOrDefault(), Name = m.Usuario_Name }
                ,Estatus_SpartanChangePasswordAutorizationEstatus = new Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Email = m.Email


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_ChangePasswordAutorization>("sp_ListSelCount_Spartan_ChangePasswordAutorization", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_ChangePasswordAutorization>("sp_ListSelAll_Spartan_ChangePasswordAutorization", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization
                {
                    Clave = m.Spartan_ChangePasswordAutorization_Clave,
                    Fecha_de_Registro = m.Spartan_ChangePasswordAutorization_Fecha_de_Registro,
                    Hora_de_Registro = m.Spartan_ChangePasswordAutorization_Hora_de_Registro,
                    Usuario = m.Spartan_ChangePasswordAutorization_Usuario,
                    Estatus = m.Spartan_ChangePasswordAutorization_Estatus,
                    Email = m.Spartan_ChangePasswordAutorization_Email,

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

        public IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_ChangePasswordAutorization>("sp_ListSelAll_Spartan_ChangePasswordAutorization", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_ChangePasswordAutorizationPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_ChangePasswordAutorizationPagingModel
                {
                    Spartan_ChangePasswordAutorizations =
                        data.Select(m => new Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization
                {
                    Clave = m.Spartan_ChangePasswordAutorization_Clave
                    ,Fecha_de_Registro = m.Spartan_ChangePasswordAutorization_Fecha_de_Registro
                    ,Hora_de_Registro = m.Spartan_ChangePasswordAutorization_Hora_de_Registro
                    ,Usuario = m.Spartan_ChangePasswordAutorization_Usuario
                    ,Usuario_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_ChangePasswordAutorization_Usuario.GetValueOrDefault(), Name = m.Spartan_ChangePasswordAutorization_Usuario_Name }
                    ,Estatus = m.Spartan_ChangePasswordAutorization_Estatus
                    ,Estatus_SpartanChangePasswordAutorizationEstatus = new Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus() { Clave = m.Spartan_ChangePasswordAutorization_Estatus.GetValueOrDefault(), Descripcion = m.Spartan_ChangePasswordAutorization_Estatus_Descripcion }
                    ,Email = m.Spartan_ChangePasswordAutorization_Email

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>("sp_GetSpartan_ChangePasswordAutorization", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_ChangePasswordAutorization>("sp_DelSpartan_ChangePasswordAutorization", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity)
        {
            int rta;
            try
            {

		                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario = _dataProvider.GetParameter();
                padreUsuario.ParameterName = "Usuario";
                padreUsuario.DbType = DbType.Int32;
                padreUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_ChangePasswordAutorization>("sp_InsSpartan_ChangePasswordAutorization" 
, padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario
, padreEstatus
, padreEmail
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

        public int Update(Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.Int32;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_ChangePasswordAutorization>("sp_UpdSpartan_ChangePasswordAutorization" , paramUpdClave , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario , paramUpdEstatus , paramUpdEmail ).FirstOrDefault();

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

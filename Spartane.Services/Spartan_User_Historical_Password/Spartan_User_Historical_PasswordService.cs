using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User_Historical_Password;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Historical_Password
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_Historical_PasswordService : ISpartan_User_Historical_PasswordService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password> _Spartan_User_Historical_PasswordRepository;
        #endregion

        #region Ctor
        public Spartan_User_Historical_PasswordService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password> Spartan_User_Historical_PasswordRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_Historical_PasswordRepository = Spartan_User_Historical_PasswordRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password>("sp_SelAllSpartan_User_Historical_Password");
        }

        public IList<Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Historical_Password_Complete>("sp_SelAllComplete_Spartan_User_Historical_Password");
            return data.Select(m => new Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password
            {
                Clave = m.Clave
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Usuario_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario.GetValueOrDefault(), Name = m.Usuario_Name }
                ,Password = m.Password


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User_Historical_Password>("sp_ListSelCount_Spartan_User_Historical_Password", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Historical_Password>("sp_ListSelAll_Spartan_User_Historical_Password", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password
                {
                    Clave = m.Spartan_User_Historical_Password_Clave,
                    Fecha_de_Registro = m.Spartan_User_Historical_Password_Fecha_de_Registro,
                    Usuario = m.Spartan_User_Historical_Password_Usuario,
                    Password = m.Spartan_User_Historical_Password_Password,

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

        public IList<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_PasswordPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User_Historical_Password>("sp_ListSelAll_Spartan_User_Historical_Password", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_User_Historical_PasswordPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_User_Historical_PasswordPagingModel
                {
                    Spartan_User_Historical_Passwords =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password
                {
                    Clave = m.Spartan_User_Historical_Password_Clave
                    ,Fecha_de_Registro = m.Spartan_User_Historical_Password_Fecha_de_Registro
                    ,Usuario = m.Spartan_User_Historical_Password_Usuario
                    ,Usuario_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Spartan_User_Historical_Password_Usuario.GetValueOrDefault(), Name = m.Spartan_User_Historical_Password_Usuario_Name }
                    ,Password = m.Spartan_User_Historical_Password_Password

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password>("sp_GetSpartan_User_Historical_Password", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User_Historical_Password>("sp_DelSpartan_User_Historical_Password", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password entity)
        {
            int rta;
            try
            {

		                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreUsuario = _dataProvider.GetParameter();
                padreUsuario.ParameterName = "Usuario";
                padreUsuario.DbType = DbType.Int32;
                padreUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var padrePassword = _dataProvider.GetParameter();
                padrePassword.ParameterName = "Password";
                padrePassword.DbType = DbType.String;
                padrePassword.Value = (object)entity.Password ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User_Historical_Password>("sp_InsSpartan_User_Historical_Password" 
, padreFecha_de_Registro
, padreUsuario
, padrePassword
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

        public int Update(Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password entity)
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

                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.Int32;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var paramUpdPassword = _dataProvider.GetParameter();
                paramUpdPassword.ParameterName = "Password";
                paramUpdPassword.DbType = DbType.String;
                paramUpdPassword.Value = (object)entity.Password ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User_Historical_Password>("sp_UpdSpartan_User_Historical_Password" , paramUpdClave , paramUpdFecha_de_Registro , paramUpdUsuario , paramUpdPassword ).FirstOrDefault();

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

using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_User;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_UserService : ISpartan_UserService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User.Spartan_User> _Spartan_UserRepository;
        #endregion

        #region Ctor
        public Spartan_UserService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User.Spartan_User> Spartan_UserRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_UserRepository = Spartan_UserRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_UserRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_User.Spartan_User> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User.Spartan_User>("sp_SelAllSpartan_User");
        }

        public IList<Core.Classes.Spartan_User.Spartan_User> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_User_Complete>("sp_SelAllComplete_Spartan_User");
            return data.Select(m => new Core.Classes.Spartan_User.Spartan_User
            {
                Id_User = m.Id_User
                ,Name = m.Name
                ,Role_Spartan_User_Role = new Core.Classes.Spartan_User_Role.Spartan_User_Role() { User_Role_Id = m.Role.GetValueOrDefault(), Description = m.Role_Description }
                ,Image = m.Image
                ,Email = m.Email
                ,Status_Spartan_User_Status = new Core.Classes.Spartan_User_Status.Spartan_User_Status() { User_Status_Id = m.Status.GetValueOrDefault(), Description = m.Status_Description }
                ,Username = m.Username
                ,Password = m.Password


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_User>("sp_ListSelCount_Spartan_User", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_User.Spartan_User> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User>("sp_ListSelAll_Spartan_User", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_User.Spartan_User
                {
                    Id_User = m.Spartan_User_Id_User,
                    Name = m.Spartan_User_Name,
                    Role = m.Spartan_User_Role,
                    Image = m.Spartan_User_Image,
                    Email = m.Spartan_User_Email,
                    Status = m.Spartan_User_Status,
                    Username = m.Spartan_User_Username,
                    Password = m.Spartan_User_Password,

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

        public IList<Spartane.Core.Classes.Spartan_User.Spartan_User> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_UserRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_User.Spartan_User> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_UserRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User.Spartan_UserPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_User>("sp_ListSelAll_Spartan_User", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_UserPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_UserPagingModel
                {
                    Spartan_Users =
                        data.Select(m => new Spartane.Core.Classes.Spartan_User.Spartan_User
                {
                    Id_User = m.Spartan_User_Id_User
                    ,Name = m.Spartan_User_Name
                    ,Role = m.Spartan_User_Role
                    ,Role_Spartan_User_Role = new Core.Classes.Spartan_User_Role.Spartan_User_Role() { User_Role_Id = m.Spartan_User_Role.GetValueOrDefault(), Description = m.Spartan_User_Role_Description }
                    ,Image = m.Spartan_User_Image
                    ,Email = m.Spartan_User_Email
                    ,Status = m.Spartan_User_Status
                    ,Status_Spartan_User_Status = new Core.Classes.Spartan_User_Status.Spartan_User_Status() { User_Status_Id = m.Spartan_User_Status.GetValueOrDefault(), Description = m.Spartan_User_Status_Description }
                    ,Username = m.Spartan_User_Username
                    ,Password = m.Spartan_User_Password

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_User.Spartan_User> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_UserRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_User.Spartan_User GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Id_User";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_User.Spartan_User>("sp_GetSpartan_User", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Id_User";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_User>("sp_DelSpartan_User", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_User.Spartan_User entity)
        {
            int rta;
            try
            {

		                var padreName = _dataProvider.GetParameter();
                padreName.ParameterName = "Name";
                padreName.DbType = DbType.String;
                padreName.Value = (object)entity.Name ?? DBNull.Value;
                var padreRole = _dataProvider.GetParameter();
                padreRole.ParameterName = "Role";
                padreRole.DbType = DbType.Int32;
                padreRole.Value = (object)entity.Role ?? DBNull.Value;

                var padreImage = _dataProvider.GetParameter();
                padreImage.ParameterName = "Image";
                padreImage.DbType = DbType.Int32;
                padreImage.Value = (object)entity.Image ?? DBNull.Value;

                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
                var padreStatus = _dataProvider.GetParameter();
                padreStatus.ParameterName = "Status";
                padreStatus.DbType = DbType.Int32;
                padreStatus.Value = (object)entity.Status ?? DBNull.Value;

                var padreUsername = _dataProvider.GetParameter();
                padreUsername.ParameterName = "Username";
                padreUsername.DbType = DbType.String;
                padreUsername.Value = (object)entity.Username ?? DBNull.Value;
                var padrePassword = _dataProvider.GetParameter();
                padrePassword.ParameterName = "Password";
                padrePassword.DbType = DbType.String;
                padrePassword.Value = (object)entity.Password ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_User>("sp_InsSpartan_User" 
, padreName
, padreRole
, padreImage
, padreEmail
, padreStatus
, padreUsername
, padrePassword
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Id_User);

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

        public int Update(Spartane.Core.Classes.Spartan_User.Spartan_User entity)
        {
            int rta;
            try
            {

                var paramUpdId_User = _dataProvider.GetParameter();
                paramUpdId_User.ParameterName = "Id_User";
                paramUpdId_User.DbType = DbType.Int32;
                paramUpdId_User.Value = (object)entity.Id_User ?? DBNull.Value;
                var paramUpdName = _dataProvider.GetParameter();
                paramUpdName.ParameterName = "Name";
                paramUpdName.DbType = DbType.String;
                paramUpdName.Value = (object)entity.Name ?? DBNull.Value;
                var paramUpdRole = _dataProvider.GetParameter();
                paramUpdRole.ParameterName = "Role";
                paramUpdRole.DbType = DbType.Int32;
                paramUpdRole.Value = (object)entity.Role ?? DBNull.Value;

                var paramUpdImage = _dataProvider.GetParameter();
                paramUpdImage.ParameterName = "Image";
                paramUpdImage.DbType = DbType.Int32;
                paramUpdImage.Value = (object)entity.Image ?? DBNull.Value;

                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdStatus = _dataProvider.GetParameter();
                paramUpdStatus.ParameterName = "Status";
                paramUpdStatus.DbType = DbType.Int32;
                paramUpdStatus.Value = (object)entity.Status ?? DBNull.Value;

                var paramUpdUsername = _dataProvider.GetParameter();
                paramUpdUsername.ParameterName = "Username";
                paramUpdUsername.DbType = DbType.String;
                paramUpdUsername.Value = (object)entity.Username ?? DBNull.Value;
                var paramUpdPassword = _dataProvider.GetParameter();
                paramUpdPassword.ParameterName = "Password";
                paramUpdPassword.DbType = DbType.String;
                paramUpdPassword.Value = (object)entity.Password ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_User>("sp_UpdSpartan_User" , paramUpdId_User , paramUpdName , paramUpdRole , paramUpdImage , paramUpdEmail , paramUpdStatus , paramUpdUsername , paramUpdPassword ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Id_User);
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

using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Data.EF;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Additional_Menu;

namespace Spartane.Services.Spartan_Additional_Menu
{
    public class Spartan_Additional_Menu : ISpartan_Additional_Menu
    {
        #region Fields

        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_User.Spartan_User> _Spartan_UserRepository;

        #endregion

        #region Constructor

        public Spartan_Additional_Menu(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_User.Spartan_User> Spartan_UserRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_UserRepository = Spartan_UserRepository;
        }

        #endregion

        #region Public

        public IList<Spartane.Core.Classes.Spartan_Additional_Menu.Spartan_Additional_Menu> GetMenu(int user, int languageId)
        {
            DbParameter Parameter = new SqlParameter("UserId", user);
            DbParameter Parameter2 = new SqlParameter("LanguageId", languageId);
            return _dbContext.
                ExecuteStoredProcedureList<Core.Classes.Spartan_Additional_Menu.Spartan_Additional_Menu>("spGetAdditionalMenu", Parameter, Parameter2).ToList();
        }

        #endregion


    }
}

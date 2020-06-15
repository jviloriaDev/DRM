using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Data.EF;

namespace Spartane.Services.CustomAuthentication
{
    public partial class CustomAuthenticationService : ICustomAuthenticationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        // private List<Spartane.Core.Domain.User.TTUsuario> _TTUsuario;
        private readonly IRepository<Spartane.Core.Classes.TTUsuarios.TTUsuarios> _TTUsuarioRepositary;
        #endregion

        #region Ctor
        public CustomAuthenticationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.TTUsuarios.TTUsuarios> TTUsuarioRepositary)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._TTUsuarioRepositary = TTUsuarioRepositary;
        }
        #endregion

        #region CRUD Operations

        public Spartane.Core.Classes.TTUsuarios.TTUsuarios GetUserDetails(string userName, string password)
        {
            
            return _TTUsuarioRepositary.Table.FirstOrDefault(m => m.Clave_de_Acceso == userName && m.Contrasena == password);
        }

        #endregion
    }
}

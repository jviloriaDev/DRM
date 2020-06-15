using System;
using Spartane.Core.Classes.Spartan_User_Role;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Role
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_RoleService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role entity);
        IList<Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Role.Spartan_User_RolePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

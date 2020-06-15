using System;
using Spartane.Core.Classes.Spartan_User;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_UserService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User.Spartan_User> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User.Spartan_User> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User.Spartan_User> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User.Spartan_User GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User.Spartan_User entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User.Spartan_User entity);
        IList<Spartane.Core.Classes.Spartan_User.Spartan_User> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User.Spartan_User> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User.Spartan_UserPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User.Spartan_User> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

using System;
using Spartane.Core.Classes.Spartan_User_Role_Status;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Role_Status
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_Role_StatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status entity);
        IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

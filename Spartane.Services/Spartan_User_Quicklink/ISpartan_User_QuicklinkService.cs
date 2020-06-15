using System;
using Spartane.Core.Classes.Spartan_User_Quicklink;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Quicklink
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_QuicklinkService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink entity);
        IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_QuicklinkPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

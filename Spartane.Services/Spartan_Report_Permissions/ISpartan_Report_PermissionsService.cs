using System;
using Spartane.Core.Classes.Spartan_Report_Permissions;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Report_Permissions
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Report_PermissionsService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions entity);
        IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_PermissionsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

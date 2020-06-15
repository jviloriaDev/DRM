using System;
using Spartane.Core.Classes.Spartan_System_Layout;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_System_Layout
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_System_LayoutService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout entity);
        Int32 Update(Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout entity);
        IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_LayoutPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

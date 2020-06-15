using System;
using Spartane.Core.Classes.Spartan_System;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_System
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_SystemService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_System.Spartan_System> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_System.Spartan_System> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_System.Spartan_System> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_System.Spartan_System GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_System.Spartan_System entity);
        Int32 Update(Spartane.Core.Classes.Spartan_System.Spartan_System entity);
        IList<Spartane.Core.Classes.Spartan_System.Spartan_System> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_System.Spartan_System> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_System.Spartan_SystemPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_System.Spartan_System> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

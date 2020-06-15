using System;
using Spartane.Core.Classes.Spartan_Session_Log;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Session_Log
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Session_LogService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log entity);
        IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_LogPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

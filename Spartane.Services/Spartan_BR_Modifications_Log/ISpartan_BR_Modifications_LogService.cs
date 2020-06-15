using System;
using Spartane.Core.Classes.Spartan_BR_Modifications_Log;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Modifications_Log
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Modifications_LogService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity);
        Int32 Update(Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity);
        IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_LogPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

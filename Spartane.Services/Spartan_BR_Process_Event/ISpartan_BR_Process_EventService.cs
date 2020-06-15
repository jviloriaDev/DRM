using System;
using Spartane.Core.Classes.Spartan_BR_Process_Event;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Process_Event
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Process_EventService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event entity);
        Int16 Update(Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event entity);
        IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_EventPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

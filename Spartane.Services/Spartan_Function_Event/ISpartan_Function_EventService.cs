using System;
using Spartane.Core.Classes.Spartan_Function_Event;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Function_Event
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Function_EventService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event entity);
        IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_EventPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

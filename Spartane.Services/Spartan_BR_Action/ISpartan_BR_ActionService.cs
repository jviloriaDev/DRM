using System;
using Spartane.Core.Classes.Spartan_BR_Action;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Action
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_ActionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action entity);
        Int32 Update(Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action entity);
        IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_ActionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

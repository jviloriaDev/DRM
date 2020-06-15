using System;
using Spartane.Core.Classes.Spartan_WorkFlow_State;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow_State
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_StateService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State entity);
        Int32 Update(Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_StatePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

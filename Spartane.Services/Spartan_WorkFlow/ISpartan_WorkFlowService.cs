using System;
using Spartane.Core.Classes.Spartan_WorkFlow;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlowService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow entity);
        Int32 Update(Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlowPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

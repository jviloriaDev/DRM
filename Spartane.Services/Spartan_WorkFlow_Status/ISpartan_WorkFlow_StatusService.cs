using System;
using Spartane.Core.Classes.Spartan_WorkFlow_Status;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow_Status
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_StatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status entity);
        Int16 Update(Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

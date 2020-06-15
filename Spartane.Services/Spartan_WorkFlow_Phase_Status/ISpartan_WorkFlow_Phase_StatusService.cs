using System;
using Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow_Phase_Status
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_Phase_StatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status entity);
        Int16 Update(Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

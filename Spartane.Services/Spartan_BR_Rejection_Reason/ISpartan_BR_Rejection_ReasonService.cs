using System;
using Spartane.Core.Classes.Spartan_BR_Rejection_Reason;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Rejection_Reason
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Rejection_ReasonService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason entity);
        Int32 Update(Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason entity);
        IList<Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

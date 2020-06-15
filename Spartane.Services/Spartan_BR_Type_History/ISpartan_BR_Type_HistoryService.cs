using System;
using Spartane.Core.Classes.Spartan_BR_Type_History;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Type_History
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Type_HistoryService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History entity);
        Int32 Update(Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History entity);
        IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_HistoryPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

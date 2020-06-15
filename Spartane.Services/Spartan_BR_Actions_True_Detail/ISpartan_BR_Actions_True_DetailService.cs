using System;
using Spartane.Core.Classes.Spartan_BR_Actions_True_Detail;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Actions_True_Detail
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Actions_True_DetailService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail entity);
        Int32 Update(Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail entity);
        IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

using System;
using Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Operation_Restrictions_Detail
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Operation_Restrictions_DetailService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail entity);
        Int32 Update(Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail entity);
        IList<Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Operation_Restrictions_Detail.Spartan_BR_Operation_Restrictions_Detail> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

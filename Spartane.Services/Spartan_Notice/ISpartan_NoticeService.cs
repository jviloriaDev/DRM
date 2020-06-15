using System;
using Spartane.Core.Classes.Spartan_Notice;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Notice
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_NoticeService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Notice.Spartan_Notice GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Notice.Spartan_Notice entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Notice.Spartan_Notice entity);
        IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Notice.Spartan_NoticePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

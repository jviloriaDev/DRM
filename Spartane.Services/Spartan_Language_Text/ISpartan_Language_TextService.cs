using System;
using Spartane.Core.Classes.Spartan_Language_Text;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Language_Text
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Language_TextService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text entity);
        IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_TextPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

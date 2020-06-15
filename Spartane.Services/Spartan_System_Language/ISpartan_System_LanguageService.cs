using System;
using Spartane.Core.Classes.Spartan_System_Language;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_System_Language
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_System_LanguageService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language entity);
        Int32 Update(Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language entity);
        IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_System_Language.Spartan_System_LanguagePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

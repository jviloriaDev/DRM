using System;
using Spartane.Core.Classes.Spartan_Traduction_Language;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Traduction_Language
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Traduction_LanguageService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language entity);
        IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_LanguagePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

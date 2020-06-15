using System;
using Spartane.Core.Classes.Spartan_Business_Rule;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Business_Rule
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Business_RuleService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule entity);
        IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_RulePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

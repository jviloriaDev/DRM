using System;
using Spartane.Core.Classes.Spartan_BR_Condition;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Condition
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_ConditionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition entity);
        Int16 Update(Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition entity);
        IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_ConditionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

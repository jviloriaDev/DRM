using System;
using Spartane.Core.Classes.Spartan_WorkFlow_Condition;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow_Condition
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_ConditionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition entity);
        Int16 Update(Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_ConditionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

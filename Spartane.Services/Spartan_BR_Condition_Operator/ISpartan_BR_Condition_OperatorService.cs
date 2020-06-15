using System;
using Spartane.Core.Classes.Spartan_BR_Condition_Operator;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Condition_Operator
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Condition_OperatorService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator entity);
        Int16 Update(Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator entity);
        IList<Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

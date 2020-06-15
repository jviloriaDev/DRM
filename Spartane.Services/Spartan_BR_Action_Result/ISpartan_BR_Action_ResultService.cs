using System;
using Spartane.Core.Classes.Spartan_BR_Action_Result;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Action_Result
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Action_ResultService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result entity);
        Int16 Update(Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result entity);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_ResultPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

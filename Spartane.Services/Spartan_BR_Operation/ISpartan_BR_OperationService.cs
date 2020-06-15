using System;
using Spartane.Core.Classes.Spartan_BR_Operation;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Operation
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_OperationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation entity);
        Int16 Update(Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation entity);
        IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_OperationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

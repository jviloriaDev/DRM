using System;
using Spartane.Core.Classes.Spartan_BR_Scope;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Scope
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_ScopeService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope entity);
        Int16 Update(Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope entity);
        IList<Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_ScopePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

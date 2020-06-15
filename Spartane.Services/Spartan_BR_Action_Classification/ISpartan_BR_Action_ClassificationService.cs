using System;
using Spartane.Core.Classes.Spartan_BR_Action_Classification;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Action_Classification
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Action_ClassificationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity);
        Int16 Update(Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

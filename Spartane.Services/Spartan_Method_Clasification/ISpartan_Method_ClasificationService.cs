using System;
using Spartane.Core.Classes.Spartan_Method_Clasification;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Method_Clasification
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Method_ClasificationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification entity);
        IList<Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_ClasificationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

using System;
using Spartane.Core.Classes.Spartan_Format_Related;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Format_Related
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Format_RelatedService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related entity);
        IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_RelatedPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

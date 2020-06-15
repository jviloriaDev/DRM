using System;
using Spartane.Core.Classes.Spartan_Format;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Format
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_FormatService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Format.Spartan_Format GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Format.Spartan_Format entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Format.Spartan_Format entity);
        IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Format.Spartan_FormatPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Format.Spartan_Format> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

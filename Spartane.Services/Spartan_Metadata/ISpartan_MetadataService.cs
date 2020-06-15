using System;
using Spartane.Core.Classes.Spartan_Metadata;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Metadata
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_MetadataService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata entity);
        IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Metadata.Spartan_MetadataPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

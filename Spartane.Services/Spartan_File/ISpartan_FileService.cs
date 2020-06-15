using System;
using Spartane.Core.Classes.Spartane_File;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_File
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_FileService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartane_File.Spartane_File> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartane_File.Spartane_File> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartane_File.Spartane_File> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartane_File.Spartane_File GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartane_File.Spartane_File entity);
        Int32 Update(Spartane.Core.Classes.Spartane_File.Spartane_File entity);
        IList<Spartane.Core.Classes.Spartane_File.Spartane_File> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartane_File.Spartane_File> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartane_File.Spartane_FilePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartane_File.Spartane_File> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

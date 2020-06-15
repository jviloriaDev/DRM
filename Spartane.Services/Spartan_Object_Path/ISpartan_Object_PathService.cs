using System;
using Spartane.Core.Classes.Spartan_Object_Path;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Object_Path
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Object_PathService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path entity);
        IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_PathPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

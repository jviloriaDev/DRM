using System;
using Spartane.Core.Classes.Spartan_Object;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Object
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_ObjectService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Object.Spartan_Object GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Object.Spartan_Object entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Object.Spartan_Object entity);
        IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Object.Spartan_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Object.Spartan_Object> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

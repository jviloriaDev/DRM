using System;
using Spartane.Core.Classes.Spartan_Bitacora_SQL;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Bitacora_SQL
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Bitacora_SQLService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity);
        IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

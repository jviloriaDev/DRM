using System;
using Spartane.Core.Classes.Spartan_Traduction_Process_Data;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Traduction_Process_Data
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Traduction_Process_DataService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data entity);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel ListaSelAll(int object_id, int process);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

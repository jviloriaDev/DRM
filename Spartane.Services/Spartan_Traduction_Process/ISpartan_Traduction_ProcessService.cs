using System;
using Spartane.Core.Classes.Spartan_Traduction_Process;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Traduction_Process
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Traduction_ProcessService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process entity);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_ProcessPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

using System;
using Spartane.Core.Classes.Spartan_Traduction_Process_Workflow;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Traduction_Process_Workflow
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Traduction_Process_WorkflowService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow entity);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_WorkflowPagingModel ListaSelAll(int object_id, int process);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

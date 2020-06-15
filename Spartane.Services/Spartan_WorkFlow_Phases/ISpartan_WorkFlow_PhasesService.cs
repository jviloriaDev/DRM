using System;
using Spartane.Core.Classes.Spartan_WorkFlow_Phases;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow_Phases
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_PhasesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases entity);
        Int32 Update(Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_PhasesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

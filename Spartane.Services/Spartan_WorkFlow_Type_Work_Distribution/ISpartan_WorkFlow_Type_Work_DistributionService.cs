using System;
using Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow_Type_Work_Distribution
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_Type_Work_DistributionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution entity);
        Int16 Update(Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_DistributionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

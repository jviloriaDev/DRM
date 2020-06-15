using System;
using Spartane.Core.Classes.Spartan_Report_Advance_Filter;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Report_Advance_Filter
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Report_Advance_FilterService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter entity);
        IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_FilterPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

using System;
using Spartane.Core.Classes.Spartan_Report;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Report
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_ReportService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Report.Spartan_Report GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Report.Spartan_Report entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Report.Spartan_Report entity);
        IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Report.Spartan_ReportPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Report.Spartan_Report> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

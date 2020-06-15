using System;
using Spartane.Core.Classes.Spartan_Report_Presentation_View;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Report_Presentation_View
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Report_Presentation_ViewService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity);
        IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

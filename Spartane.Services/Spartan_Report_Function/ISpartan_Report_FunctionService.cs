using System;
using Spartane.Core.Classes.Spartan_Report_Function;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Report_Function
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Report_FunctionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function entity);
        IList<Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_FunctionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

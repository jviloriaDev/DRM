using System;
using Spartane.Core.Classes.Spartan_Method_Type_Function;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Method_Type_Function
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Method_Type_FunctionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function entity);
        IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_FunctionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

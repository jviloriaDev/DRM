using System;
using Spartane.Core.Classes.Spartan_Module_Object_Method;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Module_Object_Method
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Module_Object_MethodService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method entity);
        IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_MethodPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Module_Object_Method.Spartan_Module_Object_Method> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

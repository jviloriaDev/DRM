using System;
using Spartane.Core.Classes.Spartan_User_Rule_Object_Function;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Rule_Object_Function
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_Rule_Object_FunctionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function GetByKey(int? Key, Boolean ConRelaciones);
        //Added parameter SpartanUserRule
        bool Delete(int? Key,int SpartanUserRule);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function entity);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_FunctionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

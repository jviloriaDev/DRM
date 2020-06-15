using System;
using Spartane.Core.Classes.Spartan_User_Most_Used_Object;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Most_Used_Object
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_Most_Used_ObjectService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object entity);
        IList<Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

using System;
using Spartane.Core.Classes.Spartan_User_Favorite_Object;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Favorite_Object
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_Favorite_ObjectService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object entity);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

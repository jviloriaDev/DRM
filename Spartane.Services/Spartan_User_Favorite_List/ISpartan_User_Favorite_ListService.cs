using System;
using Spartane.Core.Classes.Spartan_User_Favorite_List;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Favorite_List
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_Favorite_ListService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List entity);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_ListPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

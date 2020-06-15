using System;
using Spartane.Core.Classes.Spartan_User_Alert;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Alert
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_AlertService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert entity);
        IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_AlertPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

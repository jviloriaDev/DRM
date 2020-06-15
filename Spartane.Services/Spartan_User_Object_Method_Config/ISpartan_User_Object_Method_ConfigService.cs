using System;
using Spartane.Core.Classes.Spartan_User_Object_Method_Config;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Object_Method_Config
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_Object_Method_ConfigService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config entity);
        IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_ConfigPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

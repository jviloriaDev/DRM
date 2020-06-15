using System;
using Spartane.Core.Classes.Spartan_Object_Config;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Object_Config
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Object_ConfigService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config entity);
        IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_ConfigPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

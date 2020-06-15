using System;
using Spartane.Core.Classes.Spartan_Module_Config;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Module_Config
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Module_ConfigService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config entity);
        IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_ConfigPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

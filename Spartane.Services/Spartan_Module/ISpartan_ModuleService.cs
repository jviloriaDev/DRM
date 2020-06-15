using System;
using Spartane.Core.Classes.Spartan_Module;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Module
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_ModuleService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Module.Spartan_Module GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Module.Spartan_Module entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Module.Spartan_Module entity);
        IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Module.Spartan_ModulePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Module.Spartan_Module> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

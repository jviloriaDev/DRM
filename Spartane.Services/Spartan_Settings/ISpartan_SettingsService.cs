using System;
using Spartane.Core.Classes.Spartan_Settings;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Settings
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_SettingsService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Settings.Spartan_Settings GetByKey(string Key, Boolean ConRelaciones);
        bool Delete(string Key);
        String Insert(Spartane.Core.Classes.Spartan_Settings.Spartan_Settings entity);
        String Update(Spartane.Core.Classes.Spartan_Settings.Spartan_Settings entity);
        IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Settings.Spartan_SettingsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Settings.Spartan_Settings> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

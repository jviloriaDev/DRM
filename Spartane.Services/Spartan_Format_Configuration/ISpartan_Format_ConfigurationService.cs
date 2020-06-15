using System;
using Spartane.Core.Classes.Spartan_Format_Configuration;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Format_Configuration
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Format_ConfigurationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration entity);
        IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_ConfigurationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

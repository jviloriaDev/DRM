using System;
using Spartane.Core.Classes.Spartan_Object_Method_Characteristic;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Object_Method_Characteristic
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Object_Method_CharacteristicService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic entity);
        IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_CharacteristicPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

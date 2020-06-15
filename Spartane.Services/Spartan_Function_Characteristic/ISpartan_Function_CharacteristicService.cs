using System;
using Spartane.Core.Classes.Spartan_Function_Characteristic;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Function_Characteristic
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Function_CharacteristicService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic entity);
        IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_CharacteristicPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

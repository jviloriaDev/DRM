using System;
using Spartane.Core.Classes.Spartan_Menu_Orientation;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Menu_Orientation
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Menu_OrientationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation entity);
        IList<Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_OrientationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

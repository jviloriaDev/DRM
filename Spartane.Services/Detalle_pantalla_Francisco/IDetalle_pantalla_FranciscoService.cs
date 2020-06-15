using System;
using Spartane.Core.Classes.Detalle_pantalla_Francisco;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_pantalla_Francisco
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_pantalla_FranciscoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco entity);
        Int32 Update(Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco entity);
        IList<Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_FranciscoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco entity);

    }
}

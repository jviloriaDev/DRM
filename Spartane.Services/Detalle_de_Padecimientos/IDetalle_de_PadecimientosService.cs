using System;
using Spartane.Core.Classes.Detalle_de_Padecimientos;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_de_Padecimientos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_PadecimientosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos entity);
        Int32 Update(Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos entity);
        IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos entity);

    }
}

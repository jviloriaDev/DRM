using System;
using Spartane.Core.Classes.Detalle_Pagos_Especialistas;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Pagos_Especialistas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Pagos_EspecialistasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas entity);
        IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas entity);

    }
}

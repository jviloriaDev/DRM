using System;
using Spartane.Core.Classes.Detalle_Sucursales_Proveedores;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Sucursales_Proveedores
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Sucursales_ProveedoresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores entity);
        IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores entity);

    }
}

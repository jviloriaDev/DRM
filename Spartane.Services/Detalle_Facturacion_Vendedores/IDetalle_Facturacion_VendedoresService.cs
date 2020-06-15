using System;
using Spartane.Core.Classes.Detalle_Facturacion_Vendedores;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Facturacion_Vendedores
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Facturacion_VendedoresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores entity);
        IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_VendedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores entity);

    }
}

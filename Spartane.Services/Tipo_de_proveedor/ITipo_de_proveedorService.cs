using System;
using Spartane.Core.Classes.Tipo_de_proveedor;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_proveedor
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_proveedorService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor entity);
        IList<Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor entity);

    }
}

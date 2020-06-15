using System;
using Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores;
using System.Collections.Generic;


namespace Spartane.Services.Planes_de_Suscripcion_Proveedores
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPlanes_de_Suscripcion_ProveedoresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity);
        Int32 Update(Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity);
        IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity);

    }
}

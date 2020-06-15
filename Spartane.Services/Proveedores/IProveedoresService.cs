using System;
using Spartane.Core.Classes.Proveedores;
using System.Collections.Generic;


namespace Spartane.Services.Proveedores
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IProveedoresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Proveedores.Proveedores> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Proveedores.Proveedores> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Proveedores.Proveedores> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Proveedores.Proveedores GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Proveedores.Proveedores entity);
        Int32 Update(Spartane.Core.Classes.Proveedores.Proveedores entity);
        IList<Spartane.Core.Classes.Proveedores.Proveedores> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Proveedores.Proveedores> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Proveedores.ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Proveedores.Proveedores> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Proveedores.Proveedores entity);
       int Update_Datos_de_Contacto(Spartane.Core.Classes.Proveedores.Proveedores entity);
       int Update_Red_de_Proveedores(Spartane.Core.Classes.Proveedores.Proveedores entity);
       int Update_Datos_Fiscales(Spartane.Core.Classes.Proveedores.Proveedores entity);

    }
}

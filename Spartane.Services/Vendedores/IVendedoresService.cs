using System;
using Spartane.Core.Classes.Vendedores;
using System.Collections.Generic;


namespace Spartane.Services.Vendedores
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IVendedoresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Vendedores.Vendedores> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Vendedores.Vendedores> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Vendedores.Vendedores> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Vendedores.Vendedores GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Vendedores.Vendedores entity);
        Int32 Update(Spartane.Core.Classes.Vendedores.Vendedores entity);
        IList<Spartane.Core.Classes.Vendedores.Vendedores> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Vendedores.Vendedores> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Vendedores.VendedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Vendedores.Vendedores> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Vendedores.Vendedores entity);
       int Update_Codigos_de_Referencia(Spartane.Core.Classes.Vendedores.Vendedores entity);
       int Update_Datos_Bancarios(Spartane.Core.Classes.Vendedores.Vendedores entity);
       int Update_Facturacion(Spartane.Core.Classes.Vendedores.Vendedores entity);

    }
}

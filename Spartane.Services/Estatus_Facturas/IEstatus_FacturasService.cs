using System;
using Spartane.Core.Classes.Estatus_Facturas;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_Facturas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_FacturasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas entity);
        Int32 Update(Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas entity);
        IList<Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_Facturas.Estatus_FacturasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas entity);

    }
}

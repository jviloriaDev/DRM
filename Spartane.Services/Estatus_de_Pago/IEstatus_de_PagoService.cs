using System;
using Spartane.Core.Classes.Estatus_de_Pago;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_de_Pago
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_de_PagoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago entity);
        Int32 Update(Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago entity);
        IList<Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_PagoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago entity);

    }
}

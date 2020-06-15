using System;
using Spartane.Core.Classes.Detalle_Preferencia_Bebidas;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Preferencia_Bebidas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Preferencia_BebidasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity);
        IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity);

    }
}

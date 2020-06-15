using System;
using Spartane.Core.Classes.Detalle_Codigos_Referidos;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Codigos_Referidos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Codigos_ReferidosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity);
        IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_ReferidosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity);

    }
}

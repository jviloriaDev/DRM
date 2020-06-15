using System;
using Spartane.Core.Classes.Padecimientos;
using System.Collections.Generic;


namespace Spartane.Services.Padecimientos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPadecimientosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Padecimientos.Padecimientos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Padecimientos.Padecimientos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Padecimientos.Padecimientos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Padecimientos.Padecimientos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Padecimientos.Padecimientos entity);
        Int32 Update(Spartane.Core.Classes.Padecimientos.Padecimientos entity);
        IList<Spartane.Core.Classes.Padecimientos.Padecimientos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Padecimientos.Padecimientos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Padecimientos.PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Padecimientos.Padecimientos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Padecimientos.Padecimientos entity);

    }
}

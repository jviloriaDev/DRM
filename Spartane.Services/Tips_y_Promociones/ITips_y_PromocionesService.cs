using System;
using Spartane.Core.Classes.Tips_y_Promociones;
using System.Collections.Generic;


namespace Spartane.Services.Tips_y_Promociones
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITips_y_PromocionesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones entity);
        Int32 Update(Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones entity);
        IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tips_y_Promociones.Tips_y_PromocionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones entity);

    }
}

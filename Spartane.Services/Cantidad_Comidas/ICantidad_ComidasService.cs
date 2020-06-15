using System;
using Spartane.Core.Classes.Cantidad_Comidas;
using System.Collections.Generic;


namespace Spartane.Services.Cantidad_Comidas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICantidad_ComidasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas entity);
        Int32 Update(Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas entity);
        IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Cantidad_Comidas.Cantidad_ComidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas entity);

    }
}

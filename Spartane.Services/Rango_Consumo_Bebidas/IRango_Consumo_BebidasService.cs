using System;
using Spartane.Core.Classes.Rango_Consumo_Bebidas;
using System.Collections.Generic;


namespace Spartane.Services.Rango_Consumo_Bebidas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRango_Consumo_BebidasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity);
        Int32 Update(Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity);
        IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity);

    }
}

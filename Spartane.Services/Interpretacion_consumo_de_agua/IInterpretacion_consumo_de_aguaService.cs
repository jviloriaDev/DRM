using System;
using Spartane.Core.Classes.Interpretacion_consumo_de_agua;
using System.Collections.Generic;


namespace Spartane.Services.Interpretacion_consumo_de_agua
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_consumo_de_aguaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua entity);
        Int32 Update(Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua entity);
        IList<Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_aguaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua entity);

    }
}

using System;
using Spartane.Core.Classes.Frecuencia_Sustancias;
using System.Collections.Generic;


namespace Spartane.Services.Frecuencia_Sustancias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IFrecuencia_SustanciasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias entity);
        Int32 Update(Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias entity);
        IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_SustanciasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias entity);

    }
}

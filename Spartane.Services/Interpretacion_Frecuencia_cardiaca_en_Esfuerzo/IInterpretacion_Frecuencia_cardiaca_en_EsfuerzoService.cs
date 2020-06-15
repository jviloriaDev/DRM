using System;
using Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using System.Collections.Generic;


namespace Spartane.Services.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo entity);
        Int32 Update(Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo entity);
        IList<Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_EsfuerzoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo entity);

    }
}

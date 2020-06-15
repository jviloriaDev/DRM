using System;
using Spartane.Core.Classes.Dias_de_la_semana;
using System.Collections.Generic;


namespace Spartane.Services.Dias_de_la_semana
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDias_de_la_semanaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana entity);
        Int32 Update(Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana entity);
        IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semanaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana entity);

    }
}

using System;
using Spartane.Core.Classes.Rango_de_Horas;
using System.Collections.Generic;


namespace Spartane.Services.Rango_de_Horas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRango_de_HorasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas entity);
        Int32 Update(Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas entity);
        IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Rango_de_Horas.Rango_de_HorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas entity);

    }
}

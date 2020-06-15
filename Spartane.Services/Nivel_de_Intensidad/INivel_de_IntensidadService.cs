using System;
using Spartane.Core.Classes.Nivel_de_Intensidad;
using System.Collections.Generic;


namespace Spartane.Services.Nivel_de_Intensidad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface INivel_de_IntensidadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad entity);
        Int32 Update(Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad entity);
        IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad entity);

    }
}

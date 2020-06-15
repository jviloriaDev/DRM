using System;
using Spartane.Core.Classes.Nivel_de_Satisfaccion;
using System.Collections.Generic;


namespace Spartane.Services.Nivel_de_Satisfaccion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface INivel_de_SatisfaccionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity);
        Int32 Update(Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity);
        IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_SatisfaccionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity);

    }
}

using System;
using Spartane.Core.Classes.Calificacion;
using System.Collections.Generic;


namespace Spartane.Services.Calificacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICalificacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Calificacion.Calificacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Calificacion.Calificacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Calificacion.Calificacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Calificacion.Calificacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Calificacion.Calificacion entity);
        Int32 Update(Spartane.Core.Classes.Calificacion.Calificacion entity);
        IList<Spartane.Core.Classes.Calificacion.Calificacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Calificacion.Calificacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Calificacion.CalificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Calificacion.Calificacion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Calificacion.Calificacion entity);

    }
}

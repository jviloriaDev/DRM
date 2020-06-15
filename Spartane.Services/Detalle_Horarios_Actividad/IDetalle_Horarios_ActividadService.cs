using System;
using Spartane.Core.Classes.Detalle_Horarios_Actividad;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Horarios_Actividad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Horarios_ActividadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity);
        IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_ActividadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity);

    }
}

using System;
using Spartane.Core.Classes.Estatus_Reservaciones_Actividad;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_Reservaciones_Actividad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_Reservaciones_ActividadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity);
        Int32 Update(Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity);
        IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_ActividadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity);

    }
}

using System;
using Spartane.Core.Classes.Estatus_Actividades_Evento;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_Actividades_Evento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_Actividades_EventoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento entity);
        Int32 Update(Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento entity);
        IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento entity);

    }
}

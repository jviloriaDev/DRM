using System;
using Spartane.Core.Classes.Estatus_Eventos;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_Eventos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_EventosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos entity);
        Int32 Update(Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos entity);
        IList<Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_Eventos.Estatus_EventosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos entity);

    }
}

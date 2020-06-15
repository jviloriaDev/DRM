using System;
using Spartane.Core.Classes.Eventos;
using System.Collections.Generic;


namespace Spartane.Services.Eventos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEventosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Eventos.Eventos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Eventos.Eventos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Eventos.Eventos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Eventos.Eventos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Eventos.Eventos entity);
        Int32 Update(Spartane.Core.Classes.Eventos.Eventos entity);
        IList<Spartane.Core.Classes.Eventos.Eventos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Eventos.Eventos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Eventos.EventosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Eventos.Eventos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Eventos.Eventos entity);
       int Update_Actividades(Spartane.Core.Classes.Eventos.Eventos entity);

    }
}

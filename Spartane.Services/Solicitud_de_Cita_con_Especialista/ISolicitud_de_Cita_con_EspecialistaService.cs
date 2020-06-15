using System;
using Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista;
using System.Collections.Generic;


namespace Spartane.Services.Solicitud_de_Cita_con_Especialista
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISolicitud_de_Cita_con_EspecialistaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity);
        Int32 Update(Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity);
        IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_EspecialistaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity);
       int Update_Solicitud(Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity);

    }
}

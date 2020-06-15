using System;
using Spartane.Core.Classes.Respuesta_Logica;
using System.Collections.Generic;


namespace Spartane.Services.Respuesta_Logica
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRespuesta_LogicaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica entity);
        Int32 Update(Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica entity);
        IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Respuesta_Logica.Respuesta_LogicaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica entity);

    }
}

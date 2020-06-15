using System;
using Spartane.Core.Classes.Estatus_Llamadas;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_Llamadas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_LlamadasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas entity);
        Int32 Update(Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas entity);
        IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_Llamadas.Estatus_LlamadasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas entity);

    }
}

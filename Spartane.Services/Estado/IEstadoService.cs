using System;
using Spartane.Core.Classes.Estado;
using System.Collections.Generic;


namespace Spartane.Services.Estado
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstadoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estado.Estado> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estado.Estado> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estado.Estado> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estado.Estado GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estado.Estado entity);
        Int32 Update(Spartane.Core.Classes.Estado.Estado entity);
        IList<Spartane.Core.Classes.Estado.Estado> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estado.Estado> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estado.EstadoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estado.Estado> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estado.Estado entity);

    }
}

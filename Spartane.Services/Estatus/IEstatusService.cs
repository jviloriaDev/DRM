using System;
using Spartane.Core.Classes.Estatus;
using System.Collections.Generic;


namespace Spartane.Services.Estatus
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus.Estatus> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus.Estatus> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus.Estatus> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus.Estatus GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus.Estatus entity);
        Int32 Update(Spartane.Core.Classes.Estatus.Estatus entity);
        IList<Spartane.Core.Classes.Estatus.Estatus> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus.Estatus> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus.EstatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus.Estatus> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus.Estatus entity);

    }
}

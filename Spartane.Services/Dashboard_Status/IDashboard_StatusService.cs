using System;
using Spartane.Core.Classes.Dashboard_Status;
using System.Collections.Generic;


namespace Spartane.Services.Dashboard_Status
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDashboard_StatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Dashboard_Status.Dashboard_Status GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Dashboard_Status.Dashboard_Status entity);
        Int16 Update(Spartane.Core.Classes.Dashboard_Status.Dashboard_Status entity);
        IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Dashboard_Status.Dashboard_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status> ListaSelAll(Boolean ConRelaciones, string Where);
              short Update_Datos_Generales(Spartane.Core.Classes.Dashboard_Status.Dashboard_Status entity);

    }
}

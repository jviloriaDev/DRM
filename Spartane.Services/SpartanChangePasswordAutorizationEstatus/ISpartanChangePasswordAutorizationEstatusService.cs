using System;
using Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus;
using System.Collections.Generic;


namespace Spartane.Services.SpartanChangePasswordAutorizationEstatus
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartanChangePasswordAutorizationEstatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity);
        Int32 Update(Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity);
        IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

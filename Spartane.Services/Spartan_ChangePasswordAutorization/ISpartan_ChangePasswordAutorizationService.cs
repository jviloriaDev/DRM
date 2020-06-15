using System;
using Spartane.Core.Classes.Spartan_ChangePasswordAutorization;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_ChangePasswordAutorization
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_ChangePasswordAutorizationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity);
        Int32 Update(Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity);
        IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

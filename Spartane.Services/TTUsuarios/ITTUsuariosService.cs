using System;
using Spartane.Core.Classes.TTUsuarios;
using System.Collections.Generic;


namespace Spartane.Services.TTUsuarios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITTUsuariosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.TTUsuarios.TTUsuarios GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key);
        Int32 Insert(Spartane.Core.Classes.TTUsuarios.TTUsuarios entity);
        Int32 Update(Spartane.Core.Classes.TTUsuarios.TTUsuarios entity);
        IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.TTUsuarios.TTUsuariosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.TTUsuarios.TTUsuarios> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

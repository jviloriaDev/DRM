using System;
using Spartane.Core.Classes.Estado_Civil;
using System.Collections.Generic;


namespace Spartane.Services.Estado_Civil
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstado_CivilService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estado_Civil.Estado_Civil> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estado_Civil.Estado_Civil> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estado_Civil.Estado_Civil> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estado_Civil.Estado_Civil GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estado_Civil.Estado_Civil entity);
        Int32 Update(Spartane.Core.Classes.Estado_Civil.Estado_Civil entity);
        IList<Spartane.Core.Classes.Estado_Civil.Estado_Civil> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estado_Civil.Estado_Civil> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estado_Civil.Estado_CivilPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estado_Civil.Estado_Civil> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estado_Civil.Estado_Civil entity);

    }
}

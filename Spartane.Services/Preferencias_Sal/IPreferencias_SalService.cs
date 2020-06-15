using System;
using Spartane.Core.Classes.Preferencias_Sal;
using System.Collections.Generic;


namespace Spartane.Services.Preferencias_Sal
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPreferencias_SalService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal entity);
        Int32 Update(Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal entity);
        IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Preferencias_Sal.Preferencias_SalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal entity);

    }
}

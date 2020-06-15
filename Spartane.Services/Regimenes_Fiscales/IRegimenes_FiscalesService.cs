using System;
using Spartane.Core.Classes.Regimenes_Fiscales;
using System.Collections.Generic;


namespace Spartane.Services.Regimenes_Fiscales
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegimenes_FiscalesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales entity);
        Int32 Update(Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales entity);
        IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_FiscalesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales entity);

    }
}

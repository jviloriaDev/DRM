using System;
using Spartane.Core.Classes.Aseguradoras;
using System.Collections.Generic;


namespace Spartane.Services.Aseguradoras
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IAseguradorasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Aseguradoras.Aseguradoras> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Aseguradoras.Aseguradoras> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Aseguradoras.Aseguradoras> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Aseguradoras.Aseguradoras GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Aseguradoras.Aseguradoras entity);
        Int32 Update(Spartane.Core.Classes.Aseguradoras.Aseguradoras entity);
        IList<Spartane.Core.Classes.Aseguradoras.Aseguradoras> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Aseguradoras.Aseguradoras> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Aseguradoras.AseguradorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Aseguradoras.Aseguradoras> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Aseguradoras.Aseguradoras entity);

    }
}

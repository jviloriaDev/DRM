using System;
using Spartane.Core.Classes.Redes_sociales;
using System.Collections.Generic;


namespace Spartane.Services.Redes_sociales
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRedes_socialesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Redes_sociales.Redes_sociales GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Redes_sociales.Redes_sociales entity);
        Int32 Update(Spartane.Core.Classes.Redes_sociales.Redes_sociales entity);
        IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Redes_sociales.Redes_socialesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Redes_sociales.Redes_sociales> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Redes_sociales.Redes_sociales entity);

    }
}

using System;
using Spartane.Core.Classes.Identificaciones_Oficiales;
using System.Collections.Generic;


namespace Spartane.Services.Identificaciones_Oficiales
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IIdentificaciones_OficialesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales entity);
        Int32 Update(Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales entity);
        IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_OficialesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales entity);

    }
}

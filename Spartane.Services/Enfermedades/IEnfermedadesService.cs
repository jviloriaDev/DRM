using System;
using Spartane.Core.Classes.Enfermedades;
using System.Collections.Generic;


namespace Spartane.Services.Enfermedades
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEnfermedadesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Enfermedades.Enfermedades> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Enfermedades.Enfermedades> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Enfermedades.Enfermedades> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Enfermedades.Enfermedades GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Enfermedades.Enfermedades entity);
        Int32 Update(Spartane.Core.Classes.Enfermedades.Enfermedades entity);
        IList<Spartane.Core.Classes.Enfermedades.Enfermedades> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Enfermedades.Enfermedades> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Enfermedades.EnfermedadesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Enfermedades.Enfermedades> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Enfermedades.Enfermedades entity);

    }
}

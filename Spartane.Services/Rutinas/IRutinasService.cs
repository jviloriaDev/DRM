using System;
using Spartane.Core.Classes.Rutinas;
using System.Collections.Generic;


namespace Spartane.Services.Rutinas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRutinasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Rutinas.Rutinas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Rutinas.Rutinas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Rutinas.Rutinas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Rutinas.Rutinas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Rutinas.Rutinas entity);
        Int32 Update(Spartane.Core.Classes.Rutinas.Rutinas entity);
        IList<Spartane.Core.Classes.Rutinas.Rutinas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Rutinas.Rutinas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Rutinas.RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Rutinas.Rutinas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Rutinas.Rutinas entity);

    }
}

using System;
using Spartane.Core.Classes.Sustancias;
using System.Collections.Generic;


namespace Spartane.Services.Sustancias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISustanciasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Sustancias.Sustancias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Sustancias.Sustancias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Sustancias.Sustancias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Sustancias.Sustancias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Sustancias.Sustancias entity);
        Int32 Update(Spartane.Core.Classes.Sustancias.Sustancias entity);
        IList<Spartane.Core.Classes.Sustancias.Sustancias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Sustancias.Sustancias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Sustancias.SustanciasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Sustancias.Sustancias> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Sustancias.Sustancias entity);

    }
}

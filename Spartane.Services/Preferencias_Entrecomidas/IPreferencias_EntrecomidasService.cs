using System;
using Spartane.Core.Classes.Preferencias_Entrecomidas;
using System.Collections.Generic;


namespace Spartane.Services.Preferencias_Entrecomidas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPreferencias_EntrecomidasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas entity);
        Int32 Update(Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas entity);
        IList<Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_EntrecomidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas entity);

    }
}

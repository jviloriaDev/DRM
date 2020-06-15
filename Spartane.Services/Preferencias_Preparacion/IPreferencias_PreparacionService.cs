using System;
using Spartane.Core.Classes.Preferencias_Preparacion;
using System.Collections.Generic;


namespace Spartane.Services.Preferencias_Preparacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPreferencias_PreparacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion entity);
        Int32 Update(Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion entity);
        IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_PreparacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion entity);

    }
}

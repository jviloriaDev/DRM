using System;
using Spartane.Core.Classes.Preferencias_Grasas;
using System.Collections.Generic;


namespace Spartane.Services.Preferencias_Grasas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPreferencias_GrasasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas entity);
        Int32 Update(Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas entity);
        IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Preferencias_Grasas.Preferencias_GrasasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas entity);

    }
}

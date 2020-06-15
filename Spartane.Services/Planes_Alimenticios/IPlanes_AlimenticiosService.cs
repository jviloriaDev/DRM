using System;
using Spartane.Core.Classes.Planes_Alimenticios;
using System.Collections.Generic;


namespace Spartane.Services.Planes_Alimenticios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPlanes_AlimenticiosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios entity);
        Int32 Update(Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios entity);
        IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Planes_Alimenticios.Planes_AlimenticiosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios entity);

    }
}

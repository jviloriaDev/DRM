using System;
using Spartane.Core.Classes.Detalle_Planes_Alimenticios;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Planes_Alimenticios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Planes_AlimenticiosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios entity);
        IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_AlimenticiosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios entity);

    }
}

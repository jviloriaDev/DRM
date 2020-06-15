using System;
using Spartane.Core.Classes.Tiempo_Padecimiento;
using System.Collections.Generic;


namespace Spartane.Services.Tiempo_Padecimiento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITiempo_PadecimientoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento entity);
        Int32 Update(Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento entity);
        IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_PadecimientoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento entity);

    }
}

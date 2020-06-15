using System;
using Spartane.Core.Classes.Estatus_Padecimiento;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_Padecimiento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_PadecimientoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento entity);
        Int32 Update(Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento entity);
        IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_Padecimiento.Estatus_PadecimientoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento entity);

    }
}

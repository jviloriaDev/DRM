using System;
using Spartane.Core.Classes.Detalle_Pagos_Paciente;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Pagos_Paciente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Pagos_PacienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente entity);
        IList<Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente entity);

    }
}

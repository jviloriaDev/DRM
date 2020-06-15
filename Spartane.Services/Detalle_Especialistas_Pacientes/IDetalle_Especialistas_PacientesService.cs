using System;
using Spartane.Core.Classes.Detalle_Especialistas_Pacientes;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Especialistas_Pacientes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Especialistas_PacientesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity);
        IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity);

    }
}

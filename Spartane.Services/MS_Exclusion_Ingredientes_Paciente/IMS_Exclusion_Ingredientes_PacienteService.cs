using System;
using Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente;
using System.Collections.Generic;


namespace Spartane.Services.MS_Exclusion_Ingredientes_Paciente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Exclusion_Ingredientes_PacienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity);
        Int32 Update(Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity);
        IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity);

    }
}

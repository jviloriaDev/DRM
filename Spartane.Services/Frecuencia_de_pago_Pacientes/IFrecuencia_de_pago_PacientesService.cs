using System;
using Spartane.Core.Classes.Frecuencia_de_pago_Pacientes;
using System.Collections.Generic;


namespace Spartane.Services.Frecuencia_de_pago_Pacientes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IFrecuencia_de_pago_PacientesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes entity);
        Int32 Update(Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes entity);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes entity);

    }
}

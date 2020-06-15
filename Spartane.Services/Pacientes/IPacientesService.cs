using System;
using Spartane.Core.Classes.Pacientes;
using System.Collections.Generic;


namespace Spartane.Services.Pacientes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPacientesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Pacientes.Pacientes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Pacientes.Pacientes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Pacientes.Pacientes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Pacientes.Pacientes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Pacientes.Pacientes entity);
        Int32 Update(Spartane.Core.Classes.Pacientes.Pacientes entity);
        IList<Spartane.Core.Classes.Pacientes.Pacientes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Pacientes.Pacientes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Pacientes.PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Pacientes.Pacientes> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Pacientes.Pacientes entity);
       int Update_Padecimientos(Spartane.Core.Classes.Pacientes.Pacientes entity);
       int Update_Antecedentes(Spartane.Core.Classes.Pacientes.Pacientes entity);
       int Update_Mediciones_Iniciales(Spartane.Core.Classes.Pacientes.Pacientes entity);
       int Update_Datos_Ginecologicos(Spartane.Core.Classes.Pacientes.Pacientes entity);
       int Update_Historia_Nutricional(Spartane.Core.Classes.Pacientes.Pacientes entity);
       int Update_Estilo_de_Vida(Spartane.Core.Classes.Pacientes.Pacientes entity);
       int Update_Resultados(Spartane.Core.Classes.Pacientes.Pacientes entity);
       int Update_Suscripcion(Spartane.Core.Classes.Pacientes.Pacientes entity);

    }
}

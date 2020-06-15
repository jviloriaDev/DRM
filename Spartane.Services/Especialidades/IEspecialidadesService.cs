using System;
using Spartane.Core.Classes.Especialidades;
using System.Collections.Generic;


namespace Spartane.Services.Especialidades
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEspecialidadesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Especialidades.Especialidades> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Especialidades.Especialidades> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Especialidades.Especialidades> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Especialidades.Especialidades GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Especialidades.Especialidades entity);
        Int32 Update(Spartane.Core.Classes.Especialidades.Especialidades entity);
        IList<Spartane.Core.Classes.Especialidades.Especialidades> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Especialidades.Especialidades> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Especialidades.EspecialidadesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Especialidades.Especialidades> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Especialidades.Especialidades entity);

    }
}

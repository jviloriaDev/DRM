using System;
using Spartane.Core.Classes.Profesiones;
using System.Collections.Generic;


namespace Spartane.Services.Profesiones
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IProfesionesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Profesiones.Profesiones> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Profesiones.Profesiones> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Profesiones.Profesiones> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Profesiones.Profesiones GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Profesiones.Profesiones entity);
        Int32 Update(Spartane.Core.Classes.Profesiones.Profesiones entity);
        IList<Spartane.Core.Classes.Profesiones.Profesiones> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Profesiones.Profesiones> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Profesiones.ProfesionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Profesiones.Profesiones> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Profesiones.Profesiones entity);

    }
}

using System;
using Spartane.Core.Classes.Datos_Bancarios_Especialistas;
using System.Collections.Generic;


namespace Spartane.Services.Datos_Bancarios_Especialistas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDatos_Bancarios_EspecialistasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas entity);
        Int32 Update(Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas entity);
        IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas entity);

    }
}

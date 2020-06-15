using System;
using Spartane.Core.Classes.Tipos_de_Especialistas;
using System.Collections.Generic;


namespace Spartane.Services.Tipos_de_Especialistas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipos_de_EspecialistasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas entity);
        Int32 Update(Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas entity);
        IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas entity);

    }
}

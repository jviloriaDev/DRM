using System;
using Spartane.Core.Classes.Dashboard_Editor;
using System.Collections.Generic;


namespace Spartane.Services.Dashboard_Editor
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDashboard_EditorService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor entity);
        Int32 Update(Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor entity);
        IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Dashboard_Editor.Dashboard_EditorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor entity);
       int Update_Configuracion(Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor entity);

    }
}

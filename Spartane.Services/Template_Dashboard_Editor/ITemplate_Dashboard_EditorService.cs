using System;
using Spartane.Core.Classes.Template_Dashboard_Editor;
using System.Collections.Generic;


namespace Spartane.Services.Template_Dashboard_Editor
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITemplate_Dashboard_EditorService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor entity);
        Int32 Update(Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor entity);
        IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_EditorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor entity);

    }
}

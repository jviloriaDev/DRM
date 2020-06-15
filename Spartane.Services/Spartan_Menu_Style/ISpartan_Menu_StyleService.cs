using System;
using Spartane.Core.Classes.Spartan_Menu_Style;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Menu_Style
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Menu_StyleService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style entity);
        IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_StylePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

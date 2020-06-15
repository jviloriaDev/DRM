using System;
using Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Presentation_Control_Type
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Presentation_Control_TypeService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type entity);
        Int32 Update(Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type entity);
        IList<Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

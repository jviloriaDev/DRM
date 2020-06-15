using System;
using Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow_Type_Flow_Control
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_Type_Flow_ControlService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity);
        Int16 Update(Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

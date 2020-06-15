using System;
using Spartane.Core.Classes.SpartanObject;
using System.Collections.Generic;


namespace Spartane.Services.SpartanObject
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartanObjectService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.SpartanObject.SpartanObject> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.SpartanObject.SpartanObject> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.SpartanObject.SpartanObject> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.SpartanObject.SpartanObject GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.SpartanObject.SpartanObject entity);
        Int32 Update(Spartane.Core.Classes.SpartanObject.SpartanObject entity);
        IList<Spartane.Core.Classes.SpartanObject.SpartanObject> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.SpartanObject.SpartanObject> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.SpartanObject.SpartanObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.SpartanObject.SpartanObject> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

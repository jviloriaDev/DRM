using System;
using Spartane.Core.Classes.Spartan_Token_Type;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Token_Type
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Token_TypeService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type entity);
        IList<Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

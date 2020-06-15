using System;
using Spartane.Core.Classes.Spartan_Format_Field;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Format_Field
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Format_FieldService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field entity);
        IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_FieldPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

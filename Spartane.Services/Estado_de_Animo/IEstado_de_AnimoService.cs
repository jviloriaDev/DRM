using System;
using Spartane.Core.Classes.Estado_de_Animo;
using System.Collections.Generic;


namespace Spartane.Services.Estado_de_Animo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstado_de_AnimoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo entity);
        Int32 Update(Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo entity);
        IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estado_de_Animo.Estado_de_AnimoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo entity);

    }
}

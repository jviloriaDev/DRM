using System;
using Spartane.Core.Classes.Pais;
using System.Collections.Generic;


namespace Spartane.Services.Pais
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPaisService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Pais.Pais> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Pais.Pais> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Pais.Pais> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Pais.Pais GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Pais.Pais entity);
        Int32 Update(Spartane.Core.Classes.Pais.Pais entity);
        IList<Spartane.Core.Classes.Pais.Pais> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Pais.Pais> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Pais.PaisPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Pais.Pais> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Pais.Pais entity);

    }
}

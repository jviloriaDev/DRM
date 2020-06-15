using System;
using Spartane.Core.Classes.Suplementos;
using System.Collections.Generic;


namespace Spartane.Services.Suplementos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISuplementosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Suplementos.Suplementos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Suplementos.Suplementos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Suplementos.Suplementos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Suplementos.Suplementos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Suplementos.Suplementos entity);
        Int32 Update(Spartane.Core.Classes.Suplementos.Suplementos entity);
        IList<Spartane.Core.Classes.Suplementos.Suplementos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Suplementos.Suplementos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Suplementos.SuplementosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Suplementos.Suplementos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Suplementos.Suplementos entity);

    }
}

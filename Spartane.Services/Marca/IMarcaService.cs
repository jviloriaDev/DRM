using System;
using Spartane.Core.Classes.Marca;
using System.Collections.Generic;


namespace Spartane.Services.Marca
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMarcaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Marca.Marca> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Marca.Marca> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Marca.Marca> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Marca.Marca GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Marca.Marca entity);
        Int32 Update(Spartane.Core.Classes.Marca.Marca entity);
        IList<Spartane.Core.Classes.Marca.Marca> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Marca.Marca> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Marca.MarcaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Marca.Marca> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Marca.Marca entity);

    }
}

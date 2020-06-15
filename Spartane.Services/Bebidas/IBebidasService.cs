using System;
using Spartane.Core.Classes.Bebidas;
using System.Collections.Generic;


namespace Spartane.Services.Bebidas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IBebidasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Bebidas.Bebidas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Bebidas.Bebidas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Bebidas.Bebidas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Bebidas.Bebidas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Bebidas.Bebidas entity);
        Int32 Update(Spartane.Core.Classes.Bebidas.Bebidas entity);
        IList<Spartane.Core.Classes.Bebidas.Bebidas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Bebidas.Bebidas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Bebidas.BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Bebidas.Bebidas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Bebidas.Bebidas entity);

    }
}

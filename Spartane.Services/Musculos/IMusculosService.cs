using System;
using Spartane.Core.Classes.Musculos;
using System.Collections.Generic;


namespace Spartane.Services.Musculos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMusculosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Musculos.Musculos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Musculos.Musculos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Musculos.Musculos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Musculos.Musculos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Musculos.Musculos entity);
        Int32 Update(Spartane.Core.Classes.Musculos.Musculos entity);
        IList<Spartane.Core.Classes.Musculos.Musculos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Musculos.Musculos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Musculos.MusculosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Musculos.Musculos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Musculos.Musculos entity);

    }
}

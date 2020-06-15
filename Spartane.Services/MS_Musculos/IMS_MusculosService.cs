using System;
using Spartane.Core.Classes.MS_Musculos;
using System.Collections.Generic;


namespace Spartane.Services.MS_Musculos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_MusculosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_Musculos.MS_Musculos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_Musculos.MS_Musculos entity);
        Int32 Update(Spartane.Core.Classes.MS_Musculos.MS_Musculos entity);
        IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_Musculos.MS_MusculosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_Musculos.MS_Musculos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_Musculos.MS_Musculos entity);

    }
}

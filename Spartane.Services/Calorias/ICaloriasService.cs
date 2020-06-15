using System;
using Spartane.Core.Classes.Calorias;
using System.Collections.Generic;


namespace Spartane.Services.Calorias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICaloriasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Calorias.Calorias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Calorias.Calorias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Calorias.Calorias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Calorias.Calorias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Calorias.Calorias entity);
        Int32 Update(Spartane.Core.Classes.Calorias.Calorias entity);
        IList<Spartane.Core.Classes.Calorias.Calorias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Calorias.Calorias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Calorias.CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Calorias.Calorias> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Calorias.Calorias entity);

    }
}

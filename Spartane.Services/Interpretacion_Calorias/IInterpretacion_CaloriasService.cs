using System;
using Spartane.Core.Classes.Interpretacion_Calorias;
using System.Collections.Generic;


namespace Spartane.Services.Interpretacion_Calorias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_CaloriasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias entity);
        Int32 Update(Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias entity);
        IList<Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias entity);

    }
}

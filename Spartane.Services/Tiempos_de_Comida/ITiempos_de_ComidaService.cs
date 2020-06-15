using System;
using Spartane.Core.Classes.Tiempos_de_Comida;
using System.Collections.Generic;


namespace Spartane.Services.Tiempos_de_Comida
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITiempos_de_ComidaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida entity);
        Int32 Update(Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida entity);
        IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_ComidaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida entity);

    }
}

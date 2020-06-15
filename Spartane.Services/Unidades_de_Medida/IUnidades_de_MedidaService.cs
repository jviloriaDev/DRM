using System;
using Spartane.Core.Classes.Unidades_de_Medida;
using System.Collections.Generic;


namespace Spartane.Services.Unidades_de_Medida
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IUnidades_de_MedidaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida entity);
        Int32 Update(Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida entity);
        IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_MedidaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida entity);

    }
}

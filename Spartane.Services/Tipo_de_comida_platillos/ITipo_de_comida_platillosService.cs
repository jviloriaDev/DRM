using System;
using Spartane.Core.Classes.Tipo_de_comida_platillos;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_comida_platillos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_comida_platillosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos entity);
        IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos entity);

    }
}

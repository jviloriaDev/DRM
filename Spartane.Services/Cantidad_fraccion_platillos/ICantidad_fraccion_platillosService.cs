using System;
using Spartane.Core.Classes.Cantidad_fraccion_platillos;
using System.Collections.Generic;


namespace Spartane.Services.Cantidad_fraccion_platillos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICantidad_fraccion_platillosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity);
        Int32 Update(Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity);
        IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity);

    }
}

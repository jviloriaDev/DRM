using System;
using Spartane.Core.Classes.Presentacion;
using System.Collections.Generic;


namespace Spartane.Services.Presentacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPresentacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Presentacion.Presentacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Presentacion.Presentacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Presentacion.Presentacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Presentacion.Presentacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Presentacion.Presentacion entity);
        Int32 Update(Spartane.Core.Classes.Presentacion.Presentacion entity);
        IList<Spartane.Core.Classes.Presentacion.Presentacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Presentacion.Presentacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Presentacion.PresentacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Presentacion.Presentacion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Presentacion.Presentacion entity);

    }
}

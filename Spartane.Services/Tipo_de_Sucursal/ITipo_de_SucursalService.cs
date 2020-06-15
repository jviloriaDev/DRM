using System;
using Spartane.Core.Classes.Tipo_de_Sucursal;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_Sucursal
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_SucursalService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal entity);
        IList<Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_SucursalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal entity);

    }
}

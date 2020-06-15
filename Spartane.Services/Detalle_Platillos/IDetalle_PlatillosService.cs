﻿using System;
using Spartane.Core.Classes.Detalle_Platillos;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Platillos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_PlatillosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity);
        IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Platillos.Detalle_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity);

    }
}

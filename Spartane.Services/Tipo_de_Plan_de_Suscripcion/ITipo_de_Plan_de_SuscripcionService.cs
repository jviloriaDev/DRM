﻿using System;
using Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_Plan_de_Suscripcion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_Plan_de_SuscripcionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion entity);
        IList<Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_SuscripcionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion entity);

    }
}

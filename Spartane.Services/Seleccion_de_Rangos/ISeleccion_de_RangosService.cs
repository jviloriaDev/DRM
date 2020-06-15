using System;
using Spartane.Core.Classes.Seleccion_de_Rangos;
using System.Collections.Generic;


namespace Spartane.Services.Seleccion_de_Rangos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISeleccion_de_RangosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos entity);
        Int32 Update(Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos entity);
        IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_RangosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos entity);

    }
}

using System;
using Spartane.Core.Classes.Detalle_Resultados_Consultas;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Resultados_Consultas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Resultados_ConsultasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity);
        IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity);

    }
}

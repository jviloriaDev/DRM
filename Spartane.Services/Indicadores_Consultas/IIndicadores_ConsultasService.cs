using System;
using Spartane.Core.Classes.Indicadores_Consultas;
using System.Collections.Generic;


namespace Spartane.Services.Indicadores_Consultas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IIndicadores_ConsultasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas entity);
        Int32 Update(Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas entity);
        IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Indicadores_Consultas.Indicadores_ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas entity);

    }
}

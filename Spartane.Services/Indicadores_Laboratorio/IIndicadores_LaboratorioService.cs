using System;
using Spartane.Core.Classes.Indicadores_Laboratorio;
using System.Collections.Generic;


namespace Spartane.Services.Indicadores_Laboratorio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IIndicadores_LaboratorioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio entity);
        Int32 Update(Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio entity);
        IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_LaboratorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio entity);

    }
}

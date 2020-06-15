using System;
using Spartane.Core.Classes.Consultas;
using System.Collections.Generic;


namespace Spartane.Services.Consultas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IConsultasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Consultas.Consultas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Consultas.Consultas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Consultas.Consultas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Consultas.Consultas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Consultas.Consultas entity);
        Int32 Update(Spartane.Core.Classes.Consultas.Consultas entity);
        IList<Spartane.Core.Classes.Consultas.Consultas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Consultas.Consultas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Consultas.ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Consultas.Consultas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Consultas.Consultas entity);
       int Update_Mediciones(Spartane.Core.Classes.Consultas.Consultas entity);
       int Update_Resultados(Spartane.Core.Classes.Consultas.Consultas entity);

    }
}

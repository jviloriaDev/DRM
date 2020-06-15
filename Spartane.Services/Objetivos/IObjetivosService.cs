using System;
using Spartane.Core.Classes.Objetivos;
using System.Collections.Generic;


namespace Spartane.Services.Objetivos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IObjetivosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Objetivos.Objetivos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Objetivos.Objetivos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Objetivos.Objetivos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Objetivos.Objetivos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Objetivos.Objetivos entity);
        Int32 Update(Spartane.Core.Classes.Objetivos.Objetivos entity);
        IList<Spartane.Core.Classes.Objetivos.Objetivos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Objetivos.Objetivos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Objetivos.ObjetivosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Objetivos.Objetivos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Objetivos.Objetivos entity);

    }
}

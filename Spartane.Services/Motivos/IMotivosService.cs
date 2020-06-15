using System;
using Spartane.Core.Classes.Motivos;
using System.Collections.Generic;


namespace Spartane.Services.Motivos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMotivosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Motivos.Motivos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Motivos.Motivos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Motivos.Motivos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Motivos.Motivos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Motivos.Motivos entity);
        Int32 Update(Spartane.Core.Classes.Motivos.Motivos entity);
        IList<Spartane.Core.Classes.Motivos.Motivos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Motivos.Motivos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Motivos.MotivosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Motivos.Motivos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Motivos.Motivos entity);

    }
}

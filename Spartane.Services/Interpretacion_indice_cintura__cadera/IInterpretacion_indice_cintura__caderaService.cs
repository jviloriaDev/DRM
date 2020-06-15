using System;
using Spartane.Core.Classes.Interpretacion_indice_cintura__cadera;
using System.Collections.Generic;


namespace Spartane.Services.Interpretacion_indice_cintura__cadera
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_indice_cintura__caderaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity);
        Int32 Update(Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity);
        IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity);

    }
}

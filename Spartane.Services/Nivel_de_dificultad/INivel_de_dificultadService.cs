using System;
using Spartane.Core.Classes.Nivel_de_dificultad;
using System.Collections.Generic;


namespace Spartane.Services.Nivel_de_dificultad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface INivel_de_dificultadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad entity);
        Int32 Update(Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad entity);
        IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad entity);

    }
}

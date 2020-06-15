using System;
using Spartane.Core.Classes.Ejercicios;
using System.Collections.Generic;


namespace Spartane.Services.Ejercicios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEjerciciosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Ejercicios.Ejercicios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Ejercicios.Ejercicios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Ejercicios.Ejercicios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Ejercicios.Ejercicios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Ejercicios.Ejercicios entity);
        Int32 Update(Spartane.Core.Classes.Ejercicios.Ejercicios entity);
        IList<Spartane.Core.Classes.Ejercicios.Ejercicios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Ejercicios.Ejercicios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Ejercicios.EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Ejercicios.Ejercicios> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Ejercicios.Ejercicios entity);

    }
}

﻿using System;
using Spartane.Core.Classes.Antiguedad_Ejercicios;
using System.Collections.Generic;


namespace Spartane.Services.Antiguedad_Ejercicios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IAntiguedad_EjerciciosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios entity);
        Int32 Update(Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios entity);
        IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios entity);

    }
}

using System;
using Spartane.Core.Classes.Titulos_Personales;
using System.Collections.Generic;


namespace Spartane.Services.Titulos_Personales
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITitulos_PersonalesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Titulos_Personales.Titulos_Personales> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Titulos_Personales.Titulos_Personales> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Titulos_Personales.Titulos_Personales> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Titulos_Personales.Titulos_Personales GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Titulos_Personales.Titulos_Personales entity);
        Int32 Update(Spartane.Core.Classes.Titulos_Personales.Titulos_Personales entity);
        IList<Spartane.Core.Classes.Titulos_Personales.Titulos_Personales> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Titulos_Personales.Titulos_Personales> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Titulos_Personales.Titulos_PersonalesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Titulos_Personales.Titulos_Personales> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Titulos_Personales.Titulos_Personales entity);

    }
}

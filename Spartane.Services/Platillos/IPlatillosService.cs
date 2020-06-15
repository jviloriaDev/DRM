using System;
using Spartane.Core.Classes.Platillos;
using System.Collections.Generic;


namespace Spartane.Services.Platillos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPlatillosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Platillos.Platillos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Platillos.Platillos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Platillos.Platillos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Platillos.Platillos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Platillos.Platillos entity);
        Int32 Update(Spartane.Core.Classes.Platillos.Platillos entity);
        IList<Spartane.Core.Classes.Platillos.Platillos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Platillos.Platillos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Platillos.PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Platillos.Platillos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Platillos.Platillos entity);

    }
}

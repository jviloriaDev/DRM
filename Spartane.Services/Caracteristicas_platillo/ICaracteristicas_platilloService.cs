using System;
using Spartane.Core.Classes.Caracteristicas_platillo;
using System.Collections.Generic;


namespace Spartane.Services.Caracteristicas_platillo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICaracteristicas_platilloService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo entity);
        Int32 Update(Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo entity);
        IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo entity);

    }
}

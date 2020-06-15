using System;
using Spartane.Core.Classes.Bancos;
using System.Collections.Generic;


namespace Spartane.Services.Bancos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IBancosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Bancos.Bancos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Bancos.Bancos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Bancos.Bancos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Bancos.Bancos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Bancos.Bancos entity);
        Int32 Update(Spartane.Core.Classes.Bancos.Bancos entity);
        IList<Spartane.Core.Classes.Bancos.Bancos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Bancos.Bancos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Bancos.BancosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Bancos.Bancos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Bancos.Bancos entity);

    }
}

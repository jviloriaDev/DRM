using System;
using Spartane.Core.Classes.Registro;
using System.Collections.Generic;


namespace Spartane.Services.Registro
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegistroService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Registro.Registro> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Registro.Registro> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Registro.Registro> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Registro.Registro GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Registro.Registro entity);
        Int32 Update(Spartane.Core.Classes.Registro.Registro entity);
        IList<Spartane.Core.Classes.Registro.Registro> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Registro.Registro> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Registro.RegistroPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Registro.Registro> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Registro.Registro entity);

    }
}

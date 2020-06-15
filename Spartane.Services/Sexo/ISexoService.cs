using System;
using Spartane.Core.Classes.Sexo;
using System.Collections.Generic;


namespace Spartane.Services.Sexo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISexoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Sexo.Sexo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Sexo.Sexo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Sexo.Sexo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Sexo.Sexo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Sexo.Sexo entity);
        Int32 Update(Spartane.Core.Classes.Sexo.Sexo entity);
        IList<Spartane.Core.Classes.Sexo.Sexo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Sexo.Sexo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Sexo.SexoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Sexo.Sexo> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Sexo.Sexo entity);

    }
}

using System;
using Spartane.Core.Classes.Tipo_de_Dieta;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_Dieta
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_DietaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta entity);
        IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_DietaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta entity);

    }
}

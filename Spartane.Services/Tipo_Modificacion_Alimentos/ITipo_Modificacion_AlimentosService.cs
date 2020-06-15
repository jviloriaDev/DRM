using System;
using Spartane.Core.Classes.Tipo_Modificacion_Alimentos;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_Modificacion_Alimentos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_Modificacion_AlimentosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos entity);
        Int32 Update(Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos entity);
        IList<Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_AlimentosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos entity);

    }
}

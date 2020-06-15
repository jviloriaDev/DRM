using System;
using Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Antecedentes_No_Patologicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Antecedentes_No_PatologicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_PatologicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity);

    }
}

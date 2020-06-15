using System;
using Spartane.Core.Classes.Detalle_Antecedentes_Familiares;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Antecedentes_Familiares
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Antecedentes_FamiliaresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares entity);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_FamiliaresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares entity);

    }
}

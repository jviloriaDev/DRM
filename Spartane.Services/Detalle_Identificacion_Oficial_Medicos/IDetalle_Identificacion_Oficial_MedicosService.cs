using System;
using Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Identificacion_Oficial_Medicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Identificacion_Oficial_MedicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity);
        IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity);

    }
}

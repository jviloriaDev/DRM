using System;
using Spartane.Core.Classes.Detalle_Titulos_Medicos;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Titulos_Medicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Titulos_MedicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos entity);
        IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos entity);

    }
}

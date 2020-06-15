using System;
using Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Convenio_Medicos_Aseguradoras
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Convenio_Medicos_AseguradorasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity);
        IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity);

    }
}

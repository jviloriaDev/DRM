using System;
using Spartane.Core.Classes.Detalle_Contratos_Empresa;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Contratos_Empresa
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Contratos_EmpresaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa entity);
        IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa entity);

    }
}

using System;
using Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Registro_Beneficiarios_Empresa
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Registro_Beneficiarios_EmpresaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa entity);
        IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa entity);

    }
}

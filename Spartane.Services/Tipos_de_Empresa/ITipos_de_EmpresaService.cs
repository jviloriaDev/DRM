using System;
using Spartane.Core.Classes.Tipos_de_Empresa;
using System.Collections.Generic;


namespace Spartane.Services.Tipos_de_Empresa
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipos_de_EmpresaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa entity);
        Int32 Update(Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa entity);
        IList<Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa entity);

    }
}

using System;
using Spartane.Core.Classes.areas_Empresas;
using System.Collections.Generic;


namespace Spartane.Services.areas_Empresas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface Iareas_EmpresasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.areas_Empresas.areas_Empresas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.areas_Empresas.areas_Empresas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.areas_Empresas.areas_Empresas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.areas_Empresas.areas_Empresas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.areas_Empresas.areas_Empresas entity);
        Int32 Update(Spartane.Core.Classes.areas_Empresas.areas_Empresas entity);
        IList<Spartane.Core.Classes.areas_Empresas.areas_Empresas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.areas_Empresas.areas_Empresas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.areas_Empresas.areas_EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.areas_Empresas.areas_Empresas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.areas_Empresas.areas_Empresas entity);

    }
}

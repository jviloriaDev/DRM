using System;
using Spartane.Core.Classes.Empresas;
using System.Collections.Generic;


namespace Spartane.Services.Empresas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEmpresasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Empresas.Empresas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Empresas.Empresas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Empresas.Empresas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Empresas.Empresas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Empresas.Empresas entity);
        Int32 Update(Spartane.Core.Classes.Empresas.Empresas entity);
        IList<Spartane.Core.Classes.Empresas.Empresas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Empresas.Empresas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Empresas.EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Empresas.Empresas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Empresas.Empresas entity);
       int Update_Datos_de_Contacto(Spartane.Core.Classes.Empresas.Empresas entity);
       int Update_Datos_Fiscales(Spartane.Core.Classes.Empresas.Empresas entity);
       int Update_Suscripcion(Spartane.Core.Classes.Empresas.Empresas entity);
       int Update_Documentacion(Spartane.Core.Classes.Empresas.Empresas entity);

    }
}
